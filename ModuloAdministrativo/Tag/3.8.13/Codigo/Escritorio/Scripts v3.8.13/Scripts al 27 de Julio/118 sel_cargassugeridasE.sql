USE [RouteADM]
GO
/****** Object:  StoredProcedure [dbo].[sel_CargasSugeridasE]    Script Date: 06/18/2010 17:40:09 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[sel_CargasSugeridasE] 
@IdCedis as bigint,
@Fecha as datetime,
@FechaCarga as datetime,
@IdRuta as bigint,
@IdProducto as bigint,
@Opc as int
AS

declare @IdFamiliaRejas as bigint

if @Opc = 1
begin

        set @IdFamiliaRejas = ( select isnull(idfamiliarejas,0) as Reja from productos left outer join configuracion on idfamilia = idfamiliarejas where idproducto = @IdProducto )

        if @IdFamiliaRejas <> 0  -- producto reja

                select IdProducto, Producto, 0 as Surtido, 
                isnull( ( 
                        select (Inicial + Entradas - Salidas - Surtido + DevBuena + DevMala)
                        from InventarioKardex
                        where IdCedis = @IdCedis and Fecha = @Fecha and InventarioKardex.IdProducto = Productos.IdProducto
                ), 0) as Existencias, Decimales, Status,0 as SurtidoTotal
                from Productos 
                where IdProducto = @IdProducto

        else -- producto no reja

                select IdProducto, Producto, isnull( (
                        select Cantidad from CargasSugeridasDetalle 
                        where IdCedis = @IdCedis and FechaCarga = @FechaCarga and CargasSugeridasDetalle.IdRuta = @IdRuta and CargasSugeridasDetalle.IdProducto = Productos.IdProducto
                ), 0) as Surtido, 
                isnull( ( 
                        select (Inicial + Entradas - Salidas - Surtido + DevBuena + DevMala)
                        from InventarioKardex
                        where IdCedis = @IdCedis and Fecha = @Fecha and InventarioKardex.IdProducto = Productos.IdProducto
                ), 0) -
                isnull(( select sum(Surtido) 
					from SurtidosDetalle 
					where IdCedis = @IdCedis and Fecha = (select distinct top 1 Fecha from Surtidos where IdCedis = @IdCedis and Fecha > @Fecha order by Fecha) and IdProducto = Productos.IdProducto ),0) as Existencias, Decimales, Status, 
				0 as SurtidoTotal
                from Productos 
                where IdProducto = @IdProducto
end
