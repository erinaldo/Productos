USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[up_Bitacora]    Script Date: 08/25/2010 19:22:00 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[up_Bitacora]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[up_Bitacora]
GO

USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[up_Bitacora]    Script Date: 08/25/2010 19:22:00 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[up_Bitacora] 
@Login as varchar(10),
@IdCedis as bigint,
@IdSurtido as bigint,
@IdCarga as bigint,
@IdMovimiento as bigint,
@IdTipoVenta as int,
@Serie as varchar(5),
@Folio as bigint,
@FechaTrabajo as datetime,
@IdRuta as bigint,
@IdCliente as bigint,
@IdSucursal as varchar(16),
@IdProducto as bigint,
@Accion as varchar(16),
@Detalle as varchar(5000),
@Opc as int

AS

if @Opc = 1 -- Movimientos de Almacén
begin
	if @IdProducto = 0 -- alta o baja de mov de alm
	begin
		if not exists( select FolioAccion from Bitacora where IdCedis = @IdCedis and IdMovimiento = @IdMovimiento and Accion = @Accion and Modulo = 'ALMACÉN' )
			insert into Bitacora values (RIGHT(newid(),20), @Login, @IdCedis, null, null, @IdMovimiento, null, null, null, @FechaTrabajo, null, null, null, null, 'ALMACÉN', @Accion, GETDATE(), @Detalle) 
		else
			update Bitacora 
				set Login = @Login, FechaEjecucion = GETDATE(), Detalle = @Detalle
			where IdCedis = @IdCedis and IdMovimiento = @IdMovimiento and Accion = @Accion and Modulo = 'ALMACÉN'
	end
	else
	begin
		if not exists( select FolioAccion from Bitacora where IdCedis = @IdCedis and IdMovimiento = @IdMovimiento and Accion = @Accion and Modulo = 'ALMACÉN' and IdProducto = @IdProducto )
			insert into Bitacora values (RIGHT(newid(),20), @Login, @IdCedis, null, null, @IdMovimiento, null, null, null, @FechaTrabajo, null, null, null, @IdProducto, 'ALMACÉN', @Accion, GETDATE(), @Detalle) 
		else
			update Bitacora 
				set Login = @Login, FechaEjecucion = GETDATE(), Detalle = @Detalle
			where IdCedis = @IdCedis and IdMovimiento = @IdMovimiento and Accion = @Accion and Modulo = 'ALMACÉN' and IdProducto = @IdProducto
	end		
end

if @Opc = 2 -- Liquidaciones
begin
	if @IdProducto = 0 -- alta o baja de liquidación
	begin
		if not exists( select FolioAccion from Bitacora where IdCedis = @IdCedis and IdSurtido = @IdSurtido and Accion = @Accion and Modulo = 'LIQUIDACIONES' )
			insert into Bitacora values (RIGHT(newid(),20), @Login, @IdCedis, @IdSurtido, @IdCarga, null, null, null, null, @FechaTrabajo, @IdRuta, null, null, null, 'LIQUIDACIONES', @Accion, GETDATE(), @Detalle) 
		else
			update Bitacora 
				set Login = @Login, FechaEjecucion = GETDATE(), Detalle = @Detalle
			where IdCedis = @IdCedis and IdSurtido = @IdSurtido and Accion = @Accion and Modulo = 'LIQUIDACIONES'
	end
	else
	begin
		if not exists( select FolioAccion from Bitacora where IdCedis = @IdCedis and IdSurtido = @IdSurtido and Accion = @Accion and Modulo = 'LIQUIDACIONES' and IdProducto = @IdProducto )
			insert into Bitacora values (RIGHT(newid(),20), @Login, @IdCedis, @IdSurtido, @IdCarga, null, null, null, null, @FechaTrabajo, @IdRuta, null, null, @IdProducto, 'LIQUIDACIONES', @Accion, GETDATE(), @Detalle) 
		else
			update Bitacora 
				set Login = @Login, FechaEjecucion = GETDATE(), Detalle = @Detalle
			where IdCedis = @IdCedis and IdSurtido = @IdSurtido and Accion = @Accion and Modulo = 'LIQUIDACIONES' and IdProducto = @IdProducto
	end		
end

