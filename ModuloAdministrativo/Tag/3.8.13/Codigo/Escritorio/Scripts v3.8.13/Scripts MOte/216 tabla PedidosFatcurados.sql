USE [RouteADM]
GO

/****** Object:  Table [dbo].[PedidosFacturados]    Script Date: 04/19/2010 00:15:18 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[PedidosFacturados](
	[TransProdId] [varchar](16) NOT NULL,
	[Facturada] [char](1) NULL,
	[Fecha] [datetime] NULL,
 CONSTRAINT [PK_PedidosFacturados] PRIMARY KEY CLUSTERED 
(
	[TransProdId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


