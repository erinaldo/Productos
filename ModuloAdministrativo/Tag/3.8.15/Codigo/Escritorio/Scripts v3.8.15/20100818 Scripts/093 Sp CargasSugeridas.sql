USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[sel_CargasSugeridas]    Script Date: 08/18/2010 18:37:08 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sel_CargasSugeridas]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sel_CargasSugeridas]
GO

/****** Object:  StoredProcedure [dbo].[sel_CargasSugeridasE]    Script Date: 08/18/2010 18:37:08 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sel_CargasSugeridasE]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sel_CargasSugeridasE]
GO

/****** Object:  StoredProcedure [dbo].[sel_CargasSugeridasFolio]    Script Date: 08/18/2010 18:37:08 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sel_CargasSugeridasFolio]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sel_CargasSugeridasFolio]
GO

/****** Object:  StoredProcedure [dbo].[sel_CargasSugeridasParametros]    Script Date: 08/18/2010 18:37:08 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sel_CargasSugeridasParametros]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sel_CargasSugeridasParametros]
GO

/****** Object:  StoredProcedure [dbo].[up_CargasSugeridas]    Script Date: 08/18/2010 18:37:08 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[up_CargasSugeridas]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[up_CargasSugeridas]
GO

/****** Object:  StoredProcedure [dbo].[up_CargasSugeridasDetalle]    Script Date: 08/18/2010 18:37:08 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[up_CargasSugeridasDetalle]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[up_CargasSugeridasDetalle]
GO

/****** Object:  StoredProcedure [dbo].[up_CargasSugeridasDetalle2]    Script Date: 08/18/2010 18:37:08 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[up_CargasSugeridasDetalle2]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[up_CargasSugeridasDetalle2]
GO

/****** Object:  StoredProcedure [dbo].[up_CargasSugeridasParametros]    Script Date: 08/18/2010 18:37:08 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[up_CargasSugeridasParametros]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[up_CargasSugeridasParametros]
GO

/****** Object:  StoredProcedure [dbo].[up_CargasSugeridasRutas]    Script Date: 08/18/2010 18:37:08 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[up_CargasSugeridasRutas]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[up_CargasSugeridasRutas]
GO

USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[sel_CargasSugeridas]    Script Date: 08/18/2010 18:37:08 ******/
SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER OFF
GO

CREATE PROCEDURE [dbo].[sel_CargasSugeridas] 
@IdCedis as bigint,
@IdRuta as bigint,
@FechaCarga as datetime,
@Folio as bigint,
@IdProducto as bigint,
@Opc as int
AS

if @Opc = 1
	select Productos.IdProducto, Producto
	from Productos
	where Productos.IdProducto = @IdProducto and Productos.Status = 'A'

if @Opc = 2
	select Productos.IdProducto, Producto, isnull(Cantidad,0) as 'Cantidad', isnull(Cambios,0) as 'Cambios', Decimales,
	ISNULL(Factor,0) as Factor, isnull(Divide, ''), ISNULL(IdUnidad, '') as IdUnidad,
	case Divide 
		when 'N' then cast(Cantidad * ISNULL(Factor,0) as bigint) 
		when 'S' then cast(Cantidad / isnull(Factor,1) as bigint) else 0 end as UnidadC,
	case Divide 
		when 'N' then (Cantidad * ISNULL(Factor,0)) - cast(Cantidad * ISNULL(Factor,0) as bigint) 
		when 'S' then (Cantidad / isnull(Factor,1) - cast(Cantidad / isnull(Factor,1) as bigint)) * isnull(Factor,1) else Cantidad end as PiezasC,
	case Divide 
		when 'N' then cast(Cambios * ISNULL(Factor,0) as bigint) 
		when 'S' then cast(Cambios / isnull(Factor,1) as bigint) else 0 end as UnidadD,
	case Divide 
		when 'N' then (Cambios * ISNULL(Factor,0)) - cast(Cambios * ISNULL(Factor,0) as bigint) 
		when 'S' then (Cambios / isnull(Factor,1) - cast(Cambios / isnull(Factor,1) as bigint)) * isnull(Factor,1) else Cambios end as PiezasD
	from Productos
	left outer join CargasSugeridasDetalle on Productos.IdProducto = CargasSugeridasDetalle.IdProducto 
	and CargasSugeridasDetalle.IdCedis = @IdCedis and CargasSugeridasDetalle.IdRuta = @IdRuta and CargasSugeridasDetalle.FechaCarga = @FechaCarga and Folio = @Folio 
	left outer join ProductosUnidad on ProductosUnidad.IdProducto = Productos.IdProducto 
	where Productos.IdProducto = @IdProducto and Productos.Status = 'A'

