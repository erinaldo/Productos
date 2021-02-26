USE [RouteADM]
GO

/****** Object:  Trigger [tgg_SurtidosCargas]    Script Date: 12/27/2010 16:04:25 ******/
IF  EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[dbo].[tgg_SurtidosCargas]'))
DROP TRIGGER [dbo].[tgg_SurtidosCargas]
GO

USE [RouteADM]
GO

/****** Object:  Trigger [dbo].[tgg_SurtidosCargas]    Script Date: 12/27/2010 16:04:25 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




CREATE TRIGGER [dbo].[tgg_SurtidosCargas] ON [dbo].[SurtidosCargas] 
FOR INSERT, UPDATE, DELETE 
AS

declare @IdCedis as bigint, @IdSurtido as bigint, @Fecha as datetime, @IdProducto as bigint, @Cantidad as float, @Route as int, @IdCarga as bigint

set @Route = isnull( ( select Route from Configuracion where IdCedis in ( select IdCedis from Inserted ) ), 0 )
set @IdCedis = 0

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

	--if @Route = 1
	--begin
	--	declare  InsUpCarga cursor for
	--		select IdCedis, IdSurtido, IdCarga, IdProducto, Cantidad from Inserted order by IdCedis, IdSurtido, IdCarga, IdProducto 
	--	open InsUpCarga
		
	--	fetch next from InsUpCarga into @IdCedis, @IdSurtido, @IdCarga, @IdProducto, @Cantidad 
	--	while (@@fetch_status = 0)
	--	begin
			
	--		insert into Route.dbo.tmp_CargaDetalle
	--		select FolioRoute, @IdProducto, @IdProducto, 1, @IdProducto, @Cantidad 
	--		from RouteSurtidos
	--		where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdCarga = @IdCarga 
	--			and @IdProducto not in ( select IdProducto 
	--				from Productos where IdFamilia in ( select IdFamiliaRejas
	--					from Configuracion where IdCedis = @IdCedis))
			
	--		fetch next from InsUpCarga into @IdCedis, @IdSurtido, @IdCarga, @IdProducto, @Cantidad  
	--	end
	--	close InsUpCarga
	--	deallocate InsUpCarga		
	--end
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

	--if @Route = 1
	--begin
	--	declare  DelCarga cursor for
	--		select IdCedis, IdSurtido, IdCarga, IdProducto, Cantidad from Deleted order by IdCedis, IdSurtido, IdCarga, IdProducto 
	--	open DelCarga
		
	--	fetch next from DelCarga into @IdCedis, @IdSurtido, @IdCarga, @IdProducto, @Cantidad 
	--	while (@@fetch_status = 0)
	--	begin
			
	--		insert into Route.dbo.tmp_CargaDetalle
	--		select FolioRoute, @IdProducto, @IdProducto, 1, @IdProducto, @Cantidad 
	--		from RouteSurtidos
	--		where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdCarga = @IdCarga 
	--			and @IdProducto not in ( select IdProducto 
	--				from Productos where IdFamilia in ( select IdFamiliaRejas
	--					from Configuracion where IdCedis = @IdCedis))
			
	--		fetch next from DelCarga into @IdCedis, @IdSurtido, @IdCarga, @IdProducto, @Cantidad  
	--	end
	--	close DelCarga
	--	deallocate DelCarga		
	--end

end


GO


