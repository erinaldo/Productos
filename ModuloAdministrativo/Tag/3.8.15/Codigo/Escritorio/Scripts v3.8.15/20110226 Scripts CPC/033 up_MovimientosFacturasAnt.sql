USE [RouteCPC]
GO

/****** Object:  StoredProcedure [dbo].[up_MovimientosFacturasAnt]    Script Date: 03/02/2011 13:23:03 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[up_MovimientosFacturasAnt]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[up_MovimientosFacturasAnt]
GO

USE [RouteCPC]
GO

/****** Object:  StoredProcedure [dbo].[up_MovimientosFacturasAnt]    Script Date: 03/02/2011 13:23:03 ******/
SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER OFF
GO

CREATE PROCEDURE [dbo].[up_MovimientosFacturasAnt]
@FolioDetalle as bigint,
@IdCedis as bigint,
@IdTipoVenta as int,
@Serie as varchar(5),
@Folio as bigint,
@IdMovimiento as bigint,
@Fecha as datetime,
@IdMovimientoDetalle as bigint,
@IdDocumento as varchar(5),
@IdTipoDocumento as varchar(5),
@CargoAbono as varchar(1),
@Referencia as varchar(10),
@ReferenciaBancos as varchar(10),
@Subtotal as money,
@Iva as money,
@FolioAnticipo as bigint,
@Status as varchar(1),
@Login as varchar(20),
@Opc as int
AS

declare @IdCedisAnterior as bigint, @IdMovAnterior as bigint, @IdMovDetAnterior as bigint

if @Opc = 1 -- inserta movimiento
begin
	
	if not exists(select * from FolioDetalle where Folio = @FolioDetalle and IdCedis = @IdCedis and IdDocumento = @IdDocumento)
	begin	
		set @IdMovimiento = ( select isnull( max(IdMovimiento)+ 1, 1) from Movimientos where IdCedis = @IdCedis )
		insert into Movimientos values (@IdCedis, @IdMovimiento, @Fecha, @IdDocumento, @CargoAbono, 0, '', '', '', 'P', @Login, getdate() )
		insert into FolioDetalle values (@FolioDetalle, @IdCedis, @IdMovimiento, @IdDocumento, @CargoAbono, 'A', @Login, getdate() )
	end
	else
	begin
		select @FolioDetalle = Folio, @IdMovimiento = IdMovimiento from FolioDetalle where Folio = @FolioDetalle and IdCedis = @IdCedis and IdDocumento = @IdDocumento
	end

	set @IdMovimientoDetalle = isnull( ( select max(IdMovimientoDetalle)+1 from MovimientosFacturas where IdCedis = @IdCedis and IdMovimiento = @IdMovimiento) , 1)
	insert into MovimientosFacturas values (@IdCedis, @IdTipoVenta, @Serie, @Folio, @IdMovimiento, @Fecha, @IdMovimientoDetalle, @IdDocumento, @IdTipoDocumento, @CargoAbono, @Referencia, @ReferenciaBancos, @Subtotal, @Iva, @Status, @Login, getdate() )

	select @IdCedisAnterior = @IdCedis, @IdMovAnterior = @IdMovimiento, @IdMovDetAnterior = @IdMovimientoDetalle 
	insert into AnticiposDetalle values (@FolioAnticipo, @IdCedis, @IdTipoVenta, @Serie, @Folio, @IdCedis, @IdMovimiento, @IdMovimientoDetalle, 0, 0, 0, 'A', @Login, GETDATE())

	select @Serie = IdDocumentoAnticipo, @IdDocumento = IdDocumentoCargoAnt, @IdTipoDocumento = IdTipoDocumentoCargoAnt, @CargoAbono = 'C' from Configuracion 
	select @IdCedis = IdCedis, @IdTipoVenta = IdTipoVenta from Anticipos where FolioAnticipo = @FolioAnticipo 

	if not exists(select * from FolioDetalle where Folio = @FolioDetalle and IdCedis = @IdCedis and IdDocumento = @IdDocumento)
	begin	
		set @IdMovimiento = ( select isnull( max(IdMovimiento)+ 1, 1) from Movimientos where IdCedis = @IdCedis )
		insert into Movimientos values (@IdCedis, @IdMovimiento, @Fecha, @IdDocumento, @CargoAbono, 0, '', '', '', 'P', @Login, getdate() )
		insert into FolioDetalle values (@FolioDetalle, @IdCedis, @IdMovimiento, @IdDocumento, @CargoAbono, 'A', @Login, getdate() )
	end
	else
	begin
		select @FolioDetalle = Folio, @IdMovimiento = IdMovimiento from FolioDetalle where Folio = @FolioDetalle and IdCedis = @IdCedis and IdDocumento = @IdDocumento
	end
	
	set @IdMovimientoDetalle = isnull( ( select max(IdMovimientoDetalle)+1 from MovimientosFacturas where IdCedis = @IdCedis and IdMovimiento = @IdMovimiento) , 1)
	insert into MovimientosFacturas values (@IdCedis, @IdTipoVenta, @Serie, @FolioAnticipo, @IdMovimiento, @Fecha, @IdMovimientoDetalle, @IdDocumento, @IdTipoDocumento, @CargoAbono, @Referencia, @ReferenciaBancos, @Subtotal, @Iva, @Status, @Login, getdate() )

	update AnticiposDetalle set IdCedisCargoAnt = @IdCedis, IdMovimientoCargoAnt = @IdMovimiento, IdMovimientoDetalleCargoAnt = @IdMovimientoDetalle
	where IdCedisMov = @IdCedisAnterior and IdMovimiento = @IdMovAnterior and IdMovimientoDetalle = @IdMovDetAnterior 
end

if @Opc = 3 --baja movimiento
begin
	update MovimientosFacturas set Status = 'B', Login = @Login, FechaEdicion = getdate()  where IdCedis = @IdCedis and IdTipoVenta = @IdTipoVenta and Folio  = @Folio and Serie = @Serie and IdMovimiento = @IdMovimiento and IdMovimientoDetalle = @IdMovimientoDetalle
end

if @Opc = 4 --elimina movimiento
begin
	update MovimientosFacturas set Status = 'B', Login = @Login, FechaEdicion = getdate()  where IdCedis = @IdCedis and IdTipoVenta = @IdTipoVenta and Folio  = @Folio and Serie = @Serie and IdMovimiento = @IdMovimiento and IdMovimientoDetalle = @IdMovimientoDetalle
	-- delete from MovimientosFacturas where IdCedis = @IdCedis and IdTipoVenta = @IdTipoVenta and Folio  = @Folio and Serie = @Serie and IdMovimiento = @IdMovimiento and IdMovimientoDetalle = @IdMovimientoDetalle
end

if @Opc = 5 --elimina movimientos de una factura
begin
	update MovimientosFacturas set Status = 'B' where IdCedis = @IdCedis and IdTipoVenta = @IdTipoVenta and Folio  = @Folio and Serie = @Serie and IdMovimiento = @IdMovimiento
--	delete from MovimientosFacturas 
end

if @Opc = 6 --elimina movimientos de un movimiento
begin
	update MovimientosFacturas set Status = 'B'  where IdCedis = @IdCedis and IdMovimiento = @IdMovimiento
--	delete from MovimientosFacturas where IdCedis = @IdCedis and IdMovimiento = @IdMovimiento
end

GO


