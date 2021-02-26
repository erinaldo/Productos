USE [RouteADM]
GO

/****** Object:  Table [dbo].[VentasDetalle]    Script Date: 07/13/2010 13:24:33 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[VentasDetalle]') AND type in (N'U'))
DROP TABLE [dbo].[VentasDetalle]
GO

USE [RouteADM]
GO

/****** Object:  Table [dbo].[VentasDetalle]    Script Date: 07/13/2010 13:24:33 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[VentasDetalle](
	[IdCedis] [bigint] NOT NULL,
	[IdSurtido] [bigint] NOT NULL,
	[IdTipoVenta] [int] NOT NULL,
	[Folio] [bigint] NOT NULL,
	[IdProducto] [bigint] NOT NULL,
	[Serie] [varchar](5) NOT NULL,
	[Cantidad] [decimal](19, 4) NULL,
	[Precio] [money] NULL,
	[Iva] [float] NULL,
	[Subtotal]  AS (([Cantidad] * [Precio]) - [DctoImp]),
	[Total]  AS ( (([Cantidad] * [Precio]) - [DctoImp]) * (1 + [Iva])),
	[DctoPorc] [money] NULL,
	[DctoImp] [money] NULL,
	[Entregado] [decimal](19, 4) NULL,
 CONSTRAINT [PK_VentasDetalle] PRIMARY KEY CLUSTERED 
(
	[IdCedis] ASC,
	[IdSurtido] ASC,
	[IdTipoVenta] ASC,
	[Folio] ASC,
	[IdProducto] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


