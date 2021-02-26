USE [RouteADM]
GO

/****** Object:  Table [dbo].[VentasCanceladas]    Script Date: 07/13/2010 13:30:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[VentasCanceladas]') AND type in (N'U'))
DROP TABLE [dbo].[VentasCanceladas]
GO

USE [RouteADM]
GO

/****** Object:  Table [dbo].[VentasCanceladas]    Script Date: 07/13/2010 13:30:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[VentasCanceladas](
	[IdCedis] [bigint] NOT NULL,
	[IdSurtido] [bigint] NOT NULL,
	[IdTipoVenta] [int] NOT NULL,
	[Folio] [bigint] NOT NULL,
	[Serie] [varchar](5) NOT NULL,
	[Fecha] [datetime] NULL,
	[IdCliente] [bigint] NULL,
	[Subtotal] [money] NULL,
	[Iva] [money] NULL,
	[Total]  AS ([Subtotal] - [DctoImp] +[Iva]),
	[IdSucursal] [varchar](16) NULL,
	[DctoImp] [money] NULL,
	[DiasCredito] [int] NULL,
CONSTRAINT [PK_VentasCanceladas] PRIMARY KEY CLUSTERED 
(
	[IdCedis] ASC,
	[IdSurtido] ASC,
	[IdTipoVenta] ASC,
	[Folio] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


