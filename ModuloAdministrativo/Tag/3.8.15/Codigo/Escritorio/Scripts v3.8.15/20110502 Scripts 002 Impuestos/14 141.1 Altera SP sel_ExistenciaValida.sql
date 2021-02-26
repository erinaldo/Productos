USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[sel_ExistenciaValida]    Script Date: 05/03/2011 15:39:35 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sel_ExistenciaValida]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sel_ExistenciaValida]
GO

USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[sel_ExistenciaValida]    Script Date: 05/03/2011 15:39:35 ******/
SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER OFF
GO





CREATE PROCEDURE [dbo].[sel_ExistenciaValida] 
@IdCedis as bigint,
@IdSurtido as bigint,
@IdTipoVenta as bigint,
@Folio as bigint,
@IdProducto as bigint,
@Cantidad as float,
@CantidadAnterior as float,
@Opc as bigint

AS

if @Opc = 1
begin
        --select SurtidosDetalle.IdProducto, Producto, Surtido - DevBuena - DevMala - Obsequios - VentaContado - VentaCredito as 'Existencia', Productos.Iva, Decimales
        --from SurtidosDetalle 
        --inner join  Productos on SurtidosDetalle.IdProducto = Productos.IdProducto
        --where SurtidosDetalle.IdCedis = @IdCedis and SurtidosDetalle.IdSurtido = @IdSurtido and SurtidosDetalle.IdProducto = @IdProducto
        
        select Productos.IdProducto, Producto, isnull(Surtido - DevBuena - DevMala - Obsequios - VentaContado - VentaCredito,0) as 'Existencia', Productos.Iva as Impuestos, Decimales
        from Productos 
        left outer join SurtidosDetalle on SurtidosDetalle.IdProducto = Productos.IdProducto and SurtidosDetalle.IdCedis = @IdCedis and SurtidosDetalle.IdSurtido = @IdSurtido
        where Productos.IdProducto = @IdProducto and Productos.Status = 'A'
end

if @Opc = 2
begin
        select VentasDetalle.IdProducto, isnull(Cantidad, 0) as 'Cantidad', isnull(Precio, 0) as 'Precio', isnull(Subtotal, 0) as 'Subtotal', isnull(Cantidad*Precio*Iva, 0) as 'Impuestos', isnull(Total, 0) as 'Total',
			VentasDetalle.DctoPorc, VentasDetalle.DctoImp, VentasDetalle.Entregado
        from VentasDetalle 
        where VentasDetalle.IdCedis = @IdCedis and VentasDetalle.IdSurtido = @IdSurtido 
        and VentasDetalle.IdTipoVenta = @IdTipoVenta and VentasDetalle.Folio = @Folio and VentasDetalle.IdProducto = @IdProducto
end

if @Opc = 3
begin
        set @CantidadAnterior = isnull( (select sum(Cantidad) from VentasDetalle where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdTipoVenta = @IdTipoVenta and Folio = @Folio and IdProducto = @IdProducto), 0)
        
        select IdProducto, isnull( Surtido - DevBuena - DevMala - Obsequios - VentaContado - VentaCredito + @CantidadAnterior - @Cantidad, 0) as 'Existencia',
        Surtido - DevBuena - DevMala - Obsequios - VentaContado - VentaCredito as 'Disponible', @CantidadAnterior, @Cantidad
        from SurtidosDetalle 
        where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdProducto = @IdProducto
end

if @Opc = 4
begin
        select isnull( sum(Surtido - DevBuena - DevMala - Obsequios - VentaContado - VentaCredito) , 0) as 'Existencia'
        from SurtidosDetalle 
        where IdCedis = @IdCedis and IdSurtido = @IdSurtido -- and SurtidosDetalle.IdProducto = @IdProducto
end

if @Opc = 5
begin
        select VentasDetalle.IdProducto, isnull(Cantidad, 0) as 'Cantidad', isnull(Precio, 0) as 'Precio', isnull(Subtotal, 0) as 'Subtotal', isnull(Cantidad*Precio*Iva, 0) as 'Impuestos', isnull(Total, 0) as 'Total',
			VentasDetalle.DctoPorc, VentasDetalle.DctoImp, VentasDetalle.Entregado
        from VentasDetalle 
        where VentasDetalle.IdCedis = @IdCedis and VentasDetalle.IdSurtido = @IdSurtido and VentasDetalle.IdProducto = @IdProducto
end

if @Opc = 6
begin
        select SurtidosDetalle.IdProducto, Surtido, DevBuena + DevMala + Obsequios + VentaContado + VentaCredito as Movimientos
        From SurtidosDetalle
        Where SurtidosDetalle.IdCedis = @IdCedis And SurtidosDetalle.IdSurtido = @IdSurtido And SurtidosDetalle.IdProducto = @IdProducto
end


GO


