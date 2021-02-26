USE [RouteCPC]
GO

/****** Object:  StoredProcedure [dbo].[GeneraSaldos]    Script Date: 04/03/2011 16:12:33 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GeneraSaldos]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[GeneraSaldos]
GO

USE [RouteCPC]
GO

/****** Object:  StoredProcedure [dbo].[GeneraSaldos]    Script Date: 04/03/2011 16:12:33 ******/
SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER OFF
GO




CREATE PROCEDURE [dbo].[GeneraSaldos] 
@FechaInicial as datetime,
@FechaFinal as datetime
AS

--declare @FechaInicial as datetime, @FechaFinal as datetime

declare @IdCedis as bigint, @IdTipoVenta as bigint, @Folio as bigint, 
	@Serie as varchar(5), @Fecha as datetime, @IdCliente as bigint, @Subtotal as money, @Iva as money, @DiasCredito as int,
	@ImporteNR as money, @IdMovimiento as bigint, @IdSucursal as varchar(20), @DctoImp as money, @IdSurtido as bigint,
	@Obs as varchar(500), @FolioCreado as bit, @IdDoc as varchar(10), @IdTipoDoc as varchar(10)

--if @FechaInicial < CAST('20110401' as DATEtime)
	set @FechaInicial = '20110402'
--else
--	set @FechaInicial = isnull ( (select top 1 Fecha from RouteADM.dbo.StatusDia order by Fecha desc), '01/01/1900' ) - 30

set @FechaFinal = isnull ( (select top 1 Fecha from RouteADM.dbo.StatusDia order by Fecha desc), '01/01/1900' ) 

set @IdMovimiento = 0
set @FolioCreado = 0

select top 1 @IdDoc = IdDocumentoDevolucion, @IdTipoDoc = IdTipoDocumentoDevolucion from Configuracion 

