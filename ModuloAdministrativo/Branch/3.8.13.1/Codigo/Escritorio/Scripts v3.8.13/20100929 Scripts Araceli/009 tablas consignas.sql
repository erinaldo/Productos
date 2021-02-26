USE [RouteADM]
GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF__Consignas__IdSuc__597B3B93]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Consignas] DROP CONSTRAINT [DF__Consignas__IdSuc__597B3B93]
END

GO

USE [RouteADM]
GO

/****** Object:  Table [dbo].[Consignas]    Script Date: 09/23/2010 16:09:13 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Consignas]') AND type in (N'U'))
DROP TABLE [dbo].[Consignas]
GO

/****** Object:  Table [dbo].[ConsignasDetalle]    Script Date: 09/23/2010 16:09:13 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ConsignasDetalle]') AND type in (N'U'))
DROP TABLE [dbo].[ConsignasDetalle]
GO

USE [RouteADM]
GO

/****** Object:  Table [dbo].[Consignas]    Script Date: 09/23/2010 16:09:13 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Consignas](
	[IdCedis] [bigint] NOT NULL,
	[IdConsigna] [bigint] NOT NULL,
	[IdCliente] [bigint] NOT NULL,
	[IdSucursal] [varchar](16) NULL,
	[IdRutaEntrega] [bigint] NOT NULL,
	[IdSurtidoEntrega] [bigint] NOT NULL,
	[FechaEntrega] [datetime] NOT NULL,
	[IdMovimientoEntrega] [bigint] NULL,
	[IdRutaDevolucion] [bigint] NULL,
	[IdSurtidoDevolucion] [bigint] NULL,
	[FechaDevolucion] [datetime] NOT NULL,
	[IdMovimientoDevolucion] [bigint] NULL,
	[Folio] [bigint] NULL,
	[Serie] [varchar](5) NULL,
	[Observaciones] [varchar](5000) NULL,
	[Status] [char](1) NULL,
 CONSTRAINT [PK_Consignas] PRIMARY KEY CLUSTERED 
(
	[IdCedis] ASC,
	[IdConsigna] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

USE [RouteADM]
GO

/****** Object:  Table [dbo].[ConsignasDetalle]    Script Date: 09/23/2010 16:09:13 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[ConsignasDetalle](
	[IdCedis] [bigint] NOT NULL,
	[IdConsigna] [bigint] NOT NULL,
	[IdProducto] [char](10) NOT NULL,
	[Surtido] [decimal](19, 4) NULL,
	[Devolucion] [decimal](19, 4) NULL,
	[Venta] [decimal](19, 4) NULL,
	[Precio] [money] NULL,
	[Iva] [float] NULL,
	[SubTotal]  AS ([Surtido]*[Precio]),
	[Total]  AS ([Surtido]*([Precio]*((1)+[Iva]))),
 CONSTRAINT [PK_DConsignas] PRIMARY KEY CLUSTERED 
(
	[IdCedis] ASC,
	[IdConsigna] ASC,
	[IdProducto] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[Consignas] ADD  DEFAULT ('0') FOR [IdSucursal]
GO


