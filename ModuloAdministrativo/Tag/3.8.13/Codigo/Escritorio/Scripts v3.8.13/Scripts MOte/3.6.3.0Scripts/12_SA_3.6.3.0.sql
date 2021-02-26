/****** Object:  UserDefinedFunction [dbo].[FNObtenerCEDIADMInter]    Script Date: 04/11/2010 21:55:02 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FNObtenerCEDIADMInter]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[FNObtenerCEDIADMInter]
/*go*/go

/****** Object:  UserDefinedFunction [dbo].[FNObtenerCEDIADMInter]    Script Date: 04/11/2010 21:55:02 ******/
SET ANSI_NULLS ON
/*go*/go

SET QUOTED_IDENTIFIER ON
/*go*/go

-- =============================================
-- Author:		Igor Aviles
-- Create date: 12 Abril 2010
-- Description:	Convertir a formato del modulo administrativo la clave del centro de distribucion bucando en la tabla RouteAdmAlmacenCedis
-- =============================================
CREATE FUNCTION [dbo].[FNObtenerCEDIADMInter] 
(
	@CEDIClaveRoute varchar(10)
)
RETURNS int
AS
BEGIN
	DECLARE @TEMP VARCHAR(10)
	
	SELECT @TEMP = idCedis FROM RouteAdmAlmacenCedis WHERE AlmacenClave = @CEDIClaveRoute
	IF @TEMP IS NULL
	BEGIN
		SET @TEMP = dbo.FNObtenerSoloNumeros(@TEMP)
	END
	
	RETURN CAST(@TEMP AS INT)
END
/*go*/go


