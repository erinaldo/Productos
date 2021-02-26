
--Gsp_NivelReporte 3,10,'2','12/12/2010','12/18/2010', '', ''

declare @IdCedi as varchar(3),
@FechaInicial as datetime,
@FechaFinal as datetime

set @IdCedi = 2 
set @FechaInicial = '20101212'
set @FechaFinal = '20101218'


select top 1 VS.SaldoActual, isnull(SUM(VSFD.Monto),0), isnull(VSV.Creditos,0) 
from VendedoresSaldos VS
left outer join VendedoresSaldosValida VSV on VS.IdCedis = VSV.IdCedis and VS.IdSurtido = VSV.IdSurtido and VS.IdVendedor = VSV.IdVendedor 
left outer join VendedoresSaldosFinanciaD VSFD on VSFD.IdCedis = VS.IdCedis and VS.IdVendedor = VSFD.IdVendedor and VSFD.Fecha > VS.Fecha  
where VS.IdCedis = @IdCedi and VS.IdVendedor = 150 and VS.Fecha between  @FechaInicial  and  @FechaFinal  		
group by VS.IdVendedor, VS.SaldoActual, VSV.Creditos, VS.Fecha, VS.IdSurtido 
having abs(VS.SaldoActual) > (isnull(SUM(VSFD.Monto),0) + isnull(VSV.Creditos,0))
order by VS.Fecha desc, VS.IdSurtido

			select  @FechaFinal  as Fecha, IdVendedor, Nomina, Vendedor, SUM(VentaTotal) as VentaTotal, SUM(Pago) as Comision, SUM(AbonoMerma) as AbonoMerma, SUM(AbonoVolumen) as AbonoVolumen, SUM(CargoMerma) as CargoMerma,
					ISNULL((select top 1 VS.SaldoActual + isnull(SUM(VSFD.Monto),0) + isnull(VSV.Creditos,0) 
						from VendedoresSaldos VS
						left outer join VendedoresSaldosValida VSV on VS.IdCedis = VSV.IdCedis and VS.IdSurtido = VSV.IdSurtido and VS.IdVendedor = VSV.IdVendedor 
						left outer join VendedoresSaldosFinanciaD VSFD on VSFD.IdCedis = VS.IdCedis and VS.IdVendedor = VSFD.IdVendedor and VSFD.Fecha > VS.Fecha  
						where VS.IdCedis = @IdCedi and VS.IdVendedor = FN_ComisionesDetalleFecha.IdVendedor and VS.Fecha between  @FechaInicial  and  @FechaFinal  		
						group by VS.IdVendedor, VS.SaldoActual, VSV.Creditos, VS.Fecha, VS.IdSurtido 
						having VS.SaldoActual + isnull(SUM(VSFD.Monto),0) + isnull(VSV.Creditos,0) < 0
						order by VS.Fecha desc, VS.IdSurtido),0) as SaldoVendedor,
					SUM(Pago) + SUM(AbonoMerma) + SUM(AbonoVolumen) - SUM(CargoMerma) + 
					ISNULL((select top 1 VS.SaldoActual + isnull(SUM(VSFD.Monto),0) + isnull(VSV.Creditos,0) 
						from VendedoresSaldos VS
						left outer join VendedoresSaldosValida VSV on VS.IdCedis = VSV.IdCedis and VS.IdSurtido = VSV.IdSurtido and VS.IdVendedor = VSV.IdVendedor 
						left outer join VendedoresSaldosFinanciaD VSFD on VSFD.IdCedis = VS.IdCedis and VS.IdVendedor = VSFD.IdVendedor and VSFD.Fecha > VS.Fecha  
						where VS.IdCedis = @IdCedi and VS.IdVendedor = FN_ComisionesDetalleFecha.IdVendedor and VS.Fecha between  @FechaInicial  and  @FechaFinal  		
						group by VS.IdVendedor, VS.SaldoActual, VSV.Creditos, VS.Fecha, VS.IdSurtido 
						having VS.SaldoActual + isnull(SUM(VSFD.Monto),0) + isnull(VSV.Creditos,0) < 0
						order by VS.Fecha desc, VS.IdSurtido desc),0) as TotalPago,
					ISNULL((select top 1 VS.SaldoActual 
						from VendedoresSaldos VS
						where VS.IdCedis = @IdCedi and VS.IdVendedor = FN_ComisionesDetalleFecha.IdVendedor and VS.Fecha between  @FechaInicial  and  @FechaFinal  		
						order by VS.Fecha desc, VS.IdSurtido desc),0) AS Saldo, 
					ISNULL((select top 1 isnull(SUM(VSFD.Monto),0) 
						from VendedoresSaldos VS
						left outer join VendedoresSaldosValida VSV on VS.IdCedis = VSV.IdCedis and VS.IdSurtido = VSV.IdSurtido and VS.IdVendedor = VSV.IdVendedor 
						left outer join VendedoresSaldosFinanciaD VSFD on VSFD.IdCedis = VS.IdCedis and VS.IdVendedor = VSFD.IdVendedor and VSFD.Fecha > VS.Fecha  
						where VS.IdCedis = @IdCedi and VS.IdVendedor = FN_ComisionesDetalleFecha.IdVendedor and VS.Fecha between  @FechaInicial  and  @FechaFinal  		
						group by VS.IdVendedor, VS.SaldoActual, VSV.Creditos, VS.Fecha, VS.IdSurtido 
						order by VS.Fecha desc, VS.IdSurtido desc),0) AS Financiamientos, 
					ISNULL((select top 1 isnull(VSV.Creditos,0) 
						from VendedoresSaldos VS
						left outer join VendedoresSaldosValida VSV on VS.IdCedis = VSV.IdCedis and VS.IdSurtido = VSV.IdSurtido and VS.IdVendedor = VSV.IdVendedor 
						left outer join VendedoresSaldosFinanciaD VSFD on VSFD.IdCedis = VS.IdCedis and VS.IdVendedor = VSFD.IdVendedor and VSFD.Fecha > VS.Fecha  
						where VS.IdCedis = @IdCedi and VS.IdVendedor = FN_ComisionesDetalleFecha.IdVendedor and VS.Fecha between  @FechaInicial  and  @FechaFinal  		
						group by VS.IdVendedor, VS.SaldoActual, VSV.Creditos, VS.Fecha, VS.IdSurtido 
						order by VS.Fecha desc, VS.IdSurtido desc),0) AS CreditosInformales
				from FN_ComisionesDetalleFecha(@IdCedi,  @FechaInicial ,  @FechaFinal ) 
				where IdVendedor <> 0 and IdVendedor = 150
				group by IdVendedor, Nomina, Vendedor
				order by Vendedor 
