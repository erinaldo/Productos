USE [RouteADM]
GO

/****** Object:  Table [dbo].[ComEsquemaVendedor]    Script Date: 11/28/2010 16:35:47 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ComEsquemaVendedor]') AND type in (N'U'))
DROP TABLE [dbo].[ComEsquemaVendedor]
GO

USE [RouteADM]
GO

/****** Object:  Table [dbo].[ComEsquemaVendedor]    Script Date: 11/28/2010 16:35:47 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[ComEsquemaVendedor](
	[IdComEsquema] [bigint] NOT NULL,
	[IdCedis] [bigint] NOT NULL,
	[IdVendedor] [bigint] NOT NULL,
	[IdConcepto] [varchar](20) NOT NULL,
	[IdProducto] [bigint] NOT NULL,
	[Porcentaje] [money] NOT NULL,
	[Status] [char](1) NULL,
	[Fecha] [datetime] NULL,
	[Usuario] [nvarchar](20) NULL,
 CONSTRAINT [PK_ComEsquemaVendedor] PRIMARY KEY CLUSTERED 
(
	[IdComEsquema] ASC,
	[IdCedis] ASC,
	[IdVendedor] ASC,
	[IdConcepto] ASC,
	[IdProducto] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


