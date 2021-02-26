USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[up_VentasDetalle]    Script Date: 01/12/2011 16:28:45 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[up_VentasDetalle]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[up_VentasDetalle]
GO

USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[up_VentasDetalle]    Script Date: 01/12/2011 16:28:45 ******/
SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[up_VentasDetalle]
@IdCedis as bigint,
@IdSurtido as bigint,
@IdTipoVenta as int,
@Folio as bigint,
@Serie as varchar(5),
@Fecha as datetime,
@IdProducto as bigint,
@Cantidad as float,
@Precio as decimal (19,9),
@Iva as float,
@TVenta as int,
@Opc as int

AS

declare @CantidadAnterior as float, @IdRuta as bigint
if @Opc = 1 -- Actualiza Partida de Factura
begin
	set @CantidadAnterior = isnull( (select Cantidad from VentasDetalle where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdTipoVenta = @IdTipoVenta and Folio = @Folio and IdProducto = @IdProducto), 0)
	set @TVenta = (select Tipo from VentasTipo where IdTipoVenta = @IdTipoVenta )

--	if @Cantidad = 0 and @CantidadAnterior <> 0
	delete from VentasDetalle where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdTipoVenta = @IdTipoVenta and Folio = @Folio and IdProducto = @IdProducto
--	else
	if @Cantidad <> 0 
--			update VentasDetalle set Cantidad = @Cantidad, Precio = @Precio, Iva = @Iva where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdTipoVenta = @IdTipoVenta and Folio = @Folio and IdProducto = @IdProducto
--		else
		insert into VentasDetalle values (@IdCedis, @IdSurtido, @IdTipoVenta, @Folio, @IdProducto, @Serie, @Cantidad, @Precio, @Iva)


	if @TVenta = 2 
	begin
		update SurtidosDetalle set VentaContado = VentaContado + @Cantidad - @CantidadAnterior 
		where SurtidosDetalle.Fecha = @Fecha and SurtidosDetalle.IdCedis = @IdCedis and SurtidosDetalle.IdSurtido = @IdSurtido and SurtidosDetalle.IdProducto = @IdProducto
		update InventarioKardex set VentaContado = VentaContado + @Cantidad - @CantidadAnterior 
		where InventarioKardex.Fecha = @Fecha and InventarioKardex.IdCedis = @IdCedis and InventarioKardex.IdProducto = @IdProducto
	end
	else
	begin
		update SurtidosDetalle set VentaCredito = VentaCredito + @Cantidad - @CantidadAnterior 
		where SurtidosDetalle.Fecha = @Fecha and SurtidosDetalle.IdCedis = @IdCedis and SurtidosDetalle.IdSurtido = @IdSurtido and SurtidosDetalle.IdProducto = @IdProducto
		update InventarioKardex set VentaCredito = VentaCredito + @Cantidad - @CantidadAnterior 
		where InventarioKardex.Fecha = @Fecha and InventarioKardex.IdCedis = @IdCedis and InventarioKardex.IdProducto = @IdProducto
	end

/*	update SurtidosDetalle set Surtido = Surtido - @Cantidad - @CantidadAnterior 
	where SurtidosDetalle.Fecha = @Fecha and SurtidosDetalle.IdCedis = @IdCedis and SurtidosDetalle.IdProducto = @IdProducto and SurtidosDetalle.IdSurtido = @IdSurtido
	update InventarioKardex set Surtido = Surtido - @Cantidad - @CantidadAnterior 
	where InventarioKardex.Fecha = @Fecha and InventarioKardex.IdCedis = @IdCedis and InventarioKardex.IdProducto = @IdProducto
*/

	update Ventas set Subtotal = isnull((select sum(Cantidad * Precio) from VentasDetalle where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdTipoVenta = @IdTipoVenta and Folio = @Folio ), 0), 
	Iva = isnull( (select sum(Cantidad * Precio * Iva) from VentasDetalle where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdTipoVenta = @IdTipoVenta and Folio = @Folio ), 0)
	where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdTipoVenta = @IdTipoVenta and Folio = @Folio 

	-- select SubTotal, Iva, Total from Ventas where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdTipoVenta = @IdTipoVenta and Folio = @Folio 	

	set @IdRuta = isnull( (select IdRuta from Surtidos where IdCedis = @IdCedis and IdSurtido = @IdSurtido), 0)

	if exists( select IdCedis from StatusLiquidacion where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdRuta = @IdRuta and Fecha = @Fecha and Status = 'HH' )
	begin
		delete from StatusLiquidacion where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdRuta = @IdRuta and Fecha = @Fecha and Status = 'VEN'
		insert into StatusLiquidacion values ( @IdCedis, @IdSurtido, @IdRuta, @Fecha, 'VEN', 'Actualización de Ventas', getdate() )
	end

end
GO


