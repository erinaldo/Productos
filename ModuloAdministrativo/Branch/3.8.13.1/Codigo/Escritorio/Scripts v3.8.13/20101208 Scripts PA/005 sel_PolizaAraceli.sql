USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[sel_PolizaAraceli]    Script Date: 12/09/2010 16:35:07 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sel_PolizaAraceli]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sel_PolizaAraceli]
GO

USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[sel_PolizaAraceli]    Script Date: 12/09/2010 16:35:07 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




CREATE PROCEDURE [dbo].[sel_PolizaAraceli] 
@IdCedis as bigint,
@FechaInicial as datetime,
@FechaFinal as datetime,
@Opc as int

AS

if @Opc = 1
begin
	select '2-Contado' as Concepto, Ventas.Fecha, isnull(sum(Cantidad), 0) as Cantidad, 
	isnull(sum(VentasDetalle.Total) /sum( Cantidad), 0) as Precio, isnull(sum(VentasDetalle.total), 0) as Total
	from Ventas 
	inner join VentasDetalle on Ventas.IdCedis = VentasDetalle.IdCedis and VentasDetalle.IdSurtido = Ventas.IdSurtido and
		Ventas.IdTipoVenta = VentasDetalle.IdTipoVenta and VentasDetalle.Folio = Ventas.Folio and VentasDetalle.IdTipoVenta = 1
	inner join Productos on Productos.IdProducto = VentasDetalle.IdProducto
	where Ventas.IdCedis = @IdCedis and Ventas.Fecha between @FechaInicial and @FechaFinal
	group by Ventas.Fecha

	union

	select '1-Crédito' as Concepto, Ventas.Fecha, isnull(sum(Cantidad), 0) as Cantidad, 
	isnull(sum(VentasDetalle.Total) /sum( Cantidad), 0) as Precio, isnull(sum(VentasDetalle.total), 0) as Total
	from Ventas 
	inner join VentasDetalle on Ventas.IdCedis = VentasDetalle.IdCedis and VentasDetalle.IdSurtido = Ventas.IdSurtido and
		Ventas.IdTipoVenta = VentasDetalle.IdTipoVenta and VentasDetalle.Folio = Ventas.Folio and VentasDetalle.IdTipoVenta = 2
	inner join Productos on Productos.IdProducto = VentasDetalle.IdProducto
	where Ventas.IdCedis = @IdCedis and Ventas.Fecha between @FechaInicial and @FechaFinal
	group by Ventas.Fecha

	union

	select '5-DeudasAgentes' as Concepto, VendedoresSaldos.Fecha as Fecha, null as Cantidad, null as Precio, sum(Saldo) as Total
	from VendedoresSaldos
	where VendedoresSaldos.IdCedis = @IdCedis and VendedoresSaldos.Fecha between @FechaInicial and @FechaFinal
	and IdTipoSaldo = 'EF'
	group by VendedoresSaldos.Fecha 

	union

	select '3-Efectivo' as Concepto, Surtidos.Fecha, null as Cantidad, null as Precio, sum(Cantidad * IdDenominacion) as Total
	from SurtidosDenominacion
	inner join Surtidos on Surtidos.IdCedis = SurtidosDenominacion.IdCedis and Surtidos.IdSurtido = SurtidosDenominacion.IdSurtido
	where SurtidosDenominacion.IdCedis = @IdCedis and Surtidos.Fecha between @FechaInicial and @FechaFinal
	group by Surtidos.Fecha

	union

	select '4-Documentos (Cheques)' as Concepto, Surtidos.Fecha, null as Cantidad, null as Precio, sum(Importe) as Total
	from SurtidosCheque
	inner join Surtidos on Surtidos.IdCedis = SurtidosCheque.IdCedis and Surtidos.IdSurtido = SurtidosCheque.IdSurtido
	where SurtidosCheque.IdCedis = @IdCedis and Surtidos.Fecha between @FechaInicial and @FechaFinal
	group by Surtidos.Fecha

	union

	select '0-Ventas Totales' as Concepto, Ventas.Fecha, isnull(sum(Cantidad), 0) as Cantidad, 
	isnull(sum(VentasDetalle.Total) /sum( Cantidad), 0) as Precio, isnull(sum(VentasDetalle.total), 0) as Total
	from Ventas 
	inner join VentasDetalle on Ventas.IdCedis = VentasDetalle.IdCedis and VentasDetalle.IdSurtido = Ventas.IdSurtido and
		Ventas.IdTipoVenta = VentasDetalle.IdTipoVenta and VentasDetalle.Folio = Ventas.Folio-- and VentasDetalle.IdTipoVenta = 1
	inner join Productos on Productos.IdProducto = VentasDetalle.IdProducto
	where Ventas.IdCedis = @IdCedis and Ventas.Fecha between @FechaInicial and @FechaFinal
	group by Ventas.Fecha 

	union

	select '6-Contado Facturado' as Concepto, Ventas.Fecha, isnull(sum(Cantidad), 0) as Cantidad, 
	isnull(sum(VentasDetalle.Total) /sum( Cantidad), 0) as Precio, isnull(sum(VentasDetalle.total), 0) as Total
	from Ventas 
	inner join VentasDetalle on Ventas.IdCedis = VentasDetalle.IdCedis and VentasDetalle.IdSurtido = Ventas.IdSurtido and
		Ventas.IdTipoVenta = VentasDetalle.IdTipoVenta and VentasDetalle.Folio = Ventas.Folio and VentasDetalle.IdTipoVenta = 1
	inner join Productos on Productos.IdProducto = VentasDetalle.IdProducto
	inner join VentasFacturadas on Ventas.IdCedis = VentasFacturadas.IdCedis and VentasFacturadas.IdSurtido = Ventas.IdSurtido and
		Ventas.IdTipoVenta = VentasFacturadas.IdTipoVenta and VentasFacturadas.Folio = Ventas.Folio 
	where Ventas.IdCedis = @IdCedis and Ventas.Fecha between @FechaInicial and @FechaFinal 
	group by Ventas.Fecha

	order by Fecha, Concepto
