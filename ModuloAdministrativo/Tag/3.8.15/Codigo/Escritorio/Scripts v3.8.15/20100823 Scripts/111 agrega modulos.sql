
select *
from Modulo 

select *
from GrupoModulos 

select *
from ModuloGrupo 

update GrupoModulos set Orden = Orden + 1 where Orden >= 4

insert into GrupoModulos values ('GSALDOS', 'Saldos del Vendedor', 4, 'A')

insert into Modulo values ('VENSAL', 'Administrar Saldos del Vendedor')
insert into Modulo values ('VENSALCA', 'Cargos y Abonos al Saldo del Vendedor')
insert into Modulo values ('VENSALFINA', 'Agregar Financiamiento de Saldo')
insert into Modulo values ('VENSALFINE', 'Eliminar Financiamiento de Saldo')
insert into Modulo values ('VENSALVAL', 'Validar Saldo del Vendedor')

insert into ModuloGrupo values ('GSALDOS', 'VENSAL')
insert into ModuloGrupo values ('GSALDOS', 'VENSALCA')
insert into ModuloGrupo values ('GSALDOS', 'VENSALFINA')
insert into ModuloGrupo values ('GSALDOS', 'VENSALFINE')
insert into ModuloGrupo values ('GSALDOS', 'VENSALVAL')
