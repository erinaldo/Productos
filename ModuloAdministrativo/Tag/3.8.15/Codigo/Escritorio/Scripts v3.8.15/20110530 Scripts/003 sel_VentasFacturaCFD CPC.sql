USE [RouteCPC]
GO

/****** Object:  StoredProcedure [dbo].[sel_VentasFacturaCFD]    Script Date: 05/30/2011 15:03:15 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sel_VentasFacturaCFD]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sel_VentasFacturaCFD]
GO

USE [RouteCPC]
GO

/****** Object:  StoredProcedure [dbo].[sel_VentasFacturaCFD]    Script Date: 05/30/2011 15:03:15 ******/
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
		select top 1 IdCedis, IdSurtido, IdTipoVenta, Serie, SerieFactura, FolioFactura, TransprodIdFactura, TransprodId  
		from VentasFacturaCFD 
		where IdCedis = @IdCedis and Serie = @Serie and IdTipoVenta = @IdTipoVenta and Folio = @Folio
		order by FolioFactura desc
	
	--if @Actividad = 2
	--	select top 1 IdCedis, IdSurtido, IdTipoVenta, Folio, SerieFactura, FolioFactura, TransprodIdFactura, TransprodId  
	--	from VentasFacturaCFD 
	--	where IdCedis = @IdCedis and IdPedido = @IdSurtido 
	--	order by FolioFactura desc

commit tran
end

if @Opc = 2
begin

begin tran
	
	if @Actividad = 1	
		select top 1 IdCedis, IdSurtido, IdTipoVenta, Folio, SerieFactura, FolioFactura, TransprodIdFactura, TransprodId  
		from VentasFacturaCFD 
		where IdCedis = @IdCedis and IdTipoVenta = @IdTipoVenta and FolioFactura = @Folio and SerieFactura = @Serie 
		order by FolioFactura desc
	
	--if @Actividad = 2
	--	select top 1 IdCedis, IdSurtido, IdTipoVenta, Folio, SerieFactura, FolioFactura, TransprodIdFactura, TransprodId  
	--	from VentasFacturaCFD 
	--	where IdCedis = @IdCedis and IdPedido = @IdSurtido and FolioFactura = @Folio and SerieFactura = @Serie 
	--	order by FolioFactura desc

commit tran
end

if @Opc = 3
begin

begin tran
	
	if @Actividad = 1	
		select top 1 IdCedis, IdSurtido, IdTipoVenta, Folio, SerieFactura, FolioFactura, TransprodIdFactura, TransprodId  
		from VentasFacturaCFD 
		where IdCedis = @IdCedis and IdTipoVenta = @IdTipoVenta and Folio = @Folio and Serie = @Serie 
		order by FolioFactura desc
	
	--if @Actividad = 2
	--	select top 1 IdCedis, IdSurtido, IdTipoVenta, Folio, SerieFactura, FolioFactura, TransprodIdFactura, TransprodId  
	--	from VentasFacturaCFD 
	--	where IdCedis = @IdCedis and IdPedido = @IdSurtido and FolioFactura = @Folio and SerieFactura = @Serie 
	--	order by FolioFactura desc

commit tran
end
GO


