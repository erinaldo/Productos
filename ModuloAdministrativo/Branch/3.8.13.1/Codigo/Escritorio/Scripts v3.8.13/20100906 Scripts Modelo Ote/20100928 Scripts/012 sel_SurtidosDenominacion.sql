USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[sel_Denominacion]    Script Date: 09/06/2010 15:04:47 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sel_Denominacion]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sel_Denominacion]
GO

USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[sel_Denominacion]    Script Date: 09/06/2010 15:04:47 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sel_Denominacion] 
@IdCedis as bigint,
@IdSurtido as bigint,
@IdDenominacion as money,
@TipoDenominacion as char(1),
@IdMoneda as varchar(5),
@Opc as int
AS

declare @IdMarca as bigint, @IdRuta as bigint, @Fecha as datetime

if @Opc = 1
	select Denominaciones.IdMoneda, Denominaciones.IdDenominacion, Denominaciones.TipoDenominacion, Denominaciones.Denominacion, isnull(Cantidad, 0) as Cantidad, 0 as Id
	from Denominaciones
	left outer join SurtidosDenominacion on SurtidosDenominacion.IdDenominacion = Denominaciones.IdDenominacion and SurtidosDenominacion.TipoDenominacion = Denominaciones.TipoDenominacion and SurtidosDenominacion.IdMoneda = Denominaciones.IdMoneda 
		and SurtidosDenominacion.IdCedis = @IdCedis and SurtidosDenominacion.IdSurtido = @IdSurtido
	where Denominaciones.IdDenominacion = @IdDenominacion and Denominaciones.TipoDenominacion = @TipoDenominacion and Denominaciones.IdMoneda = @IdMoneda and Status = 'A' 

if @Opc = 2
	select SurtidosDenominacion.IdCedis, SurtidosDenominacion.IdSurtido, 0 as Orden, Monedas.Moneda, 'Efectivo' as Concepto, 
	SurtidosDenominacion.Cantidad, Denominacion as Descripcion, SurtidosDenominacion.Cantidad * Denominaciones.IdDenominacion as Importe, 0 as Id, SurtidosDenominacion.IdDenominacion as IdDenominacion
	from SurtidosDenominacion
	inner join Denominaciones on SurtidosDenominacion.IdDenominacion = Denominaciones.IdDenominacion and SurtidosDenominacion.TipoDenominacion = Denominaciones.TipoDenominacion and SurtidosDenominacion.IdMoneda = Denominaciones.IdMoneda 
	inner join Monedas on Monedas.IdMoneda = Denominaciones.IdMoneda 
	where IdCedis = @IdCedis and IdSurtido = @IdSurtido

	union

	select SurtidosCheque.IdCedis, SurtidosCheque.IdSurtido, 1 as Orden, Monedas.Moneda, 'Documentos' as Concepto,  
	SurtidosCheque.IdCheque as Cantidad, Nombre + ' - ' + Referencia as Descripcion, SurtidosCheque.Importe as Importe, SurtidosCheque.IdCheque as Id, 0 as IdDenominacion
	from SurtidosCheque
	inner join Bancos on SurtidosCheque.IdBanco = Bancos.IdBanco 
	inner join Monedas on Monedas.IdMoneda = SurtidosCheque.IdMoneda 
	where IdCedis = @IdCedis and IdSurtido = @IdSurtido

	order by Monedas.Moneda, Orden, IdDenominacion asc

