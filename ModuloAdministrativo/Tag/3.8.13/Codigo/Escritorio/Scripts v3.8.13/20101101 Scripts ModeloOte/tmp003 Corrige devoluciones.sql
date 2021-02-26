--Folio 200000006
--Folio 200000007

declare @FolioRoute varchar(16)
declare @IdCedis bigint
declare @IdDevolucion bigint

set @FolioRoute = '200000007'
set @IdCedis = 2
set @IdDevolucion = 7

declare @IdSurtido bigint
select @IdSurtido = IdSurtido from RouteADM.dbo.Devolucion where IdCedis = @IdCedis and IdDevolucion = @IdDevolucion

declare @DiaClave varchar(10)
declare @FechaCaptura datetime
select @DiaClave = DiaClave, @FechaCaptura = FechaCaptura from Dia where FechaCaptura = (select Fecha from RouteADM.dbo.Surtidos where IdSurtido = 933 and IdCedis = 2)

declare @VisitaClave varchar(16)
declare @DiaClaveVis varchar(10)

select @VisitaClave = VisitaClave, @DiaClaveVis = DiaClave from TransProd where Folio = @FolioRoute 
update TransProd set VisitaClave = null, DiaClave = null where Folio = @FolioRoute  
update Visita set DiaClave = @DiaClave where VisitaClave = @VisitaClave and DiaClave = @DiaClaveVis 
update TransProd set VisitaClave = @VisitaClave, DiaClave = @DiaClave, FechaHoraAlta = @FechaCaptura, FechaCaptura = @FechaCaptura where Folio = @FolioRoute   

--select @DiaClave 
