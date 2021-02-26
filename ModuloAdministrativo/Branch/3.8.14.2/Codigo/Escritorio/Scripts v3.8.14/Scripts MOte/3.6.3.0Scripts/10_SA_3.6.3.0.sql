/****** Object:  UserDefinedFunction [dbo].[FNObtenerSoloNumeros]    Script Date: 04/11/2010 21:49:13 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FNObtenerSoloNumeros]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[FNObtenerSoloNumeros]
/*go*/go

/****** Object:  UserDefinedFunction [dbo].[FNObtenerSoloNumeros]    Script Date: 04/11/2010 21:49:13 ******/
SET ANSI_NULLS ON
/*go*/go

SET QUOTED_IDENTIFIER ON
/*go*/go

-- =============================================
-- Author:		Igor Aviles
-- Create date: 11 Abril 2010
-- Description:	Para regresar solo los numeros concatenados de una cadena
-- =============================================
CREATE FUNCTION [dbo].[FNObtenerSoloNumeros] 
(
	@CEDIClaveRoute varchar(10)
)
RETURNS varchar(10)
AS
BEGIN
	DECLARE @TEMP VARCHAR(10)
	SET @TEMP = ''
	DECLARE @CAR CHAR(1)
	SET @CAR = ''
	DECLARE @CONT INT 
	SET @CONT = 1
	WHILE LEN(@CEDIClaveRoute) >= @CONT
	BEGIN
		SET @CAR = SUBSTRING(@CEDIClaveRoute,@CONT,1)
		IF ISNUMERIC(@CAR) = 1
		BEGIN
			SET @TEMP= @TEMP + @CAR
		END
		SET @CONT = @CONT +1
	END
	IF LEN(@TEMP) = 0
		SET @TEMP = '0'
	RETURN @TEMP
END

/*go*/go