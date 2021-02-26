
use RouteADM 

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TipoImpuesto]') AND type in (N'U'))
DROP TABLE [dbo].[TipoImpuesto]


/****** Object:  Table [dbo].[TipoImpuesto]    Script Date: 02/26/2011 23:03:47 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[TipoImpuesto](
	[IdTipoImpuesto] [smallint] NOT NULL,
	[TipoImpuesto] [varchar](10) NULL,
	[TipoAplicacion] [int] NULL,
	[Jerarquia] [int] NULL,
	[Tasa] [float] NULL,
	[Descripcion] [varchar](100) NULL,
 CONSTRAINT [PK_TipoImpuesto] PRIMARY KEY CLUSTERED 
(
	[IdTipoImpuesto] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[TipoImpuesto] ADD  CONSTRAINT [DF_TipoImpuesto_Impuesto]  DEFAULT ((0)) FOR [Tasa]
GO

