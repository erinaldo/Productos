USE [RouteCPC]
GO

/****** Object:  Table [dbo].[Configuracion]    Script Date: 03/03/2011 19:28:50 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Configuracion]') AND type in (N'U'))
DROP TABLE [dbo].[Configuracion]
GO

USE [RouteCPC]
GO

/****** Object:  Table [dbo].[Configuracion]    Script Date: 03/03/2011 19:28:50 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Configuracion](
	[AgrupaFolio] [char] (1) NULL,
	[IdDocumentoDevolucion] [varchar](5) NULL,
	[IdTipoDocumentoDevolucion] [varchar](50) NULL,
	[IdDocumentoAnticipo] [varchar](5) NULL,
	[IdTipoDocumentoAnticipo] [varchar](50) NULL,
	[IdDocumentoPagoAnt] [varchar](5) NULL,
	[IdTipoDocumentoPagoAnt] [varchar](50) NULL,
	[IdDocumentoCargoAnt] [varchar](5) NULL,
	[IdTipoDocumentoCargoAnt] [varchar](50) NULL	
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

