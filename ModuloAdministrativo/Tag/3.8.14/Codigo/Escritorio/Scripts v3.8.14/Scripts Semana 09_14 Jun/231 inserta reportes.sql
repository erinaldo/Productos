use RouteCPC

insert into GReportesNivel values (7,2,'Por Sucursal de Cliente', 20, 0,1, 'Clientes.IdCliente', 'S','S','S', '', 21, 0,9)
insert into GReportesNivel values (8,2,'Por Sucursal de Cliente', 20, 0,1, 'Clientes.IdCliente', 'S','S','S', '', 21, 0,8)

--select * from GReportesNaturaleza where IdReporte = 7
--select * from GReportesNivel where IdReporte = 7

insert into GReportesNaturaleza values (20, 'Cobranza Terminales', 'S', 20)
insert into GReportesNivel values (20, 1, 'Por Fecha', 10, 0,0, 'Fecha', 'S','S','S', 'Fecha', 11, 0,6)


use RouteADM 

insert into GReportesNaturaleza values (28, 'Cuenta Comprobada', 'S')

update GReportesNaturaleza set NombreReporte = 'Cuenta Comprobada' where IdReporte = 28

insert into GReportesNivel values (28, 1, 'Por Fecha', 10, 0,0, 'Fecha', 'S','S','S', 'IdMarca', 11, 1, 10)
update GReportesNivel set CampoFiltro = 'VEN.IdTipoVenta', CampoFinal = 1 where IdReporte = 28

update GReportesNivel set CampoFinalXLS = 22
where IdReporte = 28