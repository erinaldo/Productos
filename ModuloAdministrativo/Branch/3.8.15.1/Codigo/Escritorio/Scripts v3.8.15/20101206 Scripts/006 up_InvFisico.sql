USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[up_InvFisico]    Script Date: 12/07/2010 15:50:41 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[up_InvFisico]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[up_InvFisico]
GO

USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[up_InvFisico]    Script Date: 12/07/2010 15:50:41 ******/
SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER OFF
GO




CREATE PROCEDURE [dbo].[up_InvFisico]
@IdCedis as bigint,
@Fecha as datetime,
@IdProducto as bigint,
@Cantidad as float,
@DevBuena as float,
@Opc as int
AS

declare @exist as bigint

if @Opc = 1
begin
	if @IdProducto>0
	begin

		set @exist = isnull((Select IdProducto from InventarioFisico where  IdProducto = @IdProducto  and IdCedis = @IdCedis and Fecha = @Fecha),0)

		if @DevBuena > 0 
			select @DevBuena = sum(Cantidad)
			from (select Rutas.IdCedis, Rutas.IdRuta, (
				select top 1 IdSurtido 
				from Surtidos 
				where Surtidos.IdCedis = @IdCedis and Surtidos.Fecha = @Fecha and Surtidos.IdRuta = Rutas.IdRuta 
				order by IdSurtido desc ) as IdSurtido
			from Rutas 
			where Rutas.IdCedis = @IdCedis ) as SurtidosR, Surtidos, SurtidosDevolucion 
			where Surtidos.IdCedis = SurtidosR.IdCedis and Surtidos.IdSurtido = SurtidosR.IdSurtido and Surtidos.Fecha = @Fecha
				and Surtidos.IdCedis = SurtidosDevolucion.IdCedis and Surtidos.IdSurtido = SurtidosDevolucion.IdSurtido
				and SurtidosDevolucion.IdTipoDevolucion in (select IdTipoDevolucion from TipoDevolucion where EnRuta = 1)
				and SurtidosDevolucion.IdProducto = @IdProducto 
			group by SurtidosDevolucion.IdProducto 
		
		if @exist=0 
			insert into InventarioFisico values (@IdCedis, @Fecha, @IdProducto, @Cantidad + @DevBuena, 'P', 'N', @Cantidad, @DevBuena)
		else
			update InventarioFisico set Cantidad = @Cantidad + @DevBuena, Status = 'P', Captura = @Cantidad, DevBuena = @DevBuena 
			where IdProducto = @IdProducto  and IdCedis = @IdCedis and Fecha = @Fecha

		-- Actualiza Kardex
		update InventarioKardex set InventarioKardex.Fisico = isnull( (select InventarioFisico.Cantidad 
		from InventarioFisico where InventarioFisico.IdCedis = @IdCedis and InventarioFisico.Fecha = @Fecha and InventarioFisico.IdProducto = InventarioKardex.IdProducto), 0 )
		where InventarioKardex.IdCedis =@IdCedis and InventarioKardex.Fecha = @Fecha and InventarioKardex.IdProducto = @IdProducto

	end

	if @IdProducto=0
	begin
		-- Actualiza Kardex
		update InventarioKardex set InventarioKardex.Fisico = isnull( (select InventarioFisico.Cantidad 
		from InventarioFisico where InventarioFisico.IdCedis = @IdCedis and InventarioFisico.Fecha = @Fecha and InventarioFisico.IdProducto = InventarioKardex.IdProducto), 0 )
		where InventarioKardex.IdCedis =@IdCedis and InventarioKardex.Fecha = @Fecha
		
		-- Actualiza el estatus del documento
		update InventarioFisico set Status = 'A' where IdCedis = @IdCedis and Fecha = @Fecha
	end

	if @IdProducto=-1
	begin
		update InventarioKardex set InventarioKardex.Fisico = 0
		where InventarioKardex.IdCedis =@IdCedis and InventarioKardex.Fecha = @Fecha

		delete from InventarioFisico where IdCedis = @IdCedis and Fecha = @Fecha
	end
end

if @Opc = 2
begin
	declare  ActInvFis cursor for
		select  SurtidosDevolucion.IdProducto, sum(Cantidad)
		from (select Rutas.IdCedis, Rutas.IdRuta, (
			select top 1 IdSurtido 
			from Surtidos 
			where Surtidos.IdCedis = @IdCedis and Surtidos.Fecha = @Fecha and Surtidos.IdRuta = Rutas.IdRuta 
			order by IdSurtido desc ) as IdSurtido
		from Rutas 
		where Rutas.IdCedis = @IdCedis ) as SurtidosR, Surtidos, SurtidosDevolucion 
		where Surtidos.IdCedis = SurtidosR.IdCedis and Surtidos.IdSurtido = SurtidosR.IdSurtido and Surtidos.Fecha = @Fecha
			and Surtidos.IdCedis = SurtidosDevolucion.IdCedis and Surtidos.IdSurtido = SurtidosDevolucion.IdSurtido
			and SurtidosDevolucion.IdTipoDevolucion in (select IdTipoDevolucion from TipoDevolucion where EnRuta = 1)
		group by SurtidosDevolucion.IdProducto 
		order by SurtidosDevolucion.IdProducto 
	open ActInvFis

	fetch next from ActInvFis into @IdProducto, @DevBuena
	while (@@fetch_status = 0)
	begin
	
		if @Cantidad = 0 set @DevBuena = 0
		
		update InventarioFisico set Cantidad = Captura + @DevBuena, Status = 'P', DevBuena = @DevBuena 
		where IdProducto = @IdProducto and IdCedis = @IdCedis and Fecha = @Fecha

		fetch next from ActInvFis into @IdProducto, @DevBuena
	end
	close ActInvFis
	deallocate ActInvFis		

	-- Actualiza Kardex
	update InventarioKardex set InventarioKardex.Fisico = isnull( (select InventarioFisico.Cantidad 
	from InventarioFisico where InventarioFisico.IdCedis = @IdCedis and InventarioFisico.Fecha = @Fecha and InventarioFisico.IdProducto = InventarioKardex.IdProducto), 0 )
	where InventarioKardex.IdCedis =@IdCedis and InventarioKardex.Fecha = @Fecha

end

GO


