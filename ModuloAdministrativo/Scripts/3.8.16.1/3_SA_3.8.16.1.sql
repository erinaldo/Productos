USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[sel_CedisVirtuales]    Script Date: 07/25/2011 09:47:01 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sel_CedisVirtuales]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sel_CedisVirtuales]
GO

USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[sel_CedisVirtuales]    Script Date: 07/25/2011 09:47:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




CREATE PROCEDURE [dbo].[sel_CedisVirtuales]
@IdCedis as bigint
AS
BEGIN
	
	SET NOCOUNT ON;

    SELECT * FROM CedisVirtuales WHERE IdCedis = @IdCedis
END



GO

USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[up_CedisVirtuales]    Script Date: 07/25/2011 09:46:41 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[up_CedisVirtuales]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[up_CedisVirtuales]
GO

USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[up_CedisVirtuales]    Script Date: 07/25/2011 09:46:41 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[up_CedisVirtuales]
@IdCedisReal as bigint
AS
BEGIN

	SET NOCOUNT ON;

	declare @IdCedis as bigint, @TipoVenta as varchar(20), @IdCedisVirtual as bigint, @Existe as int

	declare InsertaCedis cursor for
	select IdCedis,TipoVenta from Rutas where IdCedis = @IdCedisReal group by IdCedis,TipoVenta

	open InsertaCedis
	fetch next from InsertaCedis into @IdCedis, @TipoVenta
	while(@@fetch_status=0)
	begin
		--checar si ya existe el cedis y tipo de ruta
		select @Existe = COUNT(*) from cedisvirtuales where IdCedis = @IdCedis and TipoRuta = @TipoVenta
		if @Existe = 0
		begin
			select @IdCedisVirtual = COUNT(*)+1 from CedisVirtuales
			insert into CedisVirtuales values(@IdCedis,@TipoVenta,@IdCedisVirtual)
		end
		fetch next from InsertaCedis into @IdCedis, @TipoVenta
	end
	close InsertaCedis
	deallocate InsertaCedis
	
END


GO

USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[sel_ArchivoTextoConsulta]    Script Date: 07/25/2011 13:28:41 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sel_ArchivoTextoConsulta]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sel_ArchivoTextoConsulta]
GO

USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[sel_ArchivoTextoConsulta]    Script Date: 07/25/2011 13:28:41 ******/
SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER OFF
GO




CREATE PROCEDURE [dbo].[sel_ArchivoTextoConsulta] 
@IdCedis as bigint,
@Fecha as datetime,
@Consulta as int
AS

