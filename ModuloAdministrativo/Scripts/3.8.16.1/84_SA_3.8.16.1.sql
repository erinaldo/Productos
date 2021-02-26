USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[up_ComisionesHistorico]    Script Date: 08/29/2011 08:40:23 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[up_ComisionesHistorico]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[up_ComisionesHistorico]
GO

USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[up_ComisionesHistorico]    Script Date: 08/29/2011 08:40:23 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[up_ComisionesHistorico]
@IdCedis as bigint,
@FechaInicial as datetime,
@FechaFinal as datetime,
@Filtro as varchar(4000),
@Opc as int

AS

	--declare 
	--@Fecha as datetime,
	--@UltimoSaldo as money,
	--@IdVendedor as varchar(10),
	--@Nomina as varchar(100),
	--@Vendedor as varchar(500),
	--@VentaTotal as money, 
	--@Comision as money, 
	--@AbonoMerma as money, 
	--@AbonoVolumen as money, 
	--@CargoMerma as money,
	--@SaldoVendedor as money,
	--@TotalPago as money, 
	--@Financiamientos as money, 
	--@CreditosInformales as money

if @Opc = 1
begin 
	SET DATEFIRST 1
	DECLARE @FechaIni datetime, @FechaFin datetime
	set @FechaIni = DATEADD(day,-DATEPART(dw, @FechaInicial)+1, @FechaInicial)
	set @FechaFin = DATEADD(day,-DATEPART(dw, @FechaInicial )+6, @FechaInicial )
	--Obtener las fechas de la semana de acuerdo a 
	if (LTRIM(RTRIM(@Filtro)) ='')
		exec('delete from ComisionesHistorico 
		where FechaIni = ''' + @FechaIni + ''' and FechaFin = ''' +  @FechaFin + '''')
	ELSE
		exec('delete from ComisionesHistorico 
		where ' + @Filtro + ' and FechaIni = ''' + @FechaIni + ''' and FechaFin = ''' +  @FechaFin + '''')

	insert into ComisionesHistorico 
	exec sel_ComisionesCalculo @IdCedis, @FechaIni, @FechaFin
	
end

--if @Opc = 2
--begin 

--	select RIGHT(newid(),20), @Usuario, GETDATE(), IdCedis, IdSurtido, Fecha, IdComEsquema, Esquema, IdConceptoPago, ConceptoPago, 
--	TipoRuta, IdRuta, IdTipoVendedor, TipoVendedor, IdFamilia, Familia, IdProducto, Producto, Venta, Inicial, Final, 
--	Factor, Pago, AbonoMerma, AbonoVolumen 
--	from FN_ComisionesEsquemaFecha(@IdCedis, @FechaInicial, @FechaFinal )

--end
/*
if @Opc = 3
begin
	delete from tempComisiones

	declare  CursorComisiones cursor for
		select FN_ComisionesDetalleFecha.IdVendedor, Nomina, Vendedor, SUM(VentaTotal) as VentaTotal, SUM(Pago) as Comision, SUM(AbonoMerma) as AbonoMerma, SUM(AbonoVolumen) as AbonoVolumen, SUM(CargoMerma) as CargoMerma
		from FN_ComisionesDetalleFecha(@IdCedis, @FechaInicial, @FechaFinal) 
		where FN_ComisionesDetalleFecha.IdVendedor <> 0 -- and FN_ComisionesDetalleFecha.IdVendedor = @IdVendedor 
		group by FN_ComisionesDetalleFecha.IdVendedor, Nomina, Vendedor
		order by IdVendedor 
	open CursorComisiones

	fetch next from CursorComisiones into @IdVendedor, @Nomina, @Vendedor, @VentaTotal, @Comision, @AbonoMerma, @AbonoVolumen, @CargoMerma

	while (@@fetch_status = 0)
	begin

		select top 1 @UltimoSaldo = isnull(VS.SaldoActual,0)
		from VendedoresSaldos VS
		where VS.IdCedis = @IdCedis and VS.IdVendedor = @IdVendedor and VS.Fecha between  @FechaInicial  and  @FechaFinal  		
		order by VS.Fecha desc, VS.IdSurtido desc 

		select top 1 @Financiamientos = isnull(SUM(VSFD.Monto),0) 
			from VendedoresSaldos VS
			left outer join VendedoresSaldosValida VSV on VS.IdCedis = VSV.IdCedis and VS.IdSurtido = VSV.IdSurtido and VS.IdVendedor = VSV.IdVendedor 
			left outer join VendedoresSaldosFinanciaD VSFD on VSFD.IdCedis = VS.IdCedis and VS.IdVendedor = VSFD.IdVendedor and VSFD.Fecha > @FechaFinal   
			where VS.IdCedis = @IdCedis and VS.IdVendedor = @IdVendedor and VS.Fecha between @FechaInicial and @FechaFinal
			group by VS.IdVendedor, VS.SaldoActual, VSV.Creditos, VS.Fecha, VS.IdSurtido 
			order by VS.Fecha desc, VS.IdSurtido desc

		select top 1 @CreditosInformales = isnull(VSV.Creditos,0) 
			from VendedoresSaldos VS
			left outer join VendedoresSaldosValida VSV on VS.IdCedis = VSV.IdCedis and VS.IdSurtido = VSV.IdSurtido and VS.IdVendedor = VSV.IdVendedor 
			where VS.IdCedis = @IdCedis and VS.IdVendedor = @IdVendedor and VS.Fecha between @FechaInicial and @FechaFinal
			group by VS.IdVendedor, VS.SaldoActual, VSV.Creditos, VS.Fecha, VS.IdSurtido 
			order by VS.Fecha desc, VS.IdSurtido desc

		select @SaldoVendedor = @UltimoSaldo + @Financiamientos + @CreditosInformales 
		
		if @SaldoVendedor > 0 set @SaldoVendedor = 0		

		select @TotalPago = @Comision + @AbonoMerma + @AbonoVolumen - @CargoMerma + @SaldoVendedor 
		
		insert into tempComisiones 
		select @IdCedis, @FechaFinal, @IdVendedor, @Nomina, @Vendedor, @VentaTotal, @Comision, @AbonoMerma, @AbonoVolumen, @CargoMerma, @SaldoVendedor, @TotalPago, 
		@UltimoSaldo, @Financiamientos, @CreditosInformales 
		
		fetch next from CursorComisiones into @IdVendedor, @Nomina, @Vendedor, @VentaTotal, @Comision, @AbonoMerma, @AbonoVolumen, @CargoMerma
	end
	close CursorComisiones
	deallocate CursorComisiones		
end
*/
/*
if @Opc = 4
begin
	
	delete from tempComisionesDetalle

	declare  CursorComisiones cursor for
		select FN_ComisionesDetalleFecha.Fecha, FN_ComisionesDetalleFecha.IdVendedor, Nomina, Vendedor, SUM(VentaTotal) as VentaTotal, SUM(Pago) as Comision, SUM(AbonoMerma) as AbonoMerma, SUM(AbonoVolumen) as AbonoVolumen, SUM(CargoMerma) as CargoMerma
		from FN_ComisionesDetalleFecha(@IdCedis, @FechaInicial, @FechaFinal) 
		where FN_ComisionesDetalleFecha.IdVendedor <> 0 -- and FN_ComisionesDetalleFecha.IdVendedor = @IdVendedor 
		group by FN_ComisionesDetalleFecha.Fecha, FN_ComisionesDetalleFecha.IdVendedor, Nomina, Vendedor
		order by IdVendedor, FN_ComisionesDetalleFecha.Fecha 
	open CursorComisiones

	fetch next from CursorComisiones into @Fecha, @IdVendedor, @Nomina, @Vendedor, @VentaTotal, @Comision, @AbonoMerma, @AbonoVolumen, @CargoMerma

	while (@@fetch_status = 0)
	begin

		select top 1 @UltimoSaldo = isnull(VS.SaldoActual,0)
		from VendedoresSaldos VS
		where VS.IdCedis = @IdCedis and VS.IdVendedor = @IdVendedor and VS.Fecha = @Fecha  		
		order by VS.Fecha desc, VS.IdSurtido desc 

		select top 1 @Financiamientos = isnull(SUM(VSFD.Monto),0) 
			from VendedoresSaldos VS
			left outer join VendedoresSaldosValida VSV on VS.IdCedis = VSV.IdCedis and VS.IdSurtido = VSV.IdSurtido and VS.IdVendedor = VSV.IdVendedor 
			left outer join VendedoresSaldosFinanciaD VSFD on VSFD.IdCedis = VS.IdCedis and VS.IdVendedor = VSFD.IdVendedor and VSFD.Fecha > @FechaFinal   
			where VS.IdCedis = @IdCedis and VS.IdVendedor = @IdVendedor and VS.Fecha = @Fecha  		
			group by VS.IdVendedor, VS.SaldoActual, VSV.Creditos, VS.Fecha, VS.IdSurtido 
			order by VS.Fecha desc, VS.IdSurtido desc

		select top 1 @CreditosInformales = isnull(VSV.Creditos,0) 
			from VendedoresSaldos VS
			left outer join VendedoresSaldosValida VSV on VS.IdCedis = VSV.IdCedis and VS.IdSurtido = VSV.IdSurtido and VS.IdVendedor = VSV.IdVendedor 
			where VS.IdCedis = @IdCedis and VS.IdVendedor = @IdVendedor and VS.Fecha = @Fecha  		
			group by VS.IdVendedor, VS.SaldoActual, VSV.Creditos, VS.Fecha, VS.IdSurtido 
			order by VS.Fecha desc, VS.IdSurtido desc

		select @SaldoVendedor = 0
		
		select @TotalPago = @Comision + @AbonoMerma + @AbonoVolumen - @CargoMerma 
		
		insert into tempComisionesDetalle 
		select @IdCedis, @Fecha, @IdVendedor, @Nomina, @Vendedor, @VentaTotal, @Comision, @AbonoMerma, @AbonoVolumen, @CargoMerma, @SaldoVendedor, @TotalPago, 
		@UltimoSaldo, @Financiamientos, @CreditosInformales 
		
		fetch next from CursorComisiones into @Fecha, @IdVendedor, @Nomina, @Vendedor, @VentaTotal, @Comision, @AbonoMerma, @AbonoVolumen, @CargoMerma
	end
	close CursorComisiones
	deallocate CursorComisiones	

	declare  CursorComisiones cursor for
		select distinct IdVendedor
		from tempComisionesDetalle
		where IdCedis = @IdCedis 
		order by IdVendedor
	open CursorComisiones

	fetch next from CursorComisiones into @IdVendedor

	while (@@fetch_status = 0)
	begin

		select top 1 @Fecha = Fecha  
		from tempComisionesDetalle 
		where IdCedis = @IdCedis and IdVendedor = @IdVendedor 
		order by Fecha desc
		
		select top 1 @UltimoSaldo = isnull(VS.SaldoActual,0)
		from VendedoresSaldos VS
		where VS.IdCedis = @IdCedis and VS.IdVendedor = @IdVendedor and VS.Fecha = @Fecha  		
		order by VS.Fecha desc, VS.IdSurtido desc 

		select top 1 @Financiamientos = isnull(SUM(VSFD.Monto),0) 
			from VendedoresSaldos VS
			left outer join VendedoresSaldosValida VSV on VS.IdCedis = VSV.IdCedis and VS.IdSurtido = VSV.IdSurtido and VS.IdVendedor = VSV.IdVendedor 
			left outer join VendedoresSaldosFinanciaD VSFD on VSFD.IdCedis = VS.IdCedis and VS.IdVendedor = VSFD.IdVendedor and VSFD.Fecha > @FechaFinal 
			where VS.IdCedis = @IdCedis and VS.IdVendedor = @IdVendedor and VS.Fecha = @Fecha  		
			group by VS.IdVendedor, VS.SaldoActual, VSV.Creditos, VS.Fecha, VS.IdSurtido 
			order by VS.Fecha desc, VS.IdSurtido desc

		select top 1 @CreditosInformales = isnull(VSV.Creditos,0) 
			from VendedoresSaldos VS
			left outer join VendedoresSaldosValida VSV on VS.IdCedis = VSV.IdCedis and VS.IdSurtido = VSV.IdSurtido and VS.IdVendedor = VSV.IdVendedor 
			where VS.IdCedis = @IdCedis and VS.IdVendedor = @IdVendedor and VS.Fecha = @Fecha  		
			group by VS.IdVendedor, VS.SaldoActual, VSV.Creditos, VS.Fecha, VS.IdSurtido 
			order by VS.Fecha desc, VS.IdSurtido desc

		select @SaldoVendedor = @UltimoSaldo + @Financiamientos + @CreditosInformales 
		
		if @SaldoVendedor > 0 set @SaldoVendedor = 0		

		update tempComisionesDetalle set SaldoVendedor = @SaldoVendedor,  Saldo = @UltimoSaldo, TotalPago = Comision + AbonoMerma + AbonoVolumen - CargoMerma + @SaldoVendedor 
		where IdCedis = @IdCedis and IdVendedor = @IdVendedor and Fecha = @Fecha 
		
		fetch next from CursorComisiones into @IdVendedor
	end
	close CursorComisiones
	deallocate CursorComisiones		
end
*/


GO


USE [Route] 
GO

if (Select COUNT(*) from VersionBD where Tipo = 'SA' and Version ='3.8.16.1') = 0
BEGIN
	INSERT INTO VersionBD (Tipo, FechaHora, Version, MaximoConsecutivo, VersionSql ) 
	VALUES('SA', GETDATE(), '3.8.16.1', 84, (SELECT  cast(SERVERPROPERTY('productversion') as varchar(50))))
END
ELSE
BEGIN 
	Update VersionBD  set MaximoConsecutivo = 84 where  Tipo = 'SA' and Version ='3.8.16.1'
END

GO
