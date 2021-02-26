USE [RouteCPC]
GO

/****** Object:  StoredProcedure [dbo].[GeneraSaldos]    Script Date: 02/28/2011 10:35:40 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GeneraSaldos]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[GeneraSaldos]
GO

USE [RouteCPC]
GO

/****** Object:  StoredProcedure [dbo].[GeneraSaldos]    Script Date: 02/28/2011 10:35:40 ******/
SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER OFF
GO

CREATE PROCEDURE [dbo].[GeneraSaldos] 
@FechaInicial as datetime,
@FechaFinal as datetime
AS

-- declare @FechaInicial as datetime, @FechaFinal as datetime

declare @IdCedis as bigint, @IdTipoVenta as bigint, @Folio as bigint, 
	@Serie as varchar(5), @Fecha as datetime, @IdCliente as bigint, @Subtotal as money, @Iva as money, @DiasCredito as int,
	@ImporteNR as money, @IdMovimiento as bigint, @IdSucursal as varchar(20), @DctoImp as money, @IdSurtido as bigint

-- set @FechaInicial = isnull ( (select top 1 Fecha from RouteADM.dbo.StatusDia order by Fecha desc), '01/01/1900' ) - 30
-- set @FechaFinal = isnull ( (select top 1 Fecha from RouteADM.dbo.StatusDia order by Fecha desc), '01/01/1900' ) 

Delete from VentasNoTransferidas where Fecha between @FechaInicial and @FechaFinal 

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
	order by VentasADM.IdCedis, VentasADM.Serie, VentasADM.Folio

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
			select IdCedis, IdTipoVenta, Folio, Serie, Fecha, FechaAcredita, Login, FechaEntrega, FolioEntrega, Observaciones, FolioCliente, Remision, Factura, Status, Vencimiento, StatusTransferido 
			from RouteADM.dbo.VentasAcredita VentasAcredita 
			where VentasAcredita.IdCedis = @IdCedis and VentasAcredita.IdTipoVenta = @IdTipoVenta
				and VentasAcredita.Folio = @Folio and VentasAcredita.Serie = @Serie

			--insert into VentasImpuestos 			
			--select IdCedis, IdTipoVenta, @Serie, Folio, IdProducto, IdTipoImpuesto, Tasa 
			--from RouteADM.dbo.VentasImpuestos
			--where IdCedis = @IdCedis and IdTipoVenta = @IdTipoVenta and IdSurtido = @IdSurtido and Folio = @Folio 
						
			--select @IdMovimiento = isnull(MAX(IdMovimiento) + 1,1) 
			--from Movimientos 

			--select @ImporteNR = SUM((Cantidad - Entregado) * Precio) + SUM((Cantidad - Entregado) * Precio * Iva) 
			--from RouteADM.dbo.VentasDetalle 
			--where VentasDetalle.IdCedis = @IdCedis and VentasDetalle.IdTipoVenta = @IdTipoVenta
			--	and VentasDetalle.Folio = @Folio and VentasDetalle.Serie = @Serie
			--	and Cantidad <> Entregado 
			
			--insert into Movimientos values (@IdCedis, @IdMovimiento, @Fecha, 'ASI', 'A', @ImporteNR, '', '', 'Diferencia de Facturado vs Entregado', 'A', 'Interfaz', GETDATE())
			--insert into MovimientosFacturas values (@IdCedis, @IdTipoVenta, @Serie, @Folio, @IdMovimiento, @Fecha, 1, 'ASI', 'F', 'A', '', '', @ImporteNR, 0, 'A', 'Interfaz', GETDATE())
			
			fetch next from VentasACPC into @IdCedis, @IdTipoVenta, @Folio, @Serie, @Fecha, @IdCliente, @Subtotal, @Iva, @DiasCredito, @IdSucursal, @DctoImp
		end
	close VentasACPC

deallocate VentasACPC

-- FOLIOS REPETIDOS
--declare VentasACPC cursor for

--	select VentasADM.IdCedis, VentasADM.IdTipoVenta, VentasADM.Folio, VentasADM.Serie, VentasADM.Fecha, 
--		VentasADM.IdCliente, VentasADM.Subtotal, VentasADM.Iva, VentasADM.DiasCredito, VentasADM.IdSucursal, VentasADM.DctoImp
--	from RouteADM.dbo.Ventas VentasADM
--	inner join RouteADM.dbo.VentasAcredita VentasAcredita on VentasAcredita.IdCedis = VentasADM.IdCedis and VentasAcredita.IdTipoVenta = VentasADM.IdTipoVenta
--		and VentasAcredita.Serie = VentasADM.Serie collate SQL_Latin1_General_CP1_CI_AS and VentasAcredita.Folio = VentasADM.Folio and VentasAcredita.Status = 'A'
--	left outer join Ventas on Ventas.IdCedis = VentasADM.IdCedis and Ventas.IdTipoVenta = VentasADM.IdTipoVenta
--	and Ventas.Serie = VentasADM.Serie collate SQL_Latin1_General_CP1_CI_AS and Ventas.Folio = VentasADM.Folio
--	where Ventas.Folio is not null and VentasADM.Total > 0 and VentasAcredita.FechaAcredita = @FechaInicial -- and @FechaFinal and 
--	order by VentasADM.IdCedis, VentasADM.Serie, VentasADM.Folio

--	open VentasACPC
--	fetch next from VentasACPC into @IdCedis, @IdTipoVenta, @Folio, @Serie, @Fecha, @IdCliente, @Subtotal, @Iva, @DiasCredito
--		while @@fetch_status = 0
--		begin
--			insert into VentasNoTransferidas 
--			select @IdCedis, @IdTipoVenta, @Folio, @Serie, @Fecha, @IdCliente, @Subtotal, @Iva, 0, 0, 0, '', 'Admin', getdate()
--			fetch next from VentasACPC into @IdCedis, @IdTipoVenta, @Folio, @Serie, @Fecha, @IdCliente, @Subtotal, @Iva, @DiasCredito
--		end
--	close VentasACPC

--deallocate VentasACPC

GO


