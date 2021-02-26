USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[up_Ventas]    Script Date: 05/03/2011 16:03:32 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[up_Ventas]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[up_Ventas]
GO

USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[up_Ventas]    Script Date: 05/03/2011 16:03:32 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO







CREATE PROCEDURE [dbo].[up_Ventas] 
@IdCedis as bigint,
@IdSurtido as bigint,
@IdTipoVenta as int,
@Folio as bigint,
@Serie as varchar(5),
@Fecha as datetime,
@IdCliente as bigint,
@IdSucursal as varchar(16),
@Opc as int

AS

declare 
@TVenta as bigint,
@IdRuta as bigint,
@DiasCredito as int,
@IdLista as bigint,
@IdSurtidoD as bigint,
@IdTipoVentaD as int,
@FolioD as bigint,
@SerieD as varchar(10)

declare @Total as decimal (20,9), @SubTotal as decimal (20,9), @ImpIniciales as decimal (20,9), @ImpFinales as decimal (20,9)
declare @IdTipoImpuesto as int, @TipoAplicacion as int, @Jerarquia as int, @Impuestos as float
declare @IdProducto as bigint, @Cantidad as float, @Precio as decimal(20,9), @Iva as float
declare @DctoPorc as float, @DctoImp as float

if @Opc = 1 -- Inserta Factura Nueva
begin
	
	select @SerieD = isnull(SerieDevoluciones,'') from Configuracion where IdCedis = @IdCedis 
	
	select @DiasCredito = ISNULL(DiasCredito,0) 
	from ClienteSucursal 
	where IdCedis = @IdCedis and IdCliente = @IdCliente and IdSucursal = @IdSucursal and @IdTipoVenta = 2
	
	select @Folio = isnull(MAX(Folio) + 1, 1)  
	from Ventas 
	where Serie in (@Serie, @SerieD)

	insert into Ventas values (@IdCedis, @IdSurtido, @IdTipoVenta, @Folio, @Serie, @Fecha, @IdCliente, 0, 0, @IdSucursal, 0, @DiasCredito)	

	set @IdRuta = isnull( (select IdRuta from Surtidos where IdCedis = @IdCedis and IdSurtido = @IdSurtido), 0)
	update StatusRutas set Status = 'V', StatusDesc = 'Ventas' where IdCedis = @IdCedis and Fecha = @Fecha and IdRuta = @IdRuta
end

