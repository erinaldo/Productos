USE [RouteCPC]
GO

/****** Object:  Table [dbo].[Promociones]    Script Date: 03/27/2011 23:09:59 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Promociones]') AND type in (N'U'))
DROP TABLE [dbo].[Promociones]
GO

USE [RouteCPC]
GO

/****** Object:  Table [dbo].[Promociones]    Script Date: 03/27/2011 23:09:59 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Promociones](
	[IdPromocion] [bigint] NOT NULL,
	[Nombre] [varchar](100) NULL,
	[Observaciones] [varchar](400) NULL,
	[FechaInicial] [datetime] NULL,
	[FechaFinal] [datetime] NULL,
	[IdDocumento] [varchar](5) NULL,
	[IdTipoDocumento] [varchar](5) NULL,
	[Status] [char](1) NULL,
 	[Login] [varchar](20) NULL,
	[FechaEdicion] [datetime] NULL,
CONSTRAINT [PK_Promociones] PRIMARY KEY CLUSTERED 
(
	[IdPromocion] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


