USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[up_Movimientos]    Script Date: 08/25/2011 11:52:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[up_Movimientos]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[up_Movimientos]
GO

USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[up_Movimientos]    Script Date: 08/25/2011 11:52:06 ******/
SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER OFF
GO




CREATE PROCEDURE [dbo].[up_Movimientos]
@IdCedis as bigint,
@IdMovimiento as bigint,
@Fecha as datetime,
@IdTipoMovimiento as bigint,
@Observaciones as varchar(5000),
@Folio as varchar(15),
@Status as char(1),
@Opc as int

AS

if @Opc = 1
begin
	set @IdMovimiento = isnull((Select max(IdMovimiento) from Movimientos where  IdCedis = @IdCedis)+1,1)	
	insert into Movimientos values (@IdCedis, @IdMovimiento, @Fecha, @IdTipoMovimiento, @Observaciones, @Folio, 'P')
end

if @Opc = 2
	update Movimientos set Observaciones = @Observaciones, Folio = @Folio
	where IdCedis = @IdCedis and IdMovimiento = @IdMovimiento

if @Opc = 3 and @Status = 'A' -- Cambio de Status a A para Aplicar 
begin

	-- Inserta las partidas que no estén en el Inventario Inicial	
	insert into InventarioInicial
	select @IdCedis, year(@Fecha), month(@Fecha), MovimientosDetalle.IdProducto, 0, 'A','T'
	from MovimientosDetalle 
	where MovimientosDetalle.IdCedis = @IdCedis and MovimientosDetalle.IdMovimiento = @IdMovimiento
	and MovimientosDetalle.IdProducto not in
	(
	select InventarioInicial.IdProducto from InventarioInicial where InventarioInicial.IdCedis = @IdCedis and InventarioInicial.Agno = year(@Fecha) and InventarioInicial.Mes = month(@Fecha)
	)

	-- Inserta las partidas que no estén en el Kardex
	insert into InventarioKardex
	select MovimientosDetalle.IdCedis, @Fecha, MovimientosDetalle.IdProducto, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0
	from MovimientosDetalle 
	where MovimientosDetalle.IdCedis = @IdCedis and MovimientosDetalle.IdMovimiento = @IdMovimiento
	and MovimientosDetalle.IdProducto not in
	(
	select InventarioKardex.IdProducto from InventarioKardex where InventarioKardex.IdCedis = @IdCedis and InventarioKardex.Fecha = @Fecha
	)

	-- Actualiza las columnas del Kardex
	set @IdTipoMovimiento = isnull( (select IdTipoMovimiento from Movimientos where IdCedis = @IdCedis and IdMovimiento = @IdMovimiento ) , 0)
	if (select EntradaSalida from TipoMovimiento where IdTipoMovimiento = @IdTipoMovimiento and IdCedis = @IdCedis) = 'E'	
		update InventarioKardex set InventarioKardex.Entradas = InventarioKardex.Entradas + 
		isnull( (select MovimientosDetalle.Cantidad from MovimientosDetalle where MovimientosDetalle.IdCedis = @IdCedis and MovimientosDetalle.IdMovimiento = @IdMovimiento and MovimientosDetalle.IdProducto = InventarioKardex.IdProducto), 0 )
		where InventarioKardex.IdCedis =@IdCedis and InventarioKardex.Fecha = @Fecha
	else
		update InventarioKardex set InventarioKardex.Salidas = InventarioKardex.Salidas + 
		isnull( (select MovimientosDetalle.Cantidad from MovimientosDetalle where MovimientosDetalle.IdCedis = @IdCedis and MovimientosDetalle.IdMovimiento = @IdMovimiento and MovimientosDetalle.IdProducto = InventarioKardex.IdProducto), 0)
		where InventarioKardex.IdCedis = @IdCedis and InventarioKardex.Fecha = @Fecha

	-- Cambia el Status al Documento
	update Movimientos set Status = @Status
	where IdCedis = @IdCedis and IdMovimiento = @IdMovimiento

end

if @Opc = 4 and @Status = 'B' -- Cambio de Status a B para dar de Baja
begin
	delete from MovimientosDetalle where IdCedis = @IdCedis and IdMovimiento = @IdMovimiento
	delete from Movimientos where IdCedis = @IdCedis and IdMovimiento = @IdMovimiento
end

GO


USE [Route] 
GO

if (Select COUNT(*) from VersionBD where Tipo = 'SA' and Version ='3.8.16.1') = 0
BEGIN
	INSERT INTO VersionBD (Tipo, FechaHora, Version, MaximoConsecutivo, VersionSql ) 
	VALUES('SA', GETDATE(), '3.8.16.1', 66, (SELECT  cast(SERVERPROPERTY('productversion') as varchar(50))))
END
ELSE
BEGIN 
	Update VersionBD  set MaximoConsecutivo = 66 where  Tipo = 'SA' and Version ='3.8.16.1'
END
GO