use RouteADM 

select Pedidos.IdCedis, Pedidos.IdPedido, Pedidos.Serie, Pedidos.Folio, Pedidos.IdSucursal, Ventas.IdSucursal 
from Pedidos, Ventas 
where Pedidos.IdCedis = Ventas.IdCedis and Pedidos.IdSurtido = Ventas.IdSurtido 
	and Pedidos.IdTipoVenta = Ventas.IdTipoVenta and Pedidos.Folio = Ventas.Folio 

update Ventas set IdSucursal = Pedidos.IdSucursal 
from Pedidos, Ventas 
where Pedidos.IdCedis = Ventas.IdCedis and Pedidos.IdSurtido = Ventas.IdSurtido 
	and Pedidos.IdTipoVenta = Ventas.IdTipoVenta and Pedidos.Folio = Ventas.Folio 
