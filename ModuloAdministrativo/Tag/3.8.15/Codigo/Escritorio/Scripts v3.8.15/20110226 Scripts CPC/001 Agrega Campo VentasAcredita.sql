
use RouteADM 

alter table VentasAcredita
add StatusTransferido char(1) default 'N'
Go

use RouteADM 

update VentasAcredita set statustransferido = 'N'

select * from VentasAcredita 
