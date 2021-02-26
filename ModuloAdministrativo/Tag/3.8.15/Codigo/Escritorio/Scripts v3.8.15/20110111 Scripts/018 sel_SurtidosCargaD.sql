USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[sel_SurtidosCargaD]    Script Date: 01/18/2011 20:18:00 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sel_SurtidosCargaD]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sel_SurtidosCargaD]
GO

USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[sel_SurtidosCargaD]    Script Date: 01/18/2011 20:18:00 ******/
SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER OFF
GO




CREATE PROCEDURE [dbo].[sel_SurtidosCargaD]
@IdCedis as bigint,
@IdSurtido as bigint,
@IdCarga as bigint,
@IdProducto as bigint,
@Fecha as datetime,
@Opc as int
AS

declare @IdFamiliaRejas as bigint
declare @Cantidad as money

if @Opc = 1
begin

        set @IdFamiliaRejas = ( select isnull(idfamiliarejas,0) as Reja from productos left outer join configuracion on idfamilia = idfamiliarejas where idproducto = @IdProducto )

        if @IdFamiliaRejas <> 0  -- producto reja
		begin
				select @Cantidad = isnull( (select Surtido  
				from Rejas 
				where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdProducto = @IdProducto ), 0)

                select Productos.IdProducto, Producto, isnull( (
                        select Surtido from Rejas
                        where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdCarga = @IdCarga and Rejas.IdProducto = Productos.IdProducto
                ), 0) as Surtido, 
                isnull( ( 
                        select (Inicial + Entradas - Salidas - Surtido + DevBuena + DevMala)
                        from InventarioKardex
                        where IdCedis = @IdCedis and Fecha = @Fecha and InventarioKardex.IdProducto = Productos.IdProducto
                ), 0) as Existencias, Decimales, Status,
				isnull( (
                        select sum(Surtido) from Rejas
                        where IdCedis = @IdCedis and IdSurtido = @IdSurtido and Rejas.IdProducto = Productos.IdProducto
                ), 0) as SurtidoTotal,
				case Divide 
					when 'N' then cast(@Cantidad * ISNULL(Factor,0) as bigint) 
					when 'S' then cast(@Cantidad / isnull(Factor,1) as bigint) else 0 end as Unidad,
				case Divide 
					when 'N' then (@Cantidad * ISNULL(Factor,0)) - cast(@Cantidad * ISNULL(Factor,0) as bigint) 
					when 'S' then (@Cantidad / isnull(Factor,1) - cast(@Cantidad / isnull(Factor,1) as bigint)) * isnull(Factor,1) else @Cantidad end as Piezas
                from Productos 
                left outer join ProductosUnidad on ProductosUnidad.IdProducto = Productos.IdProducto 
                where Productos.IdProducto = @IdProducto
		end
        else -- producto no reja
        begin
        
				select @Cantidad = isnull( (select Cantidad 
				from SurtidosCargas
				where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdCarga = @IdCarga and SurtidosCargas.IdProducto = @IdProducto ), 0)

                select Productos.IdProducto, Producto, isnull( (
                        select Cantidad from SurtidosCargas
                        where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdCarga = @IdCarga and SurtidosCargas.IdProducto = Productos.IdProducto
                ), 0) as Surtido, 
                isnull( ( 
                        select (Inicial + Entradas - Salidas - Surtido + DevBuena + DevMala)
                        from InventarioKardex
                        where IdCedis = @IdCedis and Fecha = @Fecha and InventarioKardex.IdProducto = Productos.IdProducto
                ), 0) -
                isnull(( select sum(Surtido) 
					from SurtidosDetalle 
					where IdCedis = @IdCedis and Fecha = (select distinct top 1 Fecha from Surtidos where IdCedis = @IdCedis and Fecha > @Fecha order by Fecha) and IdProducto = Productos.IdProducto ),0) as Existencias, Decimales, Status, 
				isnull( ( select Surtido from SurtidosDetalle
                        where IdCedis = @IdCedis and IdSurtido = @IdSurtido and SurtidosDetalle.IdProducto = Productos.IdProducto
                ), 0) as SurtidoTotal,
				case Divide 
					when 'N' then cast(@Cantidad * ISNULL(Factor,0) as bigint) 
					when 'S' then cast(@Cantidad / isnull(Factor,1) as bigint) else 0 end as Unidad,
				case Divide 
					when 'N' then (@Cantidad * ISNULL(Factor,0)) - cast(@Cantidad * ISNULL(Factor,0) as bigint) 
					when 'S' then (@Cantidad / isnull(Factor,1) - cast(@Cantidad / isnull(Factor,1) as bigint)) * isnull(Factor,1) else @Cantidad end as Piezas
                
                from Productos 
                left outer join ProductosUnidad on ProductosUnidad.IdProducto = Productos.IdProducto 
                where Productos.IdProducto = @IdProducto
       end
