
USE [RouteADM]
GO

/****** Object:  Table [dbo].[ComEsquemaClientes]    Script Date: 11/28/2010 16:35:47 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ComEsquemaClientes]') AND type in (N'U'))
DROP TABLE [dbo].[ComEsquemaClientes]
GO

USE [RouteADM]
GO

/****** Object:  Table [dbo].[ComEsquemaClientes]    Script Date: 11/28/2010 16:35:47 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[ComEsquemaClientes](
	[IdComEsquema] [bigint] NOT NULL,
	[IdCedis] [bigint] NOT NULL,
	[IdCliente] [bigint] NOT NULL,
	[IdSucursal] [varchar](20) NOT NULL,
	[IdProducto] [bigint] NOT NULL,
	[Status] [char](1) NULL,
	[Fecha] [datetime] NULL,
	[Usuario] [nvarchar](20) NULL,
 CONSTRAINT [PK_ComEsquemaClientes] PRIMARY KEY CLUSTERED 
(
	[IdComEsquema] ASC,
	[IdCedis] ASC,
	[IdCliente] ASC,
	[IdSucursal] ASC,
	[IdProducto] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


