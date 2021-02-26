USE [RouteCPC]
GO

/****** Object:  UserDefinedFunction [dbo].[FN_VentasPDCContado]    Script Date: 06/08/2010 12:17:00 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FN_VentasPDCContado]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[FN_VentasPDCContado]
GO

USE [RouteCPC]
GO

/****** Object:  UserDefinedFunction [dbo].[FN_VentasPDCContadoDetalle]    Script Date: 06/08/2010 12:17:18 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FN_VentasPDCContadoDetalle]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[FN_VentasPDCContadoDetalle]
GO

