USE [RouteCPC]
GO

/****** Object:  Table [dbo].[Cuentas]    Script Date: 10/29/2010 12:59:44 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Cuentas]') AND type in (N'U'))
DROP TABLE [dbo].[Cuentas]
GO

USE [RouteCPC]
GO

/****** Object:  Table [dbo].[Cuentas]    Script Date: 10/29/2010 12:59:44 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Cuentas](
	[Concepto] [varchar](10) NOT NULL,
	[IdCedis] [bigint] NOT NULL,
	[IdConcepto] [varchar](50) NOT NULL,
	[Cuenta] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Cuentas] PRIMARY KEY CLUSTERED 
(
	[Concepto] ASC,
	[IdCedis] ASC,
	[IdConcepto] ASC,
	[Cuenta] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