if @Opc = 3 or @Opc = 4 or @Opc = 5
begin
	select CargasSugeridasDetalle.IdCedis, CargasSugeridasDetalle.IdRuta, CargasSugeridasDetalle.IdProducto, Producto, 
	CargasSugeridasDetalle.Venta, CargasSugeridasDetalle.Cantidad as 'Cantidad Calculada', CargasSugeridasDetalle.Cambios, 
	CargasSugeridasDetalle.Venta * Conversion as VentaK, CargasSugeridasDetalle.Cantidad * Conversion as 'Cantidad CalculadaK', 
	CargasSugeridasDetalle.Cambios * Conversion as CambiosK,
	InventarioKardex.Teorico as 'Disponible', InventarioKardex.Teorico * Conversion as 'DisponibleK',
	( select sum(Surtido) 
		from SurtidosDetalle 
		where SurtidosDetalle.IdCedis = CargasSugeridasDetalle.IdCedis and SurtidosDetalle.IdProducto = CargasSugeridasDetalle.IdProducto 
		and SurtidosDetalle.Fecha = @FechaCarga) as 'Total Cargas',
	( select sum(Surtido) 
		from SurtidosDetalle 
		where SurtidosDetalle.IdCedis = CargasSugeridasDetalle.IdCedis and SurtidosDetalle.IdProducto = CargasSugeridasDetalle.IdProducto 
		and SurtidosDetalle.Fecha = @FechaCarga) * Conversion as 'Total CargasK',
	InventarioKardex.Teorico - ( select sum(Surtido) 
		from SurtidosDetalle 
		where SurtidosDetalle.IdCedis = CargasSugeridasDetalle.IdCedis and SurtidosDetalle.IdProducto = CargasSugeridasDetalle.IdProducto 
		and SurtidosDetalle.Fecha = @FechaCarga) as 'Inv. Final',
	(InventarioKardex.Teorico - ( select sum(Surtido) 
		from SurtidosDetalle 
		where SurtidosDetalle.IdCedis = CargasSugeridasDetalle.IdCedis and SurtidosDetalle.IdProducto = CargasSugeridasDetalle.IdProducto 
		and SurtidosDetalle.Fecha = @FechaCarga)) * Conversion as 'Inv. FinalK',

