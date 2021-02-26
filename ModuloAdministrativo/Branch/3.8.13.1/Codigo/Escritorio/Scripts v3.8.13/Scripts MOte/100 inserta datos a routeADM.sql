
--*********** productos

select * 
-- delete
from RouteADM.dbo.Productos 

-- insert into RouteADM.dbo.Productos 
select CAST(productoclave as Int), CodigoBarras, Nombre, 0, 0, 1, 1, 1, 0, 0, GETDATE(), 'A', 0
from Producto 


--*********** Rutas

-- Rutas de Huamantla
-- insert into RouteADM.dbo.rutas 
select 3, cast(RIGHT(rutclave,2) as int), Descripcion, 1, 'Venta', GETDATE(), 'A'
from Ruta 
where RUTClave not in ('R02', 'RUT001') and cast(RIGHT(rutclave,2) as int) not between 20 and 29

-- Rutas de Libres
-- insert into RouteADM.dbo.rutas 
select 2, cast(RIGHT(rutclave,2) as int), Descripcion, 1, 'Venta', GETDATE(), 'A'
from Ruta 
where RUTClave in ('R02') or cast(RIGHT(rutclave,2) as int) between 20 and 29


-- ********** Inventario Inicial y día de trabajo

-- insert into ROUTEADM.DBO.inventariokardex
select 3, '20100413', idproducto, 12000, 0, 0, 0, 0, 0, 0, 0, 0, 0
from RouteADM.dbo.Productos  

-- insert into ROUTEADM.DBO.inventariokardex
select 2, '20100413', idproducto, 12000, 0, 0, 0, 0, 0, 0, 0, 0, 0
from RouteADM.dbo.Productos  

-- insert into ROUTEADM.DBO.StatusDia values (3, '20100413', 'A', 'Abierto para Captura')
-- insert into ROUTEADM.DBO.StatusDia values (2, '20100413', 'A', 'Abierto para Captura')

-- insert into ROUTEADM.DBO.TipoMerma values (3, 'DEVOLUCION', 1, GETDATE(), 'A')
-- insert into ROUTEADM.DBO.TipoMerma values (2, 'DEVOLUCION', 1, GETDATE(), 'A')


-- ********** Vendedores

delete
from TipoVendedor 
where IdTipoVendedor > 2

-- insert into RouteADM.dbo.Vendedores 
select 2, SUBSTRING(nombre,7,2), Nombre, '', '', SUBSTRING(nombre,7,2), 1, GETDATE(), 'A', 'USER' + SUBSTRING(nombre,7,2)
from Vendedor 
where SUBSTRING(nombre,7,2) in ('21', '22', '23', '24', '25') 

-- insert into RouteADM.dbo.Vendedores 
select 3, SUBSTRING(nombre,7,2), Nombre, '', '', SUBSTRING(nombre,7,2), 1, GETDATE(), 'A', 'USER' + SUBSTRING(nombre,7,2)
from Vendedor 
where SUBSTRING(nombre,7,2) in ('11', '12', '31', '32', '33', '34', '35', '36', '37', '38') 


-- ********** Precios

-- insert into RouteADM.dbo.PreciosLista 
select PrecioClave, Nombre, 'BA', GETDATE(), 'A'
from Precio 
where PrecioClave in ('1', '2')

-- insert into RouteADM.dbo.PreciosLista 
select PrecioClave, Nombre, 'CL', GETDATE(), 'A'
from Precio 
where PrecioClave in ('3', '4')

-- insert into RouteADM.dbo.PreciosListaCedis 
select PrecioClave, 2
from Precio and precioclave <> '1'

-- insert into RouteADM.dbo.PreciosListaCedis 
select PrecioClave, 3
from Precio and precioclave <> '2'

-- insert into RouteADM.dbo.PreciosDetalle 
select PrecioClave, CAST(productoclave as Int), Precio 
from PrecioProductoVig 
where FechaFin = '9999-12-31T00:00:00'


-- ********** Clientes

-- delete from RouteADM.dbo.ClienteSucursal
-- insert into RouteADM.dbo.ClienteSucursal 
select 2, 1, ClienteClave, '', RazonSocial, '', '', '', '', '', '', '', '', '', '', 
'', RazonSocial, 
'', '', '', '', '', '', '', '', '', '', IdElectronico, 0, case TipoEstado  when 1 then 'A' else 'B' end, NombreContacto 
from Cliente
where ClienteClave in (
select ClienteClave -- distinct rutclave  
from Secuencia 
where cast(RIGHT(rutclave,2) as int) between 20 and 26  or RUTClave ='R02')

