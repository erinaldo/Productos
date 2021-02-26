use RouteADM 

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PedidosImpuestos]') AND type in (N'U'))
DROP TABLE [dbo].[PedidosImpuestos]


/****** Object:  Table [dbo].[PedidosImpuestos]    Script Date: 02/27/2011 00:15:41 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[PedidosImpuestos](
	[IdCedis] [bigint] NOT NULL,
	[IdPedido] [bigint] NOT NULL,
	[IdTipoVenta] [int] NOT NULL,
	[IdProducto] [bigint] NOT NULL,
	[IdTipoImpuesto] [smallint] NOT NULL,
	[TipoAplicacion] [smallint] NOT NULL,
	[Jerarquia] [smallint] NOT NULL,
	[Tasa] [float] NULL,
 CONSTRAINT [PK_PedidosImpuestos] PRIMARY KEY CLUSTERED 
(
	[IdCedis] ASC,
	[IdPedido] ASC,
	[IdTipoVenta] ASC,
	[IdProducto] ASC,
	[IdTipoImpuesto] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


