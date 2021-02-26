USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[sel_VentasFacturaCFD]    Script Date: 05/04/2011 21:14:42 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sel_VentasFacturaCFD]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sel_VentasFacturaCFD]
GO

USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[sel_VentasFacturaCFD]    Script Date: 05/04/2011 21:14:42 ******/
SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER OFF
GO





CREATE PROCEDURE [dbo].[sel_VentasFacturaCFD]
@IdCedis as bigint,
@IdSurtido as bigint,
@IdTipoVenta as int,
@Serie as varchar(6),
@Folio as bigint,
@Opc as int

AS

if @Opc = 1
begin

begin tran
	
	select top 1 IdCedis, IdSurtido, IdTipoVenta, Folio, SerieFactura, FolioFactura, TransprodIdFactura, TransprodId  
	from VentasFacturaCFD 
	where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdTipoVenta = @IdTipoVenta and Folio = @Folio
	order by FolioFactura desc
	
commit tran
end

if @Opc = 2
begin

begin tran
	
	select top 1 IdCedis, IdSurtido, IdTipoVenta, Folio, SerieFactura, FolioFactura, TransprodIdFactura, TransprodId  
	from VentasFacturaCFD 
	where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdTipoVenta = @IdTipoVenta and FolioFactura = @Folio and SerieFactura = @Serie 
	order by FolioFactura desc
	
commit tran
end
GO


