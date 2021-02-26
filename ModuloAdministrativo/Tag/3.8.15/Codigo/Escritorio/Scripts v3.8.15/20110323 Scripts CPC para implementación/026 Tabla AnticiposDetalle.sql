
USE [RouteCPC]
GO

/****** Object:  Table [dbo].[AnticiposDetalle]    Script Date: 03/04/2011 19:26:16 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AnticiposDetalle]') AND type in (N'U'))
DROP TABLE [dbo].[AnticiposDetalle]
GO

USE [RouteCPC]
GO

/****** Object:  Table [dbo].[AnticiposDetalle]    Script Date: 03/04/2011 19:26:16 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[AnticiposDetalle](
	[FolioAnticipo] [bigint] NOT NULL,
	[IdCedis] [bigint] NOT NULL,
	[IdTipoVenta] [int] NOT NULL,
	[Serie] [varchar](5) NOT NULL,
	[Folio] [bigint] NOT NULL,
	[IdCedisMov] [bigint] NOT NULL,
	[IdMovimiento] [bigint] NOT NULL,
	[IdMovimientoDetalle] [bigint] NOT NULL,
	[IdCedisCargoAnt] [bigint] NOT NULL,
	[IdMovimientoCargoAnt] [bigint] NOT NULL,
	[IdMovimientoDetalleCargoAnt] [bigint] NOT NULL,
	[Status] [char](1) NULL,
	[Login] [varchar](20) NOT NULL,
	[FechaEdicion] [datetime] NULL,
 CONSTRAINT [PK_AnticiposDetalle] PRIMARY KEY CLUSTERED 
(
	[FolioAnticipo] ASC,
	[Folio] ASC,
	[IdCedisMov] ASC,
	[IdMovimiento] ASC,
	[IdMovimientoDetalle] ASC,
	[IdCedisCargoAnt] ASC,
	[IdMovimientoCargoAnt] ASC,
	[IdMovimientoDetalleCargoAnt] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

