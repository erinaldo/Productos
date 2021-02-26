USE [RouteADM]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_CedisVirtuales_Cedis]') AND parent_object_id = OBJECT_ID(N'[dbo].[CedisVirtuales]'))
ALTER TABLE [dbo].[CedisVirtuales] DROP CONSTRAINT [FK_CedisVirtuales_Cedis]
GO

USE [RouteADM]
GO

/****** Object:  Table [dbo].[CedisVirtuales]    Script Date: 07/25/2011 09:36:49 ******/
USE [RouteADM]
GO

/****** Object:  Table [dbo].[CedisVirtuales]    Script Date: 07/25/2011 09:36:49 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CedisVirtuales]') AND type in (N'U'))
CREATE TABLE [dbo].[CedisVirtuales](
	[IdCedis] [bigint] NOT NULL,
	[TipoRuta] [varchar](20) NOT NULL,
	[IdCedisVirtual] [bigint] NOT NULL,
 CONSTRAINT [PK_CedisVirtuales] PRIMARY KEY CLUSTERED 
(
	[IdCedis] ASC,
	[TipoRuta] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[CedisVirtuales]  WITH CHECK ADD  CONSTRAINT [FK_CedisVirtuales_Cedis] FOREIGN KEY([IdCedis])
REFERENCES [dbo].[Cedis] ([IdCedis])
GO

ALTER TABLE [dbo].[CedisVirtuales] CHECK CONSTRAINT [FK_CedisVirtuales_Cedis]
GO


USE [Route]
GO

if (Select COUNT(*) from VersionBD where Tipo = 'SA' and Version ='3.8.16.1') = 0
BEGIN
	INSERT INTO VersionBD (Tipo, FechaHora, Version, MaximoConsecutivo, VersionSql ) 
	VALUES('SA', GETDATE(), '3.8.16.1', 2, (SELECT  cast(SERVERPROPERTY('productversion') as varchar(50))))
END
ELSE
BEGIN 
	Update VersionBD  set MaximoConsecutivo = 2 where  Tipo = 'SA' and Version ='3.8.16.1'
END
GO