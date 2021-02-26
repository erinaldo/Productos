USE [RouteADM]
GO

update ArchivoTextoCampo set PosicionFinal = 39 where CodigoCampo = 'motivos'
/****** Object:  StoredProcedure [dbo].[sel_ArchivoTextoConsulta]    Script Date: 11/02/2011 11:17:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sel_ArchivoTextoConsulta]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sel_ArchivoTextoConsulta]
GO

USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[sel_ArchivoTextoConsulta]    Script Date: 11/02/2011 11:17:49 ******/
SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER OFF
GO





CREATE PROCEDURE [dbo].[sel_ArchivoTextoConsulta] 
@IdCedisVirtual as varchar(10),
@Fecha as datetime,
@Consulta as int
AS

if @Consulta = 1		--Consulta para crear el Archivo: ENC
begin
	-- CEDIS VIRTUAL
	select V.IdCedisVirtual, count(STRUT.IdRuta) as TotalRutasFecha, STRUT.Fecha, STRUT.Fecha
	from StatusRutas STRUT inner join Rutas RUT on RUT.IdRuta = STRUT.IdRuta and RUT.IdCedis = STRUT.IdCedis
	inner join CedisVirtuales V on RUT.TipoVenta = V.TipoRuta
	left join Surtidos SUR on SUR.IdRuta = RUT.IdRuta and SUR.Fecha = STRUT.Fecha
	where cast(V.IdCedisVirtual as varchar(10)) = @IdCedisVirtual and STRUT.Fecha = @Fecha and RUT.Status = 'A'
	and SUR.Status = 'C' --folio aplicado
	group by V.IdCedisVirtual, STRUT.Fecha, STRUT.Fecha, RUT.Status , RUT.TipoVenta
end

