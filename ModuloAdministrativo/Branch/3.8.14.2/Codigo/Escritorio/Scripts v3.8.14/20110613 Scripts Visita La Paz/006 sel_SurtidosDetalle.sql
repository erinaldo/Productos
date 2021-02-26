USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[sel_SurtidosDetalle]    Script Date: 06/17/2011 15:13:08 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sel_SurtidosDetalle]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sel_SurtidosDetalle]
GO

USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[sel_SurtidosDetalle]    Script Date: 06/17/2011 15:13:08 ******/
SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER OFF
GO



CREATE PROCEDURE [dbo].[sel_SurtidosDetalle]
@IdCedis as bigint,
@Fecha as datetime,
@IdSurtido as bigint,
@IdProducto as bigint,
@Opc as int
AS

declare @IdFamiliaRejas as bigint, @IdRuta as bigint, @IdMarca as bigint

if @Opc = 1
begin

        set @IdFamiliaRejas = ( select isnull(idfamiliarejas,0) as Reja from productos left outer join configuracion on idfamilia = idfamiliarejas where idproducto = @IdProducto )

        if @IdFamiliaRejas <> 0  -- producto reja

                select IdProducto, Producto, isnull( (
                        select sum( Surtido ) from Rejas
                        where IdCedis = @IdCedis and IdSurtido = @IdSurtido and Rejas.IdProducto = Productos.IdProducto
                ), 0) as Surtido, 
                isnull( ( 
                        select (Inicial + Entradas - Salidas - Surtido ) --+ DevBuena + DevMala)
                        from InventarioKardex
                        where IdCedis = @IdCedis and Fecha = @Fecha and InventarioKardex.IdProducto = Productos.IdProducto
                ), 0) as 'Inv. Final', Decimales, Status
                from Productos 
                where IdProducto = @IdProducto

        else -- producto no reja

                select IdProducto, Producto, isnull( (
                        select Surtido from SurtidosDetalle
                        where IdCedis = @IdCedis and IdSurtido = @IdSurtido and SurtidosDetalle.IdProducto = Productos.IdProducto
                ), 0) as Surtido, 
                isnull( ( 
                        select (Inicial + Entradas - Salidas - VentaContado - VentaCredito - Obsequios )
                        from InventarioKardex
                        where IdCedis = @IdCedis and Fecha = @Fecha and InventarioKardex.IdProducto = Productos.IdProducto
                ), 0) /*-
                isnull(( select sum(Surtido) from SurtidosDetalle where IdCedis = @IdCedis and Fecha = (select distinct top 1 Fecha from Surtidos where IdCedis = @IdCedis and Fecha > @Fecha order by Fecha) and IdProducto = Productos.IdProducto ),0) */ as 'Inv. Final', Decimales, Status
                from Productos 
                where IdProducto = @IdProducto
end

if @Opc = 2
begin

        select SurtidosDetalle.IdCedis, SurtidosDetalle.IdProducto as 'Cve. Producto', Producto as 'Producto', Surtido as 'Carga', (VentaCredito + VentaContado) as 'Venta',
        DevBuena as 'Dev. Buena', DevMala as 'Dev. Mala', Obsequios as 'Obsequios', Surtido - VentaCredito - VentaContado - DevBuena - DevMala - Obsequios as 'Inv. Final', 
        Precio as 'Precio', Subtotal as 'Subtotal', Surtido*Precio*Productos.Iva as 'Iva', Total as 'Total'
        from SurtidosDetalle 
        inner join Productos on SurtidosDetalle.IdProducto = Productos.IdProducto
        where IdCedis = @IdCedis and IdSurtido = @IdSurtido and Surtido > 0
        -- order by cast(SurtidosDetalle.IdProducto as bigint)

        union
        
        select Rejas.IdCedis, Rejas.IdProducto as 'Cve. Producto', Producto as 'Producto', Surtido as 'Carga', 0 as 'Venta',
        Devolucion as 'Dev. Buena', 0 as 'Dev. Mala', 0 as 'Obsequios', Surtido - Devolucion as 'Inv. Final', 
        0 as 'Precio', 0 as 'Subtotal', 0 as 'Iva', 0 as 'Total'
        from Rejas 
        inner join Productos on Rejas.IdProducto = Productos.IdProducto
        where IdCedis = @IdCedis and IdSurtido = @IdSurtido and Surtido > 0
        -- order by cast(Rejas.IdProducto as bigint)
