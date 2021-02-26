
use RouteADM 

alter table InventarioFisico
add Captura [decimal](19, 4)
Go

alter table InventarioFisico
add DevBuena [decimal](19, 4)
Go

update InventarioFisico set Captura = Cantidad, DevBuena = 0

GO
