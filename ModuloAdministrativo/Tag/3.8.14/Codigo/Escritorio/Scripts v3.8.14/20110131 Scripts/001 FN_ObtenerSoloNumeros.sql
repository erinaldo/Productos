USE [Route]
GO

/****** Object:  UserDefinedFunction [dbo].[FNObtenerSoloNumeros]    Script Date: 01/31/2011 12:02:29 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FNObtenerSoloNumeros]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[FNObtenerSoloNumeros]
GO

USE [Route]
GO

/****** Object:  UserDefinedFunction [dbo].[FNObtenerSoloNumeros]    Script Date: 01/31/2011 12:02:29 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		Igor Aviles
-- Create date: 11 Abril 2010
-- Description:	Para regresar solo los numeros concatenados de una cadena
-- =============================================
CREATE FUNCTION [dbo].[FNObtenerSoloNumeros] 
(
	@CEDIClaveRoute varchar(20)
)
RETURNS varchar(20)
AS
BEGIN
	DECLARE @TEMP VARCHAR(20)
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



GO


