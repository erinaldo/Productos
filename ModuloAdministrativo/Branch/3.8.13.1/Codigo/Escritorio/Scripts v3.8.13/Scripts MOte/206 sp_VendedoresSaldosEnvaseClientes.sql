set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go







CREATE PROCEDURE [dbo].[up_VendedoresSaldosEnvaseClientes] 
@IdCedis as bigint,
@IdSurtido as bigint,
@Opc as int
AS

declare @IdVendedor as bigint
declare @Route as int, @IdRuta as bigint, @Fecha as datetime, @SaldoAnterior as money
set @Route = isnull( ( select Route from Configuracion where IdCedis = @IdCedis ), 0 )

if @Opc = 1
begin
	if @Route = 1
	begin
		if exists(select IdCedis from Configuracion where LiquidacionSaldoClientes = 'S')	
		begin
			select @IdRuta  = IdRuta, @Fecha = Fecha from Surtidos where IdCedis = @IdCedis and IdSurtido = @IdSurtido
			select top 1 @SaldoAnterior = isnull(SaldoActual, 0) 
			from VendedoresSaldos 
			where IdCedis = @IdCedis and IdRuta = @IdRuta and IdTipoSaldo = 'CL'
			order by Fecha desc
			if @SaldoAnterior is null set @SaldoAnterior=0
			
			if not exists(select IdCedis from VendedoresSaldos where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdTipoSaldo = 'CL' )
				insert into VendedoresSaldos 		
				SELECT @IdCedis, @IdSurtido, @IdRuta, 'CL', 0, @Fecha, @SaldoAnterior, sum(TRP.Saldo)*-1, @SaldoAnterior + (sum(TRP.Saldo)*-1)
				FROM Route.dbo.TransProd TRP      
				inner join (select distinct RutClave, ClienteClave from Route.dbo.Secuencia) SEC on TRP.ClienteClave = SEC.ClienteClave 
				inner join Route.dbo.VenRut VRT on SEC.RUTClave = VRT.RUTClave and VRT.TipoEstado = 1 
				where TRP.Tipo in(1,24) AND TRP.TipoFase <> 0 and Saldo > 0 and SEC.RUTClave = 'R' + replicate('0', 2 - len(@Idruta)) + cast(@IdRuta as varchar(10))
				group by VRT.RUTClave, VRT.VendedorID
		end	

		if exists(select IdCedis from Configuracion where LiquidacionSaldoEnvase = 'S')	
		begin
			select @IdRuta  = IdRuta, @Fecha = Fecha from Surtidos where IdCedis = @IdCedis and IdSurtido = @IdSurtido
			select top 1 @SaldoAnterior = isnull(SaldoActual, 0) 
			from VendedoresSaldos 
			where IdCedis = @IdCedis and IdRuta = @IdRuta  and IdTipoSaldo = 'EN'
			order by Fecha desc
			if @SaldoAnterior is null set @SaldoAnterior=0
			
			if not exists(select IdCedis from VendedoresSaldos where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdTipoSaldo = 'EN' )
				insert into VendedoresSaldos 		
				SELECT @IdCedis, @IdSurtido, @IdRuta, 'EN', 0, @Fecha, @SaldoAnterior, SUM(PPC.Saldo)*-1, @SaldoAnterior + (SUM(PPC.Saldo)*-1)
				FROM Route.dbo.ProductoPrestamoCli PPC 
				inner join (select distinct RutClave, ClienteClave from Route.dbo.Secuencia) SEC on PPC.ClienteClave = SEC.ClienteClave 
				inner join Route.dbo.VenRut VRT on SEC.RUTClave = VRT.RUTClave and VRT.TipoEstado = 1 
				where PPC.Saldo <> 0 and SEC.RUTClave = 'R' + replicate('0', 2 - len(@Idruta)) + cast(@IdRuta as varchar(10)) 
				group by SEC.RUTClave, VRT.VendedorID
		end	
	end
end



