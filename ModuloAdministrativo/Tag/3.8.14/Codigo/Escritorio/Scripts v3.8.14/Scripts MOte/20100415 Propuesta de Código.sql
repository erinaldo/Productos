	declare @ClaveCEDI as varchar(20)
	declare @DiaClave as varchar(20)
	declare @RUTClave as varchar(20)
	declare @Surtido as varchar(20)
	declare @Dia as datetime
	declare @IdMovimiento as bigint
	
-- ******** código actual

				if not exists(Select * from RouteADM.dbo.Movimientos where IdCedis = @ClaveCEDI and Fecha = @Dia  )
				begin
					set @IdMovimiento = (select Max(idMovimiento) from RouteADM.dbo.Movimientos where IdCedis = @ClaveCEDI ) + 1
					IF @IdMovimiento is null
						SET @IdMovimiento = 1
					insert into RouteADM.dbo.Movimientos values(@ClaveCEDI, @IdMovimiento, @Dia, (select IdMovimientoDevoluciones from RouteADM.dbo.Configuracion where RouteADM.dbo.Configuracion.IdCedis =@ClaveCEDI ) ,'','','A')
				end
				else
				begin
					set @IdMovimiento = (select Max(idMovimiento) from RouteADM.dbo.Movimientos where IdCedis = @ClaveCEDI and Fecha = @Dia )
					IF @IdMovimiento is null
						SET @IdMovimiento = 1
				end

-- ******** propuesta
				if not exists(Select * from RouteADM.dbo.Movimientos where IdCedis = @ClaveCEDI and Fecha = @Dia and IdTipoMovimiento in (select IdMovimientoDevoluciones from RouteADM.dbo.Configuracion where RouteADM.dbo.Configuracion.IdCedis =@ClaveCEDI ))
				begin
					set @IdMovimiento = (select Max(idMovimiento) from RouteADM.dbo.Movimientos where IdCedis = @ClaveCEDI ) + 1
					IF @IdMovimiento is null
						SET @IdMovimiento = 1
					insert into RouteADM.dbo.Movimientos values(@ClaveCEDI, @IdMovimiento, @Dia, (select IdMovimientoDevoluciones from RouteADM.dbo.Configuracion where RouteADM.dbo.Configuracion.IdCedis =@ClaveCEDI ) ,'','','A')
				end
				else
				begin
					set @IdMovimiento = (select IdMovimiento from RouteADM.dbo.Movimientos where IdCedis = @ClaveCEDI and Fecha = @Dia and IdTipoMovimiento in (select IdMovimientoDevoluciones from RouteADM.dbo.Configuracion where RouteADM.dbo.Configuracion.IdCedis =@ClaveCEDI ))
					IF @IdMovimiento is null
						SET @IdMovimiento = 1
				end




				