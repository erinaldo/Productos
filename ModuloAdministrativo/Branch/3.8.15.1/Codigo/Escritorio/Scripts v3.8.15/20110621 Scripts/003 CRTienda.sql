
use RouteADM 

alter table ClienteSucursal add CRTienda varchar(5)

GO

update ClienteSucursal set CRTienda = ''

update ClienteSucursal set CRTienda = TDA_GLN, TDA_GLN = '' where IdCliente in (1000,1200,8650,8659)


select * from ClienteSucursal where CRTienda <> ''
