USE [RouteCPC]
GO

/****** Object:  StoredProcedure [dbo].[sel_MovimientosFacturasFolio]    Script Date: 03/01/2011 10:02:01 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sel_MovimientosFacturasFolio]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sel_MovimientosFacturasFolio]
GO

USE [RouteCPC]
GO

/****** Object:  StoredProcedure [dbo].[sel_MovimientosFacturasFolio]    Script Date: 03/01/2011 10:02:01 ******/
SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sel_MovimientosFacturasFolio] 
@IdCedis as bigint,
@IdMovimiento as bigint,
@IdMovimientoDetalle as bigint,
@Opc as int
AS

if @Opc = 1
begin
	select isnull( max(IdMovimientoDetalle)+1,1) 
	from MovimientosFacturas 
	where IdCedis = @IdCedis and IdMovimiento = @IdMovimiento
end

if @Opc = 2
begin
	select IdMovimientoDetalle
	from MovimientosFacturas 
	where IdCedis = @IdCedis and IdMovimiento = @IdMovimiento and IdMovimientoDetalle = @IdMovimientoDetalle 
end

GO


