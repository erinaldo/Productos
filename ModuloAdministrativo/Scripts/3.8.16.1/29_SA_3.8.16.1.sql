USE [RouteADM]
GO

/****** Object:  Table [dbo].[VentasTransProd]    Script Date: 07/29/2011 11:35:51 ******/
USE [RouteADM]
GO

/****** Object:  Table [dbo].[VentasTransProd]    Script Date: 07/29/2011 11:35:51 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[VentasTransProd]') AND type in (N'U'))
CREATE TABLE [dbo].[VentasTransProd](
	[IdCedis] [bigint] NOT NULL,
	[IdSurtido] [bigint] NOT NULL,
	[IdTipoVenta] [int] NOT NULL,
	[Serie] [varchar](5) NOT NULL,
	[Folio] [bigint] NOT NULL,
	[TransProdId] [varchar](16) NOT NULL,
	[Fecha] [datetime] NOT NULL,
 CONSTRAINT [PK_VentasTransProd] PRIMARY KEY CLUSTERED 
(
	[IdCedis] ASC,
	[IdSurtido] ASC,
	[IdTipoVenta] ASC,
	[Folio] ASC
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
	VALUES('SA', GETDATE(), '3.8.16.1', 29, (SELECT  cast(SERVERPROPERTY('productversion') as varchar(50))))
END
ELSE
BEGIN 
	Update VersionBD  set MaximoConsecutivo = 29 where  Tipo = 'SA' and Version ='3.8.16.1'
END
GO