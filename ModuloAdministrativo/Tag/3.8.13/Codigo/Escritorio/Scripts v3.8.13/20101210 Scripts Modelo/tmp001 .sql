
exec up_ModeloOrienteESEnvase 3, '20101111'

select * from RepModeloOrienteESEnvase
--where IdAgrupador = 4

declare 
@IdCedis as bigint,
@Fecha as datetime,
@IdProducto2 as varchar(10)

--AS

set @IdCedis = 3
set @Fecha = '20101111'
set @IdProducto2 = '30'

declare @FechaIni as datetime

set @FechaIni = cast(year(@Fecha) as varchar(4)) + replicate ('0', 2-len(MONTH(@Fecha))) + cast(month(@Fecha) as varchar(2)) + '01'

--select @FechaIni 

select IdCedis, IdRuta, Fecha, IdAgrupador, Titulo, Concepto, IdProd30, IdProd31, IdProd32, IdProd33, IdProd34, IdProd35, IdProd36, 0 as Orden, 'ACTUAL' as Etiqueta  
from RepModeloOrienteESEnvase
where IdCedis = @IdCedis and Fecha = @Fecha and IdAgrupador > 0

union

select IdCedis as IdCedis, IdRuta as IdRuta, Fecha as Fecha, IdAgrupador as IdAgrupador, Titulo, Concepto, sum(cast(IdProd30 as money)) IdProd30, sum(cast(IdProd31 as money)) IdProd31, 
sum(cast(IdProd32 as money)) IdProd32, sum(cast(IdProd33 as money)) IdProd33, sum(cast(IdProd34 as money)) IdProd34, sum(cast(IdProd35 as money)) IdProd35, sum(cast(IdProd36 as money)) IdProd36, 
1 as Orden, 'ACUMULADO' as Etiqueta  
from RepModeloOrienteESEnvase
where IdCedis = @IdCedis and Fecha between @FechaIni and @Fecha and IdAgrupador > 0
group by IdCedis, IdRuta, Fecha, IdAgrupador, Titulo, Concepto 

order by Orden, IdCedis, Fecha, IdRuta, IdAgrupador 

--select * from RepModeloOrienteESEnvase 
