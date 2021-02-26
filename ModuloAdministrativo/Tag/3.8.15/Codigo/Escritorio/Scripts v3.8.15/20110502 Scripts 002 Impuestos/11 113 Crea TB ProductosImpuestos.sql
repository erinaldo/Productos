use RouteADM 

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ProductosImpuestos]') AND type in (N'U'))
DROP TABLE [dbo].[ProductosImpuestos]


/****** Object:  Table [dbo].[ProductosImpuestos]    Script Date: 02/26/2011 23:06:22 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ProductosImpuestos](
	[IdProducto] [bigint] NOT NULL,
	[IdTipoImpuesto] [smallint] NOT NULL,
 CONSTRAINT [PK_ProductosImpuestos] PRIMARY KEY CLUSTERED 
(
	[IdProducto] ASC,
	[IdTipoImpuesto] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


