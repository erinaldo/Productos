USE [RouteCPC]
GO

/****** Object:  StoredProcedure [dbo].[sel_MovimientosFacturas]    Script Date: 03/03/2011 09:33:25 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sel_MovimientosFacturas]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sel_MovimientosFacturas]
GO

USE [RouteCPC]
GO

/****** Object:  StoredProcedure [dbo].[sel_MovimientosFacturas]    Script Date: 03/03/2011 09:33:25 ******/
SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER OFF
GO

CREATE PROCEDURE [dbo].[sel_MovimientosFacturas] 
@IdCedis as bigint,
@FolioDetalle as bigint,
@Fecha as datetime,
@IdDocumento as varchar(5),
@Opc as int
AS

if @Opc = 1 -- Detalle del mov
begin
	if @IdDocumento = ''
		select '', MovimientosFacturas.IdDocumento as IdDoc, MovimientosFacturas.IdTipoDocumento as IdTipoDoc, MovimientosFacturas.Serie, MovimientosFacturas.Folio, 
		Ventas.Total as Monto, Ventas.Cargos, Ventas.Abonos, Ventas.Saldo, MovimientosFacturas.Total as 'Importe Mov.', 
		Ventas.IdCedis, isnull(Cedis,'-Cedis No Encontrado-') as Cedis, 
		Ventas.IdCliente, isnull(Clientes.RazonSocial,'-Cliente No Econtrado-') as RazonSocial,
		Ventas.IdSucursal, isnull(ClienteSucursal.NombreSucursal,'-Sucursal No Econtrada-') as NombreSucursal,
		IdMovimientoDetalle, MovimientosFacturas.IdTipoVenta, MovimientosFacturas.IdMovimiento 
		from FolioDetalle 
		inner join MovimientosFacturas on FolioDetalle.IdCedis = MovimientosFacturas.IdCedis and MovimientosFacturas.IdMovimiento = FolioDetalle.IdMovimiento 
		left outer join Ventas on Ventas.IdCedis = MovimientosFacturas.IdCedis and Ventas.IdTipoVenta = MovimientosFacturas.IdTipoVenta
		and Ventas.Serie = MovimientosFacturas.Serie and Ventas.Folio = MovimientosFacturas.Folio
		left outer join Clientes on Clientes.IdCedis = Ventas.IdCedis and Clientes.IDCliente = Ventas.IdCliente 
		left outer join ClienteSucursal on Clientes.IdCedis = ClienteSucursal.IdCedis and Ventas.IdSucursal = ClienteSucursal.IdSucursal 
		left outer join Cedis on Cedis.IdCedis = MovimientosFacturas.IdCedis 
		where FolioDetalle.Folio = @FolioDetalle and MovimientosFacturas.Status = 'A'
		order by MovimientosFacturas.IdDocumento, MovimientosFacturas.IdTipoDocumento, MovimientosFacturas.IdMovimientoDetalle 
	else
		select '', MovimientosFacturas.IdDocumento as IdDoc, MovimientosFacturas.IdTipoDocumento as IdTipoDoc, MovimientosFacturas.Serie, MovimientosFacturas.Folio, 
		Ventas.Total as Monto, Ventas.Cargos, Ventas.Abonos, Ventas.Saldo, MovimientosFacturas.Total as 'Importe Mov.', 
		Ventas.IdCedis, isnull(Cedis,'-Cedis No Encontrado-') as Cedis, 
		Ventas.IdCliente, isnull(Clientes.RazonSocial,'-Cliente No Econtrado-') as RazonSocial,
		Ventas.IdSucursal, isnull(ClienteSucursal.NombreSucursal,'-Sucursal No Econtrada-') as NombreSucursal,
		IdMovimientoDetalle, MovimientosFacturas.IdTipoVenta, MovimientosFacturas.IdMovimiento 
		from FolioDetalle 
		inner join MovimientosFacturas on FolioDetalle.IdCedis = MovimientosFacturas.IdCedis and MovimientosFacturas.IdMovimiento = FolioDetalle.IdMovimiento 
		left outer join Ventas on Ventas.IdCedis = MovimientosFacturas.IdCedis and Ventas.IdTipoVenta = MovimientosFacturas.IdTipoVenta
		and Ventas.Serie = MovimientosFacturas.Serie and Ventas.Folio = MovimientosFacturas.Folio
		left outer join Clientes on Clientes.IdCedis = Ventas.IdCedis and Clientes.IDCliente = Ventas.IdCliente 
		left outer join ClienteSucursal on Clientes.IdCedis = ClienteSucursal.IdCedis and Ventas.IdSucursal = ClienteSucursal.IdSucursal 
		left outer join Cedis on Cedis.IdCedis = MovimientosFacturas.IdCedis 
		where FolioDetalle.Folio = @FolioDetalle and MovimientosFacturas.IdDocumento = @IdDocumento and MovimientosFacturas.Status = 'A'
		order by MovimientosFacturas.IdDocumento, MovimientosFacturas.IdTipoDocumento, MovimientosFacturas.IdMovimientoDetalle 
	
end

if @Opc = 2 -- totales del mov
begin
	if @IdDocumento = ''
		select isnull( sum(MovimientosFacturas.SubTotal), 0) as SubTotal, isnull( sum(MovimientosFacturas.Iva), 0) as Iva, isnull( sum(MovimientosFacturas.Total), 0) as Total
		from FolioDetalle 
		inner join MovimientosFacturas on FolioDetalle.IdCedis = MovimientosFacturas.IdCedis and MovimientosFacturas.IdMovimiento = FolioDetalle.IdMovimiento 
		where FolioDetalle.Folio = @FolioDetalle and MovimientosFacturas.Status = 'A'
	else
		select isnull( sum(MovimientosFacturas.SubTotal), 0) as SubTotal, isnull( sum(MovimientosFacturas.Iva), 0) as Iva, isnull( sum(MovimientosFacturas.Total), 0) as Total
		from FolioDetalle 
		inner join MovimientosFacturas on FolioDetalle.IdCedis = MovimientosFacturas.IdCedis and MovimientosFacturas.IdMovimiento = FolioDetalle.IdMovimiento 
		where FolioDetalle.Folio = @FolioDetalle and MovimientosFacturas.IdDocumento= @IdDocumento and MovimientosFacturas.Status = 'A'
end

if @Opc = 3
begin
	select distinct MOV.IdCedis, MOV.Fecha, Cedis  
	from FolioDetalle FD, Movimientos MOV,Cedis 	
	where FD.IdCedis = MOV.IdCedis and FD.IdMovimiento = MOV.IdMovimiento and FD.Folio = @FolioDetalle 
		and Cedis.IdCedis = MOV.IdCedis 
	order by MOV.IdCedis  
end

GO


