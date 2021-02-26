
use RouteADM

select VendedoresSaldos.IdVendedor, VendedoresSaldos.Fecha, VendedoresSaldos.IdSurtido, 
	VendedoresSaldos.SaldoAnterior, VendedoresSaldos.Saldo, VendedoresSaldos.Otros, VendedoresSaldos.SaldoActual,
	isnull(VendedoresCargosAbonos.Fecha,0) Fecha, isnull(SUM(Importe),0) as Importe
from VendedoresSaldos  
left outer join VendedoresCargosAbonos on VendedoresSaldos.IdCedis = VendedoresCargosAbonos.IdCedis and VendedoresSaldos.IdVendedor = VendedoresCargosAbonos.IdVendedor 
	and VendedoresSaldos.Fecha = VendedoresCargosAbonos.Fecha and VendedoresSaldos.IdSurtido = VendedoresCargosAbonos.IdSurtido 
 group by VendedoresSaldos.IdVendedor, VendedoresSaldos.Fecha, VendedoresSaldos.IdSurtido, 
	VendedoresSaldos.SaldoAnterior, VendedoresSaldos.Saldo, VendedoresSaldos.Otros, VendedoresSaldos.SaldoActual,
	VendedoresCargosAbonos.Fecha
order by VendedoresSaldos.IdVendedor, VendedoresSaldos.Fecha desc, VendedoresSaldos.IdSurtido desc


select VendedoresSaldos.IdVendedor, SUM(Otros) OtrosSaldos, isnull((select SUM(Importe) from 
	VendedoresCargosAbonos where VendedoresSaldos.IdCedis = VendedoresCargosAbonos.IdCedis 
		and VendedoresSaldos.IdVendedor = VendedoresCargosAbonos.IdVendedor),0) ImporteCargo
from VendedoresSaldos 
group by VendedoresSaldos.IdCedis, VendedoresSaldos.IdVendedor
order by VendedoresSaldos.IdVendedor
