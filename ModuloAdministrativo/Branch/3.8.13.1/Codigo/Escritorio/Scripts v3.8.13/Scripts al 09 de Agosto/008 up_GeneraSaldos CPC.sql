USE [RouteCPC]
GO

/****** Object:  StoredProcedure [dbo].[GeneraSaldos]    Script Date: 07/29/2010 17:52:42 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GeneraSaldos]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[GeneraSaldos]
GO

USE [RouteCPC]
GO

/****** Object:  StoredProcedure [dbo].[GeneraSaldos]    Script Date: 07/29/2010 17:52:42 ******/
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
	@Serie as varchar(5), @Fecha as datetime, @IdCliente as bigint, @Subtotal as money, @Iva as money,
	@IdSucursal as varchar(50), @IdMarca as bigint

--set @FechaInicial = isnull ( (select top 1 Fecha from RouteADM.dbo.StatusDia order by Fecha desc), '01/01/1900' ) - 30
--set @FechaFinal = isnull ( (select top 1 Fecha from RouteADM.dbo.StatusDia order by Fecha desc), '01/01/1900' ) 

Delete from VentasNoTransferidas where Fecha between @FechaInicial and @FechaFinal 

-- VENTAS
declare VentasACPC cursor for

	select VentasADM.IdCedis, VentasADM.IdTipoVenta, VentasADM.Folio, VentasADM.Serie, VentasADM.Fecha, VentasADM.IdCliente, 
	VentasADM.Subtotal, VentasADM.Iva, VentasADM.IdSucursal 
	from RouteADM.dbo.Ventas VentasADM
	left outer join Ventas on Ventas.IdCedis = VentasADM.IdCedis and Ventas.IdTipoVenta = VentasADM.IdTipoVenta
	and Ventas.Serie = VentasADM.Serie collate SQL_Latin1_General_CP1_CI_AS and Ventas.Folio = VentasADM.Folio
	where VentasADM.Fecha between @FechaInicial and @FechaFinal and Ventas.Folio is null 
	and VentasADM.IdTipoVenta = 2 -- and VentasADM.Serie not like 'R%'
	order by VentasADM.IdCedis, VentasADM.Serie, VentasADM.Folio

	open VentasACPC
	fetch next from VentasACPC into @IdCedis, @IdTipoVenta, @Folio, @Serie, @Fecha, @IdCliente, @Subtotal, @Iva, @IdSucursal
		while @@fetch_status = 0
		begin
			insert into Ventas 
			select @IdCedis, @IdTipoVenta, @Folio, @Serie, @Fecha, @IdCliente, @Subtotal, @Iva, 0, 0, 30, @IdSucursal, 0, '', '', 'Admin', getdate()

			insert into VentasDetalle
			select VentasDetalle.IdCedis, VentasDetalle.IdTipoVenta, VentasDetalle.Folio, VentasDetalle.IdProducto, VentasDetalle.Serie, VentasDetalle.Cantidad, VentasDetalle.Precio, VentasDetalle.Iva
			from RouteADM.dbo.VentasDetalle VentasDetalle where VentasDetalle.IdCedis = @IdCedis and VentasDetalle.IdTipoVenta = @IdTipoVenta
				and VentasDetalle.Folio = @Folio and VentasDetalle.Serie = @Serie
				
			select top 1 @IdMarca = IdMarca 
			from RouteADM.dbo.VentasDetalle VentasDetalle 
			inner join Productos on Productos.IdProducto = VentasDetalle.IdProducto 
			where VentasDetalle.IdCedis = @IdCedis and VentasDetalle.IdTipoVenta = @IdTipoVenta
				and VentasDetalle.Folio = @Folio and VentasDetalle.Serie = @Serie
				
			update Ventas set IdMarca = @IdMarca
			where Ventas.IdCedis = @IdCedis and Ventas.IdTipoVenta = @IdTipoVenta
				and Ventas.Folio = @Folio and Ventas.Serie = @Serie
			
			fetch next from VentasACPC into @IdCedis, @IdTipoVenta, @Folio, @Serie, @Fecha, @IdCliente, @Subtotal, @Iva, @IdSucursal
		end
	close VentasACPC