-- insert into RouteADM.dbo.ClienteSucursal 
select 3, 1, ClienteClave, '', RazonSocial, '', '', '', '', '', '', '', '', '', '', 
'', RazonSocial, 
'', '', '', '', '', '', '', '', '', '', IdElectronico, 0, case TipoEstado  when 1 then 'A' else 'B' end, NombreContacto  
from Cliente
where ClienteClave in (
select ClienteClave -- distinct rutclave
from Secuencia 
where cast(RIGHT(rutclave,2) as int) between 10 and 15 or cast(RIGHT(rutclave,2) as int) between 30 and 40  or RUTClave = 'R03')

update RouteADM.dbo.ClienteSucursal 
set Calle = CD.Calle, NumExterior=CD.Numero, NumInterior = CD.NumInt, Colonia = CD.Colonia,
Localidad = CD.Localidad, Poblacion = CD.Poblacion, Entidad = CD.Entidad, Pais = CD.Pais,
CalleF = CD.Calle, NumExteriorF =CD.Numero, NumInteriorF = CD.NumInt, ColoniaF = CD.Colonia,
LocalidadF = CD.Localidad, PoblacionF = CD.Poblacion, EntidadF = CD.Entidad, PaisF = CD.Pais
from ClienteDomicilio as CD, Cliente as CTE
where IdSucursal = CTE.ClienteClave and CD.ClienteClave = CTE.ClienteClave  


--************ Movs Almacén

insert into RouteADM.dbo.TipoMovimiento  values (3, 1, 'Entrada de Cerveceria ', 'E')
insert into RouteADM.dbo.TipoMovimiento  values (3, 2, 'Entrada por Traspaso', 'E')
insert into RouteADM.dbo.TipoMovimiento  values (3, 3, 'Salida por Traspaso', 'S')
insert into RouteADM.dbo.TipoMovimiento  values (3, 4, 'Salida de Envase a Cerveceria', 'S')
insert into RouteADM.dbo.TipoMovimiento  values (3, 5, 'Entrada por Traspaso de envase ', 'E')
insert into RouteADM.dbo.TipoMovimiento  values (3, 6, 'Salida por Traspaso de envase ', 'S')
insert into RouteADM.dbo.TipoMovimiento  values (3, 7, 'Salida de canje', 'S')
insert into RouteADM.dbo.TipoMovimiento  values (3, 8, 'Entrada de canje', 'E')
insert into RouteADM.dbo.TipoMovimiento  values (3, 9, 'Mov. Salidas mobiliario', 'S')
insert into RouteADM.dbo.TipoMovimiento  values (3, 10, 'Mov. Entradas  mobiliario', 'E')

insert into RouteADM.dbo.TipoMovimiento  values (2, 1, 'Entrada de Cerveceria ', 'E')
insert into RouteADM.dbo.TipoMovimiento  values (2, 2, 'Entrada por Traspaso', 'E')
insert into RouteADM.dbo.TipoMovimiento  values (2, 3, 'Salida por Traspaso', 'S')
insert into RouteADM.dbo.TipoMovimiento  values (2, 4, 'Salida de Envase a Cerveceria', 'S')
insert into RouteADM.dbo.TipoMovimiento  values (2, 5, 'Entrada por Traspaso de envase ', 'E')
insert into RouteADM.dbo.TipoMovimiento  values (2, 6, 'Salida por Traspaso de envase ', 'S')
insert into RouteADM.dbo.TipoMovimiento  values (2, 7, 'Salida de canje', 'S')
insert into RouteADM.dbo.TipoMovimiento  values (2, 8, 'Entrada de canje', 'E')
insert into RouteADM.dbo.TipoMovimiento  values (2, 9, 'Mov. Salidas mobiliario', 'S')
insert into RouteADM.dbo.TipoMovimiento  values (2, 10, 'Mov. Entradas  mobiliario', 'E')

insert into RouteADM.dbo.MovimientosFamilias 
select IdCedis, IdTipoMovimiento, 1 
from RouteADM.dbo.TipoMovimiento 





