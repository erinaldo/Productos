
use RouteADM 

alter table VendedoresSaldosFinancia
	add Fecha datetime
GO

update VendedoresSaldosFinancia set Fecha = cast(YEAR(FechaElaboracion) as varchar(4)) 
	+ REPLICATE('0', 2- len(MONTH(FechaElaboracion))) + cast(MONTH(FechaElaboracion) as varchar(2))
	+ REPLICATE('0', 2- len(day(FechaElaboracion))) + cast(day(FechaElaboracion) as varchar(2))

select * from VendedoresSaldosFinancia 
