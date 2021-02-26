USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[sel_VendedoresSaldosFinancia]    Script Date: 01/14/2011 09:35:16 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sel_VendedoresSaldosFinancia]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sel_VendedoresSaldosFinancia]
GO

USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[sel_VendedoresSaldosFinancia]    Script Date: 01/14/2011 09:35:16 ******/
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
	select VSF.IdCedis, 0 as IdSurtido, VSF.Fecha, VSF.IdVendedor, 
		VSF.IdCorto, VSF.FechaElaboracion, VSF.Concepto, 
		abs((select top 1 SaldoActual 
			from VendedoresSaldos 
			where IdCedis = VSF.IdCedis and IdVendedor = VSF.IdVendedor and IdTipoSaldo = 'EF' --and Fecha <= VSF.Fecha 
			order by Fecha desc, IdSurtido desc)) as SaldoActual, 
		isnull((select SUM(VSFD1.Monto) 
			from VendedoresSaldosFinancia VSF1
			inner join VendedoresSaldosFinanciaD VSFD1 on VSF1.IdCedis = VSFD1.IdCedis and VSF1.IdCorto = VSFD1.IdCorto
			where VSF1.IdCedis = VSF.IdCedis and VSF1.IdVendedor = VSF.IdVendedor and VSFD1.Fecha > VSF.Fecha and VSF1.Status = 'A'),0) as NoVencido,
		
		abs((select top 1 SaldoActual 
			from VendedoresSaldos 
			where IdCedis = VSF.IdCedis and IdVendedor = VSF.IdVendedor and IdTipoSaldo = 'EF' --and Fecha <= VSF.Fecha 
			order by Fecha desc, IdSurtido desc)) -
		isnull((select SUM(VSFD1.Monto) 
			from VendedoresSaldosFinancia VSF1
			inner join VendedoresSaldosFinanciaD VSFD1 on VSF1.IdCedis = VSFD1.IdCedis and VSF1.IdCorto = VSFD1.IdCorto
			where VSF1.IdCedis = VSF.IdCedis and VSF1.IdVendedor = VSF.IdVendedor and VSFD1.Fecha > VSF.Fecha and VSF1.Status = 'A'),0) as Saldo,
		VSF.MontoFinanciar, VSF.Pagos, VSF.Frecuencia, VSF.FechaInicio, VSF.Autoriza
	from VendedoresSaldosFinancia VSF 
	where VSF.IdCedis = @IdCedis and VSF.IdVendedor = @IdVendedor and Status = 'A' 
	order by VSF.Fecha desc
end
	
if @Opc = 2
begin
	set @IdSurtido = @IdCorto 

	select IdCedis, IdSurtido, IdVendedor, Saldo, Financiado, SaldoVencido, Creditos, Bolsa, Ajuste, Resultado, Observaciones, Login
	from VendedoresSaldosValida	
	where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdTipoSaldo = 'EF' and IdVendedor = @IdVendedor 
end

if @Opc = 3
begin
	select VSF.IdCedis, VSF.Fecha, VSF.IdVendedor, VEN.ApPaterno + ' ' + VEN.ApMaterno + ' ' + VEN.Nombre As Nombre,
		VSF.IdCorto, VSF.Fecha, VSF.Concepto, VSF.MontoFinanciar, 
		VSF.Pagos, VSF.Frecuencia, VSF.FechaInicio, VSF.Autoriza, 
		VSFD.IdPago, VSFD.Fecha as FechaPago, VSFD.Monto
	from VendedoresSaldosFinancia VSF 
	inner join Vendedores VEN on VEN.IdCedis = VSF.IdCedis and VEN.IdVendedor = VSF.IdVendedor 
	inner join VendedoresSaldosFinanciaD VSFD on VSFD.IdCedis = VSF.IdCedis and VSFD.IdCorto = VSF.IdCorto 
	where VSF.IdCedis = @IdCedis and VSF.IdVendedor = @IdVendedor and VSFD.IdCorto = @IdCorto and VSF.Status = 'A' 
	order by VSFD.IdPago
end

if @Opc = 4
begin
	set @IdSurtido = @IdCorto 

	select VS.IdCedis, IdSurtido, VS.IdVendedor, VEN.ApPaterno + ' ' + VEN.ApMaterno + ' ' + VEN.Nombre As Nombre,
	Saldo, Financiado, SaldoVencido, Creditos, Bolsa, Ajuste, Resultado, Observaciones, Login
	from VendedoresSaldosValida	VS
	inner join Vendedores VEN on VEN.IdCedis = VS.IdCedis and VEN.IdVendedor = VS.IdVendedor 
	where VS.IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdTipoSaldo = 'EF' and VS.IdVendedor = @IdVendedor 

end

if @Opc = 5
begin
	set @IdSurtido = @IdCorto 

	select VS.IdCedis, VEN.IdSurtido
	from Ventas VEN 
	inner join VendedoresSaldos VS on VS.IdCedis = VEN.IdCedis and VS.IdSurtido = VEN.IdSurtido 
	where VEN.IdCedis = @IdCedis and VEN.IdSurtido = @IdSurtido 
end

if @Opc = 6
begin
	select top 1 VS.SaldoActual
	from VendedoresSaldos VS 
	where VS.IdCedis = @IdCedis and VS.IdVendedor = @IdVendedor and IdTipoSaldo = 'EF'
	order by Fecha desc, IdSurtido desc  
end

GO