if @Opc = 3
begin
	
	select @IdRuta = IdRuta,  @Fecha = Fecha from Surtidos where IdCedis = @IdCedis and IdSurtido = @IdSurtido 
	
	select (select isnull( sum(Total),0)
	from VentasTipo 
	inner join VentasDetalle on IdCedis = @IdCedis and IdSurtido = @IdSurtido and VentasDetalle.IdTipoVenta = VentasTipo.IdTipoVenta
	where Tipo = 2) as Liquidación, 
	(select sum(SurtidosDenominacion.Cantidad * Denominaciones.IdDenominacion) 
	from SurtidosDenominacion
	inner join Denominaciones on SurtidosDenominacion.IdDenominacion = Denominaciones.IdDenominacion and SurtidosDenominacion.TipoDenominacion = Denominaciones.TipoDenominacion and SurtidosDenominacion.IdMoneda = Denominaciones.IdMoneda 
	where IdCedis = @IdCedis and IdSurtido = @IdSurtido) as Efectivo, 
	(select sum(SurtidosDenominacion.Cantidad * Denominaciones.IdDenominacion) 
	from SurtidosDenominacion
	inner join Denominaciones on SurtidosDenominacion.IdDenominacion = Denominaciones.IdDenominacion and SurtidosDenominacion.TipoDenominacion = Denominaciones.TipoDenominacion and SurtidosDenominacion.IdMoneda = Denominaciones.IdMoneda 
	where IdCedis = @IdCedis and IdSurtido = @IdSurtido) +
	(select isnull(sum(SurtidosCheque.Importe),0) 
	from SurtidosCheque
	where IdCedis = @IdCedis and IdSurtido = @IdSurtido) - 
	(select isnull( sum(Total),0)
	from VentasTipo 
	inner join VentasDetalle on IdCedis = @IdCedis and IdSurtido = @IdSurtido and VentasDetalle.IdTipoVenta = VentasTipo.IdTipoVenta
	where Tipo = 2) - 
	(select isnull(sum(ABN.Total),0)
	from Route.dbo.AbnTrp ABT
	inner join Route.dbo.TransProd TRP on ABT.TransProdID = TRP.TransProdID 
	inner join Route.dbo.Abono ABN on ABT.ABNId = ABN.ABNId 
	inner join Route.dbo.Dia Dia on ABN.DiaClave = Dia.DiaClave
	inner join Route.dbo.Visita VIS on ABN.VisitaClave = VIS.VisitaClave
	inner join Route.dbo.Vendedor VEN on VEN.VendedorID = VIS.VendedorID
	inner join Route.dbo.Usuario USU on USU.USUId = VEN.USUId
	where Dia.FechaCaptura= @Fecha and USU.Clave = 'USER' + cast( @IdRuta as varchar(20) ) 
	and TRP.TipoFase <> 0 and (TRP.CFVTipo = 2 or TRP.CFVTipo is null) 
	) as Faltante,
	(select isnull(sum(SurtidosCheque.Importe),0) 
	from SurtidosCheque
	where IdCedis = @IdCedis and IdSurtido = @IdSurtido) as Documentos,
	(select isnull(sum(ABN.Total),0)
	from Route.dbo.AbnTrp ABT
	inner join Route.dbo.TransProd TRP on ABT.TransProdID = TRP.TransProdID 
	inner join Route.dbo.Abono ABN on ABT.ABNId = ABN.ABNId 
	inner join Route.dbo.Dia Dia on ABN.DiaClave = Dia.DiaClave
	inner join Route.dbo.Visita VIS on ABN.VisitaClave = VIS.VisitaClave
	inner join Route.dbo.Vendedor VEN on VEN.VendedorID = VIS.VendedorID
	inner join Route.dbo.Usuario USU on USU.USUId = VEN.USUId
	where Dia.FechaCaptura= @Fecha and USU.Clave = 'USER' + cast( @IdRuta as varchar(20) ) 
	and TRP.TipoFase <> 0 and (TRP.CFVTipo = 2 or TRP.CFVTipo is null) 
	) as Cobranza
end

