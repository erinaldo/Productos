USE [RouteADM]
GO

/****** Object:  Table [dbo].[MonedasMarcas]    Script Date: 09/06/2010 15:05:19 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MonedasMarcas]') AND type in (N'U'))
DROP TABLE [dbo].[MonedasMarcas]
GO

USE [RouteADM]
GO

/****** Object:  Table [dbo].[MonedasMarcas]    Script Date: 09/06/2010 15:05:19 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[MonedasMarcas](
	[IdMoneda] [varchar](5) NOT NULL,
	[IdMarca] [bigint] NOT NULL,
 CONSTRAINT [PK_MonedasMarcas] PRIMARY KEY CLUSTERED 
(
	[IdMoneda] ASC,
	[IdMarca] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

