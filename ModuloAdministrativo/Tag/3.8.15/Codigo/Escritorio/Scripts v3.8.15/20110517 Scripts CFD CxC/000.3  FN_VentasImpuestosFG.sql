USE [RouteCPC]
GO

/****** Object:  UserDefinedFunction [dbo].[FN_VentasOxxoImp]    Script Date: 05/18/2011 02:53:59 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FN_VentasOxxoImp]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[FN_VentasOxxoImp]
GO

USE [RouteCPC]
GO

/****** Object:  UserDefinedFunction [dbo].[FN_VentasOxxoImp]    Script Date: 05/18/2011 02:53:59 ******/
SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER OFF
GO


CREATE FUNCTION [dbo].[FN_VentasOxxoImp]
(
@IdCedisOX as bigint,
@IdTipoVentaOX as bigint,
@SerieOX as varchar(5),
@FolioOX as bigint
)  
RETURNS Table AS  
return
(
select distinct FacturasOxxo.IdCedisOX, FacturasOxxo.IdTipoVentaOX, FacturasOxxo.SerieOX, FacturasOxxo.FolioOX, 
VentasImpuestos.IdProducto, VentasImpuestos.IdTipoImpuesto, VentasImpuestos.TipoAplicacion, VentasImpuestos.Jerarquia, VentasImpuestos.Tasa
from FacturasOxxo
inner join VentasImpuestos on FacturasOxxo.IdCedis = VentasImpuestos.IdCedis and FacturasOxxo.Serie = VentasImpuestos.Serie collate SQL_Latin1_General_CP1_CI_AS and 
FacturasOxxo.IdTipoVenta = VentasImpuestos.IdTipoVenta and FacturasOxxo.Folio = VentasImpuestos.Folio	
where FacturasOxxo.IdCedisOX = @IdCedisOX and FacturasOxxo.IdTipoVentaOX = @IdTipoVentaOX and FacturasOxxo.SerieOX = @SerieOX and FacturasOxxo.FolioOX = @FolioOX
)


GO