deallocate VentasACPC
/*
declare VentasACPC cursor for

	select  VentasContadoADM.*
	from FN_VentasADMContado (@FechaInicial, @FechaFinal) VentasContadoADM
	left outer join Ventas on Ventas.IdCedis = VentasContadoADM.IdCedis and Ventas.IdTipoVenta = VentasContadoADM.IdTipoVenta and Ventas.Fecha = VentasContadoADM.Fecha
	where Ventas.Folio is null

	open VentasACPC
	fetch next from VentasACPC into @IdCedis, @IdTipoVenta, @Folio, @Serie, @Fecha, @IdCliente, @Subtotal, @Iva
		while @@fetch_status = 0
		begin
			insert into Ventas 
			select @IdCedis, @IdTipoVenta, @Folio, @Serie, @Fecha, @IdCliente, @Subtotal, @Iva, 0, 0, 0, '', 'Admin', getdate()

			insert into VentasDetalle
			select * from FN_VentasADMContadoDetalle (@IdCedis, @Serie, @Folio, @FechaInicial, @FechaFinal)

			fetch next from VentasACPC into @IdCedis, @IdTipoVenta, @Folio, @Serie, @Fecha, @IdCliente, @Subtotal, @Iva
		end
	close VentasACPC

deallocate VentasACPC
*/
-- FOLIOS REPETIDOS
declare VentasACPC cursor for

	select VentasADM.IdCedis, VentasADM.IdTipoVenta, VentasADM.Folio, VentasADM.Serie, VentasADM.Fecha, 
	VentasADM.IdCliente, VentasADM.Subtotal, VentasADM.Iva
	from RouteADM.dbo.Ventas VentasADM
	inner join Ventas on Ventas.IdCedis = VentasADM.IdCedis and Ventas.IdTipoVenta = VentasADM.IdTipoVenta
		and Ventas.Serie = VentasADM.Serie collate SQL_Latin1_General_CP1_CI_AS and Ventas.Folio = VentasADM.Folio
	where VentasADM.Fecha between @FechaInicial and @FechaFinal and Ventas.Fecha <> VentasADM.Fecha
	and VentasADM.IdTipoVenta = 2 -- and VentasADM.Serie not like 'R%'
	order by VentasADM.IdCedis, VentasADM.Serie, VentasADM.Folio

	open VentasACPC
	fetch next from VentasACPC into @IdCedis, @IdTipoVenta, @Folio, @Serie, @Fecha, @IdCliente, @Subtotal, @Iva
		while @@fetch_status = 0
		begin
			insert into VentasNoTransferidas 
			select @IdCedis, @IdTipoVenta, @Folio, @Serie, @Fecha, @IdCliente, @Subtotal, @Iva, 0, 0, 0, '', 'Admin', getdate()
			fetch next from VentasACPC into @IdCedis, @IdTipoVenta, @Folio, @Serie, @Fecha, @IdCliente, @Subtotal, @Iva
		end
	close VentasACPC

deallocate VentasACPC
/*
declare VentasACPC cursor for

	select  VentasContadoADM.*
	from FN_VentasADMContado (@FechaInicial, @FechaFinal) VentasContadoADM
	inner join Ventas on Ventas.IdCedis = VentasContadoADM.IdCedis and Ventas.IdTipoVenta = VentasContadoADM.IdTipoVenta 
		and Ventas.Folio = VentasContadoADM.Folio
	where Ventas.Fecha <> VentasContadoADM.Fecha

	open VentasACPC
	fetch next from VentasACPC into @IdCedis, @IdTipoVenta, @Folio, @Serie, @Fecha, @IdCliente, @Subtotal, @Iva
		while @@fetch_status = 0
		begin
			insert into VentasNoTransferidas 
			select @IdCedis, @IdTipoVenta, @Folio, @Serie, @Fecha, @IdCliente, @Subtotal, @Iva, 0, 0, 0, '', 'Admin', getdate()
			fetch next from VentasACPC into @IdCedis, @IdTipoVenta, @Folio, @Serie, @Fecha, @IdCliente, @Subtotal, @Iva
		end
	close VentasACPC

deallocate VentasACPC
*/

GO

