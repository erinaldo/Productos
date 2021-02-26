USE [RouteCPC]
GO

/****** Object:  Trigger [dbo].[tr_MovimientosFacturas]    Script Date: 04/13/2010 20:39:09 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER OFF
GO

CREATE TRIGGER [dbo].[tr_MovimientosFacturas] ON [dbo].[MovimientosFacturas] 
FOR INSERT, UPDATE, DELETE 
AS
declare @Tipo as bigint /*, @IdTipoVenta as bigint, @Serie as varchar(5), @Folio  as bigint, @IdMovimiento as bigint*/

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

