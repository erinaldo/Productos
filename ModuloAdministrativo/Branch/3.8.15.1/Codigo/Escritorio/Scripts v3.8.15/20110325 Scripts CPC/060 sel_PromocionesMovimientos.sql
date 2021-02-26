USE [RouteCPC]
GO

/****** Object:  StoredProcedure [dbo].[sel_PromocionesMovimientos]    Script Date: 03/28/2011 00:35:51 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sel_PromocionesMovimientos]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sel_PromocionesMovimientos]
GO

USE [RouteCPC]
GO

/****** Object:  StoredProcedure [dbo].[sel_PromocionesMovimientos]    Script Date: 03/28/2011 00:35:51 ******/
SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER OFF
GO

CREATE PROCEDURE [dbo].[sel_PromocionesMovimientos] 
@IdAplicacion as bigint, 
@IdPromocion as bigint, 
@Opc as int

AS

if @Opc = 1
	select PromocionesAplicadasDetalle.IdMovimiento as Folio, Folio.Fecha,
	Documentos.IdDocumento as Documento, DocumentosTipo.IdTipoDocumento as TipoDocumento, 
	-- Documentos.IdDocumento + ' ' + Documento as Documento, DocumentosTipo.IdTipoDocumento + ' ' + TipoDocumento as TipoDocumento, 
	Folio.Monto
	from PromocionesAplicadasDetalle
	inner join Cedis on Cedis.IdCedis = PromocionesAplicadasDetalle.IdCedis
	inner join Folio on Folio.Folio = PromocionesAplicadasDetalle.IdMovimiento
	inner join Documentos on Documentos.IdDocumento = PromocionesAplicadasDetalle.IdDocumento
	inner join DocumentosTipo on DocumentosTipo.IdTipoDocumento = PromocionesAplicadasDetalle.IdTipoDocumento
	where IdAplicacion = @IdAplicacion and IdPromocion = @IdPromocion and substring(Aplicado, 1, 1) = 'A'
	group by PromocionesAplicadasDetalle.IdMovimiento, Folio.Monto, Documentos.IdDocumento, Documento, DocumentosTipo.IdTipoDocumento, TipoDocumento, Folio.Fecha
	order by PromocionesAplicadasDetalle.IdMovimiento

GO


