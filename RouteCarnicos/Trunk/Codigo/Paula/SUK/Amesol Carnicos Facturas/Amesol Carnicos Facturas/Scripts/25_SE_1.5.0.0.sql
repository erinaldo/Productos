IF (SELECT COUNT(*) FROM syscolumns WHERE NAME ='ExigirOrdenCompra' AND ID =(SELECT ID FROM sysobjects WHERE NAME ='Cliente' ))=0
BEGIN
	ALTER TABLE dbo.Cliente
		DROP CONSTRAINT FK_Cliente_ConfiguracionPunto
	ALTER TABLE dbo.Cliente
		DROP CONSTRAINT DF_Cliente_FechaFactura_1
		
	CREATE TABLE dbo.Tmp_Cliente_1
		(
		ClienteClave varchar(16) NOT NULL,
		CNPId varchar(16) NULL,
		Clave varchar(16) NOT NULL,
		IdElectronico varchar(64) NULL,
		IdFiscal varchar(64) NULL,
		RazonSocial varchar(128) NOT NULL,
		TipoFiscal smallint NOT NULL,
		TipoImpuesto smallint NOT NULL,
		NombreContacto varchar(64) NULL,
		TelefonoContacto varchar(64) NULL,
		FechaRegistroSistema datetime NOT NULL,
		FechaNacimiento datetime NULL,
		LimiteCreditoDinero float(53) NULL,
		NombreCorto varchar(32) NULL,
		TipoEstado smallint NOT NULL,
		LimiteDescuento float(53) NULL,
		SaldoEfectivo float(53) NULL,
		Prestamo bit NOT NULL,
		Exclusividad bit NOT NULL,
		VigExclusividad datetime NULL,
		ActualizaSaldoCheque bit NOT NULL,
		CriterioCredito bit NOT NULL,
		VencimientoVenta bit NOT NULL,
		DiasVencimiento int NULL,
		SaldoGarantia float(53) NULL,
		Nuevo bit NULL,
		FechaFactura datetime NULL,
		DesgloseImpuesto bit NOT NULL,
		CorreoElectronico varchar(50) NULL,
		ExigirOrdenCompra bit NOT NULL,
		MFechaHora datetime NOT NULL,
		MUsuarioID varchar(16) NOT NULL
		)  ON [PRIMARY]
	ALTER TABLE dbo.Tmp_Cliente_1 ADD CONSTRAINT
		DF_Cliente_FechaFactura_1 DEFAULT ('3000-12-31T23:59:59') FOR FechaFactura
	ALTER TABLE dbo.Tmp_Cliente_1 ADD CONSTRAINT
		DF_Cliente_ExigirOrdenCompra DEFAULT 0 FOR ExigirOrdenCompra
	IF EXISTS(SELECT * FROM dbo.Cliente)
		 EXEC('INSERT INTO dbo.Tmp_Cliente_1 (ClienteClave, CNPId, Clave, IdElectronico, IdFiscal, RazonSocial, TipoFiscal, TipoImpuesto, NombreContacto, TelefonoContacto, FechaRegistroSistema, FechaNacimiento, LimiteCreditoDinero, NombreCorto, TipoEstado, LimiteDescuento, SaldoEfectivo, Prestamo, Exclusividad, VigExclusividad, ActualizaSaldoCheque, CriterioCredito, VencimientoVenta, DiasVencimiento, SaldoGarantia, Nuevo, FechaFactura, DesgloseImpuesto, CorreoElectronico, MFechaHora, MUsuarioID)
			SELECT ClienteClave, CNPId, Clave, IdElectronico, IdFiscal, RazonSocial, TipoFiscal, TipoImpuesto, NombreContacto, TelefonoContacto, FechaRegistroSistema, FechaNacimiento, LimiteCreditoDinero, NombreCorto, TipoEstado, LimiteDescuento, SaldoEfectivo, Prestamo, Exclusividad, VigExclusividad, ActualizaSaldoCheque, CriterioCredito, VencimientoVenta, DiasVencimiento, SaldoGarantia, Nuevo, FechaFactura, DesgloseImpuesto, CorreoElectronico, MFechaHora, MUsuarioID FROM dbo.Cliente WITH (HOLDLOCK TABLOCKX)')
	ALTER TABLE dbo.CLINoDesImp
		DROP CONSTRAINT FK_CLINoDesImp_Cliente
	ALTER TABLE dbo.Visita
		DROP CONSTRAINT FK_Visita_Cliente
	ALTER TABLE dbo.ProductoPrestamoCli
		DROP CONSTRAINT FK_ProductoPrestamoCli_Cliente
	ALTER TABLE dbo.MerCli
		DROP CONSTRAINT FK_MerCli_Cliente
	ALTER TABLE dbo.ClienteProducto
		DROP CONSTRAINT FK_ClienteProducto_Cliente
	ALTER TABLE dbo.ClienteMensaje
		DROP CONSTRAINT FK_ClienteMensaje_Cliente
	ALTER TABLE dbo.Punto
		DROP CONSTRAINT FK_Punto_Cliente
	ALTER TABLE dbo.ActivoClienteHist
		DROP CONSTRAINT FK_ActivoClienteHist_Cliente
	ALTER TABLE dbo.CUOCliente
		DROP CONSTRAINT FK_CUOCliente_Cliente
	ALTER TABLE dbo.CLIFormaVenta
		DROP CONSTRAINT FK_CLIFormaVenta_Cliente
	ALTER TABLE dbo.AgendaVendedor
		DROP CONSTRAINT FK_AgendaVendedor_Cliente
	ALTER TABLE dbo.Agenda
		DROP CONSTRAINT FK_Agenda_Cliente
	ALTER TABLE dbo.CliCap
		DROP CONSTRAINT FK_CliCap_Cliente
	ALTER TABLE dbo.ClienteEsquema
		DROP CONSTRAINT FK_ClienteEsquema_Cliente
	ALTER TABLE dbo.SEMHist
		DROP CONSTRAINT FK_SEMHist_Cliente
	ALTER TABLE dbo.DESCliente
		DROP CONSTRAINT FK_DESCliente_Cliente
	ALTER TABLE dbo.ClientePago
		DROP CONSTRAINT FK_ClientePago_Cliente
	ALTER TABLE dbo.CenCli
		DROP CONSTRAINT FK_CenCli_Cliente
	ALTER TABLE dbo.ClienteDomicilio
		DROP CONSTRAINT FK_ClienteDomicilio_Cliente
	DROP TABLE dbo.Cliente
	EXECUTE sp_rename N'dbo.Tmp_Cliente_1', N'Cliente', 'OBJECT' 
	ALTER TABLE dbo.Cliente ADD CONSTRAINT
		PK_Cliente PRIMARY KEY CLUSTERED 
		(
		ClienteClave
		) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

	ALTER TABLE dbo.Cliente WITH NOCHECK ADD CONSTRAINT
		FK_Cliente_ConfiguracionPunto FOREIGN KEY
		(
		CNPId
		) REFERENCES dbo.ConfiguracionPunto
		(
		CNPId
		) ON UPDATE  NO ACTION 
		 ON DELETE  NO ACTION 
		
	ALTER TABLE dbo.ClienteDomicilio WITH NOCHECK ADD CONSTRAINT
		FK_ClienteDomicilio_Cliente FOREIGN KEY
		(
		ClienteClave
		) REFERENCES dbo.Cliente
		(
		ClienteClave
		) ON UPDATE  NO ACTION 
		 ON DELETE  NO ACTION 
		
	ALTER TABLE dbo.CenCli WITH NOCHECK ADD CONSTRAINT
		FK_CenCli_Cliente FOREIGN KEY
		(
		ClienteClave
		) REFERENCES dbo.Cliente
		(
		ClienteClave
		) ON UPDATE  NO ACTION 
		 ON DELETE  NO ACTION 
		
	ALTER TABLE dbo.ClientePago WITH NOCHECK ADD CONSTRAINT
		FK_ClientePago_Cliente FOREIGN KEY
		(
		ClienteClave
		) REFERENCES dbo.Cliente
		(
		ClienteClave
		) ON UPDATE  NO ACTION 
		 ON DELETE  NO ACTION 
	ALTER TABLE dbo.DESCliente WITH NOCHECK ADD CONSTRAINT
		FK_DESCliente_Cliente FOREIGN KEY
		(
		ClienteClave
		) REFERENCES dbo.Cliente
		(
		ClienteClave
		) ON UPDATE  NO ACTION 
		 ON DELETE  NO ACTION 
	ALTER TABLE dbo.SEMHist WITH NOCHECK ADD CONSTRAINT
		FK_SEMHist_Cliente FOREIGN KEY
		(
		ClienteClave
		) REFERENCES dbo.Cliente
		(
		ClienteClave
		) ON UPDATE  NO ACTION 
		 ON DELETE  NO ACTION 
		
	ALTER TABLE dbo.ClienteEsquema WITH NOCHECK ADD CONSTRAINT
		FK_ClienteEsquema_Cliente FOREIGN KEY
		(
		ClienteClave
		) REFERENCES dbo.Cliente
		(
		ClienteClave
		) ON UPDATE  NO ACTION 
		 ON DELETE  NO ACTION 
		
	ALTER TABLE dbo.CliCap WITH NOCHECK ADD CONSTRAINT
		FK_CliCap_Cliente FOREIGN KEY
		(
		ClienteClave
		) REFERENCES dbo.Cliente
		(
		ClienteClave
		) ON UPDATE  NO ACTION 
		 ON DELETE  NO ACTION 
		
	ALTER TABLE dbo.Agenda WITH NOCHECK ADD CONSTRAINT
		FK_Agenda_Cliente FOREIGN KEY
		(
		ClienteClave
		) REFERENCES dbo.Cliente
		(
		ClienteClave
		) ON UPDATE  NO ACTION 
		 ON DELETE  NO ACTION 
		
	ALTER TABLE dbo.AgendaVendedor WITH NOCHECK ADD CONSTRAINT
		FK_AgendaVendedor_Cliente FOREIGN KEY
		(
		ClienteClave
		) REFERENCES dbo.Cliente
		(
		ClienteClave
		) ON UPDATE  NO ACTION 
		 ON DELETE  NO ACTION 
		
	ALTER TABLE dbo.CLIFormaVenta WITH NOCHECK ADD CONSTRAINT
		FK_CLIFormaVenta_Cliente FOREIGN KEY
		(
		ClienteClave
		) REFERENCES dbo.Cliente
		(
		ClienteClave
		) ON UPDATE  NO ACTION 
		 ON DELETE  NO ACTION 
		
	ALTER TABLE dbo.CUOCliente WITH NOCHECK ADD CONSTRAINT
		FK_CUOCliente_Cliente FOREIGN KEY
		(
		ClienteClave
		) REFERENCES dbo.Cliente
		(
		ClienteClave
		) ON UPDATE  NO ACTION 
		 ON DELETE  NO ACTION 
		
	ALTER TABLE dbo.ActivoClienteHist WITH NOCHECK ADD CONSTRAINT
		FK_ActivoClienteHist_Cliente FOREIGN KEY
		(
		ClienteClave
		) REFERENCES dbo.Cliente
		(
		ClienteClave
		) ON UPDATE  NO ACTION 
		 ON DELETE  NO ACTION 
		
	ALTER TABLE dbo.Punto WITH NOCHECK ADD CONSTRAINT
		FK_Punto_Cliente FOREIGN KEY
		(
		ClienteClave
		) REFERENCES dbo.Cliente
		(
		ClienteClave
		) ON UPDATE  NO ACTION 
		 ON DELETE  NO ACTION 
		
	ALTER TABLE dbo.ClienteMensaje WITH NOCHECK ADD CONSTRAINT
		FK_ClienteMensaje_Cliente FOREIGN KEY
		(
		ClienteClave
		) REFERENCES dbo.Cliente
		(
		ClienteClave
		) ON UPDATE  NO ACTION 
		 ON DELETE  NO ACTION 
		
	ALTER TABLE dbo.ClienteProducto WITH NOCHECK ADD CONSTRAINT
		FK_ClienteProducto_Cliente FOREIGN KEY
		(
		ClienteClave
		) REFERENCES dbo.Cliente
		(
		ClienteClave
		) ON UPDATE  NO ACTION 
		 ON DELETE  NO ACTION 
		
	ALTER TABLE dbo.MerCli WITH NOCHECK ADD CONSTRAINT
		FK_MerCli_Cliente FOREIGN KEY
		(
		ClienteClave
		) REFERENCES dbo.Cliente
		(
		ClienteClave
		) ON UPDATE  NO ACTION 
		 ON DELETE  NO ACTION 
	ALTER TABLE dbo.ProductoPrestamoCli WITH NOCHECK ADD CONSTRAINT
		FK_ProductoPrestamoCli_Cliente FOREIGN KEY
		(
		ClienteClave
		) REFERENCES dbo.Cliente
		(
		ClienteClave
		) ON UPDATE  NO ACTION 
		 ON DELETE  NO ACTION 
		
	ALTER TABLE dbo.Visita WITH NOCHECK ADD CONSTRAINT
		FK_Visita_Cliente FOREIGN KEY
		(
		ClienteClave
		) REFERENCES dbo.Cliente
		(
		ClienteClave
		) ON UPDATE  NO ACTION 
		 ON DELETE  NO ACTION 
		
	ALTER TABLE dbo.CLINoDesImp ADD CONSTRAINT
		FK_CLINoDesImp_Cliente FOREIGN KEY
		(
		ClienteClave
		) REFERENCES dbo.Cliente
		(
		ClienteClave
		) ON UPDATE  NO ACTION 
		ON DELETE  NO ACTION 
		
END
