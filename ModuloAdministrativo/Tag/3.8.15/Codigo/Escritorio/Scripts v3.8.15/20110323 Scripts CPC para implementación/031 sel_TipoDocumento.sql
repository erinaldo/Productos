USE [RouteCPC]
GO

/****** Object:  StoredProcedure [dbo].[sel_TipoDocumento]    Script Date: 03/08/2011 12:17:29 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sel_TipoDocumento]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sel_TipoDocumento]
GO

USE [RouteCPC]
GO

/****** Object:  StoredProcedure [dbo].[sel_TipoDocumento]    Script Date: 03/08/2011 12:17:29 ******/
SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER OFF
GO

CREATE PROCEDURE [dbo].[sel_TipoDocumento]
@IdDocumento as varchar(5),
@Opc as int
AS

if @Opc = 1
	select DocumentosTipo.IdTipoDocumento, DocumentosTipo.TipoDocumento + ' - ' +
	case DocumentosTipo.CargoAbono 
		when 'C' then 'Cargo'
		when 'A' then 'Abono'
	end as StrDocumento, DocumentosTipo.CargoAbono, isnull(Configuracion.IdDocumentoAnticipo,'') as IdDocumentoAnticipo, isnull(Configuracion.IdTipoDocumentoAnticipo,'') as IdTipoDocumentoAnticipo,
	case CFD when 1 then 'S' else 'N' end as CFD
	from Documentos
	inner join DocumentosTipo on DocumentosTipo.IdDocumento = Documentos.IdDocumento
	left outer join Configuracion on Configuracion.IdDocumentoPagoAnt = Documentos.IdDocumento and Configuracion.IdTipoDocumentoPagoAnt = DocumentosTipo.IdTipoDocumento 
	where DocumentosTipo.Status = 'A' and DocumentosTipo.IdDocumento = @IdDocumento
	order by DocumentosTipo.IdDocumento

GO