if @Opc = 3 -- Cargas 
begin
	if @IdProducto = 0 -- alta o baja de carga
	begin
		if not exists( select FolioAccion from Bitacora where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdCarga = @IdCarga and Accion = @Accion and Modulo = 'CARGAS' )
			insert into Bitacora values (RIGHT(newid(),20), @Login, @IdCedis, @IdSurtido, @IdCarga, null, null, null, null, @FechaTrabajo, @IdRuta, null, null, null, 'CARGAS', @Accion, GETDATE(), @Detalle) 
		else
			update Bitacora 
				set Login = @Login, FechaEjecucion = GETDATE(), Detalle = @Detalle
			where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdCarga = @IdCarga and Accion = @Accion and Modulo = 'CARGAS'
	end
	else
	begin
		if not exists( select FolioAccion from Bitacora where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdCarga = @IdCarga and Accion = @Accion and Modulo = 'CARGAS' and IdProducto = @IdProducto )
			insert into Bitacora values (RIGHT(newid(),20), @Login, @IdCedis, @IdSurtido, @IdCarga, null, null, null, null, @FechaTrabajo, @IdRuta, null, null, @IdProducto, 'CARGAS', @Accion, GETDATE(), @Detalle) 
		else
			update Bitacora 
				set Login = @Login, FechaEjecucion = GETDATE(), Detalle = @Detalle
			where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdCarga = @IdCarga and Accion = @Accion and Modulo = 'CARGAS' and IdProducto = @IdProducto
	end		
end

if @Opc = 4 -- Cargas Sugeridas 
begin
	if @IdProducto = 0 -- alta o baja de carga
	begin
		if not exists( select FolioAccion from Bitacora where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdCarga = @IdCarga and Accion = @Accion and Modulo = 'CARGASUGERIDA' )
			insert into Bitacora values (RIGHT(newid(),20), @Login, @IdCedis, null, @IdCarga, null, null, null, null, @FechaTrabajo, @IdRuta, null, null, null, 'CARGASUGERIDA', @Accion, GETDATE(), @Detalle) 
		else
			update Bitacora 
				set Login = @Login, FechaEjecucion = GETDATE(), Detalle = @Detalle
			where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdCarga = @IdCarga and Accion = @Accion and Modulo = 'CARGASUGERIDA'
	end
	else
	begin
		if not exists( select FolioAccion from Bitacora where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdCarga = @IdCarga and Accion = @Accion and Modulo = 'CARGASUGERIDA' and IdProducto = @IdProducto )
			insert into Bitacora values (RIGHT(newid(),20), @Login, @IdCedis, null, @IdCarga, null, null, null, null, @FechaTrabajo, @IdRuta, null, null, @IdProducto, 'CARGASUGERIDA', @Accion, GETDATE(), @Detalle) 
		else
			update Bitacora 
				set Login = @Login, FechaEjecucion = GETDATE(), Detalle = @Detalle
			where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdCarga = @IdCarga and Accion = @Accion and Modulo = 'CARGASUGERIDA' and IdProducto = @IdProducto
	end		
end

if @Opc = 5 -- Ventas
begin
	if @IdProducto = 0 -- alta o baja de venta
	begin
		if not exists( select FolioAccion from Bitacora where IdCedis = @IdCedis and IdSurtido = @IdSurtido and Serie = @Serie and Folio = @Folio and Accion = @Accion and Modulo = 'VENTAS' )
			insert into Bitacora values (RIGHT(newid(),20), @Login, @IdCedis, @IdSurtido, null, null, @IdTipoVenta, @Serie, @Folio, @FechaTrabajo, @IdRuta, null, null, null, 'VENTAS', @Accion, GETDATE(), @Detalle) 
		else
			update Bitacora 
				set Login = @Login, FechaEjecucion = GETDATE(), Detalle = @Detalle
			where IdCedis = @IdCedis and IdSurtido = @IdSurtido and Serie = @Serie and Folio = @Folio and Accion = @Accion and Modulo = 'VENTAS'
	end
	else
	begin
		if not exists( select FolioAccion from Bitacora where IdCedis = @IdCedis and IdSurtido = @IdSurtido and Serie = @Serie and Folio = @Folio and Accion = @Accion and Modulo = 'VENTAS' and IdProducto = @IdProducto )
			insert into Bitacora values (RIGHT(newid(),20), @Login, @IdCedis, @IdSurtido, null, null, @IdTipoVenta, @Serie, @Folio, @FechaTrabajo, @IdRuta, null, null, @IdProducto, 'VENTAS', @Accion, GETDATE(), @Detalle) 
		else
			update Bitacora 
				set Login = @Login, FechaEjecucion = GETDATE(), Detalle = @Detalle
			where IdCedis = @IdCedis and IdSurtido = @IdSurtido and Serie = @Serie and Folio = @Folio and Accion = @Accion and Modulo = 'VENTAS' and IdProducto = @IdProducto
	end		
