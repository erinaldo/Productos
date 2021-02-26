USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[sel_TipoDevolucion]    Script Date: 11/17/2010 19:33:45 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sel_TipoDevolucion]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sel_TipoDevolucion]
GO

USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[sel_TipoDevolucion]    Script Date: 11/17/2010 19:33:45 ******/
SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER OFF
GO




CREATE PROCEDURE [dbo].[sel_TipoDevolucion] 
@Opc as int	

AS

if @Opc = 1
	select IdTipoDevolucion, TipoDevolucion, EnRuta, Status
	from TipoDevolucion
	where Status = 'A'
	order by IdTipoDevolucion 

if @Opc = 2
	select isnull(count(IdTipoDevolucion), 0)
	from TipoDevolucion

if @Opc = 3
	select IdTipoDevolucion, cast(IdTipoDevolucion as varchar(20)) + '. ' + TipoDevolucion + ' - ' + case EnRuta when 1 then 'SI' else 'NO' end, 
	EnRuta, Status
	from TipoDevolucion
	where Status = 'A'
	order by IdTipoDevolucion 



GO


