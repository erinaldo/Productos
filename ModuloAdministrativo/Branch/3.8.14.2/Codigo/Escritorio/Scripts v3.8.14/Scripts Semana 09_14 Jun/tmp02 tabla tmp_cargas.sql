USE [RouteADM]
GO

/****** Object:  Table [dbo].[tmp_Cargas]    Script Date: 05/28/2010 04:50:05 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[tmp_Cargas](
	[RUTA] [int] NULL,
	[CLAVE] [varchar](50) NULL,
	[DESCRIPCION] [varchar](500) NULL,
	[CANTIDAD] [money] NULL,
	[LINEA] [int] NULL,
	[IDPRODUCTO] [bigint] NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

