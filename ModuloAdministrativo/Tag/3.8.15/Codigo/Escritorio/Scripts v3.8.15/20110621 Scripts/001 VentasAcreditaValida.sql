USE [RouteADM]
GO

USE [RouteADM]
GO

/****** Object:  Table [dbo].[VentasAcreditaValida]    Script Date: 06/21/2011 16:55:04 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[VentasAcreditaValida]') AND type in (N'U'))
DROP TABLE [dbo].[VentasAcreditaValida]
GO

USE [RouteADM]
GO

/****** Object:  Table [dbo].[VentasAcreditaValida]    Script Date: 06/21/2011 16:55:04 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[VentasAcreditaValida](
	[ADDId] [varchar] (16) NOT NULL,
	[FolioEntrega] [varchar](50) NULL,
	[Observaciones] [varchar](50) NULL,
	[FolioCliente] [varchar](50) NULL,
	[Remision] [varchar](50) NULL,
	[Factura] [varchar](50) NULL,
 CONSTRAINT [PK_VentasAcreditaValida] PRIMARY KEY CLUSTERED 
(
	[ADDId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


