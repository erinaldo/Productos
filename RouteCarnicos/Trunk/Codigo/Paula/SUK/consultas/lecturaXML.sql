--select * from tmp_DatosFacturacion
--Select FacturaID from TransProd
--Select * from TransProd where Folio = 'AAA-83517'
--ALTER TABLE tmp_DatosFacturacion DISABLE TRIGGER [tg_transfer_DatosFacturacion] 
Declare @LineNumer int            
Declare @ErrDesc varchar(8000)            
Declare @Err int
--'<?xml version="1.0" encoding="UTF-8"?><Comprobante version="2.0" serie="AAA" folio="83846" noAprobacion="1959108" anoAprobacion="2011" fecha="2012-05-09T03:40:00" formaDePago="Pago en una sola exhibicion" noCertificado="00001000000101985011" certificado="MIIECTCCAvGgAwIBAgIUMDAwMDEwMDAwMDAxMDE5ODUwMTEwDQYJKoZIhvcNAQEFBQAwggE2MTgwNgYDVQQDDC9BLkMuIGRlbCBTZXJ2aWNpbyBkZSBBZG1pbmlzdHJhY2nDs24gVHJpYnV0YXJpYTEvMC0GA1UECgwmU2VydmljaW8gZGUgQWRtaW5pc3RyYWNpw7NuIFRyaWJ1dGFyaWExHzAdBgkqhkiG9w0BCQEWEGFjb2RzQHNhdC5nb2IubXgxJjAkBgNVBAkMHUF2LiBIaWRhbGdvIDc3LCBDb2wuIEd1ZXJyZXJvMQ4wDAYDVQQRDAUwNjMwMDELMAkGA1UEBhMCTVgxGTAXBgNVBAgMEERpc3RyaXRvIEZlZGVyYWwxEzARBgNVBAcMCkN1YXVodGVtb2MxMzAxBgkqhkiG9w0BCQIMJFJlc3BvbnNhYmxlOiBGZXJuYW5kbyBNYXJ0w61uZXogQ29zczAeFw0xMDA5MDgxNzUyNThaFw0xMjA5MDcxNzUyNThaMIGpMRkwFwYDVQQDExBTVUtBUk5FIFNBIERFIENWMRkwFwYDVQQpExBTVUtBUk5FIFNBIERFIENWMRkwFwYDVQQKExBTVUtBUk5FIFNBIERFIENWMSUwIwYDVQQtExxTVUs5MzEyMTZOMzggLyBIRU1SNjIwNjEwUTkxMR4wHAYDVQQFExUgLyBIRU1SNjIwNjEwTVNMUlJDMDUxDzANBgNVBAsTBk1BVFJJWjCBnzANBgkqhkiG9w0BAQEFAAOBjQAwgYkCgYEAnL3JCiM+RLZ+VdAVooFtqN38lZsoeEvgtoLMaqHBiYtfJl2W2avVoyGU3qmZxKh2rDhHTkG1m1k/L7HwbQwt3g/SfEoXJzd0EuoxxKcaEnUVYqTmgqAJegss7vST8bZ7KMQcSSDmRGD0SwKI8m4f6U1WJVQtmG1l93qAiMBhMcsCAwEAAaMdMBswDAYDVR0TAQH/BAIwADALBgNVHQ8EBAMCBsAwDQYJKoZIhvcNAQEFBQADggEBABqREcEqEev1BKDNEWQ1kQM9cojwLTolKZEEbmqiXOZFG9ltH2Sog7+aYDF3Z6TdsiOUr0lEwd1boir4SFyUn8Bna4uJ8k2vpMOTm+rBttQYTJSd5fxD0q46NXePm0j1qFle7e588QrJlRbAQHIJJQXGSxdv76VtR4tfw0CKG6wc/F+Ka3vYTCPRLvGPvdl0qR3/m2WIzsya9ao/0KcKmRfNlNQbIEborPuQmXfFWWJHIxFR+ZExytGXGZp1bIDouUEOxzjEt0wk1MAynPfa9gBr6aIkwE4tIz3R34WLCKZZfMCH0qJhpG5THp6PfD13pYLNd26RYlmkxRdXe/WkM04=" tipoDeComprobante="ingreso" subTotal="411.36" descuento="0.00" total="411.36" sello="SXIyGXpzbYCG52gFgj/tv3LPaWo8B5ZsgxwYcqklEhbn1sEzcNgxxSNdNcptnu0EfYsj4BlSe/78DLIwCc5R5TAgQSKOiQmmFaJAFLb+Uh3ODocVFca2+w/3HoKb3CGCZJE5zccwxAV4UDjMx16dCTeHqLm8R4HcLcpEuFby8ZM=" xsi:schemaLocation="http://www.sat.gob.mx/cfd/2 http://www.sat.gob.mx/sitio_internet/cfd/2/cfdv2.xsd http://www.sat.gob.mx/detallista http://www.sat.gob.mx/sitio_internet/cfd/detallista/detallista.xsd" xmlns:detallista="http://www.sat.gob.mx/detallista" xmlns="http://www.sat.gob.mx/cfd/2" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance"><Emisor nombre="SuKarne S.A. de C.V." rfc="SUK931216N38"><DomicilioFiscal calle="Carretera Culiacan-Vitaruto Km 14.5" colonia="Ejido El Pinole" municipio="Culiacan" estado="Sinaloa" pais="México" codigoPostal="80300"/><ExpedidoEn calle="FORTUNATO JIMENEZ" noExterior="5080" colonia="SAN RAFAEL" municipio="CULIACAN" estado="Sinaloa" pais="México" codigoPostal="80150"/></Emisor><Receptor nombre="SOLORIO AVITIA SILVERA" rfc="XXAX010101000"><Domicilio calle="SAN AARON" noExterior="2950" colonia="LOS ANGELES" municipio="CULIACAN" estado="SINALOA" pais="MX" codigoPostal="80014"/></Receptor><Conceptos><Concepto cantidad="17.14" unidad="KGM" descripcion="RECORTE EMBOLSADO SUKARNE" noIdentificacion="8502" valorUnitario="24.00" importe="411.36"/><InformacionAduanera fecha="2012-03-20" aduana="TIJUANA" numero="32892001286"/></Concepto></Conceptos><Impuestos totalImpuestosTrasladados="0.00"><Traslados><Traslado importe="0.00" tasa="0.0" impuesto="IVA"/></Traslados></Impuestos></Comprobante>'
--select * from tmp_DatosFacturacion
/*Select * from tmp_DatosFacturacion

insert into tmp_DatosFactira
Select * from producto where nombre = 'RECORTE EMBOLSADO SUKARNE'
update tmp_DatosFacturacion set CFD ='<?xml version="1.0" encoding="UTF-8"?><Comprobante version="2.0" serie="AAA" folio="83846" noAprobacion="1959108" anoAprobacion="2011" fecha="2012-05-09T03:40:00" formaDePago="Pago en una sola exhibicion" noCertificado="00001000000101985011" certificado="MIIECTCCAvGgAwIBAgIUMDAwMDEwMDAwMDAxMDE5ODUwMTEwDQYJKoZIhvcNAQEFBQAwggE2MTgwNgYDVQQDDC9BLkMuIGRlbCBTZXJ2aWNpbyBkZSBBZG1pbmlzdHJhY2nDs24gVHJpYnV0YXJpYTEvMC0GA1UECgwmU2VydmljaW8gZGUgQWRtaW5pc3RyYWNpw7NuIFRyaWJ1dGFyaWExHzAdBgkqhkiG9w0BCQEWEGFjb2RzQHNhdC5nb2IubXgxJjAkBgNVBAkMHUF2LiBIaWRhbGdvIDc3LCBDb2wuIEd1ZXJyZXJvMQ4wDAYDVQQRDAUwNjMwMDELMAkGA1UEBhMCTVgxGTAXBgNVBAgMEERpc3RyaXRvIEZlZGVyYWwxEzARBgNVBAcMCkN1YXVodGVtb2MxMzAxBgkqhkiG9w0BCQIMJFJlc3BvbnNhYmxlOiBGZXJuYW5kbyBNYXJ0w61uZXogQ29zczAeFw0xMDA5MDgxNzUyNThaFw0xMjA5MDcxNzUyNThaMIGpMRkwFwYDVQQDExBTVUtBUk5FIFNBIERFIENWMRkwFwYDVQQpExBTVUtBUk5FIFNBIERFIENWMRkwFwYDVQQKExBTVUtBUk5FIFNBIERFIENWMSUwIwYDVQQtExxTVUs5MzEyMTZOMzggLyBIRU1SNjIwNjEwUTkxMR4wHAYDVQQFExUgLyBIRU1SNjIwNjEwTVNMUlJDMDUxDzANBgNVBAsTBk1BVFJJWjCBnzANBgkqhkiG9w0BAQEFAAOBjQAwgYkCgYEAnL3JCiM+RLZ+VdAVooFtqN38lZsoeEvgtoLMaqHBiYtfJl2W2avVoyGU3qmZxKh2rDhHTkG1m1k/L7HwbQwt3g/SfEoXJzd0EuoxxKcaEnUVYqTmgqAJegss7vST8bZ7KMQcSSDmRGD0SwKI8m4f6U1WJVQtmG1l93qAiMBhMcsCAwEAAaMdMBswDAYDVR0TAQH/BAIwADALBgNVHQ8EBAMCBsAwDQYJKoZIhvcNAQEFBQADggEBABqREcEqEev1BKDNEWQ1kQM9cojwLTolKZEEbmqiXOZFG9ltH2Sog7+aYDF3Z6TdsiOUr0lEwd1boir4SFyUn8Bna4uJ8k2vpMOTm+rBttQYTJSd5fxD0q46NXePm0j1qFle7e588QrJlRbAQHIJJQXGSxdv76VtR4tfw0CKG6wc/F+Ka3vYTCPRLvGPvdl0qR3/m2WIzsya9ao/0KcKmRfNlNQbIEborPuQmXfFWWJHIxFR+ZExytGXGZp1bIDouUEOxzjEt0wk1MAynPfa9gBr6aIkwE4tIz3R34WLCKZZfMCH0qJhpG5THp6PfD13pYLNd26RYlmkxRdXe/WkM04=" tipoDeComprobante="ingreso" subTotal="411.36" descuento="0.00" total="411.36" sello="SXIyGXpzbYCG52gFgj/tv3LPaWo8B5ZsgxwYcqklEhbn1sEzcNgxxSNdNcptnu0EfYsj4BlSe/78DLIwCc5R5TAgQSKOiQmmFaJAFLb+Uh3ODocVFca2+w/3HoKb3CGCZJE5zccwxAV4UDjMx16dCTeHqLm8R4HcLcpEuFby8ZM=" xsi:schemaLocation="http://www.sat.gob.mx/cfd/2 http://www.sat.gob.mx/sitio_internet/cfd/2/cfdv2.xsd http://www.sat.gob.mx/detallista http://www.sat.gob.mx/sitio_internet/cfd/detallista/detallista.xsd" xmlns:detallista="http://www.sat.gob.mx/detallista" xmlns="http://www.sat.gob.mx/cfd/2" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance"><Emisor nombre="SuKarne S.A. de C.V." rfc="SUK931216N38"><DomicilioFiscal calle="Carretera Culiacan-Vitaruto Km 14.5" colonia="Ejido El Pinole" municipio="Culiacan" estado="Sinaloa" pais="México" codigoPostal="80300"/><ExpedidoEn calle="FORTUNATO JIMENEZ" noExterior="5080" colonia="SAN RAFAEL" municipio="CULIACAN" estado="Sinaloa" pais="México" codigoPostal="80150"/></Emisor><Receptor nombre="SOLORIO AVITIA SILVERA" rfc="XXAX010101000"><Domicilio calle="SAN AARON" noExterior="2950" colonia="LOS ANGELES" municipio="CULIACAN" estado="SINALOA" pais="MX" codigoPostal="80014"/></Receptor><Conceptos><Concepto cantidad="17.14" unidad="KGM" descripcion="RECORTE EMBOLSADO SUKARNE" noIdentificacion="0000004392" valorUnitario="24.00" importe="411.36"><InformacionAduanera fecha="2012-03-20" aduana="TIJUANA" numero="32892001286"/></Concepto></Conceptos><Impuestos totalImpuestosTrasladados="0.00"><Traslados><Traslado importe="0.00" tasa="0.0" impuesto="IVA"/></Traslados></Impuestos></Comprobante>'
where Folio = 83846
*/

