USE [Route]
GO
/****** Object:  Trigger [dbo].[tgRouteU_ClienteSucursal]    Script Date: 10/05/2010 12:55:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


ALTER TRIGGER [dbo].[tgRouteU_Cliente] ON [dbo].[Cliente] 
FOR INSERT, UPDATE
AS

insert into RouteADM.dbo.ClienteSucursal 
select 2, 1, ClienteClave, '', Clave + ' - ' + NombreContacto, '', '', '', '', '', '', '', '', '', '', 
'', RazonSocial, 
'', '', '', '', '', '', '', '', '', '', IdElectronico, 0, case TipoEstado  when 1 then 'A' else 'B' end, NombreContacto, DiasVencimiento, LimiteCreditoDinero 
from Cliente
where ClienteClave in ( 
	select Secuencia.ClienteClave 
	from Secuencia 
	inner join Inserted INS on INS.ClienteClave = Secuencia.ClienteClave
	where cast(right(RUTClave,len(RutClave)-1) as bigint) in (select IdRuta from RouteADM.dbo.Rutas where IdCedis = 2))
and ClienteClave not in (select IdSucursal from RouteADM.dbo.ClienteSucursal )

insert into RouteADM.dbo.ClienteSucursal 
select 3, 1, ClienteClave, '', Clave + ' - ' + NombreContacto, '', '', '', '', '', '', '', '', '', '', 
'', RazonSocial, 
'', '', '', '', '', '', '', '', '', '', IdElectronico, 0, case TipoEstado  when 1 then 'A' else 'B' end, NombreContacto, DiasVencimiento, LimiteCreditoDinero 
from Cliente
where ClienteClave in (
	select Secuencia.ClienteClave 
	from Secuencia 
	inner join Inserted INS on INS.ClienteClave = Secuencia.ClienteClave
	where cast(right(RUTClave,len(RutClave)-1) as bigint) in (select IdRuta from RouteADM.dbo.Rutas where IdCedis = 3))
and ClienteClave not in (select IdSucursal from RouteADM.dbo.ClienteSucursal )

update RouteADM.dbo.ClienteSucursal 
set NombreSucursal = CTE.Clave + ' - ' + NombreContacto, CodigoBarras = CTE.IdElectronico, 
DiasCredito = DiasVencimiento, LimiteCredito = LimiteCreditoDinero,
Status = case CTE.TipoEstado when '1' then 'A' else 'B' end, 
Calle = CD.Calle, NumExterior=CD.Numero, NumInterior = CD.NumInt, Colonia = CD.Colonia,
Localidad = CD.Localidad, Poblacion = CD.Poblacion, Entidad = CD.Entidad, Pais = CD.Pais,
CalleF = CD.Calle, NumExteriorF =CD.Numero, NumInteriorF = CD.NumInt, ColoniaF = CD.Colonia,
LocalidadF = CD.Localidad, PoblacionF = CD.Poblacion, EntidadF = CD.Entidad, PaisF = CD.Pais
from ClienteDomicilio as CD, Cliente as CTE
where IdSucursal = CTE.ClienteClave and CD.ClienteClave = CTE.ClienteClave 
	and CTE.ClienteClave in (select ClienteClave from Inserted )
	
