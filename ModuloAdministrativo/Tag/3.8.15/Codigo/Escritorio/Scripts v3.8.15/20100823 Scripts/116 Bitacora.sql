USE [RouteADM]
GO

/****** Object:  Table [dbo].[Bitacora]    Script Date: 08/25/2010 22:44:16 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Bitacora]') AND type in (N'U'))
DROP TABLE [dbo].[Bitacora]
GO

USE [RouteADM]
GO

/****** Object:  Table [dbo].[Bitacora]    Script Date: 08/25/2010 22:44:17 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Bitacora](
	[FolioAccion] [varchar](20) NOT NULL,
	[Login] [varchar](10) NOT NULL,
	[IdCedis] [bigint] NOT NULL,
	[IdSurtido] [bigint] NULL,
	[IdCarga] [bigint] NULL,
	[IdMovimiento] [bigint] NULL,
	[IdTipoVenta] [int] NULL,
	[Serie] [varchar](5) NULL,
	[Folio] [bigint] NULL,
	[FechaTrabajo] [datetime] NULL,
	[IdRuta] [bigint] NULL,
	[IdCliente] [bigint] NULL,
	[IdSucursal] [varchar](16) NULL,
	[IdProducto] [bigint] NULL,
	[Modulo] [varchar](16) NULL,
	[Accion] [varchar](16) NULL,
	[FechaEjecucion] [datetime] NULL,
	[Detalle] [varchar](5000) NULL,
 CONSTRAINT [PK_Bitacora] PRIMARY KEY CLUSTERED 
(
	[FolioAccion] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


