USE [RouteCPC]
GO

/****** Object:  StoredProcedure [dbo].[up_VentasDetalle]    Script Date: 05/18/2011 03:43:18 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[up_VentasDetalle]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[up_VentasDetalle]
GO

USE [RouteCPC]
GO

/****** Object:  StoredProcedure [dbo].[up_VentasDetalle]    Script Date: 05/18/2011 03:43:18 ******/
SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER ON
GO




CREATE PROCEDURE [dbo].[up_VentasDetalle]
@IdCedis as bigint,
@IdTipoVenta as int,
@Serie as varchar(5),
@Folio as bigint,
@Fecha as datetime,
@IdProducto as bigint,
@Cantidad as float,
@Precio as money,
@Iva as float,
@TVenta as int,
@DctoPorc as money,
@DctoImp as money,
@Entregado as float,
@Opc as int

AS

declare @CantidadAnterior as float
declare @IdCliente as bigint, @IdSucursal as varchar(20)

declare @Total as decimal (20,9), @SubTotal as decimal (20,9), @ImpIniciales as decimal (20,9), @ImpFinales as decimal (20,9)
declare @IdTipoImpuesto as int, @TipoAplicacion as int, @Jerarquia as int, @Impuestos as float

if @Opc = 1 -- Actualiza Partida de Factura
begin
	set @CantidadAnterior = isnull( (select Cantidad from VentasDetalle where IdCedis = @IdCedis and Serie = @Serie and IdTipoVenta = @IdTipoVenta and Folio = @Folio and IdProducto = @IdProducto), 0)
	
	delete from VentasDetalle where IdCedis = @IdCedis and Serie = @Serie and IdTipoVenta = @IdTipoVenta and Folio = @Folio and IdProducto = @IdProducto
	delete from VentasImpuestos where IdCedis = @IdCedis and Serie = @Serie and IdTipoVenta = @IdTipoVenta and Folio = @Folio and IdProducto = @IdProducto

	if @Cantidad <> 0 
	begin

		select @IdCliente = IdCliente, @IdSucursal = IdSucursal
		from Ventas
		where IdCedis = @IdCedis and Serie = @Serie and IdTipoVenta = @IdTipoVenta and Folio = @Folio		
		
		set @SubTotal = (@Cantidad * @Precio) - @DctoImp 
		select @ImpFinales = 0, @ImpIniciales = 0, @Total = 0

		declare  ActImpuestos cursor for
			select IdTipoImpuesto, TipoAplicacion, Jerarquia, Impuestos
			from RouteADM.dbo.FN_ImpuestosClientes(@IdCedis, @IdCliente, @IdSucursal, @IdProducto)
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

		insert into VentasDetalle values (@IdCedis, @IdTipoVenta, @Folio, @IdProducto, @Serie, @Cantidad, @Precio, @Iva, 0, @DctoImp, @Entregado)

		insert into VentasImpuestos 
		select @IdCedis, @IdTipoVenta, @Serie, @Folio, IdProducto, IdTipoImpuesto, TipoAplicacion, Jerarquia, Impuestos 
		from RouteADM.dbo.FN_ImpuestosClientes(@IdCedis, @IdCliente, @IdSucursal, @IdProducto)
	end
	

	update Ventas set Subtotal = isnull((select sum((Cantidad * Precio)- DctoImp) from VentasDetalle where IdCedis = @IdCedis and Serie = @Serie and IdTipoVenta = @IdTipoVenta and Folio = @Folio ), 0), 
	Iva = isnull( (select sum(((Cantidad * Precio) - DctoImp) * Iva) from VentasDetalle where IdCedis = @IdCedis and Serie = @Serie and IdTipoVenta = @IdTipoVenta and Folio = @Folio ), 0),
	Ventas.DctoImp = isnull( (select sum(VentasDetalle.DctoImp) from VentasDetalle where IdCedis = @IdCedis and Serie = @Serie and IdTipoVenta = @IdTipoVenta and Folio = @Folio ), 0)
	where IdCedis = @IdCedis and Serie = @Serie and IdTipoVenta = @IdTipoVenta and Folio = @Folio 

end




GO


