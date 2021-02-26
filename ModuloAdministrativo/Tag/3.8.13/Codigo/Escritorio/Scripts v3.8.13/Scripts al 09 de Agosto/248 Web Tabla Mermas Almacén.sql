USE [RouteADM]
GO

/****** Object:  Table [dbo].[TipoMovimientoMerma]    Script Date: 08/06/2010 09:06:02 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TipoMovimientoMerma]') AND type in (N'U'))
DROP TABLE [dbo].[TipoMovimientoMerma]
GO

USE [RouteADM]
GO

/****** Object:  Table [dbo].[TipoMovimientoMerma]    Script Date: 08/06/2010 09:06:02 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TipoMovimientoMerma](
	[IdCedis] [bigint] NOT NULL,
	[IdTipoMovimiento] [bigint] NOT NULL,
 CONSTRAINT [PK_TipoMovimientoMerma] PRIMARY KEY CLUSTERED 
(
	[IdCedis] ASC,
	[IdTipoMovimiento] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


