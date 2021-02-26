USE [RouteADM]
GO


SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO


IF NOT  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FoliosRemision]') AND type in (N'U'))
BEGIN

	CREATE TABLE [dbo].[FoliosRemision](
		[IdCedis] [bigint] NOT NULL,
		[Serie] [varchar](5) NOT NULL,
		[Ultimo] [bigint] NOT NULL,
	 CONSTRAINT [PK_FoliosRemision] PRIMARY KEY CLUSTERED 
	(
		[IdCedis] ASC,
		[Serie] ASC
	)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
	) ON [PRIMARY]

END

GO

SET ANSI_PADDING OFF
GO




USE [Route]
GO

if (Select COUNT(*) from VersionBD where Tipo = 'SA' and Version ='3.8.15.2') = 0
BEGIN
	INSERT INTO VersionBD (Tipo, FechaHora, Version, MaximoConsecutivo, VersionSql ) 
	VALUES('SA', GETDATE(), '3.8.15.2', 2, @@VERSION )
END
ELSE
BEGIN 
	Update VersionBD  set MaximoConsecutivo = 2 where  Tipo = 'SA' and Version ='3.8.15.2'
END
GO