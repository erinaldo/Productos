USE [RouteADM]
GO

/****** Object:  Table [dbo].[ComEsquemaPagos]    Script Date: 08/20/2011 16:01:46 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ComEsquemaPagos]') AND type in (N'U'))
DROP TABLE [dbo].[ComEsquemaPagos]
GO

USE [RouteADM]
GO

/****** Object:  Table [dbo].[ComEsquemaPagos]    Script Date: 08/20/2011 16:01:46 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[ComEsquemaPagos](
	[IdComEsquema] [bigint] NOT NULL,
	[IdFamilia] [bigint] NOT NULL,
	[IdMarca] [bigint] NOT NULL,
	[IdProducto] [bigint] NOT NULL,
	[IdConceptoPago] [smallint] NOT NULL,
	[Inicial] [float] NOT NULL,
	[Final] [float] NOT NULL,
	[IdTipoVendedor] [bigint] NOT NULL,
	[Pago] [money] NULL,
	[Status] [char](1) NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[Usuario] [nvarchar](20) NULL,
 CONSTRAINT [PK_ComEsquemaPagos] PRIMARY KEY CLUSTERED 
(
	[IdComEsquema] ASC,
	[IdFamilia] ASC,
	[IdMarca] ASC,
	[IdProducto] ASC,
	[IdConceptoPago] ASC,
	[Inicial] ASC,
	[Final] ASC,
	[IdTipoVendedor] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

USE [Route] 
GO

if (Select COUNT(*) from VersionBD where Tipo = 'SA' and Version ='3.8.16.1') = 0
BEGIN
	INSERT INTO VersionBD (Tipo, FechaHora, Version, MaximoConsecutivo, VersionSql ) 
	VALUES('SA', GETDATE(), '3.8.16.1', 77, (SELECT  cast(SERVERPROPERTY('productversion') as varchar(50))))
END
ELSE
BEGIN 
	Update VersionBD  set MaximoConsecutivo = 77 where  Tipo = 'SA' and Version ='3.8.16.1'
END
GO
