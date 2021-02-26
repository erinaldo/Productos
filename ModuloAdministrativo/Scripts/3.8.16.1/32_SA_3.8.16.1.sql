USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[sel_PreventaRoute]    Script Date: 07/29/2011 14:00:21 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sel_PreventaRoute]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sel_PreventaRoute]
GO

USE [RouteADM] 
GO

/****** Object:  StoredProcedure [dbo].[sel_PreventaRoute]    Script Date: 07/29/2011 14:00:21 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




CREATE PROCEDURE [dbo].[sel_PreventaRoute]
@FechaInicial as varchar(20),
@FechaFinal as varchar(20),
@Filtro as varchar(1000),
@Opc as int
AS

if @Opc = 1
begin

	exec(
	'SELECT cast(right(VIS.RUTClave,4) as bigint) as RutaPreventa, 
	VIS.FechaHoraInicial as FechaVisita, 	
	TRP.FOLIO+''-''+ case when TRP.TipoFase <> 2 then '''' else left(cast(TRP.FechaSurtido as varchar),11) end as ''Ruta-Folio-FechaSurtido'', 
	LEFT(VAD.Descripcion,10) as ''Forma de Venta'', TRP.ClienteClave, ClienteSucursal.NombreSucursal, 
	ClienteSucursal.Calle + '' '' + ClienteSucursal.NumExterior + '' '' + ClienteSucursal.NumInterior + '', '' + ClienteSucursal.Colonia + '', '' + ClienteSucursal.Localidad as Domicilio, 
	TRP.Total, 
	case TRP.TipoFase when ''0'' then ''Cancelado'' when ''1'' then ''Preventa'' else ''Entregado'' end as Status,
	TRP.TransprodID	
	FROM Route.dbo.TransProd TRP
	INNER JOIN Route.dbo.Dia DIA ON DIA.DiaClave = TRP.DiaClave
	INNER JOIN Route.dbo.Visita VIS ON VIS.DiaClave = TRP.DiaClave AND VIS.VisitaClave = TRP.VisitaClave 
	inner join Route.dbo.VAVDescripcion VAD ON TRP.CFVTipo = VAD.VAVClave AND VAD.VARCodigo = ''FVENTA'' and VAD.VADTipoLenguaje = (select top 1 TipoLenguaje from Route.dbo.CONHist order by MFechaHora desc)
	left outer join ClienteSucursal on ClienteSucursal.IdSucursal = TRP.ClienteClave and ClienteSucursal.IdCedis = cast(SUBSTRING(VIS.RUTClave,1,len(VIS.RUTClave)-4) as bigint)	
	WHERE DIA.FechaCaptura BETWEEN ''' + @FechaInicial + ''' AND ''' + @FechaFinal + '''
	AND VIS.RUTClave in (' + @Filtro + ') AND TRP.Tipo = 1 -- AND TRP.TipoFase = 1
	order by VIS.RUTClave, DIA.FechaCaptura, TRP.TipoFase, NombreSucursal')
	
end



GO



USE [Route]
GO

if (Select COUNT(*) from VersionBD where Tipo = 'SA' and Version ='3.8.16.1') = 0
BEGIN
	INSERT INTO VersionBD (Tipo, FechaHora, Version, MaximoConsecutivo, VersionSql ) 
	VALUES('SA', GETDATE(), '3.8.16.1', 32, (SELECT  cast(SERVERPROPERTY('productversion') as varchar(50))))
END
ELSE
BEGIN 
	Update VersionBD  set MaximoConsecutivo = 32 where  Tipo = 'SA' and Version ='3.8.16.1'
END
GO