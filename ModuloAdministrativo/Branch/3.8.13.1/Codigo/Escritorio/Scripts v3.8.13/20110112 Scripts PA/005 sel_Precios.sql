USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[sel_Precios]    Script Date: 01/12/2011 16:18:23 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sel_Precios]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sel_Precios]
GO

USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[sel_Precios]    Script Date: 01/12/2011 16:18:23 ******/
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
@Precio as decimal(19,9)

AS

-- Busca a nivel Cliente
set @IdLista = isnull((Select IdLista from PreciosListaCliente where IdCedis = @IdCedis and IdCliente = @IdCliente),0)
set @Precio =  isnull((Select Precio from PreciosDetalle where IdLista = @IdLista and IdProducto = @IdProducto),0)

if @Precio=0
begin
	-- Busca a nivel ruta
	set @IdLista = isnull((Select IdLista from PreciosListaRuta where IdCedis = @IdCedis and IdRuta = @IdRuta),0)
	set @Precio =  isnull((Select Precio from PreciosDetalle where IdLista = @IdLista and IdProducto = @IdProducto),0)	
	if @Precio=0
	begin
		-- contado
		set @IdLista = isnull((select PreciosListaCedis.IdLista from PreciosListaCedis 
			inner join PreciosLista on PreciosListaCedis.IdLista = PreciosLista.IdLista and TipoLista='BA'
			where PreciosListaCedis.idcedis = @IdCedis),0)
		set @Precio =  isnull((Select Precio from PreciosDetalle where IdLista = @IdLista and IdProducto = @IdProducto),0)	
	end
end

select @IdLista, @Precio



GO


