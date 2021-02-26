

select * from Ventas 
-- insert into ventas
select idcedis, idtipovent, FolioN, serie, '20110404', idcliente, subtotal, impuestos, 0,0, diasvencim, idsucursal, 1, Origen, 0, 'A', 'Iniciales', GETDATE()
from Enc  
where origen <> '201101040A3'

select * from VentasDetalle 
-- insert into ventasdetalle
select idcedis, idtipovent, FolioN, idproducto, serie, cantidad, precio, impuestos, dctoproc, dctoimp, entregado 
from Det 
where origen <> '201101040A3'

select * from VentasAcredita 
-- insert into ventasacredita
select idcedis, idtipovent, FolioN, serie, '20110401', '20110401', 'Iniciales', '20110401', '20110401', '', 
	folioclien, remision, factura, 'A', 7
from Acr  
where origen <> '201101040A3'

select * from ventasacredita 

select sum(abonos) 
from Enc where status <> ''

--alter table acr add folioN bigint

--select idcedis, idtipovent, serie, FolioN, COUNT(idcliente)
--from Enc 
--group by idcedis, idtipovent, serie, FolioN
--having COUNT(idcliente) > 1

--update Enc set status = 'REPETIDOS'
--where idcedis = 6 and idtipovent = 2 and serie = 'JSY' and FolioN = 101216791111
