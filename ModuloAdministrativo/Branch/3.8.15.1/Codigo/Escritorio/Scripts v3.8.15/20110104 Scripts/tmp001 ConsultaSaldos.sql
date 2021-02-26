
--exec up_VendedoresSaldos  2, 4442, 150, '20110104', 1

select *
-- delete 
from VendedoresSaldos 
where IdVendedor = 2902 --and Fecha between '20101223' and '20110130' 
order by IdVendedor, Fecha, IdSurtido

select *
-- delete 
from VendedoresCargosAbonos 
where Fecha between '20101220' and '20110107' and IdVendedor = 2902

--select distinct Surtidos.IdRuta, SurtidosVendedor.IdVendedor  
--from Surtidos 
--inner join SurtidosVendedor on Surtidos.IdCedis = SurtidosVendedor.IdCedis and Surtidos.IdSurtido = SurtidosVendedor.IdSurtido 
--	and SurtidosVendedor.IdVendedor = 2902
--where Surtidos.Fecha between '20101226' and '20110101'  

