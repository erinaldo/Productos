
declare 
@IdCedis as bigint,
@IdSurtido as bigint,
@IdTipoVenta as bigint,
@Folio as bigint,
@IdSurtidoD as bigint,
@IdTipoVentaD as bigint,
@FolioD as bigint,
@Opc as int

declare @Filtro as varchar(8000)

set @IdCedis = 2
set @IdSurtido = 3072
set @IdTipoVenta = 1
set @Folio = 8767
set @Opc = 2

if @Opc = 1
begin 

	select VentasDevolucion.IdCedisD, VentasDevolucion.IdSurtidoD, VentasDevolucion.IdTipoVentaD, VentasDevolucion.SerieD, VentasDevolucion.FolioD, 
	isnull(VentasTipo.TipoVenta, 'Tipo de Venta no Definido') as 'Tipo de Venta'
	from VentasDevolucion 
	inner join VentasTipo on VentasDevolucion.IdTipoVentaD = VentasTipo.IdTipoVenta
	where VentasDevolucion.IdCedisD = @IdCedis and VentasDevolucion.IdSurtido = @IdSurtido 
		and VentasDevolucion.IdTipoVenta = @IdTipoVenta and VentasDevolucion.Folio = @Folio 

end

if @Opc = 2
begin
	select VentasDetalle.IdCedis, VentasDetalle.IdSurtido, VentasDetalle.IdTipoVenta, VentasDetalle.Folio, 
	VentasDetalle.IdProducto as 'Cve. Prod.', Productos.Producto as 'Producto', 
	VentasDetalle.Cantidad as 'Cantidad', isnull(Dev.Cantidad,0) as 'Devolución',
	VentasDetalle.Precio as 'Precio', 
	VentasDetalle.DctoPorc as 'Dcto.', VentasDetalle.DctoImp as 'Dcto. Imp.', VentasDetalle.Subtotal as 'Subtotal', 
	((VentasDetalle.Cantidad * VentasDetalle.Precio ) - VentasDetalle.DctoImp )* VentasDetalle.Iva as 'Iva', VentasDetalle.Total as 'Total'
	from VentasDetalle
	inner join Productos on VentasDetalle.IdProducto = Productos.IdProducto
	left outer join VentasDevolucion VtasDev on VtasDev.IdCedisD = VentasDetalle.IdCedis and VtasDev.IdSurtido = VentasDetalle.IdSurtido 
		and VtasDev.IdTipoVenta = VentasDetalle.IdTipoVenta and VtasDev.Folio = VentasDetalle.Folio 
	left outer join VentasDetalle Dev on Dev.IdCedis = VtasDev.IdCedisD and Dev.IdSurtido = VtasDev.IdSurtidoD  
		and Dev.IdTipoVenta = VtasDev.IdTipoVentaD and Dev.Folio = VtasDev.FolioD and VentasDetalle.IdProducto = Dev.IdProducto 
	where VentasDetalle.IdCedis = @IdCedis and VentasDetalle.IdSurtido = @IdSurtido
	and VentasDetalle.IdTipoVenta = @IdTipoVenta and VentasDetalle.Folio = @Folio 
	order by VentasDetalle.IdProducto
end


--select *
--from VentasDevolucion 
