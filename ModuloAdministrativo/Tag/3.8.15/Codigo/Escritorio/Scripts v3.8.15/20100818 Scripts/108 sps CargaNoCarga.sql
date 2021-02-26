USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[sel_VendedoresSaldosFinancia]    Script Date: 08/18/2010 16:44:38 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sel_VendedoresSaldosFinancia]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sel_VendedoresSaldosFinancia]
GO

/****** Object:  StoredProcedure [dbo].[up_VendedoresSaldosFinancia]    Script Date: 08/18/2010 16:44:38 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[up_VendedoresSaldosFinancia]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[up_VendedoresSaldosFinancia]
GO

/****** Object:  StoredProcedure [dbo].[up_VendedoresSaldosValida]    Script Date: 08/18/2010 16:44:38 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[up_VendedoresSaldosValida]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[up_VendedoresSaldosValida]
GO

USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[sel_VendedoresSaldosFinancia]    Script Date: 08/18/2010 16:44:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sel_VendedoresSaldosFinancia] 
@IdCedis as bigint,
@IdCorto as bigint,
@IdVendedor as bigint,
@Opc as int
AS

declare @IdSurtido as bigint

if @Opc = 1
begin
	select VS.IdCedis, VS.IdSurtido, VS.Fecha, VS.IdVendedor, 
		VSF.IdCorto, VSF.FechaElaboracion, VSF.Concepto, VS.SaldoActual, VSF.MontoFinanciar, 
		VSF.Pagos, VSF.Frecuencia, VSF.FechaInicio, VSF.Autoriza
	from VendedoresSaldos VS 
	inner join VendedoresSaldosFinancia VSF on VSF.IdCedis = VS.IdCedis and VSF.IdSurtido = VS.IdSurtido and VSF.IdVendedor = VS.IdVendedor 
	where VS.IdCedis = @IdCedis and VS.IdVendedor = @IdVendedor and Status = 'A' and VS.IdTipoSaldo = 'EF'
	order by VS.Fecha desc
end
	
if @Opc = 2
begin
	set @IdSurtido = @IdCorto 

	select IdCedis, IdSurtido, IdVendedor, Saldo, Financiado, SaldoVencido, Creditos, Bolsa, Ajuste, Resultado, Observaciones, Login
	from VendedoresSaldosValida	
	where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdTipoSaldo = 'EF' and IdVendedor = @IdVendedor 
end


GO

/****** Object:  StoredProcedure [dbo].[up_VendedoresSaldosFinancia]    Script Date: 08/18/2010 16:44:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[up_VendedoresSaldosFinancia] 
@IdCedis as bigint,
@IdCorto as bigint,
@IdSurtido as bigint,
@IdVendedor as bigint,
@MontoFinanciar as money,
@Pagos as int,
@Frecuencia as int,
@FechaInicio as datetime,
@Autoriza as varchar(250),
@Concepto as varchar(250),
@Opc as int
AS

if @Opc = 1
begin
	select @IdCorto = isnull((max(IdCorto)+ 1), 1)
	from VendedoresSaldosFinancia  
	where IdCedis = @IdCedis 
	
	insert into VendedoresSaldosFinancia 
	values (@IdCedis, @IdCorto, @IdSurtido, @IdVendedor, @MontoFinanciar, @Pagos, @Frecuencia, @FechaInicio, @Autoriza, @Concepto, 'A', getdate())
end

if @Opc = 2
begin
	update VendedoresSaldosFinancia 
		set MontoFinanciar = @MontoFinanciar, Pagos = @Pagos, Frecuencia = @Frecuencia, 
		FechaInicio = @FechaInicio, Autoriza = @Autoriza, Concepto = @Concepto
	where IdCedis = @IdCedis and IdCorto = @IdCorto  
end

if @Opc = 3
begin
	
	update VendedoresSaldosFinancia 
		set Status = 'B'
	where IdCedis = @IdCedis and IdCorto = @IdCorto  

	delete from VendedoresSaldosFinanciaD  
	where IdCedis = @IdCedis and IdCorto = @IdCorto  
end

if @Opc = 4
begin
	delete from VendedoresSaldosFinanciaD  
	where IdCedis = @IdCedis and IdCorto = @IdCorto  
end

if @Opc = 5
begin
	insert into VendedoresSaldosFinanciaD  
	values (@IdCedis, @IdCorto, @IdSurtido, @IdVendedor, @Pagos, @MontoFinanciar, @FechaInicio, 'A')
end

GO

/****** Object:  StoredProcedure [dbo].[up_VendedoresSaldosValida]    Script Date: 08/18/2010 16:44:39 ******/
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
	select VS.IdCedis, VS.IdSurtido, 'EF', VS.IdVendedor, @Fecha, ABS(VS.SaldoActual) as Saldo, isnull((select SUM(VSFD.Monto)
		from VendedoresSaldosFinanciaD VSFD
		where VSFD.IdCedis = VS.IdCedis and VSFD.IdVendedor = VS.IdVendedor and VSFD.Fecha > VS.Fecha),0) as Financiado,
	ABS(VS.SaldoActual) - isnull((select SUM(VSFD.Monto)
		from VendedoresSaldosFinanciaD VSFD
		where VSFD.IdCedis = VS.IdCedis and VSFD.IdVendedor = VS.IdVendedor and VSFD.Fecha > VS.Fecha),0) as SaldoVencido,
		@Creditos, @Bolsa, @Ajuste, ABS(VS.SaldoActual) - isnull((select SUM(VSFD.Monto)
		from VendedoresSaldosFinanciaD VSFD
		where VSFD.IdCedis = VS.IdCedis and VSFD.IdVendedor = VS.IdVendedor and VSFD.Fecha > VS.Fecha),0) - @Creditos - @Bolsa - @Ajuste, @Observaciones, @Login 	
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



GO


