USE [RouteADM]
GO

/****** Object:  Table [dbo].[Pedidos]    Script Date: 09/20/2010 10:31:33 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Pedidos]') AND type in (N'U'))
DROP TABLE [dbo].[Pedidos]
GO

/****** Object:  Table [dbo].[PedidosDetalle]    Script Date: 09/20/2010 10:31:33 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PedidosDetalle]') AND type in (N'U'))
DROP TABLE [dbo].[PedidosDetalle]
GO

USE [RouteADM]
GO

/****** Object:  Table [dbo].[Pedidos]    Script Date: 09/20/2010 10:31:33 ******/
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
	[Total]  AS ([Subtotal]+[Iva]),
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

USE [RouteADM]
GO

/****** Object:  Table [dbo].[PedidosDetalle]    Script Date: 09/20/2010 10:31:33 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[PedidosDetalle](
	[IdCedis] [bigint] NOT NULL,
	[IdPedido] [bigint] NOT NULL,
	[IdTipoVenta] [int] NOT NULL,
	[IdProducto] [bigint] NOT NULL,
	[Cantidad] [decimal](19, 4) NULL,
	[Precio] [money] NULL,
	[Iva] [float] NULL,
	[Subtotal]  AS ([Cantidad]*[Precio]-[DctoImp]),
	[Total]  AS (([Cantidad]*[Precio]-[DctoImp])*((1)+[Iva])),
	[DctoPorc] [money] NULL,
	[DctoImp] [money] NULL,
	[Entregado] [decimal](19, 4) NULL,
 CONSTRAINT [PK_PedidosDetalle] PRIMARY KEY CLUSTERED 
(
	[IdCedis] ASC,
	[IdPedido] ASC,
	[IdTipoVenta] ASC,
	[IdProducto] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

