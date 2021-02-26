
--select * from enc where Origen = ''

--alter table det add folioN bigint

 --Actualiza folioN
--select replace(REPLACE(REPLACE(route.dbo.FNObtenerSoloNumeros(folio),'+',''),'-',''),'.',''), folio, *
--from Enc 
--where ISNUMERIC(replace(REPLACE(REPLACE(route.dbo.FNObtenerSoloNumeros(folio),'+',''),'-',''),'.',''))= 0

--update enc set folion = replace(REPLACE(REPLACE(route.dbo.FNObtenerSoloNumeros(folio),'+',''),'-',''),'.','')
--update det set folion = replace(REPLACE(REPLACE(route.dbo.FNObtenerSoloNumeros(folio),'+',''),'-',''),'.','')
--update acr set folion = replace(REPLACE(REPLACE(route.dbo.FNObtenerSoloNumeros(folio),'+',''),'-',''),'.','')

--update enc set folion = replace(REPLACE(REPLACE(route.dbo.FNObtenerSoloNumeros(origen),'+',''),'-',''),'.','') where FolioN = 0
--update det set folion = replace(REPLACE(REPLACE(route.dbo.FNObtenerSoloNumeros(origen),'+',''),'-',''),'.','') where FolioN = 0
--update acr set folion = replace(REPLACE(REPLACE(route.dbo.FNObtenerSoloNumeros(origen),'+',''),'-',''),'.','') where FolioN = 0


select idcedis, idtipovent, serie, FolioN, COUNT(*)
from Enc 
group by idcedis, idtipovent, serie, FolioN
having COUNT(*) > 1

--select * from Enc where FolioN = 1012167911

--update Enc set status = 'REPETIDOS' where FolioN = 1012167911
