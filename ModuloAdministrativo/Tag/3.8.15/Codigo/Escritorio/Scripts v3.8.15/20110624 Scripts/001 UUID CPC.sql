
use RouteCPC 

alter table VentasFacturaCFD add UUID varchar(36)

GO

update VentasFacturaCFD set UUID = '' 

select * from VentasFacturaCFD 