if @Consulta = 1		--Consulta para crear el Archivo: ENC
begin
	-- CEDIS VIRTUAL
	select V.IdCedisVirtual, count(STRUT.IdRuta) as TotalRutasFecha, STRUT.Fecha, STRUT.Fecha
	from StatusRutas STRUT inner join Rutas RUT on RUT.IdRuta = STRUT.IdRuta and RUT.IdCedis = STRUT.IdCedis
	inner join CedisVirtuales V on RUT.TipoVenta = V.TipoRuta
	where V.IdCedisVirtual = @IdCedis and STRUT.Fecha = '20110601' and RUT.Status = 'A'
	group by V.IdCedisVirtual, STRUT.Fecha, STRUT.Fecha, RUT.Status , RUT.TipoVenta
	/* -- CEDIS REAL
	select STRUT.IdCedis, count(STRUT.IdRuta) as TotalRutasFecha, STRUT.Fecha, STRUT.Fecha
	from StatusRutas STRUT inner join Rutas RUT on RUT.IdRuta = STRUT.IdRuta and RUT.IdCedis = STRUT.IdCedis
	where STRUT.IdCedis = @IdCedis and STRUT.Fecha = @Fecha and RUT.Status = 'A'
	group by STRUT.IdCedis, STRUT.Fecha, STRUT.Fecha, RUT.Status 
	*/
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
			where	(V.IdCedisVirtual = @IdCedis) AND (MOV.Fecha = @Fecha) AND (MOVDET.Cantidad > 0) and 
					(MOVDET.IdProducto = PRO.IdProducto) and (MOV.IdTipoMovimiento in (701,702,703,704))) as EntradaProductoTerminado,
			
			(select	isnull(SUM(MOVDET.Cantidad),0) --ENTRADA DEV. CLIENTE
			from Productos P
			inner join SurtidosDetalle SD on P.IdProducto = SD.IdProducto
			inner join Surtidos S on SD.IdSurtido = S.IdSurtido
			inner join Rutas R on S.IdRuta = R.IdRuta
			inner join CedisVirtuales V on R.TipoVenta = V.TipoRuta
			inner join MovimientosDetalle MOVDET on MOVDET.IdProducto = P.IdProducto
			inner join Movimientos MOV on MOV.IdMovimiento = MOVDET.IdMovimiento and MOV.IdCedis = MOVDET.IdCedis
			where	(V.IdCedisVirtual = @IdCedis) AND (MOV.Fecha = @Fecha) AND (MOVDET.Cantidad > 0) and 
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
			where	(V.IdCedisVirtual = @IdCedis) AND (MOV.Fecha = @Fecha) AND (MOVDET.Cantidad > 0) AND 
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
			where	(V.IdCedisVirtual = @IdCedis) AND (VEN.Fecha = @Fecha) and VEN.IdTipoVenta = 2 and 
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
			where	(V.IdCedisVirtual = @IdCedis) AND (VEN.Fecha = @Fecha) and VEN.IdTipoVenta = 1 and 
					VENDET.IdProducto = PRO.IdProducto) as VentasCredito,
			
			(select	isnull(SUM(SURDET.DevMala),0) --DEV. MALAS
			from	Surtidos AS SUR INNER JOIN
					SurtidosDetalle AS SURDET ON SUR.IdCedis = SURDET.IdCedis AND SUR.IdSurtido = SURDET.IdSurtido
					inner join Rutas R on SUR.IdRuta = R.IdRuta
					inner join CedisVirtuales V on R.TipoVenta = V.TipoRuta
			where	(V.IdCedisVirtual = @IdCedis) and (SUR.Fecha = @Fecha) and 
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
			where	(V.IdCedisVirtual = @IdCedis) AND (MOV.Fecha = @Fecha) AND (MOVDET.Cantidad > 0) AND 
					(MOVDET.IdProducto = PRO.IdProducto) and (TPMOV.EntradaSalida = 'S')) as MovimientosSalida,
			0 as VentasAutos,
			0 as VentasMedioMay
	from Productos PRO
	order by PRO.IdProducto
	/* -- CEDIS REAL
	Select IdProducto, 
			(select	isnull(SUM(MOVDET.Cantidad),0) --*  PRO.Conversion 
			from	MovimientosDetalle AS MOVDET INNER JOIN Movimientos AS MOV ON MOVDET.IdCedis = MOV.IdCedis AND 
					MOVDET.IdMovimiento = MOV.IdMovimiento
			where	(MOVDET.IdCedis = @IdCedis) AND (MOV.Fecha = @Fecha) AND (MOVDET.Cantidad > 0) and 
					(MOVDET.IdProducto = PRO.IdProducto) and (MOV.IdTipoMovimiento in (701,702,703,704))) as EntradaProductoTerminado,
			(select	isnull(SUM(MOVDET.Cantidad),0) --*  PRO.Conversion 
			from	MovimientosDetalle AS MOVDET INNER JOIN Movimientos AS MOV ON MOVDET.IdCedis = MOV.IdCedis AND 
					MOVDET.IdMovimiento = MOV.IdMovimiento
			where	(MOVDET.IdCedis = @IdCedis) AND (MOV.Fecha = @Fecha) AND (MOVDET.Cantidad > 0) and 
					(MOVDET.IdProducto = PRO.IdProducto) and (MOV.IdTipoMovimiento in (210))) as EntradaDevolucionesClientes,
			(select	ISNULL(SUM(MOVDET.Cantidad), 0) --*  PRO.Conversion 
			from	MovimientosDetalle AS MOVDET INNER JOIN
					Movimientos AS MOV ON MOVDET.IdCedis = MOV.IdCedis AND MOVDET.IdMovimiento = MOV.IdMovimiento INNER JOIN
					TipoMovimiento AS TPMOV ON MOV.IdCedis = TPMOV.IdCedis AND MOV.IdTipoMovimiento = TPMOV.IdTipoMovimiento
			where	(MOVDET.IdCedis = @IdCedis) AND (MOV.Fecha = @Fecha) AND (MOVDET.Cantidad > 0) AND 
					(MOVDET.IdProducto = PRO.IdProducto) AND (MOV.IdTipoMovimiento not in (210, 701, 702, 703, 704)) and
					(TPMOV.EntradaSalida = 'E')) as OtrasEntradas,
			(select	isnull(SUM(VENDET.Cantidad),0)  --*  PRO.Conversion 
			from	VentasDetalle VENDET INNER JOIN Ventas VEN ON VENDET.IdCedis = VEN.IdCedis AND 
					VENDET.IdSurtido = VEN.IdSurtido AND VENDET.IdTipoVenta = VEN.IdTipoVenta AND 
					VENDET.Folio = VEN.Folio AND VENDET.Serie = VEN.Serie
			where	(VEN.IdCedis = @IdCedis) AND (VEN.Fecha = @Fecha) and VEN.IdTipoVenta = 2 and 
					VENDET.IdProducto = PRO.IdProducto) as Ventascontado,
			(select	isnull(SUM(VENDET.Cantidad),0)  --*  PRO.Conversion 
			from	VentasDetalle VENDET INNER JOIN Ventas VEN ON VENDET.IdCedis = VEN.IdCedis AND 
					VENDET.IdSurtido = VEN.IdSurtido AND VENDET.IdTipoVenta = VEN.IdTipoVenta AND 
					VENDET.Folio = VEN.Folio AND VENDET.Serie = VEN.Serie
			where	(VEN.IdCedis = @IdCedis) AND (VEN.Fecha = @Fecha) and VEN.IdTipoVenta = 1 and 
					VENDET.IdProducto = PRO.IdProducto) as VentasCredito,
			(select	isnull(SUM(SURDET.DevMala),0) --*  PRO.Conversion 
			from	Surtidos AS SUR INNER JOIN
					SurtidosDetalle AS SURDET ON SUR.IdCedis = SURDET.IdCedis AND SUR.IdSurtido = SURDET.IdSurtido
			where	(SUR.IdCedis = @IdCedis) and (SUR.Fecha = @Fecha) and 
					SURDET.IdProducto = PRO.IdProducto ) as DevolucionesMalas,
			(select	ISNULL(SUM(MOVDET.Cantidad), 0) --*  PRO.Conversion 
			from	MovimientosDetalle AS MOVDET INNER JOIN
					Movimientos AS MOV ON MOVDET.IdCedis = MOV.IdCedis AND MOVDET.IdMovimiento = MOV.IdMovimiento INNER JOIN
					TipoMovimiento AS TPMOV ON MOV.IdCedis = TPMOV.IdCedis AND MOV.IdTipoMovimiento = TPMOV.IdTipoMovimiento
			where	(MOVDET.IdCedis = @IdCedis) AND (MOV.Fecha = @Fecha) AND (MOVDET.Cantidad > 0) AND 
					(MOVDET.IdProducto = PRO.IdProducto) and (TPMOV.EntradaSalida = 'S')) as MovimientosSalida,
			0 as VentasAutos,
			0 as VentasMedioMay
	from Productos PRO
	order by PRO.IdProducto
	*/
