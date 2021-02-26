USE [RouteCPC]
GO

/****** Object:  Table [dbo].[PromocionesAplicadasDetalle]    Script Date: 03/30/2011 19:45:26 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PromocionesAplicadasDetalle]') AND type in (N'U'))
DROP TABLE [dbo].[PromocionesAplicadasDetalle]
GO

USE [RouteCPC]
GO

/****** Object:  Table [dbo].[PromocionesAplicadasDetalle]    Script Date: 03/30/2011 19:45:26 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[PromocionesAplicadasDetalle](
	[IdAplicacion] [bigint] NOT NULL,
	[IdPromocion] [bigint] NOT NULL,
	[IdCedis] [bigint] NOT NULL,
	[IdTipoVenta] [int] NOT NULL,
	[Serie] [varchar](5) NOT NULL,
	[Folio] [bigint] NOT NULL,
	[Fecha] [datetime] NULL,
	[IdCliente] [bigint] NULL,
	[Saldo] [money] NULL,
	[IdMovimiento] [bigint] NULL,
	[IdDocumento] [varchar](5) NULL,
	[IdTipoDocumento] [varchar](5) NULL,
	[Monto] [money] NULL,
	[IdAplicacionAnterior] [bigint] NULL,
	[IdPromocionAnterior] [bigint] NULL,
	[Aplicado] [varchar](100) NULL,
 CONSTRAINT [PK_PromocionesAplicadasDetalle] PRIMARY KEY CLUSTERED 
(
	[IdAplicacion] ASC,
	[IdPromocion] ASC,
	[IdCedis] ASC,
	[IdTipoVenta] ASC,
	[Serie] ASC,
	[Folio] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


