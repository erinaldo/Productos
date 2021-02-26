
--alter table enc alter column fecha varchar(255)
--alter table acr alter column fecha varchar(255)
--alter table acr alter column fechaacred varchar(255)

update Ventas set Fecha = Enc.fecha
from Enc, Ventas 
where Enc.idcedis = Ventas.IdCedis and Enc.idtipovent = Ventas.IdTipoVenta 
	and Enc.serie = Ventas.Serie and Enc.FolioN = Ventas.Folio 

update VentasAcredita set Fecha = Acr.fechaacred, FechaAcredita = Acr.fechaacred, FechaEntrega = Acr.fechaacred   
from Acr, VentasAcredita  
where Acr.idcedis = VentasAcredita.IdCedis and Acr.idtipovent = VentasAcredita.IdTipoVenta 
	and Acr.serie = VentasAcredita.Serie and Acr.FolioN = VentasAcredita.Folio 

