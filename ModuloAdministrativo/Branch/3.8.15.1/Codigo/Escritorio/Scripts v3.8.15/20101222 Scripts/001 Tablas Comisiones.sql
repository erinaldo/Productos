USE [RouteADM]
GO

/****** Object:  Table [dbo].[tempComisiones]    Script Date: 12/28/2010 12:58:23 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tempComisiones]') AND type in (N'U'))
DROP TABLE [dbo].[tempComisiones]
GO

/****** Object:  Table [dbo].[tempComisionesDetalle]    Script Date: 12/28/2010 12:58:23 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tempComisionesDetalle]') AND type in (N'U'))
DROP TABLE [dbo].[tempComisionesDetalle]
GO

USE [RouteADM]
GO

/****** Object:  Table [dbo].[tempComisiones]    Script Date: 12/28/2010 12:58:24 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[tempComisiones](
	[IdCedis] [bigint] NULL,
	[Fecha] [datetime] NULL,
	[IdVendedor] [bigint] NULL,
	[Nomina] [varchar](20) NULL,
	[Vendedor] [varchar](200) NULL,
	[VentaTotal] [money] NULL,
	[Comision] [money] NULL,
	[AbonoMerma] [money] NULL,
	[AbonoVolumen] [money] NULL,
	[CargoMerma] [money] NULL,
	[SaldoVendedor] [money] NULL,
	[TotalPago] [money] NULL,
	[Saldo] [money] NULL,
	[Financiamientos] [money] NULL,
	[CreditosInformales] [money] NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

USE [RouteADM]
GO

/****** Object:  Table [dbo].[tempComisionesDetalle]    Script Date: 12/28/2010 12:58:24 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[tempComisionesDetalle](
	[IdCedis] [bigint] NULL,
	[Fecha] [datetime] NULL,
	[IdVendedor] [bigint] NULL,
	[Nomina] [varchar](20) NULL,
	[Vendedor] [varchar](200) NULL,
	[VentaTotal] [money] NULL,
	[Comision] [money] NULL,
	[AbonoMerma] [money] NULL,
	[AbonoVolumen] [money] NULL,
	[CargoMerma] [money] NULL,
	[SaldoVendedor] [money] NULL,
	[TotalPago] [money] NULL,
	[Saldo] [money] NULL,
	[Financiamientos] [money] NULL,
	[CreditosInformales] [money] NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


