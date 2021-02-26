USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[sel_VentasRoute]    Script Date: 10/01/2010 11:38:34 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sel_VentasRoute]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sel_VentasRoute]
GO

USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[sel_VentasRoute]    Script Date: 10/01/2010 11:38:34 ******/
SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER OFF
GO





CREATE PROCEDURE [dbo].[sel_VentasRoute] 
@IdCedis as bigint,
@IdSurtido as bigint,
@IdTipoVenta as bigint,
@Folio as bigint,
@Opc as int

AS

if @Opc = 1
	select IdCedis, IdSurtido, IdTipoVenta, Folio, Serie, Fecha, IdCliente, IdSucursal, Consigna 
	from VentasRoute
	where VentasRoute.IdCedis = @IdCedis and VentasRoute.IdSurtido = @IdSurtido 

if @Opc = 2
	select IdCedis, IdSurtido, IdTipoVenta, Folio, Serie, Fecha, IdCliente, IdSucursal, Consigna 
	from VentasRoute
	where VentasRoute.IdCedis = @IdCedis and VentasRoute.IdSurtido = @IdSurtido and IdTipoVenta = @IdTipoVenta and Folio = @Folio 


GO


