USE [RouteCPC]
GO

/****** Object:  StoredProcedure [dbo].[up_DocumentosTipo]    Script Date: 03/10/2011 12:23:55 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[up_DocumentosTipo]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[up_DocumentosTipo]
GO

USE [RouteCPC]
GO

/****** Object:  StoredProcedure [dbo].[up_DocumentosTipo]    Script Date: 03/10/2011 12:23:55 ******/
SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER OFF
GO

CREATE PROCEDURE [dbo].[up_DocumentosTipo]
@IdDocumento as varchar(5),
@IdTipoDocumento as varchar(5),
@CargoAbono as varchar(1),
@TipoDocumento as varchar(200),
@CFD as bit,
@Status as varchar(1),
@Opc as int

AS

if @Opc = 1
begin
	insert into DocumentosTipo values (@IdDocumento, @IdTipoDocumento, @TipoDocumento, @CargoAbono, 'A', @CFD)
end

if @Opc = 2
begin
	update DocumentosTipo set 
	TipoDocumento = @TipoDocumento,
	CFD = @CFD,
	Status = @Status
	where IdDocumento = @IdDocumento and IdTipoDocumento = @IdTipoDocumento 
end

GO


