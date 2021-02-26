use [RouteADM] 

--alter table Ventas 
--drop column DctoImp 
--GO
alter table Ventas 
drop column DiasCredito
GO

--alter table VentasDetalle
--drop column Subtotal
--GO
--alter table VentasDetalle 
--drop column total
--GO
----alter table VentasDetalle 
----drop column DctoImp
----GO
----alter table VentasDetalle 
----drop column DctoPorc
----GO

-- Agrega Columnas
alter table Ventas 
add DctoImp money NULL
GO
alter table Ventas 
add DiasCredito money NULL
GO

--alter table VentasDetalle 
--add SubTotal money null 
--GO
--alter table VentasDetalle 
--add Total money null 
--GO
--alter table VentasDetalle 
--add DctoPorc money NULL
--GO
--alter table VentasDetalle 
--add DctoImp money NULL
--GO

--alter table VentasDetalle 
--alter column SubTotal AS (([Cantidad]*[Precio])-[DctoImp])
--GO
--alter table VentasDetalle 
--add Total AS ((([Cantidad]*[Precio])-[DctoImp])*(1+[Iva]))
--GO

update Ventas set DctoImp = 0
update Ventas set DiasCredito = 0
--update VentasDetalle set DctoImp = 0
--update VentasDetalle set DctoPorc = 0