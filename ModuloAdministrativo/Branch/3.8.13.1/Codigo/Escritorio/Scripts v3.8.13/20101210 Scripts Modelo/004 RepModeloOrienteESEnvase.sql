USE [RouteADM]
GO

/****** Object:  Table [dbo].[RepModeloOrienteESEnvase]    Script Date: 11/17/2010 12:28:23 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[RepModeloOrienteESEnvase]') AND type in (N'U'))
DROP TABLE [dbo].[RepModeloOrienteESEnvase]
GO

USE [RouteADM]
GO

/****** Object:  Table [dbo].[RepModeloOrienteESEnvase]    Script Date: 11/17/2010 12:28:23 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[RepModeloOrienteESEnvase](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[IdCedis] [bigint] NOT NULL,
	[IdRuta] [bigint] NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[IdAgrupador] [int] NULL,
	[Titulo] [varchar](20) NULL,
	[Concepto] [varchar](30) NULL,
	[IdProd30] [varchar](15) NULL,
	[IdProd31] [varchar](15) NULL,
	[IdProd32] [varchar](15) NULL,
	[IdProd33] [varchar](15) NULL,
	[IdProd34] [varchar](15) NULL,
	[IdProd35] [varchar](15) NULL,
	[IdProd36] [varchar](15) NULL,
 CONSTRAINT [PK_RepModeloOrienteESEnvase] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


