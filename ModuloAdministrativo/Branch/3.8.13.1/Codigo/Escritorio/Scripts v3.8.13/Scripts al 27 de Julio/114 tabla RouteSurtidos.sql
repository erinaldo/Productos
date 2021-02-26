USE [RouteADM]
GO

/****** Object:  Table [dbo].[RouteSurtidos]    Script Date: 05/27/2010 21:34:18 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[RouteSurtidos](
	[IdCedis] [bigint] NOT NULL,
	[IdSurtido] [bigint] NOT NULL,
	[IdCarga] [bigint] NOT NULL,
	[FolioRoute] [bigint] NOT NULL
 CONSTRAINT [PK_RouteSurtidos] PRIMARY KEY CLUSTERED 
(
	[IdCedis] ASC,
	[IdSurtido] ASC,
	[IdCarga] ASC,
	[FolioRoute] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
