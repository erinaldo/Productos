IF (SELECT COUNT(*) FROM SysColumns WHERE Name = 'ServidorSMTP' AND Id = (SELECT Id FROM SysObjects WHERE Name = 'ConHist')) = 0
BEGIN
	ALTER TABLE dbo.CONHist
		DROP CONSTRAINT DF_CONHist_DecimalesImporte
	ALTER TABLE dbo.CONHist
		DROP CONSTRAINT DF_CONHist_DatosCteNuevo
	ALTER TABLE dbo.CONHist
		DROP CONSTRAINT DF_CONHist_VenderApartado
	ALTER TABLE dbo.CONHist
		DROP CONSTRAINT DF_CONHist_VentaSinSurtir
		
	CREATE TABLE dbo.Tmp_CONHist_1
		(
		ConfiguracionID varchar(16) NOT NULL,
		CONHistFechaInicio datetime NOT NULL,
		MonedaID varchar(16) NOT NULL,
		TipoLenguaje varchar(8) NOT NULL,
		TipoClaveProducto smallint NOT NULL,
		DigitoClaveProd smallint NULL,
		AbonoProgramado bit NOT NULL,
		CantidadSerAct int NOT NULL,
		FiltroProductos bit NOT NULL,
		DiasSurtido int NOT NULL,
		DirectorioSDF varchar(200) NOT NULL,
		ClienteVariasRutas bit NOT NULL,
		DirInterfaz varchar(200) NULL,
		InterfazTXT bit NULL,
		DepGarantia bit NOT NULL,
		CuotasGarantia int NOT NULL,
		CodigoBarrasCliente bit NOT NULL,
		ContrasenaCliente bit NOT NULL,
		CambioProducto bit NOT NULL,
		CobrarVentas bit NOT NULL,
		ConversionKg bit NOT NULL,
		IntUnidadVta bit NOT NULL,
		EliminaEnviado bit NOT NULL,
		TicketConfigurado smallint NOT NULL,
		PagoAutomatico bit NOT NULL,
		PreLiquidacion bit NOT NULL,
		DiferenciaPreliqui float(53) NULL,
		DiasAnteriores int NOT NULL,
		DiasPosteriores int NOT NULL,
		AuditarCarga bit NOT NULL,
		Inventario bit NOT NULL,
		ModificarVenta bit NOT NULL,
		MostrarLogo bit NOT NULL,
		EnvioParcial bit NOT NULL,
		TipoLimiteCredito smallint NOT NULL,
		PorcentajeRiesgo float(53) NULL,
		DecimalesImporte smallint NOT NULL,
		ValidaInv bit NOT NULL,
		TipoIniciarVisita smallint NOT NULL,
		LimiteGPS float(53) NULL,
		ClientesVisitados bit NOT NULL,
		DatosCteNuevo bit NOT NULL,
		VenderApartado bit NOT NULL,
		VentaSinSurtir bit NOT NULL,
		ServidorSMTP varchar(100) NULL,
		Puerto int NULL,
		Correo varchar(100) NULL,
		Password varchar(100) NULL,
		SSL bit NOT NULL,
		MFechaHora datetime NOT NULL,
		MUsuarioID varchar(16) NOT NULL
		)  ON [PRIMARY]
	ALTER TABLE dbo.Tmp_CONHist_1 ADD CONSTRAINT
		DF_CONHist_DecimalesImporte DEFAULT ((2)) FOR DecimalesImporte
	ALTER TABLE dbo.Tmp_CONHist_1 ADD CONSTRAINT
		DF_CONHist_DatosCteNuevo DEFAULT ((1)) FOR DatosCteNuevo
	ALTER TABLE dbo.Tmp_CONHist_1 ADD CONSTRAINT
		DF_CONHist_VenderApartado DEFAULT ((0)) FOR VenderApartado
	ALTER TABLE dbo.Tmp_CONHist_1 ADD CONSTRAINT
		DF_CONHist_VentaSinSurtir DEFAULT ((1)) FOR VentaSinSurtir
	ALTER TABLE dbo.Tmp_CONHist_1 ADD CONSTRAINT
		DF_CONHist_SSL DEFAULT ((0)) FOR SSL
	IF EXISTS(SELECT * FROM dbo.CONHist)
		 EXEC('INSERT INTO dbo.Tmp_CONHist_1 (ConfiguracionID, CONHistFechaInicio, MonedaID, TipoLenguaje, TipoClaveProducto, DigitoClaveProd, AbonoProgramado, CantidadSerAct, FiltroProductos, DiasSurtido, DirectorioSDF, ClienteVariasRutas, DirInterfaz, InterfazTXT, DepGarantia, CuotasGarantia, CodigoBarrasCliente, ContrasenaCliente, CambioProducto, CobrarVentas, ConversionKg, IntUnidadVta, EliminaEnviado, TicketConfigurado, PagoAutomatico, PreLiquidacion, DiferenciaPreliqui, DiasAnteriores, DiasPosteriores, AuditarCarga, Inventario, ModificarVenta, MostrarLogo, EnvioParcial, TipoLimiteCredito, PorcentajeRiesgo, DecimalesImporte, ValidaInv, TipoIniciarVisita, LimiteGPS, ClientesVisitados, DatosCteNuevo, VenderApartado, VentaSinSurtir, MFechaHora, MUsuarioID)
			SELECT ConfiguracionID, CONHistFechaInicio, MonedaID, TipoLenguaje, TipoClaveProducto, DigitoClaveProd, AbonoProgramado, CantidadSerAct, FiltroProductos, DiasSurtido, DirectorioSDF, ClienteVariasRutas, DirInterfaz, InterfazTXT, DepGarantia, CuotasGarantia, CodigoBarrasCliente, ContrasenaCliente, CambioProducto, CobrarVentas, ConversionKg, IntUnidadVta, EliminaEnviado, TicketConfigurado, PagoAutomatico, PreLiquidacion, DiferenciaPreliqui, DiasAnteriores, DiasPosteriores, AuditarCarga, Inventario, ModificarVenta, MostrarLogo, EnvioParcial, TipoLimiteCredito, PorcentajeRiesgo, DecimalesImporte, ValidaInv, TipoIniciarVisita, LimiteGPS, ClientesVisitados, DatosCteNuevo, VenderApartado, VentaSinSurtir, MFechaHora, MUsuarioID FROM dbo.CONHist WITH (HOLDLOCK TABLOCKX)')
	DROP TABLE dbo.CONHist
	EXECUTE sp_rename N'dbo.Tmp_CONHist_1', N'CONHist', 'OBJECT' 
	ALTER TABLE dbo.CONHist ADD CONSTRAINT
		PK_CONHist PRIMARY KEY CLUSTERED 
		(
		ConfiguracionID,
		CONHistFechaInicio
		) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
END