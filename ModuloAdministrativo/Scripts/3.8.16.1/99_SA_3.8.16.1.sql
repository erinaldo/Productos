USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[sel_ComisionesCalculo]    Script Date: 09/04/2011 11:54:59 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sel_ComisionesCalculo]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sel_ComisionesCalculo]
GO

USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[sel_ComisionesCalculo]    Script Date: 09/04/2011 11:54:59 ******/
SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER OFF
GO







CREATE PROCEDURE [dbo].[sel_ComisionesCalculo]
@IdCedis as bigint,
@FechaInicial as datetime,
@FechaFinal as datetime,
@DiasTrabajados as smallint
AS
	
--set @IdCedis = 1
--set @FechaInicial ='2011-08-15T00:00:00'
--set @FechaFinal ='2011-08-20T00:00:00'
SET DATEFIRST 1

DECLARE @Comisiones as Table(IdComEsquema bigint, Esquema varchar(50), IdProducto bigint, IdMarca bigint, IdConceptoPago bigint,
ConceptoPago varchar(30), Inicial float, Final float, IdTipoVendedor bigint, TipoVendedor varchar(20), Pago money,  Acumulado bit)

if @DiasTrabajados <= 0 
	set @DiasTrabajados = 1
	
if @DiasTrabajados > 6 
	set @DiasTrabajados = 6
--Obtener las comisiones y su configuracion
insert  into @Comisiones 	
select ComEsquema.IdComEsquema, Nombre as 'Esquema',  
ComEsquemaProducto.IdProducto,null, ComEsquemaRangos.IdConceptoPago, case ComEsquemaRangos.IdConceptoPago
			when '1' then ( select Etiqueta01 from Configuracion where IdCedis = @IdCedis)
			when '2' then ( select Etiqueta02 from Configuracion where IdCedis = @IdCedis)
			when '3' then 'Importe de Venta'
		end as 'ConceptoPago', ComEsquemaRangos.Inicial, ComEsquemaRangos.Final,
ComEsquemaPagos.IdTipoVendedor, TipoVendedor, Pago, Acumulado
from ComEsquema 
inner join ComEsquemaCedis on ComEsquemaCedis.IdComEsquema = ComEsquema.IdComEsquema and ComEsquemaCedis.IdCedis = @IdCedis
inner join ComEsquemaProducto on ComEsquemaProducto.IdComEsquema = ComEsquema.IdComEsquema and ComEsquemaProducto.Status = 'A'
inner join ComEsquemaRangos on ComEsquemaRangos.IdComEsquema = ComEsquema.IdComEsquema and ComEsquemaRangos.IdProducto  = ComEsquemaProducto.IdProducto and ComEsquemaRangos.Status = 'A'
inner join ComEsquemaPagos on ComEsquemaRangos.IdComEsquema = ComEsquemaPagos.IdComEsquema and ComEsquemaRangos.IdProducto  = ComEsquemaPagos.IdProducto 
	and ComEsquemaRangos.Inicial  = ComEsquemaPagos.Inicial and ComEsquemaRangos.Final  = ComEsquemaPagos.Final and ComEsquemaPagos.Status = 'A'
inner join TipoVendedor on TipoVendedor.IdTipoVendedor = ComEsquemaPagos.IdTipoVendedor 
union
select ComEsquema.IdComEsquema, Nombre as 'Esquema',
null, ComEsquemaMarca.IdMarca,  ComEsquemaRangos.IdConceptoPago, case ComEsquemaRangos.IdConceptoPago
			when '1' then ( select Etiqueta01 from Configuracion where IdCedis = @IdCedis)
			when '2' then ( select Etiqueta02 from Configuracion where IdCedis = @IdCedis)
			when '3' then 'Importe de Venta'
		end as 'ConceptoPago', ComEsquemaRangos.Inicial, ComEsquemaRangos.Final,
ComEsquemaPagos.IdTipoVendedor, TipoVendedor, Pago, Acumulado
from ComEsquema 
inner join ComEsquemaCedis on ComEsquemaCedis.IdComEsquema = ComEsquema.IdComEsquema and ComEsquemaCedis.IdCedis = @IdCedis
inner join ComEsquemaMarca on ComEsquemaMarca.IdComEsquema = ComEsquema.IdComEsquema and ComEsquemaMarca.Status = 'A'
inner join ComEsquemaRangos on ComEsquemaRangos.IdComEsquema = ComEsquema.IdComEsquema and ComEsquemaMarca.IdMarca  = ComEsquemaRangos.IdMarca and ComEsquemaRangos.Status = 'A'
inner join ComEsquemaPagos on ComEsquemaRangos.IdComEsquema = ComEsquemaPagos.IdComEsquema and ComEsquemaRangos.IdProducto  = ComEsquemaPagos.IdProducto 
and ComEsquemaRangos.Inicial  = ComEsquemaPagos.Inicial and ComEsquemaRangos.Final  = ComEsquemaPagos.Final and ComEsquemaPagos.Status = 'A'
inner join TipoVendedor on TipoVendedor.IdTipoVendedor = ComEsquemaPagos.IdTipoVendedor 

