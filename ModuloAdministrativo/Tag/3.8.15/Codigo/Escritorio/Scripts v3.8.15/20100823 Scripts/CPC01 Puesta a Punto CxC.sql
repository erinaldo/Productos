use RouteADM2 

-- Deshabilitar tg Usuarios en ADM
 
/*
delete from Ventas 
delete from VentasDetalle 

delete 
from Movimientos 
delete 
from MovimientosFacturas 

exec GeneraSaldos
*/

update RouteCPC.dbo.Clientes set IdCadena = 3
where IdCliente in (1000, 1200)

insert into RouteCPC.dbo.Configuracion values (3, 'OX1', 'ASC', 'OXXO', 1, 'SFAC', 'SALD')
insert into RouteCPC.dbo.Configuracion values (3, 'OX2', 'ASC', 'OXXO', 2, 'SFAC', 'SALD')

insert into RouteCPC.dbo.FacturacionGlobal values (3, 'OX', 'CADENA COMERCIAL OXXO SA DE CV', 'ASC', 'OXXO')

insert into RouteCPC.dbo.Documentos values ('ASC', 'AJUSTE A SALDO DEL CLIENTE', 'A', 'A')
insert into RouteCPC.dbo.DocumentosTipo values ('ASC', 'F', 'DIFERENCIA FACTURADO VS ENTREGADO', 'A', 'A')
insert into RouteCPC.dbo.DocumentosTipo values ('ASC', 'OXXO', 'SALDAR FACTURAS OXXO', 'A', 'A')

insert into RouteCPC.dbo.Documentos values ('SFAC', 'SALDAR FACTURAS', 'A', 'A')
insert into RouteCPC.dbo.DocumentosTipo values ('SFAC', 'SALD', 'SALDAR FACTURAS', 'A', 'A')

/*
insert into RouteADM.dbo.Canales    
select *
from Canales 

insert into RouteADM.dbo.Cadenas     
select *
from Cadenas  

insert into RouteADM.dbo.GrupoClientes     
select *
from GrupoClientes 

insert into RouteADM.dbo.Marcas   
select *
from Marcas 

insert into RouteADM.dbo.Grupos    
select *
from Grupos 

insert into RouteADM.dbo.Familias    
select *
from Familias 

delete
from RouteADM.dbo.Usuarios 
insert into RouteADM.dbo.Usuarios  
select *
from Usuarios 

delete
from RouteADM.dbo.UsuariosCedis  
insert into RouteADM.dbo.UsuariosCedis  
select *
from UsuariosCedis 

delete
from RouteADM.dbo.UsuariosModulos 
insert into RouteADM.dbo.UsuariosModulos  
select *
from UsuariosModulos 

delete
from RouteADM.dbo.Modulo  
insert into RouteADM.dbo.Modulo  
select *
from Modulo 

delete
from RouteADM.dbo.ModuloGrupo   
insert into RouteADM.dbo.ModuloGrupo  
select *
from ModuloGrupo 

delete
from RouteADM.dbo.GrupoModulos 
insert into RouteADM.dbo.GrupoModulos  
select *
from GrupoModulos 

*/