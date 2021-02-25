SET NOCOUNT ON
IF EXISTS (SELECT TOP 1 [object_id] FROM [sys].[objects] WHERE [object_id] = OBJECT_ID(N'[dbo].[stpr_Inventario_84]'))
	DROP PROCEDURE [dbo].[stpr_Inventario_84]
SET NOCOUNT OFF
/*go*/go
 
CREATE PROCEDURE [dbo].[stpr_Inventario_84]
	@filtroVendedor AS VARCHAR(MAX) = NULL,
	@filtroFechaInicio AS VARCHAR(10) = NULL
AS

	SET NOCOUNT ON
	DECLARE
		@VendedorId AS VARCHAR(MAX) = NULL,
		@FechaIni AS DATETIME = NULL

	IF NOT COALESCE(@filtroVendedor,'') = ''
		SET @VendedorId = @filtroVendedor

	IF NOT COALESCE(@filtroFechaInicio,'') = ''
		SET @FechaIni = @filtroFechaInicio

	IF (@VendedorId IS NOT NULL) AND (@FechaIni IS NOT NULL)
	BEGIN
		if (select object_id('tempdb..#TmpPrimeraCarga')) is not null drop table #TmpPrimeraCarga
		begin
		select * into #TmpPrimeraCarga from(
			select VD.VendedorID,D.FechaCaptura,(min(T.FechaHoraAlta)) as FechaHoraPrimeraCarga, '1' as TipoCarga
			from TransProd T (NOLOCK)
			inner join Dia D (NOLOCK) on T.DiaClave=D.DiaClave
			inner join Vendedor VD (NOLOCK) on T.MUsuarioID=VD.USUId
			where T.Tipo in (2) and T.TipoFase<>0 and CONVERT(DATETIME,CONVERT(VARCHAR(20),D.FechaCaptura,112)) = @filtroFechaInicio and (VD.VendedorID IN (SELECT Datos FROM [dbo].[FNSplit](@VendedorId, ',')) OR @VendedorId IS NULL)
			group by VD.VendedorID,D.FechaCaptura
		) as PrimeraCarga 
		end

		Select [Vendedor] as [Vendedor|GROUPER],
		[Clave],
		[Descripcion],
		SUM([Inventario Inicial (Carga)]) as [Inventario Inicial (Carga)|SUMMARY],
		SUM([Recarga]) as [Recarga|SUMMARY],
		SUM([Devolucion]) as [Devolucion|SUMMARY],
		SUM([Promocion]) as [Promocion|SUMMARY],
		SUM([Descarga Almacen]) as [Descarga Almacen|SUMMARY],
		SUM([Consignas]) as [Consignas|SUMMARY],
		SUM([Ventas]) as [Ventas|SUMMARY],
		SUM(([Inventario Inicial (Carga)]+[Recarga]+[Devolucion]) - ([Promocion] + [Descarga Almacen] + [Ventas])) as [Inventario Final|SUMMARY],
		SUM([Importe]) as [Importe|FORMAT&$|SUMMARY]
		from
		(
			--Primera Carga y recargas
			Select
			VD.Nombre as [Vendedor],
			P.ProductoClave as [Clave],
			P.Nombre as [Descripcion],
			SUM(Case when PC.VendedorId is not null then TPD.Cantidad else 0 end) as [Inventario Inicial (Carga)],
			SUM(Case when PC.VendedorId is null then TPD.Cantidad else 0 end) as [Recarga],
			0 as [Devolucion],
			0 as [Promocion],
			0 as [Descarga Almacen],
			0 as [Consignas],
			0 as [Ventas],
			0 as [Importe]
			From Transprod TP (NOLOCK)
			INNER JOIN TransprodDetalle TPD (NOLOCK) on TP.TransProdID = TPD.TransProdId and CONVERT(DATETIME,CONVERT(VARCHAR(20),TP.FechaCaptura,112)) = @filtroFechaInicio and TP.Tipo = 2
			INNER JOIN ProductoDetalle PD (NOLOCK) on TPD.ProductoClave = PD.ProductoClave
			INNER JOIN Producto P (NOLOCK) on PD.ProductoDetClave = P.ProductoClave
			INNER JOIN Dia D (NOLOCK) on TP.DiaClave = D.DiaClave
			INNER JOIN Vendedor VD (NOLOCK) on TP.MUsuarioID = VD.USUId and (VD.VendedorID IN (SELECT Datos FROM [dbo].[FNSplit](@VendedorId, ',')) OR @VendedorId IS NULL)
			LEFT JOIN #TmpPrimeraCarga PC (NOLOCK) on VD.VendedorID = PC.VendedorID and TP.FechaHoraAlta = PC.FechaHoraPrimeraCarga
			Group by VD.Nombre, P.ProductoClave, P.Nombre
			Union
			--Devoluciones
			Select
			VD.Nombre as [Vendedor],
			P.ProductoClave as [Clave],
			P.Nombre as [Descripcion],
			0 as [Inventario Inicial (Carga)],
			0 as [Recarga],
			Sum(TPD.Cantidad) as [Devolucion],
			0 as [Promocion],
			0 as [Descarga Almacen],
			0 as [Consignas],
			0 as [Ventas],
			0 as [Importe]
			From Transprod TP (NOLOCK)
			INNER JOIN TransprodDetalle TPD (NOLOCK) on TP.TransProdID = TPD.TransProdId and CONVERT(DATETIME,CONVERT(VARCHAR(20),TP.FechaCaptura,112)) = @filtroFechaInicio and TP.Tipo = 3
			INNER JOIN Producto P (NOLOCK) on TPD.ProductoClave = P.ProductoClave
			INNER JOIN Dia D (NOLOCK) on TP.DiaClave = D.DiaClave
			INNER JOIN Vendedor VD (NOLOCK) on TP.MUsuarioID = VD.USUId and (VD.VendedorID IN (SELECT Datos FROM [dbo].[FNSplit](@VendedorId, ',')) OR @VendedorId IS NULL)
			Group by VD.Nombre, P.ProductoClave, P.Nombre
			Union
			--Promociones y Ventas
			Select
			VD.Nombre as [Vendedor],
			P.ProductoClave as [Clave],
			P.Nombre as [Descripcion],
			0 as [Inventario Inicial (Carga)],
			0 as [Recarga],
			0 as [Devolucion],
			SUM(Case when isnull(TP.Promocion,0) = 2 then TPD.Cantidad else 0 end) as [Promocion],
			0 as [Descarga Almacen],
			0 as [Consignas],
			SUM(Case when isnull(TP.Promocion,0) <> 2 then TPD.Cantidad else 0 end) as [Ventas],
			SUM(Case when isnull(TP.Promocion,0) <> 2 then TPD.Total else 0 end) as [Importe]
			From Transprod TP (NOLOCK)
			INNER JOIN TransprodDetalle TPD (NOLOCK) on TP.TransProdID = TPD.TransProdId and CONVERT(DATETIME,CONVERT(VARCHAR(20),TP.FechaCaptura,112)) = @filtroFechaInicio and TP.Tipo = 1
			INNER JOIN Producto P (NOLOCK) on TPD.ProductoClave = P.ProductoClave
			INNER JOIN Dia D (NOLOCK) on TP.DiaClave = D.DiaClave
			INNER JOIN Vendedor VD (NOLOCK) on TP.MUsuarioID = VD.USUId and (VD.VendedorID IN (SELECT Datos FROM [dbo].[FNSplit](@VendedorId, ',')) OR @VendedorId IS NULL)
			Group by VD.Nombre, P.ProductoClave, P.Nombre
			Union
			--Descarga Almacen
			Select
			VD.Nombre as [Vendedor],
			P.ProductoClave as [Clave],
			P.Nombre as [Descripcion],
			0 as [Inventario Inicial (Carga)],
			0 as [Recarga],
			0 as [Devolucion],
			0 as [Promocion],
			Sum(TPD.Cantidad) as [Descarga Almacen],
			0 as [Consignas],
			0 as [Ventas],
			0 as [Importe]
			From Transprod TP (NOLOCK)
			INNER JOIN TransprodDetalle TPD (NOLOCK) on TP.TransProdID = TPD.TransProdId and CONVERT(DATETIME,CONVERT(VARCHAR(20),TP.FechaCaptura,112)) = @filtroFechaInicio and TP.Tipo = 7
			INNER JOIN Producto P (NOLOCK) on TPD.ProductoClave = P.ProductoClave
			INNER JOIN Dia D (NOLOCK) on TP.DiaClave = D.DiaClave
			INNER JOIN Vendedor VD (NOLOCK) on TP.MUsuarioID = VD.USUId and (VD.VendedorID IN (SELECT Datos FROM [dbo].[FNSplit](@VendedorId, ',')) OR @VendedorId IS NULL)
			Group by VD.Nombre, P.ProductoClave, P.Nombre
			Union
			--Consignacion
			Select
			VD.Nombre as [Vendedor],
			P.ProductoClave as [Clave],
			P.Nombre as [Descripcion],
			0 as [Inventario Inicial (Carga)],
			0 as [Recarga],
			0 as [Devolucion],
			0 as [Promocion],
			0 as [Descarga Almacen],
			Sum(TPD.Cantidad) as [Consignas],
			0 as [Ventas],
			0 as [Importe]
			From Transprod TP (NOLOCK)
			INNER JOIN TransprodDetalle TPD (NOLOCK) on TP.TransProdID = TPD.TransProdId and CONVERT(DATETIME,CONVERT(VARCHAR(20),TP.FechaCaptura,112)) = @filtroFechaInicio and TP.Tipo = 24
			INNER JOIN Producto P (NOLOCK) on TPD.ProductoClave = P.ProductoClave
			INNER JOIN Dia D (NOLOCK) on TP.DiaClave = D.DiaClave
			INNER JOIN Vendedor VD (NOLOCK) on TP.MUsuarioID = VD.USUId and (VD.VendedorID IN (SELECT Datos FROM [dbo].[FNSplit](@VendedorId, ',')) OR @VendedorId IS NULL)
			Group by VD.Nombre, P.ProductoClave, P.Nombre
		) T
		group by [Vendedor], [Clave], [Descripcion]
		order by [Vendedor] asc, [Clave] asc

		drop table #TmpPrimeraCarga
	END
	SET NOCOUNT OFF
/*go*/go