Select IdCedis, IdVendedor , Vendedor, @FechaInicial as FechaIni, @FechaFinal as FechaFin, 
IdComEsquema, Esquema, IdConceptoPago, ConceptoPago,
IdTipoVendedor, TipoVendedor, null as IdMarca, null as Marca, 
IdProducto, Producto, VentaLunes, VentaMartes, VentaMiercoles, VentaJueves, VentaViernes, VentaSabado,
@DiasTrabajados  as DiasTrabajados, 
CASE WHEN Acumulado = 1 THEN Round(((VentaLunes+VentaMartes+VentaMiercoles+VentaJueves+VentaViernes+VentaSabado)/@DiasTrabajados),0) END as PromSemanal,
Inicial, Final, Factor, (VentaLunes+VentaMartes+VentaMiercoles+VentaJueves+VentaViernes+VentaSabado)  * Factor  as Pago
 from (
--Comisiones x Producto
select Surtidos.IdCedis, Vendedores.IdVendedor , Vendedores.Nombre + ' ' + Vendedores.ApPaterno + ' ' + Vendedores.ApMaterno  as Vendedor, @FechaInicial as FechaIni, @FechaFinal as FechaFin, 
COM.IdComEsquema, COM.Esquema, COM.IdConceptoPago, ConceptoPago,
SurtidosVendedor.IdTipoVendedor, COM.TipoVendedor, null as IdMarca, null as Marca, 
VentasDetalle.IdProducto, Producto, 
VentaLunes = CASE WHEN COM.IdConceptoPago = 1 THEN sum(CASE WHEN Surtidos.Fecha =DATEADD(d,-DATEPART(weekday,@FechaInicial)+1,@FechaInicial) THEN Cantidad ELSE 0 END) WHEN COM.IdConceptoPago = 2 THEN FLOOR(SUM(CASE WHEN Surtidos.Fecha =DATEADD(d,-DATEPART(weekday,@FechaInicial)+1,@FechaInicial) THEN Cantidad/ isnull(ProductosUnidad.Factor,1 ) ELSE 0 END)) WHEN COM.IdConceptoPago = 3 THEN sum(CASE WHEN Surtidos.Fecha =DATEADD(d,-DATEPART(weekday,@FechaInicial)+1,@FechaInicial) THEN Total ELSE 0 END) ELSE 0 END , 
VentaMartes = CASE WHEN COM.IdConceptoPago = 1 THEN sum(CASE WHEN Surtidos.Fecha =DATEADD(d,-DATEPART(weekday,@FechaInicial)+2,@FechaInicial) THEN Cantidad ELSE 0 END) WHEN COM.IdConceptoPago = 2 THEN FLOOR(SUM(CASE WHEN Surtidos.Fecha =DATEADD(d,-DATEPART(weekday,@FechaInicial)+2,@FechaInicial) THEN Cantidad/ isnull(ProductosUnidad.Factor,1 ) ELSE 0 END)) WHEN COM.IdConceptoPago = 3 THEN sum(CASE WHEN Surtidos.Fecha =DATEADD(d,-DATEPART(weekday,@FechaInicial)+2,@FechaInicial) THEN Total ELSE 0 END) ELSE 0 END , 
VentaMiercoles = CASE WHEN COM.IdConceptoPago = 1 THEN sum(CASE WHEN Surtidos.Fecha =DATEADD(d,-DATEPART(weekday,@FechaInicial)+3,@FechaInicial) THEN Cantidad ELSE 0 END) WHEN COM.IdConceptoPago = 2 THEN FLOOR(SUM(CASE WHEN Surtidos.Fecha =DATEADD(d,-DATEPART(weekday,@FechaInicial)+3,@FechaInicial) THEN Cantidad/ isnull(ProductosUnidad.Factor,1 ) ELSE 0 END)) WHEN COM.IdConceptoPago = 3 THEN sum(CASE WHEN Surtidos.Fecha =DATEADD(d,-DATEPART(weekday,@FechaInicial)+3,@FechaInicial) THEN Total ELSE 0 END) ELSE 0 END , 
VentaJueves = CASE WHEN COM.IdConceptoPago = 1 THEN sum(CASE WHEN Surtidos.Fecha =DATEADD(d,-DATEPART(weekday,@FechaInicial)+4,@FechaInicial) THEN Cantidad ELSE 0 END) WHEN COM.IdConceptoPago = 2 THEN FLOOR(SUM(CASE WHEN Surtidos.Fecha =DATEADD(d,-DATEPART(weekday,@FechaInicial)+4,@FechaInicial) THEN Cantidad/ isnull(ProductosUnidad.Factor,1 ) ELSE 0 END)) WHEN COM.IdConceptoPago = 3 THEN sum(CASE WHEN Surtidos.Fecha =DATEADD(d,-DATEPART(weekday,@FechaInicial)+4,@FechaInicial) THEN Total ELSE 0 END) ELSE 0 END , 
VentaViernes = CASE WHEN COM.IdConceptoPago = 1 THEN sum(CASE WHEN Surtidos.Fecha =DATEADD(d,-DATEPART(weekday,@FechaInicial)+5,@FechaInicial) THEN Cantidad ELSE 0 END) WHEN COM.IdConceptoPago = 2 THEN FLOOR(SUM(CASE WHEN Surtidos.Fecha =DATEADD(d,-DATEPART(weekday,@FechaInicial)+5,@FechaInicial) THEN Cantidad/ isnull(ProductosUnidad.Factor,1 ) ELSE 0 END)) WHEN COM.IdConceptoPago = 3 THEN sum(CASE WHEN Surtidos.Fecha =DATEADD(d,-DATEPART(weekday,@FechaInicial)+5,@FechaInicial) THEN Total ELSE 0 END) ELSE 0 END , 
VentaSabado = CASE WHEN COM.IdConceptoPago = 1 THEN sum(CASE WHEN Surtidos.Fecha =DATEADD(d,-DATEPART(weekday,@FechaInicial)+6,@FechaInicial) THEN Cantidad ELSE 0 END) WHEN COM.IdConceptoPago = 2 THEN FLOOR(SUM(CASE WHEN Surtidos.Fecha =DATEADD(d,-DATEPART(weekday,@FechaInicial)+6,@FechaInicial) THEN Cantidad/ isnull(ProductosUnidad.Factor,1 ) ELSE 0 END)) WHEN COM.IdConceptoPago = 3 THEN sum(CASE WHEN Surtidos.Fecha =DATEADD(d,-DATEPART(weekday,@FechaInicial)+6,@FechaInicial) THEN Total ELSE 0 END) ELSE 0 END , 
Inicial, Final, Pago as Factor, Acumulado 
from Surtidos
inner join SurtidosVendedor on Surtidos.IdCedis = SurtidosVendedor.IdCedis and Surtidos.IdSurtido = SurtidosVendedor.IdSurtido 
inner join Vendedores on Vendedores.IdCedis = SurtidosVendedor.IdCedis and Vendedores.IdVendedor = SurtidosVendedor.IdVendedor 
inner join VentasDetalle on Surtidos.IdCedis = VentasDetalle.IdCedis and Surtidos.IdSurtido = VentasDetalle.IdSurtido
inner join Productos on Productos.IdProducto = VentasDetalle.IdProducto
inner join @Comisiones COM on COM.IdTipoVendedor = SurtidosVendedor.IdTipoVendedor and COM.IdProducto = VentasDetalle.IdProducto
--inner join @DiasTrabajados DTR on DTR.IdVendedor = SurtidosVendedor.IdVendedor and COM.TipoVendedor = DTR.TipoVendedor
left join ProductosUnidad on ProductosUnidad.IdProducto = Productos.IdProducto and UPPER(ProductosUnidad.IdUnidad) = 'CAJA'
where Surtidos.IdCedis = @IdCedis and Surtidos.[Status]='C' and Surtidos.Fecha between @FechaInicial and @FechaFinal 
and upper(COM.TipoVendedor) <> 'PREVENTA'  
group by COM.IdComEsquema, COM.IdConceptoPago, COM.Esquema, Inicial, Final, Pago, ConceptoPago, 
Surtidos.IdCedis, SurtidosVendedor.IdTipoVendedor, COM.TipoVendedor, 
VentasDetalle.IdProducto, Producto, COM.Acumulado, Vendedores.IdVendedor , Vendedores.Nombre, Vendedores.ApPaterno, Vendedores.ApMaterno 
UNION
--Comisiones x Marca
select Surtidos.IdCedis, Vendedores.IdVendedor , Vendedores.Nombre + ' ' + Vendedores.ApPaterno + ' ' + Vendedores.ApMaterno  as Vendedor, @FechaInicial as FechaIni, @FechaFinal as FechaFin, 
COM.IdComEsquema, COM.Esquema, COM.IdConceptoPago,ConceptoPago, 
SurtidosVendedor.IdTipoVendedor, COM.TipoVendedor, Marcas.IdMarca, Marca, 
null as IdProducto, null as Producto, 
VentaLunes = CASE WHEN COM.IdConceptoPago = 1 THEN sum(CASE WHEN Surtidos.Fecha =DATEADD(d,-DATEPART(weekday,@FechaInicial)+1,@FechaInicial) THEN Cantidad ELSE 0 END) WHEN COM.IdConceptoPago = 2 THEN FLOOR(SUM(CASE WHEN Surtidos.Fecha =DATEADD(d,-DATEPART(weekday,@FechaInicial)+1,@FechaInicial) THEN Cantidad/ isnull(ProductosUnidad.Factor,1 ) ELSE 0 END)) WHEN COM.IdConceptoPago = 3 THEN sum(CASE WHEN Surtidos.Fecha =DATEADD(d,-DATEPART(weekday,@FechaInicial)+1,@FechaInicial) THEN Total ELSE 0 END) ELSE 0 END , 
VentaMartes = CASE WHEN COM.IdConceptoPago = 1 THEN sum(CASE WHEN Surtidos.Fecha =DATEADD(d,-DATEPART(weekday,@FechaInicial)+2,@FechaInicial) THEN Cantidad ELSE 0 END) WHEN COM.IdConceptoPago = 2 THEN FLOOR(SUM(CASE WHEN Surtidos.Fecha =DATEADD(d,-DATEPART(weekday,@FechaInicial)+2,@FechaInicial) THEN Cantidad/ isnull(ProductosUnidad.Factor,1 ) ELSE 0 END)) WHEN COM.IdConceptoPago = 3 THEN sum(CASE WHEN Surtidos.Fecha =DATEADD(d,-DATEPART(weekday,@FechaInicial)+2,@FechaInicial) THEN Total ELSE 0 END) ELSE 0 END , 
VentaMiercoles = CASE WHEN COM.IdConceptoPago = 1 THEN sum(CASE WHEN Surtidos.Fecha =DATEADD(d,-DATEPART(weekday,@FechaInicial)+3,@FechaInicial) THEN Cantidad ELSE 0 END) WHEN COM.IdConceptoPago = 2 THEN FLOOR(SUM(CASE WHEN Surtidos.Fecha =DATEADD(d,-DATEPART(weekday,@FechaInicial)+3,@FechaInicial) THEN Cantidad/ isnull(ProductosUnidad.Factor,1 ) ELSE 0 END)) WHEN COM.IdConceptoPago = 3 THEN sum(CASE WHEN Surtidos.Fecha =DATEADD(d,-DATEPART(weekday,@FechaInicial)+3,@FechaInicial) THEN Total ELSE 0 END) ELSE 0 END , 
VentaJueves = CASE WHEN COM.IdConceptoPago = 1 THEN sum(CASE WHEN Surtidos.Fecha =DATEADD(d,-DATEPART(weekday,@FechaInicial)+4,@FechaInicial) THEN Cantidad ELSE 0 END) WHEN COM.IdConceptoPago = 2 THEN FLOOR(SUM(CASE WHEN Surtidos.Fecha =DATEADD(d,-DATEPART(weekday,@FechaInicial)+4,@FechaInicial) THEN Cantidad/ isnull(ProductosUnidad.Factor,1 ) ELSE 0 END)) WHEN COM.IdConceptoPago = 3 THEN sum(CASE WHEN Surtidos.Fecha =DATEADD(d,-DATEPART(weekday,@FechaInicial)+4,@FechaInicial) THEN Total ELSE 0 END) ELSE 0 END , 
VentaViernes = CASE WHEN COM.IdConceptoPago = 1 THEN sum(CASE WHEN Surtidos.Fecha =DATEADD(d,-DATEPART(weekday,@FechaInicial)+5,@FechaInicial) THEN Cantidad ELSE 0 END) WHEN COM.IdConceptoPago = 2 THEN FLOOR(SUM(CASE WHEN Surtidos.Fecha =DATEADD(d,-DATEPART(weekday,@FechaInicial)+5,@FechaInicial) THEN Cantidad/ isnull(ProductosUnidad.Factor,1 ) ELSE 0 END)) WHEN COM.IdConceptoPago = 3 THEN sum(CASE WHEN Surtidos.Fecha =DATEADD(d,-DATEPART(weekday,@FechaInicial)+5,@FechaInicial) THEN Total ELSE 0 END) ELSE 0 END , 
VentaSabado = CASE WHEN COM.IdConceptoPago = 1 THEN sum(CASE WHEN Surtidos.Fecha =DATEADD(d,-DATEPART(weekday,@FechaInicial)+6,@FechaInicial) THEN Cantidad ELSE 0 END) WHEN COM.IdConceptoPago = 2 THEN FLOOR(SUM(CASE WHEN Surtidos.Fecha =DATEADD(d,-DATEPART(weekday,@FechaInicial)+6,@FechaInicial) THEN Cantidad/ isnull(ProductosUnidad.Factor,1 ) ELSE 0 END)) WHEN COM.IdConceptoPago = 3 THEN sum(CASE WHEN Surtidos.Fecha =DATEADD(d,-DATEPART(weekday,@FechaInicial)+6,@FechaInicial) THEN Total ELSE 0 END) ELSE 0 END , 
Inicial, Final, Pago as Factor, Acumulado 
from Surtidos
inner join SurtidosVendedor on Surtidos.IdCedis = SurtidosVendedor.IdCedis and Surtidos.IdSurtido = SurtidosVendedor.IdSurtido 
inner join Vendedores on Vendedores.IdCedis = SurtidosVendedor.IdCedis and Vendedores.IdVendedor = SurtidosVendedor.IdVendedor 
inner join VentasDetalle on Surtidos.IdCedis = VentasDetalle.IdCedis and Surtidos.IdSurtido = VentasDetalle.IdSurtido
inner join Productos on Productos.IdProducto = VentasDetalle.IdProducto
inner join Marcas on Marcas.IdMarca = Productos.IdMarca
inner join @Comisiones COM on COM.IdTipoVendedor = SurtidosVendedor.IdTipoVendedor and COM.IdMarca = Marcas.IdMarca
--inner join @DiasTrabajados DTR on DTR.IdVendedor = SurtidosVendedor.IdVendedor and COM.TipoVendedor = DTR.TipoVendedor 
left join ProductosUnidad on ProductosUnidad.IdProducto = Productos.IdProducto and UPPER(ProductosUnidad.IdUnidad) = 'CAJA'
where Surtidos.IdCedis = @IdCedis and Surtidos.[Status]='C' and Surtidos.Fecha between @FechaInicial and @FechaFinal 
and  upper(COM.TipoVendedor) <>'PREVENTA' 
group by COM.IdComEsquema, COM.IdConceptoPago, COM.Esquema, Inicial, Final, Pago, ConceptoPago, 
Surtidos.IdCedis,  SurtidosVendedor.IdTipoVendedor, COM.TipoVendedor, 
Marcas.IdMarca, Marcas.Marca , COM.Acumulado, Vendedores.IdVendedor , Vendedores.Nombre, Vendedores.ApPaterno, Vendedores.ApMaterno 
UNION
--Comision x Producto PREVENTA
select Surtidos.IdCedis, Vendedores.IdVendedor , Vendedores.Nombre + ' ' + Vendedores.ApPaterno + ' ' + Vendedores.ApMaterno  as Vendedor, @FechaInicial as FechaIni, @FechaFinal as FechaFin, 
COM.IdComEsquema, COM.Esquema, COM.IdConceptoPago, ConceptoPago,
SurtidosVendedor.IdTipoVendedor, COM.TipoVendedor, null as IdMarca, null as Marca, 
VentasDetalle.IdProducto, Producto, 
VentaLunes = CASE WHEN COM.IdConceptoPago = 1 THEN sum(CASE WHEN SURREP.Fecha =DATEADD(d,-DATEPART(weekday,@FechaInicial)+1,@FechaInicial) THEN Cantidad ELSE 0 END) WHEN COM.IdConceptoPago = 2 THEN FLOOR(SUM(CASE WHEN SURREP.Fecha =DATEADD(d,-DATEPART(weekday,@FechaInicial)+1,@FechaInicial) THEN Cantidad/ isnull(ProductosUnidad.Factor,1 ) ELSE 0 END)) WHEN COM.IdConceptoPago = 3 THEN sum(CASE WHEN SURREP.Fecha =DATEADD(d,-DATEPART(weekday,@FechaInicial)+1,@FechaInicial) THEN VentasDetalle.Total ELSE 0 END) ELSE 0 END , 
VentaMartes = CASE WHEN COM.IdConceptoPago = 1 THEN sum(CASE WHEN SURREP.Fecha =DATEADD(d,-DATEPART(weekday,@FechaInicial)+2,@FechaInicial) THEN Cantidad ELSE 0 END) WHEN COM.IdConceptoPago = 2 THEN FLOOR(SUM(CASE WHEN SURREP.Fecha =DATEADD(d,-DATEPART(weekday,@FechaInicial)+2,@FechaInicial) THEN Cantidad/ isnull(ProductosUnidad.Factor,1 ) ELSE 0 END)) WHEN COM.IdConceptoPago = 3 THEN sum(CASE WHEN SURREP.Fecha =DATEADD(d,-DATEPART(weekday,@FechaInicial)+2,@FechaInicial) THEN VentasDetalle.Total ELSE 0 END) ELSE 0 END , 
VentaMiercoles = CASE WHEN COM.IdConceptoPago = 1 THEN sum(CASE WHEN SURREP.Fecha =DATEADD(d,-DATEPART(weekday,@FechaInicial)+3,@FechaInicial) THEN Cantidad ELSE 0 END) WHEN COM.IdConceptoPago = 2 THEN FLOOR(SUM(CASE WHEN SURREP.Fecha =DATEADD(d,-DATEPART(weekday,@FechaInicial)+3,@FechaInicial) THEN Cantidad/ isnull(ProductosUnidad.Factor,1 ) ELSE 0 END)) WHEN COM.IdConceptoPago = 3 THEN sum(CASE WHEN SURREP.Fecha =DATEADD(d,-DATEPART(weekday,@FechaInicial)+3,@FechaInicial) THEN VentasDetalle.Total ELSE 0 END) ELSE 0 END , 
VentaJueves = CASE WHEN COM.IdConceptoPago = 1 THEN sum(CASE WHEN SURREP.Fecha =DATEADD(d,-DATEPART(weekday,@FechaInicial)+4,@FechaInicial) THEN Cantidad ELSE 0 END) WHEN COM.IdConceptoPago = 2 THEN FLOOR(SUM(CASE WHEN SURREP.Fecha =DATEADD(d,-DATEPART(weekday,@FechaInicial)+4,@FechaInicial) THEN Cantidad/ isnull(ProductosUnidad.Factor,1 ) ELSE 0 END)) WHEN COM.IdConceptoPago = 3 THEN sum(CASE WHEN SURREP.Fecha =DATEADD(d,-DATEPART(weekday,@FechaInicial)+4,@FechaInicial) THEN VentasDetalle.Total ELSE 0 END) ELSE 0 END , 
VentaViernes = CASE WHEN COM.IdConceptoPago = 1 THEN sum(CASE WHEN SURREP.Fecha =DATEADD(d,-DATEPART(weekday,@FechaInicial)+5,@FechaInicial) THEN Cantidad ELSE 0 END) WHEN COM.IdConceptoPago = 2 THEN FLOOR(SUM(CASE WHEN SURREP.Fecha =DATEADD(d,-DATEPART(weekday,@FechaInicial)+5,@FechaInicial) THEN Cantidad/ isnull(ProductosUnidad.Factor,1 ) ELSE 0 END)) WHEN COM.IdConceptoPago = 3 THEN sum(CASE WHEN SURREP.Fecha =DATEADD(d,-DATEPART(weekday,@FechaInicial)+5,@FechaInicial) THEN VentasDetalle.Total ELSE 0 END) ELSE 0 END , 
VentaSabado = CASE WHEN COM.IdConceptoPago = 1 THEN sum(CASE WHEN SURREP.Fecha =DATEADD(d,-DATEPART(weekday,@FechaInicial)+6,@FechaInicial) THEN Cantidad ELSE 0 END) WHEN COM.IdConceptoPago = 2 THEN FLOOR(SUM(CASE WHEN SURREP.Fecha =DATEADD(d,-DATEPART(weekday,@FechaInicial)+6,@FechaInicial) THEN Cantidad/ isnull(ProductosUnidad.Factor,1 ) ELSE 0 END)) WHEN COM.IdConceptoPago = 3 THEN sum(CASE WHEN SURREP.Fecha =DATEADD(d,-DATEPART(weekday,@FechaInicial)+6,@FechaInicial) THEN VentasDetalle.Total ELSE 0 END) ELSE 0 END , 
Inicial, Final, Pago as Factor, Acumulado 
from Ventas  
inner join Surtidos ON Surtidos.IdRuta  = Ventas.RutaPrev and (Surtidos.Fecha = Ventas.FechaPrev)
inner join SurtidosVendedor on Surtidos.IdCedis = SurtidosVendedor.IdCedis and Surtidos.IdSurtido = SurtidosVendedor.IdSurtido 
inner join Surtidos SURREP on SURREP.IdSurtido = Ventas.IdSurtido 
inner join Vendedores on Vendedores.IdCedis = SurtidosVendedor.IdCedis and Vendedores.IdVendedor = SurtidosVendedor.IdVendedor 
inner join VentasDetalle on Ventas.IdCedis = VentasDetalle.IdCedis and Ventas.IdSurtido = VentasDetalle.IdSurtido  and Ventas.IdTipoVenta  = VentasDetalle.IdTipoVenta and Ventas.Folio = VentasDetalle.Folio
inner join Productos on Productos.IdProducto = VentasDetalle.IdProducto
inner join @Comisiones COM on COM.IdTipoVendedor = SurtidosVendedor.IdTipoVendedor and COM.IdProducto = VentasDetalle.IdProducto
left join ProductosUnidad on ProductosUnidad.IdProducto = Productos.IdProducto and UPPER(ProductosUnidad.IdUnidad) = 'CAJA'
where Surtidos.IdCedis = @IdCedis  and SURREP.Fecha  between @FechaInicial and @FechaFinal --and Surtidos.[Status]='C'
and upper(COM.TipoVendedor) = 'PREVENTA'  
group by COM.IdComEsquema, COM.IdConceptoPago, COM.Esquema, Inicial, Final, Pago, ConceptoPago, 
Surtidos.IdCedis, SurtidosVendedor.IdTipoVendedor, COM.TipoVendedor, 
VentasDetalle.IdProducto, Producto, COM.Acumulado, Vendedores.IdVendedor , Vendedores.Nombre, Vendedores.ApPaterno, Vendedores.ApMaterno 
UNION
--Comisiones x Marca
select Surtidos.IdCedis, Vendedores.IdVendedor , Vendedores.Nombre + ' ' + Vendedores.ApPaterno + ' ' + Vendedores.ApMaterno  as Vendedor, @FechaInicial as FechaIni, @FechaFinal as FechaFin, 
COM.IdComEsquema, COM.Esquema, COM.IdConceptoPago,ConceptoPago, 
SurtidosVendedor.IdTipoVendedor, COM.TipoVendedor, Marcas.IdMarca, Marca, 
null as IdProducto, null as Producto, 
VentaLunes = CASE WHEN COM.IdConceptoPago = 1 THEN sum(CASE WHEN SURREP.Fecha =DATEADD(d,-DATEPART(weekday,@FechaInicial)+1,@FechaInicial) THEN Cantidad ELSE 0 END) WHEN COM.IdConceptoPago = 2 THEN FLOOR(SUM(CASE WHEN SURREP.Fecha =DATEADD(d,-DATEPART(weekday,@FechaInicial)+1,@FechaInicial) THEN Cantidad/ isnull(ProductosUnidad.Factor,1 ) ELSE 0 END)) WHEN COM.IdConceptoPago = 3 THEN sum(CASE WHEN SURREP.Fecha =DATEADD(d,-DATEPART(weekday,@FechaInicial)+1,@FechaInicial) THEN VentasDetalle.Total ELSE 0 END) ELSE 0 END , 
VentaMartes = CASE WHEN COM.IdConceptoPago = 1 THEN sum(CASE WHEN SURREP.Fecha =DATEADD(d,-DATEPART(weekday,@FechaInicial)+2,@FechaInicial) THEN Cantidad ELSE 0 END) WHEN COM.IdConceptoPago = 2 THEN FLOOR(SUM(CASE WHEN SURREP.Fecha =DATEADD(d,-DATEPART(weekday,@FechaInicial)+2,@FechaInicial) THEN Cantidad/ isnull(ProductosUnidad.Factor,1 ) ELSE 0 END)) WHEN COM.IdConceptoPago = 3 THEN sum(CASE WHEN SURREP.Fecha =DATEADD(d,-DATEPART(weekday,@FechaInicial)+2,@FechaInicial) THEN VentasDetalle.Total ELSE 0 END) ELSE 0 END , 
VentaMiercoles = CASE WHEN COM.IdConceptoPago = 1 THEN sum(CASE WHEN SURREP.Fecha =DATEADD(d,-DATEPART(weekday,@FechaInicial)+3,@FechaInicial) THEN Cantidad ELSE 0 END) WHEN COM.IdConceptoPago = 2 THEN FLOOR(SUM(CASE WHEN SURREP.Fecha =DATEADD(d,-DATEPART(weekday,@FechaInicial)+3,@FechaInicial) THEN Cantidad/ isnull(ProductosUnidad.Factor,1 ) ELSE 0 END)) WHEN COM.IdConceptoPago = 3 THEN sum(CASE WHEN SURREP.Fecha =DATEADD(d,-DATEPART(weekday,@FechaInicial)+3,@FechaInicial) THEN VentasDetalle.Total ELSE 0 END) ELSE 0 END , 
VentaJueves = CASE WHEN COM.IdConceptoPago = 1 THEN sum(CASE WHEN SURREP.Fecha =DATEADD(d,-DATEPART(weekday,@FechaInicial)+4,@FechaInicial) THEN Cantidad ELSE 0 END) WHEN COM.IdConceptoPago = 2 THEN FLOOR(SUM(CASE WHEN SURREP.Fecha =DATEADD(d,-DATEPART(weekday,@FechaInicial)+4,@FechaInicial) THEN Cantidad/ isnull(ProductosUnidad.Factor,1 ) ELSE 0 END)) WHEN COM.IdConceptoPago = 3 THEN sum(CASE WHEN SURREP.Fecha =DATEADD(d,-DATEPART(weekday,@FechaInicial)+4,@FechaInicial) THEN VentasDetalle.Total ELSE 0 END) ELSE 0 END , 
VentaViernes = CASE WHEN COM.IdConceptoPago = 1 THEN sum(CASE WHEN SURREP.Fecha =DATEADD(d,-DATEPART(weekday,@FechaInicial)+5,@FechaInicial) THEN Cantidad ELSE 0 END) WHEN COM.IdConceptoPago = 2 THEN FLOOR(SUM(CASE WHEN SURREP.Fecha =DATEADD(d,-DATEPART(weekday,@FechaInicial)+5,@FechaInicial) THEN Cantidad/ isnull(ProductosUnidad.Factor,1 ) ELSE 0 END)) WHEN COM.IdConceptoPago = 3 THEN sum(CASE WHEN SURREP.Fecha =DATEADD(d,-DATEPART(weekday,@FechaInicial)+5,@FechaInicial) THEN VentasDetalle.Total ELSE 0 END) ELSE 0 END , 
VentaSabado = CASE WHEN COM.IdConceptoPago = 1 THEN sum(CASE WHEN SURREP.Fecha =DATEADD(d,-DATEPART(weekday,@FechaInicial)+6,@FechaInicial) THEN Cantidad ELSE 0 END) WHEN COM.IdConceptoPago = 2 THEN FLOOR(SUM(CASE WHEN SURREP.Fecha =DATEADD(d,-DATEPART(weekday,@FechaInicial)+6,@FechaInicial) THEN Cantidad/ isnull(ProductosUnidad.Factor,1 ) ELSE 0 END)) WHEN COM.IdConceptoPago = 3 THEN sum(CASE WHEN SURREP.Fecha =DATEADD(d,-DATEPART(weekday,@FechaInicial)+6,@FechaInicial) THEN VentasDetalle.Total ELSE 0 END) ELSE 0 END , 
Inicial, Final, Pago as Factor, Acumulado 
from Ventas  
inner join Surtidos ON Surtidos.IdRuta  = Ventas.RutaPrev and (Surtidos.Fecha = Ventas.FechaPrev)
inner join SurtidosVendedor on Surtidos.IdCedis = SurtidosVendedor.IdCedis and Surtidos.IdSurtido = SurtidosVendedor.IdSurtido 
inner join Surtidos SURREP on SURREP.IdSurtido = Ventas.IdSurtido 
inner join Vendedores on Vendedores.IdCedis = SurtidosVendedor.IdCedis and Vendedores.IdVendedor = SurtidosVendedor.IdVendedor 
inner join VentasDetalle on Ventas.IdCedis = VentasDetalle.IdCedis and Ventas.IdSurtido = VentasDetalle.IdSurtido  and Ventas.IdTipoVenta  = VentasDetalle.IdTipoVenta and Ventas.Folio = VentasDetalle.Folio
inner join Productos on Productos.IdProducto = VentasDetalle.IdProducto
inner join Marcas on Marcas.IdMarca = Productos.IdMarca
inner join @Comisiones COM on COM.IdTipoVendedor = SurtidosVendedor.IdTipoVendedor and COM.IdMarca = Marcas.IdMarca
--inner join @DiasTrabajados DTR on DTR.IdVendedor = SurtidosVendedor.IdVendedor and COM.TipoVendedor = DTR.TipoVendedor 
left join ProductosUnidad on ProductosUnidad.IdProducto = Productos.IdProducto and UPPER(ProductosUnidad.IdUnidad) = 'CAJA'
where Surtidos.IdCedis = @IdCedis and SURREP.Fecha between @FechaInicial and @FechaFinal --and Surtidos.[Status]='C'
and  upper(COM.TipoVendedor) ='PREVENTA' 
group by COM.IdComEsquema, COM.IdConceptoPago, COM.Esquema, Inicial, Final, Pago, ConceptoPago, 
Surtidos.IdCedis,  SurtidosVendedor.IdTipoVendedor, COM.TipoVendedor, 
Marcas.IdMarca, Marcas.Marca , COM.Acumulado, Vendedores.IdVendedor , Vendedores.Nombre, Vendedores.ApPaterno, Vendedores.ApMaterno 
) as temp
where ROUND((VentaLunes + VentaMartes + VentaMiercoles + VentaJueves + VentaViernes + VentaSabado ) / (CASE WHEN Acumulado = 0 THEN 1 ELSE @DiasTrabajados END),0) between Inicial and Final  


GO


USE [Route] 
GO

if (Select COUNT(*) from VersionBD where Tipo = 'SA' and Version ='3.8.16.1') = 0
BEGIN
	INSERT INTO VersionBD (Tipo, FechaHora, Version, MaximoConsecutivo, VersionSql ) 
	VALUES('SA', GETDATE(), '3.8.16.1', 99, (SELECT  cast(SERVERPROPERTY('productversion') as varchar(50))))
END
ELSE
BEGIN 
	Update VersionBD  set MaximoConsecutivo = 99 where  Tipo = 'SA' and Version ='3.8.16.1'
END

GO
