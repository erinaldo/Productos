USE [RouteCPC]
GO

/****** Object:  View [dbo].[ClientesImpuestos]    Script Date: 04/01/2011 15:51:05 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[ClientesImpuestos]'))
DROP VIEW [dbo].[ClientesImpuestos]
GO

USE [RouteCPC]
GO

/****** Object:  View [dbo].[ClientesImpuestos]    Script Date: 04/01/2011 15:51:05 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[ClientesImpuestos]
AS
SELECT     *
FROM         RouteADM.dbo.ClientesImpuestos

GO


