USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[sel_VendedoresSaldos2]    Script Date: 12/06/2010 10:46:02 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sel_VendedoresSaldos2]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sel_VendedoresSaldos2]
GO

USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[sel_VendedoresSaldos2]    Script Date: 12/06/2010 10:46:02 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[sel_VendedoresSaldos2]
@IdCedis as bigint,
@IdVendedor as bigint,
@Fecha as datetime,
@IdTipoSaldo as varchar(5),
@Opc as int
AS

if @Opc = 1
begin

	select TOP 1 VendedoresSaldos.IdCedis, VendedoresSaldos.IdVendedor, Fecha, VendedoresSaldos.IdTipoSaldo, case VendedoresSaldos.IdTipoSaldo 
		when 'EF' then 'Saldo del Vendedor'
		when 'CL' then 'Saldo de Clientes'
		when 'EN' then 'Saldo de Envase'
	end as 'Concepto', SaldoAnterior as 'SaldoAnterior', Saldo as 'SaldoActual', Otros as 'Otros Cargos y/o Abonos', SaldoActual as 'SaldoFinal', VendedoresSaldos.IdSurtido 
	from VendedoresSaldos
	inner join Configuracion as CV on CV.IdCedis = VendedoresSaldos.IdCedis and CV.LiquidacionSaldoVendedor = 'S'
	where VendedoresSaldos.IdCedis = @IdCedis and VendedoresSaldos.IdVendedor = @IdVendedor and VendedoresSaldos.IdTipoSaldo = @IdTipoSaldo
	order by Fecha desc

end

if @Opc = 2
begin

	select VendedoresSaldos.IdCedis, VendedoresSaldos.IdVendedor, Fecha, VendedoresSaldos.IdTipoSaldo, case VendedoresSaldos.IdTipoSaldo 
		when 'EF' then 'Saldo del Vendedor'
		when 'CL' then 'Saldo de Clientes'
		when 'EN' then 'Saldo de Envase'
	end as 'Concepto', SaldoAnterior as 'SaldoAnterior', Saldo as 'SaldoActual', Otros as 'Otros Cargos y/o Abonos', SaldoActual as 'SaldoFinal', VendedoresSaldos.IdSurtido 
	from VendedoresSaldos
	inner join Configuracion as CV on CV.IdCedis = VendedoresSaldos.IdCedis and CV.LiquidacionSaldoVendedor = 'S'
	where VendedoresSaldos.IdCedis = @IdCedis and VendedoresSaldos.IdVendedor = @IdVendedor and VendedoresSaldos.Fecha = @Fecha and VendedoresSaldos.IdTipoSaldo = @IdTipoSaldo
	order by Fecha desc

end

if @Opc = 3
begin
	select VendedoresSaldos.IdCedis, VendedoresSaldos.IdVendedor, Fecha, SaldoAnterior as 'SaldoAnterior', Saldo as 'SaldoActual', Otros as 'Otros Cargos y/o Abonos', SaldoActual as 'SaldoFinal', VendedoresSaldos.IdSurtido 
	from VendedoresSaldos
	inner join Configuracion as CV on CV.IdCedis = VendedoresSaldos.IdCedis and CV.LiquidacionSaldoVendedor = 'S'
	where VendedoresSaldos.IdCedis = @IdCedis and VendedoresSaldos.IdVendedor = @IdVendedor and VendedoresSaldos.IdTipoSaldo = @IdTipoSaldo
	order by Fecha desc

end

if @Opc = 4
begin
	select IdCargoAbono, Fecha, Importe, Observaciones, IdSurtido 
	from VendedoresCargosAbonos
	where IdCedis = @IdCedis and IdVendedor = @IdVendedor and Fecha = @Fecha and IdTipoSaldo = @IdTipoSaldo
end

if @Opc = 5 
begin
	select VendedoresSaldos.IdCedis, VendedoresSaldos.IdVendedor, ApPaterno + ' ' + ApMaterno + ' ' + Nombre as Nombre, VendedoresSaldos.Fecha, VendedoresSaldos.IdTipoSaldo, case VendedoresSaldos.IdTipoSaldo 
		when 'EF' then 'Saldo del Vendedor'
		when 'CL' then 'Saldo de Clientes'
		when 'EN' then 'Saldo de Envase'
	end as 'Concepto', SaldoAnterior as 'SaldoAnterior', Saldo as 'SaldoActual', Otros, SaldoActual as 'SaldoFinal',
	VendedoresCargosAbonos.Importe, VendedoresCargosAbonos.Observaciones
	from VendedoresSaldos
	inner join Configuracion as CV on CV.IdCedis = VendedoresSaldos.IdCedis and CV.LiquidacionSaldoVendedor = 'S'
	inner join Vendedores on Vendedores.IdCedis = VendedoresSaldos.IdCedis and Vendedores.IdVendedor = VendedoresSaldos.IdVendedor 
	inner join VendedoresCargosAbonos on VendedoresCargosAbonos.IdCedis = VendedoresSaldos.IdCedis and VendedoresSaldos.IdVendedor = VendedoresCargosAbonos.IdVendedor 
		and VendedoresCargosAbonos.Fecha = VendedoresSaldos.Fecha and VendedoresSaldos.IdTipoSaldo = VendedoresCargosAbonos.IdTipoSaldo
	where VendedoresSaldos.IdCedis = @IdCedis and VendedoresSaldos.IdVendedor = @IdVendedor and VendedoresSaldos.Fecha = @Fecha and VendedoresSaldos.IdTipoSaldo = @IdTipoSaldo
--	where VendedoresSaldos.IdCedis = 1 and VendedoresSaldos.IdVendedor = 31 and VendedoresSaldos.Fecha = '20100423' and VendedoresSaldos.IdTipoSaldo = 'EF'
	order by VendedoresSaldos.Fecha desc
end



GO


