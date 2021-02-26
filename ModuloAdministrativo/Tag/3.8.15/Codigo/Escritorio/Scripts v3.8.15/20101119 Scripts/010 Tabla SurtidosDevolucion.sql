USE [RouteADM]
GO

/****** Object:  Table [dbo].[SurtidosMerma]    Script Date: 11/16/2010 17:25:17 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SurtidosDevolucion]') AND type in (N'U'))
DROP TABLE [dbo].[SurtidosDevolucion]
GO

USE [RouteADM]
GO

/****** Object:  Table [dbo].[SurtidosDevolucion]    Script Date: 11/16/2010 17:25:18 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[SurtidosDevolucion](
	[IdCedis] [bigint] NOT NULL,
	[IdSurtido] [bigint] NOT NULL,
	[IdTipoDevolucion] [bigint] NOT NULL,
	[IdProducto] [bigint] NOT NULL,
	[Cantidad] [decimal](19, 4) NULL,
 CONSTRAINT [PK_SurtidosDevolucion] PRIMARY KEY CLUSTERED 
(
	[IdCedis] ASC,
	[IdSurtido] ASC,
	[IdTipoDevolucion] ASC,
	[IdProducto] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


