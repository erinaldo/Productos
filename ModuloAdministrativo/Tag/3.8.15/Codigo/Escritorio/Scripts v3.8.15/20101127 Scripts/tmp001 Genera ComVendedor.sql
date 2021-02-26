
use RouteADM 

--select *
--from ComEsquemaVendedor 

--select *
--from Vendedores  

declare 
@IdCedis as bigint,
@IdSurtido as bigint,
@IdVendedor as bigint,
@Fecha as datetime,
@IdTipoVendedor as bigint

declare  ActSaldos cursor for
	select distinct SurtidosVendedor.IdCedis, SurtidosVendedor.IdVendedor, Vendedores.IdTipoVendedor 
	from SurtidosVendedor
	inner join Vendedores on Vendedores.IdCedis = SurtidosVendedor.IdCedis and Vendedores.IdVendedor = SurtidosVendedor.IdVendedor 
	where IdSurtido > '3073'

open ActSaldos

fetch next from ActSaldos into @IdCedis, @IdVendedor, @IdTipoVendedor
while (@@fetch_status = 0)
begin

	--select * from ComEsquemaVendedor 

	insert into ComEsquemaVendedor 

	select 1, @IdCedis, @IdVendedor, 'MERMA', IdProducto, case @IdTipoVendedor when 2 then .015 else .010 end, 'A', GETDATE(), 'SUPER'
	from Productos 
	where Status = 'A'

	if @IdVendedor in (82, 121)
	begin
		insert into ComEsquemaVendedor 
		
		select 1, @IdCedis, @IdVendedor, 'VOLUMEN', IdProducto, .010, 'A', GETDATE(), 'SUPER'
		from Productos 
		where Status = 'A'
	end
	
	fetch next from ActSaldos into @IdCedis, @IdVendedor, @IdTipoVendedor
end
close ActSaldos
deallocate ActSaldos		


update GReportesNivel set CampoFinalXLS = 9
where IdReporte = 3

update GReportesNivel set CampoFinalXLS = 21
where IdReporte = 30
