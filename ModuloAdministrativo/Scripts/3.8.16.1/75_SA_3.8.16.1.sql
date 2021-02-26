USE [RouteADM]
GO

/****** Object:  Table [dbo].[ComEsquemaMarca]    Script Date: 08/20/2011 13:39:44 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ComEsquemaMarca]') AND type in (N'U'))
DROP TABLE [dbo].[ComEsquemaMarca]
GO

USE [RouteADM]
GO

/****** Object:  Table [dbo].[ComEsquemaFamilia]    Script Date: 08/20/2011 13:39:44 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[ComEsquemaMarca](
	[IdComEsquema] [bigint] NOT NULL,
	[IdMarca] [bigint] NOT NULL,
	[Status] [char](1) NULL,
	[Fecha] [datetime] NULL,
	[Usuario] [nvarchar](20) NULL,
 CONSTRAINT [PK_ComEsquemaMarca] PRIMARY KEY CLUSTERED 
(
	[IdComEsquema] ASC,
	[IdMarca] ASC
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
	VALUES('SA', GETDATE(), '3.8.16.1', 75, (SELECT  cast(SERVERPROPERTY('productversion') as varchar(50))))
END
ELSE
BEGIN 
	Update VersionBD  set MaximoConsecutivo = 75 where  Tipo = 'SA' and Version ='3.8.16.1'
END
GO