end

if @Opc = 6
begin
        
        select SurtidosDetalle.IdCedis, SurtidosDetalle.IdProducto as 'Cve. Producto', Producto as 'Producto', Surtido as 'Carga', 
        Precio as 'Precio', Subtotal as 'Subtotal', Surtido*Precio*Productos.Iva as 'Iva', Total as 'Total'
        from SurtidosDetalle 
        inner join Productos on SurtidosDetalle.IdProducto = Productos.IdProducto
        where IdCedis = @IdCedis and IdSurtido = @IdSurtido and Surtido > 0
        -- order by cast(SurtidosDetalle.IdProducto as bigint)

        union
        
        select Rejas.IdCedis, Rejas.IdProducto as 'Cve. Producto', Producto as 'Producto', Surtido as 'Carga', 
        0 as 'Precio', 0 as 'Subtotal', 0 as 'Iva', 0 as 'Total'
        from Rejas 

        inner join Productos on Rejas.IdProducto = Productos.IdProducto
        where IdCedis = @IdCedis and IdSurtido = @IdSurtido and Surtido > 0
        -- order by cast(Rejas.IdProducto as bigint)        

end

if @Opc = 3
begin
        set @IdFamiliaRejas = ( select isnull(idfamiliarejas,0) as Reja from productos left outer join configuracion on idfamilia = idfamiliarejas where idproducto = @IdProducto )

        if @IdFamiliaRejas <> 0  -- producto reja
                select Rejas.IdCedis, Rejas.IdProducto as 'Cve. Producto', Producto as 'Producto', Surtido as 'Carga', 0 as 'Venta',
                Devolucion as 'Dev. Buena', 0 as 'Dev. Mala', 0 as 'Obsequios', Surtido - Devolucion as 'Inv. Final', 
                0 as 'Precio', 0 as 'Subtotal', 0 as 'Iva', 0 as 'Total', Decimales, @IdFamiliaRejas
                from Rejas
                inner join Productos on Rejas.IdProducto = Productos.IdProducto
                where IdCedis = @IdCedis and IdSurtido = @IdSurtido and Surtido > 0 and Rejas.IdProducto = @IdProducto 
                order by cast(Rejas.IdProducto as bigint)

        else -- producto no reja
                select SurtidosDetalle.IdCedis, SurtidosDetalle.IdProducto as 'Cve. Producto', Producto as 'Producto', Surtido as 'Carga', (VentaCredito + VentaContado) as 'Venta',
                DevBuena as 'Dev. Buena', DevMala as 'Dev. Mala', Obsequios as 'Obsequios', Surtido - VentaCredito - VentaContado - DevBuena - DevMala - Obsequios as 'Inv. Final', 
                Precio as 'Precio', Subtotal as 'Subtotal', Surtido*Precio*Productos.Iva as 'Iva', Total as 'Total', Decimales, @IdFamiliaRejas
                from SurtidosDetalle 
                inner join Productos on SurtidosDetalle.IdProducto = Productos.IdProducto
                where IdCedis = @IdCedis and IdSurtido = @IdSurtido and Surtido > 0 and SurtidosDetalle.IdProducto = @IdProducto 
                order by cast(SurtidosDetalle.IdProducto as bigint)
end

