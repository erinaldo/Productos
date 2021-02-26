USE [RouteADM]
GO

/****** Object:  Table [dbo].[VendedoresSaldosFinancia]    Script Date: 08/18/2010 16:44:16 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[VendedoresSaldosFinancia]') AND type in (N'U'))
DROP TABLE [dbo].[VendedoresSaldosFinancia]
GO

/****** Object:  Table [dbo].[VendedoresSaldosFinanciaD]    Script Date: 08/18/2010 16:44:16 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[VendedoresSaldosFinanciaD]') AND type in (N'U'))
DROP TABLE [dbo].[VendedoresSaldosFinanciaD]
GO

/****** Object:  Table [dbo].[VendedoresSaldosValida]    Script Date: 08/18/2010 16:44:16 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[VendedoresSaldosValida]') AND type in (N'U'))
DROP TABLE [dbo].[VendedoresSaldosValida]
GO

USE [RouteADM]
GO

/****** Object:  Table [dbo].[VendedoresSaldosFinancia]    Script Date: 08/18/2010 16:44:16 ******/
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
	[Pagos] [int] NULL,
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

USE [RouteADM]
GO

/****** Object:  Table [dbo].[VendedoresSaldosFinanciaD]    Script Date: 08/18/2010 16:44:17 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[VendedoresSaldosFinanciaD](
	[IdCedis] [bigint] NOT NULL,
	[IdCorto] [bigint] NOT NULL,
	[IdSurtido] [bigint] NULL,
	[IdVendedor] [bigint] NULL,
	[IdPago] [bigint] NOT NULL,
	[Monto] [money] NULL,
	[Fecha] [datetime] NULL,
	[Status] [char](1) NULL,
 CONSTRAINT [PK_VendedoresSaldosFinanciaD] PRIMARY KEY CLUSTERED 
(
	[IdCedis] ASC,
	[IdCorto] ASC,
	[IdPago] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

USE [RouteADM]
GO

/****** Object:  Table [dbo].[VendedoresSaldosValida]    Script Date: 08/18/2010 16:44:17 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[VendedoresSaldosValida](
	[IdCedis] [bigint] NOT NULL,
	[IdSurtido] [bigint] NOT NULL,
	[IdTipoSaldo] [char](2) NOT NULL,
	[IdVendedor] [bigint] NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[Saldo] [money] NULL,
	[Financiado] [money] NULL,
	[SaldoVencido] [money] NULL,
	[Creditos] [money] NULL,
	[Bolsa] [money] NULL,
	[Ajuste] [money] NULL,
	[Resultado] [money] NULL,
	[Observaciones] [varchar](500) NULL,
	[Login] [varchar](20) NULL,
 CONSTRAINT [PK_VendedoresSaldosValida_1] PRIMARY KEY CLUSTERED 
(
	[IdCedis] ASC,
	[IdSurtido] ASC,
	[IdTipoSaldo] ASC,
	[IdVendedor] ASC,
	[Fecha] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


