USE [RouteCPC]
GO

/****** Object:  UserDefinedFunction [dbo].[FN_PromocionesSaldoMonto]    Script Date: 03/30/2011 19:01:54 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FN_PromocionesSaldoMonto]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[FN_PromocionesSaldoMonto]
GO

USE [RouteCPC]
GO

/****** Object:  UserDefinedFunction [dbo].[FN_PromocionesSaldoMonto]    Script Date: 03/30/2011 19:01:54 ******/
SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER OFF
GO

CREATE FUNCTION [dbo].[FN_PromocionesSaldoMonto]
(
@IdAplicacion as bigint,
@IdPromocion as bigint
)  
RETURNS Table AS  
return
(
	select IdAplicacion, IdPromocion, IdCedis, IdTipoVenta, Serie, Folio, sum(Monto) as Monto
	from FN_PromocionesCalculaMonto ( @IdAplicacion, @IdPromocion )
	group by IdAplicacion, IdPromocion, IdCedis, IdTipoVenta, Serie, Folio
	-- order by IdAplicacion, IdPromocion, IdCedis, IdTipoVenta, Folio-- , IdProducto, Total, Porcentaje, Monto
)

GO


