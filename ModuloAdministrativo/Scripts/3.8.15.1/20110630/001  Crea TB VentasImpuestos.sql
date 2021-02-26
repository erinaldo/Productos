use RouteCPC  

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[VentasImpuestos]') AND type in (N'U'))
BEGIN

CREATE TABLE [dbo].[VentasImpuestos](
	[IdCedis] [bigint] NOT NULL,
	[IdTipoVenta] [int] NOT NULL,
	[Serie] [varchar] (5) NOT NULL,
	[Folio] [bigint] NOT NULL,
	[IdProducto] [bigint] NOT NULL,
	[IdTipoImpuesto] [smallint] NOT NULL,
	[TipoAplicacion] [smallint] NOT NULL,
	[Jerarquia] [smallint] NOT NULL,
	[Tasa] [float] NULL,
 CONSTRAINT [PK_VentasImpuestos] PRIMARY KEY CLUSTERED 
(
	[IdCedis] ASC,
	[IdTipoVenta] ASC,
	[Serie] ASC,
	[Folio] ASC,
	[IdProducto] ASC,
	[IdTipoImpuesto] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

END
GO


