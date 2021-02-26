USE [RouteADM]
GO

/****** Object:  Table [dbo].[RepModeloOrienteES]    Script Date: 12/15/2010 10:54:59 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[RepModeloOrienteES]') AND type in (N'U'))
DROP TABLE [dbo].[RepModeloOrienteES]
GO

USE [RouteADM]
GO

/****** Object:  Table [dbo].[RepModeloOrienteES]    Script Date: 12/15/2010 10:54:59 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[RepModeloOrienteES](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[IdCedis] [bigint] NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[IdAgrupador] [int] NULL,
	[IdRuta] [bigint] NULL,
	[Titulo] [varchar](20) NULL,
	[Concepto] [varchar](30) NULL,
	[IdProd1] [varchar](15) NULL,
	[IdProd2] [varchar](15) NULL,
	[IdProd3] [varchar](15) NULL,
	[IdProd4] [varchar](15) NULL,
	[IdProd5] [varchar](15) NULL,
	[IdProd6] [varchar](15) NULL,
	[IdProd7] [varchar](15) NULL,
	[IdProd8] [varchar](15) NULL,
	[IdProd9] [varchar](15) NULL,
	[IdProd10] [varchar](15) NULL,
	[IdProd11] [varchar](15) NULL,
	[IdProd12] [varchar](15) NULL,
	[IdProd13] [varchar](15) NULL,
	[IdProd14] [varchar](15) NULL,
	[IdProd15] [varchar](15) NULL,
	[IdProd16] [varchar](15) NULL,
	[IdProd17] [varchar](15) NULL,
	[IdProd18] [varchar](15) NULL,
	[IdProd19] [varchar](15) NULL,
	[IdProd20] [varchar](15) NULL,
	[IdProd21] [varchar](15) NULL,
	[IdProd22] [varchar](15) NULL,
	[IdProd23] [varchar](15) NULL,
	[IdProd24] [varchar](15) NULL,
	[IdProd25] [varchar](15) NULL,
	[IdProd26] [varchar](15) NULL,
	[IdProd27] [varchar](15) NULL,
	[IdProd28] [varchar](15) NULL,
	[IdProd29] [varchar](15) NULL,
	[IdProd51] [varchar](15) NULL,
	[IdProd61] [varchar](15) NULL,
 CONSTRAINT [PK_RepModeloOrienteES] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