DECLARE @FolioDatosFac bigint
set @FolioDatosFac = 83846
/*DECLARE @LogoSubEmpresa image
set @LogoSubEmpresa = (Select top 1 Logotipo from SubEmpresa)
select * from tmp_DatosFacturacion
*/
Declare @TipoLenguaje as Varchar(8)
set @TipoLenguaje = (Select Top 1 TipoLenguaje from Conhist order by CONHistFechaInicio desc)
DECLARE @Sello as nvarchar(max), @CadenaOriginal nvarchar(max)

DECLARE @CFD as nvarchar(max), @FolioXML bigint, @Serie varchar(10), @FolioVentaFac varchar(16)

Select @CFD = convert(nvarchar(max),CFD), @FolioXML = Folio, @Serie = Serie, @Sello = convert(nvarchar(max), Sello), @CadenaOriginal= convert(nvarchar(max), CadenaOriginal)  
from tmp_DatosFacturacion where Folio = @FolioDatosFac

set @FolioVentaFac = @Serie + '-' + ltrim(str(@FolioXML))

DECLARE @TransProdId varchar(16), @VisitaClave varchar(16), @DiaClave varchar(16), @SubEmpresaId varchar(16), 
@CFVTipo smallint, @SubTotal float, @Impuesto float, @Total float, @Saldo float, @FacturaID varchar(16)

