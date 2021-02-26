USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[sel_ComEsquema]    Script Date: 08/22/2011 20:29:51 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sel_ComEsquema]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sel_ComEsquema]
GO

USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[sel_ComEsquema]    Script Date: 08/22/2011 20:29:52 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO





CREATE PROCEDURE [dbo].[sel_ComEsquema]
@IdComEsquema as bigint,
@Opc as int

AS

if @Opc = 1
	select IdComEsquema, Nombre as 'Esquema', 
	case Status 
		when 'A' then 'Activo'
		when 'B' then 'Baja'
	end as 'Status', Fecha as 'Fecha de Modificación', Usuario, 
	case Acumulado when '1' then 'Prom. Semanal' else 'Por Día' end AS 'Tipo Aplicación'
	from ComEsquema
	order by IdComEsquema






GO


USE [Route] 
GO

if (Select COUNT(*) from VersionBD where Tipo = 'SA' and Version ='3.8.16.1') = 0
BEGIN
	INSERT INTO VersionBD (Tipo, FechaHora, Version, MaximoConsecutivo, VersionSql ) 
	VALUES('SA', GETDATE(), '3.8.16.1', 81, (SELECT  cast(SERVERPROPERTY('productversion') as varchar(50))))
END
ELSE
BEGIN 
	Update VersionBD  set MaximoConsecutivo = 81 where  Tipo = 'SA' and Version ='3.8.16.1'
END
GO
