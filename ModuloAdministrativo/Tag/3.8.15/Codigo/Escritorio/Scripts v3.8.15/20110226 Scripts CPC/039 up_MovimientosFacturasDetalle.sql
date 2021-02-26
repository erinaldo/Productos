USE [RouteCPC]
GO

/****** Object:  StoredProcedure [dbo].[up_MovimientosFacturasDetalle]    Script Date: 03/02/2011 13:23:03 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[up_MovimientosFacturasDetalle]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[up_MovimientosFacturasDetalle]
GO

USE [RouteCPC]
GO

/****** Object:  StoredProcedure [dbo].[up_MovimientosFacturasDetalle]    Script Date: 03/02/2011 13:23:03 ******/
SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER OFF
GO

CREATE PROCEDURE [dbo].[up_MovimientosFacturasDetalle]
@IdCedis as bigint,
@IdTipoVenta as int,
@Serie as varchar(5),
@Folio as bigint,
@IdMovimiento as bigint,
@IdMovimientoDetalle as bigint,
@IdDocumento as varchar(5),
@IdTipoDocumento as varchar(5),
@IdProducto as varchar(200),
@Producto as varchar(200),
@Precio as money,
@Status as varchar(1),
@Login as varchar(20),
@Opc as int
AS

declare @IdImpuesto as bigint, @Tasa as float

if @Opc = 1 -- inserta movimiento
begin
	
	if exists(select * from MovimientosFacturasDetalle where IdCedis = @IdCedis and IdTipoVenta = @IdTipoVenta and Serie = @Serie and Folio = @Folio
		and IdMovimiento = @IdMovimiento and IdMovimientoDetalle = @IdMovimientoDetalle and IdDocumento = @IdDocumento and IdTipoDocumento = @IdTipoDocumento )
	begin
		delete from MovimientosFacturasDetalle where IdCedis = @IdCedis and IdTipoVenta = @IdTipoVenta and Serie = @Serie and Folio = @Folio
		and IdMovimiento = @IdMovimiento and IdMovimientoDetalle = @IdMovimientoDetalle and IdDocumento = @IdDocumento and IdTipoDocumento = @IdTipoDocumento 

		delete from MovimientosFacturasImpuestos where IdCedis = @IdCedis and IdTipoVenta = @IdTipoVenta and Serie = @Serie and Folio = @Folio
		and IdMovimiento = @IdMovimiento and IdMovimientoDetalle = @IdMovimientoDetalle and IdDocumento = @IdDocumento and IdTipoDocumento = @IdTipoDocumento 
	end

	insert into MovimientosFacturasDetalle values (@IdCedis, @IdTipoVenta, @Serie, @Folio, @IdMovimiento, @IdMovimientoDetalle, @IdDocumento, @IdTipoDocumento, @IdProducto, @Producto, 1, 0, 0, 'A', @Login, GETDATE())	

select * from MovimientosFacturasDetalle 

select * 
from VentasImpuestos 
where IdCedis = @IdCedis and IdTipoVenta = @IdTipoVenta and Serie = @Serie and Folio = @Folio 



	--insert into MovimientosFacturasImpuestos values (@IdCedis, @IdTipoVenta, @Serie, @Folio, @IdMovimiento, @IdMovimientoDetalle, @IdDocumento, @IdTipoDocumento, @IdProducto, @IdImpuesto, @Tasa, @Login, GETDATE())	
	
end

GO


