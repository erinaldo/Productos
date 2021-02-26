USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[sel_Rutas]    Script Date: 01/30/2011 23:12:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sel_Rutas]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sel_Rutas]
GO

USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[sel_Rutas]    Script Date: 01/30/2011 23:12:48 ******/
SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER OFF
GO



CREATE PROCEDURE [dbo].[sel_Rutas]
@Cedis as bigint
AS

select  R.IDRUTA as 'Clave', R.RUTA as 'Ruta', T.TIPORUTA as 'Especialización', R.TipoVenta as 'TipoVenta', case CFD when 1 then 'S' else 'N' end as CFD, R.FECHAALTA as 'Estatus',

case R.Status 
	when 'A' then 'Activo'
	else 'Baja'
	end as 'Estatus'
from RUTAS R, TIPORUTA T
WHERE R.TIPORUTA = T.IDTIPORUTA and  IdCedis = @Cedis
order by R.IDRUTA

GO


