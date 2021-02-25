Imports BASLOG

Public Class cTRPDatoFiscal
    Inherits BASLOG.cClaseNodo

#Region "Propiedades"
    Public ReadOnly Property TransProdID() As String
        Get
            Return Me.Padre.ObtenerValorPropiedad("TransProdID")
        End Get
    End Property
    Public Property FolioId() As String
        Get
            Return IIf(IsDBNull(Me.Tabla.Campos("FolioId").Valor), "", Me.Tabla.Campos("FolioId").Valor)
        End Get
        Set(ByVal Value As String)
            Me.Tabla.Campos("FolioId").Valor = Value
            If Me.Status = eEstado.Recuperado Then
                Me.tEstado = eEstado.Modificado
            End If
        End Set
    End Property
    Public Property FOSId() As String
        Get
            Return IIf(IsDBNull(Me.Tabla.Campos("FOSId").Valor), "", Me.Tabla.Campos("FOSId").Valor)
        End Get
        Set(ByVal Value As String)
            Me.Tabla.Campos("FOSId").Valor = Value
            If Me.Status = eEstado.Recuperado Then
                Me.tEstado = eEstado.Modificado
            End If
        End Set
    End Property
    Public Property NumCertificado() As String
        Get
            Return Me.Tabla.Campos("NumCertificado").Valor
        End Get
        Set(ByVal Value As String)
            Me.Tabla.Campos("NumCertificado").Valor = Value
            If Me.Status = eEstado.Recuperado Then
                Me.tEstado = eEstado.Modificado
            End If
        End Set
    End Property
    Public Property Serie() As String
        Get
            Return IIf(IsDBNull(Me.Tabla.Campos("Serie").Valor), "", Me.Tabla.Campos("Serie").Valor)
        End Get
        Set(ByVal Value As String)
            Me.Tabla.Campos("Serie").Valor = Value
            If Me.Status = eEstado.Recuperado Then
                Me.tEstado = eEstado.Modificado
            End If
        End Set
    End Property
    Public Property Aprobacion() As Integer
        Get
            Return Me.Tabla.Campos("Aprobacion").Valor
        End Get
        Set(ByVal Value As Integer)
            Me.Tabla.Campos("Aprobacion").Valor = Value
            If Me.Status = eEstado.Recuperado Then
                Me.tEstado = eEstado.Modificado
            End If
        End Set
    End Property
    Public Property AnioAprobacion() As Integer
        Get
            Return Me.Tabla.Campos("AnioAprobacion").Valor
        End Get
        Set(ByVal Value As Integer)
            Me.Tabla.Campos("AnioAprobacion").Valor = Value
            If Me.Status = eEstado.Recuperado Then
                Me.tEstado = eEstado.Modificado
            End If
        End Set
    End Property
    Public Property RazonSocial() As String
        Get
            Return IIf(IsDBNull(Me.Tabla.Campos("RazonSocial").Valor), "", Me.Tabla.Campos("RazonSocial").Valor)
        End Get
        Set(ByVal Value As String)
            Me.Tabla.Campos("RazonSocial").Valor = Value
            If Me.Status = eEstado.Recuperado Then
                Me.tEstado = eEstado.Modificado
            End If
        End Set
    End Property
    Public Property RFC() As String
        Get
            Return IIf(IsDBNull(Me.Tabla.Campos("RFC").Valor), "", Me.Tabla.Campos("RFC").Valor)
        End Get
        Set(ByVal Value As String)
            Me.Tabla.Campos("RFC").Valor = Value
            If Me.Status = eEstado.Recuperado Then
                Me.tEstado = eEstado.Modificado
            End If
        End Set
    End Property
    Public Property TelefonoContacto() As String
        Get
            Return IIf(IsDBNull(Me.Tabla.Campos("TelefonoContacto").Valor), "", Me.Tabla.Campos("TelefonoContacto").Valor)
        End Get
        Set(ByVal Value As String)
            Me.Tabla.Campos("TelefonoContacto").Valor = Value
            If Me.Status = eEstado.Recuperado Then
                Me.tEstado = eEstado.Modificado
            End If
        End Set
    End Property
    Public Property Calle() As String
        Get
            Return IIf(IsDBNull(Me.Tabla.Campos("Calle").Valor), "", Me.Tabla.Campos("Calle").Valor)
        End Get
        Set(ByVal Value As String)
            Me.Tabla.Campos("Calle").Valor = Value
            If Me.Status = eEstado.Recuperado Then
                Me.tEstado = eEstado.Modificado
            End If
        End Set
    End Property
    Public Property NumExt() As String
        Get
            Return IIf(IsDBNull(Me.Tabla.Campos("NumExt").Valor), "", Me.Tabla.Campos("NumExt").Valor)
        End Get
        Set(ByVal Value As String)
            Me.Tabla.Campos("NumExt").Valor = Value
            If Me.Status = eEstado.Recuperado Then
                Me.tEstado = eEstado.Modificado
            End If
        End Set
    End Property
    Public Property NumInt() As String
        Get
            Return IIf(IsDBNull(Me.Tabla.Campos("NumInt").Valor), "", Me.Tabla.Campos("NumInt").Valor)
        End Get
        Set(ByVal Value As String)
            Me.Tabla.Campos("NumInt").Valor = Value
            If Me.Status = eEstado.Recuperado Then
                Me.tEstado = eEstado.Modificado
            End If
        End Set
    End Property
    Public Property Colonia() As String
        Get
            Return IIf(IsDBNull(Me.Tabla.Campos("Colonia").Valor), "", Me.Tabla.Campos("Colonia").Valor)
        End Get
        Set(ByVal Value As String)
            Me.Tabla.Campos("Colonia").Valor = Value
            If Me.Status = eEstado.Recuperado Then
                Me.tEstado = eEstado.Modificado
            End If
        End Set
    End Property
    Public Property CodigoPostal() As String
        Get
            Return Me.Tabla.Campos("CodigoPostal").Valor
        End Get
        Set(ByVal Value As String)
            Me.Tabla.Campos("CodigoPostal").Valor = Value
            If Me.Status = eEstado.Recuperado Then
                Me.tEstado = eEstado.Modificado
            End If
        End Set
    End Property
    Public Property ReferenciaDom() As String
        Get
            Return IIf(IsDBNull(Me.Tabla.Campos("ReferenciaDom").Valor), "", Me.Tabla.Campos("ReferenciaDom").Valor)
        End Get
        Set(ByVal Value As String)
            Me.Tabla.Campos("ReferenciaDom").Valor = Value
            If Me.Status = eEstado.Recuperado Then
                Me.tEstado = eEstado.Modificado
            End If
        End Set
    End Property
    Public Property Localidad() As String
        Get
            Return IIf(IsDBNull(Me.Tabla.Campos("Localidad").Valor), "", Me.Tabla.Campos("Localidad").Valor)
        End Get
        Set(ByVal Value As String)
            Me.Tabla.Campos("Localidad").Valor = Value
            If Me.Status = eEstado.Recuperado Then
                Me.tEstado = eEstado.Modificado
            End If
        End Set
    End Property
    Public Property Municipio() As String
        Get
            Return IIf(IsDBNull(Me.Tabla.Campos("Municipio").Valor), "", Me.Tabla.Campos("Municipio").Valor)
        End Get
        Set(ByVal Value As String)
            Me.Tabla.Campos("Municipio").Valor = Value
            If Me.Status = eEstado.Recuperado Then
                Me.tEstado = eEstado.Modificado
            End If
        End Set
    End Property
    Public Property Entidad() As String
        Get
            Return IIf(IsDBNull(Me.Tabla.Campos("Entidad").Valor), "", Me.Tabla.Campos("Entidad").Valor)
        End Get
        Set(ByVal Value As String)
            Me.Tabla.Campos("Entidad").Valor = Value
            If Me.Status = eEstado.Recuperado Then
                Me.tEstado = eEstado.Modificado
            End If
        End Set
    End Property
    Public Property Pais() As String
        Get
            Return IIf(IsDBNull(Me.Tabla.Campos("Pais").Valor), "", Me.Tabla.Campos("Pais").Valor)
        End Get
        Set(ByVal Value As String)
            Me.Tabla.Campos("Pais").Valor = Value
            If Me.Status = eEstado.Recuperado Then
                Me.tEstado = eEstado.Modificado
            End If
        End Set
    End Property
    Public Property CadenaOriginal() As String
        Get
            Return Me.Tabla.Campos("CadenaOriginal").Valor
        End Get
        Set(ByVal Value As String)
            Me.Tabla.Campos("CadenaOriginal").Valor = Value
            If Me.Status = eEstado.Recuperado Then
                Me.tEstado = eEstado.Modificado
            End If
        End Set
    End Property
    Public Property SelloDigital() As String
        Get
            Return Me.Tabla.Campos("SelloDigital").Valor
        End Get
        Set(ByVal Value As String)
            Me.Tabla.Campos("SelloDigital").Valor = Value
            If Me.Status = eEstado.Recuperado Then
                Me.tEstado = eEstado.Modificado
            End If
        End Set
    End Property
    Public Property TelefonoEm() As String
        Get
            Return IIf(IsDBNull(Me.Tabla.Campos("TelefonoEm").Valor), "", Me.Tabla.Campos("TelefonoEm").Valor)
        End Get
        Set(ByVal Value As String)
            Me.Tabla.Campos("TelefonoEm").Valor = Value
            If Me.Status = eEstado.Recuperado Then
                Me.tEstado = eEstado.Modificado
            End If
        End Set
    End Property
    Public Property RFCEm() As String
        Get
            Return Me.Tabla.Campos("RFCEm").Valor
        End Get
        Set(ByVal Value As String)
            Me.Tabla.Campos("RFCEm").Valor = Value
            If Me.Status = eEstado.Recuperado Then
                Me.tEstado = eEstado.Modificado
            End If
        End Set
    End Property
    Public Property NombreEm() As String
        Get
            Return IIf(IsDBNull(Me.Tabla.Campos("NombreEm").Valor), "", Me.Tabla.Campos("NombreEm").Valor)
        End Get
        Set(ByVal Value As String)
            Me.Tabla.Campos("NombreEm").Valor = Value
            If Me.Status = eEstado.Recuperado Then
                Me.tEstado = eEstado.Modificado
            End If
        End Set
    End Property
    Public Property CalleEm() As String
        Get
            Return IIf(IsDBNull(Me.Tabla.Campos("CalleEm").Valor), "", Me.Tabla.Campos("CalleEm").Valor)
        End Get
        Set(ByVal Value As String)
            Me.Tabla.Campos("CalleEm").Valor = Value
            If Me.Status = eEstado.Recuperado Then
                Me.tEstado = eEstado.Modificado
            End If
        End Set
    End Property
    Public Property NumExtEm() As String
        Get
            Return IIf(IsDBNull(Me.Tabla.Campos("NumExtEm").Valor), "", Me.Tabla.Campos("NumExtEm").Valor)
        End Get
        Set(ByVal Value As String)
            Me.Tabla.Campos("NumExtEm").Valor = Value
            If Me.Status = eEstado.Recuperado Then
                Me.tEstado = eEstado.Modificado
            End If
        End Set
    End Property
    Public Property NumIntEm() As String
        Get
            Return IIf(IsDBNull(Me.Tabla.Campos("NumIntEm").Valor), "", Me.Tabla.Campos("NumIntEm").Valor)
        End Get
        Set(ByVal Value As String)
            Me.Tabla.Campos("NumIntEm").Valor = Value
            If Me.Status = eEstado.Recuperado Then
                Me.tEstado = eEstado.Modificado
            End If
        End Set
    End Property
    Public Property ColoniaEm() As String
        Get
            Return IIf(IsDBNull(Me.Tabla.Campos("ColoniaEm").Valor), "", Me.Tabla.Campos("ColoniaEm").Valor)
        End Get
        Set(ByVal Value As String)
            Me.Tabla.Campos("ColoniaEm").Valor = Value
            If Me.Status = eEstado.Recuperado Then
                Me.tEstado = eEstado.Modificado
            End If
        End Set
    End Property
    Public Property LocalidadEm() As String
        Get
            Return IIf(IsDBNull(Me.Tabla.Campos("LocalidadEm").Valor), "", Me.Tabla.Campos("LocalidadEm").Valor)
        End Get
        Set(ByVal Value As String)
            Me.Tabla.Campos("LocalidadEm").Valor = Value
            If Me.Status = eEstado.Recuperado Then
                Me.tEstado = eEstado.Modificado
            End If
        End Set
    End Property
    Public Property ReferenciaDomEm() As String
        Get
            Return IIf(IsDBNull(Me.Tabla.Campos("ReferenciaDomEm").Valor), "", Me.Tabla.Campos("ReferenciaDomEm").Valor)
        End Get
        Set(ByVal Value As String)
            Me.Tabla.Campos("ReferenciaDomEm").Valor = Value
            If Me.Status = eEstado.Recuperado Then
                Me.tEstado = eEstado.Modificado
            End If
        End Set
    End Property
    Public Property MunicipioEm() As String
        Get
            Return IIf(IsDBNull(Me.Tabla.Campos("MunicipioEm").Valor), "", Me.Tabla.Campos("MunicipioEm").Valor)
        End Get
        Set(ByVal Value As String)
            Me.Tabla.Campos("MunicipioEm").Valor = Value
            If Me.Status = eEstado.Recuperado Then
                Me.tEstado = eEstado.Modificado
            End If
        End Set
    End Property
    Public Property RegionEm() As String
        Get
            Return IIf(IsDBNull(Me.Tabla.Campos("RegionEm").Valor), "", Me.Tabla.Campos("RegionEm").Valor)
        End Get
        Set(ByVal Value As String)
            Me.Tabla.Campos("RegionEm").Valor = Value
            If Me.Status = eEstado.Recuperado Then
                Me.tEstado = eEstado.Modificado
            End If
        End Set
    End Property
    Public Property PaisEm() As String
        Get
            Return IIf(IsDBNull(Me.Tabla.Campos("PaisEm").Valor), "", Me.Tabla.Campos("PaisEm").Valor)
        End Get
        Set(ByVal Value As String)
            Me.Tabla.Campos("PaisEm").Valor = Value
            If Me.Status = eEstado.Recuperado Then
                Me.tEstado = eEstado.Modificado
            End If
        End Set
    End Property
    Public Property CodigoPostalEm() As String
        Get
            Return IIf(IsDBNull(Me.Tabla.Campos("CodigoPostalEm").Valor), "", Me.Tabla.Campos("CodigoPostalEm").Valor)
        End Get
        Set(ByVal Value As String)
            Me.Tabla.Campos("CodigoPostalEm").Valor = Value
            If Me.Status = eEstado.Recuperado Then
                Me.tEstado = eEstado.Modificado
            End If
        End Set
    End Property
    Public Property CalleEx() As String
        Get
            Return IIf(IsDBNull(Me.Tabla.Campos("CalleEx").Valor), "", Me.Tabla.Campos("CalleEx").Valor)
        End Get
        Set(ByVal Value As String)
            Me.Tabla.Campos("CalleEx").Valor = Value
            If Me.Status = eEstado.Recuperado Then
                Me.tEstado = eEstado.Modificado
            End If
        End Set
    End Property
    Public Property NumExtEx() As String
        Get
            Return IIf(IsDBNull(Me.Tabla.Campos("NumExtEx").Valor), "", Me.Tabla.Campos("NumExtEx").Valor)
        End Get
        Set(ByVal Value As String)
            Me.Tabla.Campos("NumExtEx").Valor = Value
            If Me.Status = eEstado.Recuperado Then
                Me.tEstado = eEstado.Modificado
            End If
        End Set
    End Property
    Public Property NumIntEx() As String
        Get
            Return IIf(IsDBNull(Me.Tabla.Campos("NumIntEx").Valor), "", Me.Tabla.Campos("NumIntEx").Valor)
        End Get
        Set(ByVal Value As String)
            Me.Tabla.Campos("NumIntEx").Valor = Value
            If Me.Status = eEstado.Recuperado Then
                Me.tEstado = eEstado.Modificado
            End If
        End Set
    End Property
    Public Property ColoniaEx() As String
        Get
            Return IIf(IsDBNull(Me.Tabla.Campos("ColoniaEx").Valor), "", Me.Tabla.Campos("ColoniaEx").Valor)
        End Get
        Set(ByVal Value As String)
            Me.Tabla.Campos("ColoniaEx").Valor = Value
            If Me.Status = eEstado.Recuperado Then
                Me.tEstado = eEstado.Modificado
            End If
        End Set
    End Property
    Public Property CodigoPostalEx() As String
        Get
            Return IIf(IsDBNull(Me.Tabla.Campos("CodigoPostalEx").Valor), "", Me.Tabla.Campos("CodigoPostalEx").Valor)
        End Get
        Set(ByVal Value As String)
            Me.Tabla.Campos("CodigoPostalEx").Valor = Value
            If Me.Status = eEstado.Recuperado Then
                Me.tEstado = eEstado.Modificado
            End If
        End Set
    End Property
    Public Property ReferenciaDomEx() As String
        Get
            Return IIf(IsDBNull(Me.Tabla.Campos("ReferenciaDomEx").Valor), "", Me.Tabla.Campos("ReferenciaDomEx").Valor)
        End Get
        Set(ByVal Value As String)
            Me.Tabla.Campos("ReferenciaDomEx").Valor = Value
            If Me.Status = eEstado.Recuperado Then
                Me.tEstado = eEstado.Modificado
            End If
        End Set
    End Property
    Public Property LocalidadEx() As String
        Get
            Return IIf(IsDBNull(Me.Tabla.Campos("LocalidadEx").Valor), "", Me.Tabla.Campos("LocalidadEx").Valor)
        End Get
        Set(ByVal Value As String)
            Me.Tabla.Campos("LocalidadEx").Valor = Value
            If Me.Status = eEstado.Recuperado Then
                Me.tEstado = eEstado.Modificado
            End If
        End Set
    End Property
    Public Property MunicipioEx() As String
        Get
            Return IIf(IsDBNull(Me.Tabla.Campos("MunicipioEx").Valor), "", Me.Tabla.Campos("MunicipioEx").Valor)
        End Get
        Set(ByVal Value As String)
            Me.Tabla.Campos("MunicipioEx").Valor = Value
            If Me.Status = eEstado.Recuperado Then
                Me.tEstado = eEstado.Modificado
            End If
        End Set
    End Property
    Public Property EntidadEx() As String
        Get
            Return IIf(IsDBNull(Me.Tabla.Campos("EntidadEx").Valor), "", Me.Tabla.Campos("EntidadEx").Valor)
        End Get
        Set(ByVal Value As String)
            Me.Tabla.Campos("EntidadEx").Valor = Value
            If Me.Status = eEstado.Recuperado Then
                Me.tEstado = eEstado.Modificado
            End If
        End Set
    End Property
    Public Property PaisEx() As String
        Get
            Return IIf(IsDBNull(Me.Tabla.Campos("PaisEx").Valor), "", Me.Tabla.Campos("PaisEx").Valor)
        End Get
        Set(ByVal Value As String)
            Me.Tabla.Campos("PaisEx").Valor = Value
            If Me.Status = eEstado.Recuperado Then
                Me.tEstado = eEstado.Modificado
            End If
        End Set
    End Property
  
    Public Property TipoNotaCredito() As Integer
        Get
            Return IIf(IsDBNull(Me.Tabla.Campos("TipoNotaCredito").Valor), 0, 1)
        End Get
        Set(ByVal Value As Integer)
            Me.Tabla.Campos("TipoNotaCredito").Valor = Value
            If Me.Status = eEstado.Recuperado Then
                Me.tEstado = eEstado.Modificado
            End If
        End Set
    End Property

    'Public Property EnvioAddenda() As Boolean
    '    Get
    '        If IsDBNull(Me.Tabla.Campos("EnvioAddenda").Valor) Then
    '            Return False
    '        Else
    '            Return Me.Tabla.Campos("EnvioAddenda").Valor
    '        End If
    '    End Get
    '    Set(ByVal Value As Boolean)
    '        Me.Tabla.Campos("EnvioAddenda").Valor = Value
    '        If Me.Status = eEstado.Recuperado Then
    '            Me.tEstado = eEstado.Modificado
    '        End If
    '    End Set
    'End Property

    'Public Property UUID() As String
    '    Get
    '        Return Me.Tabla.Campos("UUID").Valor
    '    End Get
    '    Set(ByVal Value As String)
    '        Me.Tabla.Campos("UUID").Valor = Value
    '        If Me.Status = eEstado.Recuperado Then
    '            Me.tEstado = eEstado.Modificado
    '        End If
    '    End Set
    'End Property
    'Public Property FechaTimbrado() As DateTime
    '    Get
    '        Return Me.Tabla.Campos("FechaTimbrado").Valor
    '    End Get
    '    Set(ByVal Value As DateTime)
    '        Me.Tabla.Campos("FechaTimbrado").Valor = Value
    '        If Me.Status = eEstado.Recuperado Then
    '            Me.tEstado = eEstado.Modificado
    '        End If
    '    End Set
    'End Property
    'Public Property NoCertificadoSAT() As String
    '    Get
    '        Return Me.Tabla.Campos("NoCertificadoSAT").Valor
    '    End Get
    '    Set(ByVal Value As String)
    '        Me.Tabla.Campos("NoCertificadoSAT").Valor = Value
    '        If Me.Status = eEstado.Recuperado Then
    '            Me.tEstado = eEstado.Modificado
    '        End If
    '    End Set
    'End Property
    'Public Property SelloSAT() As String
    '    Get
    '        Return Me.Tabla.Campos("SelloSAT").Valor
    '    End Get
    '    Set(ByVal Value As String)
    '        Me.Tabla.Campos("SelloSAT").Valor = Value
    '        If Me.Status = eEstado.Recuperado Then
    '            Me.tEstado = eEstado.Modificado
    '        End If
    '    End Set
    'End Property
    'Public Property CadenaOriginalTFD() As String
    '    Get
    '        Return Me.Tabla.Campos("CadenaOriginalTFD").Valor
    '    End Get
    '    Set(ByVal Value As String)
    '        Me.Tabla.Campos("CadenaOriginalTFD").Valor = Value
    '        If Me.Status = eEstado.Recuperado Then
    '            Me.tEstado = eEstado.Modificado
    '        End If
    '    End Set
    'End Property
    Public Property TipoVersion() As String
        Get
            Return Me.Tabla.Campos("TipoVersion").Valor
        End Get
        Set(ByVal Value As String)
            Me.Tabla.Campos("TipoVersion").Valor = Value
            If Me.Status = eEstado.Recuperado Then
                Me.tEstado = eEstado.Modificado
            End If
        End Set
    End Property

    'Public Property VersionTFD() As String
    '    Get
    '        Return Me.Tabla.Campos("VersionTFD").Valor
    '    End Get
    '    Set(ByVal Value As String)
    '        Me.Tabla.Campos("VersionTFD").Valor = Value
    '        If Me.Status = eEstado.Recuperado Then
    '            Me.tEstado = eEstado.Modificado
    '        End If
    '    End Set
    'End Property
    Public Property MetodoPago() As String
        Get
            Return IIf(IsDBNull(Me.Tabla.Campos("MetodoPago").Valor), Nothing, Me.Tabla.Campos("MetodoPago").Valor)
        End Get
        Set(ByVal value As String)
            Me.Tabla.Campos("MetodoPago").Valor = IIf(value = String.Empty, System.DBNull.Value, value)
            If Me.Status = eEstado.Recuperado Then
                Me.tEstado = eEstado.Modificado
            End If
        End Set
    End Property

    Public Property LugarExpedicion() As String
        Get
            Return IIf(IsDBNull(Me.Tabla.Campos("LugarExpedicion").Valor), Nothing, Me.Tabla.Campos("LugarExpedicion").Valor)
        End Get
        Set(ByVal value As String)
            Me.Tabla.Campos("LugarExpedicion").Valor = IIf(value = String.Empty, System.DBNull.Value, value)
            If Me.Status = eEstado.Recuperado Then
                Me.tEstado = eEstado.Modificado
            End If
        End Set
    End Property

    Public Property CerBase64() As String
        Get
            Return IIf(IsDBNull(Me.Tabla.Campos("CerBase64").Valor), Nothing, Me.Tabla.Campos("CerBase64").Valor)
        End Get
        Set(ByVal value As String)
            Me.Tabla.Campos("CerBase64").Valor = IIf(value = String.Empty, System.DBNull.Value, value)
            If Me.Status = eEstado.Recuperado Then
                Me.tEstado = eEstado.Modificado
            End If
        End Set
    End Property

    Public Property FormaDePago() As String
        Get
            Return IIf(IsDBNull(Me.Tabla.Campos("FormaDePago").Valor), Nothing, Me.Tabla.Campos("FormaDePago").Valor)
        End Get
        Set(ByVal value As String)
            Me.Tabla.Campos("FormaDePago").Valor = IIf(value = String.Empty, System.DBNull.Value, value)
            If Me.Status = eEstado.Recuperado Then
                Me.tEstado = eEstado.Modificado
            End If
        End Set
    End Property

    Public Property NumCtaPago() As String
        Get
            Return IIf(IsDBNull(Me.Tabla.Campos("NumCtaPago").Valor), Nothing, Me.Tabla.Campos("NumCtaPago").Valor)
        End Get
        Set(ByVal value As String)
            Me.Tabla.Campos("NumCtaPago").Valor = IIf(value = String.Empty, System.DBNull.Value, value)
            If Me.Status = eEstado.Recuperado Then
                Me.tEstado = eEstado.Modificado
            End If
        End Set
    End Property

    Public Property Banco() As String
        Get
            Return IIf(IsDBNull(Me.Tabla.Campos("Banco").Valor), Nothing, Me.Tabla.Campos("Banco").Valor)
        End Get
        Set(ByVal value As String)
            Me.Tabla.Campos("Banco").Valor = IIf(value = String.Empty, System.DBNull.Value, value)
            If Me.Status = eEstado.Recuperado Then
                Me.tEstado = eEstado.Modificado
            End If
        End Set
    End Property

