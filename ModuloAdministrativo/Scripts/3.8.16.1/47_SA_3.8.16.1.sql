USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[up_PreciosVentas]    Script Date: 08/02/2011 11:50:23 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[up_PreciosVentas]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[up_PreciosVentas]
GO

USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[up_PreciosVentas]    Script Date: 08/02/2011 11:50:23 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO








CREATE PROCEDURE [dbo].[up_PreciosVentas]
@IdCedis as bigint,
@IdSurtido as bigint,
@IdLista as int
AS
BEGIN
declare
@IdProducto as bigint,
@Precio as float,
@IdTipoVenta as int,
@Serie as varchar(5),
@Folio as bigint,
@Subtotal as float,
@Iva as money,
@IdSucursal as varchar(16),
@Fecha as datetime,
@Lista as varchar(200),
@Cantidad as decimal(19,4),
@DctoPor as money,
@DctoImp as money,
@Entregado as decimal(19,4),
@IdCliente as bigint,
@DiasCredito as int,
@Subtotal2 as float,
@DescImp as float,
@Impuestos as float


	declare ActualizaTotales cursor for
	select V.IdCedis,V.IdSurtido,V.IdTipoVenta,V.Folio,V.Serie,V.Fecha,
	V.IdCliente/*,V.Subtotal*/,V.Iva,V.IdSucursal,V.DctoImp,V.DiasCredito from Ventas V
	left outer join VentasTipo on V.IdTipoVenta = VentasTipo.IdTipoVenta
	left outer join Clientes on V.IdCliente = Clientes.IdCliente and Clientes.IdCedis = V.IdCedis
	left outer join ClienteSucursal on V.IdCliente = ClienteSucursal.IdCliente and ClienteSucursal.IdCedis = V.IdCedis and ClienteSucursal.IdSucursal = V.IdSucursal
	left outer join PreciosListaCliente on PreciosListaCliente.IdCliente = Clientes.IdCliente and Clientes.IdCedis = PreciosListaCliente.IdCedis
	left outer join PreciosLista on PreciosLista.IdLista = PreciosListaCliente.IdLista
	left outer join VentasDevolucion on VentasDevolucion.IdCedisD = V.IdCedis and VentasDevolucion.IdSurtidoD = VentasDevolucion.IdSurtido 
		and VentasDevolucion.IdTipoVentaD = V.IdTipoVenta and VentasDevolucion.FolioD = V.Folio 
	where V.IdCedis = @IdCedis and V.IdSurtido = @IdSurtido

	open ActualizaTotales
	fetch next from ActualizaTotales into @IdCedis,@IdSurtido,@IdTipoVenta,@Folio,@Serie,@Fecha,@IdCliente/*,@Subtotal*/,@Iva,@IdSucursal,@DctoImp,@DiasCredito
	while(@@fetch_status=0)
	begin
		set @Subtotal2 = 0
		set @DescImp = 0
		set @Impuestos = 0
		declare ActualizaProductos cursor for
		select VD.IdCedis,VD.IdSurtido,VD.IdTipoVenta,VD.Folio,VD.IdProducto,VD.Serie,
		VD.Cantidad,VD.Precio,VD.Iva,VD.DctoPorc,VD.DctoImp,VD.Entregado, VD.Subtotal
		from VentasDetalle VD
		inner join Productos on VD.IdProducto = Productos.IdProducto
		where VD.IdCedis = @IdCedis and VD.IdSurtido = @IdSurtido
		and VD.IdTipoVenta = @IdTipoVenta and VD.Folio = @Folio 
		order by VD.IdProducto
		
		open ActualizaProductos
		fetch next from ActualizaProductos into @IdCedis,@IdSurtido,@IdTipoVenta,@Folio,@IdProducto,@Serie,@Cantidad,@Precio,@Iva,@DctoPor,@DctoImp,@Entregado,@Subtotal
		while(@@FETCH_STATUS=0)
		begin
			SELECT @Precio = Precio FROM PreciosDetalle 
			WHERE IdLista = @IdLista AND IdProducto = @IdProducto
			
			select @Subtotal = ((@Precio*VD.Cantidad)-VD.DctoImp) 
			from VentasDetalle VD
			inner join Productos on VD.IdProducto = Productos.IdProducto
			where VD.IdCedis = @IdCedis and VD.IdSurtido = @IdSurtido
			and VD.IdTipoVenta = @IdTipoVenta and VD.Folio = @Folio and Productos.IdProducto = @IdProducto
			
			-- COPIAR DATOS A TABLA DESC
			insert into VentasDetalleDesc
				select VD.IdCedis,VD.IdSurtido,VD.IdTipoVenta,VD.Folio,VD.IdProducto,VD.Serie,
				VD.Cantidad,VD.Precio,VD.Iva,VD.DctoPorc,VD.DctoImp,VD.Entregado
				from VentasDetalle VD
				inner join Productos on VD.IdProducto = Productos.IdProducto
				where VD.IdCedis = @IdCedis and VD.IdSurtido = @IdSurtido
				and VD.IdTipoVenta = @IdTipoVenta and VD.Folio = @Folio and Productos.IdProducto = @IdProducto
				order by VD.IdProducto
			
			-- ACTUALIZA EL PRECIO EN ADM
			update VentasDetalle set VentasDetalle.Precio = @Precio, VentasDetalle.DctoImp = (Cantidad*@Precio)*(DctoPorc/100)
			from VentasDetalle inner join Productos on VentasDetalle.IdProducto = Productos.IdProducto
			where VentasDetalle.IdCedis = @IdCedis and VentasDetalle.IdSurtido = @IdSurtido
			and VentasDetalle.IdTipoVenta = @IdTipoVenta and VentasDetalle.Folio = @Folio and Productos.IdProducto = @IdProducto
			
			-- ACTUALIZA EL PRECIO EN ROUTE
			update  Route.dbo.TransProdDetalle set Precio = @Precio, DescuentoImp = (@Precio*Cantidad)*(DescuentoPor/100)
			from Route.dbo.TransProdDetalle TPD
			inner join VentasTransProd VTP on VTP.TransProdId = TPD.TransProdID 
			where Promocion != 2 and IdSurtido = @IdSurtido and Folio = @Folio and ProductoClave = @IdProducto
			
			update  Route.dbo.TransProdDetalle set Subtotal = (@Precio*Cantidad)-DescuentoImp
			from Route.dbo.TransProdDetalle TPD
			inner join VentasTransProd VTP on VTP.TransProdId = TPD.TransProdID 
			where Promocion != 2 and IdSurtido = @IdSurtido and Folio = @Folio and ProductoClave = @IdProducto
			
			update  Route.dbo.TransProdDetalle set Impuesto = Subtotal*@Iva
			from Route.dbo.TransProdDetalle TPD
			inner join VentasTransProd VTP on VTP.TransProdId = TPD.TransProdID 
			where Promocion != 2 and IdSurtido = @IdSurtido and Folio = @Folio and ProductoClave = @IdProducto
			
			update  Route.dbo.TransProdDetalle set Total = Subtotal+Impuesto
			from Route.dbo.TransProdDetalle TPD
			inner join VentasTransProd VTP on VTP.TransProdId = TPD.TransProdID 
			where Promocion != 2 and IdSurtido = @IdSurtido and Folio = @Folio and ProductoClave = @IdProducto
			
			select @Subtotal2 = @Subtotal + @Subtotal2
			
			select @DescImp = DescuentoImp + @DescImp, @Impuestos = Impuesto + @Impuestos from Route.dbo.TransProdDetalle TPD
			inner join VentasTransProd VTP on VTP.TransProdId = TPD.TransProdID 
			where Promocion != 2 and IdSurtido = @IdSurtido and Folio = @Folio and ProductoClave = @IdProducto
			
		fetch next from ActualizaProductos into @IdCedis,@IdSurtido,@IdTipoVenta,@Folio,@IdProducto,@Serie,@Cantidad,@Precio,@Iva,@DctoPor,@DctoImp,@Entregado,@Subtotal
		end
		close ActualizaProductos
		deallocate ActualizaProductos
		
		-- COPIAR DATOS A TABLA DESC
		insert into VentasDesc
			select V.IdCedis,V.IdSurtido,V.IdTipoVenta,V.Folio,V.Serie,V.Fecha,
			V.IdCliente,V.Subtotal,V.Iva,V.IdSucursal,V.DctoImp,V.DiasCredito from Ventas V
			left outer join VentasTipo on V.IdTipoVenta = VentasTipo.IdTipoVenta
			left outer join Clientes on V.IdCliente = Clientes.IdCliente and Clientes.IdCedis = V.IdCedis
			left outer join ClienteSucursal on V.IdCliente = ClienteSucursal.IdCliente and ClienteSucursal.IdCedis = V.IdCedis and ClienteSucursal.IdSucursal = V.IdSucursal
			left outer join PreciosListaCliente on PreciosListaCliente.IdCliente = Clientes.IdCliente and Clientes.IdCedis = PreciosListaCliente.IdCedis
			left outer join PreciosLista on PreciosLista.IdLista = PreciosListaCliente.IdLista
			left outer join VentasDevolucion on VentasDevolucion.IdCedisD = V.IdCedis and VentasDevolucion.IdSurtidoD = VentasDevolucion.IdSurtido 
				and VentasDevolucion.IdTipoVentaD = V.IdTipoVenta and VentasDevolucion.FolioD = V.Folio 
			where V.IdCedis = @IdCedis and V.IdSurtido = @IdSurtido and V.Folio = @Folio
		
		-- ACTUALIZA ENCABEZADO EN ADM
		update Ventas set Ventas.Subtotal = ROUND(@Subtotal2,2), IdListaPrecioDesc = @IdLista, Iva = @Impuestos
		from Ventas
		left outer join VentasTipo on Ventas.IdTipoVenta = VentasTipo.IdTipoVenta
		left outer join Clientes on Ventas.IdCliente = Clientes.IdCliente and Clientes.IdCedis = Ventas.IdCedis
		left outer join ClienteSucursal on Ventas.IdCliente = ClienteSucursal.IdCliente and ClienteSucursal.IdCedis = Ventas.IdCedis and ClienteSucursal.IdSucursal = Ventas.IdSucursal
		left outer join PreciosListaCliente on PreciosListaCliente.IdCliente = Clientes.IdCliente and Clientes.IdCedis = PreciosListaCliente.IdCedis
		left outer join PreciosLista on PreciosLista.IdLista = PreciosListaCliente.IdLista
		left outer join VentasDevolucion on VentasDevolucion.IdCedisD = Ventas.IdCedis and VentasDevolucion.IdSurtidoD = VentasDevolucion.IdSurtido 
			and VentasDevolucion.IdTipoVentaD = Ventas.IdTipoVenta and VentasDevolucion.FolioD = Ventas.Folio 
		where Ventas.IdCedis = @IdCedis and Ventas.IdSurtido = @IdSurtido and @Folio = Ventas.Folio
		
		-- ACTUALIZA EL ENCABEZADO EN ROUTE
		update Route.dbo.TransProd set SubTDetalle = ROUND(@Subtotal2,2), DescuentoImp = @DescImp, Subtotal = ROUND(@Subtotal2,0)-@DescImp, Impuesto = @Impuestos
		from Route.dbo.TransProd TP
		inner join VentasTransProd VTP on VTP.TransProdId = TP.TransProdID
		where Promocion != 2 and IdSurtido = @IdSurtido and VTP.Folio = @Folio
		
		update Route.dbo.TransProd set Total = Subtotal + Impuesto
		from Route.dbo.TransProd TP
		inner join VentasTransProd VTP on VTP.TransProdId = TP.TransProdID
		where Promocion != 2 and IdSurtido = @IdSurtido and VTP.Folio = @Folio
		
	fetch next from ActualizaTotales into @IdCedis,@IdSurtido,@IdTipoVenta,@Folio,@Serie,@Fecha,@IdCliente/*,@Subtotal*/,@Iva,@IdSucursal,@DctoImp,@DiasCredito
	end
	close ActualizaTotales
	deallocate ActualizaTotales
END







GO



USE [Route]
GO

if (Select COUNT(*) from VersionBD where Tipo = 'SA' and Version ='3.8.16.1') = 0
BEGIN
	INSERT INTO VersionBD (Tipo, FechaHora, Version, MaximoConsecutivo, VersionSql ) 
	VALUES('SA', GETDATE(), '3.8.16.1', 47, (SELECT  cast(SERVERPROPERTY('productversion') as varchar(50))))
END
ELSE
BEGIN 
	Update VersionBD  set MaximoConsecutivo = 47 where  Tipo = 'SA' and Version ='3.8.16.1'
END
GO