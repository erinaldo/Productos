USE [RouteADM]
GO

/****** Object:  UserDefinedFunction [dbo].[FN_ComisionesTipoRutaYFamilia]    Script Date: 06/09/2010 10:40:21 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FN_ComisionesTipoRutaYFamilia]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[FN_ComisionesTipoRutaYFamilia]
GO

USE [RouteADM]
GO

/****** Object:  UserDefinedFunction [dbo].[FN_ComisionesTipoRutaXCedis]    Script Date: 06/09/2010 10:40:15 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FN_ComisionesTipoRutaXCedis]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[FN_ComisionesTipoRutaXCedis]
GO
