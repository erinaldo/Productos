
use RouteADM 

delete from StatusRutas 
delete from StatusSurtido  
delete from StatusLiquidacion 

delete 
from Vendedores 
where IdCedis = 0 and IdVendedor not in (1,2,3)

delete 
from Rutas 
where IdCedis = 0 and IdRuta not in (1,2,3)

