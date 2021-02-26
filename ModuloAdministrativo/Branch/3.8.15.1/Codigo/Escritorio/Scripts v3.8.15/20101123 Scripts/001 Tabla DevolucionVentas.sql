USE [RouteADM]
GO

/****** Object:  Table [dbo].[VentasDevolucion]    Script Date: 11/23/2010 05:14:31 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[VentasDevolucion]') AND type in (N'U'))
DROP TABLE [dbo].[VentasDevolucion]
GO

USE [RouteADM]
GO

/****** Object:  Table [dbo].[VentasDevolucion]    Script Date: 11/23/2010 05:14:32 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[VentasDevolucion](
	[IdCedisD] [bigint] NOT NULL,
	[IdSurtidoD] [bigint] NOT NULL,
	[IdTipoVentaD] [int] NOT NULL,
	[FolioD] [bigint] NOT NULL,
	[SerieD] [varchar](5) NOT NULL,
	[IdSurtido] [bigint] NOT NULL,
	[IdTipoVenta] [int] NOT NULL,
	[Folio] [bigint] NOT NULL,
	[Serie] [varchar](5) NOT NULL,
	[IdCliente] [bigint] NULL,
	[IdSucursal] [varchar](16) NULL,
 CONSTRAINT [PK_VentasDevolucion] PRIMARY KEY CLUSTERED 
(
	[IdCedisD] ASC,
	[IdSurtidoD] ASC,
	[IdTipoVentaD] ASC,
	[FolioD] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

