
use RouteADM 

update ComEsquemaVendedor set Porcentaje = .03 
where IdConcepto = 'MERMA' and Porcentaje = .015 

update ComEsquemaVendedor set Porcentaje = .015 
where IdConcepto = 'MERMA' and Porcentaje = .01 

update ComEsquemaVendedor set Porcentaje = .01 
where IdConcepto = 'MERMA' and Porcentaje = .03

select distinct idvendedor, idconcepto, porcentaje 
from ComEsquemaVendedor 
where IdConcepto = 'MERMA' 
order by idvendedor, idconcepto, porcentaje 


