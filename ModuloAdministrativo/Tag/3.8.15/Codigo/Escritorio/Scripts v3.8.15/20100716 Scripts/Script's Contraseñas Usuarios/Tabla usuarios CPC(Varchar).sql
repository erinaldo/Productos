USE [RouteCPC]
GO

/****** Object:  Table [dbo].[Usuarios]    Script Date: 07/07/2010 17:00:58 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

DROP TABLE Usuarios
CREATE TABLE [dbo].[Usuarios](
	[Login] [varchar](50) NOT NULL,
	[IdCedis] [bigint] NOT NULL,
	[Password] [varchar](8) NULL,
	[Nombre] [varchar](100) NULL,
	[ApPaterno] [varchar](50) NULL,
	[ApMaterno] [varchar](50) NULL,
	[TipoUsuario] [int] NULL,
	[Status] [char](1) NULL,
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[Login] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


