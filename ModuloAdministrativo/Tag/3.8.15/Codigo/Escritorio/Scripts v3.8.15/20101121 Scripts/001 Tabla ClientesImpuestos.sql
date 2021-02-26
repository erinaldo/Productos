USE [RouteADM]
GO

/****** Object:  Table [dbo].[ClientesImpuestos]    Script Date: 11/15/2010 11:48:53 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ClientesImpuestos]') AND type in (N'U'))
DROP TABLE [dbo].[ClientesImpuestos]
GO

USE [RouteADM]
GO

/****** Object:  Table [dbo].[ClientesImpuestos]    Script Date: 11/15/2010 11:48:53 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[ClientesImpuestos](
	[IdCedis] [bigint] NOT NULL,
	[IdCliente] [bigint] NOT NULL,
	[IdSucursal] [varchar](16) NOT NULL,
	[IdProducto] [bigint] NOT NULL,
	[Valor] [float] NULL,
 CONSTRAINT [PK_ClientesImpuestos] PRIMARY KEY CLUSTERED 
(
	[IdCedis] ASC,
	[IdCliente] ASC,
	[IdSucursal] ASC,
	[IdProducto] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


