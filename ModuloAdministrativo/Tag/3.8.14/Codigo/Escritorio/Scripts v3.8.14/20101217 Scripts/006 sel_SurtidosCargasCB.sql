USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[sel_RouteCargaCB]    Script Date: 12/27/2010 15:53:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sel_RouteCargaCB]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sel_RouteCargaCB]
GO

USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[sel_RouteCargaCB]    Script Date: 12/27/2010 15:53:28 ******/
SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER OFF
GO


CREATE PROCEDURE [dbo].[sel_RouteCargaCB] 

@IdCedis as bigint,
@IdSurtido as bigint,
@IdCarga as bigint,
@IdRuta as bigint,
@Opc as int

AS

if @Opc = 1 or @Opc = 2
        select cast( Surtidos.IdCedis as varchar(10) ) + replicate('0', 4 - len( Surtidos.IdRuta) ) + cast( Surtidos.IdRuta as varchar(10) )  as IdVendedor, 
        SurtidosCargas.IdCarga, Surtidos.Fecha, ltrim(rtrim(cast(SurtidosCargas.IdProducto as varchar(100)))) + ',' + 
        case Decimales 
        when 0 then cast(  cast(  SurtidosCargas.Cantidad as bigint) as varchar(100)) 
		else cast(  cast(  SurtidosCargas.Cantidad as Decimal(10,4)) as varchar(100)) end as Cantidad
        from Surtidos
        inner join SurtidosCargas on Surtidos.IdCedis = SurtidosCargas.IdCedis and Surtidos.IdSurtido = SurtidosCargas.IdSurtido  and SurtidosCargas.IdCarga = @IdCarga
        inner join Productos on Productos.IdProducto = SurtidosCargas.IdProducto 
        where Surtidos.IdCedis = @IdCedis and Surtidos.IdSurtido = @IdSurtido
                and SurtidosCargas.IdProducto not in ( select IdProducto from Productos where IdFamilia in ( select IdFamiliaRejas from Configuracion where IdCedis = @IdCedis ) )
		and cast( SurtidosCargas.Cantidad as int ) >  0
        order by cast( SurtidosCargas.IdProducto as bigint)

GO


