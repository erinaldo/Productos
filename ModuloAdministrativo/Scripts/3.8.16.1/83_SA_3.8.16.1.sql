USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[sel_ComisionesCalculo]    Script Date: 08/29/2011 11:32:39 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sel_ComisionesCalculo]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sel_ComisionesCalculo]
GO

USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[sel_ComisionesCalculo]    Script Date: 08/29/2011 11:32:39 ******/
SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER OFF
GO


CREATE PROCEDURE [dbo].[sel_ComisionesCalculo]
@IdCedis as bigint,
@FechaInicial as datetime,
@FechaFinal as datetime
AS
	
--set @IdCedis = 1
--set @FechaInicial ='2011-08-15T00:00:00'
--set @FechaFinal ='2011-08-20T00:00:00'

DECLARE @Comisiones as Table(IdComEsquema bigint, Esquema varchar(50), IdProducto bigint, IdMarca bigint, IdConceptoPago bigint,
ConceptoPago varchar(30), Inicial float, Final float, IdTipoVendedor bigint, TipoVendedor varchar(20), Pago money,  Acumulado bit)

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

--Obtener los dias trabajados del vendedor en todos los roles
DECLARE @DiasTrabajados as Table(IdVendedor bigint ,TipoVendedor varchar(20), NumeroDiasTrab smallint)
insert into @DiasTrabajados 
Select SurtidosVendedor.IdVendedor, TipoVendedor.TipoVendedor, COUNT(Distinct Surtidos.Fecha ) from Surtidos
inner join SurtidosVendedor on Surtidos.IdCedis = SurtidosVendedor.IdCedis and Surtidos.IdSurtido = SurtidosVendedor.IdSurtido 
inner join TipoVendedor on SurtidosVendedor.IdTipoVendedor = TipoVendedor.IdTipoVendedor
where Surtidos.IdCedis = @IdCedis and Surtidos.[Status]='C' and Surtidos.Fecha between @FechaInicial and @FechaFinal 
and upper(TipoVendedor.TipoVendedor ) <>'PREVENTA'
group by SurtidosVendedor.IdVendedor, TipoVendedor.TipoVendedor  
UNION 
SELECT  SURVEN.IdVendedor, TPVEN.TipoVendedor, COUNT(Distinct SUR.Fecha ) 
from Ventas VTA
INNER JOIN Surtidos SUR ON SUR.IdRuta  = VTA.RutaPrev and (SUR.Fecha = VTA.FechaPrev)
INNER JOIN SurtidosVendedor SURVEN ON SUR.IdSurtido = SURVEN.IdSurtido 
INNER JOIN TipoVendedor TPVEN ON SURVEN.IdTipoVendedor = TPVEN.IdTipoVendedor 
WHERE (VTA.Fecha BETWEEN  DATEADD(day,-DATEPART(dw, @FechaInicial)+1, @FechaInicial) AND DATEADD(day,-DATEPART(dw, @FechaInicial )+6, @FechaInicial ))
and SUR.Status = 'C' and (SUR.IdCedis = @IdCedis)
GROUP BY SURVEN.IdVendedor, TPVEN.TipoVendedor 


