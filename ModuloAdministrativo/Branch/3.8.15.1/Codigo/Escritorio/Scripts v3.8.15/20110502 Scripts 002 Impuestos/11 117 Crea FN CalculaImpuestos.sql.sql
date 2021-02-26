USE [RouteADM]
GO

/****** Object:  UserDefinedFunction [dbo].[FN_ImpuestosProducto]    Script Date: 05/04/2011 09:36:09 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FN_ImpuestosProducto]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[FN_ImpuestosProducto]
GO

USE [RouteADM]
GO

/****** Object:  UserDefinedFunction [dbo].[FN_ImpuestosProducto]    Script Date: 05/04/2011 09:36:09 ******/
SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER OFF
GO



CREATE FUNCTION [dbo].[FN_ImpuestosProducto]
(
@IdProducto as bigint
)  
RETURNS Table AS  
return
(
		select Productos.IdProducto, TipoImpuesto.IdTipoImpuesto, TipoAplicacion, Jerarquia, TipoImpuesto.Tasa as Impuestos
		from Productos 
		left outer join ProductosImpuestos on ProductosImpuestos.IdProducto = Productos.IdProducto 
		left outer join TipoImpuesto on TipoImpuesto.IdTipoImpuesto = ProductosImpuestos.IdTipoImpuesto
		where Productos.IdProducto = @IdProducto

)

GO


