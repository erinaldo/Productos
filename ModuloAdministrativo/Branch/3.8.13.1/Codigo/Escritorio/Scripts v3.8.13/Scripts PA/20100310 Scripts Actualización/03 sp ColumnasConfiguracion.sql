ALTER TABLE Configuracion
	ADD LiquidacionComisiones char(1)
	ADD LiquidacionEfectivo char(1)
	ADD LiquidacionSaldoVendedor char(1)
	ADD LiquidacionSaldoClientes char(1)
	ADD LiquidacionSaldoEnvase char(1)

GO

update configuracion set 
LiquidacionComisiones = 'S',
LiquidacionEfectivo = 'S',
LiquidacionSaldoVendedor = 'S',
LiquidacionSaldoClientes = 'S',
LiquidacionSaldoEnvase = 'S'
