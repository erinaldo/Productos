USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[up_ActualizaKardex]    Script Date: 07/27/2011 10:41:11 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[up_ActualizaKardex]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[up_ActualizaKardex]
GO

USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[up_ActualizaKardex]    Script Date: 07/27/2011 10:41:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER OFF
GO





CREATE PROCEDURE [dbo].[up_ActualizaKardex] 
@IdCedis as bigint, 
@Fecha as datetime,
@IdSurtido as bigint,
@Opc as int

AS

--set @IdCedis = 1 
--set @Fecha = '07/05/2011'
--set @IdSurtido = 0
--set @Opc = 1

if @Opc = 1 -- actualiza todo
begin

	declare @IdSurtidoInicial as bigint, @IdSurtidoFinal as bigint
	
	set @IdSurtidoInicial = (select min(IdSurtido) from Ventas where IdCedis = @IdCedis and Fecha = @Fecha )
	set @IdSurtidoFinal = (select max(IdSurtido) from Ventas where IdCedis = @IdCedis and Fecha = @Fecha )
	
	delete from ventasdetalle 
	where IdCedis = @IdCedis and idsurtido not in ( select idsurtido from ventas where VentasDetalle.IdCedis = Ventas.IdCedis and VentasDetalle.IdSurtido = Ventas.IdSurtido and 
	VentasDetalle.IdTipoVenta = Ventas.IdTipoVenta and VentasDetalle.Folio = Ventas.Folio and ventas.IdSurtido between @IdSurtidoInicial and @IdSurtidoFinal )
	and IdSurtido between @IdSurtidoInicial and @IdSurtidoFinal
	
	update surtidosdetalle set
		ventacontado = isnull( ( select FN_KdxVentasFechaG.VentaContado from  FN_KdxVentasFechaG (@IdCedis, @Fecha) where FN_KdxVentasFechaG.idcedis = SurtidosDetalle.idcedis 
		and FN_KdxVentasFechaG.idproducto = SurtidosDetalle.idproducto and FN_KdxVentasFechaG.idsurtido = SurtidosDetalle.idsurtido), 0),
		ventacredito = isnull( ( select FN_KdxVentasFechaG.VentaCredito from  FN_KdxVentasFechaG (@IdCedis, @Fecha) where FN_KdxVentasFechaG.idcedis = SurtidosDetalle.idcedis 
		and FN_KdxVentasFechaG.idproducto = SurtidosDetalle.idproducto and FN_KdxVentasFechaG.idsurtido = SurtidosDetalle.idsurtido), 0)
	from SurtidosDetalle
	where SurtidosDetalle.idcedis = @IdCedis and SurtidosDetalle.fecha = @Fecha 
	
	update InventarioKardex set surtido=0, devbuena=0, devmala=0, obsequios=0, ventacontado=0, ventacredito=0 where IdCedis = @IdCedis and Fecha = @Fecha 
	
	update InventarioKardex set 
		entradas = isnull( (select sum(Entradas) 
		from FN_KardexEntradas ( @IdCedis, @Fecha )
		where FN_KardexEntradas.IdCedis = InventarioKardex.IdCedis and FN_KardexEntradas.Fecha = InventarioKardex.Fecha and FN_KardexEntradas.IdProducto = InventarioKardex.IdProducto), 0),
		salidas = isnull( (select sum(Salidas) 
		from FN_KardexSalidas ( @IdCedis, @Fecha )
		where FN_KardexSalidas.IdCedis = InventarioKardex.IdCedis and FN_KardexSalidas.Fecha = InventarioKardex.Fecha and FN_KardexSalidas.IdProducto = InventarioKardex.IdProducto), 0), 
		
		surtido = FN_KdxFecha.Surtido, 
		devbuena = FN_KdxFecha.devbuena,
		devmala = FN_KdxFecha.devmala,
		obsequios = FN_KdxFecha.obsequios,
		ventacontado = FN_KdxFecha.ventacontado,
		ventacredito = FN_KdxFecha.ventacredito,
		Consignacion = FN_KdxFecha.Consignacion,
		Recuperacion = FN_KdxFecha.Recuperacion
	from InventarioKardex, FN_KdxFecha (@IdCedis, @Fecha)
	where InventarioKardex.IdCedis = @IdCedis and InventarioKardex.Fecha = @Fecha and FN_KdxFecha.idcedis = InventarioKardex.idcedis 
	and FN_KdxFecha.idproducto = InventarioKardex.idproducto  and FN_KdxFecha.fecha = InventarioKardex.fecha
	
	
	delete  from inventariokardex where idproducto not in ( select idproducto from productos )  and idcedis = @IdCedis and Fecha = @Fecha
	delete  from inventarioinicial where idproducto not in ( select idproducto from productos ) and idcedis = @IdCedis and mes = month(@Fecha)
	delete  from inventariofisico where idproducto not in ( select idproducto from productos ) and idcedis = @IdCedis and Fecha = @Fecha
	delete  from preciosdetalle where idproducto not in ( select idproducto from productos )  -- or precio <= 0
	delete  from movimientosdetalle where idproducto not in ( select idproducto from productos ) 
	delete  from surtidosdetalle where idproducto not in ( select idproducto from productos ) 
	delete  from ventasdetalle where idproducto not in ( select idproducto from productos ) 
	delete  from surtidosmerma where idproducto not in ( select idproducto from productos ) 

