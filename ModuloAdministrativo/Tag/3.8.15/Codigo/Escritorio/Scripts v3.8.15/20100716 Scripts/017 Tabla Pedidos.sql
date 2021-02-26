USE [RouteADM]
GO

/****** Object:  Table [dbo].[Pedidos]    Script Date: 07/14/2010 15:45:38 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Pedidos]') AND type in (N'U'))
DROP TABLE [dbo].[Pedidos]
GO

USE [RouteADM]
GO

/****** Object:  Table [dbo].[Pedidos]    Script Date: 07/14/2010 15:45:39 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Pedidos](
	[IdCedis] [bigint] NOT NULL,
	[IdPedido] [bigint] NOT NULL,
	[IdTipoVenta] [bigint] NULL,
	[FechaPedido] [datetime] NULL,
	[IdRutaPedido] [bigint] NULL,
	[FechaEntrega] [datetime] NULL,
	[IdRutaEntrega] [bigint] NULL,
	[IdCliente] [bigint] NULL,
	[IdSucursal] [varchar](16) NULL,
	[DctoImp] [money] NULL,
	[SubTotal] [money] NULL,
	[Iva] [money] NULL,
	[Total] AS ([Subtotal] + [Iva]),
	[IdSurtido] [bigint] NULL,
	[Serie] [varchar](5) NULL,
	[Folio] [bigint] NULL,
	[DiasCredito] [int] NULL,
 CONSTRAINT [PK_Pedidos] PRIMARY KEY CLUSTERED 
(
	[IdCedis] ASC,
	[IdPedido] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


