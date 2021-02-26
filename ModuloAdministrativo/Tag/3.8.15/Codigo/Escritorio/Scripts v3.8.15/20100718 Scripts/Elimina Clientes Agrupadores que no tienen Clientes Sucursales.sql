--Elimina Clientes Agrupadores que no tienen Clientes Sucursales
delete from Clientes where IdCliente not in (
select idcliente from ClienteSucursal)