if @Opc = 4
begin

        SELECT     SURDET.IdCedis, SURDET.IdProducto AS 'Cve. Prod.', PROD.Producto AS Producto, SURDET.Surtido AS Carga, 
                              SURDET.VentaCredito AS Credito, SURDET.VentaContado AS Contado, SURDET.DevBuena AS 'Dev. Buena', SURDET.DevMala AS 'Dev. Mala', 
                              SURDET.Obsequios AS Obsequios, isnull(sum(VENDET.Total)/sum(VENDET.Cantidad), 0)  AS Precio, ISNULL(SUM(VENDET.Subtotal), 0) AS SubTotal, 
                              ISNULL(SUM(VENDET.Cantidad * VENDET.Precio * VENDET.Iva), 0) AS Iva, ISNULL(SUM(VENDET.Total), 0) AS Total
        FROM         SurtidosDetalle SURDET LEFT OUTER JOIN
                              Productos PROD ON SURDET.IdProducto = PROD.IdProducto LEFT OUTER JOIN
                              VentasDetalle VENDET ON SURDET.IdCedis = VENDET.IdCedis AND SURDET.IdSurtido = VENDET.IdSurtido AND 
                              SURDET.IdProducto = VENDET.IdProducto
        WHERE     (SURDET.IdCedis = @IdCedis) AND (SURDET.Surtido > 0) and (SURDET.idsurtido = @IdSurtido)
        GROUP BY SURDET.IdCedis, SURDET.IdProducto, PROD.Producto, SURDET.Surtido, SURDET.VentaCredito, SURDET.VentaContado, 
                              SURDET.DevBuena, SURDET.DevMala, SURDET.Obsequios, SURDET.Precio
        -- ORDER BY CAST(SURDET.IdProducto AS bigint)

        union

        SELECT     SURDET.IdCedis, SURDET.IdProducto AS 'Cve. Prod.', PROD.Producto AS Producto, SURDET.Surtido AS Carga, 
                              0 AS Credito, 0 AS Contado, SURDET.Devolucion AS 'Dev. Buena', 0 AS 'Dev. Mala', 
                              0 AS Obsequios, 0 AS Precio, 0 AS SubTotal, 0 AS Iva, 0 AS Total
        FROM         Rejas SURDET LEFT OUTER JOIN
                              Productos PROD ON SURDET.IdProducto = PROD.IdProducto LEFT OUTER JOIN
                              VentasDetalle VENDET ON SURDET.IdCedis = VENDET.IdCedis AND SURDET.IdSurtido = VENDET.IdSurtido AND 
                              SURDET.IdProducto = VENDET.IdProducto
        WHERE     (SURDET.IdCedis = @IdCedis) AND (SURDET.Surtido > 0) and (SURDET.idsurtido = @IdSurtido)
        GROUP BY SURDET.IdCedis, SURDET.IdProducto, PROD.Producto, SURDET.Surtido, SURDET.Devolucion
        -- ORDER BY CAST(SURDET.IdProducto AS bigint)

end

if @Opc = 5

        select Tipo, isnull( sum(Subtotal),0) as 'Subtotal', isnull( sum(Cantidad * Precio * Iva),0) as 'Iva', isnull( sum(Total),0) as 'Total'
        from VentasTipo 
        inner join VentasDetalle on IdCedis = @IdCedis and IdSurtido = @IdSurtido and VentasDetalle.IdTipoVenta = VentasTipo.IdTipoVenta
        group by Tipo
        order by Tipo

if @Opc = 7
	select isnull(sum(Surtido), 0), isnull(sum(devbuena), 0), isnull(sum(devmala), 0), isnull(sum(obsequios), 0), isnull(sum(ventacontado + ventacredito), 0),
	isnull(sum(surtido - devbuena - devmala - obsequios - ventacontado - ventacredito), 0), 
	isnull(sum(Entrada), 0), isnull(sum(Salida), 0)
	from SurtidosDetalle
	left outer join SurtidosCambios on SurtidosDetalle.IdCedis = SurtidosCambios.IdCedis and SurtidosDetalle.IdSurtido = SurtidosCambios.IdSurtido and SurtidosDetalle.IdProducto = SurtidosCambios.IdProducto 
	where SurtidosDetalle.IdCedis = @IdCedis and SurtidosDetalle.IdSurtido = @IdSurtido

