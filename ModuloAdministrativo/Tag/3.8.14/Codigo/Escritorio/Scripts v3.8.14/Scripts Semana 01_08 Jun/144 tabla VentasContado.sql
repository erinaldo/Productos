USE [RouteADM]
GO

/****** Object:  Table [dbo].[VentasContado]    Script Date: 06/03/2010 10:25:13 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[VentasContado]') AND type in (N'U'))
DROP TABLE [dbo].[VentasContado]
GO

USE [RouteADM]
GO

/****** Object:  Table [dbo].[VentasContado]    Script Date: 06/03/2010 10:25:14 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[VentasContado](
	[IdCedis] [bigint] NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[Folio] [bigint] NOT NULL,
	[Serie] [varchar](5) NOT NULL,
	[Status] [char](1) NULL,
	[IdMarca] [bigint] NULL,
 CONSTRAINT [PK_VentasContado] PRIMARY KEY CLUSTERED 
(
	[IdCedis] ASC,
	[Fecha] ASC,
	[Folio] ASC,
	[Serie] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


