USE [RouteCPC]
GO

/****** Object:  Table [dbo].[LEYProductos]    Script Date: 04/20/2011 12:04:22 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LEYProductos]') AND type in (N'U'))
DROP TABLE [dbo].[LEYProductos]
GO

USE [RouteCPC]
GO

/****** Object:  Table [dbo].[LEYProductos]    Script Date: 04/20/2011 12:04:22 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[LEYProductos](
	[IdProducto] [bigint] NOT NULL,
	[IdProductoLey] [varchar](20) NULL,
	[IdSucursal] [varchar](20) NOT NULL,
	[Login] [varchar](20) NULL,
	[FechaEdicion] [datetime] NOT NULL,
 CONSTRAINT [PK_LEYProductos] PRIMARY KEY CLUSTERED 
(
	[IdProducto] ASC,
	[IdSucursal] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


