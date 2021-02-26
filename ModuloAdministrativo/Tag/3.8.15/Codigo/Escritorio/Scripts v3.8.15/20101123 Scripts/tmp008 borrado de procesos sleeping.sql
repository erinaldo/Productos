

USE ctpjnsa 
GO
DECLARE @spid VARCHAR(16)
DECLARE @KILL VARCHAR(16)
DECLARE kill_cursor CURSOR FOR

	select spid
	from MASTER..sysprocesses
	where status = 'sleeping' and loginame <> 'sa'

OPEN kill_cursor
FETCH NEXT FROM kill_cursor INTO @spid
WHILE @@FETCH_STATUS = 0
BEGIN
	
	select ' kill ' + @spid 
	FETCH NEXT FROM kill_cursor INTO @spid
END
close kill_cursor
deallocate kill_cursor
 
 