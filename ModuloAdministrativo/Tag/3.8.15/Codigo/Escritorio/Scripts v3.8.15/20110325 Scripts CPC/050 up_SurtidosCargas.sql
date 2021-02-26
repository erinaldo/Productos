USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[up_SurtidosCargas]    Script Date: 03/25/2011 23:09:57 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[up_SurtidosCargas]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[up_SurtidosCargas]
GO

USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[up_SurtidosCargas]    Script Date: 03/25/2011 23:09:57 ******/
SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER OFF
GO




CREATE PROCEDURE [dbo].[up_SurtidosCargas]
@IdCedis as bigint,
@IdSurtido as bigint,
@IdCarga as bigint,
@IdProducto as bigint,
@Fecha as datetime,
@Surtido as float,
@Opc as int

AS

declare 
@SurtidoAnterior as float,
@IdRuta as bigint,
@IdProductoDetalle as int,
@IdFamiliaRejas as bigint,
@SerieD as varchar(6)

declare @Iva as float
declare @Route as int
set @Route = isnull( ( select Route from Configuracion where IdCedis = @IdCedis ), 0 )
select @SerieD = SerieDevoluciones from Configuracion where IdCedis = @IdCedis

if @Opc = 1  
begin

	set @IdFamiliaRejas = ( select isnull(idfamiliarejas,0) as Reja from productos left outer join configuracion on idfamilia = idfamiliarejas where idproducto = @IdProducto )

	set @IdRuta = isnull( (select IdRuta from Surtidos where IdCedis = @IdCedis and IdSurtido = @IdSurtido), 0)

	if @IdFamiliaRejas <> 0  -- PRODUCTO REJA
	begin
		delete from Rejas where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdProducto = @IdProducto

		set @SurtidoAnterior =  isnull( (select Surtido from Rejas where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdCarga = @IdCarga and IdProducto = @IdProducto ), 0)
		if @SurtidoAnterior = 0 and @Surtido <> 0 
			begin
				delete from Rejas where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdCarga = @IdCarga and IdProducto = @IdProducto
				insert into Rejas values (@IdCedis, @IdSurtido, @IdCarga, @IdProducto, @Fecha, @IdRuta, @Surtido, 0)
			end
		else
			begin
				update Rejas set Surtido = @Surtido where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdCarga = @IdCarga and IdProducto = @IdProducto
				if @Surtido = 0 delete from SurtidosCargas where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdCarga = @IdCarga and IdProducto = @IdProducto
			end
		if @Surtido = 0  delete from Rejas where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdCarga = @IdCarga and IdProducto = @IdProducto
	end
	else  -- PRODUCTO NO REJA
	begin 

		set @SurtidoAnterior = isnull( (select Cantidad from SurtidosCargas where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdCarga = @IdCarga  and IdProducto = @IdProducto ), 0)
		if @SurtidoAnterior = 0 and @Surtido <> 0 
			begin
				delete from SurtidosCargas where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdCarga = @IdCarga  and IdProducto = @IdProducto
				insert into SurtidosCargas values (@IdCedis, @IdSurtido, @IdCarga, @IdProducto, @Surtido )
				--if @Route = 1
				--begin
				--	if exists(select ProductoClave from Route.dbo.ProductoDetalle where cast(ProductoClave as int) = @IdProducto and cast(ProductoDetClave as int) <> @IdProducto)
				--	begin
				--		delete from SurtidosCargas where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdCarga = @IdCarga  and IdProducto in 
				--		( select cast(ProductoDetClave as int) from Route.dbo.ProductoDetalle where cast(ProductoClave as int) = @IdProducto and cast(ProductoDetClave as int) <> @IdProducto )
					
				--		select @IdProductoDetalle = cast(ProductoDetClave as int) 
				--		from Route.dbo.ProductoDetalle 
				--		where cast(ProductoClave as int) = @IdProducto and cast(ProductoDetClave as int) <> @IdProducto
					
				--		insert into SurtidosCargas 
				--		select @IdCedis, @IdSurtido, @IdCarga, cast(ProductoDetClave as int), isnull((select sum(Cantidad) 
				--			from SurtidosCargas 
				--			where IdProducto in (select cast(PD.ProductoClave as int) from Route.dbo.ProductoDetalle as PD 
				--			where cast(PD.ProductoDetClave as int) = @IdProductoDetalle and cast(PD.ProductoClave as int) <> @IdProductoDetalle)
				--			and IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdCarga = @IdCarga),0)*Factor 
				--		from Route.dbo.ProductoDetalle 
				--		where cast(ProductoClave as int) = @IdProducto and cast(ProductoDetClave as int) <> @IdProducto
				--	end
				--end
			end
		else
			begin
				update SurtidosCargas set Cantidad = @Surtido where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdCarga = @IdCarga  and IdProducto = @IdProducto
				if @Surtido = 0 delete from SurtidosCargas where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdCarga = @IdCarga and IdProducto = @IdProducto

				--if @Route = 1
				--begin
				--	if exists(select top 1 ProductoClave from Route.dbo.ProductoDetalle where cast(ProductoClave as int) = @IdProducto and cast(ProductoDetClave as int) <> @IdProducto)
				--	begin
				--		delete from SurtidosCargas where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdCarga = @IdCarga  and IdProducto in 
				--		( select cast(ProductoDetClave as int) from Route.dbo.ProductoDetalle where cast(ProductoClave as int) = @IdProducto and cast(ProductoDetClave as int) <> @IdProducto)
					
				--		if @Surtido <> 0
				--		begin 
				--			select @IdProductoDetalle = cast(ProductoDetClave as int) 
				--			from Route.dbo.ProductoDetalle 
				--			where cast(ProductoClave as int) = @IdProducto and cast(ProductoDetClave as int) <> @IdProducto

				--			insert into SurtidosCargas 
				--			select @IdCedis, @IdSurtido, @IdCarga, cast(ProductoDetClave as int), isnull((select sum(Cantidad) 
				--					from SurtidosCargas 
				--					where IdProducto in (select cast(PD.ProductoClave as int) from Route.dbo.ProductoDetalle as PD 
				--					where cast(PD.ProductoDetClave as int) = @IdProductoDetalle and cast(PD.ProductoClave as int) <> @IdProductoDetalle)
				--					and IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdCarga = @IdCarga), 0)*Factor 
				--			from Route.dbo.ProductoDetalle 
				--			where cast(ProductoClave as int) = @IdProducto and cast(ProductoDetClave as int) <> @IdProducto
				--		end
				--	end
				--end
			end
	end

	if exists( select IdCedis from StatusLiquidacion where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdRuta = @IdRuta and Fecha = @Fecha and Status = 'HH' ) 
	begin
		delete from StatusLiquidacion where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdRuta = @IdRuta and Fecha = @Fecha and Status = 'CA'
		insert into StatusLiquidacion values ( @IdCedis, @IdSurtido, @IdRuta, @Fecha, 'CA', 'Actualización de Carga', getdate() )
	end
