



USE ctPJNSA 
GO
DECLARE @Tabla VARCHAR(50)
DECLARE ListaDeTablas CURSOR FOR

	select name from sysobjects where xtype = 'U'

OPEN ListaDeTablas
FETCH NEXT FROM ListaDeTablas INTO @Tabla
WHILE @@FETCH_STATUS = 0
BEGIN
	
	DBCC DBREINDEX (@Tabla  )
	FETCH NEXT FROM ListaDeTablas INTO @Tabla
END
close ListaDeTablas
deallocate ListaDeTablas
 
 