end

if @Opc = 2
begin
	select VentasDetalle.IdProducto, Producto, isnull(sum(Cantidad), 0) as Cantidad, isnull(sum(Cantidad*Conversion),0) as Cajas,
	isnull(sum(VentasDetalle.Total) /sum( Cantidad), 0) as Precio, isnull(sum(VentasDetalle.total), 0) as Total
	from Ventas 
	inner join VentasDetalle on Ventas.IdCedis = VentasDetalle.IdCedis and VentasDetalle.IdSurtido = Ventas.IdSurtido and
		Ventas.IdTipoVenta = VentasDetalle.IdTipoVenta and VentasDetalle.Folio = Ventas.Folio and VentasDetalle.IdTipoVenta = 1
	inner join Productos on Productos.IdProducto = VentasDetalle.IdProducto
	where Ventas.IdCedis = @IdCedis and Ventas.Fecha between @FechaInicial and @FechaFinal and Ventas.IdSurtido not in (
		select VentasFacturadas.IdSurtido from VentasFacturadas where Ventas.IdCedis = VentasFacturadas.IdCedis and VentasFacturadas.IdSurtido = Ventas.IdSurtido and
		Ventas.IdTipoVenta = VentasFacturadas.IdTipoVenta and VentasFacturadas.Folio = Ventas.Folio )
	group by VentasDetalle.IdProducto, Producto
	order by VentasDetalle.IdProducto, Producto
end

if @Opc = 3
begin
	select VS.IdCedis, VS.IdSurtido, VS.Fecha, case VS.IdTipoSaldo 
		when 'EF' then 'Efectivo'
		when 'EN' then 'Envase'
		when 'CL' then 'Clientes'
	end as TipoSaldo, 
	VS.IdVendedor, 
	S.IdRuta, V.ApPaterno + ' ' + V.ApMaterno + ' ' + V.Nombre as Nombre,
	SaldoAnterior, Saldo as SaldoActual, Otros , SaldoActual as SaldoTotal
	from VendedoresSaldos as VS
	left outer join Surtidos as S on S.IdCedis = VS.IdCedis and S.IdSurtido = VS.IdSurtido
	left outer join Vendedores V on V.IdCedis = VS.IdCedis and V.IdVendedor = VS.IdVendedor
	where VS.IdCedis = @IdCedis and VS.Fecha between @FechaInicial and @FechaFinal 
	order by V.ApPaterno, V.ApMaterno, V.Nombre, S.Fecha
end
	
