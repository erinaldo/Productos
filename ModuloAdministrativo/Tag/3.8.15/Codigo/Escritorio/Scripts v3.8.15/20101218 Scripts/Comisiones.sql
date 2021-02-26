
select '20101218' as Fecha, IdVendedor, Nomina, Vendedor, SUM(VentaTotal) as VentaTotal, SUM(Pago) as Comision, SUM(AbonoMerma) as AbonoMerma, SUM(AbonoVolumen) as AbonoVolumen, SUM(CargoMerma) as CargoMerma,
	ISNULL((select top 1 VS.SaldoActual + isnull(SUM(VSFD.Monto),0) + isnull(VSV.Creditos,0) 
		from VendedoresSaldos VS
		left outer join VendedoresSaldosValida VSV on VS.IdCedis = VSV.IdCedis and VS.IdSurtido = VSV.IdSurtido and VS.IdVendedor = VSV.IdVendedor 
		left outer join VendedoresSaldosFinanciaD VSFD on VSFD.IdCedis = VS.IdCedis and VS.IdVendedor = VSFD.IdVendedor and VSFD.Fecha > VS.Fecha  
		where VS.IdCedis = 2 and VS.IdVendedor = FN_ComisionesDetalleFecha.IdVendedor and VS.Fecha between '20101213' and '20101218' 		
		group by VS.IdVendedor, VS.SaldoActual, VSV.Creditos, VS.Fecha 
		having VS.SaldoActual + isnull(SUM(VSFD.Monto),0) + isnull(VSV.Creditos,0) < 0
		order by VS.Fecha desc),0) as SaldoVendedor,
	SUM(Pago) + SUM(AbonoMerma) + SUM(AbonoVolumen) - SUM(CargoMerma) + 
	ISNULL((select top 1 isnull(SUM(VSFD.Monto),0) 
		from VendedoresSaldos VS
		left outer join VendedoresSaldosValida VSV on VS.IdCedis = VSV.IdCedis and VS.IdSurtido = VSV.IdSurtido and VS.IdVendedor = VSV.IdVendedor 
		left outer join VendedoresSaldosFinanciaD VSFD on VSFD.IdCedis = VS.IdCedis and VS.IdVendedor = VSFD.IdVendedor and VSFD.Fecha > VS.Fecha  
		where VS.IdCedis = 2 and VS.IdVendedor = FN_ComisionesDetalleFecha.IdVendedor and VS.Fecha between '20101213' and '20101218' 		
		group by VS.IdVendedor, VS.SaldoActual, VSV.Creditos, VS.Fecha 
		order by VS.Fecha desc),0) AS Financiamientos, 
	ISNULL((select top 1 isnull(VSV.Creditos,0) 
		from VendedoresSaldos VS
		left outer join VendedoresSaldosValida VSV on VS.IdCedis = VSV.IdCedis and VS.IdSurtido = VSV.IdSurtido and VS.IdVendedor = VSV.IdVendedor 
		left outer join VendedoresSaldosFinanciaD VSFD on VSFD.IdCedis = VS.IdCedis and VS.IdVendedor = VSFD.IdVendedor and VSFD.Fecha > VS.Fecha  
		where VS.IdCedis = 2 and VS.IdVendedor = FN_ComisionesDetalleFecha.IdVendedor and VS.Fecha between '20101213' and '20101218' 		
		group by VS.IdVendedor, VS.SaldoActual, VSV.Creditos, VS.Fecha 
		order by VS.Fecha desc),0) AS CreditosInformales
from FN_ComisionesDetalleFecha(2, '20101213', '20101218') 
group by FN_ComisionesDetalleFecha.IdVendedor, Nomina, Vendedor
order by Vendedor 


	--ISNULL((select top 1 VS.SaldoActual + isnull(SUM(VSFD.Monto),0) + isnull(VSV.Creditos,0) 
	--	from VendedoresSaldos VS
	--	left outer join VendedoresSaldosValida VSV on VS.IdCedis = VSV.IdCedis and VS.IdSurtido = VSV.IdSurtido and VS.IdVendedor = VSV.IdVendedor 
	--	left outer join VendedoresSaldosFinanciaD VSFD on VSFD.IdCedis = VS.IdCedis and VS.IdVendedor = VSFD.IdVendedor and VSFD.Fecha > VS.Fecha  
	--	where VS.IdCedis = 2 and VS.IdVendedor = FN_ComisionesDetalleFecha.IdVendedor and VS.Fecha between '20101213' and '20101218' 		
	--	group by VS.IdVendedor, VS.SaldoActual, VSV.Creditos, VS.Fecha 
	--	having VS.SaldoActual + isnull(SUM(VSFD.Monto),0) + isnull(VSV.Creditos,0) < 0
	--	order by VS.Fecha desc),0) as TotalPago,


SELECT SUM(MONTO)
FROM VendedoresSaldosFinancia
INNER JOIN VendedoresSaldosFinanciaD ON VendedoresSaldosFinancia.IdCedis = VendedoresSaldosFinanciaD.IdCedis AND VendedoresSaldosFinancia.IdCorto =  VendedoresSaldosFinanciaD.IdCorto 
WHERE VendedoresSaldosFinancia.IdVendedor = 150 AND VendedoresSaldosFinancia.Status = 'A'
AND VendedoresSaldosFinanciaD.Fecha > '20101218'
