
USE [RouteCPC]
GO

/****** Object:  Table [dbo].[tmp_MovimientosFacturas]    Script Date: 06/13/2011 19:33:02 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tmp_MovimientosFacturas]') AND type in (N'U'))
DROP TABLE [dbo].[tmp_MovimientosFacturas]
GO

USE [RouteCPC]
GO

/****** Object:  Table [dbo].[tmp_MovimientosFacturas]    Script Date: 06/13/2011 19:33:02 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[tmp_MovimientosFacturas](
	[IdCedis] [bigint] NOT NULL,
	[IdTipoVenta] [int] NOT NULL,
	[Serie] [varchar](5) NOT NULL,
	[Folio] [bigint] NOT NULL,
	[IdMovimiento] [bigint] NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[IdMovimientoDetalle] [bigint] NOT NULL,
	[IdDocumento] [varchar](5) NOT NULL,
	[IdTipoDocumento] [varchar](5) NOT NULL,
	[CargoAbono] [char](1) NOT NULL,
	[Referencia] [varchar](10) NULL,
	[ReferenciaBancos] [varchar](10) NULL,
	[Subtotal] [money] NULL,
	[Iva] [money] NULL,
	[Total]  AS ([Subtotal]+[Iva]),
	[Status] [char](1) NULL,
	[Login] [varchar](20) NOT NULL,
	[FechaEdicion] [datetime] NULL,
	[ImporteCancelado] [money] NULL,
 CONSTRAINT [PK_tmp_DocumentosAplicados] PRIMARY KEY CLUSTERED 
(
	[IdCedis] ASC,
	[IdTipoVenta] ASC,
	[Serie] ASC,
	[Folio] ASC,
	[IdMovimiento] ASC,
	[Fecha] ASC,
	[IdMovimientoDetalle] ASC,
	[IdDocumento] ASC,
	[IdTipoDocumento] ASC,
	[CargoAbono] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

