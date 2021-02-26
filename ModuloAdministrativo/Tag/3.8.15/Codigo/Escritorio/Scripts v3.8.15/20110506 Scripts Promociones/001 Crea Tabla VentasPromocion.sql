USE [RouteADM]
GO

/****** Object:  Table [dbo].[VentasPromociones]    Script Date: 05/08/2011 22:20:13 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[VentasPromociones]') AND type in (N'U'))
DROP TABLE [dbo].[VentasPromociones]
GO

USE [RouteADM]
GO

/****** Object:  Table [dbo].[VentasPromociones]    Script Date: 05/08/2011 22:20:13 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[VentasPromociones](
	[IdCedis] [bigint] NOT NULL,
	[IdSurtido] [bigint] NOT NULL,
	[IdTipoVenta] [int] NOT NULL,
	[Folio] [bigint] NOT NULL,
	[IdProducto] [bigint] NOT NULL,
	[IdPromocion] [bigint] NOT NULL,
	[Otras] [smallint] NULL,
	[Cascada] [smallint] NULL,
	[DctoPorc] [money] NULL,
	[DctoImp] [money] NULL,
	[Resultado] [varchar](200) NULL,
 CONSTRAINT [PK_VentasPromociones] PRIMARY KEY CLUSTERED 
(
	[IdCedis] ASC,
	[IdSurtido] ASC,
	[IdTipoVenta] ASC,
	[Folio] ASC,
	[IdProducto] ASC,
	[IdPromocion] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


