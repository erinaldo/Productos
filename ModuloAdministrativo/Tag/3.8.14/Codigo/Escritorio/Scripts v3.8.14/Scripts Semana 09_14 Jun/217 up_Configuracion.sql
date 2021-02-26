USE [RouteADM]
GO
/****** Object:  StoredProcedure [dbo].[up_Configuracion]    Script Date: 06/09/2010 17:28:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




ALTER PROCEDURE [dbo].[up_Configuracion]
@IdCedis as bigint,
@LiquidacionComisiones as char(1),
@LiquidacionEfectivo as char(1),
@LiquidacionSaldoVendedor as char(1),
@LiquidacionSaldoClientes as char(1),
@LiquidacionSaldoEnvase as char(1),
@Opc as int

AS
if @Opc = 1
	update Configuracion
	set LiquidacionComisiones = @LiquidacionComisiones,
		LiquidacionEfectivo = @LiquidacionEfectivo,
		LiquidacionSaldoVendedor = @LiquidacionSaldoVendedor,
		LiquidacionSaldoClientes = @LiquidacionSaldoClientes,
		LiquidacionSaldoEnvase = @LiquidacionSaldoEnvase
	where IdCedis = @IdCedis


