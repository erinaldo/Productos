USE ROUTEADM

declare 
@IdCedis as bigint,
@Fecha as datetime

set @IdCedis = 2
set @Fecha = '20101127'

select '', '', @Fecha, '', @Fecha, 0, @Fecha, 0, 0, 0, 0, 'FOLE', @Fecha, '', 0, @Fecha, GETDATE(), 'SUPER', 0, 0, 0, '', '',  '', '', '', '', null, 
0,0,0, 0,0,0, 0,0,0, 0,0,0, '', null, '', '',  '', '', '', '', 0, '', '' as Serie, 0 as Folio

union

select cast(VEN.IdCedis as varchar(2)) + cast(VEN.IdSurtido as varchar(10)) + VEN.Serie + CAST(VEN.Folio as varchar(10)) Numero, RIGHT(newid(),11) Operacion, VEN.Fecha FRegistro, isnull(VA.Remision,'') Remision, VEN.Fecha FRemision, 
VEN.Folio Factura, VEN.Fecha FFactura, VEN.IdSucursal Cliente, SUR.IdRuta, isnull(PCTE.IdLista, 3) Cveprecio, isnull(PRUTA.IdLista, 3) CP_Dist, VA.FolioEntrega Folioentr, VA.FechaEntrega FEntrada,
case isnull(CONF.SerieFacturasCredito,'') when '' then  'R' else 'F' end TipoDoc, isnull(VEN.DiasCredito,0) Plazo, VEN.Fecha + isnull(VEN.DiasCredito,0) FVencimient,
isnull((select top 1 FechaEjecucion from Bitacora 
	where IdCedis = @IdCedis and IdSurtido = SUR.IdSurtido and Serie = VEN.Serie and Folio = VEN.Folio and FechaTrabajo = @Fecha 
	order by FechaEjecucion desc ), '19000101') HoraCaptur, 
isnull((select top 1 Login from Bitacora 
	where IdCedis = @IdCedis and IdSurtido = SUR.IdSurtido and Serie = VEN.Serie and Folio = VEN.Folio and FechaTrabajo = @Fecha 
	order by FechaEjecucion desc ), 'No Identifiado') as Capturista, 
VEN.Subtotal, VEN.Iva, VEN.Total, '' Fact_Impresa, case VA.Status when 'A' then 'S' else 'N' end Acreditada,
'' Diferencia, '' Acredito, '' Corrigio, '' NotasCorrec, null FCorreccion, 0 as SubTotRec, 0 as IvaRec, 
0 as Subtotreccto,0 as Ivareccto, 0 as Esubtotpromo, 0 as Eivapromo,0 as Esubtpromdist,0 as Subtotcosto, 0 as ivacosto,0 as TotalCosto, 0 as Subtotse, 0 as IvaSe, '' FactDist, null FFactDist,'' as Tipodoc2,'' as Linea,'' as Bt_origen,'' as Bt_num,
'' as Estado_ie, '' as Cd, 0 as CargoDist, ISNULL(VA.FolioCliente,'') as FolioCliente, VA.Serie, VA.Folio 
from VentasAcredita VA 
inner join Ventas VEN on VEN.IdCedis = VA.IdCedis and VEN.IdSurtido = VA.IdSurtido and VEN.IdTipoVenta = VA.IdTipoVenta and VEN.Folio = VA.Folio 
inner join Surtidos SUR on SUR.IdCedis = VEN.IdCedis and SUR.IdSurtido = VEN.IdSurtido 
left outer join Configuracion CONF on CONF.IdCedis = VEN.IdCedis and CONF.SerieFacturasCredito = VEN.Serie
inner join SurtidosVendedor SURV on VEN.IdCedis = SURV.IdCedis and VEN.IdSurtido = SURV.IdSurtido and SURV.IdTipoVendedor in (1,2)
left outer join PreciosListaCliente PCTE on PCTE.IdCedis = VEN.IdCedis and PCTE.IdCliente = VEN.IdCliente 
left outer join PreciosListaRuta PRUTA on PRUTA.IdCedis = VEN.IdCedis and PRUTA.IdRuta = SUR.IdRuta 
where VA.IdCedis = @IdCedis and VA.IdTipoVenta in (1,2) and (VA.FechaAcredita = @Fecha or VEN.Fecha = @Fecha)
order by VA.Serie, VA.Folio

select '', 0,0,  0,0, 0,0, 0, '', 0,0, 0,0, '', 0, '' as Serie, 0 as Folio

union

select cast(VEN.IdCedis as varchar(2)) + cast(VEN.IdSurtido as varchar(10)) + VEN.Serie + CAST(VEN.Folio as varchar(10)) Numero, VENDET.IdProducto,
VENDET.Cantidad / ISNULL(PRODU.Factor,1) as Cantidad, VENDET.Cantidad Cantidad2, VENDET.Precio Precio, PDET.Precio PrecioDist, VENDET.Iva Iva, 
VENDET.Entregado Recibidas, '' Promocion, 0 SubTotProm, 0 IvaPromo, 0 SubTPromDi, 0 IvaPromDis, '' PromocionCargo, 0 SubPromCgo, VA.Serie, VA.Folio 
from VentasAcredita VA 
inner join Ventas VEN on VEN.IdCedis = VA.IdCedis and VEN.IdSurtido = VA.IdSurtido and VEN.IdTipoVenta = VA.IdTipoVenta and VEN.Folio = VA.Folio 
inner join Surtidos SUR on SUR.IdCedis = VEN.IdCedis and SUR.IdSurtido = VEN.IdSurtido 
left outer join VentasDetalle VENDET on VEN.IdCedis = VENDET.IdCedis and VEN.IdSurtido = VENDET.IdSurtido and VEN.Serie = VENDET.Serie and VEN.Folio = VENDET.Folio  
left outer join ProductosUnidad PRODU on PRODU.IdProducto = VENDET.IdProducto and PRODU.IdUnidad = ''
left outer join PreciosListaCliente PCTE on PCTE.IdCedis = VEN.IdCedis and PCTE.IdCliente = VEN.IdCliente 
left outer join PreciosListaRuta PRUTA on PRUTA.IdCedis = VEN.IdCedis and PRUTA.IdRuta = SUR.IdRuta 
left outer join PreciosDetalle PDET on PDET.IdLista = PRUTA.IdLista and PDET.IdProducto = VENDET.IdProducto 
where VA.IdCedis = @IdCedis and VA.IdTipoVenta in (1,2) and (VA.FechaAcredita = @Fecha or VEN.Fecha = @Fecha)
order by VA.Serie, VA.Folio



--select *
--from VentasFacturadas  