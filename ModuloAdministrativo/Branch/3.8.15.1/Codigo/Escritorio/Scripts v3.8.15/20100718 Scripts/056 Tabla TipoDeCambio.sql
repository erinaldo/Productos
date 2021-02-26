USE [RouteADM]
GO

/****** Object:  Table [dbo].[TipoDeCambio]    Script Date: 07/17/2010 19:12:23 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TipoDeCambio]') AND type in (N'U'))
DROP TABLE [dbo].[TipoDeCambio]
GO

USE [RouteADM]
GO

/****** Object:  Table [dbo].[TipoDeCambio]    Script Date: 07/17/2010 19:12:23 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[TipoDeCambio](
	[Fecha] [datetime] NOT NULL,
	[IdMonedaBase] [varchar](5) NOT NULL,
	[IdMoneda] [varchar](5) NOT NULL,
	[TipoCambio] [money] NULL,
 CONSTRAINT [PK_TipoDeCambio] PRIMARY KEY CLUSTERED 
(
	[Fecha] ASC,
	[IdMonedaBase] ASC,
	[IdMoneda] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