if @Opc = 3 -- Elimina Factura
begin

	set @TVenta = (select Tipo from VentasTipo where IdTipoVenta = @IdTipoVenta)
	
	if @TVenta = 2 
	begin
		update SurtidosDetalle set VentaContado = VentaContado -
		( select isnull(sum(Cantidad),0) from VentasDetalle where VentasDetalle.IdCedis = @IdCedis and VentasDetalle.IdSurtido = @IdSurtido and VentasDetalle.IdTipoVenta = @IdTipoVenta and VentasDetalle.Folio = @Folio and VentasDetalle.IdProducto = SurtidosDetalle.IdProducto)  
		from SurtidosDetalle where SurtidosDetalle.Fecha = @Fecha and SurtidosDetalle.IdCedis = @IdCedis and SurtidosDetalle.IdSurtido = @IdSurtido
		and SurtidosDetalle.IdProducto in 
		(select VentasDetalle.IdProducto from VentasDetalle 
		where VentasDetalle.IdCedis = @IdCedis and VentasDetalle.IdSurtido = @IdSurtido and VentasDetalle.IdTipoVenta = @IdTipoVenta and VentasDetalle.Folio = @Folio)

		update InventarioKardex set VentaContado = VentaContado - 
		( select isnull(sum(Cantidad),0) from VentasDetalle where VentasDetalle.IdCedis = @IdCedis and VentasDetalle.IdSurtido = @IdSurtido and VentasDetalle.IdTipoVenta = @IdTipoVenta and VentasDetalle.Folio = @Folio and VentasDetalle.IdProducto = InventarioKardex.IdProducto)  
		from InventarioKardex where InventarioKardex.Fecha = @Fecha and InventarioKardex.IdCedis = @IdCedis
		and InventarioKardex.IdProducto in 
		(select VentasDetalle.IdProducto from VentasDetalle 
		where VentasDetalle.IdCedis = @IdCedis and VentasDetalle.IdSurtido = @IdSurtido and VentasDetalle.IdTipoVenta = @IdTipoVenta and VentasDetalle.Folio = @Folio)
	end
	else
	begin
		update SurtidosDetalle set VentaCredito = VentaCredito -
		( select isnull(sum(Cantidad),0) from VentasDetalle where VentasDetalle.IdCedis = @IdCedis and VentasDetalle.IdSurtido = @IdSurtido and VentasDetalle.IdTipoVenta = @IdTipoVenta and VentasDetalle.Folio = @Folio and VentasDetalle.IdProducto = SurtidosDetalle.IdProducto)  
		from SurtidosDetalle where SurtidosDetalle.Fecha = @Fecha and SurtidosDetalle.IdCedis = @IdCedis and SurtidosDetalle.IdSurtido = @IdSurtido
		and SurtidosDetalle.IdProducto in 
		(select VentasDetalle.IdProducto from VentasDetalle 
		where VentasDetalle.IdCedis = @IdCedis and VentasDetalle.IdSurtido = @IdSurtido and VentasDetalle.IdTipoVenta = @IdTipoVenta and VentasDetalle.Folio = @Folio)

		update InventarioKardex set VentaCredito = VentaCredito - 
		( select isnull(sum(Cantidad),0) from VentasDetalle where VentasDetalle.IdCedis = @IdCedis and VentasDetalle.IdSurtido = @IdSurtido and VentasDetalle.IdTipoVenta = @IdTipoVenta and VentasDetalle.Folio = @Folio and VentasDetalle.IdProducto = InventarioKardex.IdProducto) 
		from InventarioKardex where InventarioKardex.Fecha = @Fecha and InventarioKardex.IdCedis = @IdCedis
		and InventarioKardex.IdProducto in 
		(select VentasDetalle.IdProducto from VentasDetalle 
		where VentasDetalle.IdCedis = @IdCedis and VentasDetalle.IdSurtido = @IdSurtido and VentasDetalle.IdTipoVenta = @IdTipoVenta and VentasDetalle.Folio = @Folio)
	end

	insert into VentasCanceladas 
	select IdCedis, IdSurtido, IdTipoVenta, Folio, Serie, Fecha, IdCliente, Subtotal, Iva, IdSucursal, DctoImp, DiasCredito from Ventas where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdTipoVenta = @IdTipoVenta and Folio = @Folio 

	delete from VentasDetalle where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdTipoVenta = @IdTipoVenta and Folio = @Folio 
	delete from Ventas where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdTipoVenta = @IdTipoVenta and Folio = @Folio 
	delete from VentasAcredita where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdTipoVenta = @IdTipoVenta and Folio = @Folio 
	delete from VentasImpuestos where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdTipoVenta = @IdTipoVenta and Folio = @Folio 
	delete from VentasPromociones where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdTipoVenta = @IdTipoVenta and Folio = @Folio 

	--exec up_SurtidosCargas @IdCedis, @IdSurtido, 99, 0, '19000101', 0, 3
	
	update Pedidos set IdSurtido = 0, Serie = '', Folio = 0
	where IdCedis = @IdCedis and IdSurtido = @IdSurtido and Serie = @Serie and Folio = @Folio 
	
	-- Borra una devolucion
	delete from VentasDevolucion where IdCedisD = @IdCedis and IdSurtidoD = @IdSurtido and IdTipoVentaD = @IdTipoVenta and FolioD = @Folio
	
	if exists (select Folio from VentasDevolucion where IdCedisD = @IdCedis and IdSurtido = @IdSurtido and IdTipoVenta = @IdTipoVenta and Folio = @Folio and Tipo = 'F')
	begin
		select @IdSurtidoD = IdSurtidoD, @IdTipoVentaD = IdTipoVentaD, @FolioD = FolioD 
		from VentasDevolucion 
		where IdCedisD = @IdCedis and IdSurtido = @IdSurtido and IdTipoVenta = @IdTipoVenta and Folio = @Folio and Tipo = 'F'
	
		delete from VentasDevolucion where IdCedisD = @IdCedis and IdSurtido = @IdSurtidoD and IdTipoVenta = @IdTipoVentaD and FolioD = @FolioD and Tipo = 'F'
		
		exec up_Ventas @IdCedis, @IdSurtidoD, @IdTipoVentaD, @FolioD, '', '19000101', 0, '', 3
	end
	
