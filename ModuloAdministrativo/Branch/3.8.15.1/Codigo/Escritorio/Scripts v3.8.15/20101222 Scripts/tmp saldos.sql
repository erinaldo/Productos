declare 
@IdCedis as bigint,
@IdSurtido as bigint,
@IdVendedor as bigint,
@Dias as bigint,
@Fecha as datetime,
@FechaTrabajo as datetime,
@UltimaFecha as datetime

declare @Efectivo as money, @LiquidacionEfectivo as char(1)
declare @SaldoAnterior as money, @VentaContado as money, @Otros as money

set @IdCedis = 2
set @Fecha = '20101204'
set @IdVendedor = 121
set @IdSurtido = 3484

	select top 1 @UltimaFecha = Fecha 
	from VendedoresSaldos 
	where IdCedis = @IdCedis and IdVendedor = @IdVendedor and Fecha < @Fecha 
	order by IdVendedor, Fecha desc

	select @Dias = DATEDIFF(day, @UltimaFecha, @Fecha) 
	select @FechaTrabajo = @UltimaFecha 

	select @Fecha, @UltimaFecha, @Dias 

	while @Dias > 1	
	begin 

		select @FechaTrabajo = @FechaTrabajo + 1
		
		set @SaldoAnterior = 0
		select top 1 @SaldoAnterior = isnull(SaldoActual,0)
		from  VendedoresSaldos 
		where IdCedis = @IdCedis and IdVendedor = @IdVendedor and IdTipoSaldo = 'EF' and IdSurtido <> @IdSurtido and Fecha < @FechaTrabajo 
		order by Fecha desc, IdSurtido desc

		set @Otros = 0
		select @Otros = isnull(sum(Importe),0)
		from VendedoresCargosAbonos 
		where IdCedis = @IdCedis and IdVendedor = @IdVendedor and Fecha = @Fecha and IdTipoSaldo = 'EF' and Fecha = @FechaTrabajo 

		insert into VendedoresSaldos 
		select @IdCedis, 0, 0, 'EF', @IdVendedor, @FechaTrabajo, @SaldoAnterior, 0, @Otros, @SaldoAnterior + @Otros 
		
		set @Dias = @Dias - 1
	end
	
	select * from VendedoresSaldos 
	where IdCedis = @IdCedis and IdVendedor = @IdVendedor and Fecha between @UltimaFecha and @Fecha 
	order by IdVendedor, Fecha 
	-- -102,719.71