end

if @Opc = 2 -- actualiza surtidos Y KARDEX detalle a partir de las ventas
begin

	delete 
	from SurtidosDetalle where Surtido = 0 and DevBuena = 0 and DevMala = 0 
	and VentaContado = 0 and VentaCredito = 0 and Obsequios = 0
	and IdCedis = @IdCedis and IdSurtido = @IdSurtido 

	insert into SurtidosDetalle 
	select VentasDetalle.IdCedis, VentasDetalle.IdSurtido, VentasDetalle.IdProducto, @Fecha, 0,0,0,0,0,0,0,0, AVG(VentasDetalle.Precio), AVG(VentasDetalle.Iva) 
	from VentasDetalle 
	left outer join PreciosDetalle on PreciosDetalle.IdProducto = VentasDetalle.IdProducto and IdLista in (
		select top 1 PreciosLista.IdLista from PreciosLista, PreciosListaCedis where PreciosLista.IdLista = PreciosListaCedis.IdLista 
			and PreciosListaCedis.IdCedis = @IdCedis and PreciosLista.TipoLista = 'BA')
	left outer join SurtidosDetalle on SurtidosDetalle.IdCedis = VentasDetalle.IdCedis 
		and SurtidosDetalle.IdSurtido = VentasDetalle.IdSurtido and SurtidosDetalle.IdProducto  = VentasDetalle.IdProducto 
	where VentasDetalle.IdCedis = @IdCedis and VentasDetalle.IdSurtido = @IdSurtido and SurtidosDetalle.IdProducto is null
	group by VentasDetalle.IdCedis, VentasDetalle.IdSurtido, VentasDetalle.IdProducto

	delete from ventasdetalle 
	where IdCedis = @IdCedis and idsurtido not in ( select idsurtido from ventas where VentasDetalle.IdCedis = Ventas.IdCedis and VentasDetalle.IdSurtido = Ventas.IdSurtido and 
	VentasDetalle.IdTipoVenta = Ventas.IdTipoVenta and VentasDetalle.Folio = Ventas.Folio and ventas.IdSurtido = @IdSurtido )
	and IdSurtido = @IdSurtido

	update SurtidosDetalle set  
		ventacontado = isnull( ( select FN_KdxVentasSurtidoG.VentaContado from FN_KdxVentasSurtidoG ( @IdCedis, @IdSurtido ) where FN_KdxVentasSurtidoG.idcedis = SurtidosDetalle.idcedis and FN_KdxVentasSurtidoG.idsurtido = SurtidosDetalle.idsurtido
			and FN_KdxVentasSurtidoG.idproducto = SurtidosDetalle.idproducto ), 0),
		ventacredito = isnull( ( select FN_KdxVentasSurtidoG.VentaCredito from FN_KdxVentasSurtidoG ( @IdCedis, @IdSurtido ) where FN_KdxVentasSurtidoG.idcedis = SurtidosDetalle.idcedis and FN_KdxVentasSurtidoG.idsurtido = SurtidosDetalle.idsurtido
			and FN_KdxVentasSurtidoG.idproducto = SurtidosDetalle.idproducto ), 0)
	from SurtidosDetalle
	where SurtidosDetalle.idcedis = @IdCedis and SurtidosDetalle.fecha = @Fecha and SurtidosDetalle.IdSurtido = @IdSurtido

end


if @Opc = 3 -- actualiza entradas salidas
begin
        update inventariokardex set 
	        entradas = isnull( (select sum(Entradas) 
	        from FN_KardexEntradas ( @IdCedis, @Fecha )
	        where FN_KardexEntradas.IdCedis = InventarioKardex.IdCedis and FN_KardexEntradas.Fecha = InventarioKardex.Fecha and FN_KardexEntradas.IdProducto = InventarioKardex.IdProducto), 0),
	        salidas = isnull( (select sum(Salidas) 
	        from FN_KardexSalidas ( @IdCedis, @Fecha )
	        where FN_KardexSalidas.IdCedis = InventarioKardex.IdCedis and FN_KardexSalidas.Fecha = InventarioKardex.Fecha and FN_KardexSalidas.IdProducto = InventarioKardex.IdProducto), 0)
        where idcedis = @IdCedis and fecha = @Fecha
end