end

if @Opc = 4
begin
	select @DiasCredito = ISNULL(DiasCredito,0) 
	from ClienteSucursal 
	where IdCedis = @IdCedis and IdCliente = @IdCliente and IdSucursal = @IdSucursal and @IdTipoVenta = 2

	insert into Ventas values (@IdCedis, @IdSurtido, @IdTipoVenta, @Folio, @Serie, @Fecha, @IdCliente, 0, 0, @IdSucursal, 0, @DiasCredito)	

	set @IdRuta = isnull( (select IdRuta from Surtidos where IdCedis = @IdCedis and IdSurtido = @IdSurtido), 0)
	update StatusRutas set Status = 'V', StatusDesc = 'Ventas' where IdCedis = @IdCedis and Fecha = @Fecha and IdRuta = @IdRuta

	delete from VentasDetalle where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdTipoVenta = @IdTipoVenta and Folio = @Folio and Cantidad = 0

	insert into VentasDetalle
	select @IdCedis, @IdSurtido, @IdTipoVenta, @Folio, IdProducto, @Serie, isnull( sum(Surtido - DevBuena - DevMala - Obsequios - VentaContado - VentaCredito) , 0),  0, 
	0, 0, 0, isnull( sum(Surtido - DevBuena - DevMala - Obsequios - VentaContado - VentaCredito) , 0)
	from SurtidosDetalle 
	where IdCedis = @IdCedis and IdSurtido = @IdSurtido
	group by IdProducto
				
	-- ACTUALIZA PRECIOS DE RUTA ESPECIAL
	set @IdLista = isnull((select PreciosListaRuta.IdLista from PreciosListaRuta 
			inner join PreciosLista on PreciosListaRuta.IdLista = PreciosLista.IdLista and TipoLista = 'RU'
			where PreciosListaRuta.IdCedis = @IdCedis and PreciosListaRuta.IdRuta = @IdRuta),0)

	if @IdLista <> 0  
		update VentasDetalle set Precio = isnull( ( select PreciosDetalle.Precio from PreciosDetalle where PreciosDetalle.IdLista = @IdLista and VentasDetalle.IdProducto = PreciosDetalle.IdProducto ), 0) 
		where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdTipoVenta = @IdTipoVenta and Folio = @Folio

	--  INSERTA VENTA DE CONTADO CON PRECIO DE DETALLE
	set @IdLista = isnull((select PreciosListaCedis.IdLista from PreciosListaCedis 
			inner join PreciosLista on PreciosListaCedis.IdLista = PreciosLista.IdLista and TipoLista = 'BA'
			where PreciosListaCedis.idcedis = @IdCedis),0)

	if @IdLista <> 0  
		update VentasDetalle set Precio = isnull( ( select PreciosDetalle.Precio from PreciosDetalle where PreciosDetalle.IdLista = @IdLista and VentasDetalle.IdProducto = PreciosDetalle.IdProducto ), 0) 
		where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdTipoVenta = @IdTipoVenta and Folio = @Folio and VentasDetalle.Precio = 0

	-- ACTUALIZA IMPUESTOS
	declare ProductosVenta cursor for
		select IdProducto, Cantidad, Precio
		from VentasDetalle
		where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdTipoVenta = @IdTipoVenta and Folio = @Folio  
	open ProductosVenta

	fetch next from ProductosVenta into @IdProducto, @Cantidad, @Precio
	while (@@fetch_status = 0)
	begin
			if @Cantidad <> 0
			begin

				exec up_VentasPromociones @IdCedis, @IdSurtido, @IdTipoVenta, @Folio, @Serie, @Fecha, @IdProducto, @Cantidad, @Precio, 1
				
				select @DctoImp = ISNULL(SUM(DctoImp),0), @DctoPorc = isnull(@DctoImp / (@Cantidad * @Precio),0)
				from VentasPromociones 
				where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdTipoVenta = @IdTipoVenta and Folio = @Folio and IdProducto = @IdProducto 
				
				if @DctoImp is null select @DctoImp = 0
				if @DctoPorc is null select @DctoPorc = 0			

				select @IdCliente = IdCliente, @IdSucursal = IdSucursal
				from Ventas
				where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdTipoVenta = @IdTipoVenta and Folio = @Folio		
				
				set @SubTotal = (@Cantidad * @Precio) - @DctoImp 
				select @ImpFinales = 0, @ImpIniciales = 0, @Total = 0

				declare  ActImpuestos cursor for
					select IdTipoImpuesto, TipoAplicacion, Jerarquia, Impuestos
					from FN_ImpuestosClientes(@IdCedis, @IdCliente, @IdSucursal, @IdProducto)
					order by TipoAplicacion, Jerarquia
				open ActImpuestos
				
				fetch next from ActImpuestos into @IdTipoImpuesto, @TipoAplicacion, @Jerarquia, @Impuestos 
				while (@@fetch_status = 0)
				begin
					
					if @TipoAplicacion = 1
						set @ImpIniciales = @ImpIniciales + (@SubTotal * @Impuestos)
					else
						set @ImpFinales = @ImpFinales + ((@SubTotal + @ImpIniciales) * @Impuestos)
					
					fetch next from ActImpuestos into @IdTipoImpuesto, @TipoAplicacion, @Jerarquia, @Impuestos 
				end
				close ActImpuestos
				deallocate ActImpuestos		

				set @Total = @SubTotal + @ImpIniciales + @ImpFinales 
				set @Iva = ( @Total / @SubTotal ) - 1
				
			end
			
			update VentasDetalle set Iva = @Iva 
			where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdTipoVenta = @IdTipoVenta and Folio = @Folio and IdProducto = @IdProducto

			insert into VentasImpuestos 
			select @IdCedis, @IdSurtido, @IdTipoVenta, @Folio, IdProducto, IdTipoImpuesto, TipoAplicacion, Jerarquia, Impuestos 
			from FN_ImpuestosClientes(@IdCedis, @IdCliente, @IdSucursal, @IdProducto)
	
		fetch next from ProductosVenta into @IdProducto, @Cantidad, @Precio
	end
	close ProductosVenta
	deallocate ProductosVenta		

	update SurtidosDetalle set VentaContado = VentaContado +
	( select isnull(sum(Cantidad),0) from VentasDetalle where VentasDetalle.IdCedis = @IdCedis and VentasDetalle.IdSurtido = @IdSurtido and VentasDetalle.IdTipoVenta = @IdTipoVenta and VentasDetalle.Folio = @Folio and VentasDetalle.IdProducto = SurtidosDetalle.IdProducto)  
	from SurtidosDetalle where SurtidosDetalle.Fecha = @Fecha and SurtidosDetalle.IdCedis = @IdCedis and SurtidosDetalle.IdSurtido = @IdSurtido
	and SurtidosDetalle.IdProducto in 
	(select VentasDetalle.IdProducto from VentasDetalle 
	where VentasDetalle.IdCedis = @IdCedis and VentasDetalle.IdSurtido = @IdSurtido and VentasDetalle.IdTipoVenta = @IdTipoVenta and VentasDetalle.Folio = @Folio)

	update InventarioKardex set VentaContado = VentaContado +
	( select isnull(sum(Cantidad),0) from VentasDetalle where VentasDetalle.IdCedis = @IdCedis and VentasDetalle.IdSurtido = @IdSurtido and VentasDetalle.IdTipoVenta = @IdTipoVenta and VentasDetalle.Folio = @Folio and VentasDetalle.IdProducto = InventarioKardex.IdProducto)  
	from InventarioKardex where InventarioKardex.Fecha = @Fecha and InventarioKardex.IdCedis = @IdCedis
	and InventarioKardex.IdProducto in 
	(select VentasDetalle.IdProducto from VentasDetalle 
	where VentasDetalle.IdCedis = @IdCedis and VentasDetalle.IdSurtido = @IdSurtido and VentasDetalle.IdTipoVenta = @IdTipoVenta and VentasDetalle.Folio = @Folio)

	update Ventas set Subtotal = isnull((select sum(Cantidad * Precio) from VentasDetalle where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdTipoVenta = @IdTipoVenta and Folio = @Folio ), 0), 
	Iva = isnull( (select sum(Cantidad * Precio * Iva) from VentasDetalle where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdTipoVenta = @IdTipoVenta and Folio = @Folio ), 0)
	where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdTipoVenta = @IdTipoVenta and Folio = @Folio 

