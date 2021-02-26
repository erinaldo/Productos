USE [RouteADM]
GO

/****** Object:  Table [dbo].[Devolucion]    Script Date: 10/20/2010 09:28:03 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Devolucion]') AND type in (N'U'))
DROP TABLE [dbo].[Devolucion]
GO

/****** Object:  Table [dbo].[DevolucionDetalle]    Script Date: 10/20/2010 09:28:03 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DevolucionDetalle]') AND type in (N'U'))
DROP TABLE [dbo].[DevolucionDetalle]
GO

USE [RouteADM]
GO

/****** Object:  Table [dbo].[Devolucion]    Script Date: 10/20/2010 09:28:03 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Devolucion](
	[IdCedis] [bigint] NOT NULL,
	[IdSurtido] [bigint] NOT NULL,
	[IdDevolucion] [bigint] NOT NULL,
	[IdCliente] [bigint] NOT NULL,
	[IdSucursal] [varchar](16) NOT NULL,
	[Status] [char](1) NULL,
 CONSTRAINT [PK_Devolucion] PRIMARY KEY CLUSTERED 
(
	[IdCedis] ASC,
	[IdSurtido] ASC,
	[IdDevolucion] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

USE [RouteADM]
GO

/****** Object:  Table [dbo].[DevolucionDetalle]    Script Date: 10/20/2010 09:28:03 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[DevolucionDetalle](
	[IdCedis] [bigint] NOT NULL,
	[IdSurtido] [bigint] NOT NULL,
	[IdDevolucion] [bigint] NOT NULL,
	[IdProducto] [char](10) NOT NULL,
	[Cantidad] [decimal](19, 4) NULL,
 CONSTRAINT [PK_DDevolucion] PRIMARY KEY CLUSTERED 
(
	[IdCedis] ASC,
	[IdSurtido] ASC,
	[IdProducto] ASC,
	[IdDevolucion] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


