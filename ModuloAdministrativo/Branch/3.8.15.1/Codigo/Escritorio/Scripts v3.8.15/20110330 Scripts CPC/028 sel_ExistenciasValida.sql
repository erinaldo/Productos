USE [RouteCPC] 
GO

/****** Object:  StoredProcedure [dbo].[sel_ExistenciaValida]    Script Date: 04/01/2011 15:47:33 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sel_ExistenciaValida]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sel_ExistenciaValida]
GO

USE [RouteCPC] 
GO

/****** Object:  StoredProcedure [dbo].[sel_ExistenciaValida]    Script Date: 04/01/2011 15:47:33 ******/
SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER OFF
GO





CREATE PROCEDURE [dbo].[sel_ExistenciaValida] 
@IdCedis as bigint,
@IdTipoVenta as bigint,
@Serie as varchar(5),
@Folio as bigint,
@IdProducto as bigint,
@Cantidad as float,
@CantidadAnterior as float,
@Opc as bigint

AS

if @Opc = 2
begin
        select VentasDetalle.IdProducto, isnull(Cantidad, 0) as 'Cantidad', isnull(Precio, 0) as 'Precio', isnull(Subtotal, 0) as 'Subtotal', isnull(Cantidad*Precio*Iva, 0) as 'Iva', isnull(Total, 0) as 'Total',
			VentasDetalle.DctoPorc, VentasDetalle.DctoImp, VentasDetalle.Entregado
        from VentasDetalle 
        where VentasDetalle.IdCedis = @IdCedis and VentasDetalle.Serie = @Serie 
        and VentasDetalle.IdTipoVenta = @IdTipoVenta and VentasDetalle.Folio = @Folio and VentasDetalle.IdProducto = @IdProducto
end


GO


