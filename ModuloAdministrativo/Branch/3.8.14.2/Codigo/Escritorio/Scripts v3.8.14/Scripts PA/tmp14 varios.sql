
	select VendedoresSaldos.IdCedis, VendedoresSaldos.IdVendedor, ApPaterno + ' ' + ApMaterno + ' ' + Nombre as Nombre, VendedoresSaldos.Fecha, VendedoresSaldos.IdTipoSaldo, case VendedoresSaldos.IdTipoSaldo 
		when 'EF' then 'Saldo del Vendedor'
		when 'CL' then 'Saldo de Clientes'
		when 'EN' then 'Saldo de Envase'
	end as 'Concepto', SaldoAnterior as 'SaldoAnterior', Saldo as 'SaldoActual', Otros, SaldoActual as 'SaldoFinal',
	VendedoresCargosAbonos.Importe, VendedoresCargosAbonos.Observaciones
	from VendedoresSaldos
	inner join Configuracion as CV on CV.IdCedis = VendedoresSaldos.IdCedis and CV.LiquidacionSaldoVendedor = 'S'
	inner join Vendedores on Vendedores.IdCedis = VendedoresSaldos.IdCedis and Vendedores.IdVendedor = VendedoresSaldos.IdVendedor 
	inner join VendedoresCargosAbonos on VendedoresCargosAbonos.IdCedis = VendedoresSaldos.IdCedis and VendedoresSaldos.IdVendedor = VendedoresCargosAbonos.IdVendedor 
		and VendedoresCargosAbonos.Fecha = VendedoresSaldos.Fecha and VendedoresSaldos.IdTipoSaldo = VendedoresCargosAbonos.IdTipoSaldo
--	where VendedoresSaldos.IdCedis = @IdCedis and VendedoresSaldos.IdVendedor = @IdVendedor and VendedoresSaldos.Fecha = @Fecha and VendedoresSaldos.IdTipoSaldo = @IdTipoSaldo
	where VendedoresSaldos.IdCedis = 1 and VendedoresSaldos.IdVendedor = 31 and VendedoresSaldos.Fecha = '20100423' and VendedoresSaldos.IdTipoSaldo = 'EF'
	order by VendedoresSaldos.Fecha desc


select * -- IdCargoAbono, Fecha, Importe, Observaciones
from VendedoresCargosAbonos

select *
-- delete 
from vendedoresSaldos 
where idvendedor = 31 and fecha = '20100426'
-- fecha = '20100426'
order by fecha desc
