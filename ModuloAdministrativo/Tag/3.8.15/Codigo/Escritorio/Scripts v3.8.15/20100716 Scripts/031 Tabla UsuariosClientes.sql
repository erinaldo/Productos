USE [RouteCPC]
GO

/****** Object:  Table [dbo].[UsuariosClientes]    Script Date: 07/15/2010 15:06:23 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UsuariosClientes]') AND type in (N'U'))
DROP TABLE [dbo].[UsuariosClientes]
GO

USE [RouteCPC]
GO

/****** Object:  Table [dbo].[UsuariosClientes]    Script Date: 07/15/2010 15:06:23 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[UsuariosClientes](
	[Login] [varchar](50) NOT NULL,
	[IdCedis] [bigint] NOT NULL,
	[IdCliente] [bigint] NOT NULL,
 CONSTRAINT [PK_UsuariosClientes] PRIMARY KEY CLUSTERED 
(
	[Login] ASC,
	[IdCedis] ASC,
	[IdCliente] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


