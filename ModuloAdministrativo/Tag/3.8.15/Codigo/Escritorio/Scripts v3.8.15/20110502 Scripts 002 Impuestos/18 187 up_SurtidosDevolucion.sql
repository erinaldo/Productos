USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[up_SurtidosDevolucion]    Script Date: 05/05/2011 10:38:38 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[up_SurtidosDevolucion]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[up_SurtidosDevolucion]
GO

USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[up_SurtidosDevolucion]    Script Date: 05/05/2011 10:38:38 ******/
SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER OFF
GO





CREATE PROCEDURE [dbo].[up_SurtidosDevolucion] 
@IdCedis as bigint,
@IdSurtido as bigint,
@IdProducto as bigint,
@IdTipoDevolucion as bigint,
@Cantidad as float,
@Opc as int
AS

declare
@Ex as bigint

if @Opc = 1
begin	
	set @Ex = isnull( (Select IdTipoDevolucion from SurtidosDevolucion where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdProducto = @IdProducto and IdTipoDevolucion = @IdTipoDevolucion), 0)
	delete from SurtidosDevolucion where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdProducto = @IdProducto and IdTipoDevolucion = @IdTipoDevolucion
	insert into SurtidosDevolucion values (@IdCedis, @IdSurtido, @IdTipoDevolucion, @IdProducto, @Cantidad)
end

if @Opc = 2
	delete from SurtidosDevolucion where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdProducto = @IdProducto and IdTipoDevolucion = @IdTipoDevolucion

if @Opc = 3
	delete from SurtidosDevolucion where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdProducto = @IdProducto

if @Opc = 4
begin
	if @Cantidad = 0 
	begin
		delete from SurtidosDevolucion where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdProducto = @IdProducto
		update SurtidosDetalle set DevBuena = 0 where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdProducto = @IdProducto
	end
	if not exists(select IdProducto from SurtidosDevolucion where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdProducto = @IdProducto)
	begin
		select top 1 @IdTipoDevolucion = ISNULL(IdTipoDevolucion, 0) from TipoDevolucion where EnRuta = 1 order by IdTipoDevolucion
		if @IdTipoDevolucion <> 0 and @Cantidad <> 0
			insert into SurtidosDevolucion values (@IdCedis, @IdSurtido, @IdTipoDevolucion, @IdProducto, @Cantidad)
	end
end


GO


