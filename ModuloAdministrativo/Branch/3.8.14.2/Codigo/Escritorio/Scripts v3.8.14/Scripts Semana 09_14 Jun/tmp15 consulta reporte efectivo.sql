declare @Fecha as varchar(10)
set @Fecha = '20100601'

declare @Fecha2 as varchar(10)
set @Fecha2 = '20100604'

	select SurtidosDenominacion.IdCedis, Surtidos.Fecha, 0 as Orden, 'Efectivo' as Concepto, Monedas.IdMoneda, Monedas.Moneda, 
	sum(SurtidosDenominacion.Cantidad) as Cantidad, Denominacion as Descripcion, sum(SurtidosDenominacion.Cantidad * Denominaciones.IdDenominacion) as Importe
	from SurtidosDenominacion
	inner join Surtidos on Surtidos.IdCedis = SurtidosDenominacion.IdCedis and Surtidos.IdSurtido = SurtidosDenominacion.IdSurtido 
	inner join Denominaciones on SurtidosDenominacion.IdDenominacion = Denominaciones.IdDenominacion and SurtidosDenominacion.TipoDenominacion = Denominaciones.TipoDenominacion and SurtidosDenominacion.IdMoneda = Denominaciones.IdMoneda 
	inner join Monedas on Monedas.IdMoneda = Denominaciones.IdMoneda 
	where SurtidosDenominacion.IdCedis = 1 and Surtidos.Fecha between @Fecha and @Fecha2
	group by SurtidosDenominacion.IdCedis, Surtidos.Fecha, Denominaciones.Denominacion, Monedas.IdMoneda, Monedas.Moneda
		
	union

	select SurtidosCheque.IdCedis, Surtidos.Fecha, 1 as Orden, 'Documentos' as Concepto,  Monedas.IdMoneda, Monedas.Moneda, 
	SurtidosCheque.IdCheque as Cantidad, Nombre + ' - ' + Referencia as Descripcion, SurtidosCheque.Importe as Importe
	from SurtidosCheque
	inner join Surtidos on Surtidos.IdCedis = SurtidosCheque.IdCedis and Surtidos.IdSurtido = SurtidosCheque.IdSurtido 
	inner join Bancos on SurtidosCheque.IdBanco = Bancos.IdBanco 
	inner join Monedas on Monedas.IdMoneda = SurtidosCheque.IdMoneda 
	where SurtidosCheque.IdCedis = 1 and Surtidos.Fecha between @Fecha and @Fecha2

	order by Surtidos.Fecha, Monedas.Moneda, Orden, Descripcion 

/*
select 
	MON.Moneda, TD.TipoDenominacion, 
	SD.IdDenominacion as DENOMINACION, 
	SUM(SD.cantidad) as CANTIDAD
from Surtidos S
	inner join SurtidosDenominacion SD on S.IdSurtido = SD.IdSurtido
	inner join TipoDenominacion TD on TD.IdTipoDenominacion = SD.TipoDenominacion 
	inner join Monedas MON on MON.IdMoneda = SD.IdMoneda 
where S.Fecha = @Fecha
group by MON.Moneda, SD.IdMoneda, SD.IdDenominacion, TD.TipoDenominacion 
order by MON.Moneda, TD.TipoDenominacion, SD.IdMoneda

---------------------------------------------------------------

select 
	case SC.IdMoneda when 'CMXP' then 'Coba Sur' else 'Lacteos La Jolla' end as EMPRESA, 
	case SC.IdBanco when 1 then 'BANAMEX'
					when 2 then 'BBVBANCOMER'
					when 3 then 'HSBC'
					when 4 then 'SANTANDER SERFIN'
					when 5 then 'BANCO AZTECA'
					when 6 then 'SCOTIABANK INVERLAT'
					when 7 then 'BANORTE'
					when 8 then 'AFIRME'
					when 9 then 'INBURSA'
					when 10 then 'BANREGIO'
					when 11 then 'BANK OF AMERICA'
					end as BANCO,
	SC.Referencia as REFERENCIA,
	SC.Importe as IMPORTE
from Surtidos S
	inner join SurtidosCheque SC on S.IdSurtido = SC.IdSurtido
where S.Fecha = @Fecha
order by SC.IdMoneda

*/