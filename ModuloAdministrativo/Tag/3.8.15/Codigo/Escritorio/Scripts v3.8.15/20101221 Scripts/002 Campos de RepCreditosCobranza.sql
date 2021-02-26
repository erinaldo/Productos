
use RouteADM 

alter table RepCreditosCobranza alter column NombreSucursal varchar(200)
GO

alter table RepCreditosCobranza alter column Folio varchar(15)
GO

select *
from RepCreditosCobranza 
