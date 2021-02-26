
use RouteADM 

-- exec Route.dbo.sp_importVentaCPGADM  1, '20110429', 1, 21, 'TJ', 'B9743F1CF026234D', '945ED350DDD5C8F9', 'CFDCed1', 0 

select *
-- delete 
from VentasFacturaCFD where FechaFPG = '20110429' 

select *
-- delete 
from VentasContado 

select *
from Route.dbo.TransProd where TransProdID = '981503FE987B598B'
--select *
--from Route.dbo.TransProdDetalle where TransProdID = 'B9743F1CF026234D'
--select *
--from Route.dbo.TPDImpuesto where TransProdID = 'B9743F1CF026234D'

select *
from Route.dbo.TRPDatoFiscal where TransProdID = 'AE30D4C622D2EC7E'
select *
from Route.dbo.TransProd where TransProdID = 'AE30D4C622D2EC7E'