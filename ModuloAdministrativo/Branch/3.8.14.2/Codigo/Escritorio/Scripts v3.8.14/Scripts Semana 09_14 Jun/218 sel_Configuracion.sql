set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go




ALTER PROCEDURE [dbo].[sel_Configuracion]
@IdCedis as bigint,
@Opc as int

AS
if @Opc = 1
	select Cedis.IdCedis, Cedis.Cedis, Route, ImportarCargaSugerida, Etiqueta01, Etiqueta02, 
		RFC, RazonSocial, Direccion, CPC, 
		LiquidacionComisiones, LiquidacionEfectivo, LiquidacionSaldoVendedor, LiquidacionSaldoClientes, LiquidacionSaldoEnvase
	from Cedis 
	inner join configuracion on configuracion.idcedis = cedis.idcedis 
	where Cedis.IdCedis = @IdCedis


