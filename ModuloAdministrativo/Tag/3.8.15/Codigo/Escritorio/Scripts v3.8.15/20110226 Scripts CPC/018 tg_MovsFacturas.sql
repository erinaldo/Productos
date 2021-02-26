USE [RouteCPC]
GO

/****** Object:  Trigger [tr_MovimientosFacturas]    Script Date: 03/03/2011 12:28:39 ******/
IF  EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[dbo].[tr_MovimientosFacturas]'))
DROP TRIGGER [dbo].[tr_MovimientosFacturas]
GO

USE [RouteCPC]
GO

/****** Object:  Trigger [dbo].[tr_MovimientosFacturas]    Script Date: 03/03/2011 12:28:40 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER OFF
GO

CREATE TRIGGER [dbo].[tr_MovimientosFacturas] ON [dbo].[MovimientosFacturas] 
FOR INSERT, UPDATE, DELETE 
AS
declare @Tipo as bigint, @Folio as bigint, @IdDocumentoAnt as varchar(5), @IdDocumentoCargoAnt as varchar(5), @IdTipoDocumentoCargoAnt as varchar(5)

set @Tipo = 0
set @Tipo = isnull( (select top 1 IdCedis from inserted ), 0)

if @Tipo = 0 -- deleted 
begin
	update Ventas set Cargos =  ( select isnull( sum(Total), 0)   from MovimientosFacturas
			where MovimientosFacturas.IdCedis = Ventas.IdCedis and MovimientosFacturas.IdTipoVenta = Ventas.IdTipoVenta
			and MovimientosFacturas.Serie = Ventas.Serie and MovimientosFacturas.Folio = Ventas.Folio and Status <> 'B' and CargoAbono = 'C') , 
	Abonos =  ( select isnull( sum(Total), 0)   from MovimientosFacturas
			where MovimientosFacturas.IdCedis = Ventas.IdCedis and MovimientosFacturas.IdTipoVenta = Ventas.IdTipoVenta
			and MovimientosFacturas.Serie = Ventas.Serie and MovimientosFacturas.Folio = Ventas.Folio and Status <> 'B' and CargoAbono = 'A') 
	where Ventas.IDCedis in (
		select IdCedis from deleted where deleted.idcedis = Ventas.IdCedis and Ventas.IdTipoVenta = deleted.idtipoventa and Ventas.Serie =  deleted.Serie and Ventas.Folio = deleted.Folio )
	
	update Movimientos set Monto = ( select isnull( sum(Total), 0)   from MovimientosFacturas
			where MovimientosFacturas.IdCedis = Movimientos.IdCedis and MovimientosFacturas.IdMovimiento = Movimientos.IdMovimiento and MovimientosFacturas.Status <> 'B' ) -- and CargoAbono = 'C') 
	where Movimientos.IDCedis in (
		select IdCedis from deleted where Movimientos.idcedis = deleted.IdCedis and Movimientos.IdMovimiento = deleted.idMovimiento)
	
	update Folio set Monto = isnull(
		(select SUM(MovimientosFacturas.Total)
		from FolioDetalle, MovimientosFacturas 
		where FolioDetalle.IdCedis = MovimientosFacturas.IdCedis and MovimientosFacturas.IdMovimiento = FolioDetalle.IdMovimiento 
			and MovimientosFacturas.Status = 'A' and Folio.Folio = FolioDetalle.Folio and FolioDetalle.Folio in ( select distinct FD.Folio
				from FolioDetalle FD
				inner join deleted on FD.IdCedis = deleted.IdCedis and deleted.IdMovimiento = FD.IdMovimiento)),0)
	where Folio in ( select distinct FD.Folio
				from FolioDetalle FD
				inner join deleted on FD.IdCedis = deleted.IdCedis and deleted.IdMovimiento = FD.IdMovimiento)

	update Anticipos set Saldo = Ventas.saldo * -1
	from Anticipos, deleted, Ventas
	where Anticipos.IdCedis = deleted.IdCedis and Anticipos.IdTipoVenta = deleted.IdTipoVenta
		and Anticipos.Serie = deleted.Serie and Anticipos.FolioAnticipo = deleted.Folio
		and Ventas.IdCedis = deleted.IdCedis and Ventas.IdTipoVenta = deleted.IdTipoVenta
		and Ventas.Serie = deleted.Serie and Ventas.Folio = deleted.Folio
	
end
else  -- inserted
begin
	update Ventas set Cargos =  ( select isnull( sum(Total), 0)   from MovimientosFacturas
			where MovimientosFacturas.IdCedis = Ventas.IdCedis and MovimientosFacturas.IdTipoVenta = Ventas.IdTipoVenta
			and MovimientosFacturas.Serie = Ventas.Serie and MovimientosFacturas.Folio = Ventas.Folio and Status <> 'B' and CargoAbono = 'C') , 
	Abonos =  ( select isnull( sum(Total), 0)   from MovimientosFacturas
			where MovimientosFacturas.IdCedis = Ventas.IdCedis and MovimientosFacturas.IdTipoVenta = Ventas.IdTipoVenta
			and MovimientosFacturas.Serie = Ventas.Serie and MovimientosFacturas.Folio = Ventas.Folio and Status <> 'B' and CargoAbono = 'A') 
	where Ventas.IDCedis in (
		select IdCedis from inserted where inserted.idcedis = Ventas.IdCedis and Ventas.IdTipoVenta = inserted.idtipoventa and Ventas.Serie =  inserted.Serie and Ventas.Folio = inserted.Folio )
	
	update Movimientos set Monto = ( select isnull( sum(Total), 0)   from MovimientosFacturas
			where MovimientosFacturas.IdCedis = Movimientos.IdCedis and MovimientosFacturas.IdMovimiento = Movimientos.IdMovimiento and MovimientosFacturas.Status <> 'B' ) -- and CargoAbono = 'C') 
	where Movimientos.IDCedis in (
		select IdCedis from inserted where Movimientos.idcedis = inserted.IdCedis and Movimientos.IdMovimiento = inserted.idMovimiento)

	update Folio set Monto = isnull(
		(select SUM(MovimientosFacturas.Total)
		from FolioDetalle, MovimientosFacturas 
		where FolioDetalle.IdCedis = MovimientosFacturas.IdCedis and MovimientosFacturas.IdMovimiento = FolioDetalle.IdMovimiento 
			and MovimientosFacturas.Status = 'A' and Folio.Folio = FolioDetalle.Folio and FolioDetalle.Folio in ( select distinct FD.Folio
				from FolioDetalle FD
				inner join inserted on FD.IdCedis = inserted.IdCedis and inserted.IdMovimiento = FD.IdMovimiento)),0)
	where Folio in ( select distinct FD.Folio
				from FolioDetalle FD
				inner join inserted on FD.IdCedis = inserted.IdCedis and inserted.IdMovimiento = FD.IdMovimiento)

	update Anticipos set Saldo = Ventas.saldo * -1
	from Anticipos, inserted, Ventas
	where Anticipos.IdCedis = inserted.IdCedis and Anticipos.IdTipoVenta = inserted.IdTipoVenta
		and Anticipos.Serie = inserted.Serie and Anticipos.FolioAnticipo = inserted.Folio
		and Ventas.IdCedis = inserted.IdCedis and Ventas.IdTipoVenta = inserted.IdTipoVenta
		and Ventas.Serie = inserted.Serie and Ventas.Folio = inserted.Folio

/*	update Anticipos set Saldo = Importe - isnull((	select SUM(MovimientosFacturas.Total)
	from MovimientosFacturas, inserted, Configuracion
	where MovimientosFacturas.IdCedis = inserted.IdCedis and MovimientosFacturas.IdTipoVenta = inserted.IdTipoVenta 
		and MovimientosFacturas.Serie = inserted.Serie and MovimientosFacturas.Folio = inserted.folio
		and MovimientosFacturas.Status = 'A' and MovimientosFacturas.IdDocumento = Configuracion.IdDocumentoCargoAnt
		and MovimientosFacturas.IdTipoDocumento = Configuracion.IdTipoDocumentoCargoAnt
		and Configuracion.IdDocumentoAnticipo = inserted.Serie),0) */
