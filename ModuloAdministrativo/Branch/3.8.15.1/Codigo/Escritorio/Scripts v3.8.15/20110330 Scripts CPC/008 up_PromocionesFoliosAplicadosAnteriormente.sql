USE [RouteCPC]
GO

/****** Object:  StoredProcedure [dbo].[up_PromocionesFoliosAplicadosAnteriormente]    Script Date: 03/30/2011 19:09:25 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[up_PromocionesFoliosAplicadosAnteriormente]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[up_PromocionesFoliosAplicadosAnteriormente]
GO

USE [RouteCPC]
GO

/****** Object:  StoredProcedure [dbo].[up_PromocionesFoliosAplicadosAnteriormente]    Script Date: 03/30/2011 19:09:25 ******/
SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER OFF
GO

CREATE PROCEDURE [dbo].[up_PromocionesFoliosAplicadosAnteriormente] 
@IdAplicacion as bigint, 
@IdPromocion as bigint,
@Opc as int
AS

if @Opc = 1
begin

declare @IdAplicacionAnt as bigint, @IdPromocionAnt as bigint, @IdCedis as bigint, @IdTipoVenta as bigint, @Serie as varchar(6), @Folio as bigint

	declare  ActVentasMismaPromo cursor for
		select FNFoliosMismaPromocion.IdPromocion, FNFoliosMismaPromocion.IdAplicacion, 
			FNFolios.IdCedis, FNFolios.IdTipoVenta, FNFolios.Serie, FNFolios.Folio
		from FN_PromocionesFolios (@IdPromocion) as FNFolios 
		inner join FN_PromocionesFoliosAplicados(@IdPromocion, @IdAplicacion) FNFoliosMismaPromocion on 
			FNFoliosMismaPromocion.IdCedis = FNFolios.IdCedis and FNFoliosMismaPromocion.Folio = FNFolios.Folio 
			and FNFoliosMismaPromocion.IdTipoVenta = FNFolios.IdTipoVenta and FNFoliosMismaPromocion.Serie = FNFolios.Serie 
		where FNFolios.IdPromocion = @IdPromocion and FNFolios.IdAplicacion = @IdAplicacion 
	open ActVentasMismaPromo
	
	fetch next from ActVentasMismaPromo into @IdPromocionAnt, @IdAplicacionAnt, @IdCedis, @IdTipoVenta, @Serie, @Folio
	while (@@fetch_status = 0)
	begin
		
		update PromocionesAplicadasDetalle 
		set IdAplicacionAnterior = @IdAplicacionAnt, IdPromocionAnterior = @IdPromocionAnt, 
			Aplicado = '1 | El Acuerdo ' + REPLICATE('0',6-len(@IdPromocion)) + CAST(@IdPromocion as varchar(10)) + ' ya ha sido aplciado anteriormente'
		where IdAplicacion = @IdAplicacion and IdPromocion = @IdPromocion and 
			IdCedis = @IdCedis and IdTipoVenta = @IdTipoVenta and Serie = @Serie and Folio = @Folio 
		
		fetch next from ActVentasMismaPromo into @IdPromocionAnt, @IdAplicacionAnt, @IdCedis, @IdTipoVenta, @Serie, @Folio
	end
	close ActVentasMismaPromo
	deallocate ActVentasMismaPromo		

	declare  ActVentasOtrasPromo cursor for
		select distinct FNFoliosOtraPromocion.IdPromocion, FNFoliosOtraPromocion.IdAplicacion, 
			FNFolios.IdCedis, FNFolios.IdTipoVenta, FNFolios.Serie, FNFolios.Folio
		from FN_PromocionesFolios (@IdPromocion) as FNFolios 
		inner join FN_PromocionesFoliosAplicados2(@IdPromocion, @IdAplicacion) FNFoliosOtraPromocion on 
			FNFoliosOtraPromocion.IdCedis = FNFolios.IdCedis and FNFoliosOtraPromocion.Folio = FNFolios.Folio 
			and FNFoliosOtraPromocion.IdTipoVenta = FNFolios.IdTipoVenta and FNFoliosOtraPromocion.Serie = FNFolios.Serie 
		inner join PromocionesAplicadasDetalle on FNFolios.IdPromocion = @IdPromocion and FNFolios.IdAplicacion = @IdAplicacion 
			and PromocionesAplicadasDetalle.IdCedis = FNFolios.IdCedis and PromocionesAplicadasDetalle.Folio = FNFolios.Folio 
			and PromocionesAplicadasDetalle.IdTipoVenta = FNFolios.IdTipoVenta and PromocionesAplicadasDetalle.Serie = FNFolios.Serie 
		where FNFolios.IdPromocion = @IdPromocion and FNFolios.IdAplicacion = @IdAplicacion and PromocionesAplicadasDetalle.Aplicado = ''
	open ActVentasOtrasPromo
	
	fetch next from ActVentasOtrasPromo into @IdPromocionAnt, @IdAplicacionAnt, @IdCedis, @IdTipoVenta, @Serie, @Folio
	while (@@fetch_status = 0)
	begin
		
		update PromocionesAplicadasDetalle 
		set IdAplicacionAnterior = @IdAplicacionAnt, IdPromocionAnterior = @IdPromocionAnt, 
			Aplicado = '3 | Acuerdos aplicados anteriormente'
		where IdAplicacion = @IdAplicacion and IdPromocion = @IdPromocion and 
			IdCedis = @IdCedis and IdTipoVenta = @IdTipoVenta and Serie = @Serie and Folio = @Folio 
		
		fetch next from ActVentasOtrasPromo into @IdPromocionAnt, @IdAplicacionAnt, @IdCedis, @IdTipoVenta, @Serie, @Folio
	end
	close ActVentasOtrasPromo
	deallocate ActVentasOtrasPromo		
			
end

GO