-- PIEZAS CAJAS 	
	case Divide 
		when 'N' then cast(Venta * ISNULL(Factor,0) as bigint) 
		when 'S' then cast(Venta / isnull(Factor,1) as bigint) else 0 end as UnidadV,
    case Divide 
		when 'N' then (Venta * ISNULL(Factor,0)) - cast(Venta * ISNULL(Factor,0) as bigint) 
		when 'S' then (Venta / isnull(Factor,1) - cast(Venta / isnull(Factor,1) as bigint)) * isnull(Factor,1) else Venta end as PiezasV,
	case Divide 
		when 'N' then cast(Cantidad * ISNULL(Factor,0) as bigint) 
		when 'S' then cast(Cantidad / isnull(Factor,1) as bigint) else 0 end as UnidadC,
    case Divide 
		when 'N' then (Cantidad * ISNULL(Factor,0)) - cast(Cantidad * ISNULL(Factor,0) as bigint) 
		when 'S' then (Cantidad / isnull(Factor,1) - cast(Cantidad / isnull(Factor,1) as bigint)) * isnull(Factor,1) else Cantidad end as PiezasC,
	case Divide 
		when 'N' then cast(Cambios * ISNULL(Factor,0) as bigint) 
		when 'S' then cast(Cambios / isnull(Factor,1) as bigint) else 0 end as UnidadD,
    case Divide 
		when 'N' then (Cambios * ISNULL(Factor,0)) - cast(Cambios * ISNULL(Factor,0) as bigint) 
		when 'S' then (Cambios / isnull(Factor,1) - cast(Cambios / isnull(Factor,1) as bigint)) * isnull(Factor,1) else Cambios end as PiezasD,
	
	( select case Divide 
		when 'N' then cast(sum(Surtido) * ISNULL(Factor,0) as bigint) 
		when 'S' then cast(sum(Surtido) / isnull(Factor,1) as bigint) else 0 end 
		from SurtidosDetalle 
		left outer join ProductosUnidad PU on PU.IdProducto = Productos.IdProducto and IdUnidad = 'CAJA'
		where SurtidosDetalle.IdCedis = CargasSugeridasDetalle.IdCedis and SurtidosDetalle.IdProducto = CargasSugeridasDetalle.IdProducto 
		and SurtidosDetalle.Fecha = @FechaCarga group by Divide, Factor) as 'Total CargasU',
	
	( select case Divide 
		when 'N' then (sum(Surtido) * ISNULL(Factor,0)) - cast(sum(Surtido) * ISNULL(Factor,0) as bigint) 
		when 'S' then (sum(Surtido) / isnull(Factor,1) - cast(sum(Surtido) / isnull(Factor,1) as bigint)) * isnull(Factor,1) else SUM(Surtido) end
		from SurtidosDetalle 
		where SurtidosDetalle.IdCedis = CargasSugeridasDetalle.IdCedis and SurtidosDetalle.IdProducto = CargasSugeridasDetalle.IdProducto 
		and SurtidosDetalle.Fecha = @FechaCarga group by Divide, Factor) * Conversion as 'Total CargasC'
	from CargasSugeridasDetalle
	inner join Productos on CargasSugeridasDetalle.IdProducto = Productos.IdProducto
	left outer join ProductosUnidad PU on PU.IdProducto = Productos.IdProducto and IdUnidad = 'CAJA'
	inner join InventarioKardex on InventarioKardex.IdCedis = CargasSugeridasDetalle.IdCedis and InventarioKardex.IdProducto = CargasSugeridasDetalle.IdProducto
		and InventarioKardex.Fecha in (select top 1 Fecha from InventarioKardex where Fecha < @FechaCarga order by Fecha desc)
	where CargasSugeridasDetalle.IdCedis = @IdCedis and CargasSugeridasDetalle.IdRuta = @IdRuta and FechaCarga = @FechaCarga and Tipo = (@Opc - 3) and Folio = @Folio 
	order by Productos.IdProducto
end

if @Opc = 6
begin
	if not exists(select top 1 IdCedis from CargasSugeridasDetalle where IdCedis = @IdCedis and IdRuta = @IdRuta and FechaCarga = @FechaCarga and Tipo = '2')
		if exists(select top 1 IdCedis from CargasSugeridasDetalle where IdCedis = @IdCedis and IdRuta = @IdRuta and FechaCarga = '19000101' and Tipo = '2')
		begin 
			select @Folio = ISNULL(MAX(Folio) + 1,1) 
			from CargasSugeridas 
			where IdCedis = @IdCedis and IdRuta = @IdRuta and FechaCarga = @FechaCarga -- and Tipo = '2' 
		
			insert into CargasSugeridas values (@IdCedis, @IdRuta, @FechaCarga, '2', @Folio, 0, 0, 'A')	

			update CargasSugeridasDetalle set FechaCarga = @FechaCarga, Folio = @Folio 
			where IdCedis = @IdCedis and IdRuta = @IdRuta and FechaCarga = '19000101' and Tipo = '2'
		end
end

