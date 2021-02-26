
select Surtidos.IdCedis, Surtidos.IdRuta, SurtidosVendedor.IdVendedor, count(*)
from Surtidos 
inner join SurtidosVendedor on Surtidos.IdCedis = SurtidosVendedor.IdCedis and Surtidos.IdSurtido = SurtidosVendedor.IdSurtido 
where Surtidos.Fecha > '20101120' -- and IdRuta = 706
group by Surtidos.IdCedis, Surtidos.IdRuta, SurtidosVendedor.IdVendedor
order by IdRuta-- , Surtidos.Fecha 

select *
from VendedoresSaldos 
where IdVendedor = 3467

select *
from TipoVendedor 

select *
from Surtidos 
inner join SurtidosVendedor on Surtidos.IdCedis = SurtidosVendedor.IdCedis and Surtidos.IdSurtido = SurtidosVendedor.IdSurtido 
where Surtidos.Fecha > '20101120' and IdRuta = 706

--update SurtidosVendedor set IdVendedor = 3467, IdTipoVendedor = 1
--from Surtidos, SurtidosVendedor 
--where Surtidos.IdCedis = SurtidosVendedor.IdCedis and Surtidos.IdSurtido = SurtidosVendedor.IdSurtido 
-- and Surtidos.Fecha > '20101120' and IdRuta = 706

