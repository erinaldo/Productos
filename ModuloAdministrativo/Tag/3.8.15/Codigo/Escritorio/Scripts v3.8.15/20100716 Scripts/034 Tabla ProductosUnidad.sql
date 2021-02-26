USE [RouteADM]
GO

/****** Object:  Table [dbo].[ProductosUnidad]    Script Date: 07/16/2010 12:20:05 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ProductosUnidad]') AND type in (N'U'))
DROP TABLE [dbo].[ProductosUnidad]
GO

USE [RouteADM]
GO

/****** Object:  Table [dbo].[ProductosUnidad]    Script Date: 07/16/2010 12:20:05 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[ProductosUnidad](
	[IdProducto] [bigint] NOT NULL,
	[IdUnidad] [varchar](10) NOT NULL,
	[Factor] [decimal](18, 9) NULL,
	[Divide] [varchar](1) NOT NULL,
 CONSTRAINT [PK_ProductosUnidad] PRIMARY KEY CLUSTERED 
(
	[IdProducto] ASC,
	[IdUnidad] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