if @Opc = 7
begin
	select distinct IdRuta, FechaCarga 
	from CargasSugeridasDetalle 
	where Tipo = @IdProducto and IdRuta = @IdRuta and IdCedis = @IdCedis -- and Folio = @Folio 
	order by IdRuta, FechaCarga desc
end
GO

/****** Object:  StoredProcedure [dbo].[sel_CargasSugeridasE]    Script Date: 08/18/2010 18:37:08 ******/
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

GO

/****** Object:  StoredProcedure [dbo].[sel_CargasSugeridasFolio]    Script Date: 08/18/2010 18:37:08 ******/
SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER OFF
GO

CREATE PROCEDURE [dbo].[sel_CargasSugeridasFolio] 
@IdCedis as bigint,
@FechaCarga as datetime,
@IdRuta as bigint,
@Tipo as char(1),
@Opc as int
AS

if @Opc = 1
begin

	select IdCedis, IdRuta, FechaCarga, Tipo, Folio, IdSurtido as 'Folio de Liquidación', IdCarga as 'Folio de Carga',
	case Status 
		when 'A' then 'Activo' 
		when 'B' then 'Baja' 
		when 'I' then 'Importada' 
	end as 'Status', Status as Stat
	from CargasSugeridas 
	where IdCedis = @IdCedis and IdRuta = @IdRuta and FechaCarga = @FechaCarga and Tipo = @Tipo and Status <> 'B' 

end

if @Opc = 2
begin

	select IdCedis, IdRuta, FechaCarga, Tipo, Folio, IdSurtido as 'Folio de Liquidación', IdCarga as 'Folio de Carga', 
	case Status 
		when 'A' then 'Activo' 
		when 'B' then 'Baja' 
		when 'I' then 'Importada' 
	end as 'Status', Status as Stat
	from CargasSugeridas 
	where IdCedis = @IdCedis and IdRuta = @IdRuta and FechaCarga = @FechaCarga and Status = 'A' 

end

GO

/****** Object:  StoredProcedure [dbo].[sel_CargasSugeridasParametros]    Script Date: 08/18/2010 18:37:08 ******/
SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER OFF
GO

CREATE PROCEDURE [dbo].[sel_CargasSugeridasParametros]
@IdCedis as bigint,
@IdRuta as bigint,
@FechaCarga as datetime,
@Folio as bigint,
@IdProducto as bigint,
@Opc as int
AS

if @Opc = 1
	select 2 as Orden, 'Producto' as Concepto, Productos.IdProducto as Cve, Productos.Producto as 'Descripción', CargasSugeridasProducto.Semanas, CargasSugeridasProducto.Porcentaje
	from CargasSugeridasProducto 
	inner join Productos on Productos.IdProducto = CargasSugeridasProducto.IdProducto
	where CargasSugeridasProducto.IdCedis = @IdCedis and CargasSugeridasProducto.IdRuta = @IdRuta and CargasSugeridasProducto.FechaCarga = @FechaCarga and CargasSugeridasProducto.Folio = @Folio 
	union
	select 1 as Orden, 'Familia' as Concepto, Familias.IdFamilia as Cve, Familias.Familia as 'Descripción', CargasSugeridasFamilia.Semanas, CargasSugeridasFamilia.Porcentaje
	from CargasSugeridasFamilia 
	inner join Familias on Familias.IdFamilia = CargasSugeridasFamilia.IdFamilia
	where CargasSugeridasFamilia.IdCedis = @IdCedis and CargasSugeridasFamilia.IdRuta = @IdRuta and CargasSugeridasFamilia.FechaCarga = @FechaCarga and CargasSugeridasFamilia.Folio = @Folio 
	order by Orden