if @Opc = 8
        SELECT     SURDET.IdCedis, VENTASTIPO.TipoVenta, SURDET.IdProducto AS 'Cve. Prod.', PROD.Producto AS Producto, 
                sum(VENDET.Cantidad) AS Piezas, -- SURDET.VentaContado, SURDET.VentaCredito, 
                VENDET.Precio AS PrecioVenta, ISNULL(SUM(VENDET.Subtotal), 0) AS SubTotal, 
                ISNULL(SUM(VENDET.Cantidad * VENDET.Precio * VENDET.Iva), 0) AS Iva, ISNULL(SUM(VENDET.Total), 0) AS Total, 
                SURDET.Precio AS PrecioBase
        FROM         SurtidosDetalle SURDET LEFT OUTER JOIN
                              Productos PROD ON SURDET.IdProducto = PROD.IdProducto LEFT OUTER JOIN
                              VentasDetalle VENDET ON SURDET.IdCedis = VENDET.IdCedis AND SURDET.IdSurtido = VENDET.IdSurtido AND 
                              SURDET.IdProducto = VENDET.IdProducto LEFT OUTER JOIN 
                        VENTASTIPO ON VENTASTIPO.IdTipoVenta = VENDET.IdTipoVenta                                
        WHERE     (SURDET.IdCedis = @IdCedis) AND (SURDET.Surtido > 0) and (SURDET.idsurtido = @IdSurtido) AND SURDET.VentaContado + SURDET.VentaCredito  > 0
        GROUP BY SURDET.IdCedis, SURDET.IdProducto, PROD.Producto, SURDET.Surtido, SURDET.VentaCredito, SURDET.VentaContado, 
                              SURDET.DevBuena, SURDET.DevMala, SURDET.Obsequios, SURDET.Precio, VENDET.Precio, VENTASTIPO.TipoVenta,
                        VENTASTIPO.Tipo
        HAVING SURDET.Precio <> ISNULL(SUM(VENDET.Precio), 0) 
        ORDER BY SURDET.IdCedis, cast( SURDET.IdProducto as int)

