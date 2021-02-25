IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_SEMHist_Cliente]') AND parent_object_id = OBJECT_ID(N'[dbo].[SEMHist]'))
ALTER TABLE [dbo].[SEMHist] DROP CONSTRAINT [FK_SEMHist_Cliente]
/*go*/go

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_SEMHist_SubEmpresa]') AND parent_object_id = OBJECT_ID(N'[dbo].[SEMHist]'))
ALTER TABLE [dbo].[SEMHist] DROP CONSTRAINT [FK_SEMHist_SubEmpresa]
/*go*/go

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_SEMHist_FormatoFactura]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[SEMHist] DROP CONSTRAINT [DF_SEMHist_FormatoFactura]
END
/*go*/go

/****** Object:  Table [dbo].[SEMHist]    Script Date: 04/19/2012 19:52:31 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SEMHist]') AND type in (N'U'))
DROP TABLE [dbo].[SEMHist]
/*go*/go


/****** Object:  Table [dbo].[SEMHist]    Script Date: 04/19/2012 19:52:32 ******/
SET ANSI_NULLS ON
/*go*/go

SET QUOTED_IDENTIFIER ON
/*go*/go

SET ANSI_PADDING ON
/*go*/go

CREATE TABLE [dbo].[SEMHist](
	[SubEmpresaId] [varchar](16) NOT NULL,
	[SEMHistFechaInicio] [datetime] NOT NULL,
	[ClienteClave] [varchar](16) NULL,
	[ComprobanteDig] [bit] NOT NULL,
	[FormatoFactura] [smallint] NOT NULL,
	[FoliosTerminal] [bit] NOT NULL,
	[DirRepMensual] [varchar](200) NULL,
	[DirDocXML] [varchar](200) NULL,
	[DirArchivosFacElec] [varchar](200) NULL,
	[ContrasenaClave] [varchar](255) NULL,
	[ArchivoPEM] [text] NULL,
	[CerBase64] [text] NULL,
	[VersionCFD] [smallint] NOT NULL,
	[ProveedorTimbre] [smallint] NULL,
	[CustomerKey] [varchar](50) NULL,
	[ServidorTimbre] [varchar](50) NULL,
	[ServidorCancelacion] [varchar](50) NULL,
	[AchivoPFX64] [text] NULL,
	[MFechaHora] [datetime] NOT NULL,
	[MUsuarioID] [varchar](16) NOT NULL,
 CONSTRAINT [PK_SEMHist] PRIMARY KEY CLUSTERED 
(
	[SubEmpresaId] ASC,
	[SEMHistFechaInicio] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

/*go*/go

SET ANSI_PADDING OFF
/*go*/go

ALTER TABLE [dbo].[SEMHist]  WITH NOCHECK ADD  CONSTRAINT [FK_SEMHist_Cliente] FOREIGN KEY([ClienteClave])
REFERENCES [dbo].[Cliente] ([ClienteClave])
/*go*/go

ALTER TABLE [dbo].[SEMHist] CHECK CONSTRAINT [FK_SEMHist_Cliente]
/*go*/go

ALTER TABLE [dbo].[SEMHist]  WITH NOCHECK ADD  CONSTRAINT [FK_SEMHist_SubEmpresa] FOREIGN KEY([SubEmpresaId])
REFERENCES [dbo].[SubEmpresa] ([SubEmpresaId])
/*go*/go

ALTER TABLE [dbo].[SEMHist] CHECK CONSTRAINT [FK_SEMHist_SubEmpresa]
/*go*/go

ALTER TABLE [dbo].[SEMHist] ADD  CONSTRAINT [DF_SEMHist_FormatoFactura]  DEFAULT ((1)) FOR [FormatoFactura]
/*go*/go


