
declare @idCedis int, @idTipoVenta int, @Folio int, @Serie as varchar(10), @fecha as datetime

set @idCedis = 1
set @idTipoVenta = 1
set @Folio = 36
set @Serie = 'TJC'
set @fecha = '20110429'

--execute up_VentasContado 1, '04/29/2011', 0, 'TJC',  '', 1, 1
execute sel_VentasContado 1, '04/29/2011', 1, 4

exec Route.dbo.sp_importVentaCPGADM 1,'20110429',1,37,'TJC','8C99DC21A3C55C09','B2E7B35FFF46B0F3', 'CFDCed1',0 

select * 
-- delete 
from Route.dbo.TransProd where TransProdID = '8C99DC21A3C55C09'
select * 
-- delete
from Route.dbo.TransProdDetalle where TransProdID = '8C99DC21A3C55C09'
select * 
-- delete 
from Route.dbo.TPDImpuesto where TransProdID = '8C99DC21A3C55C09'

select * 
-- delete 
from Route.dbo.TransProd where TransProdID = 'B2E7B35FFF46B0F3'
select * 
-- delete 
from Route.dbo.TRPDatoFiscal where TransProdID = 'B2E7B35FFF46B0F3'

				--select VentasDetalle.IdProducto, isnull(sum(VentasDetalle.Cantidad), 0) as Cantidad, 
				--sum(VentasDetalle.SubTotal + VentasDetalle.DctoImp) / sum(VentasDetalle.Cantidad) as Precio, avg(VentasDetalle.Iva) as Iva, SUM(VentasDetalle.DctoImp) as Dcto
				--from RouteADM.dbo.Ventas as Ventas
				--inner join RouteADM.dbo.VentasDetalle as VentasDetalle on Ventas.IdCedis = VentasDetalle.IdCedis and VentasDetalle.IdSurtido = Ventas.IdSurtido 
				--	and Ventas.IdTipoVenta = VentasDetalle.IdTipoVenta and VentasDetalle.Folio = Ventas.Folio  
				--left outer join RouteADM.dbo.FN_VentasContadoFacturadas(@IdCedis, @Fecha, @Fecha) FNFact on Ventas.IdCedis = FNFact.IdCedis and Ventas.IdSurtido = FNFact.IdSurtido 
				--	and Ventas.IdTipoVenta = FNFact.IdTipoVenta and Ventas.Folio = FNFact.Folio 
				--left outer join RouteADM.dbo.FN_VentasContadoPOSTFactura(@IdCedis, @Fecha, @Fecha) FNPostFact on Ventas.IdCedis = FNPostFact.IdCedis and Ventas.IdSurtido = FNPostFact.IdSurtido 
				--	and Ventas.IdTipoVenta = FNPostFact.IdTipoVenta and Ventas.Folio = FNPostFact.Folio 
				--where Ventas.IdCedis = @IdCedis and Ventas.Fecha = @Fecha and Ventas.IdTipoVenta = 1
				--	and FNFact.Folio is null and FNPostFact.Folio is null
				--group by VentasDetalle.IdProducto

		--select SUM(VentasDetalle.DctoImp) as Dcto,
		--isnull(sum(VentasDetalle.Subtotal), 0) as Subtotal, 
		--isnull(sum(VentasDetalle.subtotal*VentasDetalle.iva), 0) as Impuestos, isnull(sum(VentasDetalle.total), 0) as Total
		--from Ventas 
		--inner join VentasDetalle on Ventas.IdCedis = VentasDetalle.IdCedis and VentasDetalle.IdSurtido = Ventas.IdSurtido 
		--	and Ventas.IdTipoVenta = VentasDetalle.IdTipoVenta and VentasDetalle.Folio = Ventas.Folio  
		--left outer join FN_VentasContadoFacturadas(@IdCedis, @Fecha, @Fecha) FNFact on Ventas.IdCedis = FNFact.IdCedis and Ventas.IdSurtido = FNFact.IdSurtido 
		--	and Ventas.IdTipoVenta = FNFact.IdTipoVenta and Ventas.Folio = FNFact.Folio 
		--left outer join FN_VentasContadoPOSTFactura(@IdCedis, @Fecha, @Fecha) FNPostFact on Ventas.IdCedis = FNPostFact.IdCedis and Ventas.IdSurtido = FNPostFact.IdSurtido 
		--	and Ventas.IdTipoVenta = FNPostFact.IdTipoVenta and Ventas.Folio = FNPostFact.Folio 
		--where Ventas.IdCedis = @IdCedis and Ventas.Fecha = @Fecha and Ventas.IdTipoVenta = 1
		--	and FNFact.Folio is null and FNPostFact.Folio is null

		--select VentasDetalle.IdProducto, IdTipoImpuesto, TipoAplicacion, Jerarquia, Tasa 
		--from Ventas 
		--inner join VentasDetalle on Ventas.IdCedis = VentasDetalle.IdCedis and VentasDetalle.IdSurtido = Ventas.IdSurtido 
		--	and Ventas.IdTipoVenta = VentasDetalle.IdTipoVenta and VentasDetalle.Folio = Ventas.Folio  
		--left outer join VentasImpuestos on VentasImpuestos.IdCedis = VentasDetalle.IdCedis and VentasDetalle.IdSurtido = VentasImpuestos.IdSurtido 
		--	and VentasImpuestos.IdTipoVenta = VentasDetalle.IdTipoVenta and VentasDetalle.Folio = VentasImpuestos.Folio  
		--left outer join FN_VentasContadoFacturadas(@IdCedis, @Fecha, @Fecha) FNFact on Ventas.IdCedis = FNFact.IdCedis and Ventas.IdSurtido = FNFact.IdSurtido 
		--	and Ventas.IdTipoVenta = FNFact.IdTipoVenta and Ventas.Folio = FNFact.Folio 
		--left outer join FN_VentasContadoPOSTFactura(@IdCedis, @Fecha, @Fecha) FNPostFact on Ventas.IdCedis = FNPostFact.IdCedis and Ventas.IdSurtido = FNPostFact.IdSurtido 
		--	and Ventas.IdTipoVenta = FNPostFact.IdTipoVenta and Ventas.Folio = FNPostFact.Folio 
		--where Ventas.IdCedis = @IdCedis and Ventas.Fecha = @Fecha and Ventas.IdTipoVenta = 1
		--	and FNFact.Folio is null and FNPostFact.Folio is null
		--group by VentasDetalle.IdProducto, IdTipoImpuesto, TipoAplicacion, Jerarquia, Tasa, round(VentasDetalle.Precio,3)  
		--order by VentasDetalle.IdProducto, IdTipoImpuesto, TipoAplicacion, Jerarquia, Tasa, round(VentasDetalle.Precio,3)

		--select IdTipoImpuesto, TipoAplicacion, Jerarquia, Tasa
		--from RouteADM.dbo.PedidosImpuestos as VtasImp
		--where VtasImp.IdCedis = @IdCedis and VtasImp.IdPedido = @IdPedido and VtasImp.IdProducto = @IdProducto --and VtasImp.IdTipoVenta = @IdTipoVenta and VtasImp.Folio = @Folio 
		--order by TipoAplicacion, Jerarquia
