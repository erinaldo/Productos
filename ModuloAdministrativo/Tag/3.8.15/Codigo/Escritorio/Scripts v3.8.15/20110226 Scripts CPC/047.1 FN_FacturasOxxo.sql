USE [RouteCPC]
GO

/****** Object:  UserDefinedFunction [dbo].[FN_VentasOxxo]    Script Date: 03/24/2011 01:43:34 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FN_VentasOxxo]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[FN_VentasOxxo]
GO

USE [RouteCPC]
GO

/****** Object:  UserDefinedFunction [dbo].[FN_VentasOxxo]    Script Date: 03/24/2011 01:43:34 ******/
SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER OFF
GO

CREATE FUNCTION [dbo].[FN_VentasOxxo]
(
@IdCedisOX as bigint,
@IdTipoVentaOX as bigint,
@SerieOX as varchar(5),
@FolioOX as bigint
)  
RETURNS Table AS  
return
(
select FacturasOxxo.IdCedisOX, FacturasOxxo.IdTipoVentaOX, FacturasOxxo.FolioOX, VentasDetalle.IdProducto, FacturasOxxo.SerieOX, 
sum(Cantidad) as Cantidad, sum(Cantidad * Precio) / sum(Cantidad) as Precio, avg(VentasDetalle.Iva) as Iva, avg(VentasDetalle.DctoPorc) as DctoPorc,
sum(VentasDetalle.DctoImp) as DctoImp, avg(VentasDetalle.Entregado) as Entregado
from FacturasOxxo
inner join VentasDetalle on FacturasOxxo.IdCedis = VentasDetalle.IdCedis and FacturasOxxo.Serie = VentasDetalle.Serie collate SQL_Latin1_General_CP1_CI_AS and 
FacturasOxxo.IdTipoVenta = VentasDetalle.IdTipoVenta and FacturasOxxo.Folio = VentasDetalle.Folio	

inner join Productos on Productos.IdProducto = VentasDetalle.IdProducto
where FacturasOxxo.IdCedisOX = @IdCedisOX and FacturasOxxo.IdTipoVentaOX = @IdTipoVentaOX and FacturasOxxo.SerieOX = @SerieOX and FacturasOxxo.FolioOX = @FolioOX
group by FacturasOxxo.IdCedisOX, FacturasOxxo.IdTipoVentaOX, FacturasOxxo.FolioOX, FacturasOxxo.SerieOX, VentasDetalle.IdProducto, Producto
)

GO


