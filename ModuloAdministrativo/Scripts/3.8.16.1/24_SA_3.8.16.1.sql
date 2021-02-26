USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[sel_ExistenciaDia]    Script Date: 07/28/2011 09:41:57 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sel_ExistenciaDia]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sel_ExistenciaDia]
GO

USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[sel_ExistenciaDia]    Script Date: 07/28/2011 09:41:57 ******/
SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER OFF
GO




CREATE PROCEDURE [dbo].[sel_ExistenciaDia] 
@IdCedis as bigint,
@Fecha as datetime,
@Opc as int
AS

if @Opc = 1
	select Surtidos.IdCedis, Surtidos.IdSurtido, Surtidos.IdRuta, isnull( sum(Surtido - DevBuena - DevMala - Obsequios - VentaContado - VentaCredito - Consignacion + Recuperacion) , 0) as 'Existencia'
	from Surtidos 
	inner join SurtidosDetalle on Surtidos.IdSurtido = SurtidosDetalle.IdSurtido and Surtidos.IdCedis = SurtidosDetalle.IdCedis 
	where Surtidos.IdCedis = @IdCedis and Surtidos.Fecha = @Fecha
	group by Surtidos.IdCedis, Surtidos.IdSurtido, Surtidos.IdRuta

if @Opc = 2
	select IdCedis, IdSurtido, IdRuta, Status
	from Surtidos 
	where IdCedis = @IdCedis and Fecha = @Fecha
GO



USE [Route]
GO

if (Select COUNT(*) from VersionBD where Tipo = 'SA' and Version ='3.8.16.1') = 0
BEGIN
	INSERT INTO VersionBD (Tipo, FechaHora, Version, MaximoConsecutivo, VersionSql ) 
	VALUES('SA', GETDATE(), '3.8.16.1', 24, (SELECT  cast(SERVERPROPERTY('productversion') as varchar(50))))
END
ELSE
BEGIN 
	Update VersionBD  set MaximoConsecutivo = 24 where  Tipo = 'SA' and Version ='3.8.16.1'
END
GO