--
--select idcedis, idsucursal, nombresucursal, formaventa
--from clientesucursal

select idcedis, idsucursal, nombresucursal, formaventa, cfvtipo, formaventa - cfvtipo as diferencias
from clientesucursal
inner join route.dbo.cliformaventa on clienteclave = idsucursal and estado = 1 and inicial = 1
where formaventa - cfvtipo <> 0
order by idsucursal
--
--select *
--from route.dbo.cliformaventa
