USE [RouteCPC]
GO

/****** Object:  StoredProcedure [dbo].[up_Folio]    Script Date: 03/01/2011 09:31:03 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[up_Folio]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[up_Folio]
GO

USE [RouteCPC]
GO

/****** Object:  StoredProcedure [dbo].[up_Folio]    Script Date: 03/01/2011 09:31:03 ******/
SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER OFF
GO

CREATE PROCEDURE [dbo].[up_Folio]
@Folio as bigint,
@Fecha as datetime,
@Monto as money,
@Observaciones as varchar(2000),
@Status as varchar(1),
@Login as varchar(20),
@Opc as int
AS

if @Opc = 1 -- inserta folio
begin
	--set @Folio = ( select isnull( max(Folio)+ 1, 1) from Folio )
	insert into Folio values (@Folio, @Fecha, 0, @Observaciones, @Status, @Login, getdate() )
end

if @Opc = 3  --baja folio
begin
	update Folio set Status = 'B', Login = @Login, FechaEdicion = getdate()  where Folio = @Folio
	update FolioDetalle set Status = 'B', Login = @Login, FechaEdicion = getdate()  where Folio = @Folio
	
	update MovimientosFacturas set Status = 'B', Login = @Login, FechaEdicion = getdate() 
	from FolioDetalle FD, MovimientosFacturas MOVF
	where FD.IdCedis = MOVF.IdCedis and FD.IdMovimiento = MOVF.IdMovimiento and FD.Folio = @Folio 

	update Movimientos set Status = 'B', Login = @Login, FechaEdicion = getdate() 
	from FolioDetalle FD, Movimientos MOV
	where FD.IdCedis = MOV.IdCedis and FD.IdMovimiento = MOV.IdMovimiento and FD.Folio = @Folio 
	
end

if @Opc = 4 -- elimina movimiento
begin
	update Folio set Status = 'B', FechaEdicion = getdate(), Login = @Login where Folio = @Folio 
	update FolioDetalle set Status = 'B', Login = @Login, FechaEdicion = getdate()  where Folio = @Folio
	
	update MovimientosFacturas set Status = 'B', Login = @Login, FechaEdicion = getdate() 
	from FolioDetalle FD, MovimientosFacturas MOVF
	where FD.IdCedis = MOVF.IdCedis and FD.IdMovimiento = MOVF.IdMovimiento and FD.Folio = @Folio 

	update Movimientos set Status = 'B', Login = @Login, FechaEdicion = getdate() 
	from FolioDetalle FD, Movimientos MOV
	where FD.IdCedis = MOV.IdCedis and FD.IdMovimiento = MOV.IdMovimiento and FD.Folio = @Folio 
end

if @Opc = 5  -- Aplica
begin
	update Folio set Status = 'A', Login = @Login, FechaEdicion = getdate()  where Folio = @Folio 

	update Movimientos set Status = 'A', Login = @Login, FechaEdicion = getdate() 
	from FolioDetalle FD, Movimientos MOV
	where FD.IdCedis = MOV.IdCedis and FD.IdMovimiento = MOV.IdMovimiento and FD.Folio = @Folio 
end
GO


