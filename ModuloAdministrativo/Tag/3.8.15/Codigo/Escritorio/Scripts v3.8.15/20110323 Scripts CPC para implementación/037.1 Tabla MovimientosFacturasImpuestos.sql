
USE [RouteCPC]
GO

/****** Object:  Table [dbo].[MovimientosFacturasImpuestos]    Script Date: 03/10/2011 11:29:10 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MovimientosFacturasImpuestos]') AND type in (N'U'))
DROP TABLE [dbo].[MovimientosFacturasImpuestos]
GO

USE [RouteCPC]
GO

/****** Object:  Table [dbo].[MovimientosFacturasImpuestos]    Script Date: 03/10/2011 11:29:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[MovimientosFacturasImpuestos](
	[IdCedis] [bigint] NOT NULL,
	[IdTipoVenta] [int] NOT NULL,
	[Serie] [varchar](5) NOT NULL,
	[Folio] [bigint] NOT NULL,
	[IdMovimiento] [bigint] NOT NULL,
	[IdMovimientoDetalle] [bigint] NOT NULL,
	[IdDocumento] [varchar](5) NOT NULL,
	[IdTipoDocumento] [varchar](5) NOT NULL,
	[IdProducto] [varchar] (200) NOT NULL,
	[IdImpuesto] [bigint] NOT NULL,
	[Tasa] [float] NULL,
	[Login] [varchar](20) NOT NULL,
	[FechaEdicion] [datetime] NULL,
	
 CONSTRAINT [PK_MovimientosFacturasImpuesto] PRIMARY KEY CLUSTERED 
(
	[IdCedis] ASC,
	[IdTipoVenta] ASC,
	[Serie] ASC,
	[Folio] ASC,
	[IdMovimiento] ASC,
	[IdMovimientoDetalle] ASC,
	[IdDocumento] ASC,
	[IdTipoDocumento] ASC,
	[IdProducto] ASC,
	[IdImpuesto] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[MovimientosFacturasImpuestos] ADD  CONSTRAINT [DF_MovimientosFacturasImpuestos_Login]  DEFAULT ('') FOR [Login]
GO

ALTER TABLE [dbo].[MovimientosFacturasImpuestos] ADD  CONSTRAINT [DF_MovimientosFacturasImpuestos_Fecha]  DEFAULT (getdate()) FOR [FechaEdicion]
GO


