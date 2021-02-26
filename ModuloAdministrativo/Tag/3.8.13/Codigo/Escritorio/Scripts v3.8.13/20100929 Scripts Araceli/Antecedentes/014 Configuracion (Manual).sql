
alter table Configuracion
add RepCreditosCobranza bit null
GO

update Configuracion set RepCreditosCobranza =0 
GO

--- Cambiar nombres de columnas en tabla Configuracion 
--- FolioInicialRoute = UsuarioTerminal
--- IPRoute = SQLConn

update Configuracion set usuarioterminal = 0, SQLConn = ''
GO

USE [RouteADM]
GO
/****** Object:  StoredProcedure [dbo].[sel_Configuracion]    Script Date: 09/21/2010 09:41:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



ALTER PROCEDURE [dbo].[sel_Configuracion]
@IdCedis as bigint,
@Opc as int

AS
if @Opc = 1
	select Cedis.IdCedis, Cedis.Cedis, Route, ImportarCargaSugerida, Etiqueta01, Etiqueta02, 
		RFC, RazonSocial, Direccion, CPC, 
		LiquidacionComisiones, LiquidacionEfectivo, LiquidacionSaldoVendedor, LiquidacionSaldoClientes, LiquidacionSaldoEnvase,
		SQLConn, RepCreditosCobranza
	from Cedis 
	inner join configuracion on configuracion.idcedis = cedis.idcedis 
	where Cedis.IdCedis = @IdCedis

