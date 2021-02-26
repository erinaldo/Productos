/*
select * from ventas
order by idcedis, idsurtido, fecha
*/
update ventas
set ventas.idcliente = clientes.idcliente
from ventas, clientesucursal as clientes
where ventas.idsucursal = clientes.idsucursal
and ventas.Fecha <= '20100425'

