/****** Object:  Table [dbo].[SubEmpresa]    Script Date: 04/19/2012 19:30:02 ******/
IF  EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'[dbo].[SubEmpresa]') AND type in (N'U'))
DROP TABLE [dbo].[SubEmpresa]
/*go*/go

/****** Object:  Table [dbo].[SubEmpresa]    Script Date: 04/19/2012 19:30:02 ******/
SET ANSI_NULLS ON
/*go*/go

SET QUOTED_IDENTIFIER ON
/*go*/go

SET ANSI_PADDING ON
/*go*/go

CREATE TABLE [dbo].[SubEmpresa](
	[SubEmpresaId] [varchar](16) NOT NULL,
	[NombreEmpresa] [varchar](60) NOT NULL,
	[RFC] [varchar](64) NULL,
	[Pais] [varchar](40) NULL,
	[Region] [varchar](40) NULL,
	[Localidad] [varchar](40) NULL,
	[ReferenciaDom] [varchar](100) NULL,
	[Ciudad] [varchar](40) NULL,
	[Colonia] [varchar](64) NULL,
	[Calle] [varchar](64) NULL,
	[Numero] [varchar](16) NULL,
	[NumeroInterior] [varchar](16) NULL,
	[CodigoPostal] [varchar](16) NULL,
	[Logotipo] [image] NULL,
	[Telefono] [varchar](32) NULL,
	[TipoEstado] [smallint] NOT NULL,
	[MFechaHora] [datetime] NOT NULL,
	[MUsuarioID] [varchar](16) NOT NULL,
 CONSTRAINT [PK_SubEmpresa] PRIMARY KEY CLUSTERED 
(
	[SubEmpresaId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

/*go*/go

SET ANSI_PADDING OFF
/*go*/go