if @Consulta = 2		--Consulta para crear el Archivo: DET
begin
	-- CEDIS VIRTUAL
	Select IdProducto, 
			(select	isnull(SUM(MOVDET.Cantidad),0) --ENTRADA PT
			from Productos P
			inner join SurtidosDetalle SD on P.IdProducto = SD.IdProducto
			inner join Surtidos S on SD.IdSurtido = S.IdSurtido
			inner join Rutas R on S.IdRuta = R.IdRuta
			inner join CedisVirtuales V on R.TipoVenta = V.TipoRuta
			inner join MovimientosDetalle MOVDET on MOVDET.IdProducto = P.IdProducto
			inner join Movimientos MOV on MOV.IdMovimiento = MOVDET.IdMovimiento and MOV.IdCedis = MOVDET.IdCedis
			where	(cast(V.IdCedisVirtual as varchar(10)) = @IdCedisVirtual) AND (MOV.Fecha = @Fecha) AND (MOVDET.Cantidad > 0) and 
					(MOVDET.IdProducto = PRO.IdProducto) and (MOV.IdTipoMovimiento in (701,702,703,704))) as EntradaProductoTerminado,
			
			(select	isnull(SUM(MOVDET.Cantidad),0) --ENTRADA DEV. CLIENTE
			from Productos P
			inner join SurtidosDetalle SD on P.IdProducto = SD.IdProducto
			inner join Surtidos S on SD.IdSurtido = S.IdSurtido
			inner join Rutas R on S.IdRuta = R.IdRuta
			inner join CedisVirtuales V on R.TipoVenta = V.TipoRuta
			inner join MovimientosDetalle MOVDET on MOVDET.IdProducto = P.IdProducto
			inner join Movimientos MOV on MOV.IdMovimiento = MOVDET.IdMovimiento and MOV.IdCedis = MOVDET.IdCedis
			where	(cast(V.IdCedisVirtual as varchar(10)) = @IdCedisVirtual) AND (MOV.Fecha = @Fecha) AND (MOVDET.Cantidad > 0) and 
					(MOVDET.IdProducto = PRO.IdProducto) and (MOV.IdTipoMovimiento in (210))) as EntradaDevolucionesClientes,
			
			(select	ISNULL(SUM(MOVDET.Cantidad), 0) --OTRAS ENTRADAS 
			from Productos P 
			inner join SurtidosDetalle SD on P.IdProducto = SD.IdProducto
			inner join Surtidos S on SD.IdSurtido = S.IdSurtido
			inner join Rutas R on S.IdRuta = R.IdRuta
			inner join CedisVirtuales V on R.TipoVenta = V.TipoRuta
			inner join MovimientosDetalle MOVDET on MOVDET.IdProducto = P.IdProducto
			inner join Movimientos MOV on MOV.IdMovimiento = MOVDET.IdMovimiento and MOV.IdCedis = MOVDET.IdCedis
			inner join TipoMovimiento TPMOV on MOV.IdTipoMovimiento = TPMOV.IdTipoMovimiento
			where	(cast(V.IdCedisVirtual as varchar(10)) = @IdCedisVirtual) AND (MOV.Fecha = @Fecha) AND (MOVDET.Cantidad > 0) AND 
					(MOVDET.IdProducto = PRO.IdProducto) AND (MOV.IdTipoMovimiento not in (210, 701, 702, 703, 704)) and
					(TPMOV.EntradaSalida = 'E')) as OtrasEntradas,
			
			(select	isnull(SUM(VENDET.Cantidad),0)  --VENTAS CONTADO
			from Productos P 
			inner join VentasDetalle VENDET on P.IdProducto = VENDET.IdProducto
			inner join Ventas VEN ON VENDET.IdCedis = VEN.IdCedis AND 
			VENDET.IdSurtido = VEN.IdSurtido AND VENDET.IdTipoVenta = VEN.IdTipoVenta AND 
			VENDET.Folio = VEN.Folio AND VENDET.Serie = VEN.Serie
			inner join Surtidos S on VEN.IdSurtido = S.IdSurtido
			inner join Rutas R on S.IdRuta = R.IdRuta
			inner join CedisVirtuales V on R.TipoVenta = V.TipoRuta
			where	(cast(V.IdCedisVirtual as varchar(10)) = @IdCedisVirtual) AND (VEN.Fecha = @Fecha) and VEN.IdTipoVenta = 2 and 
					VENDET.IdProducto = PRO.IdProducto) as Ventascontado,
			
			(select	isnull(SUM(VENDET.Cantidad),0)  --VENTAS CREDITO
			from Productos P 
			inner join VentasDetalle VENDET on P.IdProducto = VENDET.IdProducto
			inner join Ventas VEN ON VENDET.IdCedis = VEN.IdCedis AND 
			VENDET.IdSurtido = VEN.IdSurtido AND VENDET.IdTipoVenta = VEN.IdTipoVenta AND 
			VENDET.Folio = VEN.Folio AND VENDET.Serie = VEN.Serie
			inner join Surtidos S on VEN.IdSurtido = S.IdSurtido
			inner join Rutas R on S.IdRuta = R.IdRuta
			inner join CedisVirtuales V on R.TipoVenta = V.TipoRuta
			where	(cast(V.IdCedisVirtual as varchar(10)) = @IdCedisVirtual) AND (VEN.Fecha = @Fecha) and VEN.IdTipoVenta = 1 and 
					VENDET.IdProducto = PRO.IdProducto) as VentasCredito,
			
			(select	isnull(SUM(SURDET.DevMala),0) --DEV. MALAS
			from	Surtidos AS SUR INNER JOIN
					SurtidosDetalle AS SURDET ON SUR.IdCedis = SURDET.IdCedis AND SUR.IdSurtido = SURDET.IdSurtido
					inner join Rutas R on SUR.IdRuta = R.IdRuta
					inner join CedisVirtuales V on R.TipoVenta = V.TipoRuta
			where	(cast(V.IdCedisVirtual as varchar(10)) = @IdCedisVirtual) and (SUR.Fecha = @Fecha) and 
					SURDET.IdProducto = PRO.IdProducto ) as DevolucionesMalas,
			
			(select	ISNULL(SUM(MOVDET.Cantidad), 0) --MOVIMIENTOS SALIDA
			from Productos P 
			inner join SurtidosDetalle SD on P.IdProducto = SD.IdProducto
			inner join Surtidos S on SD.IdSurtido = S.IdSurtido
			inner join Rutas R on S.IdRuta = R.IdRuta
			inner join CedisVirtuales V on R.TipoVenta = V.TipoRuta
			inner join MovimientosDetalle MOVDET on MOVDET.IdProducto = P.IdProducto
			inner join Movimientos MOV on MOV.IdMovimiento = MOVDET.IdMovimiento and MOV.IdCedis = MOVDET.IdCedis
			inner join TipoMovimiento TPMOV on MOV.IdTipoMovimiento = TPMOV.IdTipoMovimiento
			where	(cast(V.IdCedisVirtual as varchar(10)) = @IdCedisVirtual) AND (MOV.Fecha = @Fecha) AND (MOVDET.Cantidad > 0) AND 
					(MOVDET.IdProducto = PRO.IdProducto) and (TPMOV.EntradaSalida = 'S')) as MovimientosSalida,
			0 as VentasAutos,
			0 as VentasMedioMay
	from Productos PRO
	order by PRO.IdProducto
end

if @Consulta = 3		--Consulta para crear el Archivo: NLI
begin
	-- CEDIS VIRTUAL
	SELECT V.IdCedisVirtual, STRUT.IdRuta, STRUT.Fecha, TNLIQ.TipoNoLiquidacion --isnull(RUTNLIQ.IdTipoNoLiquidacion,0)
	FROM    (RutasNoLiquidacion AS RUTNLIQ RIGHT OUTER JOIN            
		StatusRutas AS STRUT ON RUTNLIQ.IdCedis = STRUT.IdCedis AND RUTNLIQ.Fecha = STRUT.Fecha AND RUTNLIQ.IdRuta = STRUT.IdRuta)
		inner join Rutas RUT ON STRUT.IdRuta = RUT.IdRuta
		inner join CedisVirtuales V on RUT.TipoVenta = V.TipoRuta
		inner join RutasNoLiquidacion RNLIQ on RNLIQ.IdRuta = RUT.IdRuta and RNLIQ.Fecha = STRUT.Fecha
		inner join TipoNoLiquidacion TNLIQ on TNLIQ.IdTipoNoLiquidacion = RNLIQ.IdTipoNoLiquidacion
		left join Surtidos SUR on SUR.IdRuta = RUT.IdRuta and SUR.Fecha = STRUT.Fecha
	WHERE   (cast(V.IdCedisVirtual as varchar(10)) = @IdCedisVirtual) AND (STRUT.Fecha = @Fecha) AND (SUR.IdSurtido IS NULL)
