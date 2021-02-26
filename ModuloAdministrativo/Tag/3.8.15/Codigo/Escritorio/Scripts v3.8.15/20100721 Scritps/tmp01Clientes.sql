

declare @Clave as varchar(100)

set @Clave = '8658'

select *
from Clientes 
where CAST(idcliente as varchar(100)) like '%' + @Clave + '%' 

select *
from Clientes 
where CAST(idcliente as varchar(100)) like '%' + @Clave + '%' 

--select * from ClienteSucursal 
--where -- IdSucursal like '%9439%'
--IdCliente not in (select IdCliente 
--from Clientes)
--order by IdSucursal 

--select * from ClienteS
--where -- IdSucursal like '%9439%'
--IdCliente not in (select IdCliente 
--from Clientesucursal)
--order by IdCliente 