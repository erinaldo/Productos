
select Usuario.Clave,  
trD.ClienteClave, td.ProductoClave, 
tc.Cantidad  as Consignacion, 
td.Cantidad as Devolucion, 
diaC.FechaCaptura as FechaCons,  
diaD.FechaCaptura as FechaLiq
from TrpTpd tt
inner join TransProd tr on tt.TransProdID1 = tr.TransProdID
inner join Dia diaC on tr.DiaClave = diaC.DiaClave 
inner join TransProd trD on tt.TransProdID = trD.TransProdID
inner join Dia diaD on trd.DiaClave = diaD.DiaClave 
inner join TransProdDetalle tC on tr.TransProdID = tC.TransProdID and tt.TransProdDetalleID = tC.TransProdDetalleID 
inner join TransProdDetalle td on trD.TransProdID = td.TransProdID and tt.TransProdDetalleID = td.TransProdDetalleID 
inner join Usuario on Usuario.USUId = tt.MUsuarioID  
where diaC.FechaCaptura = '20100412' 
and tr.tipo = 24 
order by trD.ClienteClave 


