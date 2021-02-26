USE [RouteADM]
GO

/****** Object:  Table [dbo].[Kilometrajes]    Script Date: 03/18/2011 15:15:05 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Kilometraje](
	[IdCedis] [bigint] NOT NULL,
	[IdRuta] [bigint] NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[KmInicial] [bigint] NULL,
	[KmFinal] [bigint] NULL,
	[Litros] [money] NULL,
	[Importe] [money] NULL,
	[Login] [varchar](20) NULL,
	[FechaEdicion] [datetime] NULL,
 CONSTRAINT [PK_Kilometraje] PRIMARY KEY CLUSTERED 
(
	[IdCedis] ASC,
	[IdRuta] ASC,
	[Fecha] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