end

if @Opc = 2
begin
	select top 1 IdProducto, IdUnidad, Factor, Divide, CodigoBarras, Orden
	from ProductosUnidad 
	where IdProducto = @IdProducto 
	order by Orden asc
end

/*
if @Opc = 2
begin

        select SurtidosDetalle.IdCedis, SurtidosDetalle.IdProducto as 'Cve. Producto', Producto as 'Producto', Surtido as 'Carga', (VentaCredito + VentaContado) as 'Venta',
        DevBuena as 'Dev. Buena', DevMala as 'Dev. Mala', Obsequios as 'Obsequios', Surtido - VentaCredito - VentaContado - DevBuena - DevMala - Obsequios as 'Existencias', 
        Precio as 'Precio', Subtotal as 'Subtotal', Surtido*Precio*Productos.Iva as 'Iva', Total as 'Total'
        from SurtidosDetalle 
        inner join Productos on SurtidosDetalle.IdProducto = Productos.IdProducto
        where IdCedis = @IdCedis and IdSurtido = @IdSurtido and Surtido > 0
        -- order by cast(SurtidosDetalle.IdProducto as bigint)

        union
        
        select Rejas.IdCedis, Rejas.IdProducto as 'Cve. Producto', Producto as 'Producto', Surtido as 'Carga', 0 as 'Venta',
        Devolucion as 'Dev. Buena', 0 as 'Dev. Mala', 0 as 'Obsequios', Surtido - Devolucion as 'Existencias', 
        0 as 'Precio', 0 as 'Subtotal', 0 as 'Iva', 0 as 'Total'
        from Rejas 
        inner join Productos on Rejas.IdProducto = Productos.IdProducto
        where IdCedis = @IdCedis and IdSurtido = @IdSurtido and Surtido > 0
        -- order by cast(Rejas.IdProducto as bigint)
end
*/

if @Opc = 6
begin

        select SurtidosCargas.IdCedis, SurtidosCargas.IdProducto as 'Cve. Producto', Producto as 'Producto', Cantidad as 'Carga', 
        Precio as 'Precio', Cantidad*Precio as 'Subtotal', Cantidad*Precio*SurtidosDetalle.Iva as 'Iva', 
        (Cantidad*Precio)*(1+SurtidosDetalle.Iva) as 'Total',
        case Divide 
			when 'N' then cast(Cantidad * ISNULL(Factor,0) as bigint) 
			when 'S' then cast(Cantidad / isnull(Factor,1) as bigint) else 0 end as Unidad,
        case Divide 
			when 'N' then (Cantidad * ISNULL(Factor,0)) - cast(Cantidad * ISNULL(Factor,0) as bigint) 
			when 'S' then (Cantidad / isnull(Factor,1) - cast(Cantidad / isnull(Factor,1) as bigint)) * isnull(Factor,1) else Cantidad end as Piezas
        from SurtidosCargas
		inner join SurtidosDetalle on SurtidosDetalle.IdCedis = SurtidosCargas.IdCedis 
		and SurtidosDetalle.IdSurtido = SurtidosCargas.IdSurtido 
		and SurtidosDetalle.IdProducto = SurtidosCargas.IdProducto
        inner join Productos on SurtidosCargas.IdProducto = Productos.IdProducto
        left outer join ProductosUnidad PU on PU.IdProducto = Productos.IdProducto and IdUnidad = 'CAJA'
        where SurtidosCargas.IdCedis = @IdCedis and SurtidosCargas.IdSurtido = @IdSurtido and Surtido > 0 and IdCarga = @IdCarga
        -- order by cast(SurtidosCargas.IdProducto as bigint)

        union
        
        select Rejas.IdCedis, Rejas.IdProducto as 'Cve. Producto', Producto as 'Producto', Surtido as 'Carga', 
        0 as 'Precio', 0 as 'Subtotal', 0 as 'Iva', 0 as 'Total',
        case Divide 
			when 'N' then cast(Surtido * ISNULL(Factor,0) as bigint) 
			when 'S' then cast(Surtido / isnull(Factor,1) as bigint) else 0 end as Unidad,
        case Divide 
			when 'N' then (Surtido * ISNULL(Factor,0)) - cast(Surtido * ISNULL(Factor,0) as bigint) 
			when 'S' then (Surtido / isnull(Factor,1) - cast(Surtido / isnull(Factor,1) as bigint)) * isnull(Factor,1) else Surtido end as Piezas
        from Rejas 
        inner join Productos on Rejas.IdProducto = Productos.IdProducto
        left outer join ProductosUnidad PU on PU.IdProducto = Productos.IdProducto and IdUnidad = 'CAJA'
        where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdCarga = @IdCarga and ( Surtido > 0 or Devolucion > 0 )
        -- order by cast(Rejas.IdProducto as bigint)        

end


GO


