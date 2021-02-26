USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[up_VendedoresSaldosFinancia]    Script Date: 01/14/2011 09:32:01 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[up_VendedoresSaldosFinancia]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[up_VendedoresSaldosFinancia]
GO

USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[up_VendedoresSaldosFinancia]    Script Date: 01/14/2011 09:32:01 ******/
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
@Pagos as money,
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
	values (@IdCedis, @IdCorto, 0, @IdVendedor, @MontoFinanciar, @Pagos, @Frecuencia, @FechaInicio, @Autoriza, @Concepto, 'A', getdate(),
	cast(YEAR(getdate()) as varchar(4)) 
	+ REPLICATE('0', 2- len(MONTH(getdate()))) + cast(MONTH(getdate()) as varchar(2))
	+ REPLICATE('0', 2- len(day(getdate()))) + cast(day(getdate()) as varchar(2)))
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
	values (@IdCedis, @IdCorto, 0, @IdVendedor, @Pagos, @MontoFinanciar, @FechaInicio, 'A')
end


GO