end

if @Opc = 2
begin

DECLARE @CursorVtas CURSOR
SET @CursorVtas = CURSOR SCROLL DYNAMIC FOR 
	select IdProducto, SUM(cantidad)
	from VentasDetalle 
	where IdCedis = @IdCedis and IdSurtido = @IdSurtido 
	group by IdProducto

OPEN @CursorVtas
FETCH NEXT FROM @CursorVtas INTO @IdProducto, @Surtido
WHILE @@FETCH_STATUS = 0      
BEGIN       
	
	if exists(select IdProducto from SurtidosCargas where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdCarga = @IdCarga and IdProducto = @IdProducto)
		update SurtidosCargas set Cantidad = @Surtido where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdCarga = @IdCarga  and IdProducto = @IdProducto
	else
		insert into SurtidosCargas values (@IdCedis, @IdSurtido, @IdCarga, @IdProducto, @Surtido )	
	
    FETCH NEXT FROM @CursorVtas INTO @IdProducto, @Surtido
END
CLOSE @CursorVtas  
DEALLOCATE @CursorVtas

delete 
from SurtidosCargas
where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdCarga = @IdCarga and IdProducto not in (
	select IdProducto from VentasDetalle where IdCedis = @IdCedis and IdSurtido = @IdSurtido )

end

--if @Opc = 3 
--begin
--	if exists(select top 1 Folio from VentasDetalle where IdCedis = @IdCedis and IdSurtido = @IdSurtido and Cantidad <> Entregado)
--	begin
--		if not exists(select IdCarga from Cargas where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdCarga = 99)
--			insert into Cargas values (@IdCedis, @IdSurtido, 99, @IdRuta, @Fecha, 'A')
--		else
--			update Cargas set Status = 'A' where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdCarga = 99
		
--		delete from SurtidosCargas where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdCarga = 99
--		insert into SurtidosCargas 
--		select IdCedis, IdSurtido, 99, IdProducto, SUM(Cantidad-Entregado) 
--		from VentasDetalle 
--		where IdCedis = @IdCedis and IdSurtido = @IdSurtido and Cantidad <> Entregado and Serie <> @SerieD  
--		group by IdCedis, IdSurtido, IdProducto
--	end
--	else
--		delete from SurtidosCargas where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdCarga = 99
--end


GO


