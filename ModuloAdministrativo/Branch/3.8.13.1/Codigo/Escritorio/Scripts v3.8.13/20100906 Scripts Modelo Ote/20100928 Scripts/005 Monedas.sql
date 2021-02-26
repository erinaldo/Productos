USE [RouteADM]
GO

/****** Object:  Table [dbo].[Monedas]    Script Date: 09/06/2010 15:02:04 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Monedas]') AND type in (N'U'))
DROP TABLE [dbo].[Monedas]
GO

USE [RouteADM]
GO

/****** Object:  Table [dbo].[Monedas]    Script Date: 09/06/2010 15:02:04 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Monedas](
	[IdMoneda] [varchar](5) NOT NULL,
	[Moneda] [varchar](25) NULL,
	[Status] [char](1) NULL,
 CONSTRAINT [PK_Monedas] PRIMARY KEY CLUSTERED 
(
	[IdMoneda] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