if @Opc = 10
begin

        SELECT     SURDET.IdCedis, SURDET.IdProducto AS 'Cve. Prod.', PROD.Producto AS Producto, SURDET.Surtido AS Carga, 
                              SURDET.VentaCredito AS Credito, SURDET.VentaContado AS Contado, SURDET.DevBuena AS 'Dev. Buena', SURDET.DevMala AS 'Dev. Mala', 
                              SURDET.Obsequios AS Obsequios, isnull(sum(VENDET.Total)/sum(VENDET.Cantidad), 0)  AS Precio, ISNULL(SUM(VENDET.Subtotal), 0) AS SubTotal, 
                              ISNULL(SUM(VENDET.Cantidad * VENDET.Precio * VENDET.Iva), 0) AS Iva, ISNULL(SUM(VENDET.Total), 0) AS Total, Marcas.IdMarca as IdMarca, Marcas.Marca as Marca, 
                              SURDET.Fecha, SURDET.IdSurtido, Rutas.Ruta, case SUR.Status when 'A' then 'Aplicado' else 'Pendiente' end as Estatus
        FROM         SurtidosDetalle SURDET LEFT OUTER JOIN
                              Productos PROD ON SURDET.IdProducto = PROD.IdProducto LEFT OUTER JOIN
                              VentasDetalle VENDET ON SURDET.IdCedis = VENDET.IdCedis AND SURDET.IdSurtido = VENDET.IdSurtido AND 
                              SURDET.IdProducto = VENDET.IdProducto LEFT OUTER join 
                              Marcas on Marcas.IdMarca = PROD.IdMarca LEFT OUTER join 
							  Surtidos SUR on SUR.IdCedis = SURDET.IdCedis and SUR.IdSurtido = SURDET.IdSurtido LEFT OUTER join 
							  Rutas on Rutas.IdCedis = SUR.IdCedis and Rutas.IdRuta = SUR.IdRuta 
        WHERE     (SURDET.IdCedis = @IdCedis) AND (SURDET.Surtido > 0) and (SURDET.idsurtido = @IdSurtido)
        GROUP BY SURDET.IdCedis, SURDET.IdProducto, PROD.Producto, SURDET.Surtido, SURDET.VentaCredito, SURDET.VentaContado, 
                              SURDET.DevBuena, SURDET.DevMala, SURDET.Obsequios, SURDET.Precio, Marcas.IdMarca, Marcas.Marca, 
							SURDET.Fecha, SURDET.IdSurtido, Rutas.Ruta, SUR.Status
        -- ORDER BY CAST(SURDET.IdProducto AS bigint)

        union

        SELECT     SURDET.IdCedis, SURDET.IdProducto AS 'Cve. Prod.', PROD.Producto AS Producto, SURDET.Surtido AS Carga, 
                              0 AS Credito, 0 AS Contado, SURDET.Devolucion AS 'Dev. Buena', 0 AS 'Dev. Mala', 
                              0 AS Obsequios, 0 AS Precio, 0 AS SubTotal, 0 AS Iva, 0 AS Total, Marcas.IdMarca as IdMarca, Marcas.Marca as Marca, 
                              SURDET.Fecha, SURDET.IdSurtido, Rutas.Ruta, case SUR.Status when 'A' then 'Aplicado' else 'Pendiente' end as Estatus
        FROM         Rejas SURDET LEFT OUTER JOIN
                              Productos PROD ON SURDET.IdProducto = PROD.IdProducto LEFT OUTER JOIN
                              VentasDetalle VENDET ON SURDET.IdCedis = VENDET.IdCedis AND SURDET.IdSurtido = VENDET.IdSurtido AND 
                              SURDET.IdProducto = VENDET.IdProducto  LEFT OUTER join Marcas 
                              on Marcas.IdMarca = PROD.IdMarca  LEFT OUTER join 
							  Surtidos SUR on SUR.IdCedis = SURDET.IdCedis and SUR.IdSurtido = SURDET.IdSurtido LEFT OUTER join 
							  Rutas on Rutas.IdCedis = SUR.IdCedis and Rutas.IdRuta = SUR.IdRuta 
        WHERE     (SURDET.IdCedis = @IdCedis) AND (SURDET.Surtido > 0) and (SURDET.idsurtido = @IdSurtido)
        GROUP BY SURDET.IdCedis, SURDET.IdProducto, PROD.Producto, SURDET.Surtido, SURDET.Devolucion, Marcas.IdMarca, Marcas.Marca, 
				SURDET.Fecha, SURDET.IdSurtido, Rutas.Ruta, SUR.Status
        ORDER BY IDMARCA
end

if @Opc = 11
begin

	set @IdMarca = @IdProducto 
	set @IdRuta = (select IdRuta from Surtidos where IdCedis = @IdCedis and IdSurtido = @IdSurtido )

	select Tipo, isnull( sum(Subtotal),0) as 'Subtotal', isnull( sum(Cantidad * Precio * VentasDetalle.Iva),0) as 'Iva', isnull( sum(Total),0) as 'Total'
	from VentasTipo 
	inner join VentasDetalle on IdCedis = @IdCedis and IdSurtido = @IdSurtido and VentasDetalle.IdTipoVenta = VentasTipo.IdTipoVenta
	inner join Productos on Productos.IdProducto = VentasDetalle.IdProducto and IdMarca = @IdMarca 
	group by Tipo
	
	union
	
	select 99 as Tipo, 0 as Subtotal, 0 as Iva, sum(t.Total) as Total
		from (
		select USU.Clave, ABN.ABNId, ABT.Importe as Total
		from Route.dbo.AbnTrp ABT
		inner join Route.dbo.TransProd FAC on ABT.TransProdID = FAC.TransProdID 
		inner join Route.dbo.Abono ABN on ABT.ABNId = ABN.ABNId 
		inner join Route.dbo.Dia Dia on ABN.DiaClave = Dia.DiaClave
		inner join Route.dbo.Visita VIS on ABN.VisitaClave = VIS.VisitaClave
		inner join Route.dbo.Vendedor VEN on VEN.VendedorID = VIS.VendedorID
		inner join Route.dbo.Usuario USU on USU.USUId = VEN.USUId
		where Dia.FechaCaptura= @Fecha and USU.Clave = cast( @IdCedis as varchar(10) ) + replicate('0', 4 - len( @IdRuta ) ) + cast( @IdRuta as varchar(10) )
		and FAC.Tipo = 8 and FAC.TipoFase <> 0 and (FAC.CFVTipo = 2 or FAC.CFVTipo is null) and FAC.SubEmpresaId = @IdMarca
		)as t
		group by t.Clave 
	order by Tipo
