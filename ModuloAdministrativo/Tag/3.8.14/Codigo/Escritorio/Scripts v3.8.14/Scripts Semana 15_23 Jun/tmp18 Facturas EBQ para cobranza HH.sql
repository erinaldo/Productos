
use Route  

update TransProd set SubEmpresaID = 2 
where Tipo = 8 and Folio like 'EBQX%' and SubEmpresaID is null 

update TransProd set SubEmpresaID = 1 
where Tipo = 8 and Folio like 'EBQ%' and SubEmpresaID is null 


-- insert into Route.dbo.tmp_Factura
select RIGHT(newid(),16), 
replicate('0', 2 - len( DAY(Ventas.Fecha) ) ) + cast( DAY(Ventas.Fecha) as varchar(2)) + '/' + 
	replicate('0', 2 - len( month(Ventas.Fecha) ) ) + cast( month(Ventas.Fecha) as varchar(2)) + '/' + cast( year(Ventas.Fecha) as varchar(4)), 
IdSucursal, cast( Ventas.IdCedis as varchar(10) ) + replicate('0', 4 - len( IdRuta ) ) + cast( IdRuta as varchar(10)), 
Serie + REPLICATE('0',7-len(Folio)) + CAST(folio as varchar(10)), 1, Ventas.Fecha, Ventas.Fecha, Ventas.Fecha, Ventas.Fecha, 2,
Ventas.Subtotal, Iva, Ventas.Total, Ventas.Total, '', GETDATE(), cast( Ventas.IdCedis as varchar(10) ) + replicate('0', 4 - len( IdRuta ) ) + cast( IdRuta as varchar(10)) 
from RouteADM.dbo.Ventas as Ventas 
inner join RouteADM.dbo.Surtidos as Surtidos on Surtidos.IdSurtido = Ventas.IdSurtido and Ventas.IdCedis = Surtidos.IdCedis 
	and Surtidos.IdRuta <> 17
where Serie like 'EBQ%' and Ventas.Fecha between '20100528' and '20100625' and Ventas.IdTipoVenta = 2 
and Serie + REPLICATE('0',7-len(Ventas.Folio)) + CAST(Ventas.folio as varchar(10)) not in (
	select Folio collate SQL_Latin1_General_CP1_CI_AS  from Route.dbo.TransProd where Tipo = 8)
order by Ventas.Fecha, Ventas.Serie, Ventas.Folio 


