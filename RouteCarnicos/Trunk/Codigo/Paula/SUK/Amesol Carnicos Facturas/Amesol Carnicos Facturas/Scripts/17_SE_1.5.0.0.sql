IF (SELECT COUNT(*) FROM SysColumns WHERE Name = 'SubEmpresaID' AND Id = (SELECT Id FROM SysObjects WHERE Name = 'TransProd')) = 0
BEGIN

	ALTER TABLE dbo.TransProd
		DROP CONSTRAINT FK_TransProd_Visita

	ALTER TABLE dbo.TransProd
		DROP CONSTRAINT FK_TransProd_Visita1


	ALTER TABLE dbo.TransProd
		DROP CONSTRAINT FK_TransProd_PreLiquidacion


	ALTER TABLE dbo.TransProd
		DROP CONSTRAINT FK_TransProd_PrecioClienteEsquema


	ALTER TABLE dbo.TransProd
		DROP CONSTRAINT FK_TransProd_Moneda

	ALTER TABLE dbo.TransProd
		DROP CONSTRAINT FK_TransProd_CLIFormaVenta


	ALTER TABLE dbo.TransProd
		DROP CONSTRAINT DF_TransProd_TipoFaseIntSal

	CREATE TABLE dbo.Tmp_TransProd
		(
		TransProdID varchar(16) NOT NULL,
		VisitaClave varchar(16) NULL,
		DiaClave varchar(10) NULL,
		VisitaClave1 varchar(16) NULL,
		DiaClave1 varchar(10) NULL,
		PCEPrecioClave varchar(10) NULL,
		PCEModuloMovDetClave varchar(16) NULL,
		PCEEsquemaID varchar(16) NULL,
		SubEmpresaID varchar(16) NULL,
		FacturaID varchar(16) NULL,
		ClienteClave varchar(16) NULL,
		ClientePagoID varchar(16) NULL,
		CFVTipo smallint NULL,
		PLIId varchar(16) NULL,
		Folio varchar(16) NOT NULL,
		Tipo smallint NOT NULL,
		TipoPedido smallint NULL,
		TipoFase smallint NOT NULL,
		TipoMovimiento smallint NULL,
		FechaHoraAlta datetime NOT NULL,
		FechaCaptura datetime NOT NULL,
		FechaEntrega datetime NULL,
		FechaFacturacion datetime NULL,
		FechaSurtido datetime NULL,
		FechaCancelacion datetime NULL,
		TipoMotivo smallint NULL,
		SubTDetalle float(53) NULL,
		DescVendPor float(53) NULL,
		DescuentoVendedor float(53) NULL,
		DescuentoImp float(53) NULL,
		Subtotal float(53) NULL,
		Impuesto float(53) NULL,
		Total float(53) NOT NULL,
		Saldo float(53) NULL,
		Promocion bit NULL,
		Descuento bit NULL,
		MonedaId varchar(16) NULL,
		TipoCambio float(53) NULL,
		TipoTurno smallint NULL,
		FechaCobranza datetime NULL,
		DiasCredito smallint NULL,
		Notas nvarchar(500) NULL,
		TipoFaseIntSal smallint NULL,
		MFechaHora datetime NOT NULL,
		MUsuarioID varchar(16) NOT NULL
		)  ON [PRIMARY]

	ALTER TABLE dbo.Tmp_TransProd ADD CONSTRAINT
		DF_TransProd_TipoFaseIntSal DEFAULT (NULL) FOR TipoFaseIntSal

	IF EXISTS(SELECT * FROM dbo.TransProd)
		 EXEC('INSERT INTO dbo.Tmp_TransProd (TransProdID, VisitaClave, DiaClave, VisitaClave1, DiaClave1, PCEPrecioClave, PCEModuloMovDetClave, PCEEsquemaID, FacturaID, ClienteClave, ClientePagoID, CFVTipo, PLIId, Folio, Tipo, TipoPedido, TipoFase, TipoMovimiento, FechaHoraAlta, FechaCaptura, FechaEntrega, FechaFacturacion, FechaSurtido, FechaCancelacion, TipoMotivo, SubTDetalle, DescVendPor, DescuentoVendedor, DescuentoImp, Subtotal, Impuesto, Total, Saldo, Promocion, Descuento, MonedaId, TipoCambio, TipoTurno, FechaCobranza, DiasCredito, Notas, TipoFaseIntSal, MFechaHora, MUsuarioID)
			SELECT TransProdID, VisitaClave, DiaClave, VisitaClave1, DiaClave1, PCEPrecioClave, PCEModuloMovDetClave, PCEEsquemaID, FacturaID, ClienteClave, ClientePagoID, CFVTipo, PLIId, Folio, Tipo, TipoPedido, TipoFase, TipoMovimiento, FechaHoraAlta, FechaCaptura, FechaEntrega, FechaFacturacion, FechaSurtido, FechaCancelacion, TipoMotivo, SubTDetalle, DescVendPor, DescuentoVendedor, DescuentoImp, Subtotal, Impuesto, Total, Saldo, Promocion, Descuento, MonedaId, TipoCambio, TipoTurno, FechaCobranza, DiasCredito, Notas, TipoFaseIntSal, MFechaHora, MUsuarioID FROM dbo.TransProd WITH (HOLDLOCK TABLOCKX)')

	ALTER TABLE dbo.AbnTrp
		DROP CONSTRAINT FK_AbnTrp_TransProd


	ALTER TABLE dbo.AbonoProgramado
		DROP CONSTRAINT FK_AbonoProgramado_TransProd

	ALTER TABLE dbo.TRPDatoFiscal
		DROP CONSTRAINT FK_TRPDatoFiscal_TransProd

	ALTER TABLE dbo.TrpTpd
		DROP CONSTRAINT FK_TrpTpd_TransProd

	ALTER TABLE dbo.ProductoNegado
		DROP CONSTRAINT FK_ProductoNegado_TransProd1

	ALTER TABLE dbo.TransProd
		DROP CONSTRAINT FK_TransProd_TransProd

	ALTER TABLE dbo.TransProdDetalle
		DROP CONSTRAINT FK_TransProdDetalle_TransProd

	DROP TABLE dbo.TransProd

	EXECUTE sp_rename N'dbo.Tmp_TransProd', N'TransProd', 'OBJECT' 

	ALTER TABLE dbo.TransProd ADD CONSTRAINT
		PK_TransProd PRIMARY KEY CLUSTERED 
		(
		TransProdID
		) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]


	ALTER TABLE dbo.TransProd WITH NOCHECK ADD CONSTRAINT
		FK_TransProd_CLIFormaVenta FOREIGN KEY
		(
		ClienteClave,
		CFVTipo
		) REFERENCES dbo.CLIFormaVenta
		(
		ClienteClave,
		CFVTipo
		) ON UPDATE  NO ACTION 
		 ON DELETE  NO ACTION 
		
	ALTER TABLE dbo.TransProd WITH NOCHECK ADD CONSTRAINT
		FK_TransProd_Moneda FOREIGN KEY
		(
		MonedaId
		) REFERENCES dbo.Moneda
		(
		MonedaID
		) ON UPDATE  NO ACTION 
		 ON DELETE  NO ACTION 
		
	ALTER TABLE dbo.TransProd WITH NOCHECK ADD CONSTRAINT
		FK_TransProd_PrecioClienteEsquema FOREIGN KEY
		(
		PCEPrecioClave,
		PCEModuloMovDetClave,
		PCEEsquemaID
		) REFERENCES dbo.PrecioClienteEsquema
		(
		PrecioClave,
		ModuloMovDetalleClave,
		EsquemaID
		) ON UPDATE  NO ACTION 
		 ON DELETE  NO ACTION 
		
	ALTER TABLE dbo.TransProd WITH NOCHECK ADD CONSTRAINT
		FK_TransProd_PreLiquidacion FOREIGN KEY
		(
		PLIId
		) REFERENCES dbo.PreLiquidacion
		(
		PLIId
		) ON UPDATE  NO ACTION 
		 ON DELETE  NO ACTION 
		
	ALTER TABLE dbo.TransProd WITH NOCHECK ADD CONSTRAINT
		FK_TransProd_TransProd FOREIGN KEY
		(
		TransProdID
		) REFERENCES dbo.TransProd
		(
		TransProdID
		) ON UPDATE  NO ACTION 
		 ON DELETE  NO ACTION 
		
	ALTER TABLE dbo.TransProd WITH NOCHECK ADD CONSTRAINT
		FK_TransProd_Visita FOREIGN KEY
		(
		VisitaClave,
		DiaClave
		) REFERENCES dbo.Visita
		(
		VisitaClave,
		DiaClave
		) ON UPDATE  NO ACTION 
		 ON DELETE  NO ACTION 
		
	ALTER TABLE dbo.TransProd WITH NOCHECK ADD CONSTRAINT
		FK_TransProd_Visita1 FOREIGN KEY
		(
		VisitaClave1,
		DiaClave1
		) REFERENCES dbo.Visita
		(
		VisitaClave,
		DiaClave
		) ON UPDATE  NO ACTION 
		 ON DELETE  NO ACTION 
		
	ALTER TABLE dbo.TransProd ADD CONSTRAINT
		FK_TransProd_SubEmpresa FOREIGN KEY
		(
		SubEmpresaID
		) REFERENCES dbo.SubEmpresa
		(
		SubEmpresaId
		) ON UPDATE  NO ACTION 
		 ON DELETE  NO ACTION 
		
	ALTER TABLE dbo.TransProdDetalle ADD CONSTRAINT
		FK_TransProdDetalle_TransProd FOREIGN KEY
		(
		TransProdID
		) REFERENCES dbo.TransProd
		(
		TransProdID
		) ON UPDATE  NO ACTION 
		 ON DELETE  NO ACTION 
		
	ALTER TABLE dbo.TrpTpd ADD CONSTRAINT
		FK_TrpTpd_TransProd FOREIGN KEY
		(
		TransProdID
		) REFERENCES dbo.TransProd
		(
		TransProdID
		) ON UPDATE  NO ACTION 
		 ON DELETE  NO ACTION 
		

	ALTER TABLE dbo.TRPDatoFiscal ADD CONSTRAINT
		FK_TRPDatoFiscal_TransProd FOREIGN KEY
		(
		TransProdID
		) REFERENCES dbo.TransProd
		(
		TransProdID
		) ON UPDATE  NO ACTION 
		 ON DELETE  NO ACTION 
		
	ALTER TABLE dbo.ProductoNegado ADD CONSTRAINT
		FK_ProductoNegado_TransProd FOREIGN KEY
		(
		TransProdID
		) REFERENCES dbo.TransProd
		(
		TransProdID
		) ON UPDATE  NO ACTION 
		 ON DELETE  NO ACTION 
		
	ALTER TABLE dbo.AbonoProgramado ADD CONSTRAINT
		FK_AbonoProgramado_TransProd FOREIGN KEY
		(
		TransProdID
		) REFERENCES dbo.TransProd
		(
		TransProdID
		) ON UPDATE  NO ACTION 
		 ON DELETE  NO ACTION 
		

	ALTER TABLE dbo.AbnTrp ADD CONSTRAINT
		FK_AbnTrp_TransProd FOREIGN KEY
		(
		TransProdID
		) REFERENCES dbo.TransProd
		(
		TransProdID
		) ON UPDATE  NO ACTION 
		 ON DELETE  NO ACTION 
		
END