USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[up_Precios]    Script Date: 02/23/2011 11:15:08 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[up_Precios]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[up_Precios]
GO

USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[up_Precios]    Script Date: 02/23/2011 11:15:08 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[up_Precios]
@Lista as bigint,
@Producto as bigint,
@Precio as money,
@IdCedis as bigint,
@Opc as int
AS

declare @Route as int, @Decimales as int

if @Opc = 1 or @Opc = 2
begin
	delete preciosdetalle where IdLista = @Lista and IdProducto = @Producto
	insert into preciosdetalle values (@Lista, @Producto, @Precio)


	set @Route = isnull( ( select Route from Configuracion where IdCedis = @IdCedis ), 0 )
	
	if @Route = 1
	begin
		set @Decimales = (select Decimales from Productos where IdProducto = @Producto )

		if @Decimales = 1
			insert into ROUTE.dbo.tmp_PrecioProductoVig select cast( @Lista as varchar(10)), cast( @Producto as varchar(10)), 2, getdate(), cast( @Precio as decimal (10,5) ), 1, getdate(), null 
		else		
			insert into ROUTE.dbo.tmp_PrecioProductoVig select cast( @Lista as varchar(10)), cast( @Producto as varchar(10)), 1, getdate(), cast( @Precio as decimal (10,5) ), 1, getdate(), null 
		
		if exists( select IdLista from PreciosLista where IdLista = @Lista and TipoLista = 'BA'  )
		begin
			declare  ActPrecio cursor for
				select PreciosLista.IdLista, @Producto, @Precio, Decimales
				from PreciosLista
				inner join PreciosListaCedis on PreciosLista.IdLista = PreciosListaCedis.IdLista and PreciosListaCedis.IdCedis = @IdCedis
				inner join Productos on Productos.IdProducto = @Producto
				where PreciosLista.IdLista not in ( select IdLista from PreciosDetalle where PreciosDetalle.IdLista = PreciosLista.IdLista and PreciosDetalle.IdProducto in ( @Producto  ) ) 
				and PreciosLista.IdLista in ( select IdLista from PreciosListaCedis where PreciosListaCedis.IdLista = PreciosLista.IdLista and IdCedis in ( @IdCedis ) )
			open ActPrecio
			
			fetch next from ActPrecio into @Lista, @Producto, @Precio, @Decimales
			while (@@fetch_status = 0)
			begin
				if @Decimales = 1
					insert into ROUTE.dbo.tmp_PrecioProductoVig select cast( @Lista as varchar(10)), cast( @Producto as varchar(10)), 2, getdate(), cast( @Precio  as decimal (10,5) ), 1, getdate(), null
				else
					insert into ROUTE.dbo.tmp_PrecioProductoVig select cast( @Lista as varchar(10)), cast( @Producto as varchar(10)), 1, getdate(), cast( @Precio  as decimal (10,5) ), 1, getdate(), null
	
				fetch next from ActPrecio into @Lista, @Producto, @Precio, @Decimales
			end
			close ActPrecio
			deallocate ActPrecio		
		end
	end
 end


/*
if @Opc = 2
	update preciosdetalle set Precio = @Precio where IdLista = @Lista and IdProducto=@Producto

if @Opc = 3
	delete preciosdetalle where IdLista = @Lista and IdProducto=@Producto
*/
GO


