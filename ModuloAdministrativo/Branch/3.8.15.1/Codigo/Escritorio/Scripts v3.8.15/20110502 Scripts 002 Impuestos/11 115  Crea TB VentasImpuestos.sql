use RouteADM 

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[VentasImpuestos]') AND type in (N'U'))
DROP TABLE [dbo].[VentasImpuestos]


/****** Object:  Table [dbo].[VentasImpuestos]    Script Date: 02/27/2011 00:11:55 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[VentasImpuestos](
	[IdCedis] [bigint] NOT NULL,
	[IdSurtido] [bigint] NOT NULL,
	[IdTipoVenta] [int] NOT NULL,
	[Folio] [bigint] NOT NULL,
	[IdProducto] [bigint] NOT NULL,
	[IdTipoImpuesto] [smallint] NOT NULL,
	[TipoAplicacion] [smallint] NOT NULL,
	[Jerarquia] [smallint] NOT NULL,
	[Tasa] [float] NULL,
 CONSTRAINT [PK_VentasImpuestos] PRIMARY KEY CLUSTERED 
(
	[IdCedis] ASC,
	[IdSurtido] ASC,
	[IdTipoVenta] ASC,
	[Folio] ASC,
	[IdProducto] ASC,
	[IdTipoImpuesto] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


