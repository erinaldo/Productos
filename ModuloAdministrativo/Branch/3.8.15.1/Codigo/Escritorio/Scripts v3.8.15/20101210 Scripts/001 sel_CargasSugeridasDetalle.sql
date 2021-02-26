USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[sel_CargasSugeridas]    Script Date: 12/10/2010 12:59:45 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sel_CargasSugeridas]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sel_CargasSugeridas]
GO

USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[sel_CargasSugeridas]    Script Date: 12/10/2010 12:59:45 ******/
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
	isnull(InventarioKardex.Teorico,0) as 'Disponible', isnull(InventarioKardex.Teorico,0) * Conversion as 'DisponibleK'
	, ISNULL(sum(SurDet.Surtido),0) as 'Total Cargas', ISNULL(sum(SurDet.Surtido * Conversion),0) as 'Total CargasK'
	, isnull(InventarioKardex.Teorico,0) - ISNULL(sum(SurDet.Surtido),0) as 'Inv. Final', (isnull(InventarioKardex.Teorico,0) - ISNULL(sum(SurDet.Surtido),0)) * Conversion as 'Inv. FinalK',

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
		when 'S' then (Cambios / isnull(Factor,1) - cast(Cambios / isnull(Factor,1) as bigint)) * isnull(Factor,1) else Cambios end as PiezasD
		
	, case Divide 
		when 'N' then cast(sum(SurDet.Surtido) * ISNULL(Factor,0) as bigint) 
		when 'S' then cast(sum(SurDet.Surtido) / isnull(Factor,1) as bigint) else 0 end as 'Total CargasU'
		
	, case Divide 
		when 'N' then (sum(SurDet.Surtido) * ISNULL(Factor,0)) - cast(sum(SurDet.Surtido) * ISNULL(Factor,0) as bigint) 
		when 'S' then (sum(SurDet.Surtido) / isnull(Factor,1) - cast(sum(SurDet.Surtido) / isnull(Factor,1) as bigint)) * isnull(Factor,1) else SUM(SurDet.Surtido) end as 'Total CargasC'
	
	from CargasSugeridasDetalle
	inner join Productos on CargasSugeridasDetalle.IdProducto = Productos.IdProducto and Productos.Status = 'A'
	left outer join ProductosUnidad PU on PU.IdProducto = Productos.IdProducto and IdUnidad = 'CAJA'
	left outer join InventarioKardex on InventarioKardex.IdCedis = CargasSugeridasDetalle.IdCedis and InventarioKardex.IdProducto = CargasSugeridasDetalle.IdProducto
		and InventarioKardex.Fecha in (select top 1 Fecha from InventarioKardex where Fecha < @FechaCarga order by Fecha desc)
	left outer join SurtidosDetalle SurDet on SurDet.IdCedis = CargasSugeridasDetalle.IdCedis and SurDet.IdProducto = CargasSugeridasDetalle.IdProducto and SurDet.Fecha = @FechaCarga 
	where CargasSugeridasDetalle.IdCedis = @IdCedis and CargasSugeridasDetalle.IdRuta = @IdRuta and FechaCarga = @FechaCarga and Tipo = (@Opc - 3) and Folio = @Folio 
	group by CargasSugeridasDetalle.IdCedis, CargasSugeridasDetalle.IdRuta, CargasSugeridasDetalle.IdProducto, Producto, Productos.IdProducto, 
	CargasSugeridasDetalle.Venta, CargasSugeridasDetalle.Cantidad, CargasSugeridasDetalle.Cambios, Productos.Conversion, InventarioKardex.Teorico,
	PU.Factor, PU.Divide 
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


