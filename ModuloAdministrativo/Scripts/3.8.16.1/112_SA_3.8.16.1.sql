USE [RouteADM]

/****** Object:  StoredProcedure [dbo].[sel_ArchivoTextoConsulta]    Script Date: 11/09/2011 13:09:25 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sel_ArchivoTextoConsulta]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sel_ArchivoTextoConsulta]

/*go*/go

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
			(select	isnull(ROUND(SUM(MOVDET.Cantidad/PD.Factor),2,1),0) --ENTRADA PT
			from Productos P
			inner join ProductosUnidad PD on PD.IdProducto = P.IdProducto and (PD.IdUnidad='CAJA')
			inner join SurtidosDetalle SD on P.IdProducto = SD.IdProducto
			inner join Surtidos S on SD.IdSurtido = S.IdSurtido
			inner join Rutas R on S.IdRuta = R.IdRuta
			inner join CedisVirtuales V on R.TipoVenta = V.TipoRuta
			inner join MovimientosDetalle MOVDET on MOVDET.IdProducto = P.IdProducto
			inner join Movimientos MOV on MOV.IdMovimiento = MOVDET.IdMovimiento and MOV.IdCedis = MOVDET.IdCedis
			where	(cast(V.IdCedisVirtual as varchar(10)) = @IdCedisVirtual) AND (MOV.Fecha = @Fecha) AND (MOVDET.Cantidad > 0) and 
					(MOVDET.IdProducto = PRO.IdProducto) and (MOV.IdTipoMovimiento in (701,702,703,704))) as EntradaProductoTerminado,
			
			(select	isnull(ROUND(SUM(MOVDET.Cantidad/PD.Factor),2,1),0) --ENTRADA DEV. CLIENTE
			from Productos P
			inner join ProductosUnidad PD on PD.IdProducto = P.IdProducto and (PD.IdUnidad='CAJA')
			inner join SurtidosDetalle SD on P.IdProducto = SD.IdProducto
			inner join Surtidos S on SD.IdSurtido = S.IdSurtido
			inner join Rutas R on S.IdRuta = R.IdRuta
			inner join CedisVirtuales V on R.TipoVenta = V.TipoRuta
			inner join MovimientosDetalle MOVDET on MOVDET.IdProducto = P.IdProducto
			inner join Movimientos MOV on MOV.IdMovimiento = MOVDET.IdMovimiento and MOV.IdCedis = MOVDET.IdCedis
			where	(cast(V.IdCedisVirtual as varchar(10)) = @IdCedisVirtual) AND (MOV.Fecha = @Fecha) AND (MOVDET.Cantidad > 0) and 
					(MOVDET.IdProducto = PRO.IdProducto) and (MOV.IdTipoMovimiento in (210))) as EntradaDevolucionesClientes,
			
			(select	isnull(ROUND(SUM(MOVDET.Cantidad/PD.Factor),2,1),0) --OTRAS ENTRADAS 
			from Productos P 
			inner join ProductosUnidad PD on PD.IdProducto = P.IdProducto and (PD.IdUnidad='CAJA')
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
			
			(select	isnull(ROUND(SUM(VENDET.Cantidad/PD.Factor),2,1),0) --VENTAS CONTADO
			from Productos P 
			inner join ProductosUnidad PD on PD.IdProducto = P.IdProducto and (PD.IdUnidad='CAJA')
			inner join VentasDetalle VENDET on P.IdProducto = VENDET.IdProducto
			inner join Ventas VEN ON VENDET.IdCedis = VEN.IdCedis AND
			VENDET.IdSurtido = VEN.IdSurtido AND VENDET.IdTipoVenta = VEN.IdTipoVenta AND 
			VENDET.Folio = VEN.Folio AND VENDET.Serie = VEN.Serie
			
			left join FacturasRP FRP on VEN.IdCedis=FRP.IdCedis and VEN.IdSurtido=FRP.IdSurtido and FRP.Folio=VEN.Folio and FRP.IdTipoVenta=VEN.IdTipoVenta 
			
			inner join Surtidos S on VEN.IdSurtido = S.IdSurtido
			inner join Rutas R on S.IdRuta = R.IdRuta
			inner join CedisVirtuales V on R.TipoVenta = V.TipoRuta
			where	(cast(V.IdCedisVirtual as varchar(10)) = @IdCedisVirtual) AND (VEN.Fecha = @Fecha) and VEN.IdTipoVenta = 1 and 
					VENDET.IdProducto = PRO.IdProducto
					
					and (FRP.FolioFactura  ='' or FRP.FolioFactura is null)
					
					) as Ventascontado,
			
			(select	isnull(ROUND(SUM(VENDET.Cantidad/PD.Factor),2,1),0)  --VENTAS CREDITO
			from Productos P 
			inner join ProductosUnidad PD on PD.IdProducto = P.IdProducto and (PD.IdUnidad='CAJA')
			inner join VentasDetalle VENDET on P.IdProducto = VENDET.IdProducto
			inner join Ventas VEN ON VENDET.IdCedis = VEN.IdCedis AND 
			VENDET.IdSurtido = VEN.IdSurtido AND VENDET.IdTipoVenta = VEN.IdTipoVenta AND 
			VENDET.Folio = VEN.Folio AND VENDET.Serie = VEN.Serie
			
			left join FacturasRP FRP on VEN.IdCedis=FRP.IdCedis and VEN.IdSurtido=FRP.IdSurtido and FRP.Folio=VEN.Folio and FRP.IdTipoVenta=VEN.IdTipoVenta 
			
			
			inner join Surtidos S on VEN.IdSurtido = S.IdSurtido
			inner join Rutas R on S.IdRuta = R.IdRuta
			inner join CedisVirtuales V on R.TipoVenta = V.TipoRuta
			where	(cast(V.IdCedisVirtual as varchar(10)) = @IdCedisVirtual) AND (VEN.Fecha = @Fecha) and VEN.IdTipoVenta = 2 and 
					VENDET.IdProducto = PRO.IdProducto
					
					and (FRP.FolioFactura  ='' or FRP.FolioFactura is null)
					
					) as VentasCredito,
			
			(select isnull(ROUND(SUM(SURDET.DevMala/PD.Factor),2,1),0) --DEV. MALAS
			from	Surtidos AS SUR 
					INNER JOIN SurtidosDetalle AS SURDET ON SUR.IdCedis = SURDET.IdCedis AND SUR.IdSurtido = SURDET.IdSurtido
					inner join ProductosUnidad PD on PD.IdProducto = SURDET.IdProducto and (PD.IdUnidad='CAJA')
					inner join Rutas R on SUR.IdRuta = R.IdRuta
					inner join CedisVirtuales V on R.TipoVenta = V.TipoRuta
			where	(cast(V.IdCedisVirtual as varchar(10)) = @IdCedisVirtual) and (SUR.Fecha = @Fecha) and 
					SURDET.IdProducto = PRO.IdProducto ) as DevolucionesMalas,
			
			(select	isnull(ROUND(SUM(MOVDET.Cantidad/PD.Factor),2,1),0) --MOVIMIENTOS SALIDA
			from Productos P 
			inner join ProductosUnidad PD on PD.IdProducto = P.IdProducto and (PD.IdUnidad='CAJA')
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
		isnull(ROUND(SUM(SURDET.VentaContado/PRO.Factor),2,1),0)- sum(isnull(case when FRP.IdTipoVenta=1 then  FRP.Cantidad/PRO.Factor else 0 end ,0)) as VentaContado, --*  PRO.Conversion
		isnull(ROUND(SUM(SURDET.VentaCredito/PRO.Factor ),2,1),0)-sum(isnull(case when FRP.IdTipoVenta=2 then  FRP.Cantidad/PRO.Factor else 0 end ,0)) as VentaCredito, --*  PRO.Conversion 
		isnull(ROUND(SUM(SURDET.VentaCredito/PRO.Factor ),2,1),0)-sum(isnull(case when FRP.IdTipoVenta=2 then  FRP.Cantidad/PRO.Factor else 0 end ,0)) as VentaCredito, --*  PRO.Conversion 
		isnull(ROUND(SUM(SURDET.Obsequios/PRO.Factor),2,1),0) as Obsequios, --*  PRO.Conversion 
		isnull(ROUND(SUM(SURDET.Devbuena/PRO.Factor),2,1),0) as DevolucionBuena --*  PRO.Conversion 
	from	Surtidos AS SUR INNER JOIN
		SurtidosDetalle AS SURDET ON SUR.IdCedis = SURDET.IdCedis AND SUR.IdSurtido = SURDET.IdSurtido
		inner join Rutas RUT on SUR.IdRuta = RUT.IdRuta 
		inner join CedisVirtuales V on RUT.TipoVenta = V.TipoRuta
		inner join ProductosUnidad PRO on PRO.IdProducto = SURDET.IdProducto and (PRO.IdUnidad='CAJA')
		left join 
					(
							Select IdProducto,FRP.IdTipoVenta,Cantidad, SUR.IdRuta  from FacturasRP FRP
							inner join VentasDetalle VD on FRP.Folio=VD.Folio and FRP.IdCedis=VD.IdCedis
							and FRP.IdSurtido=VD.IdSurtido and FRP.IdTipoVenta=VD.IdTipoVenta
								inner join Surtidos SUR on SUR.IdSurtido=FRP.IdSurtido
								inner join Rutas RUT on SUR.IdRuta = RUT.IdRuta 
								inner join CedisVirtuales V on RUT.TipoVenta = V.TipoRuta
								where	(cast(V.IdCedisVirtual as varchar(10)) = @IdCedisVirtual) and (SUR.Fecha = @Fecha) 
							and FRP.FolioFactura<>''
							
					) as FRP on FRP.IdProducto=SURDET.IdProducto and FRP.IdRuta=RUT.IdRuta
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
/*go*/go

USE [Route]
/*go*/go

if (Select COUNT(*) from VersionBD where Tipo = 'SA' and Version ='3.8.16.1') = 0
BEGIN
	INSERT INTO VersionBD (Tipo, FechaHora, Version, MaximoConsecutivo, VersionSql ) 
	VALUES('SA', GETDATE(), '3.8.16.1', 112, (SELECT  cast(SERVERPROPERTY('productversion') as varchar(50))))
END
ELSE
BEGIN 
	Update VersionBD  set MaximoConsecutivo = 112 where  Tipo = 'SA' and Version ='3.8.16.1'
END
