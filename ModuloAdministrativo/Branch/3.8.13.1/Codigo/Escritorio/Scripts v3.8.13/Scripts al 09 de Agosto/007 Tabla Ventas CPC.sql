USE [RouteCPC]
GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_Ventas_Cargos]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Ventas] DROP CONSTRAINT [DF_Ventas_Cargos]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_Ventas_Abonos]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Ventas] DROP CONSTRAINT [DF_Ventas_Abonos]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_Ventas_Status]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Ventas] DROP CONSTRAINT [DF_Ventas_Status]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_Ventas_Login]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Ventas] DROP CONSTRAINT [DF_Ventas_Login]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_Ventas_FechaEdicion]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Ventas] DROP CONSTRAINT [DF_Ventas_FechaEdicion]
END

GO

USE [RouteCPC]
GO

/****** Object:  Table [dbo].[Ventas]    Script Date: 07/29/2010 17:45:47 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Ventas]') AND type in (N'U'))
DROP TABLE [dbo].[Ventas]
GO

USE [RouteCPC]
GO

/****** Object:  Table [dbo].[Ventas]    Script Date: 07/29/2010 17:45:47 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Ventas](
	[IdCedis] [bigint] NOT NULL,
	[IdTipoVenta] [int] NOT NULL,
	[Folio] [bigint] NOT NULL,
	[Serie] [varchar](5) NOT NULL,
	[Fecha] [datetime] NULL,
	[IdCliente] [bigint] NULL,
	[Subtotal] [money] NULL,
	[Iva] [money] NULL,
	[Total]  AS ([Subtotal]+[Iva]),
	[Cargos] [money] NULL,
	[Abonos] [money] NULL,
	[Saldo]  AS ((([Subtotal]+[Iva])+[Cargos])-[Abonos]),
	[DiasVencimiento] [int] NULL,
	[IdSucursal] [varchar](16) NULL,
	[IdMarca] [bigint] NULL,
	[FolioC] [varchar](16) NULL,
	[Status] [char](1) NULL,
	[Login] [varchar](20) NULL,
	[FechaEdicion] [datetime] NOT NULL,
 CONSTRAINT [PK_Ventas] PRIMARY KEY CLUSTERED 
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

ALTER TABLE [dbo].[Ventas] ADD  CONSTRAINT [DF_Ventas_Cargos]  DEFAULT ((0)) FOR [Cargos]
GO

ALTER TABLE [dbo].[Ventas] ADD  CONSTRAINT [DF_Ventas_Abonos]  DEFAULT ((0)) FOR [Abonos]
GO

ALTER TABLE [dbo].[Ventas] ADD  CONSTRAINT [DF_Ventas_Status]  DEFAULT ('') FOR [Status]
GO

ALTER TABLE [dbo].[Ventas] ADD  CONSTRAINT [DF_Ventas_Login]  DEFAULT ('') FOR [Login]
GO

ALTER TABLE [dbo].[Ventas] ADD  CONSTRAINT [DF_Ventas_FechaEdicion]  DEFAULT (getdate()) FOR [FechaEdicion]
GO

