USE [RouteCPC]
GO

/****** Object:  Table [dbo].[LEYSucursal]    Script Date: 04/20/2011 12:04:22 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LEYSucursal]') AND type in (N'U'))
DROP TABLE [dbo].[LEYSucursal]
GO

USE [RouteCPC]
GO

/****** Object:  Table [dbo].[LEYSucursal]    Script Date: 04/20/2011 12:04:22 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[LEYSucursal](
	[IdCliente] [bigint] NOT NULL,
	[IdSucursal] [varchar](20) NOT NULL,
	[Ley] [varchar](20) NULL,
	[Login] [varchar](20) NULL,
	[FechaEdicion] [datetime] NOT NULL,
 CONSTRAINT [PK_LEYSucursal] PRIMARY KEY CLUSTERED 
(
	[IdCliente] ASC,
	[IdSucursal] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


