USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[sel_VentasRoute]    Script Date: 05/31/2011 13:52:32 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sel_VentasRoute]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sel_VentasRoute]
GO

USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[sel_VentasRoute]    Script Date: 05/31/2011 13:52:32 ******/
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
	select IdCedis, IdSurtido, IdTipoVenta, case when SerieFactura is null then Folio else FolioFactura end as Folio, 
	case when SerieFactura is null then Serie else SerieFactura end as Serie, Fecha, IdCliente, IdSucursal
	from VentasRoute
	where VentasRoute.IdCedis = @IdCedis and VentasRoute.IdSurtido = @IdSurtido 

if @Opc = 2
	select IdCedis, IdSurtido, IdTipoVenta, case when SerieFactura is null then Folio else FolioFactura end as Folio, 
	case when SerieFactura is null then Serie else SerieFactura end as Serie, Fecha, IdCliente, IdSucursal
	from VentasRoute
	where VentasRoute.IdCedis = @IdCedis and VentasRoute.IdSurtido = @IdSurtido and IdTipoVenta = @IdTipoVenta and Folio = @Folio 




GO


