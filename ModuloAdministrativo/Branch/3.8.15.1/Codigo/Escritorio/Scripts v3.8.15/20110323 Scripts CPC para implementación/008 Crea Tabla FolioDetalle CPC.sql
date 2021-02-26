USE [RouteCPC]
GO

/****** Object:  Table [dbo].[FolioDetalle]    Script Date: 03/01/2011 09:30:31 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FolioDetalle]') AND type in (N'U'))
DROP TABLE [dbo].[FolioDetalle]
GO

USE [RouteCPC]
GO

/****** Object:  Table [dbo].[FolioDetalle]    Script Date: 03/01/2011 09:30:31 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[FolioDetalle](
	[Folio] [bigint] NOT NULL,
	[IdCedis] [bigint] NOT NULL,
	[IdMovimiento] [bigint] NOT NULL,
	[IdDocumento] [varchar](5) NOT NULL,
	[CargoAbono] [char](10) NOT NULL,
	[Status] [char](1) NOT NULL,
	[Login] [varchar](20) NULL,
	[FechaEdicion] [datetime] NULL,
 CONSTRAINT [PK_FolioDetalle] PRIMARY KEY CLUSTERED 
(
	[Folio] ASC,
	[IdCedis] ASC,
	[IdMovimiento] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


