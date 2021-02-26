use RouteCPC 

select * from GReportesNaturaleza 

insert into GReportesNivel values (6,3, 'Por Marca', 30, 0,1, 'FN_VencimientoAlaFechaS.IdMarca', 'S', 'S', 'S', '', 31, 0,11)
insert into GReportesNivel values (7,3, 'Por Marca', 30, 0,1, 'FN_VencimientoAlaFechaS.IdMarca', 'S', 'S', 'S', '', 31, 0,10)

insert into GReportesNivel values (8,3, 'Por Marca', 30, 0,1, 'FN_SaldosPorFechaS.IdMarca', 'S', 'S', 'S', '', 31, 0,9)
insert into GReportesNivel values (18,3, 'Por Marca', 30, 0,1, 'FN_BalanzaDetalladaS.IdMarca', 'S', 'S', 'S', '', 31, 0,14)

select * 
-- delete
from GReportesNivel 
where IdReporte in (6,7, 8, 18) and IdSubReporte = 3