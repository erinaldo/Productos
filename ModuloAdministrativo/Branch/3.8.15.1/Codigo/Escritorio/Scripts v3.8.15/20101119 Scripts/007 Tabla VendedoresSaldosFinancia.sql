USE [RouteADM]
GO

/****** Object:  Table [dbo].[VendedoresSaldosFinancia]    Script Date: 11/16/2010 13:21:18 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[VendedoresSaldosFinancia]') AND type in (N'U'))
DROP TABLE [dbo].[VendedoresSaldosFinancia]
GO

USE [RouteADM]
GO

/****** Object:  Table [dbo].[VendedoresSaldosFinancia]    Script Date: 11/16/2010 13:21:18 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[VendedoresSaldosFinancia](
	[IdCedis] [bigint] NOT NULL,
	[IdCorto] [bigint] NOT NULL,
	[IdSurtido] [bigint] NULL,
	[IdVendedor] [bigint] NULL,
	[MontoFinanciar] [money] NULL,
	[Pagos] [money] NULL,
	[Frecuencia] [int] NULL,
	[FechaInicio] [datetime] NULL,
	[Autoriza] [varchar](75) NULL,
	[Concepto] [varchar](250) NULL,
	[Status] [char](1) NULL,
	[FechaElaboracion] [datetime] NULL,
 CONSTRAINT [PK_VendedoresSaldosFinancia] PRIMARY KEY CLUSTERED 
(
	[IdCedis] ASC,
	[IdCorto] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


