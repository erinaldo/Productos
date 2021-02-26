USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[up_CargasSugeridasDetalle]    Script Date: 06/16/2011 12:52:38 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[up_CargasSugeridasDetalle]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[up_CargasSugeridasDetalle]
GO

USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[up_CargasSugeridasDetalle]    Script Date: 06/16/2011 12:52:38 ******/
SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER OFF
GO

CREATE PROCEDURE [dbo].[up_CargasSugeridasDetalle]
@IdCedis as bigint,
@IdRuta as bigint,
@FechaCarga as datetime,
@Filtro as varchar(1000),
@Semanas as float,
@Tipo as char(1),
@Opc as int
AS

declare 
@IdProducto as int, 
@IdProductoDetalle as int,
@Cambios as float

declare @Route as int
set @Route = isnull( ( select Route from Configuracion where IdCedis = @IdCedis ), 0 )

if @Opc = 1
begin	
	exec( 'insert into CargasSugeridasDetalle 
	
		select ' + @IdCedis + ', ' + @IdRuta + ', ''' + @FechaCarga + ''', VentasDetalle.IdProducto, ' + @Tipo + ', sum(VentasDetalle.Cantidad) as Venta, case FN_CargasSugeridas.Decimales
			when 0 then round(sum(VentasDetalle.Cantidad) * (1 + FN_CargasSugeridas.Porcentaje ), -1) 
			when 1 then sum(VentasDetalle.Cantidad) * (1 + FN_CargasSugeridas.Porcentaje )
			end as Calculo, 0
		from Surtidos 
		inner join VentasDetalle on VentasDetalle.IdCedis = Surtidos.IdCedis and Surtidos.IdSurtido = VentasDetalle.IdSurtido
		inner join FN_CargasSugeridas (' + @IdCedis + ', ' + @IdRuta + ', ''' + @FechaCarga + ''') on FN_CargasSugeridas.IdProducto = VentasDetalle.IdProducto and FN_CargasSugeridas.Semanas = ' + @Semanas + '
		where Surtidos.IdCedis = ' + @IdCedis + ' and Surtidos.IdRuta = ' + @IdRuta + ' and Surtidos.Fecha in ( ' + @Filtro + ')
		group by VentasDetalle.IdProducto, FN_CargasSugeridas.Porcentaje, FN_CargasSugeridas.Decimales ')

end

if @Opc = 2
	delete from CargasSugeridasDetalle where IdCedis = @IdCedis and IdRuta = @IdRuta and FechaCarga = @FechaCarga

if @Opc = 3
begin
	set @IdProducto = cast(@Filtro as bigint)
	set @Cambios = @Semanas

	if exists (select IdProducto from CargasSugeridasDetalle where IdCedis = @IdCedis and IdRuta = @IdRuta and FechaCarga = @FechaCarga and IdProducto = @IdProducto )
		update CargasSugeridasDetalle set Cambios = @Cambios where IdCedis = @IdCedis and IdRuta = @IdRuta and FechaCarga = @FechaCarga and IdProducto = @IdProducto and Tipo = @Tipo
	else
		insert into CargasSugeridasDetalle values (@IdCedis, @IdRuta, @FechaCarga, @IdProducto, @Tipo, 0, 0, @Cambios)
		
	--if @Route = 1
	--begin
	--	if exists(select ProductoClave from Route.dbo.ProductoDetalle where cast(ProductoClave as int) = @IdProducto and cast(ProductoDetClave as int) <> @IdProducto)
	--	begin
	--		delete from CargasSugeridasDetalle where IdCedis = @IdCedis and IdRuta = @IdRuta and FechaCarga = @FechaCarga and Tipo = @Tipo and IdProducto in 
	--		( select cast(ProductoDetClave as int) 
	--		from Route.dbo.ProductoDetalle 
	--		where cast(ProductoClave as int) = @IdProducto and cast(ProductoDetClave as int) <> @IdProducto )
						
	--		select @IdProductoDetalle = cast(ProductoDetClave as int) 
	--		from Route.dbo.ProductoDetalle 
	--		where cast(ProductoClave as int) = @IdProducto and cast(ProductoDetClave as int) <> @IdProducto
			
	--		insert into CargasSugeridasDetalle 
	--		select @IdCedis, @IdRuta, @FechaCarga, cast(ProductoDetClave as int), @Tipo, 0, 0, (select SUM(cambios)
	--			from CargasSugeridasDetalle 
	--			where IdProducto in (select cast(PD.ProductoClave as int) from Route.dbo.ProductoDetalle as PD 
	--				where cast(PD.ProductoDetClave as int) = @IdProductoDetalle and cast(PD.ProductoClave as int) <> @IdProductoDetalle)
	--			and IdCedis = @IdCedis and FechaCarga = @FechaCarga and IdRuta = @IdRuta
	--			)*Factor
	--		from Route.dbo.ProductoDetalle 
	--		where cast(ProductoClave as int) = @IdProducto and cast(ProductoDetClave as int) <> @IdProducto
	--	end
	--end
		
end

if @Opc = 4
begin
	declare @IdCarga as bigint, @IdSurtido as bigint
	
	select @IdSurtido = isnull(IdSurtido, 0)
	from Surtidos
	where IdCedis = @IdCedis and IdRuta = @IdRuta and Fecha = @FechaCarga
	
	if @IdSurtido <> 0 and @IdSurtido is not null
	begin
		set @IdCarga = null
		select @IdCarga = isnull(max(Cargas.IdCarga),0)
		from Cargas
		left outer join SurtidosCargas SurC on Cargas.IdCedis = SurC.IdCedis and Cargas.IdSurtido = SurC.IdSurtido
			and Cargas.IdCarga = SurC.IdCarga 
		where Cargas.IdCedis = @IdCedis and Cargas.IdSurtido = @IdSurtido and Cargas.Status = 'A' and SurC.IdProducto is null
--select 'Carga Actual = ' + cast(@IdCarga as varchar(10))

		if @IdCarga is null
		begin
			select @IdCarga = (isnull(max(IdCarga),0) + 1)
			from Cargas
			where IdCedis = @IdCedis and IdSurtido = @IdSurtido
--select 'Nueva Carga = ' + cast(@IdCarga as varchar(10)) 		
			insert into Cargas values (@IdCedis, @IdSurtido, @IdCarga, @IdRuta, @FechaCarga, 'A')
		end 	

		insert into SurtidosCargas
		select IdCedis, @IdSurtido, @IdCarga, IdProducto, case Cambios 
			when 0 then Cantidad
			else Cambios end
		from CargasSugeridasDetalle
		where IdCedis = @IdCedis and IdRuta = @IdRuta and FechaCarga = @FechaCarga
	end
end
GO


