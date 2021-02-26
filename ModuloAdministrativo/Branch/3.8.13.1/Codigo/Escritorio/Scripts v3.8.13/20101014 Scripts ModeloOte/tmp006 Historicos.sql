
declare @FIni as datetime, @FFin as datetime
declare @IdSurtido as bigint, @IdCedis as bigint, @Fecha as datetime, @IdRuta as bigint
declare @IdVendedor as bigint, @IdTipoVenta as bigint, @Folio as bigint, @Serie as varchar(10)
declare @SubTotal as money, @Total as money, @DctoImp as money, @Tipo as int
declare @ClienteClave as varchar(20), @DiasCredito as int, @TrpId as varchar(30)

set @FIni = '20091001'
set @FFin = '20100430' -- '20100430'

-- ***** DIAS DE TRABAJO *****

--insert into StatusDia 
--select Cedis.IdCedis, FechaCaptura, 'C', 'Histórico de Ventas'
--from Cedis 
--inner join Route.dbo.Dia on FechaCaptura between @FIni and @FFin  
--order by Cedis.IdCedis, FechaCaptura

-- ***** SURTIDOS *****

--set @IdSurtido = -1

--declare @CursorMOV CURSOR
--SET @CursorMOV = CURSOR SCROLL DYNAMIC FOR 

--	select Cedis.IdCedis, FechaCaptura, Rutas.IdRuta 
--	from Cedis 
--	inner join Rutas on Rutas.IdCedis = Cedis.IdCedis 
--	inner join Route.dbo.Dia on FechaCaptura between @FIni and @FFin  
--	order by Cedis.IdCedis, FechaCaptura, Rutas.IdRuta

--OPEN @CursorMOV
--FETCH NEXT FROM @CursorMOV INTO @IdCedis, @Fecha, @IdRuta
--WHILE @@FETCH_STATUS = 0      
--BEGIN

--	insert into Surtidos 
--	select @IdCedis, @IdSurtido, @Fecha, @IdRuta, 'C', 'N'

--	set @IdSurtido = @IdSurtido - 1
--	FETCH NEXT FROM @CursorMOV INTO @IdCedis, @Fecha, @IdRuta
--END
--CLOSE @CursorMOV  
--DEALLOCATE @CursorMOV

-- ***** SURTIDOSVENDEDOR *****

--declare @CursorMOV CURSOR
--SET @CursorMOV = CURSOR SCROLL DYNAMIC FOR 

--	select IdCedis, IdSurtido, Fecha, IdRuta 
--	from Surtidos 
--	where Fecha < '20100501'
--	order by IdCedis, IdSurtido, Fecha

--OPEN @CursorMOV
--FETCH NEXT FROM @CursorMOV INTO @IdCedis, @IdSurtido, @Fecha, @IdRuta
--WHILE @@FETCH_STATUS = 0      
--BEGIN

--	set @IdVendedor = ( select top 1 SurtidosVendedor.IdVendedor  
--	from Surtidos SURANT 
--	inner join SurtidosVendedor on SurtidosVendedor.IdCedis = SURANT.IdCedis 
--	and SurtidosVendedor.IdSurtido = SURANT.IdSurtido 	
--	where SURANT.IdCedis = @IdCedis and SURANT.IdRuta = @IdRuta  
--	order by SURANT.Fecha desc )

--	insert into SurtidosVendedor 
--	select @IdCedis, @IdSurtido, @Fecha, @IdVendedor, 1
	
--	FETCH NEXT FROM @CursorMOV INTO @IdCedis, @IdSurtido, @Fecha, @IdRuta
--END
--CLOSE @CursorMOV  
--DEALLOCATE @CursorMOV

-- ***** VENTAS *****

--declare @CursorMOV CURSOR
--SET @CursorMOV = CURSOR SCROLL DYNAMIC FOR 