Select @TransProdId = TransProdID , @VisitaClave = VisitaClave, @DiaClave = DiaClave , @SubEmpresaId = SubEmpresaID,
@CFVTipo = CFVTipo, @SubTotal = Subtotal, @Impuesto = Impuesto, @Total = Total, @Saldo = Saldo, @FacturaID = FacturaID
from TransProd where Folio = @FolioVentaFac

set @Err = 0
set @LineNumer=1

IF @Err=0
BEGIN
	if (@TransProdId is null or @TransProdId = '')
	BEGIN
		set @ErrDesc = dbo.FNObtenerMensaje('E0872',@TipoLenguaje)
		RAISERROR (@ErrDesc,16, 1)
		set @Err=@@ERROR   
	END
END

IF @Err=0
BEGIN
	if (NOT @FacturaID is null )
	BEGIN
		set @ErrDesc = dbo.FNObtenerMensaje('I0230', @TipoLenguaje)
		RAISERROR (@ErrDesc,16, 1)
		set @Err=@@ERROR   
	END
END

set @CFD = (Select SUBSTRING(@CFD, charindex( '<Comprobante',@CFD,0),charindex( '</Comprobante>',@CFD,0) ))

declare @idoc int
exec sp_xml_preparedocument @idoc OUTPUT, @CFD

SELECT * into #Comprobante
FROM   OPENXML (@idoc, '/',1)

DECLARE @FechaXML datetime , @NumCertificado varchar(20), 
@NoAprobacion int, @AnioAprobacion int, @RecNombre varchar(128), @RecRFC varchar(64), @RecCalle varchar(64),
@RecNumExt varchar(16),@RecNumInt varchar(16), @RecColonia varchar(64), @RecCodigoPostal varchar(16), @RecReferenciaDom varchar(100),
@RecLocalidad varchar(40), @RecMunicipio varchar(64), @RecEntidad varchar(32), @RecPais varchar(32), @RFCEm varchar(64) ,
@NombreEm varchar(64), @CalleEm varchar(64), @NumExtEm varchar(16), @NumIntEm varchar(16), @ColoniaEm varchar(64),
@LocalidadEm varchar(40), @ReferenciaDomEm varchar(100), @MunicipioEm varchar(40), @RegionEm varchar(40), @PaisEm varchar(40),
@CodigoPostalEm varchar(16), @CalleEx varchar(64), @NumExtEx varchar(16), @NumIntEx varchar(16), @ColoniaEx varchar(64), @CodigoPostalEx varchar(16),
@ReferenciaDomEx varchar(16), @LocalidadEx varchar(40), @MunicipioEx varchar(40), @EntidadEx varchar(40), @PaisEx varchar(40), @TipoVersion varchar(8),
@Certificado nvarchar(max), @LugarExpedicion varchar(400)