end

if @Opc = 12
begin

	set @IdRuta = (select IdRuta from Surtidos where IdCedis = @IdCedis and IdSurtido = @IdSurtido )

	select Tipo, isnull( sum(Subtotal),0) as 'Subtotal', isnull( sum(Cantidad * Precio * VentasDetalle.Iva),0) as 'Iva', isnull( sum(Total),0) as 'Total'
	from VentasTipo 
	inner join VentasDetalle on IdCedis = @IdCedis and IdSurtido = @IdSurtido and VentasDetalle.IdTipoVenta = VentasTipo.IdTipoVenta
	-- inner join Productos on Productos.IdProducto = VentasDetalle.IdProducto and IdMarca = @IdMarca 
	group by Tipo
	
	union
	
	select 99 as Tipo, 0 as Subtotal, 0 as Iva, sum(t.Total) as Total
		from (
		select USU.Clave, ABN.ABNId, ABT.Importe as Total
		from Route.dbo.AbnTrp ABT
		inner join Route.dbo.TransProd FAC on ABT.TransProdID = FAC.TransProdID 
		inner join Route.dbo.Abono ABN on ABT.ABNId = ABN.ABNId 
		inner join Route.dbo.Dia Dia on ABN.DiaClave = Dia.DiaClave
		inner join Route.dbo.Visita VIS on ABN.VisitaClave = VIS.VisitaClave
		inner join Route.dbo.Vendedor VEN on VEN.VendedorID = VIS.VendedorID
		inner join Route.dbo.Usuario USU on USU.USUId = VEN.USUId
		where Dia.FechaCaptura= @Fecha and USU.Clave = cast( @IdCedis as varchar(10) ) + replicate('0', 4 - len( @IdRuta ) ) + cast( @IdRuta as varchar(10) )
		and FAC.Tipo = 8 and FAC.TipoFase <> 0 and (FAC.CFVTipo = 2 or FAC.CFVTipo is null) -- and TRP.SubEmpresaId = @IdMarca
		)as t
		group by t.Clave 

	order by Tipo

end

if @Opc = 13
begin

	set @IdRuta = (select IdRuta from Surtidos where IdCedis = @IdCedis and IdSurtido = @IdSurtido )

	delete from RepCreditosCobranza where IdCedis = @IdCedis and IdSurtido = @IdSurtido
	
	insert into RepCreditosCobranza (IdCedis, IdSurtido, Orden, Concepto, IdMarca, Marca, NombreSucursal, Folio, Total)
	select @IdCedis, @IdSurtido, 1 as Orden, 'CRÉDITOS' as Concepto, Marcas.IdMarca as IdMarca, left(Marcas.Marca, 30), left(NombreSucursal, 60), Ventas.Serie + cast(Ventas.Folio as varchar(10)) as Folio, sum(VentasDetalle.Total) as Total
	from Ventas 
	inner join VentasDetalle on Ventas.IdCedis = VentasDetalle.IdCedis and Ventas.IdSurtido = VentasDetalle.IdSurtido 
		and Ventas.IdTipoVenta = VentasDetalle.IdTipoVenta and Ventas.Folio = VentasDetalle.Folio 
	inner join Productos on Productos.IdProducto = VentasDetalle.IdProducto 
	inner join Marcas on Marcas.IdMarca = Productos.IdMarca  
	inner join ClienteSucursal on ClienteSucursal.IdSucursal = Ventas.IdSucursal 
