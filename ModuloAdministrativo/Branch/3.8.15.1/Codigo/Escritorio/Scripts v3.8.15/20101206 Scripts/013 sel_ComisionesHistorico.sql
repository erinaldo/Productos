USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[sel_ComisionesHistorico]    Script Date: 12/07/2010 09:53:52 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sel_ComisionesHistorico]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sel_ComisionesHistorico]
GO

USE [RouteADM]
GO	

/****** Object:  StoredProcedure [dbo].[sel_ComisionesHistorico]    Script Date: 12/07/2010 09:53:52 ******/
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
	where Usuario = @Usuario and Fecha between @FechaInicial and @FechaFinal 

end

GO


