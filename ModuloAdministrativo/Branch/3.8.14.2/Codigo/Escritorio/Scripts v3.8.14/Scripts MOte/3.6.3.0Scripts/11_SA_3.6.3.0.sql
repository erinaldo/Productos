/****** Object:  UserDefinedFunction [dbo].[FNObtenerRutaADMInter]    Script Date: 04/11/2010 21:52:51 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FNObtenerRutaADMInter]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[FNObtenerRutaADMInter]
/*go*/go

/****** Object:  UserDefinedFunction [dbo].[FNObtenerRutaADMInter]    Script Date: 04/11/2010 21:52:51 ******/
SET ANSI_NULLS ON
/*go*/go

SET QUOTED_IDENTIFIER ON
/*go*/go


-- =============================================
-- Author:		Igor Aviles
-- Create date: 12 Abril 2010
-- Description:	Convertir Clave de ruta al formato del Modulo Administrativo
-- =============================================
CREATE FUNCTION [dbo].[FNObtenerRutaADMInter] 
(
	@RutaRoute varchar(10)
)
RETURNS int
AS
BEGIN
	DECLARE @RECORRER INT
	SELECT top 1 @RECORRER = recorrer FROM RouteAdmRecorrerIdRuta
	IF @RECORRER IS NULL
		SET @RECORRER = 0
	DECLARE @TEMP VARCHAR(10)
	SET @TEMP = ''
	DECLARE @CAR CHAR(1)
	SET @CAR = ''
	DECLARE @CONT INT 
	SET @CONT = 1
	WHILE LEN(@RUTAROUTE) >= @CONT
	BEGIN
		SET @CAR = SUBSTRING(@RUTAROUTE,@CONT,1)
		IF ISNUMERIC(@CAR) = 1
		BEGIN
			IF @RECORRER <= 0
				SET @TEMP= @TEMP + @CAR
			ELSE
				SET @RECORRER = @RECORRER - 1
		END
		SET @CONT = @CONT +1
	END
	
	RETURN CAST(@TEMP AS INT)
END
/*go*/go


