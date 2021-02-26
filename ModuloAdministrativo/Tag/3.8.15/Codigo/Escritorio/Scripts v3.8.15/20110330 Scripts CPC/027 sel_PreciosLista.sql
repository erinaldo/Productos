USE [RouteCPC]
GO

/****** Object:  StoredProcedure [dbo].[sel_Precios]    Script Date: 04/01/2011 15:45:59 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sel_Precios]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sel_Precios]
GO

USE [RouteCPC]
GO

/****** Object:  StoredProcedure [dbo].[sel_Precios]    Script Date: 04/01/2011 15:45:59 ******/
SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER OFF
GO




CREATE PROCEDURE [dbo].[sel_Precios] 
@IdCedis as bigint,
@IdCliente as bigint,
@IdRuta as bigint,
@IdProducto as bigint,
@Cantidad as decimal(19,4),
@IdLista as bigint,
@Precio as money

AS

-- contado
set @IdLista = isnull((select PreciosLista.IdLista 
	from PreciosLista 
	where TipoLista='BA'),0)
set @Precio =  isnull((Select Precio from PreciosDetalle where IdLista = @IdLista and IdProducto = @IdProducto),0)	

select @IdLista, @Precio, IdProducto, Producto 
from Productos 
where IdProducto = @IdProducto 


GO