--Comisiones x Producto
select Surtidos.IdCedis, Vendedores.IdVendedor , Vendedores.Nombre, @FechaInicial as FechaIni, @FechaFinal as FechaFin, 
COM.IdComEsquema, COM.Esquema, COM.IdConceptoPago, ConceptoPago,null as IdRuta, 
SurtidosVendedor.IdTipoVendedor, COM.TipoVendedor, null as IdMarca, null as Marca, 
VentasDetalle.IdProducto, Producto, 
CASE WHEN COM.IdConceptoPago = 1 THEN sum(Cantidad) WHEN COM.IdConceptoPago = 2 THEN SUM(Cantidad/ isnull(ProductosUnidad.Factor,1 )) WHEN COM.IdConceptoPago = 3 THEN sum(Total) ELSE 0 END as Venta, 
DTR.NumeroDiasTrab as DiasTrabajados, 
CASE WHEN COM.Acumulado = 0 THEN null ELSE (CASE WHEN COM.IdConceptoPago = 1 THEN sum(Cantidad) WHEN COM.IdConceptoPago = 2 THEN SUM(Cantidad/ isnull(ProductosUnidad.Factor,0 )) WHEN COM.IdConceptoPago = 3 THEN sum(Total) ELSE 0 END / (CASE WHEN COM.Acumulado = 0 THEN 1 ELSE DTR.NumeroDiasTrab END)) END as PromSem,
Inicial, Final, Pago as Factor, 
CASE WHEN COM.IdConceptoPago = 1 THEN sum(Cantidad) WHEN COM.IdConceptoPago = 2 THEN SUM(Cantidad/ isnull(ProductosUnidad.Factor,1 )) WHEN COM.IdConceptoPago = 3 THEN sum(Total) ELSE 0 END * Pago as 'Pago', null as AbonoMerma, null as AbonoVolumen
from Surtidos
inner join SurtidosVendedor on Surtidos.IdCedis = SurtidosVendedor.IdCedis and Surtidos.IdSurtido = SurtidosVendedor.IdSurtido 
inner join Vendedores on Vendedores.IdCedis = SurtidosVendedor.IdCedis and Vendedores.IdVendedor = SurtidosVendedor.IdVendedor 
inner join VentasDetalle on Surtidos.IdCedis = VentasDetalle.IdCedis and Surtidos.IdSurtido = VentasDetalle.IdSurtido
inner join Productos on Productos.IdProducto = VentasDetalle.IdProducto
inner join @Comisiones COM on COM.IdTipoVendedor = SurtidosVendedor.IdTipoVendedor and COM.IdProducto = VentasDetalle.IdProducto
inner join @DiasTrabajados DTR on DTR.IdVendedor = SurtidosVendedor.IdVendedor and COM.TipoVendedor = DTR.TipoVendedor
left join ProductosUnidad on ProductosUnidad.IdProducto = Productos.IdProducto and UPPER(ProductosUnidad.IdUnidad) = 'CAJA'
where Surtidos.IdCedis = @IdCedis and Surtidos.[Status]='C' and Surtidos.Fecha between @FechaInicial and @FechaFinal 
and upper(COM.TipoVendedor) <> 'PREVENTA'  
group by COM.IdComEsquema, COM.IdConceptoPago, COM.Esquema, Inicial, Final, Pago, ConceptoPago, 
Surtidos.IdCedis, SurtidosVendedor.IdTipoVendedor, COM.TipoVendedor, 
VentasDetalle.IdProducto, Producto, COM.Acumulado, Vendedores.IdVendedor , Vendedores.Nombre, DTR.NumeroDiasTrab 
having CASE WHEN COM.IdConceptoPago = 1 THEN sum(Cantidad) WHEN COM.IdConceptoPago = 2 THEN SUM(Cantidad/ isnull(ProductosUnidad.Factor,0 )) WHEN COM.IdConceptoPago = 3 THEN sum(Total) ELSE 0 END / (CASE WHEN COM.Acumulado = 0 THEN 1 ELSE DTR.NumeroDiasTrab END) between Inicial and Final  
UNION
--Comisiones x Marca
select Surtidos.IdCedis, Vendedores.IdVendedor , Vendedores.Nombre, @FechaInicial as FechaIni, @FechaFinal as FechaFin, 
COM.IdComEsquema, COM.Esquema, COM.IdConceptoPago,ConceptoPago, null as IdRuta, 
SurtidosVendedor.IdTipoVendedor, COM.TipoVendedor, Marcas.IdMarca, Marca, 
null as IdProducto, null as Producto, 
CASE WHEN COM.IdConceptoPago = 1 THEN sum(Cantidad) WHEN COM.IdConceptoPago = 2 THEN SUM(Cantidad/ isnull(ProductosUnidad.Factor,1 )) WHEN COM.IdConceptoPago = 3 THEN sum(Total) ELSE 0 END as Venta, 
DTR.NumeroDiasTrab as DiasTrabajados, 
CASE WHEN COM.Acumulado = 0 THEN null ELSE (CASE WHEN COM.IdConceptoPago = 1 THEN sum(Cantidad) WHEN COM.IdConceptoPago = 2 THEN SUM(Cantidad/ isnull(ProductosUnidad.Factor,0 )) WHEN COM.IdConceptoPago = 3 THEN sum(Total) ELSE 0 END / (CASE WHEN COM.Acumulado = 0 THEN 1 ELSE DTR.NumeroDiasTrab END)) END as PromSem,
Inicial, Final, Pago as Factor, 
CASE WHEN COM.IdConceptoPago = 1 THEN sum(Cantidad) WHEN COM.IdConceptoPago = 2 THEN SUM(Cantidad/ isnull(ProductosUnidad.Factor,1 )) WHEN COM.IdConceptoPago = 3 THEN sum(Total) ELSE 0 END * Pago as 'Pago', null as AbonoMerma, null as AbonoVolumen
from Surtidos
inner join SurtidosVendedor on Surtidos.IdCedis = SurtidosVendedor.IdCedis and Surtidos.IdSurtido = SurtidosVendedor.IdSurtido 
inner join Vendedores on Vendedores.IdCedis = SurtidosVendedor.IdCedis and Vendedores.IdVendedor = SurtidosVendedor.IdVendedor 
inner join VentasDetalle on Surtidos.IdCedis = VentasDetalle.IdCedis and Surtidos.IdSurtido = VentasDetalle.IdSurtido
inner join Productos on Productos.IdProducto = VentasDetalle.IdProducto
inner join Marcas on Marcas.IdMarca = Productos.IdMarca
inner join @Comisiones COM on COM.IdTipoVendedor = SurtidosVendedor.IdTipoVendedor and COM.IdMarca = Marcas.IdMarca
inner join @DiasTrabajados DTR on DTR.IdVendedor = SurtidosVendedor.IdVendedor and COM.TipoVendedor = DTR.TipoVendedor 
left join ProductosUnidad on ProductosUnidad.IdProducto = Productos.IdProducto and UPPER(ProductosUnidad.IdUnidad) = 'CAJA'
where Surtidos.IdCedis = @IdCedis and Surtidos.[Status]='C' and Surtidos.Fecha between @FechaInicial and @FechaFinal 
and  upper(COM.TipoVendedor) <>'PREVENTA' 
group by COM.IdComEsquema, COM.IdConceptoPago, COM.Esquema, Inicial, Final, Pago, ConceptoPago, 
Surtidos.IdCedis,  SurtidosVendedor.IdTipoVendedor, COM.TipoVendedor, 
Marcas.IdMarca, Marcas.Marca , COM.Acumulado, Vendedores.IdVendedor , Vendedores.Nombre, DTR.NumeroDiasTrab 
having CASE WHEN COM.IdConceptoPago = 1 THEN sum(Cantidad) WHEN COM.IdConceptoPago = 2 THEN SUM(Cantidad/ isnull(ProductosUnidad.Factor,0 )) WHEN COM.IdConceptoPago = 3 THEN sum(Total) ELSE 0 END / (CASE WHEN COM.Acumulado = 0 THEN 1 ELSE DTR.NumeroDiasTrab END) between Inicial and Final  

GO

USE [Route] 
GO

if (Select COUNT(*) from VersionBD where Tipo = 'SA' and Version ='3.8.16.1') = 0
BEGIN
	INSERT INTO VersionBD (Tipo, FechaHora, Version, MaximoConsecutivo, VersionSql ) 
	VALUES('SA', GETDATE(), '3.8.16.1', 83, (SELECT  cast(SERVERPROPERTY('productversion') as varchar(50))))
END
ELSE
BEGIN 
	Update VersionBD  set MaximoConsecutivo = 83 where  Tipo = 'SA' and Version ='3.8.16.1'
END

GO

