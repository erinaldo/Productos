USE [RouteCPC]
GO

/****** Object:  Table [dbo].[Folio]    Script Date: 03/01/2011 09:26:13 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Folio]') AND type in (N'U'))
DROP TABLE [dbo].[Folio]
GO

USE [RouteCPC]
GO

/****** Object:  Table [dbo].[Folio]    Script Date: 03/01/2011 09:26:13 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Folio](
	[Folio] [bigint] NOT NULL,
	[Fecha] [datetime] NULL,
	[Monto] [money] NULL,
	[Observaciones] [varchar](5000) NULL,
	[Status] [char](1) NULL,
	[Login] [varchar](20) NULL,
	[FechaEdicion] [datetime] NULL,
 CONSTRAINT [PK_Folio] PRIMARY KEY CLUSTERED 
(
	[Folio] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


