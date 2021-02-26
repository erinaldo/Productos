
select 'R' + cast(Surtidos.IdRuta as varchar(10)) as Serie, V.IdCedis, V.IdSurtido, Surtidos.IdRuta, V.IdTipoVenta, V.Fecha,
V.Serie, V.Folio, V.Subtotal, TP.Folio, TP.Subtotal, V.Subtotal - TP.Subtotal as Diferencia, cast(substring(TP.Folio,2,4) as int) as RutaFolio
from  Ventas V
inner join Surtidos on Surtidos.IdCedis = V.IdCedis and Surtidos.IdSurtido = V.IdSurtido 
	-- and Surtidos.IdRuta = 1
inner join Route.dbo.TransProd TP on cast(RIGHT(TP.Folio,4) as bigint) = V.Folio and 
	TP.Folio is not null and TP.Tipo = 1 and TP.TipoFase <> 0 -- and TP.DiaClave = '28/05/2010'
	and TP.DiaClave = replicate('0', 2 - len( DAY(V.Fecha) ) ) + cast( DAY(V.Fecha) as varchar(2)) + '/' + 
		replicate('0', 2 - len( month(V.Fecha) ) ) + cast( month(V.Fecha) as varchar(2)) + '/' + cast( year(V.Fecha) as varchar(4))
	and TP.MUsuarioID = cast( Surtidos.IdCedis as varchar(10) ) + replicate('0', 4 - len( Surtidos.IdRuta ) ) + cast( Surtidos.IdRuta as varchar(10) )
	and TP.CFVTipo = V.IdTipoVenta and cast(substring(TP.Folio,2,4) as int) = Surtidos.IdRuta  
where V.Fecha between '20100528' and '20100604' -- and V.Subtotal - TP.Subtotal not between -1 and 1 
order by V.Folio 

--select *
--from Ventas 
--inner join VentasDetalle on Ventas.IdCedis = VentasDetalle.IdCedis and Ventas.IdSurtido = VentasDetalle.IdSurtido
--	and Ventas.IdTipoVenta = VentasDetalle.IdTipoVenta and Ventas.Folio = VentasDetalle.Folio 
--where Ventas.Serie = 'EBAX' and Ventas.Folio = 80 and Fecha = '20100528'
--order by Fecha 

--select * 
--from VentasDetalle 
--where IdSurtido = 1 and Folio = 80

--select TP.Folio, TP.Subtotal, tp.Impuesto, TP.Total 
--from  Route.dbo.TransProd TP 
--where TP.Folio is not null and TP.Tipo = 1 and TP.DiaClave = '28/05/2010' and TP.MUsuarioID = '10001' -- and TP.TipoFase = 2
--	and TP.Folio = '10001-00080'
--order by cast(right(TP.Folio,4) as int) 

--select V.*
--from  Ventas V
--where V.Fecha = '20100601' 
--	and V.IdSurtido in (select IdSurtido from Surtidos where Fecha = '20100601' and IdRuta = 1)
--order by Folio 

--select distinct Fecha, replicate('0', 2 - len( DAY(Fecha) ) ) + cast( DAY(Fecha) as varchar(2)) + '/' + 
--	replicate('0', 2 - len( month(Fecha) ) ) + cast( month(Fecha) as varchar(2)) + '/' + cast( year(Fecha) as varchar(4))
--from Ventas 

