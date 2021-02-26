USE [RouteADM]
GO

/****** Object:  Table [dbo].[StatusDiaDetalle]    Script Date: 03/26/2011 17:21:59 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[StatusDiaDetalle]') AND type in (N'U'))
DROP TABLE [dbo].[StatusDiaDetalle]
GO

USE [RouteADM]
GO

/****** Object:  Table [dbo].[StatusDia]    Script Date: 03/26/2011 17:21:59 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[StatusDiaDetalle](
	[IdCedis] [bigint] NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[FechaEdicion] [datetime] NOT NULL,
	[Status] [varchar](1) NULL,
	[StatusDesc] [varchar](100) NULL,
 CONSTRAINT [PK_StatusDiaDetalle] PRIMARY KEY CLUSTERED 
(
	[IdCedis] ASC,
	[Fecha] ASC,
	[FechaEdicion] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


