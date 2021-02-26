use RouteADM 

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SurtidosImpuestos]') AND type in (N'U'))
DROP TABLE [dbo].[SurtidosImpuestos]


/****** Object:  Table [dbo].[SurtidosImpuestos]    Script Date: 02/27/2011 00:06:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[SurtidosImpuestos](
	[IdCedis] [bigint] NOT NULL,
	[IdSurtido] [bigint] NOT NULL,
	[IdProducto] [bigint] NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[IdTipoImpuesto] [smallint] NOT NULL,
	[TipoAplicacion] [smallint] NOT NULL,
	[Jerarquia] [smallint] NOT NULL,
	[Tasa] [float] NULL,
 CONSTRAINT [PK_SurtidosImpuestos] PRIMARY KEY CLUSTERED 
(
	[IdCedis] ASC,
	[IdSurtido] ASC,
	[IdProducto] ASC,
	[Fecha] ASC,
	[IdTipoImpuesto] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


