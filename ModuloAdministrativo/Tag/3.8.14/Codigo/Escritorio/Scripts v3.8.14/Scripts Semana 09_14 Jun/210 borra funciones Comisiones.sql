USE [RouteADM]
GO

/****** Object:  UserDefinedFunction [dbo].[FN_Comisiones]    Script Date: 06/09/2010 10:37:44 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FN_Comisiones]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[FN_Comisiones]
GO

USE [RouteADM]
GO

/****** Object:  UserDefinedFunction [dbo].[FN_ComisionesDetalle]    Script Date: 06/09/2010 10:37:55 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FN_ComisionesDetalle]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[FN_ComisionesDetalle]
GO

USE [RouteADM]
GO

/****** Object:  UserDefinedFunction [dbo].[FN_ComisionesDetalleSurtido]    Script Date: 06/09/2010 10:38:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FN_ComisionesDetalleSurtido]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[FN_ComisionesDetalleSurtido]
GO


