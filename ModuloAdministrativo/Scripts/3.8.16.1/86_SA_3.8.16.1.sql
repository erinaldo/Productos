USE [RouteADM]
GO

/****** Object:  Table [dbo].[ComisionesHistorico]    Script Date: 08/30/2011 12:10:40 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ComisionesHistorico]') AND type in (N'U'))
DROP TABLE [dbo].[ComisionesHistorico]
GO

USE [RouteADM]
GO

/****** Object:  Table [dbo].[ComisionesHistorico]    Script Date: 08/30/2011 12:10:40 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[ComisionesHistorico](
	[IdCedis] [bigint] NOT NULL,
	[IdVendedor] [bigint] NOT NULL,
	[Vendedor] [varchar](200) NOT NULL,
	[FechaIni] [datetime] NOT NULL,
	[FechaFin] [datetime] NOT NULL,
	[IdComEsquema] [bigint] NOT NULL,
	[Esquema] [varchar](50) NULL,
	[IdConceptoPago] [bigint] NULL,
	[ConceptoPago] [varchar](50) NULL,
	[IdTipoVendedor] [bigint] NULL,
	[TipoVendedor] [varchar](50) NULL,
	[IdMarca] [bigint] NULL,
	[Marca] [varchar](50) NULL,
	[IdProducto] [bigint] NULL,
	[Producto] [varchar](50) NULL,
	[VentaLunes] [money] NULL,
	[VentaMartes] [money] NULL,
	[VentaMiercoles] [money] NULL,
	[VentaJueves] [money] NULL,
	[VentaViernes] [money] NULL,
	[VentaSabado] [money] NULL,
	[DiasTrabajados] [smallint] NULL,
	[PromSemanal] [money] NULL,
	[Inicial] [money] NULL,
	[Final] [money] NULL,
	[Factor] [money] NULL,
	[Pago] [money] NULL,
 CONSTRAINT [PK_ComisionesHistorico_1] PRIMARY KEY CLUSTERED 
(
	[IdCedis] ASC,
	[IdVendedor] ASC,
	[FechaIni] ASC,
	[FechaFin] ASC,
	[IdComEsquema] ASC
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
	VALUES('SA', GETDATE(), '3.8.16.1', 86, (SELECT  cast(SERVERPROPERTY('productversion') as varchar(50))))
END
ELSE
BEGIN 
	Update VersionBD  set MaximoConsecutivo = 86 where  Tipo = 'SA' and Version ='3.8.16.1'
END

GO

