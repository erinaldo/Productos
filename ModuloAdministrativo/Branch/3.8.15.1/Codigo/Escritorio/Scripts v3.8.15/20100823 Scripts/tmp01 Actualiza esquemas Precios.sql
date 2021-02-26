
insert into RouteADM.dbo.PreciosLista 
select *
from PreciosLista 
where IdLista = 4

insert into RouteADM.dbo.PreciosDetalle 
select PD2.IdLista, PD2.IdProducto, PD2.Precio
from PreciosDetalle PD2
left outer join RouteADM.dbo.PreciosDetalle PD on PD2.IdLista = PD.IdLista and PD.IdProducto = PD2.IdProducto 
where PD.Precio is null

delete from RouteADM.dbo.PreciosListaCedis 
insert into RouteADM.dbo.PreciosListaCedis 
select IdLista, 1
from PreciosListaCedis 

delete from RouteADM.dbo.PreciosListaCliente 
insert into RouteADM.dbo.PreciosListaCliente 
select 1, IdCliente, IdLista 
from PreciosListaCliente 

delete from RouteADM.dbo.PreciosListaRuta 
insert into RouteADM.dbo.PreciosListaRuta  
select 1, IdRuta, IdLista 
from PreciosListaRuta 


