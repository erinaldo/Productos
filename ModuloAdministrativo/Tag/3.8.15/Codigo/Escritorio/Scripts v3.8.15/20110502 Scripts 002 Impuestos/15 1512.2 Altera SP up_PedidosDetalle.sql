USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[up_PedidosDetalle]    Script Date: 05/04/2011 17:25:32 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[up_PedidosDetalle]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[up_PedidosDetalle]
GO

USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[up_PedidosDetalle]    Script Date: 05/04/2011 17:25:32 ******/
SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[up_PedidosDetalle]
@IdCedis as bigint,
@IdPedido as bigint,
@IdTipoVenta as int,
@IdProducto as bigint,
@Cantidad as float,
@Precio as money,
@Iva as float,
@DctoPorc as money,
@DctoImp as money,
@Entregado as float,
@Opc as int

AS

declare @IdCliente as bigint, @IdSucursal as varchar(20)

declare @Total as decimal (20,9), @SubTotal as decimal (20,9), @ImpIniciales as decimal (20,9), @ImpFinales as decimal (20,9)
declare @IdTipoImpuesto as int, @TipoAplicacion as int, @Jerarquia as int, @Impuestos as float

if @Opc = 1 -- Actualiza Partida de Factura
begin

	delete from PedidosDetalle where IdCedis = @IdCedis and IdPedido = @IdPedido and IdProducto = @IdProducto
	delete from PedidosImpuestos where IdCedis = @IdCedis and IdPedido = @IdPedido and IdProducto = @IdProducto
	
	if @Cantidad <> 0
	begin
		select @IdCliente = IdCliente, @IdSucursal = IdSucursal
		from Pedidos 
		where IdCedis = @IdCedis and IdPedido = @IdPedido
		
		set @SubTotal = @Cantidad * @Precio 
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
		
		insert into PedidosDetalle values (@IdCedis, @IdPedido, @IdTipoVenta, @IdProducto, @Cantidad, @Precio, @Iva, @DctoPorc, @Cantidad * @Precio * @DctoPorc, @Entregado)

		insert into PedidosImpuestos 
		select @IdCedis, @IdPedido, @IdTipoVenta, IdProducto, IdTipoImpuesto, TipoAplicacion, Jerarquia, Impuestos 
		from FN_ImpuestosClientes(@IdCedis, @IdCliente, @IdSucursal, @IdProducto)
		
	end

	update Pedidos set Subtotal = isnull((select sum((Cantidad * Precio)- DctoImp) from PedidosDetalle where IdCedis = @IdCedis and IdPedido = @IdPedido and IdTipoVenta = @IdTipoVenta ), 0), 
	Iva = isnull( (select sum(((Cantidad * Precio) - DctoImp) * Iva) from PedidosDetalle where IdCedis = @IdCedis and IdPedido = @IdPedido and IdTipoVenta = @IdTipoVenta ), 0),
	Pedidos.DctoImp = isnull( (select sum(PedidosDetalle.DctoImp) from PedidosDetalle where IdCedis = @IdCedis and IdPedido = @IdPedido and IdTipoVenta = @IdTipoVenta ), 0)
	where IdCedis = @IdCedis and IdPedido = @IdPedido and IdTipoVenta = @IdTipoVenta 

end
GO


