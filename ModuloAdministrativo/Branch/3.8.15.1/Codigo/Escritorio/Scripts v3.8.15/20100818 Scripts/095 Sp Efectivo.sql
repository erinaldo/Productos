USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[sel_Denominacion]    Script Date: 08/12/2010 09:18:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sel_Denominacion]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sel_Denominacion]
GO

/****** Object:  StoredProcedure [dbo].[sel_DenominacionFolios]    Script Date: 08/12/2010 09:18:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sel_DenominacionFolios]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sel_DenominacionFolios]
GO

/****** Object:  StoredProcedure [dbo].[up_SurtidosCheques]    Script Date: 08/12/2010 09:18:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[up_SurtidosCheques]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[up_SurtidosCheques]
GO

/****** Object:  StoredProcedure [dbo].[up_SurtidosDenominacion]    Script Date: 08/12/2010 09:18:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[up_SurtidosDenominacion]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[up_SurtidosDenominacion]
GO

/****** Object:  StoredProcedure [dbo].[up_SurtidosDenominacionFolio]    Script Date: 08/12/2010 09:18:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[up_SurtidosDenominacionFolio]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[up_SurtidosDenominacionFolio]
GO

USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[sel_Denominacion]    Script Date: 08/12/2010 09:18:06 ******/
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
	SurtidosDenominacion.Cantidad, Denominacion as Descripcion, SurtidosDenominacion.Cantidad * Denominaciones.IdDenominacion as SubTotal,
	ISNULL(TipoDeCambio.TipoCambio,1) as TipoDeCambio, SurtidosDenominacion.Cantidad * Denominaciones.IdDenominacion * ISNULL(TipoDeCambio.TipoCambio,1) as Total,
	0 as Id, SurtidosDenominacion.IdDenominacion as IdDenominacion
	from SurtidosDenominacion
	inner join Denominaciones on SurtidosDenominacion.IdDenominacion = Denominaciones.IdDenominacion and SurtidosDenominacion.TipoDenominacion = Denominaciones.TipoDenominacion and SurtidosDenominacion.IdMoneda = Denominaciones.IdMoneda 
	inner join Monedas on Monedas.IdMoneda = Denominaciones.IdMoneda 
	inner join Surtidos on Surtidos.IdCedis = SurtidosDenominacion.IdCedis and Surtidos.IdSurtido = SurtidosDenominacion.IdSurtido 
	left outer join TipoDeCambio on TipoDeCambio.Fecha = Surtidos.Fecha and TipoDeCambio.IdMoneda = SurtidosDenominacion.IdMoneda 
	where SurtidosDenominacion.IdCedis = @IdCedis and SurtidosDenominacion.IdSurtido = @IdSurtido

	union

	select SurtidosCheque.IdCedis, SurtidosCheque.IdSurtido, 1 as Orden, Monedas.Moneda, 'Documentos' as Concepto,  
	SurtidosCheque.IdCheque as Cantidad, Nombre + ' - ' + Referencia as Descripcion, SurtidosCheque.Importe as SubTotal, 
	ISNULL(TipoDeCambio.TipoCambio,1) as TipoDeCambio, SurtidosCheque.Importe  * ISNULL(TipoDeCambio.TipoCambio,1) as Total,
	SurtidosCheque.IdCheque as Id, 0 as IdDenominacion
	from SurtidosCheque
	inner join Bancos on SurtidosCheque.IdBanco = Bancos.IdBanco 
	inner join Monedas on Monedas.IdMoneda = SurtidosCheque.IdMoneda 
	inner join Surtidos on Surtidos.IdCedis = SurtidosCheque.IdCedis and Surtidos.IdSurtido = SurtidosCheque.IdSurtido 
	left outer join TipoDeCambio on TipoDeCambio.Fecha = Surtidos.Fecha and TipoDeCambio.IdMoneda = SurtidosCheque.IdMoneda 
	where SurtidosCheque.IdCedis = @IdCedis and SurtidosCheque.IdSurtido = @IdSurtido

	order by Monedas.Moneda, Orden, IdDenominacion asc

