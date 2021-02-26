USE [RouteADM]
GO

/****** Object:  Trigger [tgg_SurtidosCargas]    Script Date: 02/23/2011 11:18:51 ******/
IF  EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[dbo].[tgg_SurtidosCargas]'))
DROP TRIGGER [dbo].[tgg_SurtidosCargas]
GO

USE [RouteADM]
GO

/****** Object:  Trigger [dbo].[tgg_SurtidosCargas]    Script Date: 02/23/2011 11:18:51 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO






CREATE TRIGGER [dbo].[tgg_SurtidosCargas] ON [dbo].[SurtidosCargas] 
FOR INSERT, UPDATE, DELETE 
AS

declare @IdCedis as bigint, @IdSurtido as bigint, @Fecha as datetime, @IdProducto as bigint, @Cantidad as float, @Route as int, @IdCarga as bigint
declare @Decimales as int

set @Route = isnull( ( select Route from Configuracion where IdCedis in ( select IdCedis from Inserted ) ), 0 )
set @IdCedis = 0

declare @IdRuta as bigint, @Valor as varchar(100) 

if exists ( select IdCedis from Inserted )
begin	
	declare  InsUpCarga cursor for
		select IdCedis, IdSurtido, IdProducto  from Inserted
	open InsUpCarga
	
	fetch next from InsUpCarga into @IdCedis, @IdSurtido, @IdProducto 
	while (@@fetch_status = 0)
	begin
		set @Cantidad = isnull( ( select sum( Cantidad ) from SurtidosCargas where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdProducto = @IdProducto ) , 0 )
		set @Fecha = isnull( ( select Fecha from Surtidos where IdCedis = @IdCedis and IdSurtido = @IdSurtido ) , '01/01/1900' )
		exec dbo.up_SurtidosDetalle @IdCedis, @IdSurtido, @IdProducto, @Fecha, @Cantidad, 0, 0, 0, 0, 0, 1

		fetch next from InsUpCarga into @IdCedis, @IdSurtido, @IdProducto 
	end
	close InsUpCarga
	deallocate InsUpCarga		

	--if exists(select count(IdCarga) from Inserted having count(IdCarga)=1)
	--begin
		select top 1 @IdRuta = Surtidos.IdRuta 
		from Inserted 
		inner join Surtidos on Surtidos.IdCedis = Inserted.IdCedis and Surtidos.IdSurtido = Inserted.IdSurtido 

		select @Valor = Nombre_Dispositivo
		from Route.dbo.Terminal Terminal
		inner join Route.dbo.TerminalSerial TerminalSerial on Terminal.NumeroSerie = DispositivoID and TerminalSerial.Nombre_Dispositivo like '%PPT8800%'
		where TerminalClave = cast(@IdCedis as varchar(10)) + replicate('0', 4-len(@IdRuta)) + cast(@IdRuta as varchar(10))
	--end

	if @Route = 1 and @Valor is not null and @Valor <> ''
	begin

		declare  InsUpCarga cursor for
			select IdCedis, IdSurtido, IdCarga, IdProducto, Cantidad from Inserted order by IdCedis, IdSurtido, IdCarga, IdProducto 
		open InsUpCarga
		
		fetch next from InsUpCarga into @IdCedis, @IdSurtido, @IdCarga, @IdProducto, @Cantidad 
		while (@@fetch_status = 0)
		begin
			
			set @Decimales = (select Decimales from Productos where IdProducto = @IdProducto )

			insert into Route.dbo.tmp_CargaDetalle
			select FolioRoute, @IdProducto, @IdProducto, case @Decimales when 0 then 1 else 2 end, @IdProducto, @Cantidad 
			from RouteSurtidos
			where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdCarga = @IdCarga 
				and @IdProducto not in ( select IdProducto 
					from Productos where IdFamilia in ( select IdFamiliaRejas
						from Configuracion where IdCedis = @IdCedis))
			
			fetch next from InsUpCarga into @IdCedis, @IdSurtido, @IdCarga, @IdProducto, @Cantidad  
		end
		close InsUpCarga
		deallocate InsUpCarga		
	end
end
else
begin
	declare  DelCarga cursor for
		select IdCedis, IdSurtido, IdProducto  from Deleted
	open DelCarga
	
	fetch next from DelCarga into @IdCedis, @IdSurtido, @IdProducto 
	while (@@fetch_status = 0)
	begin
		set @Cantidad = isnull( ( select sum( Cantidad ) from SurtidosCargas where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdProducto = @IdProducto ) , 0 )
		set @Fecha = isnull( ( select Fecha from Surtidos where IdCedis = @IdCedis and IdSurtido = @IdSurtido ) , '01/01/1900' )
		exec dbo.up_SurtidosDetalle @IdCedis, @IdSurtido, @IdProducto, @Fecha, @Cantidad, 0, 0, 0, 0, 0, 1

		fetch next from DelCarga into @IdCedis, @IdSurtido, @IdProducto 
	end
	close DelCarga
	deallocate DelCarga		

	--if exists(select count(IdCarga) from Deleted having count(IdCarga)=1)
	--begin
		select top 1 @IdRuta = Surtidos.IdRuta 
		from Deleted 
		inner join Surtidos on Surtidos.IdCedis = Deleted.IdCedis and Surtidos.IdSurtido = Deleted.IdSurtido 
		
		select @Valor = Nombre_Dispositivo
		from Route.dbo.Terminal Terminal
		inner join Route.dbo.TerminalSerial TerminalSerial on Terminal.NumeroSerie = DispositivoID and TerminalSerial.Nombre_Dispositivo like '%PPT8800%'
		where TerminalClave = cast(@IdCedis as varchar(10)) + replicate('0', 4-len(@IdRuta)) + cast(@IdRuta as varchar(10))
	--end

	if @Route = 1 and @Valor is not null and @Valor <> ''
	begin
	
		declare  DelCarga cursor for
			select IdCedis, IdSurtido, IdCarga, IdProducto, Cantidad from Deleted order by IdCedis, IdSurtido, IdCarga, IdProducto 
		open DelCarga
		
		fetch next from DelCarga into @IdCedis, @IdSurtido, @IdCarga, @IdProducto, @Cantidad 
		while (@@fetch_status = 0)
		begin
			
			set @Decimales = (select Decimales from Productos where IdProducto = @IdProducto )
			
			insert into Route.dbo.tmp_CargaDetalle
			select FolioRoute, @IdProducto, @IdProducto, case @Decimales when 0 then 1 else 2 end, @IdProducto, @Cantidad 
			from RouteSurtidos
			where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdCarga = @IdCarga 
				and @IdProducto not in ( select IdProducto 
					from Productos where IdFamilia in ( select IdFamiliaRejas
						from Configuracion where IdCedis = @IdCedis))
			
			fetch next from DelCarga into @IdCedis, @IdSurtido, @IdCarga, @IdProducto, @Cantidad  
		end
		close DelCarga
		deallocate DelCarga		
	end

end




GO


