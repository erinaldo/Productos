USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[up_ComisionesHistorico]    Script Date: 08/31/2011 18:20:09 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[up_ComisionesHistorico]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[up_ComisionesHistorico]
GO

USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[up_ComisionesHistorico]    Script Date: 08/31/2011 18:20:09 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[up_ComisionesHistorico]
@IdCedis as bigint,
@FechaInicial as datetime,
@FechaFinal as datetime,
@DiasTrabajados as smallint,
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
	--if (LTRIM(RTRIM(@Filtro)) ='')
		exec('delete from ComisionesHistorico 
		where FechaIni = ''' + @FechaIni + ''' and FechaFin = ''' +  @FechaFin + '''')
	--ELSE
	--	exec('delete from ComisionesHistorico 
	--	where ' + @Filtro + ' and FechaIni = ''' + @FechaIni + ''' and FechaFin = ''' +  @FechaFin + '''')

	insert into ComisionesHistorico 
	exec sel_ComisionesCalculo @IdCedis, @FechaIni, @FechaFin, @DiasTrabajados
	
end




GO

USE [Route] 
GO

if (Select COUNT(*) from VersionBD where Tipo = 'SA' and Version ='3.8.16.1') = 0
BEGIN
	INSERT INTO VersionBD (Tipo, FechaHora, Version, MaximoConsecutivo, VersionSql ) 
	VALUES('SA', GETDATE(), '3.8.16.1', 94, (SELECT  cast(SERVERPROPERTY('productversion') as varchar(50))))
END
ELSE
BEGIN 
	Update VersionBD  set MaximoConsecutivo = 94 where  Tipo = 'SA' and Version ='3.8.16.1'
END

GO
