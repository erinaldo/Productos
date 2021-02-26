USE [RouteCPC]
GO


/****** Object:  Table [dbo].[ClientesFacturacion]    Script Date: 03/21/2011 11:10:54 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ClientesFacturacion]') AND type in (N'U'))
DROP TABLE [dbo].[ClientesFacturacion]
GO

USE [RouteCPC]
GO

/****** Object:  Table [dbo].[ClientesFacturacion]    Script Date: 03/21/2011 11:10:54 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[ClientesFacturacion](
	[IdCedis] [bigint] NOT NULL,
	[IdCliente] [bigint] NOT NULL,
	[Login] [varchar](20) NULL,
	[FechaEdicion] [datetime] NOT NULL,
 CONSTRAINT [PK_ClientesFacturacion] PRIMARY KEY CLUSTERED 
(
	[IdCedis] ASC,
	[IdCliente] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

