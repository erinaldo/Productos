USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[sel_CedisLista]    Script Date: 12/17/2010 20:03:54 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sel_CedisLista]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sel_CedisLista]
GO

USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[sel_CedisLista]    Script Date: 12/17/2010 20:03:54 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER OFF
GO


CREATE PROCEDURE [dbo].[sel_CedisLista]
@IdCedis as bigint,
@IdLista as bigint,
@IdCliente as bigint,
@IdRuta as bigint,
@Opc as int
AS

if @Opc = 0 -- POR CEDIS
begin
        select '', c.IdCedis, c.Cedis, l.IdLista, l.Descripcion, t.TipoLista, 
        case l.Status 
                when 'A' then 'Activo'
                else 'Baja'
        end as 'Estatus'
        from precioslista l, precioslistacedis u, cedis c, tipolista t
        where c.idcedis = u.idcedis and u.idlista = l.idlista and l.tipolista = t.idtipolista and c.idcedis = @IdCedis
        order by cedis, cast(l.IdLista as bigint)
end

if @Opc = 1 -- POR CLIENTE
begin
        Select '', Clientes.IdCliente, RazonSocial, PreciosListaCliente.IdLista, 
        case TipoLista
                when 'BA' then 'BASE'
                when 'CL' then 'CLIENTE'
                when 'RU' then 'RUTA'
        end as TipoLista,
        Descripcion
        from PreciosListaCliente
        inner join PreciosLista on PreciosLista.IdLista = PreciosListaCliente.IdLista
        inner join Clientes on Clientes.IdCliente = PreciosListaCliente.IdCliente and Clientes.IdCedis = PreciosListaCliente.IdCedis 
        where PreciosListaCliente.IdCedis = @IdCedis and PreciosListaCliente.IdCliente = @IdCliente
end

if @Opc = 2 -- POR RUTA
begin
        Select '', Rutas.IdRuta, Ruta, PreciosListaRuta.IdLista, 
        case TipoLista
                when 'BA' then 'BASE'
                when 'CL' then 'CLIENTE'
                when 'RU' then 'RUTA'
        end as TipoLista,
        Descripcion
        from PreciosListaRuta
        inner join PreciosLista on PreciosLista.IdLista = PreciosListaRuta.IdLista 
        inner join Rutas on Rutas.IdRuta = PreciosListaRuta.IdRuta and Rutas.IdCedis = PreciosListaRuta.IdCedis
        where PreciosListaRuta.IdCedis = @IdCedis and PreciosListaRuta.IdRuta = @IdRuta
end

GO


