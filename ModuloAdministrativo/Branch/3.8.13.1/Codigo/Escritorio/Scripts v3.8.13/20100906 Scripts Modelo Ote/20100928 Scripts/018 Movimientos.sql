USE [RouteCPC]
GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_Movimientos_Status]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Movimientos] DROP CONSTRAINT [DF_Movimientos_Status]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_Movimientos_Login]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Movimientos] DROP CONSTRAINT [DF_Movimientos_Login]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_Movimientos_FechaEdicion]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Movimientos] DROP CONSTRAINT [DF_Movimientos_FechaEdicion]
END

GO

USE [RouteCPC]
GO

/****** Object:  Table [dbo].[Movimientos]    Script Date: 09/22/2010 13:58:18 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Movimientos]') AND type in (N'U'))
DROP TABLE [dbo].[Movimientos]
GO

USE [RouteCPC]
GO

/****** Object:  Table [dbo].[Movimientos]    Script Date: 09/22/2010 13:58:18 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Movimientos](
	[IdCedis] [bigint] NOT NULL,
	[IdMovimiento] [bigint] NOT NULL,
	[Fecha] [datetime] NULL,
	[IdDocumento] [varchar](5) NULL,
	[CargoAbono] [char](10) NULL,
	[Monto] [money] NULL,
	[Referencia] [varchar](10) NULL,
	[ReferenciaBancos] [varchar](10) NULL,
	[Observaciones] [varchar](2000) NULL,
	[Status] [char](1) NULL,
	[Login] [varchar](20) NULL,
	[FechaEdicion] [datetime] NULL,
 CONSTRAINT [PK_Movimientos] PRIMARY KEY CLUSTERED 
(
	[IdCedis] ASC,
	[IdMovimiento] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[Movimientos] ADD  CONSTRAINT [DF_Movimientos_Status]  DEFAULT ('A') FOR [Status]
GO

ALTER TABLE [dbo].[Movimientos] ADD  CONSTRAINT [DF_Movimientos_Login]  DEFAULT ('') FOR [Login]
GO

ALTER TABLE [dbo].[Movimientos] ADD  CONSTRAINT [DF_Movimientos_FechaEdicion]  DEFAULT (getdate()) FOR [FechaEdicion]
GO


