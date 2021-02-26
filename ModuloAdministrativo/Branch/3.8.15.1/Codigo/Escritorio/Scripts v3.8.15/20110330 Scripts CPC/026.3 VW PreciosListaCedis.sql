USE [RouteCPC]
GO

/****** Object:  View [dbo].[PreciosListaCedis]    Script Date: 04/01/2011 15:51:05 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[PreciosListaCedis]'))
DROP VIEW [dbo].[PreciosListaCedis]
GO

USE [RouteCPC]
GO

/****** Object:  View [dbo].[PreciosListaCedis]    Script Date: 04/01/2011 15:51:05 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[PreciosListaCedis]
AS
SELECT     *
FROM         RouteADM.dbo.PreciosListaCedis

GO


