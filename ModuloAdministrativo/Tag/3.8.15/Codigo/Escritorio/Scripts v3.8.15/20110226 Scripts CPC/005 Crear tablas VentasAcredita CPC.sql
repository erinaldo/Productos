USE [RouteCPC]
GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF__VentasAcr__Statu__47477CBF]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[VentasAcredita] DROP CONSTRAINT [DF__VentasAcr__Statu__47477CBF]
END

GO

USE [RouteCPC]
GO

/****** Object:  Table [dbo].[VentasAcredita]    Script Date: 02/26/2011 12:49:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[VentasAcredita]') AND type in (N'U'))
DROP TABLE [dbo].[VentasAcredita]
GO

USE [RouteCPC]
GO

USE [RouteCPC]
GO

/****** Object:  Table [dbo].[VentasAcredita]    Script Date: 02/26/2011 12:49:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[VentasAcredita](
	[IdCedis] [bigint] NOT NULL,
	[IdTipoVenta] [int] NOT NULL,
	[Folio] [bigint] NOT NULL,
	[Serie] [varchar](5) NOT NULL,
	[Fecha] [datetime] NULL,
	[FechaAcredita] [datetime] NULL,
	[Login] [varchar](16) NULL,
	[FechaEntrega] [datetime] NULL,
	[FolioEntrega] [varchar](16) NULL,
	[Observaciones] [varchar](3000) NULL,
	[FolioCliente] [varchar](16) NULL,
	[Remision] [varchar](16) NULL,
	[Factura] [varchar](16) NULL,
	[Status] [varchar](1) NULL,
	[Vencimiento] [int] NULL,
	[StatusTransferido] [char](1) NULL,
 CONSTRAINT [PK_VentasAcredita] PRIMARY KEY CLUSTERED 
(
	[IdCedis] ASC,
	[IdTipoVenta] ASC,
	[Folio] ASC,
	[Serie] ASC	
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[VentasAcredita] ADD  DEFAULT ('N') FOR [StatusTransferido]
GO


