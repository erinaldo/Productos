IF (SELECT COUNT(*) FROM SysColumns WHERE Name = 'Tipo' AND Id = (SELECT Id FROM SysObjects WHERE Name = 'Vendedor')) = 0
begin
	ALTER TABLE dbo.Vendedor
		DROP CONSTRAINT FK_Vendedor_ModuloTerm

	ALTER TABLE dbo.Vendedor
		DROP CONSTRAINT FK_Vendedor_Almacen
	ALTER TABLE dbo.Vendedor
		DROP CONSTRAINT FK_Vendedor_Terminal
	ALTER TABLE dbo.Vendedor
		DROP CONSTRAINT FK_Vendedor_MOTConfiguracion
	ALTER TABLE dbo.Vendedor
		DROP CONSTRAINT DF_Vendedor_CapturaFolioFac
	ALTER TABLE dbo.Vendedor
		DROP CONSTRAINT DF_Vendedor_JornadaTrabajo
	ALTER TABLE dbo.Vendedor
		DROP CONSTRAINT DF_Vendedor_MostrarCuota
	ALTER TABLE dbo.Vendedor
		DROP CONSTRAINT DF_Vendedor_EditarDatosFiscal
	ALTER TABLE dbo.Vendedor
		DROP CONSTRAINT DF_Vendedor_Kilometraje
	
	CREATE TABLE dbo.Tmp_Vendedor_1
		(
		VendedorID varchar(16) NOT NULL,
		MCNClave varchar(16) NULL,
		Nombre varchar(64) NOT NULL,
		Tipo smallint NOT NULL,
		ModuloClave varchar(16) NULL,
		AlmacenID varchar(16) NULL,
		TipoCapturaProductos smallint NOT NULL,
		Nivel smallint NOT NULL,
		LimiteDescuento float(53) NOT NULL,
		TipoEstado smallint NOT NULL,
		USUId varchar(16) NOT NULL,
		TerminalClave varchar(25) NULL,
		Baja bit NOT NULL,
		ActualizaEsquema bit NOT NULL,
		CapturaPrecio bit NOT NULL,
		DirInterfazSalida varchar(200) NULL,
		MostrarEsquema bit NOT NULL,
		CapturaFolioFac bit NOT NULL,
		JornadaTrabajo bit NOT NULL,
		MostrarCuota bit NOT NULL,
		MantenerPrm bit NOT NULL,
		TipoModImp smallint NULL,
		EditarDatosFiscal bit NOT NULL,
		Kilometraje bit NOT NULL,
		MFechaHora datetime NOT NULL,
		MUsuarioID varchar(16) NOT NULL
	)  ON [PRIMARY]
	ALTER TABLE dbo.Tmp_Vendedor_1 ADD CONSTRAINT
		DF_Vendedor_CapturaFolioFac DEFAULT ((0)) FOR CapturaFolioFac
	ALTER TABLE dbo.Tmp_Vendedor_1 ADD CONSTRAINT
		DF_Vendedor_JornadaTrabajo DEFAULT ((1)) FOR JornadaTrabajo
	ALTER TABLE dbo.Tmp_Vendedor_1 ADD CONSTRAINT
		DF_Vendedor_MostrarCuota DEFAULT ((1)) FOR MostrarCuota
	ALTER TABLE dbo.Tmp_Vendedor_1 ADD CONSTRAINT
		DF_Vendedor_EditarDatosFiscal DEFAULT ((0)) FOR EditarDatosFiscal
	ALTER TABLE dbo.Tmp_Vendedor_1 ADD CONSTRAINT
		DF_Vendedor_Kilometraje DEFAULT ((0)) FOR Kilometraje
	IF EXISTS(SELECT * FROM dbo.Vendedor)
		 EXEC('INSERT INTO dbo.Tmp_Vendedor_1 (VendedorID, MCNClave, Nombre, Tipo, ModuloClave, AlmacenID, TipoCapturaProductos, Nivel, LimiteDescuento, TipoEstado, USUId, TerminalClave, Baja, ActualizaEsquema, CapturaPrecio, DirInterfazSalida, MostrarEsquema, CapturaFolioFac, JornadaTrabajo, MostrarCuota, MantenerPrm, TipoModImp, EditarDatosFiscal, Kilometraje, MFechaHora, MUsuarioID)
			SELECT VendedorID, MCNClave, Nombre, 1, ModuloClave, AlmacenID, TipoCapturaProductos, Nivel, LimiteDescuento, TipoEstado, USUId, TerminalClave, Baja, ActualizaEsquema, CapturaPrecio, DirInterfazSalida, MostrarEsquema, CapturaFolioFac, JornadaTrabajo, MostrarCuota, MantenerPrm, TipoModImp, EditarDatosFiscal, Kilometraje, MFechaHora, MUsuarioID FROM dbo.Vendedor WITH (HOLDLOCK TABLOCKX)')
	ALTER TABLE dbo.FOSHist
		DROP CONSTRAINT FK_FOSHist_Vendedor
	ALTER TABLE dbo.AgendaVendedor
		DROP CONSTRAINT FK_AgendaVendedor_Vendedor
	ALTER TABLE dbo.FolioUsuario
		DROP CONSTRAINT FK_FolioUsuario_Vendedor
	ALTER TABLE dbo.VenRut
		DROP CONSTRAINT FK_VenRut_Vendedor
	ALTER TABLE dbo.VendedorDescuento
		DROP CONSTRAINT FK_VendedorDescuento_Vendedor
	ALTER TABLE dbo.CUOVen
		DROP CONSTRAINT FK_CUOVen_Vendedor
	ALTER TABLE dbo.VendedorEsquema
		DROP CONSTRAINT FK_VendedorEsquema_Vendedor
	ALTER TABLE dbo.Gasto
		DROP CONSTRAINT FK_Gasto_Vendedor
	ALTER TABLE dbo.VENCentroDistHist
		DROP CONSTRAINT FK_VENCentroDistHist_Vendedor
	ALTER TABLE dbo.VendedorJornada
		DROP CONSTRAINT FK_VendedorJornada_Vendedor
	ALTER TABLE dbo.Agenda
		DROP CONSTRAINT FK_Agenda_Vendedor
	ALTER TABLE dbo.Visita
		DROP CONSTRAINT FK_Visita_Vendedor
	ALTER TABLE dbo.PuntoGPS
		DROP CONSTRAINT FK_PuntoGPS_Vendedor
	ALTER TABLE dbo.CamionVendedor
		DROP CONSTRAINT FK_CamionVendedor_Vendedor
	DROP TABLE dbo.Vendedor
	EXECUTE sp_rename N'dbo.Tmp_Vendedor_1', N'Vendedor', 'OBJECT' 
	ALTER TABLE dbo.Vendedor ADD CONSTRAINT
		PK_Vendedor PRIMARY KEY CLUSTERED 
		(
		VendedorID
		) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

	ALTER TABLE dbo.Vendedor WITH NOCHECK ADD CONSTRAINT
		FK_Vendedor_MOTConfiguracion FOREIGN KEY
		(
		MCNClave
		) REFERENCES dbo.MOTConfiguracion
		(
		MCNClave
		) ON UPDATE  NO ACTION 
		 ON DELETE  NO ACTION 
		
	ALTER TABLE dbo.Vendedor WITH NOCHECK ADD CONSTRAINT
		FK_Vendedor_Terminal FOREIGN KEY
		(
		TerminalClave
		) REFERENCES dbo.Terminal
		(
		TerminalClave
		) ON UPDATE  NO ACTION 
		 ON DELETE  NO ACTION 
		
	ALTER TABLE dbo.Vendedor WITH NOCHECK ADD CONSTRAINT
		FK_Vendedor_Almacen FOREIGN KEY
		(
		AlmacenID
		) REFERENCES dbo.Almacen
		(
		AlmacenID
		) ON UPDATE  NO ACTION 
		 ON DELETE  NO ACTION 
		
	ALTER TABLE dbo.Vendedor WITH NOCHECK ADD CONSTRAINT
		FK_Vendedor_ModuloTerm FOREIGN KEY
		(
		ModuloClave
		) REFERENCES dbo.ModuloTerm
		(
		ModuloClave
		) ON UPDATE  NO ACTION 
		 ON DELETE  NO ACTION 
		
	ALTER TABLE dbo.CamionVendedor WITH NOCHECK ADD CONSTRAINT
		FK_CamionVendedor_Vendedor FOREIGN KEY
		(
		VendedorId
		) REFERENCES dbo.Vendedor
		(
		VendedorID
		) ON UPDATE  NO ACTION 
		 ON DELETE  NO ACTION 
		

	ALTER TABLE dbo.PuntoGPS WITH NOCHECK ADD CONSTRAINT
		FK_PuntoGPS_Vendedor FOREIGN KEY
		(
		VendedorId
		) REFERENCES dbo.Vendedor
		(
		VendedorID
		) ON UPDATE  NO ACTION 
		 ON DELETE  NO ACTION 
		
	ALTER TABLE dbo.Visita WITH NOCHECK ADD CONSTRAINT
		FK_Visita_Vendedor FOREIGN KEY
		(
		VendedorID
		) REFERENCES dbo.Vendedor
		(
		VendedorID
		) ON UPDATE  NO ACTION 
		 ON DELETE  NO ACTION 
	ALTER TABLE dbo.Agenda WITH NOCHECK ADD CONSTRAINT
		FK_Agenda_Vendedor FOREIGN KEY
		(
		VendedorId
		) REFERENCES dbo.Vendedor
		(
		VendedorID
		) ON UPDATE  NO ACTION 
		 ON DELETE  NO ACTION 
		
	ALTER TABLE dbo.VendedorJornada WITH NOCHECK ADD CONSTRAINT
		FK_VendedorJornada_Vendedor FOREIGN KEY
		(
		VendedorId
		) REFERENCES dbo.Vendedor
		(
		VendedorID
		) ON UPDATE  NO ACTION 
		 ON DELETE  NO ACTION 
		
	ALTER TABLE dbo.VENCentroDistHist WITH NOCHECK ADD CONSTRAINT
		FK_VENCentroDistHist_Vendedor FOREIGN KEY
		(
		VendedorId
		) REFERENCES dbo.Vendedor
		(
		VendedorID
		) ON UPDATE  NO ACTION 
		 ON DELETE  NO ACTION 
		
	ALTER TABLE dbo.Gasto WITH NOCHECK ADD CONSTRAINT
		FK_Gasto_Vendedor FOREIGN KEY
		(
		VendedorID
		) REFERENCES dbo.Vendedor
		(
		VendedorID
		) ON UPDATE  NO ACTION 
		 ON DELETE  NO ACTION 
		
	ALTER TABLE dbo.VendedorEsquema WITH NOCHECK ADD CONSTRAINT
		FK_VendedorEsquema_Vendedor FOREIGN KEY
		(
		VendedorID
		) REFERENCES dbo.Vendedor
		(
		VendedorID
		) ON UPDATE  NO ACTION 
		 ON DELETE  NO ACTION 
		
	ALTER TABLE dbo.CUOVen WITH NOCHECK ADD CONSTRAINT
		FK_CUOVen_Vendedor FOREIGN KEY
		(
		VendedorID
		) REFERENCES dbo.Vendedor
		(
		VendedorID
		) ON UPDATE  NO ACTION 
		 ON DELETE  NO ACTION 
		
	ALTER TABLE dbo.VendedorDescuento WITH NOCHECK ADD CONSTRAINT
		FK_VendedorDescuento_Vendedor FOREIGN KEY
		(
		VendedorID
		) REFERENCES dbo.Vendedor
		(
		VendedorID
		) ON UPDATE  NO ACTION 
		 ON DELETE  NO ACTION 
		
	ALTER TABLE dbo.VenRut WITH NOCHECK ADD CONSTRAINT
		FK_VenRut_Vendedor FOREIGN KEY
		(
		VendedorID
		) REFERENCES dbo.Vendedor
		(
		VendedorID
		) ON UPDATE  NO ACTION 
		 ON DELETE  NO ACTION 
		
	ALTER TABLE dbo.FolioUsuario WITH NOCHECK ADD CONSTRAINT
		FK_FolioUsuario_Vendedor FOREIGN KEY
		(
		VendedorID
		) REFERENCES dbo.Vendedor
		(
		VendedorID
		) ON UPDATE  NO ACTION 
		 ON DELETE  NO ACTION 
		
	ALTER TABLE dbo.AgendaVendedor WITH NOCHECK ADD CONSTRAINT
		FK_AgendaVendedor_Vendedor FOREIGN KEY
		(
		VendedorId
		) REFERENCES dbo.Vendedor
		(
		VendedorID
		) ON UPDATE  NO ACTION 
		 ON DELETE  NO ACTION 
		
	ALTER TABLE dbo.FOSHist WITH NOCHECK ADD CONSTRAINT
		FK_FOSHist_Vendedor FOREIGN KEY
		(
		VendedorID
		) REFERENCES dbo.Vendedor
		(
		VendedorID
		) ON UPDATE  NO ACTION 
		 ON DELETE  NO ACTION 
		
END