USE [RouteADM]
GO


SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO


IF NOT  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[RecuperacionTransProd]') AND type in (N'U'))
BEGIN

	CREATE TABLE [dbo].[RecuperacionTransProd](
		[TransProdId] [varchar](16) NOT NULL,
		[Fecha] [datetime] NOT NULL,
	 CONSTRAINT [PK_RecuperacionTransProd] PRIMARY KEY CLUSTERED 
	(
		[TransProdId] ASC
	)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
	) ON [PRIMARY]

END

GO

SET ANSI_PADDING OFF
GO



USE [Route] 
GO

if (Select COUNT(*) from VersionBD where Tipo = 'SA' and Version ='3.8.16.1') = 0
BEGIN
	INSERT INTO VersionBD (Tipo, FechaHora, Version, MaximoConsecutivo, VersionSql ) 
	VALUES('SA', GETDATE(), '3.8.16.1', 72, (SELECT  cast(SERVERPROPERTY('productversion') as varchar(50))))
END
ELSE
BEGIN 
	Update VersionBD  set MaximoConsecutivo = 72 where  Tipo = 'SA' and Version ='3.8.16.1'
END
GO
