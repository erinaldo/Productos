USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[sel_VentasFacturaCFD]    Script Date: 06/27/2011 15:55:01 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sel_VentasFacturaCFD]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sel_VentasFacturaCFD]
GO

USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[sel_VentasFacturaCFD]    Script Date: 06/27/2011 15:55:01 ******/
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
@Actividad as int,
@Opc as int

AS

if @Opc = 1
begin
begin tran
	
	if @Actividad = 1	
		select top 1 IdCedis, IdSurtido, IdTipoVenta, VentasFacturaCFD.Folio, SerieFactura, FolioFactura, TransprodIdFactura, VentasFacturaCFD.TransprodId, UUID, Trp.TipoFase   
		from VentasFacturaCFD 
		left outer join Route.dbo.TransProd Trp on Trp.TransProdID = VentasFacturaCFD.TransprodIdFactura 
		where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdTipoVenta = @IdTipoVenta and VentasFacturaCFD.Folio = @Folio
		order by FolioFactura desc
	
	if @Actividad = 2
		select top 1 IdCedis, IdSurtido, IdTipoVenta, VentasFacturaCFD.Folio, SerieFactura, FolioFactura, TransprodIdFactura, VentasFacturaCFD.TransprodId, UUID, Trp.TipoFase   
		from VentasFacturaCFD 
		left outer join Route.dbo.TransProd Trp on Trp.TransProdID = VentasFacturaCFD.TransprodIdFactura 
		where IdCedis = @IdCedis and IdPedido = @IdSurtido 
		order by FolioFactura desc

commit tran
end

if @Opc = 2
begin

begin tran
	
	if @Actividad = 1	
		select top 1 IdCedis, IdSurtido, IdTipoVenta, VentasFacturaCFD.Folio, SerieFactura, FolioFactura, TransprodIdFactura, VentasFacturaCFD.TransprodId, UUID, Trp.TipoFase  
		from VentasFacturaCFD 
		left outer join Route.dbo.TransProd Trp on Trp.TransProdID = VentasFacturaCFD.TransprodIdFactura 
		where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdTipoVenta = @IdTipoVenta and FolioFactura = @Folio and SerieFactura = @Serie 
		order by FolioFactura desc
	
	if @Actividad = 2
		select top 1 IdCedis, IdSurtido, IdTipoVenta, VentasFacturaCFD.Folio, SerieFactura, FolioFactura, TransprodIdFactura, VentasFacturaCFD.TransprodId, UUID, Trp.TipoFase  
		from VentasFacturaCFD 
		left outer join Route.dbo.TransProd Trp on Trp.TransProdID = VentasFacturaCFD.TransprodIdFactura 
		where IdCedis = @IdCedis and IdPedido = @IdSurtido and FolioFactura = @Folio and SerieFactura = @Serie 
		order by FolioFactura desc

commit tran
end

GO


