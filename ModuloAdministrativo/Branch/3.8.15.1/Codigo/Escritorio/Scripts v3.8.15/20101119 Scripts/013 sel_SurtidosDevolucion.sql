USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[sel_SurtidosDevolucion]    Script Date: 11/17/2010 19:41:02 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sel_SurtidosDevolucion]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sel_SurtidosDevolucion]
GO

USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[sel_SurtidosDevolucion]    Script Date: 11/17/2010 19:41:02 ******/
SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER OFF
GO




CREATE PROCEDURE [dbo].[sel_SurtidosDevolucion] 
@IdCedis as bigint,
@IdSurtido as bigint,
@IdProducto as bigint,
@Opc as int
AS

if @Opc = 1
	select SurtidosDevolucion.IdSurtido, SurtidosDevolucion.IdTipoDevolucion as 'Id', TipoDevolucion.TipoDevolucion as 'Tipo Devolución', 
	SurtidosDevolucion.Cantidad as 'Cantidad', case EnRuta when 1 then 'SI' else 'NO' end EnRuta
	from SurtidosDevolucion
	inner join TipoDevolucion on SurtidosDevolucion.IdTipoDevolucion = TipoDevolucion.IdTipoDevolucion
	where SurtidosDevolucion.IdCedis = @IdCedis and SurtidosDevolucion.IdSurtido = @IdSurtido and IdProducto = @IdProducto
	order by SurtidosDevolucion.IdTipoDevolucion

if @Opc = 2
	select isnull( sum(Cantidad), 0 ) 
	from SurtidosDevolucion 
	where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdProducto = @IdProducto



GO


