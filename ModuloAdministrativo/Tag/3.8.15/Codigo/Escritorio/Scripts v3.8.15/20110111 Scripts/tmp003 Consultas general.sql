
select *
-- delete 
from VendedoresSaldos  
where IdVendedor = 82 -- and IdSurtido = 4724
and Fecha >= '20110101'
order by idvendedor, Fecha desc, IdSurtido desc

--select * from Surtidos where IdCedis = 2 and IdRuta = 82 and Fecha >= '20110101' order by idsurtido

select *
-- delete 
from VendedoresCargosAbonos 
where IdVendedor = 82 and IdCargoAbono >= 164

-- update VendedoresCargosAbonos set IdSurtido = 0 where IdVendedor = 82 and IdCargoAbono >= 164
--update Surtidos set Status = 'P' where IdSurtido = 4724 and IdCedis = 2

-- exec up_VendedoresSaldos 2, 4731, 82, '20110113', 1 

--execute up_SurtidosDenominacion 2, 4724, 0, '', '', 0, '', 0, 2
--execute up_VendedoresSaldos2 2, 0, 82, '01/13/2011', 'EF', 500, 'PRUEBAS', 4724, 1

