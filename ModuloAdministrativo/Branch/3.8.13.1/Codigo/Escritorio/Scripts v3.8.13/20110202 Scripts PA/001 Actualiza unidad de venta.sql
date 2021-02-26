
use Route 

update VAVDescripcion set Descripcion = 'LT', MUsuarioId = 'Admin', MFechaHora = GETDATE()
where VARCodigo = 'UNIDADV' and VAVClave = 3

--update VARValor set Estado = 1, MUsuarioId = 'Admin', MFechaHora = GETDATE()
--where VARCodigo = 'UNIDADV' and VAVClave = 3

select *
from VARValor VAL
inner join VAVDescripcion VAD on VAD.VARCodigo = VAL.VARCodigo and VAD.VAVClave = VAL.VAVClave 
where VAL.VARCodigo = 'UNIDADV'

insert into ProductoUnidad 
select ProductoClave, '3', 1, 0, GETDATE(), 'Interfaz'
from Producto 
where ProductoClave not in (select ProductoClave from ProductoUnidad where ProductoClave = Producto.ProductoClave and PRUTipoUnidad = '3')

update ProductoUnidad set KgLts = 1 where productoclave = '5600' and PRUTipoUnidad = '3'
update ProductoUnidad set KgLts = 1 where productoclave = '5610' and PRUTipoUnidad = '3'
update ProductoUnidad set KgLts = 1 where productoclave = '5620' and PRUTipoUnidad = '3'
update ProductoUnidad set KgLts = 1 where productoclave = '5630' and PRUTipoUnidad = '3'
update ProductoUnidad set KgLts = 1 where productoclave = '5635' and PRUTipoUnidad = '3'
update ProductoUnidad set KgLts = 1 where productoclave = '5640' and PRUTipoUnidad = '3'
update ProductoUnidad set KgLts = 0.22 where productoclave = '5700' and PRUTipoUnidad = '3'
update ProductoUnidad set KgLts = 0.5 where productoclave = '5710' and PRUTipoUnidad = '3'
update ProductoUnidad set KgLts = 4 where productoclave = '5740' and PRUTipoUnidad = '3'
update ProductoUnidad set KgLts = 1 where productoclave = '5900' and PRUTipoUnidad = '3'
update ProductoUnidad set KgLts = 0.24 where productoclave = '5980' and PRUTipoUnidad = '3'

select *
from ProductoUnidad where PRUTipoUnidad = '3'

--update VARValor set Estado = 0, MUsuarioId = 'Admin', MFechaHora = GETDATE()
--where VARCodigo = 'UNIDADV' and VAVClave = 3