end


/*
set @IdMovimiento = (select top 1 IdMovimiento from inserted )
if @IdMovimiento is null set @IdMovimiento = isnull( (select top 1 IdMovimiento from deleted), 0)

set @IdTipoVenta = (select top 1 IdTipoVenta from inserted)
if @IdTipoVenta is null set @IdTipoVenta = isnull( (select top 1 IdTipoVenta from deleted), 0)

set @Serie = (select top 1 Serie from inserted)
if @Serie is null set @Serie = isnull( (select top 1 Serie from deleted), 0)

set @Folio = (select top 1 Folio from inserted)
if @Folio is null set @Folio = isnull( (select top 1 Folio from deleted), 0)

update Ventas set Cargos =  ( select isnull( sum(Total), 0)   from MovimientosFacturas
		where MovimientosFacturas.IdCedis = Ventas.IdCedis and MovimientosFacturas.IdTipoVenta = Ventas.IdTipoVenta
		and MovimientosFacturas.Serie = Ventas.Serie and MovimientosFacturas.Folio = Ventas.Folio and Status = 'A' and CargoAbono = 'C') , 

Abonos =  ( select isnull( sum(Total), 0)   from MovimientosFacturas

		where MovimientosFacturas.IdCedis = Ventas.IdCedis and MovimientosFacturas.IdTipoVenta = Ventas.IdTipoVenta
		and MovimientosFacturas.Serie = Ventas.Serie and MovimientosFacturas.Folio = Ventas.Folio and Status = 'A' and CargoAbono = 'A') 

where Ventas.IDCedis = @IdCedis and Ventas.IdTipoVenta = @IdTipoVenta and Ventas.Serie =  @Serie and Ventas.Folio = @Folio

update Movimientos set Monto = ( select isnull( sum(Total), 0)   from MovimientosFacturas
		where MovimientosFacturas.IdCedis = Movimientos.IdCedis and MovimientosFacturas.IdMovimiento = Movimientos.IdMovimiento and MovimientosFacturas.Status = 'A' ) -- and CargoAbono = 'C') 
where Movimientos.IDCedis = @IdCedis and Movimientos.IdMovimiento = @IdMovimiento 

*/

GO


