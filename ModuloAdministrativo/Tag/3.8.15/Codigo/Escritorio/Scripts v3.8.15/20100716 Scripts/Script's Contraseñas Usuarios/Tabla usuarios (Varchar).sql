USE [RouteADM]
GO

/****** Object:  Table [dbo].[Usuarios]    Script Date: 07/07/2010 15:40:55 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO


DROP TABLE Usuarios
CREATE TABLE [dbo].[Usuarios](
	[IdCedis] [bigint] NOT NULL,
	[Login] [varchar](50) NOT NULL,
	[Password] [varchar](8) NULL,
	[Nombre] [varchar](100) NULL,
	[ApPaterno] [varchar](50) NULL,
	[ApMaterno] [varchar](50) NULL,
	[TipoUsuario] [int] NULL,
	[Status] [char](1) NULL,
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[IdCedis] ASC,
	[Login] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