if @Opc = 4
begin

	set @IdMarca = @IdMoneda 
	select @IdMoneda = IdMoneda from MonedasMarcas where IdMarca = @IdMarca

	select (select isnull( sum(Total),0)
	from VentasTipo 
	inner join VentasDetalle on IdCedis = @IdCedis and IdSurtido = @IdSurtido and VentasDetalle.IdTipoVenta = VentasTipo.IdTipoVenta
	inner join Productos on VentasDetalle.IdProducto = Productos.IdProducto and IdMarca = @IdMarca 
	where Tipo = 2) as Liquidación, 
	(select sum(SurtidosDenominacion.Cantidad * Denominaciones.IdDenominacion) 
	from SurtidosDenominacion
	inner join Denominaciones on SurtidosDenominacion.IdDenominacion = Denominaciones.IdDenominacion and SurtidosDenominacion.TipoDenominacion = Denominaciones.TipoDenominacion and SurtidosDenominacion.IdMoneda = Denominaciones.IdMoneda 
	where IdCedis = @IdCedis and IdSurtido = @IdSurtido and SurtidosDenominacion.IdMoneda = @IdMoneda) as Efectivo, 
	(select sum(SurtidosDenominacion.Cantidad * Denominaciones.IdDenominacion) 
	from SurtidosDenominacion
	inner join Denominaciones on SurtidosDenominacion.IdDenominacion = Denominaciones.IdDenominacion and SurtidosDenominacion.TipoDenominacion = Denominaciones.TipoDenominacion and SurtidosDenominacion.IdMoneda = Denominaciones.IdMoneda 
	where IdCedis = @IdCedis and IdSurtido = @IdSurtido and SurtidosDenominacion.IdMoneda = @IdMoneda) +
	(select isnull(sum(SurtidosCheque.Importe),0) 
	from SurtidosCheque
	where IdCedis = @IdCedis and IdSurtido = @IdSurtido and SurtidosCheque.IdMoneda = @IdMoneda) - 
	(select isnull( sum(Total),0)
	from VentasTipo 
	inner join VentasDetalle on IdCedis = @IdCedis and IdSurtido = @IdSurtido and VentasDetalle.IdTipoVenta = VentasTipo.IdTipoVenta
	inner join Productos on VentasDetalle.IdProducto = Productos.IdProducto and IdMarca = @IdMarca 
	where Tipo = 2)  as Faltante,
	(select isnull(sum(SurtidosCheque.Importe),0) 
	from SurtidosCheque
	where IdCedis = @IdCedis and IdSurtido = @IdSurtido and SurtidosCheque.IdMoneda = @IdMoneda) as Documentos
end

if @Opc = 5
begin

	set @IdMarca = @IdMoneda 
	select @IdMoneda = IdMoneda from MonedasMarcas where IdMarca = @IdMarca

	select SurtidosDenominacion.IdCedis, SurtidosDenominacion.IdSurtido, 0 as Orden, Monedas.Moneda, 'Efectivo' as Concepto, 
	SurtidosDenominacion.Cantidad, Denominacion as Descripcion, SurtidosDenominacion.Cantidad * Denominaciones.IdDenominacion as Importe, 0 as Id, SurtidosDenominacion.IdDenominacion as IdDenominacion
	from SurtidosDenominacion
	inner join Denominaciones on SurtidosDenominacion.IdDenominacion = Denominaciones.IdDenominacion and SurtidosDenominacion.TipoDenominacion = Denominaciones.TipoDenominacion and SurtidosDenominacion.IdMoneda = Denominaciones.IdMoneda 
	inner join Monedas on Monedas.IdMoneda = Denominaciones.IdMoneda 
	where IdCedis = @IdCedis and IdSurtido = @IdSurtido and SurtidosDenominacion.IdMoneda = @IdMoneda 

	union

	select SurtidosCheque.IdCedis, SurtidosCheque.IdSurtido, 1 as Orden, Monedas.Moneda, 'Documentos' as Concepto,  
	SurtidosCheque.IdCheque as Cantidad, Nombre + ' - ' + Referencia as Descripcion, SurtidosCheque.Importe as Importe, SurtidosCheque.IdCheque as Id, 0 as IdDenominacion
	from SurtidosCheque
	inner join Bancos on SurtidosCheque.IdBanco = Bancos.IdBanco 
	inner join Monedas on Monedas.IdMoneda = SurtidosCheque.IdMoneda 
	where IdCedis = @IdCedis and IdSurtido = @IdSurtido and SurtidosCheque.IdMoneda = @IdMoneda 

	order by Monedas.Moneda, Orden, IdDenominacion asc
end
GO

