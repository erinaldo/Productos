
execute sel_Pedidos 1, '09/01/2010', '0', '110', 1

select *
from PreciosListaCliente 
where IdCliente = '9430'

select *
from PreciosDetalle 
inner join PreciosLista on PreciosDetalle.IdLista = PreciosLista.IdLista 
where IdProducto = 1

select *
from Pedidos 
where IdPedido  = 749 

select *
from Productos 
where Producto like '%nutri%'
