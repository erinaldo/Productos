USE [RouteADM]
GO
/****** Object:  StoredProcedure [dbo].[sel_Productos]    Script Date: 05/27/2010 23:38:26 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO

CREATE PROCEDURE [dbo].[sel_ProductosDescripcion]
@IdProducto as bigint,
@Producto as varchar(500),
@Opc as int
AS

select IdProducto, Producto 
from Productos
WHERE Status = 'A' and Producto like '%' + @Producto + '%'
order by Producto 