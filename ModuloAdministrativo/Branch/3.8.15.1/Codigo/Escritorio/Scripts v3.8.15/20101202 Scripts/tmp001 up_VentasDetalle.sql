USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[up_VentasDetalle]    Script Date: 11/27/2010 14:17:15 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[up_VentasDetalle]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[up_VentasDetalle]
GO

USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[up_VentasDetalle]    Script Date: 11/27/2010 14:17:15 ******/
SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[up_VentasDetalle]
@IdCedis as bigint,
@IdSurtido as bigint,
@IdTipoVenta as int,
@Folio as bigint,
@Serie as varchar(5),
@Fecha as datetime,
@IdProducto as bigint,
@Cantidad as float,
@Precio as money,
@Iva as float,
@TVenta as int,
@DctoPorc as money,
@DctoImp as money,
@Entregado as float,
@Opc as int

AS

declare @CantidadAnterior as float, @IdRuta as bigint
declare @IdCliente as bigint, @IdSucursal as varchar(20)
declare @IdSurtidoD as bigint, @IdTipoVentaD as bigint, @FolioD as bigint, @SerieD as varchar(6)


if @Opc = 1 -- Actualiza Partida de Factura
begin
	set @CantidadAnterior = isnull( (select Cantidad from VentasDetalle where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdTipoVenta = @IdTipoVenta and Folio = @Folio and IdProducto = @IdProducto), 0)
	set @TVenta = (select Tipo from VentasTipo where IdTipoVenta = @IdTipoVenta )
	set @IdRuta = isnull( (select IdRuta from Surtidos where IdCedis = @IdCedis and IdSurtido = @IdSurtido), 0)
	
	if @Iva = 0 
	begin
		select @IdCliente = IdCliente, @IdSucursal = IdSucursal
		from Ventas
		where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdTipoVenta = @IdTipoVenta and Folio = @Folio		
		set @Iva = ISNULL( (select Valor from ClientesImpuestos where IdCedis = @IdCedis and IdCliente = @IdCliente and IdSucursal = @IdSucursal and IdProducto = @IdProducto), 0)
	end
	
	delete from VentasDetalle where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdTipoVenta = @IdTipoVenta and Folio = @Folio and IdProducto = @IdProducto
	
	if @IdTipoVenta = 3 set @Cantidad = @Cantidad * -1

	if @Cantidad <> 0 
		insert into VentasDetalle values (@IdCedis, @IdSurtido, @IdTipoVenta, @Folio, @IdProducto, @Serie, @Cantidad, @Precio, @Iva, @DctoPorc, @Cantidad * @Precio * @DctoPorc, @Entregado)

	if not exists(select IdProducto from SurtidosDetalle where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdProducto = @IdProducto)
		insert into SurtidosDetalle values (@IdCedis, @IdSurtido, @IdProducto, @Fecha, 0,0,0, 0,0,0, @Precio, @Iva )

	exec up_SurtidosCargas @IdCedis, @IdSurtido, 99, 0, '19000101', 0, 3

	if @TVenta = 2 
	begin
		update SurtidosDetalle set VentaContado = VentaContado + @Cantidad - @CantidadAnterior 
		where SurtidosDetalle.Fecha = @Fecha and SurtidosDetalle.IdCedis = @IdCedis and SurtidosDetalle.IdSurtido = @IdSurtido and SurtidosDetalle.IdProducto = @IdProducto
		update InventarioKardex set VentaContado = VentaContado + @Cantidad - @CantidadAnterior 
		where InventarioKardex.Fecha = @Fecha and InventarioKardex.IdCedis = @IdCedis and InventarioKardex.IdProducto = @IdProducto
	end
	else
	begin
		update SurtidosDetalle set VentaCredito = VentaCredito + @Cantidad - @CantidadAnterior 
		where SurtidosDetalle.Fecha = @Fecha and SurtidosDetalle.IdCedis = @IdCedis and SurtidosDetalle.IdSurtido = @IdSurtido and SurtidosDetalle.IdProducto = @IdProducto
		update InventarioKardex set VentaCredito = VentaCredito + @Cantidad - @CantidadAnterior 
		where InventarioKardex.Fecha = @Fecha and InventarioKardex.IdCedis = @IdCedis and InventarioKardex.IdProducto = @IdProducto
	end

	update Ventas set Subtotal = isnull((select sum((Cantidad * Precio)- DctoImp) from VentasDetalle where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdTipoVenta = @IdTipoVenta and Folio = @Folio ), 0), 
	Iva = isnull( (select sum(((Cantidad * Precio) - DctoImp) * Iva) from VentasDetalle where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdTipoVenta = @IdTipoVenta and Folio = @Folio ), 0),
	Ventas.DctoImp = isnull( (select sum(VentasDetalle.DctoImp) from VentasDetalle where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdTipoVenta = @IdTipoVenta and Folio = @Folio ), 0)
	where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdTipoVenta = @IdTipoVenta and Folio = @Folio 

	if exists( select IdCedis from StatusLiquidacion where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdRuta = @IdRuta and Fecha = @Fecha and Status = 'HH' )
	begin
		delete from StatusLiquidacion where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdRuta = @IdRuta and Fecha = @Fecha and Status = 'VEN'
		insert into StatusLiquidacion values ( @IdCedis, @IdSurtido, @IdRuta, @Fecha, 'VEN', 'Actualización de Ventas', getdate() )
	end
	
	if exists(select IdSurtido from VentasDetalle where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdTipoVenta = @IdTipoVenta and Folio = @Folio and Cantidad <> Entregado and IdTipoVenta = 2)
	begin
		if not exists(select IdSurtido from VentasDevolucion where IdCedisD = @IdCedis and IdSurtido = @IdSurtido and IdTipoVenta = @IdTipoVenta and Folio = @Folio and IdSurtidoD = @IdSurtido )
		begin
			execute up_VentasDevoluciones @IdCedis, @IdSurtido, @IdTipoVenta, @Folio, @IdSurtido, 0, 0, 1
			
			--select @SerieD = SerieDevoluciones from Configuracion where IdCedis = @IdCedis
			--select @FolioD = ISNULL(MAX(Folio) + 1, 1)
			--from Ventas 
			--where Serie = @SerieD and IdTipoVenta = 3

			--insert into Ventas 	
			--select SURD.IdCedis, SURD.IdSurtido, 3, @FolioD, @SerieD, SURD.Fecha, 0,0,0, '', 0, 0
			--from Surtidos SURD 
			--where SURD.IdCedis = @IdCedis and SURD.IdSurtido = @IdSurtidoD  
			
			--select @IdCliente = IdCliente, @IdSucursal = IdSucursal, @Serie = Serie 
			--from Ventas
			--where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdTipoVenta = @IdTipoVenta and Folio = @Folio 

			--update Ventas set IdCliente = @IdCliente, IdSucursal = @IdSucursal 
			--where IdCedis = @IdCedis and IdSurtido = @IdSurtidoD and IdTipoVenta = 3 and Folio = @FolioD 
			
			--insert into VentasDevolucion values (@IdCedis, @IdSurtidoD, 3, @FolioD, @SerieD, @IdSurtido, @IdTipoVenta, @Folio, @Serie, @IdCliente, @IdSucursal) 
		end
		
		select top 1 @IdSurtidoD = IdSurtidoD, @IdTipoVentaD = IdTipoVentaD, @FolioD = FolioD, @SerieD = SerieD  
		from VentasDevolucion 
		where IdCedisD = @IdCedis and IdSurtido = @IdSurtido and IdTipoVenta = @IdTipoVenta and Folio = @Folio and IdSurtidoD = @IdSurtido 
		order by FolioD 
		
		delete from VentasDetalle 
		where IdCedis = @IdCedis and IdSurtido = @IdSurtidoD and IdTipoVenta = @IdTipoVentaD and Folio = @FolioD
		
		insert into VentasDetalle 
		select IdCedis, @IdSurtidoD, @IdTipoVentaD, @FolioD, IdProducto, @SerieD, Entregado - Cantidad, Precio, Iva, DctoPorc, DctoImp, 0
		from VentasDetalle 
		where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdTipoVenta = @IdTipoVenta and Folio = @Folio 
			and Cantidad <> Entregado 
	end
end
GO


