
-- Primer paso

insert into Ventas2 
select IdCedis, IdTipoVenta, Folio, Serie, Fecha, IdCliente, Subtotal, Iva, Cargos, Abonos, DiasVencimiento, Status, Login, FechaEdicion 
from Ventas 

select *
-- delete 
from Ventas2 

-- Segundo paso

insert into Ventas 
select IdCedis, IdTipoVenta, Folio, Serie, Fecha, IdCliente, Subtotal, Iva, Cargos, Abonos, DiasVencimiento, '', 0, '', Status, Login, FechaEdicion 
from Ventas2 




