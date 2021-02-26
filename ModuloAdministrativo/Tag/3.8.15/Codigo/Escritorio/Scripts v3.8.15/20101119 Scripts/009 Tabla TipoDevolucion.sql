USE [RouteADM]
GO

/****** Object:  Table [dbo].[TipoDevolucion]    Script Date: 11/16/2010 17:27:12 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TipoDevolucion]') AND type in (N'U'))
DROP TABLE [dbo].[TipoDevolucion]
GO

USE [RouteADM]
GO

/****** Object:  Table [dbo].[TipoDevolucion]    Script Date: 11/16/2010 17:27:12 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[TipoDevolucion](
	[IdTipoDevolucion] [bigint] NOT NULL,
	[TipoDevolucion] [varchar](20) NULL,
	[EnRuta] [bit] NULL,
	[FechaAlta] [datetime] NULL,
	[Status] [char](1) NULL,
 CONSTRAINT [PK_TipoDevolucion] PRIMARY KEY CLUSTERED 
(
	[IdTipoDevolucion] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


