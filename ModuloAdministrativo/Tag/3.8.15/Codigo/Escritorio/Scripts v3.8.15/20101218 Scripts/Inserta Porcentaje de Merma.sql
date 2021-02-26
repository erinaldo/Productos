
declare 
@IdComEsquema as bigint,
@IdCedis as bigint,
@IdVendedor as bigint

set @IdComEsquema = 1
set @IdCedis = 2
set @IdVendedor = 3471

insert into ComEsquemaVendedor 
select @IdComEsquema, @IdCedis, @IdVendedor, 'MERMA', IdProducto, 0.01, 'A', GETDATE(), 'SUPER'
from Productos 
where Status = 'A'