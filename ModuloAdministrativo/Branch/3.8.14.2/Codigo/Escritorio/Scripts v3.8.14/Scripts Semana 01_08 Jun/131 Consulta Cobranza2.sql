--Cobranza (solo para facturas de ventas a credito)
declare  @fecha as datetime
set @fecha='2010-05-29T00:00:00' --Formato yyyy-mm-dd
declare  @Usuario as varchar(20)
set @Usuario='10004'
--se
--select * from TransProd where DiaClave = '31/05/2010' and MUsuarioID = '10001' and tipo = '1'

select Clave, sum(Total) as Total
from (
select distinct USU.Clave, ABN.ABNId, ABN.Total
from AbnTrp ABT
inner join TransProd FAC on ABT.TransProdID = FAC.TransProdID 
left join TransProd TRP on FAC.TransProdID = TRP.FacturaID 
inner join Abono ABN on ABT.ABNId = ABN.ABNId 
inner join Dia on ABN.DiaClave = Dia.DiaClave
inner join Visita VIS on ABN.VisitaClave = VIS.VisitaClave
inner join Vendedor VEN on VEN.VendedorID = VIS.VendedorID
inner join Usuario USU on USU.USUId = VEN.USUId
where Dia.FechaCaptura=@fecha and USU.Clave=@Usuario 
and FAC.Tipo = 8 and FAC.TipoFase <> 0 and (TRP.CFVTipo = 2 or TRP.CFVTipo is null)
)as t
group by t.Clave 