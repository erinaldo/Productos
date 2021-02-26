USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[sel_InvFisico]    Script Date: 12/08/2010 09:24:04 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sel_InvFisico]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sel_InvFisico]
GO

USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[sel_InvFisico]    Script Date: 12/08/2010 09:24:04 ******/
SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER OFF
GO




CREATE PROCEDURE [dbo].[sel_InvFisico]
@IdCedis as bigint,
@Fecha as datetime

AS

select IdCedis, Fecha, Productos.IdProducto as 'Cve. Producto', Producto as 'Producto', Cantidad, Captura, DevBuena as 'Devolución',
case InventarioFisico.Status 
	when 'P' then 'Pendiente'
	when 'A' then 'Aplicado'
end as 'Estatus', Cantidad * Conversion as 'KgLts'
from InventarioFisico
inner join Productos on Productos.IdProducto = InventarioFisico.IdProducto
where IdCedis = @IdCedis and Fecha = @Fecha and Cantidad>0
order by InventarioFisico.IdProducto



GO


