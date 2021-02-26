USE [RouteCPC]
GO

/****** Object:  StoredProcedure [dbo].[Rep_Movimientos]    Script Date: 03/03/2011 19:01:50 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Rep_Movimientos]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Rep_Movimientos]
GO

USE [RouteCPC]
GO

/****** Object:  StoredProcedure [dbo].[Rep_Movimientos]    Script Date: 03/03/2011 19:01:50 ******/
SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER OFF
GO

CREATE PROCEDURE [dbo].[Rep_Movimientos] 
@Folio as bigint,
@FechaInicial as datetime,
@FechaFinal as datetime,
@Opc as int
AS

if @Opc = 1
begin
	select replicate('0', 6 - len(Folio.Folio)) + cast(Folio.Folio as varchar(6)) as Folio, Folio.Fecha as FechaM, Folio.Login,
	Folio.Monto as Importe, Folio.Observaciones, Movimientos.IdDocumento, Movimientos.IdDocumento + ' - ' + Documento AS Documento,
	MovimientosFacturas.IdTipoDocumento, MovimientosFacturas.IdTipoDocumento + ' - ' + TipoDocumento as TipoDocumento,
	Ventas.IdCliente, Clientes.RazonSocial as Cliente, ClienteSucursal.IdSucursal + ' - ' + ClienteSucursal.NombreSucursal as Sucursal, 
	ISNULL(ClientesTipo.Tipo,'') AS CTipo, MovimientosFacturas.Referencia, MovimientosFacturas.ReferenciaBancos, 
	Ventas.Serie, Ventas.Folio as FolioVenta, Ventas.Fecha, MovimientosFacturas.Total as Monto, case MovimientosFacturas.CargoAbono when 'A' then 'ABONOS' else 'CARGOS' end CargoAbono,
	VentasAcredita.FechaAcredita, VentasAcredita.FechaEntrega, VentasAcredita.FolioEntrega, VentasAcredita.FolioCliente, VentasAcredita.Remision, VentasAcredita.Factura  
	from Folio
	inner join FolioDetalle on Folio.Folio = FolioDetalle.Folio 
	inner join Movimientos on FolioDetalle.IdCedis = Movimientos.IdCedis and FolioDetalle.IdMovimiento = Movimientos.IdMovimiento 
	inner join MovimientosFacturas on Movimientos.IdCedis = MovimientosFacturas.IdCedis and Movimientos.IdMovimiento = MovimientosFacturas.IdMovimiento and MovimientosFacturas.Status <> 'B' 
	inner join Cedis on Cedis.IdCedis = Movimientos.IdCedis
	left outer join Ventas on Ventas.IdCedis = MovimientosFacturas.IdCedis and Ventas.IdTipoVenta = MovimientosFacturas.IdTipoVenta
		and Ventas.Serie = MovimientosFacturas.Serie collate SQL_Latin1_General_CP1_CI_AS and Ventas.Folio = MovimientosFacturas.Folio
	left outer join VentasAcredita on VentasAcredita.IdCedis = MovimientosFacturas.IdCedis and VentasAcredita.IdTipoVenta = MovimientosFacturas.IdTipoVenta
		and VentasAcredita.Serie = MovimientosFacturas.Serie collate SQL_Latin1_General_CP1_CI_AS and VentasAcredita.Folio = MovimientosFacturas.Folio
	left outer join Clientes on Clientes.IdCedis = Ventas.IdCedis and Clientes.IDCliente = Ventas.IdCliente 
	left outer join ClientesTipo on Clientes.IdCedis = ClientesTipo.IdCedis and Clientes.IdCliente = ClientesTipo.IdCliente 
	left outer join ClienteSucursal on Clientes.IdCedis = ClienteSucursal.IdCedis and Ventas.IdSucursal = ClienteSucursal.IdSucursal  
	inner join Documentos on Movimientos.IdDocumento = Documentos.IdDocumento 
	inner join DocumentosTipo on DocumentosTipo.IdTipoDocumento = MovimientosFacturas.IdTipoDocumento and DocumentosTipo.IdDocumento = MovimientosFacturas.IdDocumento
	where Folio.Folio = @Folio 
	order by Folio.Folio, MovimientosFacturas.CargoAbono, Movimientos.IdDocumento, Ventas.IdCliente, MovimientosFacturas.IdTipoDocumento, Ventas.Serie, Ventas.Folio 