end

if @Consulta = 3		--Consulta para crear el Archivo: NLI
begin
	-- CEDIS VIRTUAL
	SELECT V.IdCedisVirtual, STRUT.IdRuta, STRUT.Fecha, isnull(RUTNLIQ.IdTipoNoLiquidacion,0)
	FROM    (RutasNoLiquidacion AS RUTNLIQ RIGHT OUTER JOIN            
			StatusRutas AS STRUT ON RUTNLIQ.IdCedis = STRUT.IdCedis AND RUTNLIQ.Fecha = STRUT.Fecha AND RUTNLIQ.IdRuta = STRUT.IdRuta)
			inner join Rutas RUT ON STRUT.IdRuta = RUT.IdRuta
			inner join CedisVirtuales V on RUT.TipoVenta = V.TipoRuta
	WHERE   (V.IdCedisVirtual = @IdCedis) AND (STRUT.Fecha = @Fecha) AND (STRUT.Status = 'N')
	/* -- CEDIS REAL
	SELECT	STRUT.IdCedis, STRUT.IdRuta, STRUT.Fecha, isnull(RUTNLIQ.IdTipoNoLiquidacion,0)
	FROM    RutasNoLiquidacion AS RUTNLIQ RIGHT OUTER JOIN            
			StatusRutas AS STRUT ON RUTNLIQ.IdCedis = STRUT.IdCedis AND RUTNLIQ.Fecha = STRUT.Fecha AND RUTNLIQ.IdRuta = STRUT.IdRuta
	WHERE   (STRUT.IdCedis = @IdCedis) AND (STRUT.Fecha = @Fecha) AND (STRUT.Status = 'N')
	*/
end

if @Consulta = 4		--Consulta para crear el Archivo: RRR
begin
	-- CEDIS VIRTUAL
	select	V.IdCedisVirtual,IdRuta,Ruta  
	from	Rutas RUT inner join CedisVirtuales V on RUT.TipoVenta = V.TipoRuta
	where	V.IdCedisVirtual = @IdCedis
	/* -- CEDIS REAL
	select	IdCedis,IdRuta,Ruta  
	from	Rutas 
	where	IdCedis = @IdCedis
	*/
end