end

if @Opc = 6 -- Efectivo y Documentos
begin
	if @IdProducto = 0 -- alta o baja de Folio
	begin
		if not exists( select FolioAccion from Bitacora where IdCedis = @IdCedis and IdSurtido = @IdSurtido and Folio = @Folio and Accion = @Accion and Modulo = 'EFECTIVO' )
			insert into Bitacora values (RIGHT(newid(),20), @Login, @IdCedis, @IdSurtido, null, null, null, null, @Folio, @FechaTrabajo, @IdRuta, null, null, null, 'EFECTIVO', @Accion, GETDATE(), @Detalle) 
		else
			update Bitacora 
				set Login = @Login, FechaEjecucion = GETDATE(), Detalle = @Detalle
			where IdCedis = @IdCedis and IdSurtido = @IdSurtido and Folio = @Folio and Accion = @Accion and Modulo = 'EFECTIVO'
	end
	else
	begin
			insert into Bitacora values (RIGHT(newid(),20), @Login, @IdCedis, @IdSurtido, null, null, null, null, @Folio, @FechaTrabajo, @IdRuta, null, null, null, 'EFECTIVO', @Accion, GETDATE(), @Detalle) 
	end		
end

if @Opc = 7 -- Saldos del Vendedor
begin
	insert into Bitacora values (RIGHT(newid(),20), @Login, @IdCedis, @IdSurtido, null, null, null, null, @Folio, @FechaTrabajo, @IdRuta, null, null, null, 'SALDO VENDEDOR', @Accion, GETDATE(), @Detalle) 
end

if @Opc = 8 -- Pedidos
begin
	if @IdProducto = 0 -- alta o baja de Pedido
	begin
		if not exists( select FolioAccion from Bitacora where IdCedis = @IdCedis and Folio = @Folio and Accion = @Accion and Modulo = 'PEDIDOS' )
			insert into Bitacora values (RIGHT(newid(),20), @Login, @IdCedis, null, null, null, @IdTipoVenta, null, @Folio, @FechaTrabajo, @IdRuta, null, null, null, 'PEDIDOS', @Accion, GETDATE(), @Detalle) 
		else
			update Bitacora 
				set Login = @Login, FechaEjecucion = GETDATE(), Detalle = @Detalle
			where IdCedis = @IdCedis and Folio = @Folio and Accion = @Accion and Modulo = 'PEDIDOS'
	end
	else
	begin
		if not exists( select FolioAccion from Bitacora where IdCedis = @IdCedis and Folio = @Folio and Accion = @Accion and Modulo = 'PEDIDOS' and IdProducto = @IdProducto )
			insert into Bitacora values (RIGHT(newid(),20), @Login, @IdCedis, null, null, null, @IdTipoVenta, null, @Folio, @FechaTrabajo, @IdRuta, null, null, @IdProducto, 'PEDIDOS', @Accion, GETDATE(), @Detalle) 
		else
			update Bitacora 
				set Login = @Login, FechaEjecucion = GETDATE(), Detalle = @Detalle
			where IdCedis = @IdCedis and Folio = @Folio and Accion = @Accion and Modulo = 'PEDIDOS' and IdProducto = @IdProducto
	end		
end

if @Opc = 9 -- Catálogos
begin
	insert into Bitacora values (RIGHT(newid(),20), @Login, @IdCedis, null, null, null, null, null, @Folio, null, null, null, null, null, 'CATÁLOGOS', @Accion, GETDATE(), @Detalle) 
end
