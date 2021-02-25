Public Class eCFD

    Public RENClave As String
    Public cadenaOriginal As String
    Public sello As String
    'Public extra As String
    'Comprobante

    Public tipoDeComprobante As String

    Public Serie As String
    Public Folio As String

    Public Fecha As Date

    Public TipoCF As Integer

    Public VersionCF As String
    Public VersionNomina As Integer
    Public regimenFiscal As String
    Public noCertificado As String
    Public Certificado64 As String

    Public formaDePago As String
    Public metodoDePago As String
    Public NumCtaPago As String

    Public TipoNomina As String
    Public FechaPago As Date
    Public FechaInicialPago As Date
    Public FechaFinalPago As Date
    Public NumDiasPagados As Integer


    Public LlaveFile As String
    Public ContrasenaClave As String

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
    Public total As String
    Public ISR As Double


    Public TipoCambio As Double
    Public Moneda As String
    'Emisor

    Public RegistroPatronal As String

    Public eRFC As String
    Public eRazonSocial As String
    Public eCURP As String = ""
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

    Public EMPClave As String

    Public NumEmpleado As String
    Public CURP As String
    Public TipoRegimen As String
    Public NumSeguridadSocial As String
    Public Departamento As String
    Public Banco As Integer
    Public CLABE As String
    Public FechaInicioRelLaboral As String
    Public Antiguedad As String
    Public Puesto As String

    Public TipoContrato As String
    Public TipoJornada As String
    Public PeriodicidadPago As String
    Public Sindicalizado As Integer
    Public SalarioBaseCotApor As Double
    Public RiesgoPuesto As Integer
    Public SalarioDiarioIntegrado As Double
    Public ClaveEntFed As String

    Public RFC As String
    Public RazonSocial As String


    Public Pais As String
    Public Entidad As String
    Public Mnpio As String
    Public Calle As String
    Public Colonia As String
    Public noExterior As String
    Public noInterior As String
    Public codigoPostal As String
    Public brnoInterior As Boolean

    'Public Contacto As String
    'Public Tel1 As String
    'Public Tel2 As String
    'Public email As String
    'Public TipoEstado As Integer


    'com

    Public TotalGravadoP As Double
    Public TotalExentoP As Double
    Public TotalDeducciones As Double
    Public TotalOtrosPagos As Double
    Public TotalIncapacidades As Double
    Public TotalHorasExtra As Double
    Public TotalSueldos As Double
    Public TotalSeparacion As Double
    Public TotalJubilacion As Double



End Class
