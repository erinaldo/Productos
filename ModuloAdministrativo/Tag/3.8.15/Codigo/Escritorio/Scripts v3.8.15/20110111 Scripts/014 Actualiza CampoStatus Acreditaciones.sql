
use RouteADM 

update VentasAcredita set Status = 'A'
where Status = ''

select distinct Status 
from VentasAcredita 


