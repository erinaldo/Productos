USE [RouteCPC]
GO

/****** Object:  StoredProcedure [dbo].[up_VentasDetalle]    Script Date: 04/01/2011 15:57:07 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[up_VentasDetalle]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[up_VentasDetalle]
GO

USE [RouteCPC]
GO

/****** Object:  StoredProcedure [dbo].[up_VentasDetalle]    Script Date: 04/01/2011 15:57:07 ******/
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

if @Opc = 1 -- Actualiza Partida de Factura
begin
	set @CantidadAnterior = isnull( (select Cantidad from VentasDetalle where IdCedis = @IdCedis and Serie = @Serie and IdTipoVenta = @IdTipoVenta and Folio = @Folio and IdProducto = @IdProducto), 0)
	
	select @Iva = Iva from Productos where IdProducto = @IdProducto 
	
	if @Iva = 0 
	begin
		select @IdCliente = IdCliente, @IdSucursal = IdSucursal
		from Ventas
		where IdCedis = @IdCedis and Serie = @Serie and IdTipoVenta = @IdTipoVenta and Folio = @Folio		
		set @Iva = ISNULL( (select Valor from ClientesImpuestos where IdCedis = @IdCedis and IdCliente = @IdCliente and IdSucursal = @IdSucursal and IdProducto = @IdProducto), 0)
	end
	
	delete from VentasDetalle where IdCedis = @IdCedis and Serie = @Serie and IdTipoVenta = @IdTipoVenta and Folio = @Folio and IdProducto = @IdProducto

	if @Cantidad <> 0 
	begin
		insert into VentasDetalle values (@IdCedis, @IdTipoVenta, @Folio, @IdProducto, @Serie, @Cantidad, @Precio, @Iva, @DctoPorc, @Cantidad * @Precio * @DctoPorc, @Entregado)
	end
	

	update Ventas set Subtotal = isnull((select sum((Cantidad * Precio)- DctoImp) from VentasDetalle where IdCedis = @IdCedis and Serie = @Serie and IdTipoVenta = @IdTipoVenta and Folio = @Folio ), 0), 
	Iva = isnull( (select sum(((Cantidad * Precio) - DctoImp) * Iva) from VentasDetalle where IdCedis = @IdCedis and Serie = @Serie and IdTipoVenta = @IdTipoVenta and Folio = @Folio ), 0),
	Ventas.DctoImp = isnull( (select sum(VentasDetalle.DctoImp) from VentasDetalle where IdCedis = @IdCedis and Serie = @Serie and IdTipoVenta = @IdTipoVenta and Folio = @Folio ), 0)
	where IdCedis = @IdCedis and Serie = @Serie and IdTipoVenta = @IdTipoVenta and Folio = @Folio 

end



GO


