
use RouteCPC 

select * from GReportesNaturaleza 

select * 
from GReportesNivel 
where IdReporte in (8, 18, 6, 7)

insert into GReportesNivel values (6, 2, 'Por Sucursal de Cliente', 20, 0, 1, 'Clientes.IdCliente', 'S','S','S', '', 21, 0, 10)
insert into GReportesNivel values (18, 2, 'Por Sucursal de Cliente', 20, 0, 2, 'Clientes.IdCliente', 'S','S','S', '', 21, 0, 13)