if @Opc = 4
begin
	select Clientes.IdCliente, Clientes.RazonSocial as Cliente, Ventas.IdSucursal, ClienteSucursal.NombreSucursal,
	isnull(sum(Cantidad), 0) as Cantidad, isnull(sum(VentasDetalle.total), 0) as Total
	from Ventas 
	inner join VentasDetalle on Ventas.IdCedis = VentasDetalle.IdCedis and VentasDetalle.IdSurtido = Ventas.IdSurtido and
		Ventas.IdTipoVenta = VentasDetalle.IdTipoVenta and VentasDetalle.Folio = Ventas.Folio and VentasDetalle.IdTipoVenta = 2
	left outer join Clientes on Clientes.IdCedis = Ventas.IdCedis and Clientes.IdCliente = Ventas.IdCliente 
	left outer join ClienteSucursal on ClienteSucursal.IdCedis = Ventas.IdCedis and ClienteSucursal.IdSucursal = Ventas.IdSucursal 
	where Ventas.IdCedis = @IdCedis and Ventas.Fecha between @FechaInicial and @FechaFinal
	group by Clientes.IdCliente, Clientes.RazonSocial, Ventas.IdSucursal, ClienteSucursal.NombreSucursal
	order by Clientes.IdCliente, Clientes.RazonSocial, Ventas.IdSucursal, ClienteSucursal.NombreSucursal
end

if @Opc = 5
begin
	select 0 as IdCliente, 'VENTA CONTADO' as Cliente, '-------' as IdSucursal, 'PUBLICO GENERAL' as NombreSucursal, isnull(sum(VentasDetalle.Cantidad), 0) as Cantidad, isnull(sum(VentasDetalle.total), 0) as Total, 0 as Orden
	from VentasContado 
	inner join Surtidos on Surtidos.IdCedis = VentasContado.IdCedis and  VentasContado.Fecha = Surtidos.Fecha
	inner join Ventas on Ventas.IdCedis = Surtidos.IdCedis and Ventas.IdSurtido = Surtidos.IdSurtido 
	left outer join VentasFacturadas on Ventas.IdCedis = VentasFacturadas.IdCedis and Ventas.IdSurtido = VentasFacturadas.IdSurtido 
		and Ventas.IdTipoVenta = VentasFacturadas.IdTipoVenta and Ventas.Folio = VentasFacturadas.Folio 
	inner join VentasDetalle on VentasDetalle.IdCedis = Ventas.IdCedis and VentasDetalle.IdSurtido = Ventas.IdSurtido 
		and VentasDetalle.IdTipoVenta = Ventas.IdTipoVenta and VentasDetalle.Folio = Ventas.Folio 
	and VentasDetalle.IdSurtido = Surtidos.IdSurtido and VentasDetalle.IdTipoVenta = 1
	where VentasContado.IdCedis = @IdCedis and VentasContado.Fecha between @FechaInicial and @FechaFinal and VentasFacturadas.Serie is null
	group by VentasContado.Serie, VentasContado.Folio, VentasFacturadas.FolioImpresion 
	
	union

	select Clientes.IdCliente, Clientes.RazonSocial as Cliente, Ventas.IdSucursal, ClienteSucursal.NombreSucursal,
	isnull(sum(Cantidad), 0) as Cantidad, isnull(sum(VentasDetalle.total), 0) as Total, 1 as Orden
	from Ventas 
	inner join VentasFacturadas on Ventas.IdCedis = VentasFacturadas.IdCedis and VentasFacturadas.IdSurtido = Ventas.IdSurtido and
		Ventas.IdTipoVenta = VentasFacturadas.IdTipoVenta and VentasFacturadas.Folio = Ventas.Folio 	
	inner join VentasDetalle on Ventas.IdCedis = VentasDetalle.IdCedis and VentasDetalle.IdSurtido = Ventas.IdSurtido and
		Ventas.IdTipoVenta = VentasDetalle.IdTipoVenta and VentasDetalle.Folio = Ventas.Folio and VentasDetalle.IdTipoVenta = 1
	left outer join Clientes on Clientes.IdCedis = Ventas.IdCedis and Clientes.IdCliente = Ventas.IdCliente 
	left outer join ClienteSucursal on ClienteSucursal.IdCedis = Ventas.IdCedis and ClienteSucursal.IdSucursal = Ventas.IdSucursal 
	where Ventas.IdCedis = @IdCedis and Ventas.Fecha between @FechaInicial and @FechaFinal
	group by Clientes.IdCliente, Clientes.RazonSocial, Ventas.IdSucursal, ClienteSucursal.NombreSucursal
	order by Orden, IdCliente, Cliente, Ventas.IdSucursal, NombreSucursal
end

GO