if @Opc = 4 -- actualiza surtidos detalle a partir de las ventas
begin

	/*declare @Route as int
	set @Route = isnull( ( select Route from Configuracion where IdCedis in ( select IdCedis from Inserted ) ), 0 )

	if @Route = 1 exec up_ActualizaCambios @IdCedis, @IdSurtido, @Fecha*/

	delete 
	from SurtidosDetalle where Surtido = 0 and DevBuena = 0 and DevMala = 0 and VentaContado = 0 
	and VentaCredito = 0 and Obsequios = 0 and Consignacion = 0 and Recuperacion = 0
	and IdCedis = @IdCedis and IdSurtido = @IdSurtido 

	insert into SurtidosDetalle 
	select VentasDetalle.IdCedis, VentasDetalle.IdSurtido, VentasDetalle.IdProducto, @Fecha, 0,0,0,0,0,0,0,0, AVG(VentasDetalle.Precio), AVG(VentasDetalle.Iva) 
	from VentasDetalle 
	left outer join PreciosDetalle on PreciosDetalle.IdProducto = VentasDetalle.IdProducto and IdLista in (
		select top 1 PreciosLista.IdLista from PreciosLista, PreciosListaCedis where PreciosLista.IdLista = PreciosListaCedis.IdLista 
			and PreciosListaCedis.IdCedis = @IdCedis and PreciosLista.TipoLista = 'BA')
	left outer join SurtidosDetalle on SurtidosDetalle.IdCedis = VentasDetalle.IdCedis 
		and SurtidosDetalle.IdSurtido = VentasDetalle.IdSurtido and SurtidosDetalle.IdProducto  = VentasDetalle.IdProducto 
	where VentasDetalle.IdCedis = @IdCedis and VentasDetalle.IdSurtido = @IdSurtido and SurtidosDetalle.IdProducto is null
	group by VentasDetalle.IdCedis, VentasDetalle.IdSurtido, VentasDetalle.IdProducto

	update SurtidosDetalle set  
		ventacontado = isnull( ( select FN_KdxVentasSurtidoG.VentaContado from FN_KdxVentasSurtidoG ( @IdCedis, @IdSurtido ) where FN_KdxVentasSurtidoG.idcedis = SurtidosDetalle.idcedis and FN_KdxVentasSurtidoG.idsurtido = SurtidosDetalle.idsurtido
			and FN_KdxVentasSurtidoG.idproducto = SurtidosDetalle.idproducto ), 0),
		ventacredito = isnull( ( select FN_KdxVentasSurtidoG.VentaCredito from FN_KdxVentasSurtidoG ( @IdCedis, @IdSurtido ) where FN_KdxVentasSurtidoG.idcedis = SurtidosDetalle.idcedis and FN_KdxVentasSurtidoG.idsurtido = SurtidosDetalle.idsurtido
			and FN_KdxVentasSurtidoG.idproducto = SurtidosDetalle.idproducto ), 0)
	from SurtidosDetalle
	where SurtidosDetalle.idcedis = @IdCedis and SurtidosDetalle.fecha = @Fecha and SurtidosDetalle.IdSurtido = @IdSurtido

	update InventarioKardex set surtido=0, devbuena=0, devmala=0, obsequios=0, ventacontado=0, ventacredito=0, Consignacion = 0, Recuperacion = 0 
	where IdCedis = @IdCedis and Fecha = @Fecha 
	
    update InventarioKardex set         
		surtido = FN_KdxFecha.Surtido, 
		devbuena = FN_KdxFecha.devbuena,
		devmala = FN_KdxFecha.devmala,
		obsequios = FN_KdxFecha.obsequios,
		ventacontado = FN_KdxFecha.ventacontado,
		ventacredito = FN_KdxFecha.ventacredito,
		Consignacion = FN_KdxFecha.Consignacion,
		Recuperacion = FN_KdxFecha.Recuperacion 
	from InventarioKardex, FN_KdxFecha (@IdCedis, @Fecha)
        where InventarioKardex.IdCedis = @IdCedis and InventarioKardex.Fecha = @Fecha
	and FN_KdxFecha.idcedis = InventarioKardex.idcedis 
        and FN_KdxFecha.idproducto = InventarioKardex.idproducto
        and FN_KdxFecha.fecha = InventarioKardex.fecha


end




GO



USE [Route]
GO

if (Select COUNT(*) from VersionBD where Tipo = 'SA' and Version ='3.8.16.1') = 0
BEGIN
	INSERT INTO VersionBD (Tipo, FechaHora, Version, MaximoConsecutivo, VersionSql ) 
	VALUES('SA', GETDATE(), '3.8.16.1', 16, (SELECT  cast(SERVERPROPERTY('productversion') as varchar(50))))
END
ELSE
BEGIN 
	Update VersionBD  set MaximoConsecutivo = 16 where  Tipo = 'SA' and Version ='3.8.16.1'
END
GO