end

if @Consulta = 4		--Consulta para crear el Archivo: RRR
begin
	-- CEDIS VIRTUAL
	select	V.IdCedisVirtual,IdRuta,Ruta  
	from	Rutas RUT inner join CedisVirtuales V on RUT.TipoVenta = V.TipoRuta
	where	cast(V.IdCedisVirtual as varchar(10)) = @IdCedisVirtual
end

if @Consulta = 5		--Consulta para crear el Archivo: RUT
begin
	-- CEDIS VIRTUAL
	select  V.IdCedisVirtual, SUR.Fecha, SUR.IdRuta, ltrim(rtrim(SURDET.IdProducto)) as IdProducto, 
		isnull(ROUND(SUM(SURDET.VentaContado/PRO.Factor),2,1),0) as VentaContado, --*  PRO.Conversion
		isnull(ROUND(SUM(SURDET.VentaCredito/PRO.Factor ),2,1),0) as VentaCredito, --*  PRO.Conversion 
		isnull(ROUND(SUM(SURDET.VentaCredito/PRO.Factor ),2,1),0) as VentaCredito, --*  PRO.Conversion 
		isnull(ROUND(SUM(SURDET.Obsequios/PRO.Factor),2,1),0) as Obsequios, --*  PRO.Conversion 
		isnull(ROUND(SUM(SURDET.Devbuena/PRO.Factor),2,1),0) as DevolucionBuena --*  PRO.Conversion 
	from	Surtidos AS SUR INNER JOIN
		SurtidosDetalle AS SURDET ON SUR.IdCedis = SURDET.IdCedis AND SUR.IdSurtido = SURDET.IdSurtido
		inner join Rutas RUT on SUR.IdRuta = RUT.IdRuta 
		inner join CedisVirtuales V on RUT.TipoVenta = V.TipoRuta
		inner join ProductosUnidad PRO on PRO.IdProducto = SURDET.IdProducto and (PRO.IdUnidad='CAJA')
	where	(cast(V.IdCedisVirtual as varchar(10)) = @IdCedisVirtual) and (SUR.Fecha = @Fecha) 
	group by SUR.IdCedis, SUR.Fecha, SUR.IdRuta, SURDET.IdProducto, V.IdCedisVirtual
	order by SUR.IdCedis, SUR.Fecha, SUR.IdRuta, SURDET.IdProducto
end

if @Consulta = 6		--Consulta para crear el Archivo: VEN
begin
	-- CEDIS VIRTUAL
	SELECT	distinct V.IdCedisVirtual, SUR.IdRuta, RUT.Ruta, SURVEN.IdVendedor, 
			VEN.ApPaterno + ' ' + VEN.ApMaterno + ' ' + VEN.Nombre AS 'Nombre del Vendedor'
	FROM    SurtidosVendedor AS SURVEN INNER JOIN
			Vendedores AS VEN ON VEN.IdCedis = SURVEN.IdCedis AND VEN.IdVendedor = SURVEN.IdVendedor INNER JOIN
			Surtidos AS SUR ON SURVEN.IdCedis = SUR.IdCedis AND SURVEN.IdSurtido = SUR.IdSurtido AND SURVEN.Fecha = SUR.Fecha INNER JOIN
			Rutas AS RUT ON SUR.IdCedis = RUT.IdCedis AND SUR.IdRuta = RUT.IdRuta
			inner join CedisVirtuales V on RUT.TipoVenta = V.TipoRuta
	WHERE   (cast(V.IdCedisVirtual as varchar(10)) = @IdCedisVirtual) AND (SURVEN.Fecha = @Fecha)
	order by V.IdCedisVirtual, SUR.IdRuta
end

GO


--USE [Route]
--GO

--if (Select COUNT(*) from VersionBD where Tipo = 'SA' and Version ='3.8.16.1') = 0
--BEGIN
--	INSERT INTO VersionBD (Tipo, FechaHora, Version, MaximoConsecutivo, VersionSql ) 
--	VALUES('SA', GETDATE(), '3.8.16.1', 107, (SELECT  cast(SERVERPROPERTY('productversion') as varchar(50))))
--END
--ELSE
--BEGIN 
--	Update VersionBD  set MaximoConsecutivo = 107 where  Tipo = 'SA' and Version ='3.8.16.1'
--END
