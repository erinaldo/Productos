USE [RouteADM]
GO

/****** Object:  Table [dbo].[CargasSugeridas]    Script Date: 08/11/2010 10:40:50 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CargasSugeridas]') AND type in (N'U'))
DROP TABLE [dbo].[CargasSugeridas]
GO

/****** Object:  Table [dbo].[CargasSugeridasDetalle]    Script Date: 08/11/2010 10:40:50 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CargasSugeridasDetalle]') AND type in (N'U'))
DROP TABLE [dbo].[CargasSugeridasDetalle]
GO

/****** Object:  Table [dbo].[CargasSugeridasFamilia]    Script Date: 08/11/2010 10:40:50 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CargasSugeridasFamilia]') AND type in (N'U'))
DROP TABLE [dbo].[CargasSugeridasFamilia]
GO

/****** Object:  Table [dbo].[CargasSugeridasProducto]    Script Date: 08/11/2010 10:40:50 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CargasSugeridasProducto]') AND type in (N'U'))
DROP TABLE [dbo].[CargasSugeridasProducto]
GO

/****** Object:  Table [dbo].[CargasSugeridasRuta]    Script Date: 08/11/2010 10:40:50 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CargasSugeridasRuta]') AND type in (N'U'))
DROP TABLE [dbo].[CargasSugeridasRuta]
GO

USE [RouteADM]
GO

/****** Object:  Table [dbo].[CargasSugeridas]    Script Date: 08/11/2010 10:40:51 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[CargasSugeridas](
	[IdCedis] [bigint] NOT NULL,
	[IdRuta] [bigint] NOT NULL,
	[FechaCarga] [datetime] NOT NULL,
	[Tipo] [char](1) NOT NULL,
	[Folio] [bigint] NOT NULL,
	[IdSurtido] [bigint] NULL,
	[IdCarga] [bigint] NULL,
	[Status] [char](1) NULL,
 CONSTRAINT [PK_CargasSugeridas] PRIMARY KEY CLUSTERED 
(
	[IdCedis] ASC,
	[IdRuta] ASC,
	[FechaCarga] ASC,
	[Tipo] ASC,
	[Folio] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

USE [RouteADM]
GO

/****** Object:  Table [dbo].[CargasSugeridasDetalle]    Script Date: 08/11/2010 10:40:51 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[CargasSugeridasDetalle](
	[IdCedis] [bigint] NOT NULL,
	[IdRuta] [bigint] NOT NULL,
	[FechaCarga] [datetime] NOT NULL,
	[IdProducto] [bigint] NOT NULL,
	[Tipo] [char](1) NOT NULL,
	[Folio] [bigint] NOT NULL,
	[Venta] [decimal](18, 6) NULL,
	[Cantidad] [decimal](18, 6) NULL,
	[Cambios] [decimal](18, 6) NULL,
 CONSTRAINT [PK_CargasSugeridasDetalle] PRIMARY KEY CLUSTERED 
(
	[IdCedis] ASC,
	[IdRuta] ASC,
	[FechaCarga] ASC,
	[IdProducto] ASC,
	[Tipo] ASC,
	[Folio] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

USE [RouteADM]
GO

/****** Object:  Table [dbo].[CargasSugeridasFamilia]    Script Date: 08/11/2010 10:40:51 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CargasSugeridasFamilia](
	[IdCedis] [bigint] NOT NULL,
	[IdRuta] [bigint] NOT NULL,
	[FechaCarga] [datetime] NOT NULL,
	[Folio] [bigint] NOT NULL,
	[IdFamilia] [bigint] NOT NULL,
	[Semanas] [int] NULL,
	[Porcentaje] [float] NULL,
 CONSTRAINT [PK_CargasSugeridasFamilia] PRIMARY KEY CLUSTERED 
(
	[IdCedis] ASC,
	[IdRuta] ASC,
	[FechaCarga] ASC,
	[Folio] ASC,
	[IdFamilia] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

USE [RouteADM]
GO

/****** Object:  Table [dbo].[CargasSugeridasProducto]    Script Date: 08/11/2010 10:40:51 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CargasSugeridasProducto](
	[IdCedis] [bigint] NOT NULL,
	[IdRuta] [bigint] NOT NULL,
	[FechaCarga] [datetime] NOT NULL,
	[Folio] [bigint] NOT NULL,
	[IdProducto] [bigint] NOT NULL,
	[Semanas] [int] NULL,
	[Porcentaje] [float] NULL,
 CONSTRAINT [PK_CargasSugeridasProducto] PRIMARY KEY CLUSTERED 
(
	[IdCedis] ASC,
	[IdRuta] ASC,
	[FechaCarga] ASC,
	[Folio] ASC,
	[IdProducto] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

USE [RouteADM]
GO

/****** Object:  Table [dbo].[CargasSugeridasRuta]    Script Date: 08/11/2010 10:40:51 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[CargasSugeridasRuta](
	[IdCedis] [bigint] NOT NULL,
	[IdRuta] [bigint] NOT NULL,
	[FechaCarga] [datetime] NOT NULL,
	[Folio] [bigint] NOT NULL,
	[IdRutaPedido] [varchar](5) NOT NULL,
	[FechaInicial] [datetime] NULL,
	[FechaFinal] [datetime] NULL,
 CONSTRAINT [PK_CargasSugeridasRuta] PRIMARY KEY CLUSTERED 
(
	[IdCedis] ASC,
	[IdRuta] ASC,
	[FechaCarga] ASC,
	[Folio] ASC,
	[IdRutaPedido] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


