
select cast(VSAct.IdVendedor AS varchar(10)) + ', ' + ApPaterno + ' ' + ApMaterno + ' ' + Nombre as IdVendedor, 
	VSAct.Fecha, VSAct.SaldoAnterior, VSAct.Saldo, VSAct.Otros, VSAct.SaldoActual,
	VSAnt.Fecha, VSAnt.SaldoAnterior, VSAnt.Saldo, VSAnt.Otros, VSAnt.SaldoActual
from RouteADM.dbo.VendedoresSaldos VSAct 
inner join Vendedores on Vendedores.IdCedis = VSAct.IdCedis and Vendedores.IdVendedor = VSAct.IdVendedor 
left outer join RouteADM2.dbo.VendedoresSaldos VSAnt on VSAct.IdCedis = VSAnt.IdCedis and VSAct.IdVendedor = VSAnt.IdVendedor 
	and VSAct.Fecha = VSAnt.Fecha and VSAct.IdSurtido = VSAnt.IdSurtido 
where VSAct.IdVendedor = 3472
order by VSAct.IdVendedor, VSAct.Fecha, VSAct.IdSurtido

--3270, 3465, 3467, 3468, 3470, 3471, 3472

select *
from VendedoresCargosAbonos 
where IdVendedor = 3472 
-- and Importe between 1598 and 1600