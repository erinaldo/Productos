
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_CLINoDesImp_Cliente]') AND parent_object_id = OBJECT_ID(N'[dbo].[CLINoDesImp]'))
ALTER TABLE [dbo].[CLINoDesImp] DROP CONSTRAINT [FK_CLINoDesImp_Cliente]
/*go*/go

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_CLINoDesImp_Impuesto]') AND parent_object_id = OBJECT_ID(N'[dbo].[CLINoDesImp]'))
ALTER TABLE [dbo].[CLINoDesImp] DROP CONSTRAINT [FK_CLINoDesImp_Impuesto]
/*go*/go

/****** Object:  Table [dbo].[CLINoDesImp]    Script Date: 04/27/2012 12:01:07 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CLINoDesImp]') AND type in (N'U'))
DROP TABLE [dbo].[CLINoDesImp]
/*go*/go

/****** Object:  Table [dbo].[CLINoDesImp]    Script Date: 04/27/2012 12:01:07 ******/
SET ANSI_NULLS ON
/*go*/go

SET QUOTED_IDENTIFIER ON
/*go*/go

SET ANSI_PADDING ON
/*go*/go

CREATE TABLE [dbo].[CLINoDesImp](
	[CNDIID] [varchar](20) NOT NULL,
	[ClienteClave] [varchar](16) NOT NULL,
	[ImpuestoClave] [varchar](10) NOT NULL,
	[FechaInicio] [datetime] NOT NULL,
	[FechaFin] [datetime] NOT NULL,
	[MFechaHora] [datetime] NOT NULL,
	[MUsuarioID] [varchar](16) NOT NULL,
 CONSTRAINT [PK_CLINoDesImp] PRIMARY KEY CLUSTERED 
(
	[CNDIID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

/*go*/go

SET ANSI_PADDING OFF
/*go*/go

ALTER TABLE [dbo].[CLINoDesImp]  WITH CHECK ADD  CONSTRAINT [FK_CLINoDesImp_Cliente] FOREIGN KEY([ClienteClave])
REFERENCES [dbo].[Cliente] ([ClienteClave])
/*go*/go

ALTER TABLE [dbo].[CLINoDesImp] CHECK CONSTRAINT [FK_CLINoDesImp_Cliente]
/*go*/go

ALTER TABLE [dbo].[CLINoDesImp]  WITH CHECK ADD  CONSTRAINT [FK_CLINoDesImp_Impuesto] FOREIGN KEY([ImpuestoClave])
REFERENCES [dbo].[Impuesto] ([ImpuestoClave])
/*go*/go
ALTER TABLE [dbo].[CLINoDesImp] CHECK CONSTRAINT [FK_CLINoDesImp_Impuesto]
/*go*/go


