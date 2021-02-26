
--Gsp_NivelReporte 3,10,'2','12/12/2010','12/18/2010', '', ''

declare @IdCedi as varchar(3),
@FechaInicial as datetime,
@FechaFinal as datetime,
@Fecha as datetime,
@UltimoSaldo as money,
@IdVendedor as varchar(10),
@Nomina as varchar(100),
@Vendedor as varchar(500),
@VentaTotal as money, 
@Comision as money, 
@AbonoMerma as money, 
@AbonoVolumen as money, 
@CargoMerma as money,
@SaldoVendedor as money,
@TotalPago as money, 
@Financiamientos as money, 
@CreditosInformales as money


set @IdCedi = 2 
set @FechaInicial = '20101212'
set @FechaFinal = '20101218'
--set @IdVendedor = 150

--exec Gsp_NivelReporte 3,10,'2','12/12/2010','12/18/2010', ' AND FN_ComisionesDetalleFecha.IdVendedor in (''150'')', ''

delete from tempComisionesDetalle

--create table tempComisionesDetalle(IdCedis bigint, FechaFinal datetime, IdVendedor bigint, Nomina varchar(20), Vendedor varchar(200), 
--VentaTotal money, Comision money, AbonoMerma money, AbonoVolumen money, CargoMerma money,
--SaldoVendedor money, TotalPago money, Saldo money, Financiamientos money, CreditosInformales money)

declare  CursorComisiones cursor for
	select FN_ComisionesDetalleFecha.Fecha, FN_ComisionesDetalleFecha.IdVendedor, Nomina, Vendedor, SUM(VentaTotal) as VentaTotal, SUM(Pago) as Comision, SUM(AbonoMerma) as AbonoMerma, SUM(AbonoVolumen) as AbonoVolumen, SUM(CargoMerma) as CargoMerma
	from FN_ComisionesDetalleFecha(@IdCedi, @FechaInicial, @FechaFinal) 
	where FN_ComisionesDetalleFecha.IdVendedor <> 0 -- and FN_ComisionesDetalleFecha.IdVendedor = @IdVendedor 
	group by FN_ComisionesDetalleFecha.Fecha, FN_ComisionesDetalleFecha.IdVendedor, Nomina, Vendedor
	order by IdVendedor, FN_ComisionesDetalleFecha.Fecha 
open CursorComisiones

fetch next from CursorComisiones into @Fecha, @IdVendedor, @Nomina, @Vendedor, @VentaTotal, @Comision, @AbonoMerma, @AbonoVolumen, @CargoMerma

while (@@fetch_status = 0)
begin

	select top 1 @UltimoSaldo = isnull(VS.SaldoActual,0)
	from VendedoresSaldos VS
	where VS.IdCedis = @IdCedi and VS.IdVendedor = @IdVendedor and VS.Fecha = @Fecha  		
	order by VS.Fecha desc, VS.IdSurtido desc 

	select top 1 @Financiamientos = isnull(SUM(VSFD.Monto),0) 
		from VendedoresSaldos VS
		left outer join VendedoresSaldosValida VSV on VS.IdCedis = VSV.IdCedis and VS.IdSurtido = VSV.IdSurtido and VS.IdVendedor = VSV.IdVendedor 
		left outer join VendedoresSaldosFinanciaD VSFD on VSFD.IdCedis = VS.IdCedis and VS.IdVendedor = VSFD.IdVendedor and VSFD.Fecha > VS.Fecha  
		where VS.IdCedis = @IdCedi and VS.IdVendedor = @IdVendedor and VS.Fecha = @Fecha  		
		group by VS.IdVendedor, VS.SaldoActual, VSV.Creditos, VS.Fecha, VS.IdSurtido 
		order by VS.Fecha desc, VS.IdSurtido desc

	select top 1 @CreditosInformales = isnull(VSV.Creditos,0) 
		from VendedoresSaldos VS
		left outer join VendedoresSaldosValida VSV on VS.IdCedis = VSV.IdCedis and VS.IdSurtido = VSV.IdSurtido and VS.IdVendedor = VSV.IdVendedor 
		left outer join VendedoresSaldosFinanciaD VSFD on VSFD.IdCedis = VS.IdCedis and VS.IdVendedor = VSFD.IdVendedor and VSFD.Fecha > VS.Fecha  
		where VS.IdCedis = @IdCedi and VS.IdVendedor = @IdVendedor and VS.Fecha = @Fecha  		
		group by VS.IdVendedor, VS.SaldoActual, VSV.Creditos, VS.Fecha, VS.IdSurtido 
		order by VS.Fecha desc, VS.IdSurtido desc

	select @SaldoVendedor = 0
	
	select @TotalPago = @Comision + @AbonoMerma + @AbonoVolumen - @CargoMerma 
	
	insert into tempComisionesDetalle 
	select @IdCedi, @Fecha, @IdVendedor, @Nomina, @Vendedor, @VentaTotal, @Comision, @AbonoMerma, @AbonoVolumen, @CargoMerma, @SaldoVendedor, @TotalPago, 
	@UltimoSaldo, @Financiamientos, @CreditosInformales 
	
	fetch next from CursorComisiones into @Fecha, @IdVendedor, @Nomina, @Vendedor, @VentaTotal, @Comision, @AbonoMerma, @AbonoVolumen, @CargoMerma
