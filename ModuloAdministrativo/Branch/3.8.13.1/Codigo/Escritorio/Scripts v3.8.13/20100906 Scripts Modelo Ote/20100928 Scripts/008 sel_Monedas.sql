USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[sel_Monedas]    Script Date: 09/06/2010 15:07:39 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sel_Monedas]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sel_Monedas]
GO

USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[sel_Monedas]    Script Date: 09/06/2010 15:07:39 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




CREATE PROCEDURE [dbo].[sel_Monedas]
@IdMoneda as varchar(5),
@Opc as int
AS

if @Opc = 1
	select IdMoneda, Moneda 
	from Monedas 
	where Status = 'A'
	order by IdMoneda 


GO