--	select distinct Rutas.IdCedis, trp.CFVTipo as IdTipoV, route.dbo.FNObtenerSoloNumeros(trp.Folio), 'R' + CAST(Rutas.IdRuta as varchar(10)) as Serie, 
--	Dia.FechaCaptura, trp.Subtotal, TRP.ClienteClave, TRP.DescuentoVendedor, TRP.DiasCredito, Rutas.IdRuta, trp.transprodid, 1 as tipo
--	from Route.dbo.TransProd TRP 
--	inner join Route.dbo.Dia Dia on TRP.DiaClave = Dia.DiaClave
--	inner join Route.dbo.Visita VIS on TRP.VisitaClave = VIS.VisitaClave
--	inner join Route.dbo.Vendedor VEN on VEN.VendedorID = VIS.VendedorID
--	inner join Route.dbo.Usuario USU on USU.USUId = VEN.USUId 
--	inner join Rutas Rutas on Rutas.IdRuta = cast(Route.dbo.FNObtenerSoloNumeros(USU.Clave) as bigint)
--	where TRP.Tipo in (1) and TRP.TipoFase <> 0 and Dia.FechaCaptura between @FIni and @FFin 

--	union

--	select distinct Rutas.IdCedis, 2 as IdTipoV, route.dbo.FNObtenerSoloNumeros(trp.Folio), 'CR' + CAST(Rutas.IdRuta as varchar(10)) as Serie, 
--	Dia.FechaCaptura, sum(ABN.Total) as Subtotal, TRP.ClienteClave, TRP.DescuentoVendedor, TRP.DiasCredito, Rutas.IdRuta, trp.transprodid, 24 as tipo
--	from Route.dbo.TransProd TRP 
--	inner join Route.dbo.AbnTrp ABT on ABT.TransProdID = TRP.TransProdID 
--	inner join Route.dbo.Abono ABN on ABT.ABNId = ABN.ABNId 
--	inner join Route.dbo.Dia Dia on TRP.DiaClave = Dia.DiaClave
--	inner join Route.dbo.Visita VIS on TRP.VisitaClave = VIS.VisitaClave
--	inner join Route.dbo.Vendedor VEN on VEN.VendedorID = VIS.VendedorID
--	inner join Route.dbo.Usuario USU on USU.USUId = VEN.USUId 
--	inner join Rutas Rutas on Rutas.IdRuta = cast(Route.dbo.FNObtenerSoloNumeros(USU.Clave) as bigint)
--	where TRP.Tipo in (24) and TRP.TipoFase <> 0 and Dia.FechaCaptura between @FIni and @FFin 
--	group by Rutas.IdCedis, trp.Folio, Rutas.IdRuta, Dia.FechaCaptura, TRP.Total, 
--	TRP.ClienteClave, TRP.DescuentoVendedor, TRP.DiasCredito, Rutas.IdRuta, trp.transprodid
--	order by Rutas.IdCedis, Dia.FechaCaptura, Rutas.IdRuta 

--OPEN @CursorMOV
--FETCH NEXT FROM @CursorMOV INTO @IdCedis, @IdTipoVenta, @Folio, @Serie, @Fecha, @SubTotal, @ClienteClave, @DctoImp, @DiasCredito, @IdRuta, @TrpId, @Tipo
--WHILE @@FETCH_STATUS = 0      
--BEGIN

--	set @IdSurtido = ( select top 1 Surtidos.IdSurtido from Surtidos where IdCedis = @IdCedis and Fecha = @Fecha and IdRuta = @IdRuta )

--	insert into Ventas  
--	select @IdCedis, @IdSurtido, @IdTipoVenta, @Folio, @Serie, @Fecha, 1, @SubTotal, 0, @ClienteClave, @DctoImp, @DiasCredito
	
