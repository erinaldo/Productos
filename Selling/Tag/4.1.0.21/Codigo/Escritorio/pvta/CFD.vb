Public Class CFD

    Public AplicaAnticipo As Boolean = False
    Public UUID_Sustituido As String = ""
    Public UsoCFDI As String
    Public tipoNC As Integer

    Public DOCClave As String
    Public cadenaOriginal As String
    Public sello As String
    'Public extra As String
    'Comprobante

    Public tipoDeComprobante As String

    Public FOLClave As String
    Public Serie As String
    Public Folio As String

    Public Fecha As String
    Public FechaPago As String

    Public ClaveRetenc As Integer
    Public Nacionalidad As String
    Public NumRegIdTrib As String

    Public TipoCF As Integer
    Public VersionCF As String
    Public regimenFiscal As String
    Public noCertificado As String
    Public Certificado64 As String

    Public formaDePago As String
    Public metodoDePago As String
    Public NumCtaPago As String
    Public CondicionesDePago As String

    Public LlaveFile As String
    Public ContrasenaClave As String
    Public noAprobacion As String
    Public anoAprobacion As String
    Public fechaAprobacion As Date = #1/1/1900#
    Public CBB As Byte()
    'Public UUID As String
    'Public SelloSAT As String
    'Public CertificadoSAT As String
    'Public fechaTimbrado As Date = #1/1/1900#
    'Public versionSAT As String

    Public subtotal As String
    Public descuento As Double
    Public impuestos As Double
    Public Retenciones As Double

    Public total As Decimal

    Public TipoCambio As Double
    Public Moneda As String
    'Emisor

    Public eRFC As String
    Public eRazonSocial As String
    Public eTPersona As Integer
    Public ePais As String
    Public eEntidad As String
    Public eMnpio As String
    Public eCalle As String
    Public eColonia As String
    Public eLocalidad As String
    Public eReferencia As String
    Public enoExterior As String
    Public enoInterior As String
    Public eCodigoPostal As String
    Public benoInterior As Boolean


    'Sucursal
    Public LugarExpedicion As String
    Public sPais As String
    Public sEntidad As String
    Public sMnpio As String


    Public sCalle As String
    Public sColonia As String
    Public sLocalidad As String
    Public sReferencia As String
    Public snoExterior As String
    Public snoInterior As String
    Public sCodigoPostal As String
    Public iTipoSucursal As Integer
    Public bsnoInterior As Boolean

    'Receptor
    Public CTEClave As String
    Public CURP As String
    Public Clave As String
    Public TImpuesto As Integer
    Public NombreCorto As String
    Public RazonSocial As String
    Public TPersona As Integer
    Public RFC As String
    Public LCredito As Double
    Public DiasCredito As Integer
    Public Contacto As String
    Public Tel1 As String
    Public Tel2 As String
    Public email As String
    Public listaPrecio As String
    Public NoDesglosaIEPS As Boolean = False
    Public ImprimirFac As Boolean = True
    Public Estado As Integer
    Public FechaReg As Date
    Public DCTEClave As String

    Public GLN As String

    Public Pais As String
    Public Entidad As String
    Public Mnpio As String
    Public Calle As String
    Public Colonia As String
    Public Localidad As String
    Public Referencia As String
    Public noExterior As String
    Public noInterior As String
    Public codigoPostal As String
    Public brnoInterior As Boolean

    'Sección de Configuración de Addendas

    Public tieneAddenda As Boolean = False
    Public Tipo As Integer
    Public TipoConexion As Integer
    Public UsuarioFTP As String
    Public PwdFTP As String
    Public FTP As String
    Public Firma As String
    Public emailAdd As String
    Public NoProveedor As String

    Public FechaEntrega As String
    Public NotaEntrada As String
    Public NoCita As String
    Public CantBultos As Integer
    Public CantPedidos As Integer
    Public FACClave As String
    
End Class
