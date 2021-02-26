USE [Route]
GO

/****** Object:  Table [dbo].[tmp_AbonoFactura]    Script Date: 07/07/2010 09:24:26 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[tmp_AbonoFactura](
	[FolioFactura] [varchar](16) NULL,
	[FolioAbono] [varchar](16) NULL,
	[FechaAbono] [datetime] NULL,
	[Importe] [decimal](18, 4) NULL,
	[TipoPago] [smallint] NULL,
	[MUsuarioID] [varchar](16) NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


