
USE [RouteCPC]
GO

/****** Object:  Table [dbo].[MovimientosFacturasDetalle]    Script Date: 03/10/2011 11:29:10 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MovimientosFacturasDetalle]') AND type in (N'U'))
DROP TABLE [dbo].[MovimientosFacturasDetalle]
GO

USE [RouteCPC]
GO

/****** Object:  Table [dbo].[MovimientosFacturasDetalle]    Script Date: 03/10/2011 11:29:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[MovimientosFacturasDetalle](
	[IdCedis] [bigint] NOT NULL,
	[IdTipoVenta] [int] NOT NULL,
	[Serie] [varchar](5) NOT NULL,
	[Folio] [bigint] NOT NULL,
	[IdMovimiento] [bigint] NOT NULL,
	[IdMovimientoDetalle] [bigint] NOT NULL,
	[IdDocumento] [varchar](5) NOT NULL,
	[IdTipoDocumento] [varchar](5) NOT NULL,
	[IdProducto] [varchar](200) NOT NULL,
	[Producto] [varchar](200) NULL,
	[Cantidad] [decimal](19, 4) NULL,
	[Precio] [money] NULL,
	[Iva] [float] NOT NULL,
	[Subtotal]  AS ([Cantidad]*[Precio]),
	[Total]  AS (([Cantidad]*[Precio])*((1)+[Iva])),
	[Status] [char](1) NULL,
	[Login] [varchar](20) NOT NULL,
	[FechaEdicion] [datetime] NULL,
 CONSTRAINT [PK_MovimientosFacturasDetalle] PRIMARY KEY CLUSTERED 
(
	[IdCedis] ASC,
	[IdTipoVenta] ASC,
	[Serie] ASC,
	[Folio] ASC,
	[IdMovimiento] ASC,
	[IdMovimientoDetalle] ASC,
	[IdDocumento] ASC,
	[IdTipoDocumento] ASC,
	[IdProducto] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[MovimientosFacturasDetalle] ADD  CONSTRAINT [DF_MovimientosFacturasDetalle_Status]  DEFAULT ('A') FOR [Status]
GO

ALTER TABLE [dbo].[MovimientosFacturasDetalle] ADD  CONSTRAINT [DF_MovimientosFacturasDetalle_Login]  DEFAULT ('') FOR [Login]
GO

ALTER TABLE [dbo].[MovimientosFacturasDetalle] ADD  CONSTRAINT [DF_MovimientosFacturasDetalle_Fecha]  DEFAULT (getdate()) FOR [FechaEdicion]
GO


