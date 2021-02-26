USE [RouteCPC]
GO

/****** Object:  UserDefinedFunction [dbo].[FN_PromocionesFoliosAplicados2]    Script Date: 03/30/2011 20:32:57 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FN_PromocionesFoliosAplicados2]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[FN_PromocionesFoliosAplicados2]
GO

USE [RouteCPC]
GO

/****** Object:  UserDefinedFunction [dbo].[FN_PromocionesFoliosAplicados2]    Script Date: 03/30/2011 20:32:57 ******/
SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER OFF
GO

CREATE FUNCTION [dbo].[FN_PromocionesFoliosAplicados2]
(
@IdPromocion as bigint,
@IdAplicacion as bigint
)  
RETURNS Table AS  
return
(
	select IdAplicacion, IdPromocion, IdCedis, IdTipoVenta, Serie, Folio, Aplicado
	from PromocionesAplicadasDetalle 
	where IdPromocion <> @IdPromocion and substring(Aplicado, 1, 1) = 'A'
)

GO


