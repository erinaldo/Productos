USE [RouteADM]
GO

/****** Object:  UserDefinedFunction [dbo].[FN_CargasSugeridas]    Script Date: 08/11/2010 10:45:22 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FN_CargasSugeridas]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[FN_CargasSugeridas]
GO

USE [RouteADM]
GO

/****** Object:  UserDefinedFunction [dbo].[FN_CargasSugeridas]    Script Date: 08/11/2010 10:45:22 ******/
SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER OFF
GO


CREATE FUNCTION [dbo].[FN_CargasSugeridas]
(
@IdCedi as bigint,
@IdRuta as bigint,
@FechaCarga as datetime,
@Folio as bigint
)  
RETURNS Table AS  
return
(
	select Productos.IdProducto as IdProducto, CargasSugeridasFamilia.Semanas as Semanas, CargasSugeridasFamilia.Porcentaje, Productos.Decimales
	from CargasSugeridasFamilia 
	inner join Familias on Familias.IdFamilia = CargasSugeridasFamilia.IdFamilia
	inner join Productos on Productos.IdFamilia = CargasSugeridasFamilia.IdFamilia 
		and Productos.IdProducto not in ( select CargasSugeridasProducto.IdProducto from CargasSugeridasProducto 
		where CargasSugeridasProducto.IdCedis = @IdCedi and CargasSugeridasProducto.IdRuta = @IdRuta and CargasSugeridasProducto.FechaCarga = @FechaCarga)
	where CargasSugeridasFamilia.IdCedis = @IdCedi and CargasSugeridasFamilia.IdRuta = @IdRuta and CargasSugeridasFamilia.FechaCarga = @FechaCarga and CargasSugeridasFamilia.Folio = @Folio
	group by CargasSugeridasFamilia.FechaCarga, Familias.IdFamilia, Familias.Familia, Productos.IdProducto, Producto, 
	CargasSugeridasFamilia.Semanas, CargasSugeridasFamilia.Porcentaje, Productos.Decimales
	
	union
	
	select CargasSugeridasProducto.IdProducto as IdProducto, CargasSugeridasProducto.Semanas as Semanas, CargasSugeridasProducto.Porcentaje, Productos.Decimales
	from CargasSugeridasProducto
	inner join Productos on Productos.IdProducto = CargasSugeridasProducto.IdProducto 
	where CargasSugeridasProducto.IdCedis = @IdCedi and CargasSugeridasProducto.IdRuta = @IdRuta and CargasSugeridasProducto.FechaCarga = @FechaCarga and CargasSugeridasProducto.Folio = @Folio

)












GO


