USE [RouteADM]
GO

/****** Object:  Table [dbo].[RepModeloOrienteES]    Script Date: 05/11/2010 15:50:58 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[RepModeloOrienteEnvase](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[IdCedis] [bigint] NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[IdAgrupador] [int] NULL,
	[IdRuta] [bigint] NULL,
	[Titulo] [varchar](20) NULL,
	[Concepto] [varchar](30) NULL,
	[IdProd30] [varchar](15) NULL,
	[IdProd31] [varchar](15) NULL,
	[IdProd32] [varchar](15) NULL,
	[IdProd33] [varchar](15) NULL,
	[IdProd34] [varchar](15) NULL,
	[IdProd35] [varchar](15) NULL,
	[IdProd36] [varchar](15) NULL,
 CONSTRAINT [PK_RepModeloOrienteEnvase] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

