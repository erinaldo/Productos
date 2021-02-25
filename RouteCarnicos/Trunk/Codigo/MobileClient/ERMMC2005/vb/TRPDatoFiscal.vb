Imports System.Data.SqlServerCe
Public Class TRPDatoFiscal

#Region "Propiedades"
    Dim _TransProdID As String
    Dim _FolioID As String
    Dim _FOSId As String
    Dim _NumCertificado As String = String.Empty
    Dim _Serie As String = String.Empty
    Dim _Aprobacion As String = String.Empty
    Dim _AnioAprobacion As String = String.Empty
    Dim _RazonSocial As String = String.Empty
    Dim _RFC As String = String.Empty
    Dim _TelefonoContacto As String = String.Empty
    Dim _Calle As String = String.Empty
    Dim _NumExt As String = String.Empty
    Dim _NumInt As String = String.Empty
    Dim _Colonia As String = String.Empty
    Dim _CodigoPostal As String = String.Empty
    Dim _ReferenciaDom As String = String.Empty
    Dim _Localidad As String = String.Empty
    Dim _Municipio As String = String.Empty
    Dim _Entidad As String = String.Empty
    Dim _Pais As String = String.Empty
    Dim _CadenaOriginal As String
    Dim _SelloDigital As String
    Dim _TelefonoEm As String = String.Empty
    Dim _RFCEm As String = String.Empty
    Dim _NombreEm As String = String.Empty
    Dim _CalleEm As String = String.Empty
    Dim _NumExtEm As String = String.Empty
    Dim _NumIntEm As String = String.Empty
    Dim _ColoniaEm As String = String.Empty
    Dim _LocalidadEm As String = String.Empty
    Dim _ReferenciaDomEm As String = String.Empty
    Dim _MunicipioEm As String = String.Empty
    Dim _RegionEm As String = String.Empty
    Dim _PaisEm As String = String.Empty
    Dim _CodigoPostalEm As String = String.Empty
    Dim _CalleEx As String = String.Empty
    Dim _NumExtEx As String = String.Empty
    Dim _NumIntEx As String = String.Empty
    Dim _ColoniaEx As String = String.Empty
    Dim _CodigoPostalEx As String = String.Empty
    Dim _ReferenciaDomEx As String = String.Empty
    Dim _LocalidadEx As String = String.Empty
    Dim _MunicipioEx As String = String.Empty
    Dim _EntidadEx As String = String.Empty
    Dim _PaisEx As String = String.Empty
    Dim _TipoVersion As String
    Dim _TipoNotaCredito As Int16
    Dim _MetodoPago As String = String.Empty
    Dim _CerBase64 As String = String.Empty
    Dim _LugarExpedicion As String = String.Empty
    Dim _FormaDePago As String = String.Empty
    Dim _NumCtaPago As String = String.Empty
    Dim _Banco As String = String.Empty
    Dim _DatFacturaEditados As Boolean
    Dim _MUsuarioID As String
    Dim _MetodoPagoFinal As String
    Dim _NumCtaPagoFinal As String
    Dim aTRPRegimenFiscal As Generic.SortedList(Of String, TRPRegimenFiscal)

    Public Property TransProdID() As String
        Get
            Return _TransProdID
        End Get
        Set(ByVal value As String)
            _TransProdID = value
        End Set
    End Property

    Public Property FolioID() As String
        Get
            Return _FolioID
        End Get
        Set(ByVal value As String)
            _FolioID = value
        End Set
    End Property

    Public Property FOSId() As String
        Get
            Return _FOSId
        End Get
        Set(ByVal value As String)
            _FOSId = value
        End Set
    End Property
    Public Property NumCertificado() As String
        Get
            Return _NumCertificado
        End Get
        Set(ByVal value As String)
            _NumCertificado = value
        End Set
    End Property
    Public Property Serie() As String
        Get
            Return _Serie
        End Get
        Set(ByVal value As String)
            _Serie = value
        End Set
    End Property
    Public Property Aprobacion() As String
        Get
            Return _Aprobacion
        End Get
        Set(ByVal value As String)
            _Aprobacion = value
        End Set
    End Property
    Public Property AnioAprobacion() As String
        Get
            Return _AnioAprobacion
        End Get
        Set(ByVal value As String)
            _AnioAprobacion = value
        End Set
    End Property
    Public Property RazonSocial() As String
        Get
            Return _RazonSocial
        End Get
        Set(ByVal value As String)
            _RazonSocial = value
        End Set
    End Property

    Public Property RFC() As String
        Get
            Return _RFC
        End Get
        Set(ByVal value As String)
            _RFC = value
        End Set
    End Property

    Public Property TelefonoContacto() As String
        Get
            Return _TelefonoContacto
        End Get
        Set(ByVal value As String)
            _TelefonoContacto = value
        End Set
    End Property

    Public Property Calle() As String
        Get
            Return IIf(IsNothing(_Calle), "", _Calle)
        End Get
        Set(ByVal value As String)
            _Calle = value
        End Set
    End Property

    Public Property NumExt() As String
        Get
            Return IIf(IsNothing(_NumExt), "", _NumExt)
        End Get
        Set(ByVal value As String)
            _NumExt = value
        End Set
    End Property

    Public Property NumInt() As String
        Get
            Return IIf(IsNothing(_NumInt), "", _NumInt)
        End Get
        Set(ByVal value As String)
            _NumInt = value
        End Set
    End Property

    Public Property Colonia() As String
        Get
            Return IIf(IsNothing(_Colonia), "", _Colonia)
        End Get
        Set(ByVal value As String)
            _Colonia = value
        End Set
    End Property

    Public Property CodigoPostal() As String
        Get
            Return IIf(IsNothing(_CodigoPostal), "", _CodigoPostal)
        End Get
        Set(ByVal value As String)
            _CodigoPostal = value
        End Set
    End Property
    Public Property ReferenciaDom() As String
        Get
            Return IIf(IsNothing(_ReferenciaDom), "", _ReferenciaDom)
        End Get
        Set(ByVal value As String)
            _ReferenciaDom = value
        End Set
    End Property
    Public Property Localidad() As String
        Get
            Return IIf(IsNothing(_Localidad), "", _Localidad)
        End Get
        Set(ByVal value As String)
            _Localidad = value
        End Set
    End Property
    Public Property Municipio() As String
        Get
            Return IIf(IsNothing(_Municipio), "", _Municipio)
        End Get
        Set(ByVal value As String)
            _Municipio = value
        End Set
    End Property
    Public Property Entidad() As String
        Get
            Return IIf(IsNothing(_Entidad), "", _Entidad)
        End Get
        Set(ByVal value As String)
            _Entidad = value
        End Set
    End Property
    Public Property Pais() As String
        Get
            Return IIf(IsNothing(_Pais), "", _Pais)
        End Get
        Set(ByVal value As String)
            _Pais = value
        End Set
    End Property
    Public Property CadenaOriginal() As String
        Get
            Return _CadenaOriginal
        End Get
        Set(ByVal value As String)
            _CadenaOriginal = value
        End Set
    End Property
    Public Property SelloDigital() As String
        Get
            Return _SelloDigital
        End Get
        Set(ByVal value As String)
            _SelloDigital = value
        End Set
    End Property
    Public Property TelefonoEm() As String
        Get
            Return _TelefonoEm
        End Get
        Set(ByVal value As String)
            _TelefonoEm = value
        End Set
    End Property
    Public Property RFCEm() As String
        Get
            Return _RFCEm
        End Get
        Set(ByVal value As String)
            _RFCEm = value
        End Set
    End Property
    Public Property NombreEm() As String
        Get
            Return _NombreEm
        End Get
        Set(ByVal value As String)
            _NombreEm = value
        End Set
    End Property
    Public Property CalleEm() As String
        Get
            Return _CalleEm
        End Get
        Set(ByVal value As String)
            _CalleEm = value
        End Set
    End Property
    Public Property NumExtEm() As String
        Get
            Return _NumExtEm
        End Get
        Set(ByVal value As String)
            _NumExtEm = value
        End Set
    End Property
    Public Property NumIntEm() As String
        Get
            Return _NumIntEm
        End Get
        Set(ByVal value As String)
            _NumIntEm = value
        End Set
    End Property
    Public Property ColoniaEm() As String
        Get
            Return _ColoniaEm
        End Get
        Set(ByVal value As String)
            _ColoniaEm = value
        End Set
    End Property
    Public Property LocalidadEm() As String
        Get
            Return _LocalidadEm
        End Get
        Set(ByVal value As String)
            _LocalidadEm = value
        End Set
    End Property
    Public Property ReferenciaDomEm() As String
        Get
            Return _ReferenciaDomEm
        End Get
        Set(ByVal value As String)
            _ReferenciaDomEm = value
        End Set
    End Property
    Public Property MunicipioEm() As String
        Get
            Return _MunicipioEm
        End Get
        Set(ByVal value As String)
            _MunicipioEm = value
        End Set
    End Property

    Public Property RegionEm() As String
        Get
            Return _RegionEm
        End Get
        Set(ByVal value As String)
            _RegionEm = value
        End Set
    End Property
    Public Property PaisEm() As String
        Get
            Return _PaisEm
        End Get
        Set(ByVal value As String)
            _PaisEm = value
        End Set
    End Property
    Public Property CodigoPostalEm() As String
        Get
            Return _CodigoPostalEm
        End Get
        Set(ByVal value As String)
            _CodigoPostalEm = value
        End Set
    End Property
    Public Property CalleEx() As String
        Get
            Return _CalleEx
        End Get
        Set(ByVal value As String)
            _CalleEx = value
        End Set
    End Property
    Public Property NumExtEx() As String
        Get
            Return _NumExtEx
        End Get
        Set(ByVal value As String)
            _NumExtEx = value
        End Set
    End Property
    Public Property NumIntEx() As String
        Get
            Return _NumIntEx
        End Get
        Set(ByVal value As String)
            _NumIntEx = value
        End Set
    End Property
    Public Property ColoniaEx() As String
        Get
            Return _ColoniaEx
        End Get
        Set(ByVal value As String)
            _ColoniaEx = value
        End Set
    End Property
    Public Property CodigoPostalEx() As String
        Get
            Return _CodigoPostalEx
        End Get
        Set(ByVal value As String)
            _CodigoPostalEx = value
        End Set
    End Property
    Public Property ReferenciaDomEx() As String
        Get
            Return _ReferenciaDomEx
        End Get
        Set(ByVal value As String)
            _ReferenciaDomEx = value
        End Set
    End Property
    Public Property LocalidadEx() As String
        Get
            Return _LocalidadEx
        End Get
        Set(ByVal value As String)
            _LocalidadEx = value
        End Set
    End Property
    Public Property MunicipioEx() As String
        Get
            Return _MunicipioEx
        End Get
        Set(ByVal value As String)
            _MunicipioEx = value
        End Set
    End Property
    Public Property EntidadEx() As String
        Get
            Return _EntidadEx
        End Get
        Set(ByVal value As String)
            _EntidadEx = value
        End Set
    End Property

    Public Property PaisEx() As String
        Get
            Return _PaisEx
        End Get
        Set(ByVal value As String)
            _PaisEx = value
        End Set
    End Property

    Public Property TipoVersion() As String
        Get
            Return _TipoVersion
        End Get
        Set(ByVal value As String)
            _TipoVersion = value
        End Set
    End Property

    Public Property TipoNotaCredito() As Int16
        Get
            Return _TipoNotaCredito
        End Get
        Set(ByVal value As Int16)
            _TipoNotaCredito = value
        End Set
    End Property

    Public Property MetodoPago() As String
        Get
            Return _MetodoPago
        End Get
        Set(ByVal value As String)
            _MetodoPago = value
        End Set
    End Property
    Public Property CerBase64() As String
        Get
            Return _CerBase64
        End Get
        Set(ByVal value As String)
            _CerBase64 = value
        End Set
    End Property

    Public Property LugarExpedicion() As String
        Get
            Return _LugarExpedicion
        End Get
        Set(ByVal value As String)
            _LugarExpedicion = value
        End Set
    End Property
    Public Property FormaDePago() As String
        Get
            Return _FormaDePago
        End Get
        Set(ByVal value As String)
            _FormaDePago = value
        End Set
    End Property
    Public Property NumCtaPago() As String
        Get
            Return _NumCtaPago
        End Get
        Set(ByVal value As String)
            _NumCtaPago = value
        End Set
    End Property
    Public Property Banco() As String
        Get
            Return _Banco
        End Get
        Set(ByVal value As String)
            _Banco = value
        End Set
    End Property
    Public Property DatFacturaEditados() As Boolean
        Get
            Return _DatFacturaEditados
        End Get
        Set(ByVal value As Boolean)
            _DatFacturaEditados = value
        End Set
    End Property

    Public Property MUsuarioID() As Boolean
        Get
            Return _MUsuarioID
        End Get
        Set(ByVal value As Boolean)
            MUsuarioID = value
        End Set
    End Property
    Public Property MetodoPagoFinal() As String
        Get
            Return _MetodoPagoFinal
        End Get
        Set(ByVal value As String)
            _MetodoPagoFinal = value
        End Set
    End Property

    Public Property NumCtaPagoFinal() As String
        Get
            Return IIf(IsNothing(_NumCtaPagoFinal), "", _NumCtaPagoFinal)
        End Get
        Set(ByVal value As String)
            _NumCtaPagoFinal = value
        End Set
    End Property

    Public Property TRPRegimenFiscal() As Generic.SortedList(Of String, TRPRegimenFiscal)
        Get
            Return aTRPRegimenFiscal
        End Get
        Set(ByVal value As Generic.SortedList(Of String, TRPRegimenFiscal))
            aTRPRegimenFiscal = value
        End Set
    End Property

