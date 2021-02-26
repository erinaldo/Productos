USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[sel_ComisionesHistorico]    Script Date: 08/31/2011 18:26:19 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sel_ComisionesHistorico]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sel_ComisionesHistorico]
GO

USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[sel_ComisionesHistorico]    Script Date: 08/31/2011 18:26:19 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO





CREATE PROCEDURE [dbo].[sel_ComisionesHistorico]
@IdCedis as bigint,
@FechaInicial as datetime,
@FechaFinal as datetime,
@Usuario as varchar(50),
@Opc as int

AS

if @Opc = 1
begin 

	select *
	from ComisionesHistorico 
	where FechaIni = @FechaInicial and FechaFin = @FechaFinal and IdCedis = @IdCedis 

end


GO


USE [Route] 
GO

if (Select COUNT(*) from VersionBD where Tipo = 'SA' and Version ='3.8.16.1') = 0
BEGIN
	INSERT INTO VersionBD (Tipo, FechaHora, Version, MaximoConsecutivo, VersionSql ) 
	VALUES('SA', GETDATE(), '3.8.16.1', 95, (SELECT  cast(SERVERPROPERTY('productversion') as varchar(50))))
END
ELSE
BEGIN 
	Update VersionBD  set MaximoConsecutivo = 95 where  Tipo = 'SA' and Version ='3.8.16.1'
END

GO