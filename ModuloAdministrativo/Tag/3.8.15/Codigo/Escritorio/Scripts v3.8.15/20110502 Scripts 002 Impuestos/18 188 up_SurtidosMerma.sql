USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[up_SurtidosMerma]    Script Date: 05/05/2011 10:54:33 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[up_SurtidosMerma]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[up_SurtidosMerma]
GO

USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[up_SurtidosMerma]    Script Date: 05/05/2011 10:54:33 ******/
SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER OFF
GO




CREATE PROCEDURE [dbo].[up_SurtidosMerma] 
@IdCedis as bigint,
@IdSurtido as bigint,
@IdProducto as bigint,
@IdTipoMerma as bigint,
@Cantidad as float,
@Opc as int
AS

declare
@Ex as bigint

if @Opc = 1
begin	
	set @Ex = isnull( (Select IdTipoMerma from SurtidosMerma where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdProducto = @IdProducto and IdTipoMerma = @IdTipoMerma), 0)
	delete from SurtidosMerma where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdProducto = @IdProducto and IdTipoMerma = @IdTipoMerma
	insert into SurtidosMerma values (@IdCedis, @IdSurtido, @IdTipoMerma, @IdProducto, @Cantidad)
end

if @Opc = 2
	delete from SurtidosMerma where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdProducto = @IdProducto and IdTipoMerma = @IdTipoMerma

if @Opc = 3
begin
	delete from SurtidosMerma where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdProducto = @IdProducto
	update SurtidosDetalle set DevMala = 0 where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdProducto = @IdProducto
end


GO


