
declare 
@IdCedis as bigint,
@Fecha as datetime


DECLARE @CursorMOV CURSOR
SET @CursorMOV = CURSOR SCROLL DYNAMIC FOR 
	
	select Cedis.IdCedis, Fecha 
	from Cedis 
	inner join StatusDia on StatusDia.IdCedis = Cedis.IdCedis and StatusDia.Status = 'C'
	order by Fecha, Cedis.IdCedis 
	
OPEN @CursorMOV
FETCH NEXT FROM @CursorMOV INTO @idcedis, @fecha
WHILE @@FETCH_STATUS = 0      
BEGIN  

	exec up_ModeloOrienteES @IdCedis, @Fecha

	FETCH NEXT FROM @CursorMOV INTO @idcedis, @fecha

END                                                                
CLOSE @CursorMOV  
DEALLOCATE @CursorMOV

