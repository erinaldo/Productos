SET NOCOUNT ON
IF EXISTS (SELECT TOP 1 [object_id] FROM [sys].[objects] WHERE [object_id] = OBJECT_ID(N'[dbo].[stpr_VentasDistribuidor_82]'))
	DROP PROCEDURE [dbo].[stpr_VentasDistribuidor_82]
SET NOCOUNT OFF
/*go*/go
 
CREATE PROCEDURE [dbo].[stpr_VentasDistribuidor_82]
	@filtroRutas AS VARCHAR(MAX) = NULL,
	@filtroVendedores AS VARCHAR(MAX) = NULL,
	@filtroFechaInicio AS VARCHAR(10) = NULL,
	@filtroFechaFin AS VARCHAR(10) = NULL
AS
SET NOCOUNT ON

	DECLARE @TipoLenguaje  varchar(8)

	set @TipoLenguaje = (Select TOP 1 TipoLenguaje from CONHist order by  CONHistFechaInicio desc)

	/*
	DECLARE @filtroCedis AS VARCHAR(MAX) = NULL,
	@filtroVendedores AS VARCHAR(MAX) = NULL,
	@filtroFechaInicio AS VARCHAR(10) = NULL,
	@filtroFechaFin AS VARCHAR(10) = NULL

	set @VendedorId = '3Z5J9B9FXK8+CJ2'
	set @FechaIni = '2020-01-01T00:00:00'
	set @FechaFin = '2020-08-06T00:00:00'
	*/

		IF @filtroRutas = ' ' OR @filtroRutas = '' OR @filtroRutas = 'null'
		SET @filtroRutas = NULL

		IF @filtroVendedores = ' ' OR @filtroVendedores = '' OR @filtroVendedores = 'null'
		SET @filtroVendedores = NULL

	Select  Dia.FechaCaptura , VAD.Descripcion as Distribuidor, VEN.VendedorID + ' - ' + VEN.Nombre as Vendedor, 
	RUT.RUTClave + ' - ' + RUT.Descripcion as Ruta, Dia.FechaCaptura as FechaPedido, TRP.Folio as FolioPedido,  CLI.Clave + ' - ' + CLI.RazonSocial as Cliente, TRP.Total as Total, PRO.Nombre as Producto, TPD.Precio, TPD.Cantidad 
	into #Preventa
	from TransProd TRP
	inner join TransProdDetalle TPD on TRP.TransProdID = TPD.TransProdID 
	inner join Visita VIS on VIS.VisitaClave = TRP.VisitaClave and VIS.DiaClave = TRP.DiaClave 
	inner join Cliente CLI on VIS.ClienteClave = CLI.ClienteClave 
	inner join Vendedor VEN on VIS.VendedorID = VEN.VendedorID and (VEN.VendedorID IN (SELECT Datos FROM FNSplit(@filtroVendedores, ',')) or @filtroVendedores is null)
	inner join Dia on VIS.DiaClave = Dia.DiaClave and CONVERT(date, Dia.FechaCaptura, 112) BETWEEN @filtroFechaInicio AND @filtroFechaFin
	inner join Ruta RUT on RUT.RUTClave = VIS.RUTClave and  (RUT.RUTClave in (SELECT Datos FROM FNSplit(@filtroRutas, ',')) or @filtroRutas is NULL)
	inner join VAVDescripcion VAD on VAD.VARCodigo = 'TURNO' and VAVClave = TRP.TipoTurno and VADTipoLenguaje = @TipoLenguaje
	inner join Producto PRO on PRO.ProductoClave = TPD.ProductoClave 
	where TRP.Tipo = 1 and TRP.TipoFase = 1 

	Select FechaCaptura as [Fecha|FORMAT%{0:dd/mm/yyyy}|GROUPER],Distribuidor as [Distribuidor|GROUPER] ,Vendedor as [Vendedor|GROUPER] , 
			   CASE WHEN 
				 ROW_NUMBER() OVER
					  (PARTITION BY FechaCaptura,Distribuidor, Vendedor, Ruta ORDER BY FechaCaptura Asc, Distribuidor ASC,Vendedor ASC,  Ruta ASC) =1
				   THEN Ruta
				 ELSE ''
			   END [Ruta], 
			   CASE 
				 WHEN ROW_NUMBER() OVER
					  (PARTITION BY FechaCaptura, Distribuidor,Vendedor, Ruta,FechaPedido ORDER BY FechaCaptura Asc, Distribuidor ASC,Vendedor ASC, Ruta ASC, FechaPedido ASC) = 1 
				   THEN FechaPedido
				 ELSE null
			   END [FechaPedido|FORMAT%{0:dd/mm/yyyy hh:mm:ss}],
			   	CASE 
				 WHEN ROW_NUMBER() OVER
					  (PARTITION BY FechaCaptura, Distribuidor,Vendedor, Ruta,FechaPedido,FolioPedido ORDER BY FechaCaptura Asc, Distribuidor ASC,Vendedor ASC, Ruta ASC, FechaPedido ASC, FolioPedido ASC) = 1 
				   THEN FolioPedido
				 ELSE ''
			   END [FolioPedido],
			   CASE 
				 WHEN ROW_NUMBER() OVER
					  (PARTITION BY FechaCaptura,Distribuidor, Vendedor,  Ruta,FechaPedido, FolioPedido, Cliente  ORDER BY FechaCaptura Asc, Distribuidor ASC,Vendedor ASC, Ruta ASC, FechaPedido ASC,FolioPedido ASC, Cliente ASC) = 1 
				   THEN Cliente
				 ELSE ''
			   END [Cliente],
			   CASE 
				 WHEN ROW_NUMBER() OVER
					  (PARTITION BY FechaCaptura,Distribuidor, Vendedor,  Ruta,FechaPedido, FolioPedido, Cliente, Total  ORDER BY FechaCaptura Asc, Distribuidor ASC,Vendedor ASC, Ruta ASC, FechaPedido ASC,FolioPedido ASC, Cliente ASC, Total ASC) = 1 
				   THEN Total
				 ELSE null
			   END [Total|SUMMARY|FORMAT&n] , Producto, Precio as [Precio|FORMAT&n], Cantidad
	from #Preventa PRE
	order by FechaCaptura,Distribuidor, Vendedor,  ROW_NUMBER() OVER (PARTITION BY FechaCaptura, Vendedor, Distribuidor, Ruta ORDER BY FechaCaptura Asc, Distribuidor ASC,Vendedor ASC,  Ruta ASC), 
	ROW_NUMBER() OVER(PARTITION BY FechaCaptura, Distribuidor,Vendedor,  Ruta,FechaPedido ORDER BY FechaCaptura Asc, Distribuidor ASC,Vendedor ASC, Ruta ASC, FechaPedido ASC) , 
	ROW_NUMBER() OVER(PARTITION BY FechaCaptura, Distribuidor,Vendedor, Ruta,FechaPedido,FolioPedido ORDER BY FechaCaptura Asc, Distribuidor ASC,Vendedor ASC, Ruta ASC, FechaPedido ASC, FolioPedido ASC),
	ROW_NUMBER() OVER(PARTITION BY FechaCaptura, Distribuidor,Vendedor,  Ruta,FechaPedido, Cliente  ORDER BY FechaCaptura Asc, Distribuidor ASC,Vendedor ASC, Ruta ASC, FechaPedido ASC,FolioPedido ASC, Cliente ASC) ,
	ROW_NUMBER() OVER(PARTITION BY FechaCaptura,Distribuidor, Vendedor,  Ruta,FechaPedido, FolioPedido, Cliente, Total  ORDER BY FechaCaptura Asc, Distribuidor ASC,Vendedor ASC, Ruta ASC, FechaPedido ASC,FolioPedido ASC, Cliente ASC, Total ASC),
	Producto


	DROP TABLE #Preventa