end
close CursorComisiones
deallocate CursorComisiones	

declare  CursorComisiones cursor for
	select distinct IdVendedor
	from tempComisionesDetalle
	where IdCedis = @IdCedi 
	order by IdVendedor
open CursorComisiones

fetch next from CursorComisiones into @IdVendedor

while (@@fetch_status = 0)
begin

	select top 1 @Fecha = FechaFinal 
	from tempComisionesDetalle 
	where IdCedis = @IdCedi and IdVendedor = @IdVendedor 
	order by FechaFinal desc
	
	select top 1 @UltimoSaldo = isnull(VS.SaldoActual,0)
	from VendedoresSaldos VS
	where VS.IdCedis = @IdCedi and VS.IdVendedor = @IdVendedor and VS.Fecha = @Fecha  		
	order by VS.Fecha desc, VS.IdSurtido desc 

	select top 1 @Financiamientos = isnull(SUM(VSFD.Monto),0) 
		from VendedoresSaldos VS
		left outer join VendedoresSaldosValida VSV on VS.IdCedis = VSV.IdCedis and VS.IdSurtido = VSV.IdSurtido and VS.IdVendedor = VSV.IdVendedor 
		left outer join VendedoresSaldosFinanciaD VSFD on VSFD.IdCedis = VS.IdCedis and VS.IdVendedor = VSFD.IdVendedor and VSFD.Fecha > VS.Fecha  
		where VS.IdCedis = @IdCedi and VS.IdVendedor = @IdVendedor and VS.Fecha = @Fecha  		
		group by VS.IdVendedor, VS.SaldoActual, VSV.Creditos, VS.Fecha, VS.IdSurtido 
		order by VS.Fecha desc, VS.IdSurtido desc

	select top 1 @CreditosInformales = isnull(VSV.Creditos,0) 
		from VendedoresSaldos VS
		left outer join VendedoresSaldosValida VSV on VS.IdCedis = VSV.IdCedis and VS.IdSurtido = VSV.IdSurtido and VS.IdVendedor = VSV.IdVendedor 
		left outer join VendedoresSaldosFinanciaD VSFD on VSFD.IdCedis = VS.IdCedis and VS.IdVendedor = VSFD.IdVendedor and VSFD.Fecha > VS.Fecha  
		where VS.IdCedis = @IdCedi and VS.IdVendedor = @IdVendedor and VS.Fecha = @Fecha  		
		group by VS.IdVendedor, VS.SaldoActual, VSV.Creditos, VS.Fecha, VS.IdSurtido 
		order by VS.Fecha desc, VS.IdSurtido desc

	select @SaldoVendedor = @UltimoSaldo + @Financiamientos + @CreditosInformales 
	
	if @SaldoVendedor > 0 set @SaldoVendedor = 0		

	update tempComisionesDetalle set SaldoVendedor = @SaldoVendedor,  Saldo = @UltimoSaldo, TotalPago = Comision + AbonoMerma + AbonoVolumen - CargoMerma + @SaldoVendedor 
	where IdCedis = @IdCedi and IdVendedor = @IdVendedor and FechaFinal = @Fecha 
	
	fetch next from CursorComisiones into @IdVendedor
end
close CursorComisiones
deallocate CursorComisiones		



