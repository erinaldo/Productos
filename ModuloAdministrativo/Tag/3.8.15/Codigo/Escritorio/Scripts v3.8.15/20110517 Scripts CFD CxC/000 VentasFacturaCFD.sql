USE [RouteCPC]
GO

/****** Object:  Table [dbo].[VentasFacturaCFD]    Script Date: 05/15/2011 16:01:02 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[VentasFacturaCFD]') AND type in (N'U'))
DROP TABLE [dbo].[VentasFacturaCFD]
GO

USE [RouteCPC]
GO

/****** Object:  Table [dbo].[VentasFacturaCFD]    Script Date: 05/15/2011 16:01:02 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[VentasFacturaCFD](
	[IdCedis] [bigint] NOT NULL,
	[IdSurtido] [bigint] NOT NULL,
	[IdTipoVenta] [bigint] NOT NULL,
	[Serie] [varchar] (8) NOT NULL,
	[Folio] [bigint] NOT NULL,
	[SerieFactura] [varchar](6) NOT NULL,
	[FolioFactura] [bigint] NOT NULL,
	[TransprodId] [varchar](50) NOT NULL,
	[TransprodIdFactura] [varchar](50) NOT NULL,
	[Fecha] [datetime] NULL,
 CONSTRAINT [PK_VentasFacturaCFD] PRIMARY KEY CLUSTERED 
(
	[IdCedis] ASC,
	[IdSurtido] ASC,
	[IdTipoVenta] ASC,
	[Serie] ASC,
	[Folio] ASC,
	[SerieFactura] ASC,
	[FolioFactura] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


