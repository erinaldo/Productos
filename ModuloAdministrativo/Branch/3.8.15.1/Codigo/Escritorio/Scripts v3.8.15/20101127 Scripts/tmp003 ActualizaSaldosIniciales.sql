
select *
-- delete 
from VendedoresSaldos 
where IdVendedor in( 169 ) and IdSurtido <> 0 -- or IdRuta = 188

select * from VendedoresSaldos  where IdVendedor = 188 and IdSurtido = 0

select * from VendedoresCargosAbonos  

/*
update Surtidos set Status = 'C' where IdSurtido = 3158
update StatusDia set Status = 'C' where Fecha = '20101123'
*/
--update VendedoresCargosAbonos set IdVendedor = 188, Fecha = '20101123'
--INSERT INTO VENDEDORESSALDOS VALUES (2, 0, 0, 'EF', CAST('3467' AS INT), '20101120', 0, 21826.23*-1, 0, 21826.23*-1)
-- update VendedoresSaldos set saldo = -7316.99, saldoactual = -7316.99 where IdVendedor = 188 and IdSurtido = 0