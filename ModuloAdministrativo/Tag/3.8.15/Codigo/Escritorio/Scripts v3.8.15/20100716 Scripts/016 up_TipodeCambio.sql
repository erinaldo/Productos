USE [RouteADM]
GO
/****** Object:  StoredProcedure [dbo].[up_TipoDeCambio]    Script Date: 07/14/2010 09:51:15 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
ALTER PROCEDURE [dbo].[up_TipoDeCambio] 
@IdCedis as bigint,
@Fecha as datetime,
@IdMonedaBase as varchar(5),
@IdMoneda as varchar(5),
@TipoDeCambio as money,
@Opc as int
AS

if @Opc = 1
begin

	delete from TipoDeCambio where IdMonedaBase = @IdMonedaBase and IdMoneda = @IdMoneda and Fecha = @Fecha
	if @TipoDeCambio > 0
		insert into TipoDeCambio values (@Fecha, @IdMonedaBase, @IdMoneda, @TipoDeCambio)
end