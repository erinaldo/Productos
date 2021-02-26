USE [RouteADM]
GO

/****** Object:  Table [dbo].[SurtidosCancelados]    Script Date: 08/01/2011 13:49:23 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
	
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SurtidosCancelados]') AND type in (N'U'))
BEGIN

	CREATE TABLE [dbo].[SurtidosCancelados](
		[IdCedis] [bigint] NOT NULL,
		[IdSurtido] [bigint] NOT NULL,
		[Fecha] [datetime] NOT NULL,
		[IdRuta] [bigint] NOT NULL,
		[MFechaHora] [datetime] NOT NULL,
	 CONSTRAINT [PK_SurtidosCancelados] PRIMARY KEY CLUSTERED 
	(
		[IdCedis] ASC,
		[IdSurtido] ASC
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
	VALUES('SA', GETDATE(), '3.8.16.1', 38, (SELECT  cast(SERVERPROPERTY('productversion') as varchar(50))))
END
ELSE
BEGIN 
	Update VersionBD  set MaximoConsecutivo = 38 where  Tipo = 'SA' and Version ='3.8.16.1'
END
GO