end

if @Opc = 2
begin
	select replicate('0', 6 - len(Anticipos.FolioAnticipo)) + cast(Anticipos.FolioAnticipo as varchar(6)) as FolioAnt, Anticipos.Fecha as FechaAnt, Anticipos.Login as LoginAnt,
		Anticipos.Importe as ImporteAnt, Anticipos.Saldo as SaldoAnt, Anticipos.Observaciones as ObservacionesAnt,
		Movimientos.IdDocumento, Movimientos.IdDocumento + ' - ' + Documento AS Documento,
		MovimientosFacturas.IdTipoDocumento, MovimientosFacturas.IdTipoDocumento + ' - ' + TipoDocumento as TipoDocumento,
		Ventas.IdCliente, Clientes.RazonSocial as Cliente, ClienteSucursal.IdSucursal + ' - ' + ClienteSucursal.NombreSucursal as Sucursal, 
		ISNULL(ClientesTipo.Tipo,'') AS CTipo, MovimientosFacturas.Referencia, MovimientosFacturas.ReferenciaBancos, 
		Ventas.Serie, Ventas.Folio as FolioVenta, Ventas.Fecha, MovimientosFacturas.Total as Monto, MovimientosFacturas.Login as Login, case MovimientosFacturas.CargoAbono when 'A' then 'ABONOS' else 'CARGOS' end CargoAbono,
		VentasAcredita.FechaAcredita, VentasAcredita.FechaEntrega, VentasAcredita.FolioEntrega, VentasAcredita.FolioCliente, VentasAcredita.Remision, VentasAcredita.Factura  
	from Anticipos
	left outer join AnticiposDetalle on Anticipos.FolioAnticipo = AnticiposDetalle.FolioAnticipo and AnticiposDetalle.Status <> 'B'
	inner join Movimientos on AnticiposDetalle.IdCedisMov = Movimientos.IdCedis and AnticiposDetalle.IdMovimiento = Movimientos.IdMovimiento 
	inner join MovimientosFacturas on AnticiposDetalle.IdCedisMov = MovimientosFacturas.IdCedis and AnticiposDetalle.IdMovimiento = MovimientosFacturas.IdMovimiento 
		and AnticiposDetalle.IdMovimientoDetalle = MovimientosFacturas.IdMovimientoDetalle and MovimientosFacturas.Status <> 'B' 
	inner join Cedis on Cedis.IdCedis = Movimientos.IdCedis
	left outer join Ventas on Ventas.IdCedis = MovimientosFacturas.IdCedis and Ventas.IdTipoVenta = MovimientosFacturas.IdTipoVenta
		and Ventas.Serie = MovimientosFacturas.Serie collate SQL_Latin1_General_CP1_CI_AS and Ventas.Folio = MovimientosFacturas.Folio
	left outer join VentasAcredita on VentasAcredita.IdCedis = MovimientosFacturas.IdCedis and VentasAcredita.IdTipoVenta = MovimientosFacturas.IdTipoVenta
		and VentasAcredita.Serie = MovimientosFacturas.Serie collate SQL_Latin1_General_CP1_CI_AS and VentasAcredita.Folio = MovimientosFacturas.Folio
	left outer join Clientes on Clientes.IdCedis = Ventas.IdCedis and Clientes.IDCliente = Ventas.IdCliente 
	left outer join ClientesTipo on Clientes.IdCedis = ClientesTipo.IdCedis and Clientes.IdCliente = ClientesTipo.IdCliente 
	left outer join ClienteSucursal on Clientes.IdCedis = ClienteSucursal.IdCedis and Ventas.IdSucursal = ClienteSucursal.IdSucursal  
	inner join Documentos on Movimientos.IdDocumento = Documentos.IdDocumento 	
	inner join DocumentosTipo on DocumentosTipo.IdTipoDocumento = MovimientosFacturas.IdTipoDocumento and DocumentosTipo.IdDocumento = MovimientosFacturas.IdDocumento
	where Anticipos.FolioAnticipo = @Folio 
	order by Anticipos.FolioAnticipo, MovimientosFacturas.CargoAbono, Movimientos.IdDocumento, Ventas.IdCliente, MovimientosFacturas.IdTipoDocumento, Ventas.Serie, Ventas.Folio 
end

GO