#End Region

#Region "Guardar, Actualizar"

    Public Sub Insertar()
        Dim strSQL As New Text.StringBuilder
        With strSQL
            .Append("Insert Into TRPDatoFiscal(TransProdID,FolioID,FosID, NumCertificado, Serie, Aprobacion, AnioAprobacion, TipoVersion,RazonSocial,RFC,TelefonoContacto,Calle,NumExt,NumInt,Colonia,Localidad,Municipio,Entidad,Pais,CodigoPostal,ReferenciaDom,CadenaOriginal,SelloDigital,TelefonoEm,RFCEm,NombreEm,CalleEm,NumExtEm,NumIntEm,ColoniaEm,LocalidadEm,ReferenciaDomEm,MunicipioEm,RegionEM,PaisEm,CodigoPostalEm,CalleEx,NumExtEx,NumIntEx,ColoniaEx,CodigoPostalEx,ReferenciaDomEx,LocalidadEx,MunicipioEx,EntidadEx,PaisEx,TipoNotaCredito,MetodoPago,NumCtaPago,Banco,LugarExpedicion,FormaDePago,CerBase64,DatFacturaEditados,MFechaHora,MUsuarioId,Enviado) ")
            .Append(" values ('" & TransProdID & "'")
            .Append(",'" & FolioID & "'")
            .Append(",'" & FOSId & "'")
            .Append(",'" & NumCertificado & "'")
            .Append(",'" & Serie & "'")
            .Append(",'" & Aprobacion & "'")
            .Append(",'" & AnioAprobacion & "'")
            .Append(",'" & TipoVersion & "'")
            .Append(",'" & RazonSocial.Replace("'", "''") & "'")
            .Append(",'" & RFC.Replace("-", "").Replace("'", "''") & "'")
            .Append(",'" & TelefonoContacto.Replace("'", "''") & "'")
            .Append(",'" & Calle.Replace("'", "''") & "'")
            .Append(",'" & NumExt.Replace("'", "''") & "'")
            .Append(",'" & NumInt.Replace("'", "''") & "'")
            .Append(",'" & Colonia.Replace("'", "''") & "'")
            .Append(",'" & Localidad.Replace("'", "''") & "'")
            .Append(",'" & Municipio.Replace("'", "''") & "'")
            .Append(",'" & Entidad.Replace("'", "''") & "'")
            .Append(",'" & Pais.Replace("'", "''") & "'")
            .Append(",'" & CodigoPostal.Replace("'", "''") & "'")
            .Append(",'" & ReferenciaDom.Replace("'", "''") & "'")
            .Append(",'" & CadenaOriginal & "'")
            .Append(",'" & CrearSelloDigital(CType(SubEmpresa.aSubEmpresa(0), SubEmpresa.DatosEmpresa).SubEmpresaId, CadenaOriginal, Now.Year).ToString.Replace("'", "''") & "'")
            .Append(",'" & TelefonoContacto & "'")
            .Append(",'" & RFCEm.ToString.Replace("'", "''") & "'")
            .Append(",'" & NombreEm.ToString.Replace("'", "''") & "'")
            .Append(",'" & CalleEm.ToString.Replace("'", "''") & "'")
            .Append(",'" & NumExtEm.ToString.Replace("'", "''") & "'")
            .Append(",'" & NumIntEm.ToString.Replace("'", "''") & "'")
            .Append(",'" & ColoniaEm.ToString.Replace("'", "''") & "'")
            .Append(",'" & LocalidadEm.ToString.Replace("'", "''") & "'")
            .Append(",'" & ReferenciaDomEm.ToString.Replace("'", "''") & "'")
            .Append(",'" & MunicipioEm.ToString.Replace("'", "''") & "'")
            .Append(",'" & RegionEm.ToString.Replace("'", "''") & "'")
            .Append(",'" & PaisEm.ToString.Replace("'", "''") & "'")
            .Append(",'" & CodigoPostalEm.ToString.Replace("'", "''") & "'")
            .Append(",'" & CalleEx.ToString.Replace("'", "''") & "'")
            .Append(",'" & NumExtEx.ToString.Replace("'", "''") & "'")
            .Append(",'" & NumIntEx.ToString.Replace("'", "''") & "'")
            .Append(",'" & ColoniaEx.ToString.Replace("'", "''") & "'")
            .Append(",'" & CodigoPostalEx.ToString.Replace("'", "''") & "'")
            .Append(",'" & ReferenciaDomEx.ToString.Replace("'", "''") & "'")
            .Append(",'" & LocalidadEx.ToString.Replace("'", "''") & "'")
            .Append(",'" & MunicipioEx.ToString.Replace("'", "''") & "'")
            .Append(",'" & EntidadEx.ToString.Replace("'", "''") & "'")
            .Append(",'" & PaisEx.ToString.Replace("'", "''") & "'")
            .Append("," & TipoNotaCredito.ToString())
            .Append(",'" & MetodoPago.ToString.Replace("'", "''") & "'")
            .Append(",'" & NumCtaPago.ToString.Replace("'", "''") & "'")
            .Append(",'" & Banco.ToString.Replace("'", "''") & "'")
            .Append(",'" & LugarExpedicion.ToString.Replace("'", "''") & "'")
            .Append(",'" & FormaDePago.ToString.Replace("'", "''") & "'")
            .Append(",'" & CerBase64.ToString.Replace("'", "''") & "'")
            .Append("," & IIf(DatFacturaEditados, 1, 0))
            .Append("," & UniFechaSQL(Now) & ",'" & oVendedor.UsuarioId & "',0)")
        End With

        oDBVen.EjecutarComandoSQL(strSQL.ToString)

        For Each oTRPRegimenFiscal As TRPRegimenFiscal In aTRPRegimenFiscal.Values
            strSQL = New Text.StringBuilder
            With strSQL
                .Append("Insert Into TRPRegimenFiscal(TransProdID,RegimenID,Descripcion,MFechaHora,MUsuarioId,Enviado) ")
                .Append(" values ('" & oTRPRegimenFiscal.TransProdID & "'")
                .Append(",'" & oTRPRegimenFiscal.RegimenFiscalID & "'")
                .Append(",'" & oTRPRegimenFiscal.Descripcion & "'")
                .Append("," & UniFechaSQL(Now) & ",'" & oVendedor.UsuarioId & "',0)")
            End With
            oDBVen.EjecutarComandoSQL(strSQL.ToString)
        Next

    End Sub

