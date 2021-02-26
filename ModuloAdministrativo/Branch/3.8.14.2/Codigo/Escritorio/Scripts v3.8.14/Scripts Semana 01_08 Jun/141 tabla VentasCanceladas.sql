USE [RouteADM]
GO

/****** Object:  Table [dbo].[Ventas]    Script Date: 06/02/2010 22:32:19 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[VentasCanceladas](
	[IdCedis] [bigint] NOT NULL,
	[IdSurtido] [bigint] NOT NULL,
	[IdTipoVenta] [int] NOT NULL,
	[Folio] [bigint] NOT NULL,
	[Serie] [varchar](5) NOT NULL,
	[Fecha] [datetime] NULL,
	[IdCliente] [bigint] NULL,
	[Subtotal] [money] NULL,
	[Iva] [money] NULL,
	[Total]  AS ([Subtotal] + [Iva]),
	[IdSucursal] [varchar](16) NULL,
 CONSTRAINT [PK_VentasCanceladas] PRIMARY KEY CLUSTERED 
(
	[IdCedis] ASC,
	[IdSurtido] ASC,
	[IdTipoVenta] ASC,
	[Folio] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

