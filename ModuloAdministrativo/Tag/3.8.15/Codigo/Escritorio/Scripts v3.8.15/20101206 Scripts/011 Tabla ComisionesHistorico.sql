USE [RouteADM]
GO

/****** Object:  Table [dbo].[ComisionesHistorico]    Script Date: 12/06/2010 19:19:58 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ComisionesHistorico]') AND type in (N'U'))
DROP TABLE [dbo].[ComisionesHistorico]
GO

USE [RouteADM]
GO

/****** Object:  Table [dbo].[ComisionesHistorico]    Script Date: 12/06/2010 19:19:58 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[ComisionesHistorico](
	[Id] [varchar](20) NOT NULL,
	[Usuario] [varchar](12) NOT NULL,
	[FechaCalculo] [datetime] NOT NULL,
	[IdCedis] [bigint] NOT NULL,
	[IdSurtido] [bigint] NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[IdComEsquema] [bigint] NULL,
	[Esquema] [varchar](50) NULL,
	[IdConceptoPago] [bigint] NULL,
	[ConceptoPago] [varchar](50) NULL,
	[TipoRuta] [bigint] NULL,
	[IdRuta] [bigint] NULL,
	[IdTipoVendedor] [bigint] NULL,
	[TipoVendedor] [varchar](50) NULL,
	[IdFamilia] [bigint] NULL,
	[Familia] [varchar](50) NULL,
	[IdProducto] [bigint] NULL,
	[Producto] [varchar](50) NULL,
	[Venta] [money] NULL,
	[Inicial] [money] NULL,
	[Final] [money] NULL,
	[Factor] [money] NULL,
	[Pago] [money] NULL,
	[AbonoMerma] [money] NULL,
	[AbonoVolumen] [money] NULL,
 CONSTRAINT [PK_ComisionesHistorico] PRIMARY KEY CLUSTERED 
(
	[Id] ASC,
	[Usuario] ASC,
	[FechaCalculo] ASC,
	[IdCedis] ASC,
	[IdSurtido] ASC,
	[Fecha] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


