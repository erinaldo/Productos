SET NOCOUNT ON
IF EXISTS (SELECT TOP 1 [object_id] FROM [sys].[objects] WHERE [object_id] = OBJECT_ID(N'[dbo].[stpr_Kardex_81]'))
	DROP PROCEDURE [dbo].[stpr_Kardex_81]
SET NOCOUNT OFF
/*go*/go
 
CREATE PROCEDURE [dbo].[stpr_Kardex_81]
	@filtroCedis AS VARCHAR(MAX) = NULL,
	@filtroEsquemasProd AS VARCHAR(MAX) = NULL,
	@filtroFechaInicio AS VARCHAR(10) = NULL,
	@filtroFechaFin AS VARCHAR(10) = NULL
AS

DECLARE
	@Cedis AS VARCHAR(MAX) = NULL,
	@Esquemas AS VARCHAR(MAX) = NULL,
	@MostrarME AS BIT = 0

IF NOT COALESCE(@filtroCedis,'') = ''
	SET @Cedis = @filtroCedis
IF NOT COALESCE(@filtroEsquemasProd,'') = ''
	SET @Esquemas = @filtroEsquemasProd

SET NOCOUNT ON
	Set transaction isolation level read uncommitted

	Select distinct ProductoClave, Nombre, [InventarioInicial BE], [InventarioInicial ME], [Entradas BE], [Entradas ME], [Salidas BE], [Salidas ME], [Obsequios], [Ventas Contado], [Ventas Credito], [Entradas BE por Conteo],
	[Entradas ME por Conteo], [Salidas BE por Conteo], [Salidas ME por Conteo], (isnull([InventarioInicial BE],0) + isnull([Entradas BE],0) - isnull([Salidas BE],0)) as [Inventario Final BE],
	([InventarioInicial ME] + [Entradas ME] - [Salidas ME]) as [Inventario Final ME], ' ' as ' ', (([Entradas BE por Conteo] - [Salidas BE por Conteo]) - ([Entradas BE] - [Salidas BE])) as [Diferencia BE],
	(([Entradas ME por Conteo] - [Salidas ME por Conteo]) - ([Entradas ME] - [Salidas ME])) as [Diferencia ME], ' ' as '_', [Cargas], [Dev. Buena], [Dev. Mala]
	into #Temp_Kardex 
	from
	(
	Select distinct
	P.ProductoClave,
	P.Nombre,
	--Inventario Inicial BE
	isnull(
	Case when CONVERT(DATETIME,CONVERT(VARCHAR(20),getdate(),112)) = @filtroFechaInicio then
		(select top 1 isnull(BuenEstado,0) from inventario where ((AlmacenId IN (SELECT Datos FROM [dbo].[FNSplit](@Cedis, ','))) OR @Cedis IS NULL) and ProductoClave = P.ProductoClave)
	else
		(select top 1 isnull(BuenEstadoFin,0) FROM InvHist I (NOLOCK) Inner Join InvHistDetalle ID (NOLOCK) on I.InvHId = ID.InvHId where ((AlmacenId IN (SELECT Datos FROM [dbo].[FNSplit](@Cedis, ','))) OR @Cedis IS NULL) and CONVERT(DATETIME,CONVERT(VARCHAR(20),I.FechaHoraAlta,112)) < @filtroFechaInicio and ProductoClave = P.ProductoClave order by I.FechaHoraAlta desc) end
	, (select top 1 isnull(BuenEstado,0) from inventario where ((AlmacenId IN (SELECT Datos FROM [dbo].[FNSplit](@Cedis, ','))) OR @Cedis IS NULL) and ProductoClave = P.ProductoClave)) as [InventarioInicial BE],
	--Inventario Inicial ME
	isnull(
	Case when CONVERT(DATETIME,CONVERT(VARCHAR(20),getdate(),112)) = @filtroFechaInicio then
		(select top 1 isnull(MalEstado,0) from inventario (NOLOCK) where ((AlmacenId IN (SELECT Datos FROM [dbo].[FNSplit](@Cedis, ','))) OR @Cedis IS NULL) and ProductoClave = P.ProductoClave)
	else
		(select top 1 isnull(MalEstadoFin,0) FROM InvHist I (NOLOCK) Inner Join InvHistDetalle ID (NOLOCK) on I.InvHId = ID.InvHId where ((AlmacenId IN (SELECT Datos FROM [dbo].[FNSplit](@Cedis, ','))) OR @Cedis IS NULL) and CONVERT(DATETIME,CONVERT(VARCHAR(20),I.FechaHoraAlta,112)) < @filtroFechaInicio and ProductoClave = P.ProductoClave order by I.FechaHoraAlta desc) end
	, (select top 1 isnull(MalEstado,0) from inventario (NOLOCK) where ((AlmacenId IN (SELECT Datos FROM [dbo].[FNSplit](@Cedis, ','))) OR @Cedis IS NULL) and ProductoClave = P.ProductoClave)) as [InventarioInicial ME],
	--Entradas BE
	(
	Select sum(isnull(Cantidad,0))
	from(
	Select sum(isnull(MD.Cantidad,0)) as Cantidad
	from Transprod T
	inner join Dia D (NOLOCK) on isnull(T.DiaClave1, T.DiaClave) = D.DiaClave and CONVERT(DATETIME,CONVERT(VARCHAR(20),D.FechaCaptura,112)) between @filtroFechaInicio AND @filtroFechaFin
	inner join MovAlmacen M (NOLOCK) on T.TransProdID = M.TransProdId and ((M.AlmacenId IN (SELECT Datos FROM [dbo].[FNSplit](@Cedis, ','))) OR (M.AlmacenId IN (Select AlmacenID from Almacen where AlmacenPadreId in (SELECT Datos FROM [dbo].[FNSplit](@Cedis, ',')))) OR @Cedis IS NULL) and ((T.Tipo <> 3 and T.TipoFase = 2) or (T.Tipo = 7 and T.TipoFase = 1))
	inner join ConfigMovAlmacen CM (NOLOCK) on M.CMAId = CM.CMAId and CM.TipoMovPerm = 1 and CM.Descripcion not in ('Ajuste de entrada en buen estado por diferencia', 'Ajuste de entrada en mal estado por diferencia', 'Ajuste de salida en buen estado por diferencia', 'Ajuste de salida en mal estado por diferencia') and CM.TipoAplicacion = 1
	inner join MOVDetalle MD (NOLOCK) on M.MOVId = MD.MOVId and MD.ProductoClave = P.ProductoClave
	left join TrpTpd TT (NOLOCK) on T.TransProdID = isnull(TT.TransprodId1, TT.TransprodId)
	where TT.TransProdID is null
	union all
	Select sum(isnull(MD.Cantidad,0)) as Cantidad
	from MovAlmacen M 
	inner join ConfigMovAlmacen CM (NOLOCK) on M.CMAId = CM.CMAId and CM.TipoAplicacion = 1 and M.TransProdId is null and CM.TipoMovPerm = 1 and CM.Descripcion not in ('Ajuste de entrada en buen estado por diferencia', 'Ajuste de entrada en mal estado por diferencia', 'Ajuste de salida en buen estado por diferencia', 'Ajuste de salida en mal estado por diferencia') and CONVERT(DATETIME,CONVERT(VARCHAR(20),M.FechaHoraAplicacion,112)) between @filtroFechaInicio AND @filtroFechaFin
	inner join MOVDetalle MD (NOLOCK) on M.MOVId = MD.MOVId and MD.ProductoClave = P.ProductoClave
	) T) as [Entradas BE],
	--Entradas ME
	(
	Select sum(isnull(Cantidad,0))
	from(
	Select sum(isnull(MD.Cantidad,0)) as Cantidad
	from Transprod T
	inner join Dia D (NOLOCK) on isnull(T.DiaClave1, T.DiaClave) = D.DiaClave and CONVERT(DATETIME,CONVERT(VARCHAR(20),D.FechaCaptura,112)) between @filtroFechaInicio AND @filtroFechaFin
	inner join MovAlmacen M (NOLOCK) on T.TransProdID = M.TransProdId and ((M.AlmacenId IN (SELECT Datos FROM [dbo].[FNSplit](@Cedis, ','))) OR (M.AlmacenId IN (Select AlmacenID from Almacen where AlmacenPadreId in (SELECT Datos FROM [dbo].[FNSplit](@Cedis, ',')))) OR @Cedis IS NULL) and T.TipoFase = 2
	inner join ConfigMovAlmacen CM (NOLOCK) on M.CMAId = CM.CMAId and CM.TipoMovPerm = 1 and CM.Descripcion not in ('Ajuste de entrada en buen estado por diferencia', 'Ajuste de entrada en mal estado por diferencia', 'Ajuste de salida en buen estado por diferencia', 'Ajuste de salida en mal estado por diferencia') and CM.TipoAplicacion = 2
	inner join MOVDetalle MD (NOLOCK) on M.MOVId = MD.MOVId and MD.ProductoClave = P.ProductoClave
	left join TrpTpd TT (NOLOCK) on T.TransProdID = isnull(TT.TransprodId1, TT.TransprodId)
	where TT.TransProdID is null
	union all
	Select sum(isnull(MD.Cantidad,0)) as Cantidad
	from MovAlmacen M 
	inner join ConfigMovAlmacen CM (NOLOCK) on M.CMAId = CM.CMAId and CM.TipoAplicacion = 2 and M.TransProdId is null and CM.TipoMovPerm = 1 and CM.Descripcion not in ('Ajuste de entrada en buen estado por diferencia', 'Ajuste de entrada en mal estado por diferencia', 'Ajuste de salida en buen estado por diferencia', 'Ajuste de salida en mal estado por diferencia') and CONVERT(DATETIME,CONVERT(VARCHAR(20),M.FechaHoraAplicacion,112)) between @filtroFechaInicio AND @filtroFechaFin
	inner join MOVDetalle MD (NOLOCK) on M.MOVId = MD.MOVId and MD.ProductoClave = P.ProductoClave
	) T) as [Entradas ME],
	--Salidas BE
	(
	Select sum(isnull(Cantidad,0))
	from(
	Select sum(isnull(MD.Cantidad,0)) as Cantidad
	from Transprod T
	inner join Dia D (NOLOCK) on isnull(T.DiaClave1, T.DiaClave) = D.DiaClave and CONVERT(DATETIME,CONVERT(VARCHAR(20),D.FechaCaptura,112)) between @filtroFechaInicio AND @filtroFechaFin
	inner join MovAlmacen M (NOLOCK) on T.TransProdID = M.TransProdId and ((M.AlmacenId IN (SELECT Datos FROM [dbo].[FNSplit](@Cedis, ','))) OR (M.AlmacenId IN (Select AlmacenID from Almacen where AlmacenPadreId in (SELECT Datos FROM [dbo].[FNSplit](@Cedis, ',')))) OR @Cedis IS NULL) and (T.Tipo not in (1,24) and T.TipoFase = 2 or (T.Tipo = 2 and T.TipoFase = 1))
	inner join ConfigMovAlmacen CM (NOLOCK) on M.CMAId = CM.CMAId and CM.TipoMovPerm = 2 and CM.Descripcion not in ('Ajuste de entrada en buen estado por diferencia', 'Ajuste de entrada en mal estado por diferencia', 'Ajuste de salida en buen estado por diferencia', 'Ajuste de salida en mal estado por diferencia') and CM.TipoAplicacion = 1
	inner join MOVDetalle MD (NOLOCK) on M.MOVId = MD.MOVId and MD.ProductoClave = P.ProductoClave
	left join TrpTpd TT (NOLOCK) on T.TransProdID = isnull(TT.TransprodId1, TT.TransprodId)
	where TT.TransProdID is null
	union all
	Select sum(isnull(MD.Cantidad,0)) as Cantidad
	from MovAlmacen M 
	inner join ConfigMovAlmacen CM (NOLOCK) on M.CMAId = CM.CMAId and CM.TipoAplicacion = 1 and M.TransProdId is null and CM.TipoMovPerm = 2 and M.TipoFase = 2 and CM.Descripcion not in ('Ajuste de entrada en buen estado por diferencia', 'Ajuste de entrada en mal estado por diferencia', 'Ajuste de salida en buen estado por diferencia', 'Ajuste de salida en mal estado por diferencia') and CONVERT(DATETIME,CONVERT(VARCHAR(20),M.FechaHoraAplicacion,112)) between @filtroFechaInicio AND @filtroFechaFin
	inner join MOVDetalle MD (NOLOCK) on M.MOVId = MD.MOVId and MD.ProductoClave = P.ProductoClave
	) T) as [Salidas BE],
	--Salidas ME
	(
	Select sum(isnull(Cantidad,0))
	from(
	Select sum(isnull(MD.Cantidad,0)) as Cantidad
	from Transprod T
	inner join Dia D (NOLOCK) on isnull(T.DiaClave1, T.DiaClave) = D.DiaClave and CONVERT(DATETIME,CONVERT(VARCHAR(20),D.FechaCaptura,112)) between @filtroFechaInicio AND @filtroFechaFin
	inner join MovAlmacen M (NOLOCK) on T.TransProdID = M.TransProdId and ((M.AlmacenId IN (SELECT Datos FROM [dbo].[FNSplit](@Cedis, ','))) OR (M.AlmacenId IN (Select AlmacenID from Almacen where AlmacenPadreId in (SELECT Datos FROM [dbo].[FNSplit](@Cedis, ',')))) OR @Cedis IS NULL) and T.Tipo not in (1) and T.TipoFase = 2
	inner join ConfigMovAlmacen CM (NOLOCK) on M.CMAId = CM.CMAId and CM.TipoMovPerm = 2 and CM.Descripcion not in ('Ajuste de entrada en buen estado por diferencia', 'Ajuste de entrada en mal estado por diferencia', 'Ajuste de salida en buen estado por diferencia', 'Ajuste de salida en mal estado por diferencia') and CM.TipoAplicacion = 2
	inner join MOVDetalle MD (NOLOCK) on M.MOVId = MD.MOVId and MD.ProductoClave = P.ProductoClave
	left join TrpTpd TT (NOLOCK) on T.TransProdID = isnull(TT.TransprodId1, TT.TransprodId)
	where TT.TransProdID is null
	union all
	Select sum(isnull(MD.Cantidad,0)) as Cantidad
	from MovAlmacen M 
	inner join ConfigMovAlmacen CM (NOLOCK) on M.CMAId = CM.CMAId and CM.TipoAplicacion = 2 and M.TransProdId is null and CM.TipoMovPerm = 2 and M.TipoFase = 2 and CM.Descripcion not in ('Ajuste de entrada en buen estado por diferencia', 'Ajuste de entrada en mal estado por diferencia', 'Ajuste de salida en buen estado por diferencia', 'Ajuste de salida en mal estado por diferencia') and CONVERT(DATETIME,CONVERT(VARCHAR(20),M.FechaHoraAplicacion,112)) between @filtroFechaInicio AND @filtroFechaFin
	inner join MOVDetalle MD (NOLOCK) on M.MOVId = MD.MOVId and MD.ProductoClave = P.ProductoClave
	) T) as [Salidas ME],
	--Obsequios
	(
	Select isnull(sum(isnull(TD.Cantidad,0)),0) as Cantidad
	from Transprod T
	inner join Dia D (NOLOCK) on isnull(T.DiaClave1, T.DiaClave) = D.DiaClave and CONVERT(DATETIME,CONVERT(VARCHAR(20),D.FechaCaptura,112)) between @filtroFechaInicio AND @filtroFechaFin
	inner join MovAlmacen M (NOLOCK) on T.TransProdID = M.TransProdId and ((M.AlmacenId IN (SELECT Datos FROM [dbo].[FNSplit](@Cedis, ','))) OR (M.AlmacenId IN (Select AlmacenID from Almacen where AlmacenPadreId in (SELECT Datos FROM [dbo].[FNSplit](@Cedis, ',')))) OR @Cedis IS NULL) and T.Tipo in (1) and T.TipoFase in (2,3) and T.Promocion = 2 and M.TipoFase = 2
	inner join TransprodDetalle TD (NOLOCK) on T.TransProdID = TD.TransProdID and TD.ProductoClave = P.ProductoClave
	left join TrpTpd TT (NOLOCK) on T.TransProdID = isnull(TT.TransprodId1, TT.TransprodId)
	where TT.TransProdID is null) as [Obsequios],
	--Ventas Contado
	(
	Select isnull(sum(isnull(TD.Cantidad,0)),0) as Cantidad
	from Transprod T
	inner join Dia D (NOLOCK) on isnull(T.DiaClave1, T.DiaClave) = D.DiaClave and CONVERT(DATETIME,CONVERT(VARCHAR(20),D.FechaCaptura,112)) between @filtroFechaInicio AND @filtroFechaFin
	inner join TransprodDetalle TD (NOLOCK) on T.TransProdID = TD.TransProdID and TD.ProductoClave = P.ProductoClave and T.Tipo in (1) and T.TipoFase in (2,3) and isnull(T.Promocion,0) <> 2 and T.CFVTipo = 1
	left join MovAlmacen M (NOLOCK) on T.TransProdID = M.TransProdId and ((M.AlmacenId IN (SELECT Datos FROM [dbo].[FNSplit](@Cedis, ','))) OR (M.AlmacenId IN (Select AlmacenID from Almacen where AlmacenPadreId in (SELECT Datos FROM [dbo].[FNSplit](@Cedis, ',')))) OR @Cedis IS NULL) and M.TipoFase = 2
	left join TrpTpd TT (NOLOCK) on T.TransProdID = isnull(TT.TransprodId1, TT.TransprodId)
	where TT.TransProdID is null) as [Ventas Contado],
	--Ventas Credito
	(
	Select isnull(sum(isnull(TD.Cantidad,0)),0) as Cantidad
	from Transprod T
	inner join Dia D (NOLOCK) on isnull(T.DiaClave1, T.DiaClave) = D.DiaClave and CONVERT(DATETIME,CONVERT(VARCHAR(20),D.FechaCaptura,112)) between @filtroFechaInicio AND @filtroFechaFin
	inner join TransprodDetalle TD (NOLOCK) on T.TransProdID = TD.TransProdID and TD.ProductoClave = P.ProductoClave and T.Tipo in (1) and T.TipoFase in (2,3) and isnull(T.Promocion,0) <> 2 and T.CFVTipo = 2
	left join MovAlmacen M (NOLOCK) on T.TransProdID = M.TransProdId and ((M.AlmacenId IN (SELECT Datos FROM [dbo].[FNSplit](@Cedis, ','))) OR (M.AlmacenId IN (Select AlmacenID from Almacen where AlmacenPadreId in (SELECT Datos FROM [dbo].[FNSplit](@Cedis, ',')))) OR @Cedis IS NULL) and M.TipoFase = 2
	left join TrpTpd TT (NOLOCK) on T.TransProdID = isnull(TT.TransprodId1, TT.TransprodId)
	where TT.TransProdID is null) as [Ventas Credito],
	--Entradas BE por Conteo
	(
	select isnull(sum(isnull(MD.Cantidad,0)),0)  as Cantidad
	from MovAlmacen M 
	inner join CONHist CH (NOLOCK) on M.CMAId = CH.AjusteEntradaBE and CONVERT(DATETIME,CONVERT(VARCHAR(20),M.FechaHoraAplicacion,112)) between @filtroFechaInicio AND @filtroFechaFin
	inner join MOVDetalle MD (NOLOCK) on M.MOVId = MD.MOVId and MD.ProductoClave = P.ProductoClave) as [Entradas BE por Conteo],
	--Entradas ME por Conteo
	(
	select isnull(sum(isnull(MD.Cantidad,0)),0)  as Cantidad
	from MovAlmacen M 
	inner join CONHist CH (NOLOCK) on M.CMAId = CH.AjusteEntradaME and CONVERT(DATETIME,CONVERT(VARCHAR(20),M.FechaHoraAplicacion,112)) between @filtroFechaInicio AND @filtroFechaFin
	inner join MOVDetalle MD (NOLOCK) on M.MOVId = MD.MOVId and MD.ProductoClave = P.ProductoClave) as [Entradas ME por Conteo],
	--Salidas ME por Conteo
	(
	select isnull(sum(isnull(MD.Cantidad,0)),0)  as Cantidad
	from MovAlmacen M 
	inner join CONHist CH (NOLOCK) on M.CMAId = CH.AjusteSalidaBE and CONVERT(DATETIME,CONVERT(VARCHAR(20),M.FechaHoraAplicacion,112)) between @filtroFechaInicio AND @filtroFechaFin
	inner join MOVDetalle MD (NOLOCK) on M.MOVId = MD.MOVId and MD.ProductoClave = P.ProductoClave) as [Salidas BE por Conteo],
	--Salidas ME por Conteo
	(
	select isnull(sum(isnull(MD.Cantidad,0)),0)  as Cantidad
	from MovAlmacen M 
	inner join CONHist CH (NOLOCK) on M.CMAId = CH.AjusteSalidaME and CONVERT(DATETIME,CONVERT(VARCHAR(20),M.FechaHoraAplicacion,112)) between @filtroFechaInicio AND @filtroFechaFin
	inner join MOVDetalle MD (NOLOCK) on M.MOVId = MD.MOVId and MD.ProductoClave = P.ProductoClave) as [Salidas ME por Conteo],
	--Cargas
	(
	Select isnull(sum(isnull(TD.Cantidad,0)),0) as Cantidad
	from Transprod T
	inner join Dia D (NOLOCK) on isnull(T.DiaClave1, T.DiaClave) = D.DiaClave and CONVERT(DATETIME,CONVERT(VARCHAR(20),D.FechaCaptura,112)) between @filtroFechaInicio AND @filtroFechaFin
	inner join TransprodDetalle TD (NOLOCK) on T.TransProdID = TD.TransProdID and T.Tipo = 2 and TD.ProductoClave = P.ProductoClave
	inner join Vendedor V (NOLOCK) on T.MUsuarioID = V.UsuId
	inner join VENCentroDistHist VH (NOLOCK) on V.VendedorID = VH.VendedorId and ((VH.AlmacenId IN (SELECT Datos FROM [dbo].[FNSplit](@Cedis, ','))) OR (VH.AlmacenId IN (Select AlmacenID from Almacen where AlmacenPadreId in (SELECT Datos FROM [dbo].[FNSplit](@Cedis, ',')))) OR @Cedis IS NULL)) as [Cargas],
	--Dev. Buena
	(
	Select isnull(sum(isnull(TD.Cantidad,0)),0) as Cantidad
	from Transprod T
	inner join Dia D (NOLOCK) on isnull(T.DiaClave1, T.DiaClave) = D.DiaClave and CONVERT(DATETIME,CONVERT(VARCHAR(20),D.FechaCaptura,112)) between @filtroFechaInicio AND @filtroFechaFin
	inner join TransprodDetalle TD (NOLOCK) on T.TransProdID = TD.TransProdID and T.Tipo = 7 and TD.ProductoClave = P.ProductoClave
	inner join Vendedor V (NOLOCK) on T.MUsuarioID = V.UsuId
	inner join VENCentroDistHist VH (NOLOCK) on V.VendedorID = VH.VendedorId and ((VH.AlmacenId IN (SELECT Datos FROM [dbo].[FNSplit](@Cedis, ','))) OR (VH.AlmacenId IN (Select AlmacenID from Almacen where AlmacenPadreId in (SELECT Datos FROM [dbo].[FNSplit](@Cedis, ',')))) OR @Cedis IS NULL)) as [Dev. Buena],
	--Dev. Mala
	(
	Select isnull(sum(isnull(TD.Cantidad,0)),0) as Cantidad
	from Transprod T
	inner join Dia D (NOLOCK) on isnull(T.DiaClave1, T.DiaClave) = D.DiaClave and CONVERT(DATETIME,CONVERT(VARCHAR(20),D.FechaCaptura,112)) between @filtroFechaInicio AND @filtroFechaFin
	inner join TransprodDetalle TD (NOLOCK) on T.TransProdID = TD.TransProdID and T.Tipo = 4 and TD.ProductoClave = P.ProductoClave
	inner join Vendedor V (NOLOCK) on T.MUsuarioID = V.UsuId
	inner join VENCentroDistHist VH (NOLOCK) on V.VendedorID = VH.VendedorId and ((VH.AlmacenId IN (SELECT Datos FROM [dbo].[FNSplit](@Cedis, ','))) OR (VH.AlmacenId IN (Select AlmacenID from Almacen where AlmacenPadreId in (SELECT Datos FROM [dbo].[FNSplit](@Cedis, ',')))) OR @Cedis IS NULL)) as [Dev. Mala]
	-------------------------------------------------------------------------------------------------------------------------------------------------------------------
	from Producto p (NOLOCK)
	inner join ProductoEsquema pe (NOLOCK) on p.ProductoClave=pe.ProductoClave and ((pe.EsquemaId IN (SELECT Datos FROM [dbo].[FNSplit](@Esquemas, ','))) OR @Esquemas IS NULL)
	inner join Esquema e (NOLOCK) on pe.EsquemaID=e.EsquemaID 
	group by P.ProductoClave, P.Nombre
	) T

	If ((select sum([InventarioInicial ME]) from #Temp_Kardex) > 0 or (select sum([Entradas ME]) from #Temp_Kardex) > 0 or (select sum([Salidas ME]) from #Temp_Kardex) > 0 or (select sum([Entradas ME por Conteo]) from #Temp_Kardex) > 0 or (select sum([Salidas ME por Conteo]) from #Temp_Kardex) > 0 or (select sum([Inventario Final ME]) from #Temp_Kardex) > 0 or (select sum([Diferencia ME]) from #Temp_Kardex) > 0)
		Select * from #Temp_Kardex
	Else
		Select ProductoClave, Nombre, [InventarioInicial BE], [Entradas BE], [Salidas BE], [Obsequios], [Ventas Contado], [Ventas Credito], [Entradas BE por Conteo],
		[Salidas BE por Conteo], [Inventario Final BE], ' ' as ' ', [Diferencia BE], ' ' as '_', [Cargas], [Dev. Buena], [Dev. Mala]
		from #Temp_Kardex
	drop table #Temp_Kardex


SET NOCOUNT OFF
/*go*/go