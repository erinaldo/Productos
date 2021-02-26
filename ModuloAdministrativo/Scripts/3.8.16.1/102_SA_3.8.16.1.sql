USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[up_SurtidosDetalle]    Script Date: 09/12/2011 10:25:35 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[up_SurtidosDetalle]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[up_SurtidosDetalle]
GO

USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[up_SurtidosDetalle]    Script Date: 09/12/2011 10:25:35 ******/
SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER OFF
GO






CREATE PROCEDURE [dbo].[up_SurtidosDetalle] 
@IdCedis as bigint,
@IdSurtido as bigint,
@IdProducto as bigint,
@Fecha as datetime,
@Surtido as float,
@DevBuena as float,
@DevMala as float,
@Obsequios as float,
@VentaContado as float,
@VentaCredito as float,
@Opc as int

AS

declare 
@SurtidoAnterior as float,
@DevBuenaA as float,
@DevMalaA as float,
@ObsequiosA as float,
@Precio as money,
@IdLista as bigint,
@IdRuta as bigint,
@IdFamiliaRejas as bigint

declare @Iva as float, @IdTipoDevolucion as bigint

if @Opc = 1  
begin

	set @IdFamiliaRejas = ( select isnull(idfamiliarejas,0) as Reja from productos left outer join configuracion on idfamilia = idfamiliarejas where idproducto = @IdProducto )

	set @IdRuta = isnull( (select IdRuta from Surtidos where IdCedis = @IdCedis and IdSurtido = @IdSurtido), 0)


	if @IdFamiliaRejas <> 0  -- PRODUCTO REJA
	begin
		
		set @SurtidoAnterior =  isnull( (select Surtido from Rejas where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdProducto = @IdProducto ), 0)
		if @SurtidoAnterior = 0 and @Surtido <> 0 
			begin
				-- delete from Rejas where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdProducto = @IdProducto
				--- insert into Rejas values (@IdCedis, @IdSurtido, @IdCarga, @IdProducto, @Fecha, @IdRuta, @Surtido, 0)
				update InventarioKardex set Surtido = Surtido + @Surtido where IdCedis = @IdCedis and Fecha = @Fecha and IdProducto = @IdProducto 
			end
		else
			begin
				-- update Rejas set Surtido = @Surtido where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdProducto = @IdProducto
				update InventarioKardex set Surtido = Surtido + ( @Surtido - @SurtidoAnterior ) where IdCedis = @IdCedis and Fecha = @Fecha and IdProducto = @IdProducto 	
				-- if @Surtido = 0 delete from SurtidosDetalle where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdProducto = @IdProducto
			end
		
	end
	else   -- PRODUCTO NO REJA
	begin 

		set @IdLista = isnull((select PreciosListaCedis.IdLista from PreciosListaCedis 
				inner join PreciosLista on PreciosListaCedis.IdLista = PreciosLista.IdLista and TipoLista='BA'
				where PreciosListaCedis.idcedis = @IdCedis),0)
		set @Precio = isnull( (select Precio from PreciosDetalle where IdLista = @IdLista and IdProducto = @IdProducto), 0)
		set @Iva = isnull( (select Iva from Productos where IdProducto = @IdProducto), 0)
	
		set @SurtidoAnterior = isnull( (select Surtido from SurtidosDetalle where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdProducto = @IdProducto ), 0)
		if @SurtidoAnterior = 0 and @Surtido <> 0 
			begin
				delete from SurtidosDetalle where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdProducto = @IdProducto
				insert into SurtidosDetalle values (@IdCedis, @IdSurtido, @IdProducto, @Fecha, @Surtido, 0, 0, 0, 0, 0, 0, 0,@Precio, @Iva)
				update InventarioKardex set Surtido = Surtido + @Surtido where IdCedis = @IdCedis and Fecha = @Fecha and IdProducto = @IdProducto 
			end
		else
			begin
				update SurtidosDetalle set Surtido = @Surtido, Precio = @Precio, Iva = @Iva where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdProducto = @IdProducto
				update InventarioKardex set Surtido = Surtido + ( @Surtido - @SurtidoAnterior ) where IdCedis = @IdCedis and Fecha = @Fecha and IdProducto = @IdProducto 	
				if @Surtido = 0 delete from SurtidosDetalle where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdProducto = @IdProducto
			end

	end

	update StatusRutas set Status = 'C', StatusDesc = 'Carga' where IdCedis = @IdCedis and Fecha = @Fecha and IdRuta = @IdRuta
end


if @Opc = 2  
begin

