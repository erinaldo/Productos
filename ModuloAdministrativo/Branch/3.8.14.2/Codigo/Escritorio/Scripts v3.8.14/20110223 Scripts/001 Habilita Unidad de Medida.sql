
use Route 

update VARValor set Estado = 1
where VARCodigo = 'UNIDADV' and VAVClave = 2

select *
from VARValor 
inner join VAVDescripcion on VAVDescripcion.VARCodigo = VARValor.VARCodigo and VAVDescripcion.VAVClave = VARValor.VAVClave 
where Varvalor.VARCodigo like 'UNIDADV'

