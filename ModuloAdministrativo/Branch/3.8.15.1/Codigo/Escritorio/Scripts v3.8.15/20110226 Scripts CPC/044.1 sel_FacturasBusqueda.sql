USE [RouteADM]
GO

/****** Object:  Table [dbo].[VentasFacturadas]    Script Date: 03/23/2011 15:46:43 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[VentasFacturadas]') AND type in (N'U'))
DROP TABLE [dbo].[VentasFacturadas]
GO

USE [RouteADM]
GO

/****** Object:  Table [dbo].[VentasFacturadas]    Script Date: 03/23/2011 15:46:43 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[VentasFacturadas](
	[IdCedis] [bigint] NOT NULL,
	[IdSurtido] [bigint] NOT NULL,
	[IdTipoVenta] [bigint] NOT NULL,
	[Folio] [bigint] NOT NULL,
	[Serie] [varchar](5) NOT NULL,
	[FolioImpresion] [varchar](20) NULL,
	[Facturada] [char](1) NULL,
	[Fecha] [datetime] NULL,
 CONSTRAINT [PK_VentasFacturadas] PRIMARY KEY CLUSTERED 
(
	[IdCedis] ASC,
	[IdSurtido] ASC,
	[IdTipoVenta] ASC,
	[Folio] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO



