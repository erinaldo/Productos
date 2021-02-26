USE [RouteCPC]
GO

/****** Object:  StoredProcedure [dbo].[up_PromocionesGeneraMovimientosFacturas]    Script Date: 03/28/2011 00:04:43 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[up_PromocionesGeneraMovimientosFacturas]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[up_PromocionesGeneraMovimientosFacturas]
GO

USE [RouteCPC]
GO

/****** Object:  StoredProcedure [dbo].[up_PromocionesGeneraMovimientosFacturas]    Script Date: 03/28/2011 00:04:43 ******/
SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER OFF
GO



CREATE PROCEDURE [dbo].[up_PromocionesGeneraMovimientosFacturas] 
@IdAplicacion as bigint,
@IdPromocion as bigint,
@IdCedis as bigint,
@Fecha as datetime,
@FolioMovs as bigint,
@IdDocumento as varchar(5),
@IdTipoDocumento as varchar(5),
@CargoAbono as varchar(10),
@Login as varchar(100),
@Opc as int
AS

if @Opc = 1
begin

declare 
@IdTipoVenta as int,
@Serie as varchar(5),
@Folio as bigint,
@Monto as money

	declare  InsertaMovs cursor for
		select IdCedis, IdTipoVenta, Serie, Folio, Monto 
		from PromocionesAplicadasDetalle
		where IdAplicacion = @IdAplicacion and IdPromocion = @IdPromocion and IdCedis = @IdCedis and Monto > 0 and Aplicado = '' and IdAplicacionAnterior = 0
	open InsertaMovs

	fetch next from InsertaMovs into @IdCedis, @IdTipoVenta, @Serie, @Folio, @Monto
	while (@@fetch_status = 0)
	begin
		
		exec up_MovimientosFacturas  @FolioMovs, @IdCedis, @IdTipoVenta, @Serie, @Folio, 0, @Fecha, 0, @IdDocumento, @IdTipoDocumento,
			@CargoAbono, '', '', @Monto, 0, 'A', @Login, 1
		
		fetch next from InsertaMovs into @IdCedis, @IdTipoVenta, @Serie, @Folio, @Monto
	end
	close InsertaMovs
	deallocate InsertaMovs		
	
	update PromocionesAplicadasDetalle set Aplicado = 'A', IdMovimiento = @FolioMovs where IdAplicacion = @IdAplicacion and IdPromocion = @IdPromocion and IdCedis = @IdCedis and Monto > 0
end


GO


