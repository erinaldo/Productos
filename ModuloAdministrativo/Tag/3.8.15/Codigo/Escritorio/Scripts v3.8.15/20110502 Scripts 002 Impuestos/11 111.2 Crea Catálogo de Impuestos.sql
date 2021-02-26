
use RouteADM 

delete from TipoImpuesto 

insert into TipoImpuesto values (1, 'IVA', 2, 1, 0,		'IVA 0.00%')
insert into TipoImpuesto values (2, 'IVA', 2, 1, .11,	'IVA 11.00%')
insert into TipoImpuesto values (3, 'IEPS', 1, 0, .25,	'IEPS 25.00%')

--update TipoImpuesto set TipoImpuesto = TipoImpuesto 

select * from Route.dbo.Impuesto 

