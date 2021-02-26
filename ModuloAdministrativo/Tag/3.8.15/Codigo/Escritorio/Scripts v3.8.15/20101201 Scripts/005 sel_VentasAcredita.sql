USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[sel_VentasAcredita]    Script Date: 12/02/2010 11:38:39 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sel_VentasAcredita]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sel_VentasAcredita]
GO

USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[sel_VentasAcredita]    Script Date: 12/02/2010 11:38:39 ******/
SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER OFF
GO




CREATE PROCEDURE [dbo].[sel_VentasAcredita] 
@IdCedis as bigint,
@IdSurtido as bigint,
@IdTipoVenta as bigint,
@Serie as varchar(5),
@Folio as bigint,
@Opc as int

AS

if @Opc = 1
	select IdCedis, IdSurtido, FechaAcredita, Login, FechaEntrega, FolioEntrega, Observaciones, FolioCliente, Remision, Factura, Status  
	from VentasAcredita 
	where VentasAcredita.IdCedis = @IdCedis and VentasAcredita.IdSurtido = @IdSurtido and VentasAcredita.IdTipoVenta = @IdTipoVenta 
		and VentasAcredita.Serie = @Serie and VentasAcredita.Folio = @Folio 


GO


