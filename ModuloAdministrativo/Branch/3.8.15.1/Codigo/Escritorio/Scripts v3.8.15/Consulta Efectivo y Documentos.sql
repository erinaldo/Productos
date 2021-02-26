
declare @IdCedi as bigint, @FechaInicial as datetime, @FechaFinal as datetime

set @IdCedi = 2
set @FechaInicial = '20110101'
set @FechaFinal = '20110110'

	select SurtidosDenominacion.IdCedis, Surtidos.Fecha, Surtidos.IdRuta, ( select top 1 IdVendedor from SurtidosVendedor
		where IdCedis = Surtidos.IdCedis and IdSurtido = Surtidos.IdSurtido
		order by IdTipoVendedor ) as IdVendedor, SurtidosDenominacion.IdCajero, ApPaterno + ' ' + ApMaterno + ' ' + Usuarios.Nombre as Cajero,
	0 + TipoDenominacion.IdTipoDenominacion as Orden, 'Efectivo ' + TipoDenominacion.TipoDenominacion as Concepto, Monedas.IdMoneda, Monedas.Moneda, 
	sum(SurtidosDenominacion.Cantidad) as Cantidad, Denominacion as Descripcion, sum(SurtidosDenominacion.Cantidad * Denominaciones.IdDenominacion) * ISNULL(TipoCambio,1) as Importe
	from SurtidosDenominacion
	inner join Surtidos on Surtidos.IdCedis = SurtidosDenominacion.IdCedis and Surtidos.IdSurtido = SurtidosDenominacion.IdSurtido 
	inner join Denominaciones on SurtidosDenominacion.IdDenominacion = Denominaciones.IdDenominacion and SurtidosDenominacion.TipoDenominacion = Denominaciones.TipoDenominacion and SurtidosDenominacion.IdMoneda = Denominaciones.IdMoneda 
	inner join TipoDenominacion on TipoDenominacion.IdTipoDenominacion = SurtidosDenominacion.TipoDenominacion 
	inner join Monedas on Monedas.IdMoneda = Denominaciones.IdMoneda 
	left outer join TipoDeCambio on TipoDeCambio.IdMoneda = Monedas.IdMoneda and TipoDeCambio.Fecha = Surtidos.Fecha 
	left outer join Usuarios on Usuarios.Login = SurtidosDenominacion.IdCajero
	where SurtidosDenominacion.IdCedis = @IdCedi and Surtidos.Fecha between @FechaInicial and @FechaFinal 
	group by SurtidosDenominacion.IdCedis, Surtidos.Fecha, Surtidos.IdRuta, SurtidosDenominacion.IdCajero, ApPaterno, ApMaterno, Usuarios.Nombre, 
		Denominaciones.Denominacion, Monedas.IdMoneda, Monedas.Moneda, Surtidos.IdCedis, Surtidos.IdSurtido, 
		TipoDenominacion.IdTipoDenominacion, TipoDenominacion.TipoDenominacion, TipoCambio
		
	union

	select SurtidosCheque.IdCedis, Surtidos.Fecha, Surtidos.IdRuta, ( select top 1 IdVendedor from SurtidosVendedor
		where IdCedis = Surtidos.IdCedis and IdSurtido = Surtidos.IdSurtido
		order by IdTipoVendedor ) as IdVendedor, SurtidosCheque.IdCajero, ApPaterno + ' ' + ApMaterno + ' ' + Usuarios.Nombre as Cajero, 
	100 as Orden, 'Documentos' as Concepto,  Monedas.IdMoneda, Monedas.Moneda, 
	SurtidosCheque.IdCheque as Cantidad, Bancos.Nombre + ' - ' + Referencia as Descripcion, SurtidosCheque.Importe * ISNULL(TipoCambio,1) as Importe
	from SurtidosCheque
	inner join Surtidos on Surtidos.IdCedis = SurtidosCheque.IdCedis and Surtidos.IdSurtido = SurtidosCheque.IdSurtido 
	inner join Bancos on SurtidosCheque.IdBanco = Bancos.IdBanco 
	inner join Monedas on Monedas.IdMoneda = SurtidosCheque.IdMoneda 
	left outer join TipoDeCambio on TipoDeCambio.IdMoneda = Monedas.IdMoneda and TipoDeCambio.Fecha = Surtidos.Fecha 
	left outer join Usuarios on Usuarios.Login = SurtidosCheque.IdCajero
	where SurtidosCheque.IdCedis = @IdCedi and Surtidos.Fecha between @FechaInicial and @FechaFinal 

	order by Surtidos.Fecha, IdRuta, IdVendedor, IdCajero, Monedas.Moneda, Orden, Descripcion 