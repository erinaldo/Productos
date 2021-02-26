USE [RouteADM]
GO

/****** Object:  Table [dbo].[VentasDetalle]    Script Date: 01/12/2011 16:26:11 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[VentasDetalle2]') AND type in (N'U'))
DROP TABLE [dbo].[VentasDetalle2]
GO

USE [RouteADM]
GO

/****** Object:  Table [dbo].[VentasDetalle]    Script Date: 01/12/2011 16:26:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[VentasDetalle2](
	[IdCedis] [bigint] NOT NULL,
	[IdSurtido] [bigint] NOT NULL,
	[IdTipoVenta] [int] NOT NULL,
	[Folio] [bigint] NOT NULL,
	[IdProducto] [bigint] NOT NULL,
	[Serie] [varchar](5) NOT NULL,
	[Cantidad] [decimal](19, 4) NULL,
	[Precio] [money] NULL,
	[Iva] [float] NULL,
	[Subtotal]  AS ([Cantidad] * [Precio]),
	[Total]  AS ([Cantidad] * [Precio] * (1 + [Iva])),
 CONSTRAINT [PK_VentasDetalle2] PRIMARY KEY CLUSTERED 
(
	[IdCedis] ASC,
	[IdSurtido] ASC,
	[IdTipoVenta] ASC,
	[Folio] ASC,
	[IdProducto] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

insert into VentasDetalle2 
select IdCedis, IdSurtido, IdTipoVenta, Folio, IdProducto, Serie, Cantidad, Precio,Iva
from VentasDetalle 

USE [RouteADM]
GO

/****** Object:  Table [dbo].[VentasDetalle]    Script Date: 01/12/2011 16:26:11 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[VentasDetalle]') AND type in (N'U'))
DROP TABLE [dbo].[VentasDetalle]
GO

USE [RouteADM]
GO

/****** Object:  Table [dbo].[VentasDetalle]    Script Date: 01/12/2011 16:26:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[VentasDetalle](
	[IdCedis] [bigint] NOT NULL,
	[IdSurtido] [bigint] NOT NULL,
	[IdTipoVenta] [int] NOT NULL,
	[Folio] [bigint] NOT NULL,
	[IdProducto] [bigint] NOT NULL,
	[Serie] [varchar](5) NOT NULL,
	[Cantidad] [decimal](19, 4) NULL,
	[Precio] [decimal](19, 9) NULL,
	[Iva] [float] NULL,
	[Subtotal]  AS ([Cantidad] * [Precio]),
	[Total]  AS ([Cantidad] * [Precio] * (1 + [Iva])),
 CONSTRAINT [PK_VentasDetalle] PRIMARY KEY CLUSTERED 
(
	[IdCedis] ASC,
	[IdSurtido] ASC,
	[IdTipoVenta] ASC,
	[Folio] ASC,
	[IdProducto] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

insert into VentasDetalle
select IdCedis, IdSurtido, IdTipoVenta, Folio, IdProducto, Serie, Cantidad, Precio,Iva
from VentasDetalle2

/****** Object:  Table [dbo].[VentasDetalle]    Script Date: 01/12/2011 16:26:11 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[VentasDetalle2]') AND type in (N'U'))
DROP TABLE [dbo].[VentasDetalle2]
GO
