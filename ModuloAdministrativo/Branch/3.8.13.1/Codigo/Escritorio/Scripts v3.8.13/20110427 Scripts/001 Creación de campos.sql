
use RouteADM 

alter table Ventas add FechaEdicion datetime
alter table Ventas add Login varchar (20)

alter table VentasCanceladas add FechaEdicion datetime
alter table VentasCanceladas add Login varchar(20)

--alter table VentasFacturadas add FechaEdicion datetime
alter table VentasFacturadas add Login varchar(20)

--alter table PedidosFacturados add FechaEdicion datetime
alter table PedidosFacturados add Login varchar(20)

go

use RouteADM 

update Ventas set FechaEdicion = Fecha, login = 'SUPER'
update VentasCanceladas set FechaEdicion = Fecha, login = 'SUPER'
update VentasFacturadas set login = 'SUPER' 
update PedidosFacturados set login = 'SUPER'





