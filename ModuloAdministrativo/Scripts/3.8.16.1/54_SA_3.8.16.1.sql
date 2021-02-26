USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[sel_StatusRutas]    Script Date: 08/10/2011 12:21:05 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sel_StatusRutas]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sel_StatusRutas]
GO

USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[sel_StatusRutas]    Script Date: 08/10/2011 12:21:05 ******/
SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER OFF
GO







CREATE PROCEDURE [dbo].[sel_StatusRutas]
@IdCedis as bigint,
@Fecha as datetime,
@IdRuta as bigint,
@Opc as int
AS

if @Opc = 1 
Begin
	select StatusRutas.IdCedis, StatusRutas.Fecha, StatusRutas.IdRuta as 'No.', Rutas.Ruta as 'Ruta', StatusRutas.Status as 'Estatus', StatusDesc as 'Descripción'
	from StatusRutas
	inner join Rutas on Rutas.IdRuta = StatusRutas.IdRuta and Rutas.IdCedis = @IdCedis
	where StatusRutas.IdCedis = @IdCedis and StatusRutas.Fecha = @Fecha
End

-- NGC - REQBEL01 - Se agrega consulta para mostrar las rutas en Calculo de Costos de Kilometrajes
if @Opc = 2 
Begin
	select  R.IDRUTA as 'Clave', R.RUTA as 'Ruta', T.TIPORUTA as 'Especialización', 
		R.TipoVenta as 'TipoVenta', case CFD when 1 then 'S' else 'N' end as CFD, 
		case R.Status 
			when 'A' then 'Activo'
			else 'Baja'
		end as 'Estatus'
		from RUTAS R, TIPORUTA T
		WHERE R.TIPORUTA = T.IDTIPORUTA and  IdCedis = @IdCedis
		order by R.IDRUTA
End

-- NGC - REQBEL01 - Se agrega consulta para mostrar las rutas sin movimientos en un día en específico
if @Opc = 3 
Begin
	SELECT	RUT.IdCedis, @Fecha AS Fecha, RUT.IdRuta, 
			isnull(cast(TPNLIQ.IdTipoNoLiquidacion as varchar(5)), 'SR') as [MotivoNoLiquidacion],
			cast(RUT.IdRuta as varchar(5)) + ' - ' + RUT.Ruta AS Ruta, 
			case SUR.Status when 'C' then 'Aplicado' when 'P' then 'En Proceso' else 'Sin Liquidación' end AS 'Estatus', 
			isnull(cast(TPNLIQ.IdTipoNoLiquidacion as varchar(5)) + ' - ' + 
			TPNLIQ.TipoNoLiquidacion, 'Sin Registro') as [Concepto de No Liquidación]		
	FROM    Rutas AS RUT
	LEFT OUTER JOIN Surtidos AS SUR ON SUR.IdCedis = RUT.IdCedis AND SUR.IdRuta = RUT.IdRuta AND SUR.Fecha = @Fecha
	LEFT OUTER JOIN RutasNoLiquidacion AS RUTNLIQ ON RUT.IdCedis = RUTNLIQ.IdCedis AND RUT.IdRuta = RUTNLIQ.IdRuta AND RUTNLIQ.Fecha = @Fecha 
	LEFT OUTER JOIN TipoNoLiquidacion AS TPNLIQ ON RUTNLIQ.IdTipoNoLiquidacion = TPNLIQ.IdTipoNoLiquidacion 
	WHERE RUT.IdCedis = @IdCedis AND RUT.Status = 'A' and SUR.IdSurtido IS NULL AND RUT.TipoVenta IN ('Venta', 'Reparto')
	ORDER BY RUT.IdCedis, RUT.IdRuta 
	
End

-- NGC - REQBEL01 - Se agrega consulta para la validacion de cierre de dia, rutas sin movimientos faltantes de registro de No Liquidacion
if @Opc = 4 
Begin
	SELECT	RUT.IdCedis, RUT.IdRuta
	FROM    Rutas AS RUT
	LEFT OUTER JOIN Surtidos AS SUR ON SUR.IdCedis = RUT.IdCedis AND SUR.IdRuta = RUT.IdRuta AND SUR.Fecha = @Fecha
	LEFT OUTER JOIN RutasNoLiquidacion AS RUTNLIQ ON RUT.IdCedis = RUTNLIQ.IdCedis AND RUT.IdRuta = RUTNLIQ.IdRuta AND RUTNLIQ.Fecha = @Fecha 
	LEFT OUTER JOIN TipoNoLiquidacion AS TPNLIQ ON RUTNLIQ.IdTipoNoLiquidacion = TPNLIQ.IdTipoNoLiquidacion 
	WHERE RUT.IdCedis = @IdCedis AND RUT.Status = 'A' and SUR.IdSurtido IS NULL and RUTNLIQ.IdTipoNoLiquidacion IS NULL AND RUT.TipoVenta IN ('Venta', 'Reparto','Preventa')

End

if @Opc = 5
begin
	select IdCedis, IdRuta, Fecha 
	from RutasNoLiquidacion 
	where IdCedis = @IdCedis and Fecha = @Fecha and IdRuta = @IdRuta 
end



GO



USE [Route]
GO

if (Select COUNT(*) from VersionBD where Tipo = 'SA' and Version ='3.8.16.1') = 0
BEGIN
	INSERT INTO VersionBD (Tipo, FechaHora, Version, MaximoConsecutivo, VersionSql ) 
	VALUES('SA', GETDATE(), '3.8.16.1', 54, (SELECT  cast(SERVERPROPERTY('productversion') as varchar(50))))
END
ELSE
BEGIN 
	Update VersionBD  set MaximoConsecutivo = 54 where  Tipo = 'SA' and Version ='3.8.16.1'
END
GO