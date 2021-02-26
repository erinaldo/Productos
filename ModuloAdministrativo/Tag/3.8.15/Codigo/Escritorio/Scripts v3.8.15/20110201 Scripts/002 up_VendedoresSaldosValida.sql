USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[up_VendedoresSaldosValida]    Script Date: 02/01/2011 16:56:35 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[up_VendedoresSaldosValida]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[up_VendedoresSaldosValida]
GO

USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[up_VendedoresSaldosValida]    Script Date: 02/01/2011 16:56:35 ******/
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

	select @Financiado = 0	
	select @Financiado = isnull(SUM(VSFD.Monto),0)
	from VendedoresSaldosFinanciaD VSFD
	where VSFD.IdCedis = @IdCedis and VSFD.IdVendedor =  @IdVendedor and VSFD.Fecha > @Fecha 
	
	insert into VendedoresSaldosValida 
	select VS.IdCedis, VS.IdSurtido, 'EF', VS.IdVendedor, @Fecha, VS.SaldoActual as Saldo, @Financiado as Financiado,
	VS.SaldoActual + @Financiado as SaldoVencido, @Creditos, @Bolsa, @Ajuste, 
	VS.SaldoActual + @Financiado + @Creditos + @Bolsa + @Ajuste, @Observaciones, @Login 	
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
	
	select @Financiado = 0	
	select @Financiado = isnull(SUM(VSFD.Monto),0)
	from VendedoresSaldosFinanciaD VSFD
	where VSFD.IdCedis = @IdCedis and VSFD.IdVendedor =  @IdVendedor and VSFD.Fecha > @Fecha 
	
	select @Saldo = VS.SaldoActual, @Vencido = VS.SaldoActual + @Financiado 
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


