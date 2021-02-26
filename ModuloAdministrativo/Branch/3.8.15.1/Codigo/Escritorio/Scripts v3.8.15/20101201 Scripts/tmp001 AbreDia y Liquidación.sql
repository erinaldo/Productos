
declare 
@IdCedis as bigint,
@Fecha as datetime,
@IdSurtido as bigint,
@AccionDia as char(1),
@AccionSurtido as char(1)

set @IdCedis = 2
set @Fecha = '20101130'
set @IdSurtido = 3406
set @AccionDia = ''
set @AccionSurtido = ''

if @AccionDia = 'A'
	update StatusDia set Status = 'A' where IdCedis = @IdCedis and Fecha = @Fecha 
	
if @AccionDia = 'C'
	update StatusDia set Status = 'C' where IdCedis = @IdCedis and Fecha = @Fecha 
	
if @AccionSurtido = 'A'
	update Surtidos set Status = 'P' where IdCedis = @IdCedis and IdSurtido = @IdSurtido 
	
if @AccionSurtido = 'C'
	update Surtidos set Status = 'C' where IdCedis = @IdCedis and IdSurtido = @IdSurtido 
