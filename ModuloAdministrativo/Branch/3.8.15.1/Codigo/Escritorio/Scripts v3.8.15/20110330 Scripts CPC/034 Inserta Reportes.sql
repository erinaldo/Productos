
USE RouteCPC 

--insert into GReportesNaturaleza values (22, 'VENTAS AL COBRO', 'S', 22)
--insert into GReportesNaturaleza values (23, 'MOVIMIENTOS (CARGO/ABONO)', 'S', 1)
--insert into GReportesNaturaleza values (24, 'CASA LEY', 'S', 24)

--insert into GReportesNivel values (22, 1, 'Por Cliente', 10, 0, 1, 'VEN.IdCliente', 'S','S','S', '', 11, 0, 9 )
--insert into GReportesNivel values (22, 2, 'Por Sucursal', 20, 0, 1, 'VEN.IdCliente', 'S','S','S', '', 21, 0, 9 )

--insert into GReportesNivel values (24, 1, 'Por Sucursal', 10, 0, 1, 'VEN.IdCliente', 'S','S','S', '', 11, 0, 9 )

--insert into GReportesNivel 
select 23, ROW_NUMBER() over (order by IdDocumento, IdTipoDocumento) as Id, IdDocumento + ' - ' + IdTipoDocumento + ' | ' + TipoDocumento as Descripcion, 
ROW_NUMBER() over (order by IdDocumento, IdTipoDocumento) + 99 as Ejecucion, 0, 1, 'MovimientosFacturas.IdTipoDocumento', 'S','S','S', '', 
ROW_NUMBER() over (order by IdDocumento, IdTipoDocumento) + 199 as EjeXLS, 0, 25
from DocumentosTipo 

select *
-- delete 
from GReportesNivel where IdReporte = 23


