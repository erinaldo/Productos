
USE [RouteCPC]
GO

/****** Object:  Table [dbo].[Anticipos]    Script Date: 03/04/2011 19:26:16 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Anticipos]') AND type in (N'U'))
DROP TABLE [dbo].[Anticipos]
GO

USE [RouteCPC]
GO

/****** Object:  Table [dbo].[Anticipos]    Script Date: 03/04/2011 19:26:16 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Anticipos](
	[IdCedis] [bigint] NOT NULL,
	[IdTipoVenta] [int] NOT NULL,
	[Serie] [varchar](5) NOT NULL,
	[FolioAnticipo] [bigint] NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[IdCliente] [bigint] NOT NULL,
	[IdSucursal] [varchar](25) NOT NULL,
	[Importe] [money] NULL,
	[Saldo] [money] NULL,
	[Observaciones] [varchar] (2000) NULL,
	[Status] [char](1) NULL,
	[Login] [varchar](20) NOT NULL,
	[FechaEdicion] [datetime] NULL,
 CONSTRAINT [PK_Anticipos] PRIMARY KEY CLUSTERED 
(
	[IdCedis] ASC,
	[IdTipoVenta] ASC,
	[Serie] ASC,
	[FolioAnticipo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

