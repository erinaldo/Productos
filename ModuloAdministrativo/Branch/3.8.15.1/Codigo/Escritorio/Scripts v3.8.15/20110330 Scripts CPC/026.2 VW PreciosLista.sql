USE [RouteCPC]
GO

/****** Object:  View [dbo].[PreciosLista]    Script Date: 04/01/2011 15:51:05 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[PreciosLista]'))
DROP VIEW [dbo].[PreciosLista]
GO

USE [RouteCPC]
GO

/****** Object:  View [dbo].[PreciosLista]    Script Date: 04/01/2011 15:51:05 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[PreciosLista]
AS
SELECT     *
FROM         RouteADM.dbo.PreciosLista

GO