--	inner join Surtidos on Surtidos.IdCedis = Ventas.IdCedis and Surtidos.IdCedis = Ventas.IdCedis 
	where Ventas.IdCedis = @IdCedis and Ventas.IdSurtido = @IdSurtido and Ventas.IdTipoVenta = 2
	group by Marcas.IdMarca, Marcas.Marca, Ventas.IdSucursal, NombreSucursal, Ventas.Serie, Ventas.Folio

	insert into RepCreditosCobranza (IdCedis, IdSurtido, Orden, Concepto, M.IdMarca, M.Marca, NombreSucursal, Folio, Total)
	select @IdCedis, @IdSurtido, 2 as Orden, 'COBRANZA' as Concepto, M.IdMarca as IdMarca, left(M.Marca,30) Marca, left(CS.NombreCorto,60) NombreSucursal, FAC.Folio as Folio, sum(ABT.Importe) as Total -- replace(FAC.Folio, 'X', '') as Folio
	from Route.dbo.AbnTrp ABT
	inner join Route.dbo.TransProd FAC on ABT.TransProdID = FAC.TransProdID 
	inner join Route.dbo.Abono ABN on ABT.ABNId = ABN.ABNId 
	inner join Route.dbo.Dia Dia on ABN.DiaClave = Dia.DiaClave
	inner join Route.dbo.Visita VIS on ABN.VisitaClave = VIS.VisitaClave
	inner join Route.dbo.Vendedor VEN on VEN.VendedorID = VIS.VendedorID
	inner join Route.dbo.Usuario USU on USU.USUId = VEN.USUId
	inner join Marcas M on M.IdMarca = FAC.SubEmpresaID 
	inner join Route.dbo.Cliente CS on CS.ClienteClave = VIS.ClienteClave 
	where Dia.FechaCaptura= @Fecha and USU.Clave = cast( @IdCedis as varchar(10) ) + replicate('0', 4 - len( @IdRuta ) ) + cast( @IdRuta as varchar(10) )
	and FAC.Tipo = 8 and FAC.TipoFase <> 0 and (FAC.CFVTipo = 2 or FAC.CFVTipo is null) 
	group by M.IdMarca, M.Marca, CS.NombreCorto, FAC.Folio

end

if @Opc = 14
begin

	select *
	from RepCreditosCobranza
	where IdCedis = @IdCedis and IdSurtido = @IdSurtido 
	order by Orden, IdMarca, NombreSucursal

end

if @Opc = 9
begin

        set @IdFamiliaRejas = ( select isnull(idfamiliarejas,0) as Reja from productos left outer join configuracion on idfamilia = idfamiliarejas where idproducto = @IdProducto )

        if @IdFamiliaRejas <> 0  -- producto reja

                select IdProducto, Producto, isnull( (
                        select sum( Surtido ) from Rejas
                        where IdCedis = @IdCedis and IdSurtido = @IdSurtido and Rejas.IdProducto = Productos.IdProducto
                ), 0) as Surtido, 
                isnull( ( 
                        select (Inicial + Entradas - Salidas - Surtido + DevBuena + DevMala) 
                        from InventarioKardex
                        where IdCedis = @IdCedis and Fecha = @Fecha and InventarioKardex.IdProducto = Productos.IdProducto
                ), 0) as 'Inv. Final', Decimales, Status
                from Productos 
                where IdProducto = @IdProducto

        else -- producto no reja

                select IdProducto, Producto, isnull( (
                        select Surtido from SurtidosDetalle
                        where IdCedis = @IdCedis and IdSurtido = @IdSurtido and SurtidosDetalle.IdProducto = Productos.IdProducto
                ), 0) as Surtido, 
                isnull( ( 
                        select (Inicial + Entradas - Salidas - Surtido + DevBuena + DevMala) 
                        from InventarioKardex
                        where IdCedis = @IdCedis and Fecha = @Fecha and InventarioKardex.IdProducto = Productos.IdProducto
                ), 0) /*-
                isnull(( select sum(Surtido) from SurtidosDetalle where IdCedis = @IdCedis and Fecha > @Fecha and IdProducto = Productos.IdProducto ),0) */
				as 'Inv. Final', Decimales, Status
                from Productos 
                where IdProducto = @IdProducto
end

GO


