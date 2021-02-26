
select SurtidosDenominacion.IdCedis, Surtidos.Fecha, 0 + TipoDenominacion.IdTipoDenominacion as Orden, 'Efectivo ' + TipoDenominacion.TipoDenominacion as Concepto, Monedas.IdMoneda, Monedas.Moneda, 
sum(SurtidosDenominacion.Cantidad) as Cantidad, Denominacion as Descripcion, sum(SurtidosDenominacion.Cantidad * Denominaciones.IdDenominacion ) * ISNULL(TipoCambio,1) as Importe
from SurtidosDenominacion
inner join Surtidos on Surtidos.IdCedis = SurtidosDenominacion.IdCedis and Surtidos.IdSurtido = SurtidosDenominacion.IdSurtido 
inner join Denominaciones on SurtidosDenominacion.IdDenominacion = Denominaciones.IdDenominacion and SurtidosDenominacion.TipoDenominacion = Denominaciones.TipoDenominacion and SurtidosDenominacion.IdMoneda = Denominaciones.IdMoneda 
inner join TipoDenominacion on TipoDenominacion.IdTipoDenominacion = SurtidosDenominacion.TipoDenominacion 
inner join Monedas on Monedas.IdMoneda = Denominaciones.IdMoneda 
left outer join TipoDeCambio on TipoDeCambio.IdMoneda = Monedas.IdMoneda and TipoDeCambio.Fecha = Surtidos.Fecha 
where SurtidosDenominacion.IdCedis = 2 and Surtidos.Fecha between '20101122' and '20101122' 
group by SurtidosDenominacion.IdCedis, Surtidos.Fecha, Denominaciones.Denominacion, Monedas.IdMoneda, Monedas.Moneda, 
	TipoDenominacion.IdTipoDenominacion, TipoDenominacion.TipoDenominacion, TipoDeCambio.TipoCambio 
	
union

select SurtidosCheque.IdCedis, Surtidos.Fecha, 100 as Orden, 'Documentos' as Concepto,  Monedas.IdMoneda, Monedas.Moneda, 
SurtidosCheque.IdCheque as Cantidad, Nombre + ' - ' + Referencia as Descripcion, SurtidosCheque.Importe * ISNULL(TipoCambio,1) as Importe
from SurtidosCheque
inner join Surtidos on Surtidos.IdCedis = SurtidosCheque.IdCedis and Surtidos.IdSurtido = SurtidosCheque.IdSurtido 
inner join Bancos on SurtidosCheque.IdBanco = Bancos.IdBanco 
inner join Monedas on Monedas.IdMoneda = SurtidosCheque.IdMoneda 
left outer join TipoDeCambio on TipoDeCambio.IdMoneda = Monedas.IdMoneda and TipoDeCambio.Fecha = Surtidos.Fecha 
where SurtidosCheque.IdCedis = 2 and Surtidos.Fecha between '20101122' and '20101122' 

order by Surtidos.Fecha, Monedas.Moneda, Orden, Descripcion 
