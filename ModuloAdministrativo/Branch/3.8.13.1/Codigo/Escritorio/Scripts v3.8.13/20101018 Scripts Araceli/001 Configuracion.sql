
use [RouteADM] 

alter table Configuracion add Descuentos bit

alter table Configuracion add ReporteFactura varchar(50)

update Configuracion set Descuentos = 0, ReporteFactura = 'ARACELI'
