/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
USE RouteADM

IF (SELECT COUNT(*) FROM syscolumns WHERE NAME ='IdListaPrecioDesc' AND ID =(SELECT ID FROM sysobjects WHERE NAME ='Ventas' ))=0
BEGIN

	BEGIN TRANSACTION
	
		CREATE TABLE [dbo].[Tmp_Ventas](
			[IdCedis] [bigint] NOT NULL,
			[IdSurtido] [bigint] NOT NULL,
			[IdTipoVenta] [int] NOT NULL,
			[Folio] [bigint] NOT NULL,
			[Serie] [varchar](5) NOT NULL,
			[Fecha] [datetime] NULL,
			[IdCliente] [bigint] NULL,
			[Subtotal] [money] NULL,
			[Iva] [money] NULL,
			[Total]  AS ([Subtotal]+[Iva]),
			[IdSucursal] [varchar](16) NULL,
			[DctoImp] [money] NULL,
			[DiasCredito] [int] NULL,
			[IdListaPrecioDesc] [bigint] NULL,
		) ON [PRIMARY]
		
		ALTER TABLE dbo.Tmp_Ventas SET (LOCK_ESCALATION = TABLE)
		
		IF EXISTS(SELECT * FROM dbo.Ventas)
			EXEC('INSERT INTO dbo.Tmp_Ventas (IdCedis, IdSurtido, IdTipoVenta, Folio, Serie, Fecha, IdCliente, Subtotal, Iva, IdSucursal, DctoImp, DiasCredito, IdListaPrecioDesc)
			SELECT IdCedis, IdSurtido, IdTipoVenta, Folio, Serie, Fecha, IdCliente, Subtotal, Iva, IdSucursal, DctoImp, DiasCredito, NULL FROM dbo.Ventas WITH (HOLDLOCK TABLOCKX)')
		
		DROP TABLE dbo.Ventas
		
		EXECUTE sp_rename N'dbo.Tmp_Ventas', N'Ventas', 'OBJECT' 
		
		ALTER TABLE dbo.Ventas ADD CONSTRAINT
		[PK_Ventas] PRIMARY KEY CLUSTERED 
		(
			[IdCedis] ASC,
			[IdSurtido] ASC,
			[IdTipoVenta] ASC,
			[Folio] ASC
		)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
		
	COMMIT

END

GO


USE [Route]
GO

if (Select COUNT(*) from VersionBD where Tipo = 'SA' and Version ='3.8.16.1') = 0
BEGIN
	INSERT INTO VersionBD (Tipo, FechaHora, Version, MaximoConsecutivo, VersionSql ) 
	VALUES('SA', GETDATE(), '3.8.16.1', 19, (SELECT  cast(SERVERPROPERTY('productversion') as varchar(50))))
END
ELSE
BEGIN 
	Update VersionBD  set MaximoConsecutivo = 19 where  Tipo = 'SA' and Version ='3.8.16.1'
END
GO