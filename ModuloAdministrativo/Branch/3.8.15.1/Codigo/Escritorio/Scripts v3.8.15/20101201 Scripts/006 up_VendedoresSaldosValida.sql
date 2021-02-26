USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[up_VendedoresSaldosValida]    Script Date: 12/02/2010 12:28:12 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[up_VendedoresSaldosValida]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[up_VendedoresSaldosValida]
GO

USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[up_VendedoresSaldosValida]    Script Date: 12/02/2010 12:28:12 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




CREATE PROCEDURE [dbo].[up_VendedoresSaldosValida] 
@IdCedis as bigint,
@IdSurtido as bigint,
@IdVendedor as bigint,
@Fecha as datetime,
@Creditos as money,
@Bolsa as money,
@Ajuste as money,
@Resultado as money,
@Observaciones as varchar(500),
@Login as varchar(20),
@Opc as int
AS

declare 
@Saldo as money, 
@Financiado as money, 
@Vencido as money

if @Opc = 1
begin
	
	if exists(select IdVendedor from VendedoresSaldosValida where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdVendedor = @IdVendedor and IdTipoSaldo = 'EF')
		select @Creditos = Creditos, @Bolsa = Bolsa, @Ajuste = Ajuste, @Observaciones = Observaciones 
		from VendedoresSaldosValida 
		where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdVendedor = @IdVendedor and IdTipoSaldo = 'EF'
	else
		select @Creditos = 0, @Bolsa = 0, @Ajuste = 0, @Resultado = 0, @Observaciones = ''
	

	delete from VendedoresSaldosValida 
	where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdVendedor = @IdVendedor and IdTipoSaldo = 'EF'

	insert into VendedoresSaldosValida 
	select VS.IdCedis, VS.IdSurtido, 'EF', VS.IdVendedor, @Fecha, VS.SaldoActual as Saldo, isnull((select SUM(VSFD.Monto)
		from VendedoresSaldosFinanciaD VSFD
		where VSFD.IdCedis = VS.IdCedis and VSFD.IdVendedor = VS.IdVendedor and VSFD.Fecha > VS.Fecha),0) as Financiado,
	VS.SaldoActual + isnull((select SUM(VSFD.Monto)
		from VendedoresSaldosFinanciaD VSFD
		where VSFD.IdCedis = VS.IdCedis and VSFD.IdVendedor = VS.IdVendedor and VSFD.Fecha > VS.Fecha),0) as SaldoVencido,
		@Creditos, @Bolsa, @Ajuste, VS.SaldoActual + isnull((select SUM(VSFD.Monto)
		from VendedoresSaldosFinanciaD VSFD
		where VSFD.IdCedis = VS.IdCedis and VSFD.IdVendedor = VS.IdVendedor and VSFD.Fecha > VS.Fecha),0) + @Creditos + @Bolsa + @Ajuste, @Observaciones, @Login 	
	from VendedoresSaldos VS
	where VS.IdCedis = @IdCedis and VS.IdSurtido = @IdSurtido and VS.IdVendedor = @IdVendedor and VS.IdTipoSaldo = 'EF'

end

if @Opc = 2
begin
	update VendedoresSaldosValida 
		set Creditos = @Creditos, Bolsa = @Bolsa, Ajuste = @Ajuste, 
		Resultado = @Resultado, Observaciones = @Observaciones
	where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdTipoSaldo = 'EF' and IdVendedor = @IdVendedor 
end

if @Opc = 3
begin
	
	select @Saldo = VS.SaldoActual, @Financiado = isnull((select SUM(VSFD.Monto)
		from VendedoresSaldosFinanciaD VSFD
		where VSFD.IdCedis = VS.IdCedis and VSFD.IdVendedor = VS.IdVendedor and VSFD.Fecha > VS.Fecha),0),
	@Vencido =	VS.SaldoActual + isnull((select SUM(VSFD.Monto)
		from VendedoresSaldosFinanciaD VSFD
		where VSFD.IdCedis = VS.IdCedis and VSFD.IdVendedor = VS.IdVendedor and VSFD.Fecha > VS.Fecha),0)
	from VendedoresSaldos VS
	where VS.IdCedis = @IdCedis and VS.IdSurtido = @IdSurtido and VS.IdVendedor = @IdVendedor and VS.IdTipoSaldo = 'EF'
	
	select @Saldo, @Financiado, @Vencido 
	
	update VendedoresSaldosValida set 
		Saldo = @Saldo, Financiado = @Financiado, SaldoVencido = @Vencido
	where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdVendedor = @IdVendedor and IdTipoSaldo = 'EF'

	update VendedoresSaldosValida set 
		Resultado = SaldoVencido + Creditos + Bolsa + Ajuste, Login = @Login
	where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdVendedor = @IdVendedor and IdTipoSaldo = 'EF'
end




GO


