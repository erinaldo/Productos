
-- borrar saldos en CPC
select *
-- delete 
from RouteCPC.dbo.Ventas  
where Folio < 0

select *
-- delete
from RouteCPC.dbo.VentasDetalle 

-- *******
-- *******  VERIFICAR SI SOLO SON COBRANZAS POR TERMINAL
-- *******
select *
-- delete 
from RouteCPC.dbo.Movimientos 

select *
-- delete
from RouteCPC.dbo.MovimientosFacturas  

--update RouteCPC.dbo.Periodos  set Periodo = 9

-- SALDOS INICIALES Encabezado de Ventas
-- insert into RouteCPC.dbo.Ventas  

select case USU.Clave 
	when 'USER2' then 2
	when 'USER21' then 2
	when 'USER22' then 2
	when 'USER23' then 2
	when 'USER24' then 2
	when 'USER25' then 2
	else 3
	end AS IdCedis, 2 as IdTipoVenta, replace(Route.dbo.FNObtenerSoloNumeros(TRP.Folio),'-','') as Folio, right(USU.Clave,3) as Serie,
TRP.FechaCaptura as Fecha, 1 as IdCliente, TRP.Saldo as Subtotal, 0 as Iva, 0 as Cargos, 0 as Abonos, TRP.DiasCredito, VIS.ClienteClave as IdSucursal, 
1 AS IdMarca, TRP.Folio, '' as Status, 'SIniciales' AS LOGIN, GETDATE()
from Route.dbo.TransProd TRP
inner join Route.dbo.Visita VIS on TRP.VisitaClave = VIS.VisitaClave and TRP.DiaClave = VIS.DiaClave
inner join Route.dbo.Vendedor VEN on VEN.VendedorID = VIS.VendedorID
inner join Route.dbo.Usuario USU on USU.USUId = VEN.USUId
where TRP.Tipo = 1 and TRP.CFVTipo = 2 and Saldo <> 0 and TRP.TipoFase <> 0 and TRP.FechaCaptura < '20100928'
	--and not TRP.Folio like 'S%'
order by TRP.FechaCaptura desc

--select *
--from Rutas 
--order by IdCedis, IdRuta 

use [Route] 
-- ********** Clientes

insert into RouteADM.dbo.ClienteSucursal 
select 2, 1, ClienteClave, '', RazonSocial, '', '', '', '', '', '', '', '', '', '', 
'', RazonSocial, 
'', '', '', '', '', '', '', '', '', '', IdElectronico, 0, case TipoEstado  when 1 then 'A' else 'B' end, NombreContacto, DiasVencimiento, LimiteCreditoDinero 
from Cliente
where ClienteClave in (
select ClienteClave -- distinct rutclave  
from Secuencia 
where cast(right(RUTClave,len(RutClave)-1) as bigint) in (select IdRuta from RouteADM.dbo.Rutas where IdCedis = 2))
and ClienteClave not in (select IdSucursal from RouteADM.dbo.ClienteSucursal )

insert into RouteADM.dbo.ClienteSucursal 
select 3, 1, ClienteClave, '', RazonSocial, '', '', '', '', '', '', '', '', '', '', 
'', RazonSocial, 
'', '', '', '', '', '', '', '', '', '', IdElectronico, 0, case TipoEstado  when 1 then 'A' else 'B' end, NombreContacto, DiasVencimiento, LimiteCreditoDinero 
from Cliente
where ClienteClave in (
select ClienteClave -- distinct rutclave
from Secuencia 
where cast(right(RUTClave,len(RutClave)-1) as bigint) in (select IdRuta from RouteADM.dbo.Rutas where IdCedis = 3))
and ClienteClave not in (select IdSucursal from RouteADM.dbo.ClienteSucursal )

update RouteADM.dbo.ClienteSucursal 
set Calle = CD.Calle, NumExterior=CD.Numero, NumInterior = CD.NumInt, Colonia = CD.Colonia,
Localidad = CD.Localidad, Poblacion = CD.Poblacion, Entidad = CD.Entidad, Pais = CD.Pais,
CalleF = CD.Calle, NumExteriorF =CD.Numero, NumInteriorF = CD.NumInt, ColoniaF = CD.Colonia,
LocalidadF = CD.Localidad, PoblacionF = CD.Poblacion, EntidadF = CD.Entidad, PaisF = CD.Pais
from ClienteDomicilio as CD, Cliente as CTE
where IdSucursal = CTE.ClienteClave and CD.ClienteClave = CTE.ClienteClave -- and CTE.ClienteClave not in (select IdSucursal from RouteADM.dbo.ClienteSucursal )

use RouteADM 

select *
from Route.dbo.Cliente
where ClienteClave not in (
	select IdSucursal 
	from ClienteSucursal )
and TipoEstado = 1