Declare @id int
set @id = (Select id from #Comprobante where localname = 'version' and parentid = 0)
set @TipoVersion = (Select convert( varchar(100),text) from #Comprobante where parentid = @id)
IF @Err=0
BEGIN
	if (@TipoVersion is null or @TipoVersion = '')
	BEGIN
		set @ErrDesc = replace(dbo.FNObtenerMensaje('BE0001',@TipoLenguaje), '$0$','version')
		RAISERROR (@ErrDesc,16, 1)
		set @Err=@@ERROR   
	END
END

set @id =  (Select id from #Comprobante where localname = 'fecha'and parentid = 0)
set @FechaXML = (Select Convert(datetime, convert( varchar(50),text)) from #Comprobante where parentid = @id)
IF @Err=0
BEGIN
	if (@FechaXML is null )
	BEGIN
		set @ErrDesc = replace(dbo.FNObtenerMensaje('BE0001',@TipoLenguaje), '$0$','fecha')
		RAISERROR (@ErrDesc,16, 1)
		set @Err=@@ERROR   
	END
END
set @id = (Select id from #Comprobante where localname = 'noCertificado' and parentid = 0)
set @NumCertificado  = (Select convert( varchar(100),text) from #Comprobante where parentid = @id)
IF @Err=0
BEGIN
	if (@NumCertificado is null )
	BEGIN
		set @ErrDesc = replace(dbo.FNObtenerMensaje('BE0001',@TipoLenguaje), '$0$','noCertificado')
		RAISERROR (@ErrDesc,16, 1)
		set @Err=@@ERROR   
	END
END
set @id = (Select id from #Comprobante where localname ='noAprobacion' and parentid = 0)
set @NoAprobacion = (Select CONVERT(Int, Convert( varchar(100),text)) from #Comprobante where parentid = @id)      
IF @Err=0
BEGIN
	if (@NoAprobacion is null )
	BEGIN
		set @ErrDesc = replace(dbo.FNObtenerMensaje('BE0001',@TipoLenguaje), '$0$','noAprobacion')
		RAISERROR (@ErrDesc,16, 1)
		set @Err=@@ERROR   
	END
END
set @id = (Select id from #Comprobante where localname ='anoAprobacion' and parentid = 0)
set @AnioAprobacion = (Select CONVERT(Int, Convert( varchar(100),text)) from #Comprobante where parentid = @id)
IF @Err=0
BEGIN
	if (@AnioAprobacion is null )
	BEGIN
		set @ErrDesc = replace(dbo.FNObtenerMensaje('BE0001',@TipoLenguaje), '$0$','anoAprobacion')
		RAISERROR (@ErrDesc,16, 1)
		set @Err=@@ERROR   
	END
END
set @id = (Select id from #Comprobante where localname ='certificado' and parentid = 0)
set @Certificado = (Select convert(varchar(max),text) from #Comprobante where parentid = @id)

IF (@TipoVersion = '2.2')
BEGIN
	set @id = (Select id from #Comprobante where localname ='LugarExpedicion')
	set @LugarExpedicion = (Select convert(varchar(400),text) from #Comprobante where parentid = @id)
	IF @Err=0
	BEGIN
		if (@LugarExpedicion is null )
		BEGIN
			set @ErrDesc = replace(dbo.FNObtenerMensaje('BE0001',@TipoLenguaje), '$0$','LugarExpedicion')
			RAISERROR (@ErrDesc,16, 1)
			set @Err=@@ERROR   
		END
	END
END
DECLARE @MetodoPago nvarchar(300)
IF (@TipoVersion = '2.2')
BEGIN
	set @id = (Select id from #Comprobante where localname = 'metodoDePago')
	set @MetodoPago = (Select convert( nvarchar(300),text) from #Comprobante where parentid = @id)
	IF @Err=0
	BEGIN
		if (@MetodoPago is null )
		BEGIN
			set @ErrDesc = replace(dbo.FNObtenerMensaje('BE0001',@TipoLenguaje), '$0$','metodoDePago')
			RAISERROR (@ErrDesc,16, 1)
			set @Err=@@ERROR   
		END
	END
END
/**************************RECEPTOR**********************************************/
DECLARE @idReceptor int
set @idReceptor = (Select id from #Comprobante where localname ='receptor')
IF @Err=0
BEGIN
	if (@idReceptor is null )
	BEGIN
		set @ErrDesc = replace(dbo.FNObtenerMensaje('BE0001',@TipoLenguaje), '$0$','receptor')
		RAISERROR (@ErrDesc,16, 1)
		set @Err=@@ERROR   
	END
END      
set @id = (Select id from #Comprobante where localname ='nombre' and parentid = @idReceptor )
set @RecNombre  = (Select convert( varchar(100),text) from #Comprobante where parentid = @id)
set @id = (Select id from #Comprobante where localname ='rfc' and parentid = @idReceptor )
set @RecRFC  = (Select convert( varchar(100),text) from #Comprobante where parentid = @id)
IF @Err=0
	BEGIN
		if (@RecRFC is null )
		BEGIN
			set @ErrDesc = replace(dbo.FNObtenerMensaje('BE0001',@TipoLenguaje), '$0$','rfc')
			RAISERROR (@ErrDesc,16, 1)
			set @Err=@@ERROR   
		END
	END
DECLARE @IdRECDomicilio int
set @IdRECDomicilio = (Select id from #Comprobante where localname ='domicilio' and parentid = @idReceptor )

if (Not @IdRECDomicilio is null )
BEGIN
	set @id = (Select id from #Comprobante where localname ='calle' and parentid = @IdRECDomicilio )
	set @RecCalle = (Select convert( varchar(100),text) from #Comprobante where parentid = @id)
	set @id = (Select id from #Comprobante where localname ='noExterior' and parentid = @IdRECDomicilio )
	set @RecNumExt  = (Select convert( varchar(100),text) from #Comprobante where parentid = @id)
	set @id = (Select id from #Comprobante where localname ='noInterior' and parentid = @IdRECDomicilio )
	set @RecNumInt = (Select convert( varchar(100),text) from #Comprobante where parentid = @id)
	set @id = (Select id from #Comprobante where localname ='colonia' and parentid = @IdRECDomicilio )
	set @RecColonia = (Select convert( varchar(100),text) from #Comprobante where parentid = @id)
	set @id = (Select id from #Comprobante where localname ='codigoPostal' and parentid = @IdRECDomicilio )
	set @RecCodigoPostal = (Select convert( varchar(100),text) from #Comprobante where parentid = @id)
	set @id = (Select id from #Comprobante where localname ='referencia' and parentid = @IdRECDomicilio )
	set @RecReferenciaDom = (Select convert( varchar(100),text) from #Comprobante where parentid = @id)
	set @id = (Select id from #Comprobante where localname ='localidad' and parentid = @IdRECDomicilio )
	set @RecLocalidad = (Select convert( varchar(100),text) from #Comprobante where parentid = @id)
	set @id = (Select id from #Comprobante where localname ='municipio' and parentid = @IdRECDomicilio )
	set @RecMunicipio = (Select convert( varchar(100),text) from #Comprobante where parentid = @id)
	set @id = (Select id from #Comprobante where localname ='estado' and parentid = @IdRECDomicilio )
	set @RecEntidad = (Select convert( varchar(100),text) from #Comprobante where parentid = @id)
	set @id = (Select id from #Comprobante where localname ='pais' and parentid = @IdRECDomicilio )
	set @RecPais = (Select convert( varchar(100),text) from #Comprobante where parentid = @id)
	IF @Err=0
	BEGIN
		if (@RecPais is null )
		BEGIN
			set @ErrDesc = replace(dbo.FNObtenerMensaje('BE0001',@TipoLenguaje), '$0$','pais')
			RAISERROR (@ErrDesc,16, 1)
			set @Err=@@ERROR   
		END
	END
END
/*************************************EMISOR*****************************************************/
DECLARE @IdEmisor int
set @idEmisor = (Select id from #Comprobante where localname ='emisor')   
IF @Err=0
BEGIN
	if (@IdEmisor is null )
	BEGIN
		set @ErrDesc = replace(dbo.FNObtenerMensaje('BE0001',@TipoLenguaje), '$0$','emisor')
		RAISERROR (@ErrDesc,16, 1)
		set @Err=@@ERROR   
	END
END
set @id = (Select id from #Comprobante where localname ='nombre' and parentid = @IdEmisor) 
set @NombreEm = (Select convert( varchar(100),text) from #Comprobante where parentid = @id)
IF (@TipoVersion = '2.0')
BEGIN
	IF @Err=0
	BEGIN
		if (@NombreEm is null )
		BEGIN
			set @ErrDesc = replace(dbo.FNObtenerMensaje('BE0001',@TipoLenguaje), '$0$','nombre')
			RAISERROR (@ErrDesc,16, 1)
			set @Err=@@ERROR   
		END
	END
END
set @id = (Select id from #Comprobante where localname ='rfc' and parentid = @IdEmisor) 
set @RFCEm = (Select convert( varchar(100),text) from #Comprobante where parentid = @id)
IF @Err=0
BEGIN
	if (@RFCEm is null )
	BEGIN
		set @ErrDesc = replace(dbo.FNObtenerMensaje('BE0001',@TipoLenguaje), '$0$','rfc')
		RAISERROR (@ErrDesc,16, 1)
		set @Err=@@ERROR   
	END
END
DECLARE @idDomicilioFiscal int
set @idDomicilioFiscal = (Select id from #Comprobante where localname ='domicilioFiscal' and parentid = @IdEmisor )
IF (@TipoVersion = '2.0')
BEGIN
	IF @Err=0
	BEGIN
		if (@idDomicilioFiscal is null )
		BEGIN
			set @ErrDesc = replace(dbo.FNObtenerMensaje('BE0001',@TipoLenguaje), '$0$','domicilioFiscal')
			RAISERROR (@ErrDesc,16, 1)
			set @Err=@@ERROR   
		END
	END
END
if (not @idDomicilioFiscal is null)
BEGIN
	set @id = (Select id from #Comprobante where localname ='calle' and parentid = @idDomicilioFiscal) 
	set @CalleEm = (Select convert( varchar(100),text) from #Comprobante where parentid = @id)
	IF @Err=0
	BEGIN
		if (@CalleEm is null )
		BEGIN
			set @ErrDesc = replace(dbo.FNObtenerMensaje('BE0001',@TipoLenguaje), '$0$','calle')
			RAISERROR (@ErrDesc,16, 1)
			set @Err=@@ERROR   
		END
	END
	set @id = (Select id from #Comprobante where localname ='noExterior' and parentid = @idDomicilioFiscal) 
	set @NumExtEm= (Select convert( varchar(100),text) from #Comprobante where parentid = @id)
	set @id = (Select id from #Comprobante where localname ='noInterior' and parentid = @idDomicilioFiscal) 
	set @NumIntEm= (Select convert( varchar(100),text) from #Comprobante where parentid = @id)
	set @id = (Select id from #Comprobante where localname ='colonia' and parentid = @idDomicilioFiscal) 
	set @ColoniaEm= (Select convert( varchar(100),text) from #Comprobante where parentid = @id)
	set @id = (Select id from #Comprobante where localname ='localidad' and parentid = @idDomicilioFiscal) 
	set @LocalidadEm= (Select convert( varchar(100),text) from #Comprobante where parentid = @id)
	set @id = (Select id from #Comprobante where localname ='referencia' and parentid = @idDomicilioFiscal) 
	set @ReferenciaDomEm= (Select convert( varchar(100),text) from #Comprobante where parentid = @id)
	set @id = (Select id from #Comprobante where localname ='municipio' and parentid = @idDomicilioFiscal) 
	set @MunicipioEm= (Select convert( varchar(100),text) from #Comprobante where parentid = @id)
	IF @Err=0
	BEGIN
		if (@MunicipioEm is null )
		BEGIN
			set @ErrDesc = replace(dbo.FNObtenerMensaje('BE0001',@TipoLenguaje), '$0$','municipio')
			RAISERROR (@ErrDesc,16, 1)
			set @Err=@@ERROR   
		END
	END
	set @id = (Select id from #Comprobante where localname ='estado' and parentid = @idDomicilioFiscal) 
	set @RegionEm= (Select convert( varchar(100),text) from #Comprobante where parentid = @id)
	IF @Err=0
	BEGIN
		if (@RegionEm is null )
		BEGIN
			set @ErrDesc = replace(dbo.FNObtenerMensaje('BE0001',@TipoLenguaje), '$0$','estado')
			RAISERROR (@ErrDesc,16, 1)
			set @Err=@@ERROR   
		END
	END
	set @id = (Select id from #Comprobante where localname ='pais' and parentid = @idDomicilioFiscal) 
	set @PaisEm= (Select convert( varchar(100),text) from #Comprobante where parentid = @id)
	IF @Err=0
	BEGIN
		if (@PaisEm is null )
		BEGIN
			set @ErrDesc = replace(dbo.FNObtenerMensaje('BE0001',@TipoLenguaje), '$0$','pais')
			RAISERROR (@ErrDesc,16, 1)
			set @Err=@@ERROR   
		END
	END
	set @id = (Select id from #Comprobante where localname ='codigoPostal' and parentid = @idDomicilioFiscal) 
	set @CodigoPostalEm= (Select convert( varchar(100),text) from #Comprobante where parentid = @id)
	IF @Err=0
	BEGIN
		if (@CodigoPostalEm is null )
		BEGIN
			set @ErrDesc = replace(dbo.FNObtenerMensaje('BE0001',@TipoLenguaje), '$0$','codigoPostal')
			RAISERROR (@ErrDesc,16, 1)
			set @Err=@@ERROR   
		END
	END
END

DECLARE @IdExpedidoEn int
set @idExpedidoEn = (Select id from #Comprobante where localname ='expedidoEn' and parentid = @IdEmisor )
IF (not @idExpedidoEn is null)
BEGIN   
	set @id = (Select id from #Comprobante where localname ='calle' and parentid = @IdExpedidoEn ) 
	set @CalleEx = (Select convert( varchar(100),text) from #Comprobante where parentid = @id)
	set @id = (Select id from #Comprobante where localname ='noExterior' and parentid = @IdExpedidoEn ) 
	set @NumExtEx= (Select convert( varchar(100),text) from #Comprobante where parentid = @id)
	set @id = (Select id from #Comprobante where localname ='noInterior' and parentid = @IdExpedidoEn ) 
	set @NumIntEx= (Select convert( varchar(100),text) from #Comprobante where parentid = @id)
	set @id = (Select id from #Comprobante where localname ='colonia' and parentid = @IdExpedidoEn ) 
	set @ColoniaEx= (Select convert( varchar(100),text) from #Comprobante where parentid = @id)
	set @id = (Select id from #Comprobante where localname ='codigoPostal' and parentid = @IdExpedidoEn ) 
	set @CodigoPostalEx= (Select convert( varchar(100),text) from #Comprobante where parentid = @id)
	set @id = (Select id from #Comprobante where localname ='referencia' and parentid = @IdExpedidoEn ) 
	set @ReferenciaDomEx= (Select convert( varchar(100),text) from #Comprobante where parentid = @id)
	set @id = (Select id from #Comprobante where localname ='localidad' and parentid = @IdExpedidoEn ) 
	set @LocalidadEx= (Select convert( varchar(100),text) from #Comprobante where parentid = @id)
	set @id = (Select id from #Comprobante where localname ='municipio' and parentid = @IdExpedidoEn ) 
	set @MunicipioEx= (Select convert( varchar(100),text) from #Comprobante where parentid = @id)
	set @id = (Select id from #Comprobante where localname ='estado' and parentid = @IdExpedidoEn ) 
	set @EntidadEx= (Select convert( varchar(100),text) from #Comprobante where parentid = @id)
	set @id = (Select id from #Comprobante where localname ='pais' and parentid = @IdExpedidoEn ) 
	set @PaisEx= (Select convert( varchar(100),text) from #Comprobante where parentid = @id)
	IF @Err=0
	BEGIN
		if (@PaisEx is null )
		BEGIN
			set @ErrDesc = replace(dbo.FNObtenerMensaje('BE0001',@TipoLenguaje), '$0$','pais')
			RAISERROR (@ErrDesc,16, 1)
			set @Err=@@ERROR   
		END
	END
END


DECLARE @TransProdIdFactura varchar(16)
set @TransProdIdFactura = (Select cast(replace(cast(NEWID() as varchar(36)),'-','') as varchar(16)))

/***********************************REGIMEN FISCAL******************************************/
IF (@TipoVersion = '2.2')
BEGIN
	Select @TransProdIdFactura as TransProdId, (Select cast(replace(cast(NEWID() as varchar(36)),'-','') as varchar(16))) as RegimenID,
	text,getdate() as MFechaHora, 'Interfaz' as MUsuarioID into #RegimenFiscal from #Comprobante where parentid in(Select id from #Comprobante where localname = 'Regimen')
END


if @Err = 0
BEGIN
	Select TXTNUM.text as numPedimento , TXTPROD.text as ProductoClave, INFOADUA.id as IdAduana into #Pedimentos
	from #Comprobante TXTNUM 
	inner join #Comprobante NUM on TXTNUM.parentid = NUM.id
	inner join #Comprobante INFOADUA on INFOADUA.id = NUM.parentId
	inner join #Comprobante CONC on CONC.id = INFOADUA.parentId
	inner join #Comprobante NOIDE on CONC.id  = NOIDE.parentid and NOIDE.localname = 'noIdentificacion'
	inner join #Comprobante TXTPROD on TXTPROD.parentid = NOIDE.id
	where NUM.localname = 'numero' and INFOADUA.localname = 'InformacionAduanera' and CONC.localname = 'Concepto'

	Insert into TransProd (TransProdID, VisitaClave, DiaClave, SubEmpresaID, CFVTipo, Folio, Tipo, TipoPedido, TipoFase, TipoMovimiento, FechaHoraAlta, FechaCaptura, FechaEntrega, FechaFacturacion, FechaSurtido, FechaCancelacion, TipoMotivo, SubTDetalle, DescVendPor, DescuentoVendedor, DescuentoImp, Subtotal, Impuesto, Total, Saldo, Promocion, Descuento, MonedaId, TipoCambio, TipoTurno,FechaCobranza, DiasCredito, Notas, MFechaHora,MUsuarioID  )
	VALUES(@TransProdIdFactura, @VisitaClave, @DiaClave, @SubEmpresaId, @CFVTipo, @Serie + ltrim(str(@FolioXML)), 8,0,1,0, @FechaXML, convert(datetime,Convert(varchar(20),@FechaXML ,112)),'1900-01-01T00:00:00.000', '1900-01-01T00:00:00.000', '1900-01-01T00:00:00.000', '1900-01-01T00:00:00.000', 0,0,0,0,0, @SubTotal, @Impuesto, @Total,@Saldo ,0,0,null,null,0,'1900-01-01T00:00:00.000',0,'',GETDATE(), 'Interfaz' )

	Insert into TRPDatoFiscal(TransProdID, FolioId, FOSId, NumCertificado, Serie, Aprobacion, AnioAprobacion, RazonSocial, RFC, 
	TelefonoContacto, Calle, NumExt, NumInt, Colonia, CodigoPostal, ReferenciaDom, Localidad, Municipio, Entidad, Pais, CadenaOriginal 
	,SelloDigital, LogotipoEm, TelefonoEm, RFCEm, NombreEm, CalleEm, NumExtEm,NumIntEm, ColoniaEm, LocalidadEm, ReferenciaDomEm, 
	MunicipioEm, RegionEm, PaisEm, CodigoPostalEm, CalleEx ,NumExtEx, NumIntEx, ColoniaEx, CodigoPostalEx, ReferenciaDomEx, 
	LocalidadEx, MunicipioEx, EntidadEx, PaisEx,TipoVersion, TipoNotaCredito, MetodoPago,CerBase64, LugarExpedicion, MFechaHora, MUsuarioID  )
	VALUES(@TransProdIdFactura, null, null, @NumCertificado, @Serie, @NoAprobacion, @AnioAprobacion, @RecNombre, @RecRFC,
	null,@RecCalle, @RecNumExt , @RecNumInt, @RecColonia,@RecCodigoPostal, @RecReferenciaDom, @RecLocalidad, @RecMunicipio, @RecEntidad, @RecPais, @CadenaOriginal,
	@Sello, null, '',@RFCEm, @NombreEm, @CalleEm,@NumExtEm, @NumIntEm, @ColoniaEm, @LocalidadEm, @ReferenciaDomEm,
	@MunicipioEm, @RegionEm, @PaisEm, @CodigoPostalEm,@CalleEx,@NumExtEx, @NumIntEx, @ColoniaEx, @CodigoPostalEx, @ReferenciaDomEx,
	@LocalidadEx, @MunicipioEx, @EntidadEx, @PaisEx, @TipoVersion, 0,@MetodoPago, @Certificado, @LugarExpedicion, GETDATE(), 'Interfaz')
	
	IF (@TipoVersion = '2.2')
	BEGIN
		Insert into TRPRegimenFiscal
		Select * from #RegimenFiscal
	END
	
	DECLARE @NumPedimento varchar(30), @ProductoClave varchar(10), @idAduana int
	DECLARE @CursorPed Cursor
	SET @CursorPed = CURSOR SCROLL DYNAMIC FOR
	Select NumPedimento,ProductoClave, idAduana from #Pedimentos
	
	OPEN @CursorPed
	FETCH NEXT FROM @CursorPed INTO @NumPedimento, @ProductoClave, @idAduana

	WHILE @@FETCH_STATUS = 0
	BEGIN
		IF (Select count(*) from TRPPedimento where NumPedimento = @NumPedimento and ProductoClave = @ProductoClave)>0
		BEGIN
			Update TRPPedimento set Facturado = 1 where NumPedimento = @NumPedimento and ProductoClave = @ProductoClave
		END
		ELSE
		BEGIN
			DECLARE @Aduana varchar(40), @FechaIngreso datetime
			Select @Aduana = TXTADUA.text, @FechaIngreso = Cast(Cast(TXTFecha.text as nvarchar(100)) as datetime) 
			from #Comprobante ADUA 
			inner join #Comprobante TXTADUA on ADUA.id = TXTADUA.parentid and ADUA.localname = 'aduana'
			inner join #Comprobante FECHA on  FECHA.parentid = @idAduana and FECHA.localname = 'fecha'
			inner join #Comprobante TXTFECHA on TXTFecha.parentid = FECHA.id
			where ADUA.parentid = @idAduana 
			
			DECLARE @TRPPedimentoID varchar(16)
			set @TRPPedimentoID = (Select cast(replace(cast(NEWID() as varchar(36)),'-','') as varchar(16)))
			Insert into TRPPedimento (TransprodID, TRPPedimentoID, ProductoClave, CodigoSKU, NumPedimento, Aduana, FechaIngreso, Facturado, Cancelado, MFechaHora, MUsuarioID)
			VALUES (@TransProdId,@TRPPedimentoID, @ProductoClave, null, @NumPedimento,@Aduana, @FechaIngreso,1,0,getdate(), 'Interfaz') 
		END
		FETCH NEXT FROM @CursorPed INTO @NumPedimento, @ProductoClave, @idAduana
	END
	
	CLOSE @CursorPed
	DEALLOCATE @CursorPed

	DROP TABLE #Pedimentos
	Update TransProd set FacturaID = @TransProdIdFactura where TransProdID = @TransProdId 
END

DROP TABLE #Comprobante

IF (@TipoVersion = '2.2')
BEGIN
	DROP TABLE #RegimenFiscal
END

IF @Err<>0             
BEGIN        
              
	If @Err=2627           
		set @ErrDesc='Error de restricción, llave primaria duplicada'          
	Else          
		select distinct top 1 @ErrDesc=description from master.dbo.sysmessages where error=@Err            
	INSERT INTO ErrorLog(LineNumber,DTSName,SQLErrNumber,Descripcion,MFechaHora,MUsuarioID)            
		values (@LineNumer,'Datos Facturacion',@Err, @ErrDesc, getDate(),'Admin')            
END




--ROLLBACK TRAN
/*Select Top 3 * from Altena.dbo.TransProd where tipo = 8
Select * from TransProd where tipo = 8

Delete from TransProd where TransProdId = '4C53E4F0ECD54039'
update TransProd set FacturaId = null where TransProdId ='PAU00000AAA83517'

Select * from TransProd where not FacturaId is null
Select * from cliente where clienteclave = '0000002349000001'
Select * from ClienteDomicilio where clienteclave = '0000002349000001'
Select top 3 * from Altena.dbo.TRPDatoFiscal 

select * from subempresa
Select * from TRPDatoFiscal 

Select * from visita where visitaClave='35J6GXHWKO22CXI'

Select * from Cliente where ClienteClave 
*/

/*Select * from tmp_DatosFacturacion 

<?xml version="1.0" encoding="UTF-8"?>  <Comprobante version="2.0" serie="AAA" folio="83517" noAprobacion="1959108" anoAprobacion="2011" fecha="2012-05-04T15:48:00" formaDePago="Pago en una sola exhibicion" noCertificado="00001000000101985011" certificado="MIIECTCCAvGgAwIBAgIUMDAwMDEwMDAwMDAxMDE5ODUwMTEwDQYJKoZIhvcNAQEFBQAwggE2MTgwNgYDVQQDDC9BLkMuIGRlbCBTZXJ2aWNpbyBkZSBBZG1pbmlzdHJhY2nDs24gVHJpYnV0YXJpYTEvMC0GA1UECgwmU2VydmljaW8gZGUgQWRtaW5pc3RyYWNpw7NuIFRyaWJ1dGFyaWExHzAdBgkqhkiG9w0BCQEWEGFjb2RzQHNhdC5nb2IubXgxJjAkBgNVBAkMHUF2LiBIaWRhbGdvIDc3LCBDb2wuIEd1ZXJyZXJvMQ4wDAYDVQQRDAUwNjMwMDELMAkGA1UEBhMCTVgxGTAXBgNVBAgMEERpc3RyaXRvIEZlZGVyYWwxEzARBgNVBAcMCkN1YXVodGVtb2MxMzAxBgkqhkiG9w0BCQIMJFJlc3BvbnNhYmxlOiBGZXJuYW5kbyBNYXJ0w61uZXogQ29zczAeFw0xMDA5MDgxNzUyNThaFw0xMjA5MDcxNzUyNThaMIGpMRkwFwYDVQQDExBTVUtBUk5FIFNBIERFIENWMRkwFwYDVQQpExBTVUtBUk5FIFNBIERFIENWMRkwFwYDVQQKExBTVUtBUk5FIFNBIERFIENWMSUwIwYDVQQtExxTVUs5MzEyMTZOMzggLyBIRU1SNjIwNjEwUTkxMR4wHAYDVQQFExUgLyBIRU1SNjIwNjEwTVNMUlJDMDUxDzANBgNVBAsTBk1BVFJJWjCBnzANBgkqhkiG9w0BAQEFAAOBjQAwgYkCgYEAnL3JCiM+RLZ+VdAVooFtqN38lZsoeEvgtoLMaqHBiYtfJl2W2avVoyGU3qmZxKh2rDhHTkG1m1k/L7HwbQwt3g/SfEoXJzd0EuoxxKcaEnUVYqTmgqAJegss7vST8bZ7KMQcSSDmRGD0SwKI8m4f6U1WJVQtmG1l93qAiMBhMcsCAwEAAaMdMBswDAYDVR0TAQH/BAIwADALBgNVHQ8EBAMCBsAwDQYJKoZIhvcNAQEFBQADggEBABqREcEqEev1BKDNEWQ1kQM9cojwLTolKZEEbmqiXOZFG9ltH2Sog7+aYDF3Z6TdsiOUr0lEwd1boir4SFyUn8Bna4uJ8k2vpMOTm+rBttQYTJSd5fxD0q46NXePm0j1qFle7e588QrJlRbAQHIJJQXGSxdv76VtR4tfw0CKG6wc/F+Ka3vYTCPRLvGPvdl0qR3/m2WIzsya9ao/0KcKmRfNlNQbIEborPuQmXfFWWJHIxFR+ZExytGXGZp1bIDouUEOxzjEt0wk1MAynPfa9gBr6aIkwE4tIz3R34WLCKZZfMCH0qJhpG5THp6PfD13pYLNd26RYlmkxRdXe/WkM04=" tipoDeComprobante="ingreso" subTotal="8742.13" descuento="0.00" total="8742.13" sello="C0P3lxwNXWhnwK5LmncPL6D5Q/Dv03ceOkdIdgPajC6XOt9hupCt1fJM7DoTWhSlfFnducuLB9SpO62f6yzI0if9CRLoZN+PcFsOOTC3n7VDkgY/qk5KNkE36ht6CAgyCY1jTYa1zdGu1tKTxulZF+NARjchWgspgxqda46e1YM=" xsi:schemaLocation="http://www.sat.gob.mx/cfd/2 http://www.sat.gob.mx/sitio_internet/cfd/2/cfdv2.xsd http://www.sat.gob.mx/detallista http://www.sat.gob.mx/sitio_internet/cfd/detallista/detallista.xsd" xmlns:detallista="http://www.sat.gob.mx/detallista" xmlns="http://www.sat.gob.mx/cfd/2" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance"><Emisor nombre="SuKarne S.A. de C.V." rfc="SUK931216N38"><DomicilioFiscal calle="Carretera Culiacan-Vitaruto Km 14.5" colonia="Ejido El Pinole" municipio="Culiacan" estado="Sinaloa" pais="Mexico" codigoPostal="80300"/><ExpedidoEn calle="FORTUNATO JIMENEZ" noExterior="5080" colonia="SAN RAFAEL" municipio="CULIACAN" estado="Sinaloa" pais="Mexico" codigoPostal="80150"/></Emisor><Receptor nombre="RAMIREZ FELIX MA. ANGELES" rfc="RAFM700118Q19"><Domicilio calle="AVE. PATRIA" noExterior="2221" colonia="LAZARO CARDENAS" municipio="CULIACAN" estado="SINALOA" pais="MX" codigoPostal="80290"/></Receptor><Conceptos><Concepto cantidad="130.69" unidad="KGM" descripcion="TOP SIRLOIN SUKARNE" noIdentificacion="700" valorUnitario="62.95" importe="8226.94"/><Concepto cantidad="6.24" unidad="KGM" descripcion="TRIPA DELGADA EMBOLSADA SUKARNE" noIdentificacion="8498" valorUnitario="24.95" importe="155.69"/><Concepto cantidad="18.02" unidad="KGM" descripcion="HIGADO EMBOLSADO SUKARNE" noIdentificacion="8506" valorUnitario="19.95" importe="359.50"/></Conceptos><Impuestos totalImpuestosTrasladados="0.00"><Traslados><Traslado importe="0.00" tasa="0.0" impuesto="IVA"/></Traslados></Impuestos></Comprobante>

Select * from producto


Select CHARINDEX('é','<?xml version="1.0" encoding="UTF-8"?> <Comprobante version="2.0" serie="AAA" folio="83516" noAprobacion="1959108" anoAprobacion="2011" fecha="2012-05-04T15:44:00" formaDePago="Pago en una sola exhibicion" noCertificado="00001000000101985011" certificado="MIIECTCCAvGgAwIBAgIUMDAwMDEwMDAwMDAxMDE5ODUwMTEwDQYJKoZIhvcNAQEFBQAwggE2MTgwNgYDVQQDDC9BLkMuIGRlbCBTZXJ2aWNpbyBkZSBBZG1pbmlzdHJhY2nDs24gVHJpYnV0YXJpYTEvMC0GA1UECgwmU2VydmljaW8gZGUgQWRtaW5pc3RyYWNpw7NuIFRyaWJ1dGFyaWExHzAdBgkqhkiG9w0BCQEWEGFjb2RzQHNhdC5nb2IubXgxJjAkBgNVBAkMHUF2LiBIaWRhbGdvIDc3LCBDb2wuIEd1ZXJyZXJvMQ4wDAYDVQQRDAUwNjMwMDELMAkGA1UEBhMCTVgxGTAXBgNVBAgMEERpc3RyaXRvIEZlZGVyYWwxEzARBgNVBAcMCkN1YXVodGVtb2MxMzAxBgkqhkiG9w0BCQIMJFJlc3BvbnNhYmxlOiBGZXJuYW5kbyBNYXJ0w61uZXogQ29zczAeFw0xMDA5MDgxNzUyNThaFw0xMjA5MDcxNzUyNThaMIGpMRkwFwYDVQQDExBTVUtBUk5FIFNBIERFIENWMRkwFwYDVQQpExBTVUtBUk5FIFNBIERFIENWMRkwFwYDVQQKExBTVUtBUk5FIFNBIERFIENWMSUwIwYDVQQtExxTVUs5MzEyMTZOMzggLyBIRU1SNjIwNjEwUTkxMR4wHAYDVQQFExUgLyBIRU1SNjIwNjEwTVNMUlJDMDUxDzANBgNVBAsTBk1BVFJJWjCBnzANBgkqhkiG9w0BAQEFAAOBjQAwgYkCgYEAnL3JCiM+RLZ+VdAVooFtqN38lZsoeEvgtoLMaqHBiYtfJl2W2avVoyGU3qmZxKh2rDhHTkG1m1k/L7HwbQwt3g/SfEoXJzd0EuoxxKcaEnUVYqTmgqAJegss7vST8bZ7KMQcSSDmRGD0SwKI8m4f6U1WJVQtmG1l93qAiMBhMcsCAwEAAaMdMBswDAYDVR0TAQH/BAIwADALBgNVHQ8EBAMCBsAwDQYJKoZIhvcNAQEFBQADggEBABqREcEqEev1BKDNEWQ1kQM9cojwLTolKZEEbmqiXOZFG9ltH2Sog7+aYDF3Z6TdsiOUr0lEwd1boir4SFyUn8Bna4uJ8k2vpMOTm+rBttQYTJSd5fxD0q46NXePm0j1qFle7e588QrJlRbAQHIJJQXGSxdv76VtR4tfw0CKG6wc/F+Ka3vYTCPRLvGPvdl0qR3/m2WIzsya9ao/0KcKmRfNlNQbIEborPuQmXfFWWJHIxFR+ZExytGXGZp1bIDouUEOxzjEt0wk1MAynPfa9gBr6aIkwE4tIz3R34WLCKZZfMCH0qJhpG5THp6PfD13pYLNd26RYlmkxRdXe/WkM04=" tipoDeComprobante="ingreso" subTotal="10676.32" descuento="0.00" total="10676.32" sello="AssEGhNtHA3rgDipDxejxMa+8RFBJqB7FU4Dfn7Ytoh1CiG1RfJ643FKlhtbeLNvyFYxYaVW6Ovllmk/hCW2L2oCZFCM+o6KpJ0cuZLgcgE6N33w7CvLVLGvu4lA5EydDChAc5XwhOi56cVa3a0HVgAHA95CaMr4LgqFVqc2kmc=" xsi:schemaLocation="http://www.sat.gob.mx/cfd/2 http://www.sat.gob.mx/sitio_internet/cfd/2/cfdv2.xsd http://www.sat.gob.mx/detallista http://www.sat.gob.mx/sitio_internet/cfd/detallista/detallista.xsd" xmlns:detallista="http://www.sat.gob.mx/detallista" xmlns="http://www.sat.gob.mx/cfd/2" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance"><Emisor nombre="SuKarne S.A. de C.V." rfc="SUK931216N38"><DomicilioFiscal calle="Carretera Culiacan-Vitaruto Km 14.5" colonia="Ejido El Pinole" municipio="Culiacan" estado="Sinaloa" pais="México" codigoPostal="80300"/><ExpedidoEn calle="FORTUNATO JIMENEZ" noExterior="5080" colonia="SAN RAFAEL" municipio="CULIACAN" estado="Sinaloa" pais="México" codigoPostal="80150"/></Emisor><Receptor nombre="RAMIREZ FELIX MA. ANGELES" rfc="RAFM700118Q19"><Domicilio calle="AVE. PATRIA" noExterior="2221" colonia="LAZARO CARDENAS" municipio="CULIACAN" estado="SINALOA" pais="MX" codigoPostal="80290"/></Receptor><Conceptos><Concepto cantidad="169.60" unidad="KGM" descripcion="TOP SIRLOIN SUKARNE" noIdentificacion="700" valorUnitario="62.95" importe="10676.32"/></Conceptos><Impuestos totalImpuestosTrasladados="0.00"><Traslados><Traslado importe="0.00" tasa="0.0" impuesto="IVA"/></Traslados></Impuestos></Comprobante>',0)

Select * from trpDatoFiscal where TransProdID in('D5279190980D4C7B')
Select * from transProd where FacturaID in('4EA3295F89BC471C','4EF4A85E0F614D4F','F3EB5F604BA04D9F')

Select * from transProd where tipo = 8 and tipoFase <>0 and Folio like '%83846'
Select * from transprod where Folio like '%83846'
delete from transprod where TransProdID in('B23265A2F1794070')
delete from TRPDatoFiscal where TransProdID in('B23265A2F1794070')
delete from TRPRegimenFiscal where TransProdID in('B23265A2F1794070')

Update TransProd set FacturaID =  null where FacturaID in('B23265A2F1794070')
Select * from TRPPedimento
Select * from TRPRegimenFiscal

*/

--