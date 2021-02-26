USE [RouteCPC]
GO

/****** Object:  StoredProcedure [dbo].[sel_DocumentosTipo]    Script Date: 03/10/2011 12:23:47 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sel_DocumentosTipo]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sel_DocumentosTipo]
GO

USE [RouteCPC]
GO

/****** Object:  StoredProcedure [dbo].[sel_DocumentosTipo]    Script Date: 03/10/2011 12:23:47 ******/
SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER OFF
GO

CREATE PROCEDURE [dbo].[sel_DocumentosTipo] 
@IdDocumento as varchar(5),
@CargoAbono as varchar(1),
@Opc as int

AS

if @Opc = 1
	select IdDocumento, IdTipoDocumento, TipoDocumento, case CFD when 1 then 'SI' else 'NO' end As CFD,
	case Status 
		when 'A' then 'Activo'
		when 'B' then 'Baja'
	end as Status
	from DocumentosTipo
	where IdDocumento = @IdDocumento and CargoAbono = @CargoAbono

if @Opc = 2
	select IdDocumento, TipoDocumento, IdTipoDocumento, case CFD when 1 then 'SI' else 'NO' end As CFD,
	case Status 
		when 'A' then 'Activo'
		when 'B' then 'Baja'
	end as Status
	from DocumentosTipo
	where IdDocumento = @IdDocumento and CargoAbono = @CargoAbono

GO


