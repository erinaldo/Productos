
-- update VentasDetalle set Cantidad = 4 where IdSurtido = 1 and Folio = 40
-- update Ventas set subtotal = 101 where IdSurtido = 1 and Folio = 40

-- update SurtidosDetalle set DevBuena = 71 where IdSurtido = 1 and IdCedis = 1
-- exec up_ActualizaKardex 1, '20100528', 1, 1

--insert into GReportesNaturaleza values (27, 'Efectivo y Documentos', 'S')
--insert into GReportesNivel values (27, 1, 'Por Fecha', 10, 0, 0, 'Surtidos.Fecha', 'S', 'S', 'S', 'Fecha', 11, 0, 8) 

select *
from SurtidosDetalle 
where IdCedis = 1 and IdSurtido = 1

-- update SurtidosDetalle set DevBuena = Surtido - VentaContado - VentaCredito - Obsequios - DevMala where IdCedis = 1 and IdSurtido = 1

select * 
from GReportesNaturaleza 

select * 
from GReportesNivel 