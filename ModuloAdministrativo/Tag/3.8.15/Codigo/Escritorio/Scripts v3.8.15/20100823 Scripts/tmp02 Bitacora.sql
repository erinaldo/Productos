
USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[up_Bitacora]    Script Date: 08/25/2010 09:47:16 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


ALTER PROCEDURE [dbo].[up_Bitacora] 
@Login as varchar(10),
@IdCedis as bigint,
@IdSurtido as bigint,
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
			insert into Bitacora values (RIGHT(newid(),20), @Login, @IdCedis, null, @IdMovimiento, null, null, null, @FechaTrabajo, null, null, null, null, 'ALMACÉN', @Accion, GETDATE(), @Detalle) 
		else
			update Bitacora 
				set Login = @Login, FechaEjecucion = GETDATE(), Detalle = @Detalle
			where IdCedis = @IdCedis and IdMovimiento = @IdMovimiento and Accion = @Accion and Modulo = 'ALMACÉN'
	end
	else
	begin
		if not exists( select FolioAccion from Bitacora where IdCedis = @IdCedis and IdMovimiento = @IdMovimiento and Accion = @Accion and Modulo = 'ALMACÉN' and IdProducto = @IdProducto )
			insert into Bitacora values (RIGHT(newid(),20), @Login, @IdCedis, null, @IdMovimiento, null, null, null, @FechaTrabajo, null, null, null, @IdProducto, 'ALMACÉN', @Accion, GETDATE(), @Detalle) 
		else
			update Bitacora 
				set Login = @Login, FechaEjecucion = GETDATE(), Detalle = @Detalle
			where IdCedis = @IdCedis and IdMovimiento = @IdMovimiento and Accion = @Accion and Modulo = 'ALMACÉN' and IdProducto = @IdProducto
	end		
end

--if @Opc = 2 -- Liquidaciones
--begin
--end

--if @Opc = 3 -- Ventas
--begin
--end

GO