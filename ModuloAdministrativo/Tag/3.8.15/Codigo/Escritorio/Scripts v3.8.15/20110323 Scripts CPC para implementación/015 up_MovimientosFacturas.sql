USE [RouteCPC]
GO

/****** Object:  StoredProcedure [dbo].[up_MovimientosFacturas]    Script Date: 03/02/2011 13:23:03 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[up_MovimientosFacturas]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[up_MovimientosFacturas]
GO

USE [RouteCPC]
GO

/****** Object:  StoredProcedure [dbo].[up_MovimientosFacturas]    Script Date: 03/02/2011 13:23:03 ******/
SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER OFF
GO

CREATE PROCEDURE [dbo].[up_MovimientosFacturas]
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
@Status as varchar(1),
@Login as varchar(20),
@Opc as int
AS

declare @IdCedisCargoAnt as bigint, @IdMovimientoCargoAnt as bigint, @IdMovimientoDetalleCargoAnt as bigint

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
end

if @Opc = 3 --baja movimiento
begin
	if exists(select * from AnticiposDetalle where IdCedisMov = @IdCedis and IdMovimiento = @IdMovimiento and IdMovimientoDetalle = @IdMovimientoDetalle and Status = 'A' )
	begin
		update MovimientosFacturas set Status = 'B', Login = @Login, FechaEdicion = GETDATE()
		from AnticiposDetalle, MovimientosFacturas 
		where  AnticiposDetalle.IdCedisCargoAnt = MovimientosFacturas.IdCedis and AnticiposDetalle.IdMovimientoCargoAnt = MovimientosFacturas.IdMovimiento 
			and AnticiposDetalle.IdMovimientoDetalleCargoAnt = MovimientosFacturas.IdMovimientoDetalle 
			and AnticiposDetalle.IdCedisMov = @IdCedis and AnticiposDetalle.IdMovimiento = @IdMovimiento and AnticiposDetalle.IdMovimientoDetalle = @IdMovimientoDetalle 
				
		update AnticiposDetalle set Status = 'B', Login = @Login, FechaEdicion = GETDATE()
		where IdCedisMov = @IdCedis and IdMovimiento = @IdMovimiento and IdMovimientoDetalle = @IdMovimientoDetalle 
	end	

	update MovimientosFacturas set Status = 'B', Login = @Login, FechaEdicion = getdate()  where IdCedis = @IdCedis and IdTipoVenta = @IdTipoVenta and Folio  = @Folio and Serie = @Serie and IdMovimiento = @IdMovimiento and IdMovimientoDetalle = @IdMovimientoDetalle
end

if @Opc = 4 --elimina movimiento
begin
	if exists(select * from AnticiposDetalle where IdCedis = @IdCedis and IdTipoVenta = @IdTipoVenta and Serie = @Serie and Folio = @Folio and IdMovimiento = @IdMovimiento and IdMovimientoDetalle = @IdMovimientoDetalle and Status = 'A' )
	begin
		update MovimientosFacturas set Status = 'B', Login = @Login, FechaEdicion = GETDATE()
		from AnticiposDetalle, MovimientosFacturas 
		where  AnticiposDetalle.IdCedisCargoAnt = MovimientosFacturas.IdCedis and AnticiposDetalle.IdMovimientoCargoAnt = MovimientosFacturas.IdMovimiento 
			and AnticiposDetalle.IdMovimientoDetalleCargoAnt = MovimientosFacturas.IdMovimientoDetalle and AnticiposDetalle.Status = 'A'
			and AnticiposDetalle.IdCedisMov = @IdCedis and AnticiposDetalle.IdMovimiento = @IdMovimiento and AnticiposDetalle.IdMovimientoDetalle = @IdMovimientoDetalle 
			and AnticiposDetalle.IdCedis = @IdCedis and AnticiposDetalle.IdTipoVenta = @IdTipoVenta and AnticiposDetalle.Serie = @Serie and AnticiposDetalle.Folio = @Folio 
				
		update AnticiposDetalle set Status = 'B', Login = @Login, FechaEdicion = GETDATE()
		where IdCedisMov = @IdCedis and IdMovimiento = @IdMovimiento and IdMovimientoDetalle = @IdMovimientoDetalle and IdCedis = @IdCedis and IdTipoVenta = @IdTipoVenta and Serie = @Serie and Folio = @Folio 
	end	

	update MovimientosFacturas set Status = 'B', Login = @Login, FechaEdicion = getdate()  where IdCedis = @IdCedis and IdTipoVenta = @IdTipoVenta and Folio  = @Folio and Serie = @Serie and IdMovimiento = @IdMovimiento and IdMovimientoDetalle = @IdMovimientoDetalle
	-- delete from MovimientosFacturas where IdCedis = @IdCedis and IdTipoVenta = @IdTipoVenta and Folio  = @Folio and Serie = @Serie and IdMovimiento = @IdMovimiento and IdMovimientoDetalle = @IdMovimientoDetalle
end

