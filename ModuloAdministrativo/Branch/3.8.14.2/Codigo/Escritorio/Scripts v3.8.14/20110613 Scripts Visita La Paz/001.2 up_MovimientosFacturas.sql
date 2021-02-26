USE [RouteCPC]
GO

/****** Object:  StoredProcedure [dbo].[up_Movimientos]    Script Date: 06/14/2011 14:49:17 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[up_Movimientos]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[up_Movimientos]
GO

USE [RouteCPC]
GO

/****** Object:  StoredProcedure [dbo].[up_Movimientos]    Script Date: 06/14/2011 14:49:17 ******/
SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER OFF
GO


CREATE PROCEDURE [dbo].[up_Movimientos]
@IdCedis as bigint,
@IdMovimiento as bigint,
@Fecha as datetime,
@IdDocumento as varchar(5),
@CargoAbono as varchar(1),
@Monto as money,
@Referencia as varchar(10),
@ReferenciaBancos as varchar(10),
@Observaciones as varchar(2000),
@Status as varchar(1),
@Login as varchar(20),
@Opc as int
AS

declare 
@Periodo as int
set @Periodo = isnull( (select idcedis from periodos where idcedis = @IdCedis and agno = year(@Fecha) and periodo = month(@Fecha) and status = 'A'), 0)

if @Opc = 1 and @Periodo >= 1-- inserta movimiento
begin
	-- set @IdMovimiento = ( select isnull( max(IdMovimiento)+ 1, 1) from Movimientos where IdCedis = @IdCedis )
	insert into Movimientos values (@IdCedis, @IdMovimiento, @Fecha, @IdDocumento, @CargoAbono, 0, @Referencia, @ReferenciaBancos, @Observaciones, 'P', @Login, getdate() )
end

if @Opc = 3  and @Periodo >= 1--baja movimiento
begin
	update MovimientosFacturas set Status = 'B', Login = @Login, FechaEdicion = getdate()  where IdMovimiento = @IdMovimiento and IdCedis = @IdCedis
	update Movimientos set Status = 'B', Login = @Login, FechaEdicion = getdate()  where IdMovimiento = @IdMovimiento and IdCedis = @IdCedis
	exec up_actualizasaldo @IdCedis, 2
end

if @Opc = 4 -- and @Periodo >= 1--elimina movimiento
begin
	update Movimientos set Status = 'B', FechaEdicion = getdate(), Login = @Login where IdMovimiento = @IdMovimiento and IdCedis = @IdCedis
	-- delete from Movimientos where IdMovimiento = @IdMovimiento and IdCedis = @IdCedis
end

if @Opc = 5  -- and @Periodo >= 1--Aplica
begin
	update Movimientos set Status = 'A', Login = @Login, FechaEdicion = getdate()  where IdMovimiento = @IdMovimiento and IdCedis = @IdCedis
	exec up_actualizasaldo @IdCedis, 2

	-- Abono en Route
	insert into Route.dbo.tmp_AbonoFactura 
	select distinct MOVF.Serie + REPLICATE('0', 7-len(MOVF.Folio)) + CAST( MOVF.Folio as varchar(10)) as Folio, 
	REPLICATE('0', 2-len(MOVF.IdCedis)) + CAST( MOVF.IdCedis as varchar(10)) + REPLICATE('0', 6-len(MOVF.IdMovimiento)) + CAST( MOVF.IdMovimiento as varchar(10)) + REPLICATE('0', 6-len(MOVF.IdMovimientoDetalle)) + CAST( MOVF.IdMovimientoDetalle as varchar(10)) as FolioAbono,
	MOV.Fecha, MOVF.Total, 1, '10000'
	from Movimientos MOV 
	inner join MovimientosFacturas MOVF on MOV.IdCedis = MOVF.IdCedis and MOV.IdMovimiento = MOVF.IdMovimiento 
		and MOVF.Status = 'A' and MOVF.Serie + REPLICATE('0', 7-len(MOVF.Folio)) + CAST( MOVF.Folio as varchar(10)) in (
		select Folio from Route.dbo.TransProd where Tipo = 8 and TipoFase = 1
		)
	where MOV.IdCedis = @IdCedis and MOV.Status = 'A' and MOV.IdDocumento <> 'CT' and MOV.IdMovimiento = @IdMovimiento 
		and REPLICATE('0', 2-len(MOVF.IdCedis)) + CAST( MOVF.IdCedis as varchar(10)) + REPLICATE('0', 6-len(MOVF.IdMovimiento)) + CAST( MOVF.IdMovimiento as varchar(10)) + REPLICATE('0', 6-len(MOVF.IdMovimientoDetalle)) + CAST( MOVF.IdMovimientoDetalle as varchar(10))
			not in (select FolioAbono from Route.dbo.tmp_AbonoFactura )
	
end

GO