#End Region

#Region "Constructores"

    Public Sub New(ByRef prPadre As cTransProd)
        MyBase.New(prPadre)
    End Sub

#End Region

#Region "Sobreescritos"
    Protected Overrides Sub CrearEstructuraTabla()
        With Me.Tabla
            .AgregarCampo(New LbDatos.cCampo("TransProdID", LbDatos.ETipo.Cadena, "", True, True))
            .AgregarCampo(New LbDatos.cCampo("FolioId", LbDatos.ETipo.Cadena, "", False, True, False, True))
            .AgregarCampo(New LbDatos.cCampo("FOSId", LbDatos.ETipo.Cadena, "", False, True, False, True))
            .AgregarCampo(New LbDatos.cCampo("NumCertificado", LbDatos.ETipo.Cadena, True))
            .AgregarCampo(New LbDatos.cCampo("Serie", LbDatos.ETipo.Cadena, False))
            .AgregarCampo(New LbDatos.cCampo("Aprobacion", LbDatos.ETipo.Numerico, True))
            .AgregarCampo(New LbDatos.cCampo("AnioAprobacion", LbDatos.ETipo.Numerico, True))
            .AgregarCampo(New LbDatos.cCampo("RazonSocial", LbDatos.ETipo.Cadena, True))
            .AgregarCampo(New LbDatos.cCampo("RFC", LbDatos.ETipo.Cadena, False))
            .AgregarCampo(New LbDatos.cCampo("TelefonoContacto", LbDatos.ETipo.Cadena, False))
            .AgregarCampo(New LbDatos.cCampo("Calle", LbDatos.ETipo.Cadena, True))
            .AgregarCampo(New LbDatos.cCampo("NumExt", LbDatos.ETipo.Cadena, False))
            .AgregarCampo(New LbDatos.cCampo("NumInt", LbDatos.ETipo.Cadena, False))
            .AgregarCampo(New LbDatos.cCampo("Colonia", LbDatos.ETipo.Cadena, False))
            .AgregarCampo(New LbDatos.cCampo("CodigoPostal", LbDatos.ETipo.Cadena, False))
            .AgregarCampo(New LbDatos.cCampo("ReferenciaDom", LbDatos.ETipo.Cadena, False))
            .AgregarCampo(New LbDatos.cCampo("Localidad", LbDatos.ETipo.Cadena, False))
            .AgregarCampo(New LbDatos.cCampo("Municipio", LbDatos.ETipo.Cadena, False))
            .AgregarCampo(New LbDatos.cCampo("Entidad", LbDatos.ETipo.Cadena, False))
            .AgregarCampo(New LbDatos.cCampo("Pais", LbDatos.ETipo.Cadena, True))
            .AgregarCampo(New LbDatos.cCampo("CadenaOriginal", LbDatos.ETipo.Cadena, True))
            .AgregarCampo(New LbDatos.cCampo("SelloDigital", LbDatos.ETipo.Cadena, True))
            .AgregarCampo(New LbDatos.cCampo("TelefonoEm", LbDatos.ETipo.Cadena, False))
            .AgregarCampo(New LbDatos.cCampo("RFCEm", LbDatos.ETipo.Cadena, True))
            .AgregarCampo(New LbDatos.cCampo("NombreEm", LbDatos.ETipo.Cadena, True))
            .AgregarCampo(New LbDatos.cCampo("CalleEm", LbDatos.ETipo.Cadena, True))
            .AgregarCampo(New LbDatos.cCampo("NumExtEm", LbDatos.ETipo.Cadena, False))
            .AgregarCampo(New LbDatos.cCampo("NumIntEm", LbDatos.ETipo.Cadena, False))
            .AgregarCampo(New LbDatos.cCampo("ColoniaEm", LbDatos.ETipo.Cadena, False))
            .AgregarCampo(New LbDatos.cCampo("LocalidadEm", LbDatos.ETipo.Cadena, False))
            .AgregarCampo(New LbDatos.cCampo("ReferenciaDomEm", LbDatos.ETipo.Cadena, False))
            .AgregarCampo(New LbDatos.cCampo("MunicipioEm", LbDatos.ETipo.Cadena, False))
            .AgregarCampo(New LbDatos.cCampo("RegionEm", LbDatos.ETipo.Cadena, False))
            .AgregarCampo(New LbDatos.cCampo("PaisEm", LbDatos.ETipo.Cadena, True))
            .AgregarCampo(New LbDatos.cCampo("CodigoPostalEm", LbDatos.ETipo.Cadena, False))
            .AgregarCampo(New LbDatos.cCampo("CalleEx", LbDatos.ETipo.Cadena, True))
            .AgregarCampo(New LbDatos.cCampo("NumExtEx", LbDatos.ETipo.Cadena, False))
            .AgregarCampo(New LbDatos.cCampo("NumIntEx", LbDatos.ETipo.Cadena, False))
            .AgregarCampo(New LbDatos.cCampo("ColoniaEx", LbDatos.ETipo.Cadena, False))
            .AgregarCampo(New LbDatos.cCampo("CodigoPostalEx", LbDatos.ETipo.Cadena, False))
            .AgregarCampo(New LbDatos.cCampo("ReferenciaDomEx", LbDatos.ETipo.Cadena, False))
            .AgregarCampo(New LbDatos.cCampo("LocalidadEx", LbDatos.ETipo.Cadena, False))
            .AgregarCampo(New LbDatos.cCampo("MunicipioEx", LbDatos.ETipo.Cadena, False))
            .AgregarCampo(New LbDatos.cCampo("EntidadEx", LbDatos.ETipo.Cadena, False))
            .AgregarCampo(New LbDatos.cCampo("PaisEx", LbDatos.ETipo.Cadena, True))
            .AgregarCampo(New LbDatos.cCampo("TipoVersion", LbDatos.ETipo.Cadena, True))
            .AgregarCampo(New LbDatos.cCampo("TipoNotaCredito", LbDatos.ETipo.Numerico, False))

            '.AgregarCampo(New LbDatos.cCampo("VersionTFD", LbDatos.ETipo.Cadena, False))
            '.AgregarCampo(New LbDatos.cCampo("UUID", LbDatos.ETipo.Cadena, False))
            '.AgregarCampo(New LbDatos.cCampo("FechaTimbrado", LbDatos.ETipo.FechaHora, False))
            '.AgregarCampo(New LbDatos.cCampo("NoCertificadoSAT", LbDatos.ETipo.Cadena, False))
            '.AgregarCampo(New LbDatos.cCampo("SelloSAT", LbDatos.ETipo.Cadena, False))
            '.AgregarCampo(New LbDatos.cCampo("CadenaOriginalTFD", LbDatos.ETipo.Cadena, False))
            '.AgregarCampo(New LbDatos.cCampo("EnvioAddenda", LbDatos.ETipo.Bit, False))
            .AgregarCampo(New LbDatos.cCampo("MetodoPago", LbDatos.ETipo.Cadena, "", False, False, False))
            .AgregarCampo(New LbDatos.cCampo("LugarExpedicion", LbDatos.ETipo.Cadena, "", False, False, False))
            .AgregarCampo(New LbDatos.cCampo("CerBase64", LbDatos.ETipo.Cadena, "", False, False, False))
            .AgregarCampo(New LbDatos.cCampo("FormaDePago", LbDatos.ETipo.Cadena, "", False, True, False))
            .AgregarCampo(New LbDatos.cCampo("NumCtaPago", LbDatos.ETipo.Cadena, "", False, False, False))
            .AgregarCampo(New LbDatos.cCampo("Banco", LbDatos.ETipo.Cadena, "", False, False, False))

            '          VersionTFD varchar(5) NULL,
            'UUID varchar(36) NULL,
            'FechaTimbrado datetime NULL,
            'NoCertificadoSAT varchar(20) NULL,
            'SelloSAT text NULL,
            'CadenaOriginalTFD text NULL,

        End With
    End Sub

    Protected Overrides Sub CrearHijos()

    End Sub

    Protected Overrides Function RegresaEnsamblado() As System.Reflection.Assembly
        Return System.Reflection.Assembly.GetExecutingAssembly()
    End Function

    Protected Overrides Function RegresaMnemonico() As String
        Return "TDF"
    End Function

    Protected Overrides Function RegresaNombreTabla() As String
        Return "TRPDatoFiscal"
    End Function
#End Region

#Region "Sobrecargados Especificos"

    Public Overloads Sub Recuperar(ByVal pvTransProdID As String)
        Me.Limpiar()
        Me.Tabla.Campos("TransProdID").Valor = pvTransProdID
        Me.Recuperar()
    End Sub

    Public Overloads Function Existe(ByVal pvTransProdID As String) As Boolean
        Return (Me.Tabla.Seleccionar("TransProdID='" & pvTransProdID & "'").Rows.Count > 0)
    End Function

#End Region

End Class