if @Opc = 5 --elimina movimientos de una factura
begin
	
	declare  ActAnticipoDetalle cursor for
		select AnticiposDetalle.IdCedisCargoAnt, AnticiposDetalle.IdMovimientoCargoAnt, AnticiposDetalle.IdMovimientoDetalleCargoAnt
		from AnticiposDetalle, MovimientosFacturas 
		where  AnticiposDetalle.IdCedisCargoAnt = MovimientosFacturas.IdCedis and AnticiposDetalle.IdMovimientoCargoAnt = MovimientosFacturas.IdMovimiento 
			and AnticiposDetalle.IdMovimientoDetalleCargoAnt = MovimientosFacturas.IdMovimientoDetalle and AnticiposDetalle.Status = 'A'
			and AnticiposDetalle.IdCedisMov = @IdCedis and AnticiposDetalle.IdMovimiento = @IdMovimiento -- and AnticiposDetalle.IdMovimientoDetalle = @IdMovimientoDetalle 
			and AnticiposDetalle.IdCedis = @IdCedis and AnticiposDetalle.IdTipoVenta = @IdTipoVenta and AnticiposDetalle.Serie = @Serie and AnticiposDetalle.Folio = @Folio 
	open ActAnticipoDetalle
	
	fetch next from ActAnticipoDetalle into @IdCedisCargoAnt, @IdMovimientoCargoAnt, @IdMovimientoDetalleCargoAnt 
	while (@@fetch_status = 0)
	begin
	
		update MovimientosFacturas set Status = 'B', Login = @Login, FechaEdicion = GETDATE()
		where IdCedis = @IdCedisCargoAnt and IdMovimiento = @IdMovimientoCargoAnt and IdMovimientoDetalle = @IdMovimientoDetalleCargoAnt 

		update AnticiposDetalle set Status = 'B', Login = @Login, FechaEdicion = GETDATE()
		where IdCedisCargoAnt = @IdCedisCargoAnt and IdMovimientoCargoAnt = @IdMovimientoCargoAnt and IdMovimientoDetalleCargoAnt = @IdMovimientoDetalleCargoAnt 

		fetch next from ActAnticipoDetalle into @IdCedisCargoAnt, @IdMovimientoCargoAnt, @IdMovimientoDetalleCargoAnt 
	end
	close ActAnticipoDetalle
	deallocate ActAnticipoDetalle		

	update MovimientosFacturas set Status = 'B' where IdCedis = @IdCedis and IdTipoVenta = @IdTipoVenta and Folio  = @Folio and Serie = @Serie and IdMovimiento = @IdMovimiento
--	delete from MovimientosFacturas 
end

if @Opc = 6 --elimina movimientos de un movimiento
begin

	declare  ActAnticipoDetalle cursor for
		select AnticiposDetalle.IdCedisCargoAnt, AnticiposDetalle.IdMovimientoCargoAnt, AnticiposDetalle.IdMovimientoDetalleCargoAnt
		from AnticiposDetalle, MovimientosFacturas 
		where  AnticiposDetalle.IdCedisCargoAnt = MovimientosFacturas.IdCedis and AnticiposDetalle.IdMovimientoCargoAnt = MovimientosFacturas.IdMovimiento 
			and AnticiposDetalle.IdMovimientoDetalleCargoAnt = MovimientosFacturas.IdMovimientoDetalle and AnticiposDetalle.Status = 'A'
			and AnticiposDetalle.IdCedisMov = @IdCedis and AnticiposDetalle.IdMovimiento = @IdMovimiento -- and AnticiposDetalle.IdMovimientoDetalle = @IdMovimientoDetalle 
	open ActAnticipoDetalle
	
	fetch next from ActAnticipoDetalle into @IdCedisCargoAnt, @IdMovimientoCargoAnt, @IdMovimientoDetalleCargoAnt 
	while (@@fetch_status = 0)
	begin
	
		update MovimientosFacturas set Status = 'B', Login = @Login, FechaEdicion = GETDATE()
		where IdCedis = @IdCedisCargoAnt and IdMovimiento = @IdMovimientoCargoAnt and IdMovimientoDetalle = @IdMovimientoDetalleCargoAnt 

		update AnticiposDetalle set Status = 'B', Login = @Login, FechaEdicion = GETDATE()
		where IdCedisCargoAnt = @IdCedisCargoAnt and IdMovimientoCargoAnt = @IdMovimientoCargoAnt and IdMovimientoDetalleCargoAnt = @IdMovimientoDetalleCargoAnt 

		fetch next from ActAnticipoDetalle into @IdCedisCargoAnt, @IdMovimientoCargoAnt, @IdMovimientoDetalleCargoAnt 
	end
	close ActAnticipoDetalle
	deallocate ActAnticipoDetalle		

	update MovimientosFacturas set Status = 'B'  where IdCedis = @IdCedis and IdMovimiento = @IdMovimiento
--	delete from MovimientosFacturas where IdCedis = @IdCedis and IdMovimiento = @IdMovimiento
end
GO


