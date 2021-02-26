USE [RouteCPC]
GO

/****** Object:  Table [dbo].[UsuariosLogin]    Script Date: 03/04/2011 10:19:54 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UsuariosLogin]') AND type in (N'U'))
DROP TABLE [dbo].[UsuariosLogin]
GO

USE [RouteCPC]
GO

/****** Object:  Table [dbo].[UsuariosLogin]    Script Date: 03/04/2011 10:19:54 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[UsuariosLogin](
	[Login] [varchar](20) NOT NULL,
	[LoginD] [varchar](20) NOT NULL,
 CONSTRAINT [PK_UsuariosLogin] PRIMARY KEY CLUSTERED 
(
	[Login] ASC,
	[LoginD] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


