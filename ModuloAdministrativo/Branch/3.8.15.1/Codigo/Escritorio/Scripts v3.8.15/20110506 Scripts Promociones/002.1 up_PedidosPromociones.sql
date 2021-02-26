USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[up_PedidosPromociones]    Script Date: 05/03/2011 16:29:20 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[up_PedidosPromociones]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[up_PedidosPromociones]
GO

USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[up_PedidosPromociones]    Script Date: 05/03/2011 16:29:20 ******/
SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER ON
GO





CREATE PROCEDURE [dbo].[up_PedidosPromociones]
@IdCedis as bigint,
@IdPedido as bigint,
@IdTipoVenta as int,
@Fecha as datetime,
@IdProducto as bigint,
@Cantidad as float,
@Precio as money,
@Opc as int

AS

if @Opc = 1 -- Actualiza Promociones
begin

declare @IdPromocion as bigint, @Otras as smallint, @Cascada as smallint, @BOtras as smallint, @BCascada as smallint, @IdCliente as bigint
declare @PromoAplicada as bit, @Subtotal as float, @SubtotalDcto as float, @DctoImp as float, @DctoPorc as float

select @IdCliente = IdCliente from Pedidos where IdCedis = @IdCedis and IdPedido = @IdPedido and IdTipoVenta = @IdTipoVenta 

delete from PedidosPromociones  
where IdCedis = @IdCedis and IdPedido = @IdPedido and IdTipoVenta = @IdTipoVenta and IdProducto = @IdProducto 

declare  RPromociones cursor for
	select IdPromocion, Otras, Cascada 
	from RouteCPC.dbo.Promociones as Promo
	where Status = 'G' and @Fecha between FechaInicial and case FechaFinal when '19000101' then '20991231' else FechaFinal end
	order by IdPromocion, Cascada
open RPromociones

select @PromoAplicada = 0, @DctoPorc = 0, @DctoImp = 0, @Subtotal = @Cantidad * @Precio, @SubtotalDcto = @Cantidad * @Precio 

fetch next from RPromociones into @IdPromocion, @Otras, @Cascada 
while (@@fetch_status = 0)
begin
	if exists(select IdCliente from RouteCPC.dbo.FN_PromocionesClientes(@IdPromocion) where IdCedis = @IDCedis and IdCliente = @IdCliente )
	begin
		if exists(select * from RouteCPC.dbo.FN_PromocionesProductos(@IdPromocion) where IdProducto = @IdProducto)
		begin
			if not (@PromoAplicada = 1 and @Otras = 0)
			begin
				set @PromoAplicada = 1 
			
				if @Cascada = 1 
				begin
					
					select @SubtotalDcto = @Subtotal - isnull(sum(DctoImp),0)
					from PedidosPromociones  
					where IdCedis = @IdCedis and IdPedido = @IdPedido and IdTipoVenta = @IdTipoVenta and IdProducto = @IdProducto 
				
					select @DctoImp = isnull(@SubtotalDcto * Porcentaje,0), @DctoPorc = Porcentaje  
					from RouteCPC.dbo.FN_PromocionesProductos(@IdPromocion) where IdProducto = @IdProducto

					insert into PedidosPromociones 
					select @IdCedis, @IdPedido, @IdTipoVenta, @IdProducto, @IdPromocion, @Otras, @Cascada, @DctoPorc, @DctoImp, ''
				end
				else
				begin
					select @DctoImp = @Subtotal * Porcentaje, @DctoPorc = Porcentaje  
					from RouteCPC.dbo.FN_PromocionesProductos(@IdPromocion) where IdProducto = @IdProducto

					insert into PedidosPromociones 
					select @IdCedis, @IdPedido, @IdTipoVenta, @IdProducto, @IdPromocion, @Otras, @Cascada, @DctoPorc, @DctoImp, ''
					
				end
			end
		end
	end
	
	fetch next from RPromociones into @IdPromocion, @Otras, @Cascada 
end
close RPromociones
deallocate RPromociones		

end



GO


