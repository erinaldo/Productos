USE [RouteCPC]
GO

/****** Object:  Trigger [dbo].[tr_FacturasOxxo]    Script Date: 06/08/2010 18:02:55 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER OFF
GO

CREATE TRIGGER [dbo].[tr_FacturasOxxo] ON [dbo].[FacturasOxxo] 
FOR INSERT, UPDATE, DELETE 
AS
declare @IdCedisOX as bigint, @IdTipoVentaOX as bigint, @SerieOX as varchar(5), @FolioOX  as bigint

set @IdCedisOX = 0

set @IdCedisOX = (select top 1 IdCedisOX from inserted )
if @IdCedisOX is null set @IdCedisOX = isnull( (select top 1 IdCedisOX from deleted), 0)

set @IdTipoVentaOX = (select top 1 IdTipoVentaOX from inserted)
if @IdTipoVentaOX is null set @IdTipoVentaOX = isnull( (select top 1 IdTipoVentaOX from deleted), 0)

set @SerieOX = (select top 1 SerieOX from inserted)
if @SerieOX is null set @SerieOX = isnull( (select top 1 SerieOX from deleted), 0)

set @FolioOX = (select top 1 FolioOX from inserted)
if @FolioOX is null set @FolioOX = isnull( (select top 1 FolioOX from deleted), 0)


update Ventas set Subtotal =  ( select isnull( sum(Subtotal), 0)   from Ventas  
	where Folio in ( select Folio from FacturasOxxo
		where FacturasOxxo.IdCedis = Ventas.IDCedis and FacturasOxxo.IdTipoVenta = Ventas.IdTipoVenta
		and FacturasOxxo.Serie = Ventas.Serie and FacturasOxxo.Folio = Ventas.Folio
		and FacturasOxxo.IdCedisOX = @IdCedisOX and FacturasOxxo.IdTipoVentaOX = @IdTipoVentaOX
		and FacturasOxxo.SerieOX = @SerieOX and FacturasOxxo.FolioOX = @FolioOX)) , 

Iva = ( select isnull( sum(Iva), 0)   from Ventas  
	where Folio in ( select Folio from FacturasOxxo
		where FacturasOxxo.IdCedis = Ventas.IDCedis and FacturasOxxo.IdTipoVenta = Ventas.IdTipoVenta
		and FacturasOxxo.Serie = Ventas.Serie and FacturasOxxo.Folio = Ventas.Folio
		and FacturasOxxo.IdCedisOX = @IdCedisOX and FacturasOxxo.IdTipoVentaOX = @IdTipoVentaOX
		and FacturasOxxo.SerieOX = @SerieOX and FacturasOxxo.FolioOX = @FolioOX)) 

where Ventas.IDCedis = @IdCedisOX and Ventas.IdTipoVenta = @IdTipoVentaOX and Ventas.Serie =  @SerieOX and Ventas.Folio = @FolioOX 

GO


