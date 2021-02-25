/* Reporte Dinamico Ventas Y Cobranza */

/* Caso de ejemplo de ejecucion del SP
EXEC [dbo].[stpr_VentasCobranza_54]
	@filtroCedis = ''
	@filtroVendedores = '',
	@filtroFechaInicio = '2020-01-01',
	@filtroFechaFin = '2020-06-30'
*/

SET NOCOUNT ON
IF EXISTS (SELECT TOP 1 [object_id] FROM [sys].[objects] WHERE [object_id] = OBJECT_ID(N'[dbo].[stpr_VentasCobranza_54]'))
	DROP PROCEDURE [dbo].[stpr_VentasCobranza_54]
SET NOCOUNT OFF
/*go*/go
 
CREATE PROCEDURE [dbo].[stpr_VentasCobranza_54]
	@filtroCedis AS VARCHAR(MAX) = NULL,
	@filtroVendedores AS VARCHAR(MAX) = NULL,
	@filtroFechaInicio AS VARCHAR(10) = NULL,
	@filtroFechaFin AS VARCHAR(10) = NULL
AS
SET NOCOUNT ON
	Select distinct
	Doc, TipoDoc, Fecha, Dia, VendedorID, Vendedor, FolioV, FVenta, FolioC, FCobranza, FechaCobranza, PrecioVenta, HoraI, Hora, HoraF, HoraSalida, Clave, IdCliente, Nombre, Telefono, Latitud, Longitud, Calle, Numero, Colonia, ProductoClave, NombreLargo, Cantidad, Unidad, FPago, CVenta
	into #Temp_Consulta
	from
	(
	--Ventas
	Select 
	'Pedido' as TipoDoc, 
	'A' as Doc,
	Folio as FVenta, 
	Folio as FolioV, 
	cast(TD.Total as varchar(30)) as PrecioVenta,
	'' as FCobranza,
	'' as FolioC,
	Ven.Nombre as Vendedor,
	Ven.VendedorID as VendedorID,
	T.DiaClave as Dia, 
	D.FechaCaptura as Fecha,
	convert(varchar(10), V.FechaHoraInicial, 108) as Hora,
	convert(varchar(10), V.FechaHoraInicial, 108) as HoraI, 
	convert(varchar(10), V.FechaHoraFinal, 108) as HoraSalida,
	convert(varchar(10), V.FechaHoraFinal, 108) as HoraF,
	C.ClienteClave as IdCliente,
	C.ClienteClave as Clave,
	C.RazonSocial as Nombre,
	C.TelefonoContacto as Telefono,
	cast(CoordenadaX as varchar(30)) as Latitud,
	cast(CoordenadaY as varchar(30)) as Longitud,
	CD.Calle,
	CD.Numero,
	CD.Colonia,
	TD.ProductoClave,
	P.NombreLargo,
	TD.Cantidad,
	(Select Descripcion from VAVDescripcion where VADTipoLenguaje = 'EM' and VARCodigo = 'UNIDADV' and VAVClave = TD.TipoUnidad) as Unidad,
	(Select Descripcion from VAVDescripcion where VADTipoLenguaje = 'EM' and VARCodigo = 'PAGO' and VAVClave = T.ClientePagoID) as FPago,
	(Select Descripcion from VAVDescripcion where VADTipoLenguaje = 'EM' and VARCodigo = 'FVENTA' and VAVClave = T.CFVTipo) as CVenta,
	'' as FechaCobranza
	FROM Visita V
	INNER JOIN Dia d on V.DiaClave = d.DiaClave and CONVERT(date, D.FechaCaptura, 112) BETWEEN @filtroFechaInicio AND @filtroFechaFin
	INNER JOIN Transprod T on V.VisitaClave = T.VisitaClave and V.DiaClave = T.DiaClave
	INNER JOIN TransprodDetalle TD on T.TransProdID = TD.TransProdID
	INNER JOIN Producto P on TD.ProductoClave = P.ProductoClave
	INNER JOIN Vendedor Ven on V.VendedorID = Ven.VendedorID AND V.VendedorID IN (SELECT Datos FROM FNSplit(@filtroVendedores, ','))
	INNER JOIN Cliente C on V.ClienteClave = C.ClienteClave
	INNER JOIN ClienteDomicilio CD on C.ClienteClave = CD.ClienteClave and CD.Tipo = 2
	WHERE T.Tipo = 1 and T.TipoFase = 2

	Union all

	--Cobranza
	Select 
	'Cobranza' as TipoDoc, 
	'B' as Doc, 
	T.Folio as FVenta, 
	T.Folio as FolioV, 
	'' as PrecioVenta,
	A.Folio as FCobranza, 
	A.Folio as FolioC,
	Ven.Nombre as Vendedor,
	Ven.VendedorID as VendedorID,
	T.DiaClave as Dia, 
	D.FechaCaptura as Fecha,
	convert(varchar(10), V.FechaHoraInicial, 108) as Hora,
	convert(varchar(10), V.FechaHoraInicial, 108) as HoraI, 
	convert(varchar(10), V.FechaHoraFinal, 108) as HoraSalida,
	convert(varchar(10), V.FechaHoraFinal, 108) as HoraF,
	C.ClienteClave as IdCliente,
	C.ClienteClave as Clave,
	C.RazonSocial as Nombre,
	C.TelefonoContacto as Telefono,
	str(isnull(str(CD.CoordenadaX),'')) as Latitud,
	str(isnull(str(CD.CoordenadaY),'')) as Longitud,
	CD.Calle,
	CD.Numero,
	CD.Colonia,
	'' as ProductoClave,
	'' as NombreLargo,
	'' as Cantidad,
	'' as Unidad,
	(Select Descripcion from VAVDescripcion where VADTipoLenguaje = 'EM' and VARCodigo = 'PAGO' and VAVClave = T.ClientePagoID) as FPago,
	(Select Descripcion from VAVDescripcion where VADTipoLenguaje = 'EM' and VARCodigo = 'FVENTA' and VAVClave = T.CFVTipo) as CVenta,
	convert(varchar, T.FechaCobranza, 103) as FechaCobranza
	FROM Abono a 
	INNER JOIN Visita v ON a.VisitaClave = v.VisitaClave 
	INNER JOIN Dia d on V.DiaClave = d.DiaClave and CONVERT(date, D.FechaCaptura, 112) BETWEEN @filtroFechaInicio AND @filtroFechaFin
	INNER JOIN Vendedor Ven on V.VendedorID = Ven.VendedorID AND V.VendedorID IN (SELECT Datos FROM FNSplit(@filtroVendedores, ','))
	INNER JOIN Cliente c ON v.ClienteClave = c.ClienteClave
	INNER JOIN ClienteDomicilio CD on C.ClienteClave = CD.ClienteClave and CD.Tipo = 2
	INNER JOIN AbnTrp at ON at.ABNId=a.ABNId 
	INNER JOIN Transprod t ON at.TransprodID= T.TransprodID  and T.CFVTipo = 2
	) Consulta

	SELECT CASE 
			 WHEN ROW_NUMBER() OVER
				  (PARTITION BY Doc, Fecha, VendedorID, FolioV ORDER BY Doc Asc, Fecha ASC, VendedorID ASC, FolioV ASC) = 1 
			   THEN TipoDoc
			 ELSE ''
		   END [Tipo Documento],
		   CASE 
			 WHEN ROW_NUMBER() OVER
				  (PARTITION BY Doc, Fecha, VendedorID, FolioV ORDER BY Doc Asc, Fecha ASC, VendedorID ASC, FolioV ASC) = 1 
			   THEN Dia
			 ELSE ''
		   END Fecha,
		   CASE 
			 WHEN ROW_NUMBER() OVER
				  (PARTITION BY Doc, Fecha, VendedorID, FolioV ORDER BY Doc Asc, Fecha ASC, VendedorID ASC, FolioV ASC) = 1 
			   THEN Vendedor
			 ELSE ''
		   END Vendedor,
		   CASE 
			 WHEN ROW_NUMBER() OVER
				  (PARTITION BY Doc, Fecha, VendedorID, FolioV ORDER BY Doc Asc, Fecha ASC, VendedorID ASC, FolioV ASC) = 1 
			   THEN FVenta
			 ELSE ''
		   END [Folio de Venta],
		   CASE 
			 WHEN ROW_NUMBER() OVER
				  (PARTITION BY Doc, Fecha, VendedorID, FolioV, FolioC ORDER BY Doc Asc, Fecha ASC, VendedorID ASC, FolioV ASC, FolioC ASC) = 1 
			   THEN FCobranza
			 ELSE ''
		   END [Folio de Cobranza],
		   CASE 
			 WHEN ROW_NUMBER() OVER
				  (PARTITION BY Doc, Fecha, VendedorID, FolioV, FolioC ORDER BY Doc Asc, Fecha ASC, VendedorID ASC, FolioV ASC, FolioC ASC) = 1 
			   THEN FechaCobranza
			 ELSE ''
		   END [Vencimiento],
		   CASE 
			 WHEN ROW_NUMBER() OVER
				  (PARTITION BY Doc, Fecha, VendedorID, FolioV, FolioC ORDER BY Doc Asc, Fecha ASC, VendedorID ASC, FolioV ASC, FolioC ASC) = 1 
			   THEN FPago
			 ELSE ''
		   END [Forma de Pago],
		   CASE 
			 WHEN ROW_NUMBER() OVER
				  (PARTITION BY Doc, Fecha, VendedorID, FolioV, FolioC ORDER BY Doc Asc, Fecha ASC, VendedorID ASC, FolioV ASC, FolioC ASC) = 1 
			   THEN CVenta
			 ELSE ''
		   END [Condiciones de Venta],
		   CASE 
			 WHEN ROW_NUMBER() OVER
				  (PARTITION BY Doc, Fecha, VendedorID, FolioV, FolioC, HoraI ORDER BY Doc Asc, Fecha ASC, VendedorID ASC, FolioV ASC, FolioC ASC, HoraI Asc) = 1 
			   THEN Hora
			 ELSE ''
		   END Hora,
		   CASE 
			 WHEN ROW_NUMBER() OVER
				  (PARTITION BY Doc, Fecha, VendedorID, FolioV, FolioC, HoraI, HoraF ORDER BY Doc Asc, Fecha ASC, VendedorID ASC, FolioV ASC, FolioC ASC, HoraI Asc, HoraF Asc) = 1 
			   THEN HoraSalida
			 ELSE ''
		   END [Hora de Salida],
		   CASE 
			 WHEN ROW_NUMBER() OVER
				  (PARTITION BY Doc, Fecha, VendedorID, FolioV, FolioC, HoraI, HoraF, Clave ORDER BY Doc Asc, Fecha ASC, VendedorID ASC, FolioV ASC, FolioC ASC, HoraI Asc, HoraF Asc, Clave ASC) = 1 
			   THEN IdCliente
			 ELSE ''
		   END [Id Cliente],
		   CASE 
			 WHEN ROW_NUMBER() OVER
				  (PARTITION BY Doc, Fecha, VendedorID, FolioV, FolioC, HoraI, HoraF, Clave ORDER BY Doc Asc, Fecha ASC, VendedorID ASC, FolioV ASC, FolioC ASC, HoraI Asc, HoraF Asc, Clave ASC) = 1 
			   THEN Nombre
			 ELSE ''
		   END Nombre,
		   CASE 
			 WHEN ROW_NUMBER() OVER
				  (PARTITION BY Doc, Fecha, VendedorID, FolioV, FolioC, HoraI, HoraF, Clave ORDER BY Doc Asc, Fecha ASC, VendedorID ASC, FolioV ASC, FolioC ASC, HoraI Asc, HoraF Asc, Clave ASC) = 1 
			   THEN Telefono
			 ELSE ''
		   END Telefono,
		   CASE 
			 WHEN ROW_NUMBER() OVER
				  (PARTITION BY Doc, Fecha, VendedorID, FolioV, FolioC, HoraI, HoraF, Clave ORDER BY Doc Asc, Fecha ASC, VendedorID ASC, FolioV ASC, FolioC ASC, HoraI Asc, HoraF Asc, Clave ASC) = 1 
			   THEN Latitud
			 ELSE ''
		   END Latitud,
		   CASE 
			 WHEN ROW_NUMBER() OVER
				  (PARTITION BY Doc, Fecha, VendedorID, FolioV, FolioC, HoraI, HoraF, Clave ORDER BY Doc Asc, Fecha ASC, VendedorID ASC, FolioV ASC, FolioC ASC, HoraI Asc, HoraF Asc, Clave ASC) = 1 
			   THEN Longitud
			 ELSE ''
		   END Longitud,
		   CASE 
			 WHEN ROW_NUMBER() OVER
				  (PARTITION BY Doc, Fecha, VendedorID, FolioV, FolioC, HoraI, HoraF, Clave ORDER BY Doc Asc, Fecha ASC, VendedorID ASC, FolioV ASC, FolioC ASC, HoraI Asc, HoraF Asc, Clave ASC) = 1 
			   THEN Calle
			 ELSE ''
		   END Calle,
		   CASE 
			 WHEN ROW_NUMBER() OVER
				  (PARTITION BY Doc, Fecha, VendedorID, FolioV, FolioC, HoraI, HoraF, Clave ORDER BY Doc Asc, Fecha ASC, VendedorID ASC, FolioV ASC, FolioC ASC, HoraI Asc, HoraF Asc, Clave ASC) = 1 
			   THEN Numero
			 ELSE ''
		   END Numero,
		   CASE 
			 WHEN ROW_NUMBER() OVER
				  (PARTITION BY Doc, Fecha, VendedorID, FolioV, FolioC, HoraI, HoraF, Clave ORDER BY Doc Asc, Fecha ASC, VendedorID ASC, FolioV ASC, FolioC ASC, HoraI Asc, HoraF Asc, Clave ASC) = 1 
			   THEN Colonia
			 ELSE ''
		   END Colonia, ProductoClave, NombreLargo, Cantidad, PrecioVenta, Unidad
	from #Temp_Consulta
	order by Doc asc
	drop table #Temp_Consulta
SET NOCOUNT OFF
/*go*/go