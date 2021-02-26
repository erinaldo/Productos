
declare

@IdCedis as bigint,
@IdCargoAbono as bigint,
@IdVendedor as varchar(10),
@Fecha as datetime,
@IdTipoSaldos as varchar(5),
@Importe as money,
@Observaciones as varchar(200),
@IdSurtido as bigint,
@Opc as int
-- AS

set @IdCedis = 2
set @IdCargoAbono = 128
set @IdVendedor = 2902
set @Fecha = '20101223'
set @IdTipoSaldos = 'EF'
set @Opc = 1

declare 
@Dias as bigint,
@FechaTrabajo as datetime,
@UltimaFecha as datetime,
@SaldoAnterior as money,
@Otros as money

if @Opc = 1
begin

	select top 1 @UltimaFecha = Fecha 
	from VendedoresSaldos 
	where IdCedis = @IdCedis and IdVendedor = @IdVendedor and Fecha < @Fecha and IdTipoSaldo = 'EF' 
	order by IdVendedor, Fecha desc

	select @Dias = DATEDIFF(day, @UltimaFecha, @Fecha) 
	select @FechaTrabajo = @UltimaFecha 

	while @Dias > 0	
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
		where IdCedis = @IdCedis and IdVendedor = @IdVendedor and Fecha = @FechaTrabajo and IdTipoSaldo = 'EF' 

		insert into VendedoresSaldos 
		select @IdCedis, 0, 0, 'EF', @IdVendedor, @FechaTrabajo, @SaldoAnterior, 0, @Otros, @SaldoAnterior + @Otros 
		
		set @Dias = @Dias - 1
	end
end