if @Opc = 3
begin
	
	select @IdRuta = IdRuta,  @Fecha = Fecha from Surtidos where IdCedis = @IdCedis and IdSurtido = @IdSurtido 
	
	select (select isnull( sum(Total),0)
	from VentasTipo 
	inner join VentasDetalle on IdCedis = @IdCedis and IdSurtido = @IdSurtido and VentasDetalle.IdTipoVenta = VentasTipo.IdTipoVenta
	where Tipo = 2) as Liquidación, 
	
	(select sum(SurtidosDenominacion.Cantidad * Denominaciones.IdDenominacion * ISNULL(TipoDeCambio.TipoCambio,1)) 
	from SurtidosDenominacion
	inner join Denominaciones on SurtidosDenominacion.IdDenominacion = Denominaciones.IdDenominacion and SurtidosDenominacion.TipoDenominacion = Denominaciones.TipoDenominacion and SurtidosDenominacion.IdMoneda = Denominaciones.IdMoneda 
	inner join Surtidos on Surtidos.IdCedis = SurtidosDenominacion.IdCedis and Surtidos.IdSurtido = SurtidosDenominacion.IdSurtido 
	left outer join TipoDeCambio on TipoDeCambio.Fecha = Surtidos.Fecha and TipoDeCambio.IdMoneda = SurtidosDenominacion.IdMoneda 
	where SurtidosDenominacion.IdCedis = @IdCedis and SurtidosDenominacion.IdSurtido = @IdSurtido) as Efectivo, 
	
	(select sum(SurtidosDenominacion.Cantidad * Denominaciones.IdDenominacion * ISNULL(TipoDeCambio.TipoCambio,1)) 
	from SurtidosDenominacion
	inner join Denominaciones on SurtidosDenominacion.IdDenominacion = Denominaciones.IdDenominacion and SurtidosDenominacion.TipoDenominacion = Denominaciones.TipoDenominacion and SurtidosDenominacion.IdMoneda = Denominaciones.IdMoneda 
	inner join Surtidos on Surtidos.IdCedis = SurtidosDenominacion.IdCedis and Surtidos.IdSurtido = SurtidosDenominacion.IdSurtido 
	left outer join TipoDeCambio on TipoDeCambio.Fecha = Surtidos.Fecha and TipoDeCambio.IdMoneda = SurtidosDenominacion.IdMoneda 
	where SurtidosDenominacion.IdCedis = @IdCedis and SurtidosDenominacion.IdSurtido = @IdSurtido) +
	(select isnull(sum(SurtidosCheque.Importe * ISNULL(TipoDeCambio.TipoCambio,1)),0) 
	from SurtidosCheque
	inner join Surtidos on Surtidos.IdCedis = SurtidosCheque.IdCedis and Surtidos.IdSurtido = SurtidosCheque.IdSurtido 
	left outer join TipoDeCambio on TipoDeCambio.Fecha = Surtidos.Fecha and TipoDeCambio.IdMoneda = SurtidosCheque.IdMoneda 
	where SurtidosCheque.IdCedis = @IdCedis and SurtidosCheque.IdSurtido = @IdSurtido) - 
	(select isnull( sum(Total),0)
	from VentasTipo 
	inner join VentasDetalle on IdCedis = @IdCedis and IdSurtido = @IdSurtido and VentasDetalle.IdTipoVenta = VentasTipo.IdTipoVenta
	where Tipo = 2) - 
	(select isnull(sum(ABN.Total),0)
	from Route.dbo.AbnTrp ABT
	inner join Route.dbo.TransProd FAC on ABT.TransProdID = FAC.TransProdID 
	left join Route.dbo.TransProd TRP on FAC.TransProdID = TRP.FacturaID 
	inner join Route.dbo.Abono ABN on ABT.ABNId = ABN.ABNId 
	inner join Route.dbo.Dia Dia on ABN.DiaClave = Dia.DiaClave
	inner join Route.dbo.Visita VIS on ABN.VisitaClave = VIS.VisitaClave
	inner join Route.dbo.Vendedor VEN on VEN.VendedorID = VIS.VendedorID
	inner join Route.dbo.Usuario USU on USU.USUId = VEN.USUId
	where Dia.FechaCaptura= @Fecha and USU.Clave = cast( @IdCedis as varchar(10) ) + replicate('0', 4 - len( @IdRuta ) ) + cast( @IdRuta as varchar(10) )
	and FAC.Tipo = 8 and FAC.TipoFase <> 0 and (TRP.CFVTipo = 2 or TRP.CFVTipo is null) 
	) as Faltante,
	
	(select isnull(sum(SurtidosCheque.Importe * ISNULL(TipoDeCambio.TipoCambio,1)),0) 
	from SurtidosCheque
	inner join Surtidos on Surtidos.IdCedis = SurtidosCheque.IdCedis and Surtidos.IdSurtido = SurtidosCheque.IdSurtido 
	left outer join TipoDeCambio on TipoDeCambio.Fecha = Surtidos.Fecha and TipoDeCambio.IdMoneda = SurtidosCheque.IdMoneda 
	where SurtidosCheque.IdCedis = @IdCedis and SurtidosCheque.IdSurtido = @IdSurtido ) as Documentos,
	
	(select isnull(sum(ABN.Total),0)
	from Route.dbo.AbnTrp ABT
	inner join Route.dbo.TransProd FAC on ABT.TransProdID = FAC.TransProdID 
	left join Route.dbo.TransProd TRP on FAC.TransProdID = TRP.FacturaID 
	inner join Route.dbo.Abono ABN on ABT.ABNId = ABN.ABNId 
	inner join Route.dbo.Dia Dia on ABN.DiaClave = Dia.DiaClave
	inner join Route.dbo.Visita VIS on ABN.VisitaClave = VIS.VisitaClave
	inner join Route.dbo.Vendedor VEN on VEN.VendedorID = VIS.VendedorID
	inner join Route.dbo.Usuario USU on USU.USUId = VEN.USUId
	where Dia.FechaCaptura= @Fecha and USU.Clave = cast( @IdCedis as varchar(10) ) + replicate('0', 4 - len( @IdRuta ) ) + cast( @IdRuta as varchar(10) )
	and FAC.Tipo = 8 and FAC.TipoFase <> 0 and (TRP.CFVTipo = 2 or TRP.CFVTipo is null) 
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
	
	(select sum(SurtidosDenominacion.Cantidad * Denominaciones.IdDenominacion * ISNULL(TipoDeCambio.TipoCambio,1)) 
	from SurtidosDenominacion
	inner join Denominaciones on SurtidosDenominacion.IdDenominacion = Denominaciones.IdDenominacion and SurtidosDenominacion.TipoDenominacion = Denominaciones.TipoDenominacion and SurtidosDenominacion.IdMoneda = Denominaciones.IdMoneda 
	inner join Surtidos on Surtidos.IdCedis = SurtidosDenominacion.IdCedis and Surtidos.IdSurtido = SurtidosDenominacion.IdSurtido 
	left outer join TipoDeCambio on TipoDeCambio.Fecha = Surtidos.Fecha and TipoDeCambio.IdMoneda = SurtidosDenominacion.IdMoneda 
	where SurtidosDenominacion.IdCedis = @IdCedis and SurtidosDenominacion.IdSurtido = @IdSurtido and SurtidosDenominacion.IdMoneda = @IdMoneda) as Efectivo, 
	
	(select sum(SurtidosDenominacion.Cantidad * Denominaciones.IdDenominacion * ISNULL(TipoDeCambio.TipoCambio,1)) 
	from SurtidosDenominacion
	inner join Denominaciones on SurtidosDenominacion.IdDenominacion = Denominaciones.IdDenominacion and SurtidosDenominacion.TipoDenominacion = Denominaciones.TipoDenominacion and SurtidosDenominacion.IdMoneda = Denominaciones.IdMoneda 
	inner join Surtidos on Surtidos.IdCedis = SurtidosDenominacion.IdCedis and Surtidos.IdSurtido = SurtidosDenominacion.IdSurtido 
	left outer join TipoDeCambio on TipoDeCambio.Fecha = Surtidos.Fecha and TipoDeCambio.IdMoneda = SurtidosDenominacion.IdMoneda 
	where SurtidosDenominacion.IdCedis = @IdCedis and SurtidosDenominacion.IdSurtido = @IdSurtido and SurtidosDenominacion.IdMoneda = @IdMoneda) +
	(select isnull(sum(SurtidosCheque.Importe * ISNULL(TipoDeCambio.TipoCambio,1)),0) 
	from SurtidosCheque
	inner join Surtidos on Surtidos.IdCedis = SurtidosCheque.IdCedis and Surtidos.IdSurtido = SurtidosCheque.IdSurtido 
	left outer join TipoDeCambio on TipoDeCambio.Fecha = Surtidos.Fecha and TipoDeCambio.IdMoneda = SurtidosCheque.IdMoneda 
	where SurtidosCheque.IdCedis = @IdCedis and SurtidosCheque.IdSurtido = @IdSurtido and SurtidosCheque.IdMoneda = @IdMoneda) - 
	(select isnull( sum(Total),0)
	from VentasTipo 
	inner join VentasDetalle on IdCedis = @IdCedis and IdSurtido = @IdSurtido and VentasDetalle.IdTipoVenta = VentasTipo.IdTipoVenta
	inner join Productos on VentasDetalle.IdProducto = Productos.IdProducto and IdMarca = @IdMarca 
	where Tipo = 2)  as Faltante,
	
	(select isnull(sum(SurtidosCheque.Importe * ISNULL(TipoDeCambio.TipoCambio,1)),0) 
	from SurtidosCheque
	inner join Surtidos on Surtidos.IdCedis = SurtidosCheque.IdCedis and Surtidos.IdSurtido = SurtidosCheque.IdSurtido 
	left outer join TipoDeCambio on TipoDeCambio.Fecha = Surtidos.Fecha and TipoDeCambio.IdMoneda = SurtidosCheque.IdMoneda 
	where SurtidosCheque.IdCedis = @IdCedis and SurtidosCheque.IdSurtido = @IdSurtido and SurtidosCheque.IdMoneda = @IdMoneda) as Documentos
end

if @Opc = 5
begin

	set @IdMarca = @IdMoneda 
	select @IdMoneda = IdMoneda from MonedasMarcas where IdMarca = @IdMarca

	select SurtidosDenominacion.IdCedis, SurtidosDenominacion.IdSurtido, 0 as Orden, Monedas.Moneda, 'Efectivo' as Concepto, 
	SurtidosDenominacion.Cantidad, Denominacion as Descripcion, SurtidosDenominacion.Cantidad * Denominaciones.IdDenominacion as SubTotal,
	ISNULL(TipoDeCambio.TipoCambio,1) as TipoDeCambio, SurtidosDenominacion.Cantidad * Denominaciones.IdDenominacion * ISNULL(TipoDeCambio.TipoCambio,1) as Total,
	0 as Id, SurtidosDenominacion.IdDenominacion as IdDenominacion
	from SurtidosDenominacion
	inner join Denominaciones on SurtidosDenominacion.IdDenominacion = Denominaciones.IdDenominacion and SurtidosDenominacion.TipoDenominacion = Denominaciones.TipoDenominacion and SurtidosDenominacion.IdMoneda = Denominaciones.IdMoneda 
	inner join Monedas on Monedas.IdMoneda = Denominaciones.IdMoneda 
	inner join Surtidos on Surtidos.IdCedis = SurtidosDenominacion.IdCedis and Surtidos.IdSurtido = SurtidosDenominacion.IdSurtido 
	left outer join TipoDeCambio on TipoDeCambio.Fecha = Surtidos.Fecha and TipoDeCambio.IdMoneda = SurtidosDenominacion.IdMoneda 
	where SurtidosDenominacion.IdCedis = @IdCedis and SurtidosDenominacion.IdSurtido = @IdSurtido and SurtidosDenominacion.IdMoneda = @IdMoneda 

	union

	select SurtidosCheque.IdCedis, SurtidosCheque.IdSurtido, 1 as Orden, Monedas.Moneda, 'Documentos' as Concepto,  
	SurtidosCheque.IdCheque as Cantidad, Nombre + ' - ' + Referencia as Descripcion, SurtidosCheque.Importe as SubTotal, 
	ISNULL(TipoDeCambio.TipoCambio,1) as TipoDeCambio, SurtidosCheque.Importe  * ISNULL(TipoDeCambio.TipoCambio,1) as Total,
	SurtidosCheque.IdCheque as Id, 0 as IdDenominacion
	from SurtidosCheque
	inner join Bancos on SurtidosCheque.IdBanco = Bancos.IdBanco 
	inner join Monedas on Monedas.IdMoneda = SurtidosCheque.IdMoneda 
	inner join Surtidos on Surtidos.IdCedis = SurtidosCheque.IdCedis and Surtidos.IdSurtido = SurtidosCheque.IdSurtido 
	left outer join TipoDeCambio on TipoDeCambio.Fecha = Surtidos.Fecha and TipoDeCambio.IdMoneda = SurtidosCheque.IdMoneda 
	where SurtidosCheque.IdCedis = @IdCedis and SurtidosCheque.IdSurtido = @IdSurtido and SurtidosCheque.IdMoneda = @IdMoneda 

	order by Monedas.Moneda, Orden, IdDenominacion asc
end
GO

/****** Object:  StoredProcedure [dbo].[sel_DenominacionFolios]    Script Date: 08/12/2010 09:18:06 ******/
SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER OFF
GO


CREATE PROCEDURE [dbo].[sel_DenominacionFolios]
@IdCedis as bigint,
@IdSurtido as bigint,
@Folio as bigint,
@Opc as int
AS

declare @IdMarca as bigint, @IdRuta as bigint, @Fecha as datetime

if @Opc = 1
begin
	select 0 as Orden, @IdCedis, @IdSurtido, 0 as 'Folio de Entrega', '<Acumulado>' as 'Usuario', 'Activo' as Status
	
	union
	
	select 1 as Orden, IdCedis, IdSurtido, Folio as 'Folio de Entrega', IdCajero as 'Usuario',
	case Status 
		when 'A' then 'Activo'
		when 'B' then 'Baja'
	end as Status
	from SurtidosFoliosLiquidacion 
	where IdCedis = @IdCedis and IdSurtido = @IdSurtido and Status = 'A'
	order by Orden
end

if @Opc = 2
begin
	if @Folio = 0
		select SurtidosDenominacion.IdCedis, SurtidosDenominacion.IdSurtido, 0 as Orden, Monedas.Moneda, 'Efectivo' as Concepto, 
		SurtidosDenominacion.Cantidad, Denominacion as Descripcion, SurtidosDenominacion.Cantidad * Denominaciones.IdDenominacion as SubTotal,
		ISNULL(TipoDeCambio.TipoCambio,1) as TipoDeCambio, SurtidosDenominacion.Cantidad * Denominaciones.IdDenominacion * ISNULL(TipoDeCambio.TipoCambio,1) as Total,
		0 as Id, SurtidosDenominacion.IdDenominacion as IdDenominacion
		from SurtidosDenominacion
		inner join Denominaciones on SurtidosDenominacion.IdDenominacion = Denominaciones.IdDenominacion and SurtidosDenominacion.TipoDenominacion = Denominaciones.TipoDenominacion and SurtidosDenominacion.IdMoneda = Denominaciones.IdMoneda 
		inner join Monedas on Monedas.IdMoneda = Denominaciones.IdMoneda 
		inner join Surtidos on Surtidos.IdCedis = SurtidosDenominacion.IdCedis and Surtidos.IdSurtido = SurtidosDenominacion.IdSurtido 
		left outer join TipoDeCambio on TipoDeCambio.Fecha = Surtidos.Fecha and TipoDeCambio.IdMoneda = SurtidosDenominacion.IdMoneda 
		where SurtidosDenominacion.IdCedis = @IdCedis and SurtidosDenominacion.IdSurtido = @IdSurtido 

		union

		select SurtidosCheque.IdCedis, SurtidosCheque.IdSurtido, 1 as Orden, Monedas.Moneda, 'Documentos' as Concepto,  
		SurtidosCheque.IdCheque as Cantidad, Nombre + ' - ' + Referencia as Descripcion, SurtidosCheque.Importe as SubTotal, 
		ISNULL(TipoDeCambio.TipoCambio,1) as TipoDeCambio, SurtidosCheque.Importe  * ISNULL(TipoDeCambio.TipoCambio,1) as Total,
		SurtidosCheque.IdCheque as Id, 0 as IdDenominacion
		from SurtidosCheque
		inner join Bancos on SurtidosCheque.IdBanco = Bancos.IdBanco 
		inner join Monedas on Monedas.IdMoneda = SurtidosCheque.IdMoneda 
		inner join Surtidos on Surtidos.IdCedis = SurtidosCheque.IdCedis and Surtidos.IdSurtido = SurtidosCheque.IdSurtido 
		left outer join TipoDeCambio on TipoDeCambio.Fecha = Surtidos.Fecha and TipoDeCambio.IdMoneda = SurtidosCheque.IdMoneda 
		where SurtidosCheque.IdCedis = @IdCedis and SurtidosCheque.IdSurtido = @IdSurtido 

		order by Monedas.Moneda, Orden, IdDenominacion asc
	else
		select SurtidosDenominacion.IdCedis, SurtidosDenominacion.IdSurtido, 0 as Orden, Monedas.Moneda, 'Efectivo' as Concepto, 
		SurtidosDenominacion.Cantidad, Denominacion as Descripcion, SurtidosDenominacion.Cantidad * Denominaciones.IdDenominacion as SubTotal,
		ISNULL(TipoDeCambio.TipoCambio,1) as TipoDeCambio, SurtidosDenominacion.Cantidad * Denominaciones.IdDenominacion * ISNULL(TipoDeCambio.TipoCambio,1) as Total,
		0 as Id, SurtidosDenominacion.IdDenominacion as IdDenominacion
		from SurtidosDenominacion
		inner join Denominaciones on SurtidosDenominacion.IdDenominacion = Denominaciones.IdDenominacion and SurtidosDenominacion.TipoDenominacion = Denominaciones.TipoDenominacion and SurtidosDenominacion.IdMoneda = Denominaciones.IdMoneda 
		inner join Monedas on Monedas.IdMoneda = Denominaciones.IdMoneda 
		inner join Surtidos on Surtidos.IdCedis = SurtidosDenominacion.IdCedis and Surtidos.IdSurtido = SurtidosDenominacion.IdSurtido 
		left outer join TipoDeCambio on TipoDeCambio.Fecha = Surtidos.Fecha and TipoDeCambio.IdMoneda = SurtidosDenominacion.IdMoneda 
		where SurtidosDenominacion.IdCedis = @IdCedis and SurtidosDenominacion.IdSurtido = @IdSurtido and Folio = @Folio 

		union

		select SurtidosCheque.IdCedis, SurtidosCheque.IdSurtido, 1 as Orden, Monedas.Moneda, 'Documentos' as Concepto,  
		SurtidosCheque.IdCheque as Cantidad, Nombre + ' - ' + Referencia as Descripcion, SurtidosCheque.Importe as SubTotal, 
		ISNULL(TipoDeCambio.TipoCambio,1) as TipoDeCambio, SurtidosCheque.Importe  * ISNULL(TipoDeCambio.TipoCambio,1) as Total,
		SurtidosCheque.IdCheque as Id, 0 as IdDenominacion
		from SurtidosCheque
		inner join Bancos on SurtidosCheque.IdBanco = Bancos.IdBanco 
		inner join Monedas on Monedas.IdMoneda = SurtidosCheque.IdMoneda 
		inner join Surtidos on Surtidos.IdCedis = SurtidosCheque.IdCedis and Surtidos.IdSurtido = SurtidosCheque.IdSurtido 
		left outer join TipoDeCambio on TipoDeCambio.Fecha = Surtidos.Fecha and TipoDeCambio.IdMoneda = SurtidosCheque.IdMoneda 
		where SurtidosCheque.IdCedis = @IdCedis and SurtidosCheque.IdSurtido = @IdSurtido and Folio = @Folio 

		order by Monedas.Moneda, Orden, IdDenominacion asc
end

if @Opc = 3
begin
		select isnull((select sum(SurtidosDenominacion.Cantidad * Denominaciones.IdDenominacion * ISNULL(TipoDeCambio.TipoCambio,1)) as Total
		from SurtidosDenominacion
		inner join Denominaciones on SurtidosDenominacion.IdDenominacion = Denominaciones.IdDenominacion and SurtidosDenominacion.TipoDenominacion = Denominaciones.TipoDenominacion and SurtidosDenominacion.IdMoneda = Denominaciones.IdMoneda 
		inner join Surtidos on Surtidos.IdCedis = SurtidosDenominacion.IdCedis and Surtidos.IdSurtido = SurtidosDenominacion.IdSurtido 
		left outer join TipoDeCambio on TipoDeCambio.Fecha = Surtidos.Fecha and TipoDeCambio.IdMoneda = SurtidosDenominacion.IdMoneda 
		where SurtidosDenominacion.IdCedis = @IdCedis and SurtidosDenominacion.IdSurtido = @IdSurtido and SurtidosDenominacion.Folio = @Folio ),0) as Efectivo,
		isnull(( select sum(SurtidosCheque.Importe  * ISNULL(TipoDeCambio.TipoCambio,1))  
		from SurtidosCheque
		inner join Monedas on Monedas.IdMoneda = SurtidosCheque.IdMoneda 
		inner join Surtidos on Surtidos.IdCedis = SurtidosCheque.IdCedis and Surtidos.IdSurtido = SurtidosCheque.IdSurtido 
		left outer join TipoDeCambio on TipoDeCambio.Fecha = Surtidos.Fecha and TipoDeCambio.IdMoneda = SurtidosCheque.IdMoneda 
		where SurtidosCheque.IdCedis = @IdCedis and SurtidosCheque.IdSurtido = @IdSurtido and SurtidosCheque.Folio = @Folio ),0) as Docuemntos
end
GO

/****** Object:  StoredProcedure [dbo].[up_SurtidosCheques]    Script Date: 08/12/2010 09:18:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO





CREATE PROCEDURE [dbo].[up_SurtidosCheques] 
@IdCedis as bigint,
@IdSurtido as bigint,
@Folio as bigint,
@IdCajero varchar(20),
@IdMoneda as varchar(5),
@IdCheque as bigint,
@IdBanco as int,
@Referencia as varchar(30),
@Importe as money,
@Opc as int

AS

declare @IdVendedor as bigint, @Fecha as datetime

if @Opc = 1
begin
	delete from SurtidosCheque where IdCedis = @IdCedis and IdSurtido = @IdSurtido and Folio = @Folio and IdMoneda = @IdMoneda and  IdCheque = @IdCheque 
	if @Importe > 0 
	begin
		set @IdCheque = (select isnull(max(IdCheque)+1, 1) from SurtidosCheque where IdCedis = @IdCedis and IdSurtido = @IdSurtido)
		insert into SurtidosCheque values (@IdCedis, @IdSurtido, @Folio, @IdCheque, @IdCajero, @IdMoneda, @IdBanco, @Referencia, @Importe)
	end
		select top 1 @IdVendedor = SurtidosVendedor.IdVendedor, @Fecha = Surtidos.Fecha
		from Surtidos 
		inner join SurtidosVendedor on Surtidos.IdCedis = SurtidosVendedor.IdCedis and Surtidos.IdSurtido = SurtidosVendedor.IdSurtido 
		where Surtidos.IdCedis = @IdCedis and Surtidos.IdSurtido = @IdSurtido 
		order by SurtidosVendedor.IdTipoVendedor
			
		exec up_VendedoresSaldos @IdCedis, @IdSurtido, @IdVendedor, @Fecha, 1
end

GO

/****** Object:  StoredProcedure [dbo].[up_SurtidosDenominacion]    Script Date: 08/12/2010 09:18:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




CREATE PROCEDURE [dbo].[up_SurtidosDenominacion] 
@IdCedis as bigint,
@IdSurtido as bigint,
@Folio as bigint,
@IdCajero varchar(20),
@IdMoneda as varchar(5),
@IdDenominacion as money,
@TipoDenominacion as char(1),
@Cantidad as money,
@Opc as int

AS

declare @IdVendedor as bigint, @Fecha as datetime

if @Opc = 1
begin
	delete from SurtidosDenominacion where IdCedis = @IdCedis and IdSurtido = @IdSurtido and Folio = @Folio and IdMoneda = @IdMoneda and  IdDenominacion = @IdDenominacion and TipoDenominacion = @TipoDenominacion
	if @Cantidad > 0 
		insert into SurtidosDenominacion values (@IdCedis, @IdSurtido, @Folio, @IdCajero, @IdMoneda, @IdDenominacion, @TipoDenominacion, @Cantidad)
		
		select top 1 @IdVendedor = SurtidosVendedor.IdVendedor, @Fecha = Surtidos.Fecha
		from Surtidos 
		inner join SurtidosVendedor on Surtidos.IdCedis = SurtidosVendedor.IdCedis and Surtidos.IdSurtido = SurtidosVendedor.IdSurtido 
		where Surtidos.IdCedis = @IdCedis and Surtidos.IdSurtido = @IdSurtido 
		order by SurtidosVendedor.IdTipoVendedor
			
		exec up_VendedoresSaldos @IdCedis, @IdSurtido, @IdVendedor, @Fecha, 1
end

if @Opc = 2
begin
		select top 1 @IdVendedor = SurtidosVendedor.IdVendedor, @Fecha = Surtidos.Fecha
		from Surtidos 
		inner join SurtidosVendedor on Surtidos.IdCedis = SurtidosVendedor.IdCedis and Surtidos.IdSurtido = SurtidosVendedor.IdSurtido 
		where Surtidos.IdCedis = @IdCedis and Surtidos.IdSurtido = @IdSurtido 
		order by SurtidosVendedor.IdTipoVendedor
			
		exec up_VendedoresSaldos @IdCedis, @IdSurtido, @IdVendedor, @Fecha, 1
end





GO

/****** Object:  StoredProcedure [dbo].[up_SurtidosDenominacionFolio]    Script Date: 08/12/2010 09:18:06 ******/
SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER OFF
GO


CREATE PROCEDURE [dbo].[up_SurtidosDenominacionFolio]
@IdCedis as bigint,
@IdSurtido as bigint,
@Folio as bigint,
@IdCajero as varchar(20),
@Opc as int
AS

if @Opc = 1
begin	

	select @Folio = ISNULL(MAX(Folio) + 1,1) 
	from SurtidosFoliosLiquidacion  
	where IdCedis = @IdCedis and IdSurtido = @IdSurtido 

	insert into SurtidosFoliosLiquidacion values (@IdCedis, @IdSurtido, @Folio, @IdCajero, 'A')	
end

if @Opc = 2
begin
	update SurtidosFoliosLiquidacion
	set Status = 'B'
	where IdCedis = @IdCedis and IdSurtido = @IdSurtido and Folio = @Folio 
	
	delete from SurtidosCheque 
	where IdCedis = @IdCedis and IdSurtido = @IdSurtido and Folio = @Folio 
	delete from SurtidosDenominacion 
	where IdCedis = @IdCedis and IdSurtido = @IdSurtido and Folio = @Folio 
	
end



GO


