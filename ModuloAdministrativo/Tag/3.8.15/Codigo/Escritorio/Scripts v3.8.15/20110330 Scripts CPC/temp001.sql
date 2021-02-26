
--update PromocionesAplicadasDetalle set IdAplicacionAnterior = '', IdPromocionAnterior = ''

select * from PromocionesAplicadasDetalle 
where IdPromocion = 1  and IdAplicacion = 2
order by IdPromocion, IdAplicacion desc, IdCedis, Serie, Folio 

select * from PromocionesAplicadasDetalle 
where IdPromocion = 1  and IdAplicacion = 1
order by IdPromocion, IdAplicacion desc, IdCedis, Serie, Folio 

--select IdPromocion, IdAplicacion, COUNT(Folio) 
--from PromocionesAplicadasDetalle where IdPromocion = 1 
--group by IdPromocion, IdAplicacion 
--order by IdPromocion, IdAplicacion desc

--select IdPromocion, IdAplicacion, IdCedis, IdTipoVenta, Serie, Folio, COUNT(IdCliente ) 
--from PromocionesAplicadasDetalle where IdPromocion = 1 
--group by IdPromocion, IdAplicacion , IdCedis, IdTipoVenta, Serie, Folio
--order by IdPromocion, IdAplicacion desc


--select * from PromocionesAplicadasDetalle where IdPromocion = 1 and IdAplicacion in( 1) order by IdCedis, Serie, Folio 

--select * from Promociones where IdPromocion = 1
