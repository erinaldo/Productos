USE [RouteADM]
GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF__Ventas__IdSucurs__37FA4C37]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Ventas] DROP CONSTRAINT [DF__Ventas__IdSucurs__37FA4C37]
END

GO

USE [RouteADM]
GO

/****** Object:  Table [dbo].[VentasAcredita]    Script Date: 07/13/2010 13:24:23 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[VentasAcredita]') AND type in (N'U'))
DROP TABLE [dbo].[VentasAcredita]
GO

USE [RouteADM]
GO

/****** Object:  Table [dbo].[VentasAcredita]    Script Date: 07/13/2010 13:24:23 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[VentasAcredita](
	[IdCedis] [bigint] NOT NULL,
	[IdSurtido] [bigint] NOT NULL,
	[IdTipoVenta] [int] NOT NULL,
	[Folio] [bigint] NOT NULL,
	[Serie] [varchar](5) NOT NULL,
	[Fecha] [datetime] NULL,
	[FechaAcredita] [datetime] NULL,
	[Login] [varchar](16) NULL,
	[FechaEntrega] [datetime] NULL,
	[FolioEntrega] [varchar](16) NULL,
	[Observaciones] [varchar](3000) NULL,
 CONSTRAINT [PK_VentasAcredita] PRIMARY KEY CLUSTERED 
(
	[IdCedis] ASC,
	[IdSurtido] ASC,
	[IdTipoVenta] ASC,
	[Folio] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

