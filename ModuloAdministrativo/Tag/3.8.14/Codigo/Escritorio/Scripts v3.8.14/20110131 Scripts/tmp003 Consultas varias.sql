
select TransProdID, Total, Saldo, Folio 
from Route.dbo.TransProd 
where Folio = 'EBL0000673'

--update Route.dbo.TransProd set Folio = 'EBLX0000673'
--where TransProdID = 'EBL0000673C'

select TransProdID, Total, Saldo, Folio 
from Route.dbo.TransProd 
where TransProdID like 'EB%C%' and Tipo = 1


--select *
--from Route.dbo.TransProd 
--where FacturaID = '111-B86F39778890'

select *
from Route.dbo.AbnTrp 
where TransProdID = '111-B86F39778890'

select * 
from Route.dbo.Abono 
where ABNId = 'ED01095F9AA4AD20'

select * 
from Route.dbo.ABNDetalle 
where ABNId = 'ED01095F9AA4AD20'