--	if @Tipo = 1
--	begin
--		insert into VentasDetalle 
--		select @IdCedis, @IdSurtido, @IdTipoVenta, @Folio, TRPDET.ProductoClave, @Serie, sum(TRPDET.Cantidad) as Cantidad, sum(TRPDET.Total) / sum(TRPDET.Cantidad ) as Precio, 
--		0, 0, sum(TRPDET.DescuentoImp)
--		from Route.dbo.TransProdDetalle TRPDET
--		where TRPDET.TransProdID = @TrpId 
--		group by TRPDET.ProductoClave
--	end
--	else
--	begin 
--		insert into VentasDetalle 
--		select @IdCedis, @IdSurtido, @IdTipoVenta, @Folio, TRPDET.ProductoClave, @Serie, sum(TRPDET.Cantidad) - isnull(SUM(TPD.Cantidad),0) as Cantidad, (sum(TRPDET.Total) - isnull(sum(TPD.Subtotal),0)) / (sum(TRPDET.Cantidad) - isnull(SUM(TPD.Cantidad),0)) as Precio, 
--		0, 0, sum(TRPDET.DescuentoImp)
--		from Route.dbo.TransProdDetalle TRPDET
--		left outer join Route.dbo.TrpTpd TPD on TPD.TransProdID1 = TRPDET.TransProdID 
--		where TRPDET.TransProdID = @TrpId 
--		group by TRPDET.ProductoClave
--	end
	
--	FETCH NEXT FROM @CursorMOV INTO @IdCedis, @IdTipoVenta, @Folio, @Serie, @Fecha, @SubTotal, @ClienteClave, @DctoImp, @DiasCredito, @IdRuta, @TrpId, @Tipo
--END
--CLOSE @CursorMOV  
--DEALLOCATE @CursorMOV

-- ***** CARGAS *****

insert into Cargas 
select IdCedis, IdSurtido, 1, IdRuta, Fecha, 'A'
from Surtidos 
where IdSurtido < 0

-- ***** SURTIDOSDETALLE *****

insert into SurtidosDetalle 
select IdCedis, IdSurtido, IdProducto, '19000101', SUM(cantidad), 0, 0, 0, 0, 0, SUM(total)/ SUM(Cantidad), 0
from VentasDetalle 
where IdSurtido < 0
group by IdCedis, IdSurtido, IdProducto
having SUM(cantidad) <> 0

update SurtidosDetalle set SurtidosDetalle.Fecha = Surtidos.Fecha 
from SurtidosDetalle, Surtidos 
where Surtidos.IdCedis = SurtidosDetalle.IdCedis and Surtidos.IdSurtido = SurtidosDetalle.IdSurtido 
	and Surtidos.IdSurtido < 0

declare @CursorMOV CURSOR
SET @CursorMOV = CURSOR SCROLL DYNAMIC FOR 

	select distinct IdCedis, Fecha
	from Surtidos 
	where Fecha < '20100501'
	order by IdCedis, Fecha

OPEN @CursorMOV
FETCH NEXT FROM @CursorMOV INTO @IdCedis, @Fecha
WHILE @@FETCH_STATUS = 0      
BEGIN

	update surtidosdetalle set
		ventacontado = isnull( ( select FN_KdxVentasFechaG.VentaContado from  FN_KdxVentasFechaG (@IdCedis, @Fecha) where FN_KdxVentasFechaG.idcedis = SurtidosDetalle.idcedis 
		and FN_KdxVentasFechaG.idproducto = SurtidosDetalle.idproducto and FN_KdxVentasFechaG.idsurtido = SurtidosDetalle.idsurtido), 0),
		ventacredito = isnull( ( select FN_KdxVentasFechaG.VentaCredito from  FN_KdxVentasFechaG (@IdCedis, @Fecha) where FN_KdxVentasFechaG.idcedis = SurtidosDetalle.idcedis 
		and FN_KdxVentasFechaG.idproducto = SurtidosDetalle.idproducto and FN_KdxVentasFechaG.idsurtido = SurtidosDetalle.idsurtido), 0)
	from SurtidosDetalle
	where SurtidosDetalle.idcedis = @IdCedis and SurtidosDetalle.fecha = @Fecha 
	
	FETCH NEXT FROM @CursorMOV INTO @IdCedis, @Fecha
END
CLOSE @CursorMOV  
DEALLOCATE @CursorMOV

-- ***** SURTIDOSCARGAS *****

insert into SurtidosCargas 
select IdCedis, IdSurtido, 1, IdProducto, SUM(cantidad)
from VentasDetalle 
where IdSurtido < 0
group by IdCedis, IdSurtido, IdProducto
having SUM(cantidad) <> 0

--select * from SurtidosCargas 
	