if @Consulta = 5		--Consulta para crear el Archivo: RUT
begin
	-- CEDIS VIRTUAL
	select  V.IdCedisVirtual, SUR.Fecha, SUR.IdRuta, ltrim(rtrim(SURDET.IdProducto)) as IdProducto, 
			isnull(SUM(SURDET.VentaContado),0) as VentaContado, --*  PRO.Conversion
			isnull(SUM(SURDET.VentaCredito ),0) as VentaCredito, --*  PRO.Conversion 
			isnull(SUM(SURDET.VentaCredito ),0) as VentaCredito, --*  PRO.Conversion 
			isnull(SUM(SURDET.Obsequios),0) as Obsequios, --*  PRO.Conversion 
			isnull(SUM(SURDET.Devbuena),0) as DevolucionBuena --*  PRO.Conversion 
	from	Surtidos AS SUR INNER JOIN
			SurtidosDetalle AS SURDET ON SUR.IdCedis = SURDET.IdCedis AND SUR.IdSurtido = SURDET.IdSurtido
			inner join Rutas RUT on SUR.IdRuta = RUT.IdRuta 
			inner join CedisVirtuales V on RUT.TipoVenta = V.TipoRuta
	where	(V.IdCedisVirtual = @IdCedis) and (SUR.Fecha = @Fecha) 
	group by SUR.IdCedis, SUR.Fecha, SUR.IdRuta, SURDET.IdProducto, V.IdCedisVirtual
	order by SUR.IdCedis, SUR.Fecha, SUR.IdRuta, SURDET.IdProducto
	
	/* -- CEDIS REAL
	select	SUR.IdCedis, SUR.Fecha, SUR.IdRuta, ltrim(rtrim(SURDET.IdProducto)) as IdProducto, 
			isnull(SUM(SURDET.VentaContado),0) as VentaContado, --*  PRO.Conversion
			isnull(SUM(SURDET.VentaCredito ),0) as VentaCredito, --*  PRO.Conversion 
			isnull(SUM(SURDET.VentaCredito ),0) as VentaCredito, --*  PRO.Conversion 
			isnull(SUM(SURDET.Obsequios),0) as Obsequios, --*  PRO.Conversion 
			isnull(SUM(SURDET.Devbuena),0) as DevolucionBuena --*  PRO.Conversion 
	from	Surtidos AS SUR INNER JOIN
			SurtidosDetalle AS SURDET ON SUR.IdCedis = SURDET.IdCedis AND SUR.IdSurtido = SURDET.IdSurtido
	where	(SUR.IdCedis = @IdCedis) and (SUR.Fecha = @Fecha) 
	group by SUR.IdCedis, SUR.Fecha, SUR.IdRuta, SURDET.IdProducto
	order by SUR.IdCedis, SUR.Fecha, SUR.IdRuta, SURDET.IdProducto
	*/
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
	WHERE   (V.IdCedisVirtual = @IdCedis) AND (SURVEN.Fecha = @Fecha)
	order by V.IdCedisVirtual, SUR.IdRuta
	/*-- CEDIS REAL
	SELECT	distinct SURVEN.IdCedis, SUR.IdRuta, RUT.Ruta, SURVEN.IdVendedor, 
			VEN.ApPaterno + ' ' + VEN.ApMaterno + ' ' + VEN.Nombre AS 'Nombre del Vendedor'
	FROM    SurtidosVendedor AS SURVEN INNER JOIN
			Vendedores AS VEN ON VEN.IdCedis = SURVEN.IdCedis AND VEN.IdVendedor = SURVEN.IdVendedor INNER JOIN
			Surtidos AS SUR ON SURVEN.IdCedis = SUR.IdCedis AND SURVEN.IdSurtido = SUR.IdSurtido AND SURVEN.Fecha = SUR.Fecha INNER JOIN
			Rutas AS RUT ON SUR.IdCedis = RUT.IdCedis AND SUR.IdRuta = RUT.IdRuta
	WHERE   (SURVEN.IdCedis = @IdCedis) AND (SURVEN.Fecha = @Fecha)
	order by SURVEN.IdCedis, SUR.IdRuta
	*/
end





GO


USE [Route]
GO

if (Select COUNT(*) from VersionBD where Tipo = 'SA' and Version ='3.8.16.1') = 0
BEGIN
	INSERT INTO VersionBD (Tipo, FechaHora, Version, MaximoConsecutivo, VersionSql ) 
	VALUES('SA', GETDATE(), '3.8.16.1', 3, (SELECT  cast(SERVERPROPERTY('productversion') as varchar(50))))
END
ELSE
BEGIN 
	Update VersionBD  set MaximoConsecutivo = 3 where  Tipo = 'SA' and Version ='3.8.16.1'
END
GO