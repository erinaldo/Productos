USE [RouteADM]
GO

/****** Object:  Table [dbo].[VentasRoute]    Script Date: 05/31/2011 13:58:46 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[VentasRoute]') AND type in (N'U'))
DROP TABLE [dbo].[VentasRoute]
GO

USE [RouteADM]
GO

/****** Object:  Table [dbo].[VentasRoute]    Script Date: 05/31/2011 13:58:46 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[VentasRoute](
	[IdCedis] [bigint] NOT NULL,
	[IdSurtido] [bigint] NOT NULL,
	[IdTipoVenta] [int] NOT NULL,
	[Folio] [bigint] NOT NULL,
	[Serie] [varchar](5) NOT NULL,
	[Fecha] [datetime] NULL,
	[IdCliente] [bigint] NULL,
	[IdSucursal] [varchar](16) NULL,
	[SerieFactura] [varchar](5) NULL,
	[FolioFactura] [bigint] NULL,
 CONSTRAINT [PK_VentasRoute] PRIMARY KEY CLUSTERED 
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


