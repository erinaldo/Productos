
use RouteADM 

alter table VentasAcredita
add FolioCliente varchar(16)
GO

alter table VentasAcredita
add Remision varchar(16)
GO

alter table VentasAcredita
add Factura varchar(16)
GO

alter table VentasAcredita
add Status varchar(1)
GO

alter table VentasAcredita
add Vencimiento int
GO

update VentasAcredita set FolioCliente = '', Remision ='', Factura = '',  Status = '', vencimiento = 0

select *
from VentasAcredita 

