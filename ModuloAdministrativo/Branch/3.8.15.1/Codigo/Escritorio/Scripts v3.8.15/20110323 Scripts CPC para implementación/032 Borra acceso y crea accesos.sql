
use RouteCPC 

delete
from Modulo 
where IdModulo in ('PROMO', 'PROM', 'OXXO')

insert into Modulo values ('ACUE', 'ACUERDOS POSTVENTA')
insert into Modulo values ('ANTI', 'ANTICIPOS')
insert into Modulo values ('FGLOB', 'FACTURACIÓN GLOBAL')

insert into UsuariosModulos 
select distinct LOGIN, 'ACUE'
from UsuariosModulos 
where Modulo  in ('PROMO', 'PROM')

delete
from UsuariosModulos 
where Modulo  in ('PROMO', 'PROM')

insert into UsuariosModulos 
select distinct LOGIN, 'FGLOB'
from UsuariosModulos 
where Modulo  in ('OXXO')

delete
from UsuariosModulos 
where Modulo  in ('OXXO')



