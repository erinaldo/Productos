
	declare @RutClave as varchar(20), @ClienteClave as varchar(20), @Orden as bigint, @FrecuenciaClave as varchar(20)
	declare @RutClaveAnt as varchar(20), @ClienteClaveAnt as varchar(20), @OrdenAnt as bigint, @FrecuenciaClaveAnt as varchar(20)
	declare @Nuevo as bigint

--select *
---- delete
--from Secuencia
--where RutClave is null

	declare  CursorSecuencias cursor for
		select top 1000 RutClave, FrecuenciaClave, Orden, ClienteClave
		from Secuencia
		where RutClave is not null
		order by RutClave, FrecuenciaClave, Orden, ClienteClave
	open CursorSecuencias
	
--	set @RutClaveAnt = ''
--	set @ClienteClaveAnt  = ''
--	set @OrdenAnt  = ''
	set @FrecuenciaClaveAnt = ''
	set @Nuevo = 0

	fetch next from CursorSecuencias into @RutClave, @FrecuenciaClave, @Orden, @ClienteClave
	while (@@fetch_status = 0)
	begin

		print 'update secuencia set Orden = ' + cast( @Nuevo as varchar(10)) + ' 
		where RutClave = ' + @RutClave  + ' and FrecuenciaClave = ' + @FrecuenciaClave  + ' and Orden = ' + cast( @Orden as varchar(10)) + ' and ClienteClave = ' + @ClienteClave 
		
		if @FrecuenciaClaveAnt <> @FrecuenciaClave 
		begin
			set @Nuevo = 0
			set @FrecuenciaClaveAnt = @FrecuenciaClave
		end
		set @Nuevo = @Nuevo + 1

		fetch next from CursorSecuencias into @RutClave, @FrecuenciaClave, @Orden, @ClienteClave
	end
	close CursorSecuencias
	deallocate CursorSecuencias		