#End Region

#Region "CrearSelloDigital"
    Public Function CrearSelloDigital(ByVal parsSubEmpresaID As String, ByVal pvCadenaOriginal As String, ByVal pvAnioFacturacion As Integer)
        Dim dt As Data.DataTable = oDBVen.RealizarConsultaSQL("select ArchivoPEM from SEMHist where SubEmpresaID='" & parsSubEmpresaID & "'", "conhist")

        If dt Is Nothing Or dt.Rows.Count <= 0 Or dt.Rows(0).Item(0).ToString = "" Then
            dt.Dispose()
            dt = Nothing
            Return ""
        End If

        Dim selloLeido As System.Text.StringBuilder
        Dim path As System.Text.StringBuilder

        Try
            path = New System.Text.StringBuilder
            path.Append(IO.Path.GetDirectoryName(Reflection.Assembly.GetExecutingAssembly.GetName.CodeBase) & "\")

            selloLeido = New System.Text.StringBuilder
            Dim swPEM As New System.IO.FileStream(path.ToString & "ArchivoPEM.key.pem", System.IO.FileMode.Create)
            swPEM.Write(Convert.FromBase64String(dt.Rows(0).Item(0)), 0, Convert.FromBase64String(dt.Rows(0).Item(0)).Length)
            swPEM.Close()
            swPEM = Nothing

            Dim sw As New System.IO.StreamWriter(path.ToString & "cadenaOriginal.txt", False)
            sw.Write(pvCadenaOriginal)
            sw.Flush()
            sw.Close()
            sw = Nothing

            If pvAnioFacturacion < 2011 Then
                Process.Start("""" & path.ToString & "OPENSSLCE\OPENSSL.exe" & """", "dgst -md5 -out """ & path.ToString & "sello.txt"" -sign """ & path.ToString & "ArchivoPEM.key.pem"" """ & path.ToString & "cadenaOriginal.txt""")
            Else
                Process.Start("""" & path.ToString & "OPENSSLCE\OPENSSL.exe" & """", "dgst -sha1 -out """ & path.ToString & "sello.txt"" -sign """ & path.ToString & "ArchivoPEM.key.pem"" """ & path.ToString & "cadenaOriginal.txt""")
            End If
            System.Threading.Thread.Sleep(500)
            Process.Start("""" & path.ToString & "OPENSSLCE\OPENSSL.exe" & """", "enc -base64 -in """ & path.ToString & "sello.txt"" -out """ & path.ToString & "sello64.txt"" -A")
            System.Threading.Thread.Sleep(500)

            Dim leer_archivo As System.IO.StreamReader = System.IO.File.OpenText(path.ToString & "sello64.txt")

            selloLeido.Append(leer_archivo.ReadToEnd())
            leer_archivo.Close()
            leer_archivo = Nothing

            System.IO.File.Delete(path.ToString & "sello.txt")
            System.IO.File.Delete(path.ToString & "sello64.txt")
            System.IO.File.Delete(path.ToString & "cadenaOriginal.txt")
            System.IO.File.Delete(path.ToString & "ArchivoPEM.key.pem")

        Catch ex As Exception
            selloLeido = Nothing
            path = Nothing
            dt.Dispose()
            dt = Nothing
            MsgBox(ex.Message())
            Return ""
        End Try

        path = Nothing
        dt.Dispose()
        dt = Nothing
        Return selloLeido.ToString
    End Function

#End Region

#Region "CadenaOriginalM"
    Private Function sValido(ByVal pvCadena As String) As String
        Dim strValido As String
        If pvCadena.Trim() = "" Then Return ""
        strValido = pvCadena.Replace("|", "/")
        strValido = strValido.Replace(ControlChars.Tab, " "c)
        strValido = strValido.Replace(ControlChars.Lf, " "c)
        Dim Arreglo As String() = strValido.Split(" "c)
        strValido = ""
        For Each a As String In Arreglo
            If a <> "" Then strValido += a & " "
        Next

        Return strValido.Trim() & "|"
    End Function

    Private Function dValido(ByVal pvCadena As Object) As String
        If pvCadena.ToString = "" Then Return ""

        Return Format(pvCadena, "0.00") & "|"
    End Function

    Private Function fValido(ByVal parFecha As Date) As String
        Return parFecha.ToString("s") & "|"
    End Function

    Private Sub obtenerSubtotales(ByRef parSubTotal As Decimal, ByRef parTotal As Decimal, ByRef parDescuento As Decimal, ByVal parTransProdId As String, ByVal parsClienteClave As String)
        Dim vlConsulta As New System.Text.StringBuilder
        Dim vlDt As DataTable
        Dim dtImpNoDes As DataTable
        parSubTotal = 0
        parTotal = 0
        parDescuento = 0

        Dim sFiltro As String
        Dim sFiltroTDI As String
        sFiltro = " TRP.TransProdId in ("
        sFiltroTDI = " TransProdId in ("
        sFiltro &= "'" & parTransProdId & "',"
        sFiltroTDI &= "'" & parTransProdId & "',"

        sFiltro = sFiltro.Remove(sFiltro.Length - 1, 1)
        sFiltroTDI = sFiltroTDI.Remove(sFiltroTDI.Length - 1, 1)
        sFiltro &= ") "
        sFiltroTDI &= ") "

        vlConsulta.Append("select TRP.TransProdID, sum(TPD.Cantidad * (TPD.Precio + case when TDI.ImpuestoPU is null then 0 else TDI.ImpuestoPU end)) as SubTotal, ")
        vlConsulta.Append("(TRP.DescuentoImp + TRP.DescuentoVendedor + sum(TPD.DescuentoImp) + SUM(case when TDI.ImpuestoPU is null then 0 else (TPD.Cantidad * TDI.ImpuestoPU) - TDI.ImpDesGlb end)) as Descuento, TRP.Total ")
        vlConsulta.Append("from TransProd TRP ")
        vlConsulta.Append("inner join TransProdDetalle TPD on TRP.TransProdId = TPD.TransProdId ")
        vlConsulta.Append("left join ( ")
        vlConsulta.Append("select TransProdId, TransProdDetalleId, sum(ImpuestoPU) as ImpuestoPU, sum(ImpDesGlb) as ImpDesGlb ")
        vlConsulta.Append("from TpdImpuesto ")
        vlConsulta.Append("where " & sFiltroTDI & " and ImpuestoClave in ( ")
        vlConsulta.Append("select ImpuestoClave ")
        vlConsulta.Append("from CLINoDesImp ")
        vlConsulta.Append("where ClienteClave = '" & parsClienteClave & "' and getdate() between FechaInicio and FechaFin) ")
        vlConsulta.Append("group by TransProdId, TransProdDetalleId ")
        vlConsulta.Append(")as TDI on TPD.TransProdId = TDI.TransProdId and TPD.TransProdDetalleId = TDI.TransProdDetalleId ")
        vlConsulta.Append("where " & sFiltro & " ")
        vlConsulta.Append("group by TRP.TransProdID, TRP.DescuentoImp, TRP.DescuentoVendedor, TRP.Total ")


        vlDt = oDBVen.RealizarConsultaSQL(vlConsulta.ToString, "Transprod")

        For Each row As DataRow In vlDt.Rows
            parSubTotal += row("subtotal") '+ nSubtotalImp
            parTotal += row("total")
            parDescuento += IIf(IsDBNull(row("descuento")), 0, row("descuento")) '+ nDescuentoImp
        Next

        vlConsulta = Nothing
        vlDt.Dispose()
        vlDt = Nothing
    End Sub

    Public Function CrearCadenaOriginalM(ByVal paroTRPdocumento As TransProd, ByVal parsTransProdIdVenta As String, ByVal parsClienteClave As String, ByVal bFactura As Boolean) As String

        Dim OP_CadenaOriginal As New System.Text.StringBuilder("||")
        Dim vlDt As DataTable
        Dim vlUnidad As DataTable

        'Datos del Comprobante
        OP_CadenaOriginal.Append(sValido(TipoVersion))
        OP_CadenaOriginal.Append(sValido(Serie))
        If paroTRPdocumento.FolioActual.Substring(0, Serie.Length) = Serie.ToString Then
            OP_CadenaOriginal.Append(sValido(paroTRPdocumento.FolioActual.Remove(0, Serie.ToString.Length)))
        Else
            OP_CadenaOriginal.Append(sValido(paroTRPdocumento.FolioActual))
        End If

        OP_CadenaOriginal.Append(fValido(paroTRPdocumento.FechaHoraAlta))
        OP_CadenaOriginal.Append(sValido(Aprobacion.ToString))
        OP_CadenaOriginal.Append(sValido(AnioAprobacion.ToString))
        If bFactura Then
            OP_CadenaOriginal.Append(sValido("ingreso"))
        Else
            OP_CadenaOriginal.Append(sValido("egreso"))
        End If
        OP_CadenaOriginal.Append(sValido(FormaDePago))

        Dim dSubtotal, dTotal, dDescuento As Decimal
        obtenerSubtotales(dSubtotal, dTotal, dDescuento, parsTransProdIdVenta, parsClienteClave)
        OP_CadenaOriginal.Append(dValido(dSubtotal))
        OP_CadenaOriginal.Append(dValido(dDescuento))
        OP_CadenaOriginal.Append(dValido(paroTRPdocumento.Total))

        If TipoVersion = "2.2" Then
            OP_CadenaOriginal.Append(sValido(MetodoPagoFinal))
            OP_CadenaOriginal.Append(sValido(LugarExpedicion))
            OP_CadenaOriginal.Append(sValido(NumCtaPagoFinal))
            If Not IsNothing(paroTRPdocumento.MonedaID) AndAlso paroTRPdocumento.MonedaID <> "" Then
                OP_CadenaOriginal.Append(dValido(paroTRPdocumento.TipoCambio))
                Dim iTipoCodigo As Integer = oDBVen.EjecutarCmdScalarIntSQL("Select TipoCodigo from moneda where MonedaID='" + paroTRPdocumento.MonedaID + "' ")
                OP_CadenaOriginal.Append(sValido(ValorReferencia.BuscarEquivalente("CDGOMON", iTipoCodigo.ToString)))
            End If
        End If

        'Datos del emisor
        OP_CadenaOriginal.Append(sValido(RFCEm))
        OP_CadenaOriginal.Append(sValido(NombreEm))
        OP_CadenaOriginal.Append(sValido(CalleEm))
        OP_CadenaOriginal.Append(sValido(NumExtEm))
        OP_CadenaOriginal.Append(sValido(NumIntEm))
        OP_CadenaOriginal.Append(sValido(ColoniaEm))
        OP_CadenaOriginal.Append(sValido(LocalidadEm))
        OP_CadenaOriginal.Append(sValido(ReferenciaDomEm))
        OP_CadenaOriginal.Append(sValido(MunicipioEm))
        OP_CadenaOriginal.Append(sValido(RegionEm))
        OP_CadenaOriginal.Append(sValido(PaisEm))
        OP_CadenaOriginal.Append(sValido(CodigoPostalEm))


        ' expedición
        OP_CadenaOriginal.Append(sValido(CalleEx))
        OP_CadenaOriginal.Append(sValido(NumExtEx))
        OP_CadenaOriginal.Append(sValido(NumIntEx))
        OP_CadenaOriginal.Append(sValido(ColoniaEx))
        OP_CadenaOriginal.Append(sValido(LocalidadEx))
        OP_CadenaOriginal.Append(sValido(ReferenciaDomEx))
        OP_CadenaOriginal.Append(sValido(MunicipioEx))
        OP_CadenaOriginal.Append(sValido(EntidadEx))
        OP_CadenaOriginal.Append(sValido(PaisEx))
        OP_CadenaOriginal.Append(sValido(CodigoPostalEx))

        If TipoVersion = "2.2" Then
            'Regimen fiscal
            For Each RegimenDesc As String In aTRPRegimenFiscal.Keys
                OP_CadenaOriginal.Append(sValido(RegimenDesc))
            Next
        End If

        'receptor
        OP_CadenaOriginal.Append(sValido(RFC))
        OP_CadenaOriginal.Append(sValido(RazonSocial))
        OP_CadenaOriginal.Append(sValido(Calle))
        OP_CadenaOriginal.Append(sValido(NumExt))
        OP_CadenaOriginal.Append(sValido(NumInt))
        OP_CadenaOriginal.Append(sValido(Colonia))
        OP_CadenaOriginal.Append(sValido(Localidad))
        OP_CadenaOriginal.Append(sValido(ReferenciaDom))
        OP_CadenaOriginal.Append(sValido(Municipio))
        OP_CadenaOriginal.Append(sValido(Entidad))
        OP_CadenaOriginal.Append(sValido(Pais))
        OP_CadenaOriginal.Append(sValido(CodigoPostal))

        Dim vlConsulta As New System.Text.StringBuilder
        Dim sFiltro As String
        Dim sFiltroTDI As String
        sFiltro = " TRP.TransProdId in ("
        sFiltroTDI = " TransProdId in ("
        'For i As Integer = 0 To parTransProdID.Count - 1
        sFiltro &= "'" & parsTransProdIdVenta & "',"
        sFiltroTDI &= "'" & parsTransProdIdVenta & "',"
        'Next
        sFiltro = sFiltro.Remove(sFiltro.Length - 1, 1)
        sFiltroTDI = sFiltroTDI.Remove(sFiltroTDI.Length - 1, 1)
        sFiltro &= ") "
        sFiltroTDI &= ") "

        vlConsulta.Append("select sum(TPD.Cantidad) as Cantidad, TPD.TipoUnidad, TPD.ProductoClave, PRO.NombreLargo as Descripcion, ")
        vlConsulta.Append("(TPD.Precio + case when TDI.ImpuestoPU is null then 0 else TDI.ImpuestoPU end) as ValorUnitario1, ")
        vlConsulta.Append("sum((Cantidad * (TPD.Precio + case when TDI.ImpuestoPU is null then 0 else TDI.ImpuestoPU end))) as Importe1 ")
        vlConsulta.Append("from TransProd TRP ")
        vlConsulta.Append("inner join TransProdDetalle TPD on TRP.TransProdId = TPD.TransProdId ")
        vlConsulta.Append("inner join Producto PRO on PRO.ProductoClave = TPD.ProductoClave ")
        vlConsulta.Append("left join ( ")
        vlConsulta.Append("select TransProdId, TransProdDetalleId, sum(ImpuestoPU) as ImpuestoPU, sum(ImpDesGlb) as ImpDesGlb ")
        vlConsulta.Append("from TpdImpuesto ")
        vlConsulta.Append("where " & sFiltroTDI & " and ImpuestoClave in ( ")
        vlConsulta.Append("select ImpuestoClave ")
        vlConsulta.Append("from CLINoDesImp ")
        vlConsulta.Append("where ClienteClave = '" & parsClienteClave & "' and getdate() between FechaInicio and FechaFin) ")
        vlConsulta.Append("group by TransProdId, TransProdDetalleId ")
        vlConsulta.Append(")as TDI on TPD.TransProdId = TDI.TransProdId and TPD.TransProdDetalleId = TDI.TransProdDetalleId ")
        vlConsulta.Append("where " & sFiltro & " ")
        vlConsulta.Append("group by TPD.TipoUnidad, TPD.ProductoClave, PRO.NombreLargo, (TPD.Precio + case when TDI.ImpuestoPU is null then 0 else TDI.ImpuestoPU end) ")
        vlConsulta.Append("order by TPD.ProductoClave, TPD.TipoUnidad, (TPD.Precio + case when TDI.ImpuestoPU is null then 0 else TDI.ImpuestoPU end) ")

        'conceptos
        vlDt = oDBVen.RealizarConsultaSQL(vlConsulta.ToString, "Transprod")
        'Pedimentos
        Dim dtPedimentos As DataTable = New DataTable
        If (TipoNotaCredito = 0) Then
            dtPedimentos = oDBVen.RealizarConsultaSQL("Select distinct TRPP.ProductoClave, TRPP.NumPedimento, TRPP.Aduana, TRPP.FechaIngreso from TRPPedimento TRPP inner join TransProd TRP on TRPP.TransProdID = TRP.TransProdId where TRP.Tipo = 1 and TRPP.Facturado = 1 and TRP.FacturaID='" & Me.TransProdID & "'", "Pedimentos")
        End If

        vlUnidad = oDBApp.RealizarConsultaSQL("select vavclave, descripcion from vavdescripcion  where varcodigo = 'unidadv' ", "vavDescripcion")
        For Each row As DataRow In vlDt.Rows
            For y As Integer = 0 To vlDt.Columns.Count - 1
                Select Case vlDt.Columns(y).ToString.ToLower
                    Case "valorunitario1", "importe1", "cantidad"
                        OP_CadenaOriginal.Append(dValido(row(y)))
                    Case "tipounidad"
                        For Each rUnidad As DataRow In vlUnidad.Rows
                            If rUnidad("vavclave") = row("tipounidad") Then
                                OP_CadenaOriginal.Append(sValido(rUnidad("descripcion")))
                                Exit For
                            End If
                        Next
                    Case Else
                        OP_CadenaOriginal.Append(sValido(row(y)))
                End Select
            Next
            If TipoNotaCredito = 0 Then
                If (Not IsNothing(dtPedimentos) AndAlso Not IsDBNull(dtPedimentos)) Then
                    For Each dr As DataRow In dtPedimentos.Select("ProductoClave = '" & row("ProductoClave") & "'")
                        OP_CadenaOriginal.Append(sValido(dr("NumPedimento")))
                        OP_CadenaOriginal.Append(Microsoft.VisualBasic.Format(dr("FechaIngreso"), "yyyy-MM-dd") & "|")
                        OP_CadenaOriginal.Append(sValido(dr("Aduana")))
                    Next
                End If
            End If
        Next

        'dtPedimentos.Dispose()
        'impuestos
        Dim vlImpuesto, vlTasa, vlImporte As ArrayList
        If TipoNotaCredito = 0 Then
            TransProd.ImpuestosConDesc(paroTRPdocumento.TransProdId, parsClienteClave, vlImpuesto, vlTasa, vlImporte)
        Else
            Dim aId As New ArrayList()
            aId.Add(paroTRPdocumento.TransProdId)
            TransProd.ImpuestosConDesc(aId, parsClienteClave, vlImpuesto, vlTasa, vlImporte)
        End If

        Dim nTotalImpuesto As Double = 0
        For i As Integer = 0 To vlImpuesto.Count - 1
            OP_CadenaOriginal.Append(sValido(vlImpuesto.Item(i)))
            OP_CadenaOriginal.Append(Microsoft.VisualBasic.Strings.Format(vlTasa.Item(i), "0.0#") + "|")
            OP_CadenaOriginal.Append(dValido(vlImporte.Item(i)))
            nTotalImpuesto += vlImporte.Item(i)
        Next

        OP_CadenaOriginal.Append(dValido(nTotalImpuesto))

        OP_CadenaOriginal.Append("|")

        vlConsulta = Nothing
        vlDt.Dispose()
        vlDt = Nothing
        vlUnidad.Dispose()
        vlUnidad = Nothing
        vlImpuesto = Nothing
        vlTasa = Nothing
        vlImporte = Nothing

        Return OP_CadenaOriginal.ToString
    End Function
#End Region

    Public Sub New()
        aTRPRegimenFiscal = New Generic.SortedList(Of String, TRPRegimenFiscal)
    End Sub
End Class

Public Class TRPRegimenFiscal
#Region "Propiedades"
    Dim _TransProdID As String
    Dim _RegimenFiscalID As String
    Dim _Descripcion As String

    Public Property TransProdID() As String
        Get
            Return _TransProdID
        End Get
        Set(ByVal value As String)
            _TransProdID = value
        End Set
    End Property
    Public Property RegimenFiscalID() As String
        Get
            Return _RegimenFiscalID
        End Get
        Set(ByVal value As String)
            _RegimenFiscalID = value
        End Set
    End Property

    Public Property Descripcion() As String
        Get
            Return _Descripcion
        End Get
        Set(ByVal value As String)
            _Descripcion = value
        End Set
    End Property

#End Region
End Class