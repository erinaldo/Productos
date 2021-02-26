
delete 
from VendedoresSaldos
where IdCedis = 1 and IdVendedor = 15 and IdSurtido = 91 and IdTipoSaldo = 'EF'
and Fecha = '20100330'

select VentasDetalle.IdCedis, VentasDetalle.IdSurtido, SurtidosVendedor.IdVendedor, 
isnull((select top 1 SaldoActual
from  VendedoresSaldos 
where IdCedis = 1 and IdVendedor = 15 and IdTipoSaldo = 'EF' and IdSurtido <> 91
order by Fecha desc), 0) as SAnt,
isnull(sum(IdDenominacion * SurtidosDenominacion.Cantidad), 0) - isnull(sum(Total), 0) as SAct,
isnull((select top 1 SaldoActual
from  VendedoresSaldos 
where IdCedis = 1 and IdVendedor = 15 and IdTipoSaldo = 'EF' and IdSurtido <> 91
order by Fecha desc), 0) +
(isnull(sum(IdDenominacion * SurtidosDenominacion.Cantidad), 0) - isnull(sum(Total), 0)) as STot
from VentasDetalle
left outer join SurtidosDenominacion on VentasDetalle.IdCedis = SurtidosDenominacion.IdCedis and VentasDetalle.IdSurtido = SurtidosDenominacion.IdSurtido
inner join SurtidosVendedor on VentasDetalle.IdCedis = SurtidosVendedor.IdCedis and VentasDetalle.IdSurtido = SurtidosVendedor.IdSurtido and SurtidosVendedor.IdVendedor = 15
where VentasDetalle.IdCedis = 1 and VentasDetalle.IdSurtido = 91
and IdTipoVenta = 1
group by VentasDetalle.IdCedis, VentasDetalle.IdSurtido, SurtidosVendedor.IdVendedor