declare @IdCarga as bigint

	set @IdFamiliaRejas = ( select isnull(idfamiliarejas,0) as Reja from productos left outer join configuracion on idfamilia = idfamiliarejas where idproducto = @IdProducto )
	if @IdFamiliaRejas <> 0  -- PRODUCTO REJA
	begin

		set @DevBuenaA = isnull ( (select Devolucion from Rejas where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdProducto = @IdProducto ), -1 ) 
		
		update Rejas set Devolucion = @DevBuena where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdProducto = @IdProducto
		
		if not exists(select IdProducto from Rejas where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdProducto = @IdProducto) and @DevBuena > 0
		begin
			select top 1 @IdCarga = IdCarga, @IdRuta = Surtidos.IdRuta, @Fecha = Surtidos.Fecha 
			from Surtidos 
			inner join Cargas on Cargas.IdCedis = Surtidos.IdCedis and Cargas.IdSurtido = Surtidos.IdSurtido and Cargas.Status = 'A'
			where Surtidos.IdCedis = @IdCedis and Surtidos.IdSurtido = @IdSurtido 
			order by Cargas.IdCarga  
		
			insert into Rejas values (@IdCedis, @IdSurtido, @IdCarga, @IdProducto, @Fecha, @IdRuta, 0, @DevBuena) 
		end	
			
		
		update InventarioKardex set DevBuena = DevBuena + ( @DevBuena - @DevBuenaA ) where IdCedis = @IdCedis and Fecha = @Fecha and IdProducto = @IdProducto 		

	end
	else

	begin
	
		set @DevBuenaA = isnull ( (select DevBuena from SurtidosDetalle where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdProducto = @IdProducto ), -1 ) 
		set @DevMalaA = isnull ( (select DevMala from SurtidosDetalle where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdProducto = @IdProducto ), -1 ) 
		set @ObsequiosA = isnull ( (select Obsequios from SurtidosDetalle where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdProducto = @IdProducto ), -1 ) 
		
		update SurtidosDetalle set DevBuena = @DevBuena, DevMala = @DevMala, Obsequios = @Obsequios 
		where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdProducto = @IdProducto
		
		update InventarioKardex set DevBuena = DevBuena + ( @DevBuena - @DevBuenaA ), DevMala = DevMala + ( @DevMala - @DevMalaA ), Obsequios = Obsequios + ( @Obsequios - @ObsequiosA )  
		where IdCedis = @IdCedis and Fecha = @Fecha and IdProducto = @IdProducto 		
	
	end

	set @IdRuta = isnull( (select IdRuta from Surtidos where IdCedis = @IdCedis and IdSurtido = @IdSurtido), 0)
	update StatusRutas set Status = 'D', StatusDesc = 'Devolución' where IdCedis = @IdCedis and Fecha = @Fecha and IdRuta = @IdRuta

	if exists( select IdCedis from StatusLiquidacion where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdRuta = @IdRuta and Fecha = @Fecha and Status = 'HH' ) and @IdFamiliaRejas = 0  
	begin
		delete from StatusLiquidacion where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdRuta = @IdRuta and Fecha = @Fecha and Status = 'DEV'
		insert into StatusLiquidacion values ( @IdCedis, @IdSurtido, @IdRuta, @Fecha, 'DEV', 'Actualización de Devoluciones', getdate() )
	end

end

if @Opc = 3
	begin
		update SurtidosDetalle set DevBuena = Surtido - DevMala - Obsequios - VentaContado - VentaCredito - Consignacion + Recuperacion 
		where idCedis = @IdCedis and IdSurtido = @IdSurtido

		select top 1 @IdTipoDevolucion = ISNULL(IdTipoDevolucion, 0) from TipoDevolucion where EnRuta = 1 order by IdTipoDevolucion
		if @IdTipoDevolucion <> 0 
		begin
			delete from SurtidosDevolucion 
			where idCedis = @IdCedis and IdSurtido = @IdSurtido
			
			insert into SurtidosDevolucion 
			select IdCedis, IdSurtido, @IdTipoDevolucion, IdProducto, DevBuena 
			from SurtidosDetalle 
			where idCedis = @IdCedis and IdSurtido = @IdSurtido and DevBuena > 0
		end
	end  



GO



USE [Route]
GO

if (Select COUNT(*) from VersionBD where Tipo = 'SA' and Version ='3.8.16.1') = 0
BEGIN
	INSERT INTO VersionBD (Tipo, FechaHora, Version, MaximoConsecutivo, VersionSql ) 
	VALUES('SA', GETDATE(), '3.8.16.1', 102, (SELECT  cast(SERVERPROPERTY('productversion') as varchar(50))))
END
ELSE
BEGIN 
	Update VersionBD  set MaximoConsecutivo = 102 where  Tipo = 'SA' and Version ='3.8.16.1'
END
GO