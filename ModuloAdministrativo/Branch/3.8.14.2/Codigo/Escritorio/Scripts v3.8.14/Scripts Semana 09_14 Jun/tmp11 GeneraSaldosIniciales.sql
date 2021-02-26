-- select * from RouteCPC.dbo.Ventas 

-- insert into RouteCPC.dbo.Ventas 
select 1, 2, SUBSTRING(TP.Folio,4,4), SUBSTRING(TP.Folio,1,3), TP.FechaFacturacion, VS.ClienteClave, Tp.Subtotal, 0, 0, 0, 0, '', 'Inicial', GETDATE()
from TransProd TP
inner join Visita VS on VS.VisitaClave = TP.VisitaClave 
where TP.Tipo = 8 and TP.MUsuarioID = '10000'
	and isnumeric(SUBSTRING(folio,1,2)) = 1 and isnumeric(SUBSTRING(folio,3,1)) = 0 
order by TP.Folio

--2
-- insert into RouteCPC.dbo.Ventas 
select 1, 2, SUBSTRING(TP.Folio,3,5), SUBSTRING(TP.Folio,1,2), TP.FechaFacturacion, VS.ClienteClave, Tp.Subtotal, 0, 0, 0, 0, '', 'Inicial', GETDATE()
from TransProd TP
inner join Visita VS on VS.VisitaClave = TP.VisitaClave 
where TP.Tipo = 8 and TP.MUsuarioID = '10000'
	and isnumeric(SUBSTRING(folio,1,1)) = 1 and isnumeric(SUBSTRING(folio,2,1)) = 0 
order by TP.Folio

--3
-- insert into RouteCPC.dbo.Ventas 
select 1, 2, SUBSTRING(TP.Folio,3,5), SUBSTRING(TP.Folio,1,2), TP.FechaFacturacion, VS.ClienteClave, Tp.Subtotal, 0, 0, 0, 0, '', 'Inicial', GETDATE()
from TransProd TP
inner join Visita VS on VS.VisitaClave = TP.VisitaClave 
where TP.Tipo = 8 and TP.MUsuarioID = '10000'
	and isnumeric(SUBSTRING(folio,2,1)) = 1 and isnumeric(SUBSTRING(folio,1,1)) = 0
order by TP.Folio

--4
-- insert into RouteCPC.dbo.Ventas2 
select -- Tp.TransProdId,
1, 2, SUBSTRING(TP.Folio,4,7), case SUBSTRING(TP.TransProdID,LEN(TP.TransProdID),1) when 'C' then SUBSTRING(TP.Folio,1,3) + 'X' else SUBSTRING(TP.Folio,1,3) end, TP.FechaFacturacion, VS.ClienteClave, Tp.Subtotal, 0, 0, 0, 0, '', 'Inicial', GETDATE()
from TransProd TP
inner join Visita VS on VS.VisitaClave = TP.VisitaClave 
where TP.Tipo = 8 and TP.MUsuarioID = '10000'
	and isnumeric(SUBSTRING(folio,1,1)) = 0 and isnumeric(SUBSTRING(folio,3,1)) = 0
order by TP.Folio

/*
select Folio, COUNT(transprodid)
from TransProd 
where Tipo = 8 and MUsuarioID = '10000'
group by Folio 
having COUNT(transprodid) > 1
order by Folio 
*/

