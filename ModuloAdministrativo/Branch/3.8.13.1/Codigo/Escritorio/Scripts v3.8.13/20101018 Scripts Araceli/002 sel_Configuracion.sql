USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[sel_Configuracion]    Script Date: 10/18/2010 09:58:52 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sel_Configuracion]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sel_Configuracion]
GO

USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[sel_Configuracion]    Script Date: 10/18/2010 09:58:52 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




CREATE PROCEDURE [dbo].[sel_Configuracion]
@IdCedis as bigint,
@Opc as int

AS
if @Opc = 1
	select Cedis.IdCedis, Cedis.Cedis, Route, ImportarCargaSugerida, Etiqueta01, Etiqueta02, 
		RFC, RazonSocial, Direccion, CPC, 
		LiquidacionComisiones, LiquidacionEfectivo, LiquidacionSaldoVendedor, LiquidacionSaldoClientes, LiquidacionSaldoEnvase,
		SQLConn, RepCreditosCobranza, Descuentos, ReporteFactura
	from Cedis 
	inner join configuracion on configuracion.idcedis = cedis.idcedis 
	where Cedis.IdCedis = @IdCedis


GO