if @Opc = 2
	select max(CargasSugeridasFamilia.Semanas) as Mayor
	from CargasSugeridasFamilia 
	inner join Familias on Familias.IdFamilia = CargasSugeridasFamilia.IdFamilia
	inner join Productos on Productos.IdFamilia = CargasSugeridasFamilia.IdFamilia 
		and Productos.IdProducto not in ( select CargasSugeridasProducto.IdProducto from CargasSugeridasProducto 
		where CargasSugeridasProducto.IdCedis = @IdCedis and CargasSugeridasProducto.IdRuta = @IdRuta and CargasSugeridasProducto.FechaCarga = @FechaCarga and CargasSugeridasProducto.Folio = @Folio)
	where CargasSugeridasFamilia.IdCedis = @IdCedis and CargasSugeridasFamilia.IdRuta = @IdRuta and CargasSugeridasFamilia.FechaCarga = @FechaCarga and CargasSugeridasFamilia.Folio = @Folio 
	union
	select max(CargasSugeridasProducto.Semanas) as Mayor
	from CargasSugeridasProducto
	where CargasSugeridasProducto.IdCedis = @IdCedis and CargasSugeridasProducto.IdRuta = @IdRuta and CargasSugeridasProducto.FechaCarga = @FechaCarga and CargasSugeridasProducto.Folio = @Folio 
	order by Mayor desc

if @Opc = 3
	select Rutas.IdCedis, Rutas.IdRuta, Rutas.Ruta, TipoRuta.TipoRuta as 'Especialización', Rutas.TipoVenta as 'TipoVenta',
	isnull((select Top 1 FechaInicial from CargasSugeridasRuta where IdCedis = @IdCedis and IdRuta = @IdRuta and FechaCarga = @FechaCarga and Folio = @Folio),0) as 'F. Inicial',
	isnull((select Top 1 FechaFinal from CargasSugeridasRuta where IdCedis = @IdCedis and IdRuta = @IdRuta and FechaCarga = @FechaCarga and Folio = @Folio),0) as 'F. Final',
	isnull((select IdRutaPedido from CargasSugeridasRuta where IdCedis = @IdCedis and IdRuta = @IdRuta and FechaCarga = @FechaCarga and IdRutaPedido = Rutas.IdRuta and Folio = @Folio),0) as 'Selected'
	from Rutas
	inner join TipoRuta on TipoRuta.IdTipoRuta = Rutas.TipoRuta
	where Rutas.IdCedis = @IdCedis and Rutas.Status = 'A'
	order by Rutas.IdRuta
	
	
GO

/****** Object:  StoredProcedure [dbo].[up_CargasSugeridas]    Script Date: 08/18/2010 18:37:08 ******/
SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER OFF
GO

CREATE PROCEDURE [dbo].[up_CargasSugeridas]
@IdCedis as bigint,
@IdRuta as bigint,
@FechaCarga as datetime,
@Tipo as char(1),
@Folio as bigint,
@IdSurtido as bigint,
@IdCarga as bigint,
@Status as char(1),
@Opc as int
AS

declare @Route as int
set @Route = isnull( ( select Route from Configuracion where IdCedis = @IdCedis ), 0 )

if @Opc = 1
begin	

	select @Folio = ISNULL(MAX(Folio) + 1,1) 
	from CargasSugeridas 
	where IdCedis = @IdCedis and IdRuta = @IdRuta and FechaCarga = @FechaCarga -- and Tipo = @Tipo 

	insert into CargasSugeridas values (@IdCedis, @IdRuta, @FechaCarga, @Tipo, @Folio, 0, 0, 'A')	
end

if @Opc = 2
begin
	update CargasSugeridas
	set Status = 'B'
	where IdCedis = @IdCedis and IdRuta = @IdRuta and FechaCarga = @FechaCarga and Tipo = @Tipo and Folio = @Folio 
	
	delete from CargasSugeridasDetalle 
	where IdCedis = @IdCedis and IdRuta = @IdRuta and FechaCarga = @FechaCarga and Tipo = @Tipo and Folio = @Folio 
	
end


GO

/****** Object:  StoredProcedure [dbo].[up_CargasSugeridasDetalle]    Script Date: 08/18/2010 18:37:08 ******/
SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER OFF
GO

