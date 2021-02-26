
select *
from VendedoresSaldos
where IdVendedor = 82 
order by Fecha desc, IdSurtido desc

select SUM(monto)
from VendedoresSaldosFinanciaD 
where IdVendedor=82 and Fecha > '20110112'

select top 5 *
from VendedoresSaldosValida 
where IdVendedor = 82 
order by Fecha desc

select top 5 *
from VendedoresSaldosFinancia 
where IdVendedor = 82 
order by IdCorto desc
