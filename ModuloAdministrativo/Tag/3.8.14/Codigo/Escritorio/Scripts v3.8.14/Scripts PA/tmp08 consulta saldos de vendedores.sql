declare @IdCedis as bigint,
	@FechaIni as datetime,
	@FechaFin as datetime

	set @IdCedis = 1
	set @FechaIni = '20100331'
	set @FechaFin = '20100421'


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
where VS.IdCedis = @IdCedis and VS.Fecha between @FechaIni and @FechaFin 
order by V.ApPaterno, V.ApMaterno, V.Nombre, S.Fecha

select VS.IdVendedor, V.ApPaterno + ' ' + V.ApMaterno + ' ' + V.Nombre as Nombre
from VendedoresSaldos as VS
left outer join Surtidos as S on S.IdCedis = VS.IdCedis and S.IdSurtido = VS.IdSurtido
left outer join Vendedores V on V.IdCedis = VS.IdCedis and V.IdVendedor = VS.IdVendedor
where VS.IdCedis = @IdCedis and VS.Fecha between @FechaIni and @FechaFin 
group by VS.IdVendedor, V.ApPaterno, V.ApMaterno, V.Nombre
order by V.ApPaterno, V.ApMaterno, V.Nombre


/*
select *
from surtidos
inner join surtidosvendedor on surtidos.idcedis = surtidosvendedor.idcedis and surtidos.idsurtido = surtidosvendedor.idsurtido 
where idruta = 415 and surtidos.fecha between '20100401' and '20100421'
order by surtidos.fecha 
*/