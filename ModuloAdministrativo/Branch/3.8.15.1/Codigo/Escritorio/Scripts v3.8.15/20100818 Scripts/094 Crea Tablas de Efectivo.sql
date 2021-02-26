USE [RouteADM]
GO

/****** Object:  Table [dbo].[SurtidosCheque]    Script Date: 08/12/2010 09:19:01 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SurtidosCheque]') AND type in (N'U'))
DROP TABLE [dbo].[SurtidosCheque]
GO

/****** Object:  Table [dbo].[SurtidosDenominacion]    Script Date: 08/12/2010 09:19:01 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SurtidosDenominacion]') AND type in (N'U'))
DROP TABLE [dbo].[SurtidosDenominacion]
GO

/****** Object:  Table [dbo].[SurtidosFoliosLiquidacion]    Script Date: 08/12/2010 09:19:01 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SurtidosFoliosLiquidacion]') AND type in (N'U'))
DROP TABLE [dbo].[SurtidosFoliosLiquidacion]
GO

USE [RouteADM]
GO

/****** Object:  Table [dbo].[SurtidosCheque]    Script Date: 08/12/2010 09:19:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[SurtidosCheque](
	[IdCedis] [bigint] NOT NULL,
	[IdSurtido] [bigint] NOT NULL,
	[Folio] [bigint] NOT NULL,
	[IdCheque] [bigint] NOT NULL,
	[IdCajero] [varchar](20) NULL,
	[IdMoneda] [varchar](5) NOT NULL,
	[IdBanco] [bigint] NOT NULL,
	[Referencia] [varchar](30) NOT NULL,
	[Importe] [money] NULL,
 CONSTRAINT [PK_SurtidosCheque] PRIMARY KEY CLUSTERED 
(
	[IdCedis] ASC,
	[IdSurtido] ASC,
	[Folio] ASC,
	[IdCheque] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

USE [RouteADM]
GO

/****** Object:  Table [dbo].[SurtidosDenominacion]    Script Date: 08/12/2010 09:19:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[SurtidosDenominacion](
	[IdCedis] [bigint] NOT NULL,
	[IdSurtido] [bigint] NOT NULL,
	[Folio] [bigint] NOT NULL,
	[IdCajero] [varchar](20) NULL,
	[IdMoneda] [varchar](5) NOT NULL,
	[IdDenominacion] [money] NOT NULL,
	[TipoDenominacion] [char](1) NOT NULL,
	[Cantidad] [float] NULL,
 CONSTRAINT [PK_SurtidosDenominacion] PRIMARY KEY CLUSTERED 
(
	[IdCedis] ASC,
	[IdSurtido] ASC,
	[Folio] ASC,
	[IdMoneda] ASC,
	[IdDenominacion] ASC,
	[TipoDenominacion] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

USE [RouteADM]
GO

/****** Object:  Table [dbo].[SurtidosFoliosLiquidacion]    Script Date: 08/12/2010 09:19:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[SurtidosFoliosLiquidacion](
	[IdCedis] [bigint] NOT NULL,
	[IdSurtido] [bigint] NOT NULL,
	[Folio] [bigint] NOT NULL,
	[IdCajero] [varchar](20) NULL,
	[Status] [char](1) NULL,
 CONSTRAINT [PK_SurtidosFoliosLiquidacion] PRIMARY KEY CLUSTERED 
(
	[IdCedis] ASC,
	[IdSurtido] ASC,
	[Folio] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