end

if @Opc = 5
begin
	delete from VentasDetalle where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdTipoVenta = @IdTipoVenta and Folio = @Folio and ( Cantidad = 0 or Precio = 0)

	delete from VentasImpuestos 
	where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdTipoVenta = @IdTipoVenta and Folio = @Folio 
		and IdProducto not in (select IdProducto from VentasDetalle where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdTipoVenta = @IdTipoVenta and Folio = @Folio)

	update SurtidosDetalle set VentaContado = VentaContado +
	( select isnull(sum(Cantidad),0) from VentasDetalle where VentasDetalle.IdCedis = @IdCedis and VentasDetalle.IdSurtido = @IdSurtido and VentasDetalle.IdTipoVenta = @IdTipoVenta and VentasDetalle.Folio = @Folio and VentasDetalle.IdProducto = SurtidosDetalle.IdProducto)  
	from SurtidosDetalle where SurtidosDetalle.Fecha = @Fecha and SurtidosDetalle.IdCedis = @IdCedis and SurtidosDetalle.IdSurtido = @IdSurtido
	and SurtidosDetalle.IdProducto in 
	(select VentasDetalle.IdProducto from VentasDetalle 
	where VentasDetalle.IdCedis = @IdCedis and VentasDetalle.IdSurtido = @IdSurtido and VentasDetalle.IdTipoVenta = @IdTipoVenta and VentasDetalle.Folio = @Folio)

	update InventarioKardex set VentaContado = VentaContado +
	( select isnull(sum(Cantidad),0) from VentasDetalle where VentasDetalle.IdCedis = @IdCedis and VentasDetalle.IdSurtido = @IdSurtido and VentasDetalle.IdTipoVenta = @IdTipoVenta and VentasDetalle.Folio = @Folio and VentasDetalle.IdProducto = InventarioKardex.IdProducto)  
	from InventarioKardex where InventarioKardex.Fecha = @Fecha and InventarioKardex.IdCedis = @IdCedis
	and InventarioKardex.IdProducto in 
	(select VentasDetalle.IdProducto from VentasDetalle 
	where VentasDetalle.IdCedis = @IdCedis and VentasDetalle.IdSurtido = @IdSurtido and VentasDetalle.IdTipoVenta = @IdTipoVenta and VentasDetalle.Folio = @Folio)

	update Ventas set Subtotal = isnull((select sum(Cantidad * Precio) from VentasDetalle where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdTipoVenta = @IdTipoVenta and Folio = @Folio ), 0), 
	Iva = isnull( (select sum(((Cantidad * Precio) - DctoImp)* Iva) from VentasDetalle where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdTipoVenta = @IdTipoVenta and Folio = @Folio ), 0),
	DctoImp = isnull( (select sum(DctoImp) from VentasDetalle where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdTipoVenta = @IdTipoVenta and Folio = @Folio ), 0)
	where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdTipoVenta = @IdTipoVenta and Folio = @Folio 
end






GO


