

update Ventas set IdCliente = CS.IdCliente 
from Ventas VT, ClienteSucursal CS
where VT.IdSucursal = CS.IdSucursal 
and VT.IdCliente <> CS.IdCliente 