CREATE PROCEDURE [dbo].[up_CargasSugeridasDetalle]
@IdCedis as bigint,
@IdRuta as bigint,
@FechaCarga as datetime,
@Filtro as varchar(1000),
@Semanas as float,
@Tipo as char(1),
@Folio as bigint,
@Opc as int
AS

declare 
@IdProducto as int, 
@IdProductoDetalle as int,
@Cambios as float,
@Calculo as float

declare @Route as int
set @Route = isnull( ( select Route from Configuracion where IdCedis = @IdCedis ), 0 )

if @Opc = 1
begin	
	exec( 'insert into CargasSugeridasDetalle 
	
		select ' + @IdCedis + ', ' + @IdRuta + ', ''' + @FechaCarga + ''', VentasDetalle.IdProducto, ' + @Tipo + ', sum(VentasDetalle.Cantidad) as Venta, case FN_CargasSugeridas.Decimales
			when 0 then round(sum(VentasDetalle.Cantidad) * (1 + FN_CargasSugeridas.Porcentaje ), -1) 
			when 1 then sum(VentasDetalle.Cantidad) * (1 + FN_CargasSugeridas.Porcentaje )
			end as Calculo, 0
		from Surtidos 
		inner join VentasDetalle on VentasDetalle.IdCedis = Surtidos.IdCedis and Surtidos.IdSurtido = VentasDetalle.IdSurtido
		inner join FN_CargasSugeridas (' + @IdCedis + ', ' + @IdRuta + ', ''' + @FechaCarga + ''', ' + @Folio + ') on FN_CargasSugeridas.IdProducto = VentasDetalle.IdProducto and FN_CargasSugeridas.Semanas = ' + @Semanas + '
		where Surtidos.IdCedis = ' + @IdCedis + ' and Surtidos.IdRuta = ' + @IdRuta + ' and Surtidos.Fecha in ( ' + @Filtro + ')
		group by VentasDetalle.IdProducto, FN_CargasSugeridas.Porcentaje, FN_CargasSugeridas.Decimales ')
end

if @Opc = 2
	delete from CargasSugeridasDetalle 
	where IdCedis = @IdCedis and IdRuta = @IdRuta and FechaCarga = @FechaCarga and Tipo = @Tipo and Folio = @Folio 

if @Opc = 3
begin
	set @IdProducto = cast(@Filtro as bigint)
	set @Cambios = @Semanas

	if exists (select IdProducto from CargasSugeridasDetalle where IdCedis = @IdCedis and IdRuta = @IdRuta and FechaCarga = @FechaCarga and IdProducto = @IdProducto and Tipo = @Tipo and Folio = @Folio)
		update CargasSugeridasDetalle set Cambios = @Cambios where IdCedis = @IdCedis and IdRuta = @IdRuta and FechaCarga = @FechaCarga and IdProducto = @IdProducto and Tipo = @Tipo and Folio = @Folio 
	else
		insert into CargasSugeridasDetalle values (@IdCedis, @IdRuta, @FechaCarga, @IdProducto, @Tipo, @Folio, 0, 0, @Cambios)
end

if @Opc = 4
begin
	declare @IdCarga as bigint, @IdSurtido as bigint, @IdCargaAnt as bigint
	
	select top 1 @IdSurtido = isnull(IdSurtido, 0)
	from Surtidos
	where IdCedis = @IdCedis and IdRuta = @IdRuta and Fecha = @FechaCarga
	order by IdSurtido desc
	
	if @IdSurtido <> 0 and @IdSurtido is not null
	begin
		select @IdCarga = isnull(max(IdCarga),0)
		from Cargas
		where IdCedis = @IdCedis and IdSurtido = @IdSurtido and Status = 'A'
--select 'Carga Actual = ' + cast(@IdCarga as varchar(10))

		if exists ( select IdProducto from SurtidosCargas where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdCarga = @IdCarga ) 
		begin
			set @IdCarga = isnull( (select max( IdCarga ) from Cargas where IdCedis = @IdCedis and Fecha = @FechaCarga and IdRuta = @IdRuta) + 1, 1)	
			if @IdCarga > 1 
			begin
				set @IdCargaAnt = isnull( (select max( IdCarga ) from Cargas where IdCedis = @IdCedis and Fecha = @FechaCarga and IdRuta = @IdRuta and IdCarga < @IdCarga), 0)	
				if @IdCarga - @IdCargaAnt > 1 
					set @IdCarga = isnull( (select max( IdCarga ) from Cargas where IdCedis = @IdCedis and Fecha = @FechaCarga and IdRuta = @IdRuta and IdCarga < @IdCarga) + 1, 1)	
			end

--select 'Nueva Carga = ' + cast(@IdCarga as varchar(10)) 		
			insert into Cargas values (@IdCedis, @IdSurtido, @IdCarga, @IdRuta, @FechaCarga, 'A')
		end 	

		insert into SurtidosCargas
		select IdCedis, @IdSurtido, @IdCarga, IdProducto, case Cambios 
			when 0 then Cantidad
			else Cambios end
		from CargasSugeridasDetalle
		where IdCedis = @IdCedis and IdRuta = @IdRuta and FechaCarga = @FechaCarga and Tipo = @Tipo and Folio = @Folio 
		
		update CargasSugeridas set IdSurtido = @IdSurtido, IdCarga = @IdCarga, Status = 'I'
		where IdCedis = @IdCedis and IdRuta = @IdRuta and FechaCarga = @FechaCarga and Tipo = @Tipo and Folio = @Folio 
	end
end

if @Opc = 5
begin
	set @IdProducto = cast(@Filtro as bigint)
	set @Calculo = @Semanas

	if exists (select IdProducto from CargasSugeridasDetalle where IdCedis = @IdCedis and IdRuta = @IdRuta and FechaCarga = @FechaCarga and IdProducto = @IdProducto and Tipo = @Tipo and Folio = @Folio)
		update CargasSugeridasDetalle set Cantidad = @Calculo where IdCedis = @IdCedis and IdRuta = @IdRuta and FechaCarga = @FechaCarga and IdProducto = @IdProducto and Tipo = @Tipo and Folio = @Folio 
	else
		insert into CargasSugeridasDetalle values (@IdCedis, @IdRuta, @FechaCarga, @IdProducto, @Tipo, @Folio, 0, @Calculo, 0)
end
GO

/****** Object:  StoredProcedure [dbo].[up_CargasSugeridasDetalle2]    Script Date: 08/18/2010 18:37:08 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[up_CargasSugeridasDetalle2]
@IdCedis as bigint,
@IdRuta as bigint,
@FechaCarga as datetime,
@FechaInicial as datetime,
@FechaFinal as datetime,
@Filtro as varchar(1000),
@Tipo as char(1),
@Opc as int
AS

if @Opc = 1
begin

set @FechaFinal = @FechaFinal + 1
exec ('
insert into CargasSugeridasDetalle
SELECT ' + @IdCedis + ', ' + @IdRuta + ', ''' + @FechaCarga + ''', ProductoClave, ' + @Tipo + ', SUM(Piezas), SUM(Piezas), 0
FROM (
	SELECT TD.ProductoClave, TD.SubTotal,TD.TipoUnidad,TD.Cantidad,
	(PRD.Factor * TD.Cantidad) as Piezas, 
	T.DescVendPor, TD.Impuesto,
	(select (case when sum(DesImporte) is null then 0 else sum(DesImporte) end) from Route.dbo.TpdDes as TDD where TDD.TransProdId=TD.TransProdId and TDD.TransProdDetalleId=TD.TransProdDetalleId) as DescuentoCliente, 
	(select (case when sum(DesImpuesto) is null then 0 else sum(DesImpuesto) end) from Route.dbo.TpdDes as TDD where TDD.TransProdId=TD.TransProdId and TDD.TransProdDetalleId=TD.TransProdDetalleId) as DescClienteImpuesto
	FROM Route.dbo.TransProd T
	INNER JOIN Route.dbo.Dia D ON D.DiaClave = T.DiaClave
	INNER JOIN Route.dbo.Visita V ON V.DiaClave = T.DiaClave AND V.VisitaClave = T.VisitaClave 
	INNER JOIN Route.dbo.TransProdDetalle TD ON T.TransProdId = TD.TransProdId
	inner join Route.dbo.Producto PRO on PRO.ProductoClave = TD.ProductoClave 
	inner join Route.dbo.ProductoDetalle PRD on TD.ProductoClave = PRD.ProductoClave and TD.TipoUnidad = PRD.PRUTipoUnidad and PRD.ProductoClave = PRD.ProductoDetClave 
	WHERE D.FechaCaptura BETWEEN ''' + @FechaInicial + ''' AND ''' + @FechaFinal + ''' 
	AND V.RUTClave in (' + @Filtro + ') AND T.Tipo = 1 AND T.TipoFase <> 0 AND T.TipoFase = 1
) AS Tabla
GROUP BY ProductoClave
ORDER BY ProductoClave')
end

if @Opc = 2
begin
	insert into CargasSugeridasDetalle 
	select IdCedis, IdRuta, @FechaCarga, IdProducto, Tipo, Venta, Cantidad, Cambios 
	from CargasSugeridasDetalle 
	where IdCedis = @IdCedis and IdRuta = @IdRuta and FechaCarga = @FechaInicial and Tipo = @Tipo 
end
GO

/****** Object:  StoredProcedure [dbo].[up_CargasSugeridasParametros]    Script Date: 08/18/2010 18:37:08 ******/
SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER OFF
GO

CREATE PROCEDURE [dbo].[up_CargasSugeridasParametros]
@IdCedis as bigint,
@IdRuta as bigint,
@FechaCarga as datetime,
@IdProducto as bigint,
@Semanas as bigint,
@Porcentaje as float,
@Folio as bigint,
@Opc as int
AS

if @Opc = 1
begin
	delete from CargasSugeridasProducto where IdCedis = @IdCedis and IdRuta = @IdRuta and FechaCarga = @FechaCarga and IdProducto = @IdProducto and Folio = @Folio 
	if @Semanas <> 0 insert into CargasSugeridasProducto values ( @IdCedis, @IdRuta, @FechaCarga, @Folio, @IdProducto, @Semanas, @Porcentaje )
end

if @Opc = 2
begin
	delete from CargasSugeridasFamilia where IdCedis = @IdCedis and IdRuta = @IdRuta and FechaCarga = @FechaCarga and IdFamilia = @IdProducto and Folio = @Folio 
	if @Semanas <> 0 insert into CargasSugeridasFamilia values ( @IdCedis, @IdRuta, @FechaCarga, @Folio, @IdProducto, @Semanas, @Porcentaje )
end

if @Opc = 3
begin
	delete from CargasSugeridas where IdCedis = @IdCedis and IdRuta = @IdRuta and FechaCarga = @FechaCarga and Folio = @Folio
end
GO

/****** Object:  StoredProcedure [dbo].[up_CargasSugeridasRutas]    Script Date: 08/18/2010 18:37:08 ******/
SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER OFF
GO

CREATE PROCEDURE [dbo].[up_CargasSugeridasRutas]
@IdCedis as bigint,
@IdRuta as bigint,
@FechaCarga as datetime,
@FechaInicial as datetime,
@FechaFinal as datetime,
@Folio as bigint,
@IdRutaPedido as bigint,
@Opc as int
AS

if @Opc = 1
begin
	delete from CargasSugeridasRuta where IdCedis = @IdCedis and IdRuta = @IdRuta and FechaCarga = @FechaCarga and IdRutaPedido = @IdRutaPedido and Folio = @Folio
	insert into CargasSugeridasRuta values ( @IdCedis, @IdRuta, @FechaCarga, @Folio, @IdRutaPedido, @FechaInicial, @FechaFinal)
end

if @Opc = 2
begin
	delete from CargasSugeridasRuta where IdCedis = @IdCedis and IdRuta = @IdRuta and FechaCarga = @FechaCarga and Folio = @Folio 
end


GO

