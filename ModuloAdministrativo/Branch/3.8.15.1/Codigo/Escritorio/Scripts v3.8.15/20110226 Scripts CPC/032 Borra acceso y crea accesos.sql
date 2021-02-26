
use RouteCPC 

delete
from Modulo 
where IdModulo in ('PROMO', 'PROM')

insert into Modulo values ('ACUE', 'ACUERDOS POSTVENTA')
insert into Modulo values ('ANTI', 'ANTICIPOS')

insert into UsuariosModulos 
select distinct LOGIN, 'ACUE'
from UsuariosModulos 
where Modulo  in ('PROMO', 'PROM')

delete
from UsuariosModulos 
where Modulo  in ('PROMO', 'PROM')