-- VENTAS
declare VentasACPC cursor for

	select VentasADM.IdCedis, VentasADM.IdTipoVenta, VentasADM.Folio, VentasADM.Serie, VentasADM.Fecha, 
		VentasADM.IdCliente, VentasADM.Subtotal, VentasADM.Iva, VentasADM.DiasCredito, VentasADM.IdSucursal, VentasADM.DctoImp, VentasADM.IdSurtido
	from RouteADM.dbo.Ventas VentasADM
	inner join RouteADM.dbo.VentasAcredita VentasAcredita on VentasAcredita.IdCedis = VentasADM.IdCedis and VentasAcredita.IdTipoVenta = VentasADM.IdTipoVenta
		and VentasAcredita.Serie = VentasADM.Serie collate SQL_Latin1_General_CP1_CI_AS and VentasAcredita.Folio = VentasADM.Folio and VentasAcredita.Status = 'A'
	left outer join Ventas on Ventas.IdCedis = VentasADM.IdCedis and Ventas.IdTipoVenta = VentasADM.IdTipoVenta
	and Ventas.Serie = VentasADM.Serie collate SQL_Latin1_General_CP1_CI_AS and Ventas.Folio = VentasADM.Folio
	where Ventas.Folio is null and VentasADM.Total > 0 and VentasAcredita.FechaAcredita between @FechaInicial and @FechaFinal 
	order by VentasADM.Fecha, VentasADM.IdCedis, VentasADM.Serie, VentasADM.Folio

	open VentasACPC
	fetch next from VentasACPC into @IdCedis, @IdTipoVenta, @Folio, @Serie, @Fecha, @IdCliente, @Subtotal, @Iva, @DiasCredito, @IdSucursal, @DctoImp, @IdSurtido
		while @@fetch_status = 0
		begin
			insert into Ventas 
			select @IdCedis, @IdTipoVenta, @Folio, @Serie, @Fecha, @IdCliente, @Subtotal, @Iva, 0, 0, @DiasCredito, @IdSucursal, 1, '', @DctoImp, '', 'Admin', getdate()

			insert into VentasDetalle
			select VentasDetalle.IdCedis, VentasDetalle.IdTipoVenta, VentasDetalle.Folio, VentasDetalle.IdProducto, VentasDetalle.Serie, VentasDetalle.Cantidad, VentasDetalle.Precio, VentasDetalle.Iva,
				VentasDetalle.DctoPorc, VentasDetalle.DctoImp, VentasDetalle.Entregado 
			from RouteADM.dbo.VentasDetalle VentasDetalle 
			where VentasDetalle.IdCedis = @IdCedis and VentasDetalle.IdTipoVenta = @IdTipoVenta
				and VentasDetalle.Folio = @Folio and VentasDetalle.Serie = @Serie

			insert into VentasAcredita 
			select IdCedis, IdTipoVenta, Folio, Serie, Fecha, FechaAcredita, Login, FechaEntrega, FolioEntrega, Observaciones, FolioCliente, Remision, Factura, Status, Vencimiento
			from RouteADM.dbo.VentasAcredita VentasAcredita 
			where VentasAcredita.IdCedis = @IdCedis and VentasAcredita.IdTipoVenta = @IdTipoVenta
				and VentasAcredita.Folio = @Folio and VentasAcredita.Serie = @Serie

			--insert into VentasImpuestos 			
			--select IdCedis, IdTipoVenta, @Serie, Folio, IdProducto, IdTipoImpuesto, Tasa 
			--from RouteADM.dbo.VentasImpuestos
			--where IdCedis = @IdCedis and IdTipoVenta = @IdTipoVenta and IdSurtido = @IdSurtido and Folio = @Folio 
						
			select @ImporteNR = isnull( SUM((Cantidad - Entregado) * Precio) + isnull(SUM((Cantidad - Entregado) * Precio * Iva),0), 0)
			from RouteADM.dbo.VentasDetalle 
			where VentasDetalle.IdCedis = @IdCedis and VentasDetalle.IdTipoVenta = @IdTipoVenta
				and VentasDetalle.Folio = @Folio and VentasDetalle.Serie = @Serie
				and Cantidad <> Entregado 
			
			if @ImporteNR is not null and @ImporteNR > 0
			begin
				if exists(	select distinct FOL.Folio 
						from MovimientosFacturas MOVF
						inner join Movimientos MOV on MOV.IdCedis = MOVF.IdCedis and MOV.IdMovimiento = MOVF.IdMovimiento and MOV.Status <> 'B'
						inner join FolioDetalle FOLD on MOV.IdCedis = FOLD.IdCedis and MOV.IdMovimiento = FOLD.IdMovimiento and FOLD.Status <> 'B'
						inner join Folio FOL on FOLD.Folio = FOL.Folio and FOL.Status <> 'B' and FOL.Fecha = @Fecha 
						where MOVF.IdDocumento = @IdDoc and MOVF.IdTipoDocumento = @IdTipoDoc and MOVF.Status <> 'B') 
				begin
					select distinct @IdMovimiento = FOL.Folio 
					from MovimientosFacturas MOVF
					inner join Movimientos MOV on MOV.IdCedis = MOVF.IdCedis and MOV.IdMovimiento = MOVF.IdMovimiento and MOV.Status <> 'B'
					inner join FolioDetalle FOLD on MOV.IdCedis = FOLD.IdCedis and MOV.IdMovimiento = FOLD.IdMovimiento and FOLD.Status <> 'B'
					inner join Folio FOL on FOLD.Folio = FOL.Folio and FOL.Status <> 'B' and FOL.Fecha = @Fecha 
					where MOVF.IdDocumento = @IdDoc and MOVF.IdTipoDocumento = @IdTipoDoc and MOVF.Status <> 'B'			
				end
				else
				begin				
					if @FolioCreado = 1
					begin
						exec up_Folio @IdMovimiento, '19000101', 0, '', '', 'SUPER', 5
					end

					select @IdMovimiento = isnull(MAX(Folio) + 1,1) from Folio 
					set @Obs = 'Notas de Crédito Diferencias Entr vs Fact ' + cast(@Fecha as varchar(20))
					exec up_Folio @IdMovimiento, @Fecha, 0, @Obs, '', 'SUPER', 1
					set @FolioCreado = 1
				end
				execute up_MovimientosFacturas @IdMovimiento, @IdCedis, @IdTipoVenta, @Serie, @Folio, @IdMovimiento, @Fecha, 0, @IdDoc, @IdTipoDoc, 'A', '', '', @ImporteNR, 0, 'A', 'SUPER', 1 
			end
			
			fetch next from VentasACPC into @IdCedis, @IdTipoVenta, @Folio, @Serie, @Fecha, @IdCliente, @Subtotal, @Iva, @DiasCredito, @IdSucursal, @DctoImp, @IdSurtido
		end
	close VentasACPC

	if @FolioCreado = 1
		exec up_Folio @IdMovimiento, '19000101', 0, '', '', 'SUPER', 5

deallocate VentasACPC

GO


