USE [RouteCPC]
GO

/****** Object:  StoredProcedure [dbo].[up_PromocionesGeneraMovimientosFacturas]    Script Date: 03/30/2011 18:43:12 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[up_PromocionesGeneraMovimientosFacturas]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[up_PromocionesGeneraMovimientosFacturas]
GO

USE [RouteCPC]
GO

/****** Object:  StoredProcedure [dbo].[up_PromocionesGeneraMovimientosFacturas]    Script Date: 03/30/2011 18:43:12 ******/
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
		inner join Promociones on Promociones.IdPromocion = PromocionesAplicadasDetalle.IdPromocion
		where PromocionesAplicadasDetalle.IdAplicacion = @IdAplicacion and PromocionesAplicadasDetalle.IdPromocion = @IdPromocion 
			and IdCedis = @IdCedis and Monto > 0 and ( Aplicado = '' or ( SUBSTRING(Aplicado,1,1) = '3' and Promociones.Otras = 1 ))
	open InsertaMovs

	fetch next from InsertaMovs into @IdCedis, @IdTipoVenta, @Serie, @Folio, @Monto
	while (@@fetch_status = 0)
	begin
		
		exec up_MovimientosFacturas  @FolioMovs, @IdCedis, @IdTipoVenta, @Serie, @Folio, 0, @Fecha, 0, @IdDocumento, @IdTipoDocumento,
			@CargoAbono, '', '', @Monto, 0, 'A', @Login, 1

		update PromocionesAplicadasDetalle
			set IdMovimiento = @FolioMovs
		where IdAplicacion = @IdAplicacion and IdPromocion = @IdPromocion and IdCedis = @IdCedis and IdTipoVenta = @IdTipoVenta 
			and Serie = @Serie and Folio = @Folio and Monto > 0 

		update PromocionesAplicadasDetalle
			set Aplicado = 'A | Acuerdo Aplicado'
		where IdAplicacion = @IdAplicacion and IdPromocion = @IdPromocion and IdCedis = @IdCedis and IdTipoVenta = @IdTipoVenta 
			and Serie = @Serie and Folio = @Folio and Monto > 0 and Aplicado = '' 
		
		fetch next from InsertaMovs into @IdCedis, @IdTipoVenta, @Serie, @Folio, @Monto
	end
	close InsertaMovs
	deallocate InsertaMovs		
	
end

if @Opc = 2
begin
	if not exists(
		select Folio.Folio from Folio, FolioDetalle 
		where Folio.Folio = FolioDetalle.Folio and FolioDetalle.Status = 'A' and Folio.Folio = @FolioMovs )
	begin
		delete from Folio where Folio = @FolioMovs
		update PromocionesAplicadasDetalle set IdMovimiento = 0 where IdPromocion = @IdPromocion and IdAplicacion = @IdAplicacion 
	end
end

GO


