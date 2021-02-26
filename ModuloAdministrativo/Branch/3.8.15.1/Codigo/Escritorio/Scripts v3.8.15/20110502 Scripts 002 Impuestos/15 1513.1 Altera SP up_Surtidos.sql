USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[up_Surtidos]    Script Date: 05/03/2011 16:52:01 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[up_Surtidos]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[up_Surtidos]
GO

USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[up_Surtidos]    Script Date: 05/03/2011 16:52:01 ******/
SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER OFF
GO







CREATE PROCEDURE [dbo].[up_Surtidos] 
@IdCedis as bigint,
@IdSurtido as bigint,
@Fecha as datetime,
@IdRuta as bigint,
@Opc as int

AS

declare @IdRutaS as bigint, @IdCarga as bigint
declare @IdVendedor as bigint

if @Opc = 1  
begin
	set @IdSurtido = isnull ( (select max(IdSurtido) from Surtidos where IdCedis = @IdCedis)+1, 1)	
	insert into Surtidos values (@IdCedis, @IdSurtido, @Fecha, @IdRuta, 'P', 'N')

	set @IdCarga = isnull( (select max( IdCarga ) from Cargas where IdCedis = @IdCedis and Fecha = @Fecha and IdRuta = @IdRuta) + 1 , 1)	
	insert into Cargas values (@IdCedis, @IdSurtido, @IdCarga, @IdRuta, @Fecha, 'A')

	Insert into SurtidosVendedor
	select @IdCedis, @IdSurtido, @Fecha, IdVendedor, IdTipoVendedor
	from VendedoresRutas
	where IdCedis = @IdCedis and IdRuta = @IdRuta
	
	-- SE ARRASTRA A CARGA EL INV SOBRANTE DE LA LIQIDACIÓN ANTERIOR
	declare @IdSurtidoA as bigint

	select top 1 @IdSurtidoA = isnull(IdSurtido,0)
	from Surtidos 
	where IdCedis = @IdCedis and Fecha = @Fecha and IdRuta = @IdRuta and Status = 'C'
	order by IdSurtido desc
	
	if @IdSurtidoA > 0
	begin
		insert into SurtidosCargas 
		select SurtidosDetalle.IdCedis, @IdSurtido, @IdCarga, SurtidosDetalle.IdProducto, sum(DevBuena) - ISNULL(sum(Cantidad),0)
		from SurtidosDetalle
		left outer join SurtidosDevolucion on SurtidosDetalle.IdCedis = SurtidosDevolucion.IdCedis and SurtidosDetalle.IdSurtido = SurtidosDevolucion.IdSurtido
			and SurtidosDetalle.IdProducto = SurtidosDevolucion.IdProducto and SurtidosDevolucion.IdTipoDevolucion in (
				select IdTipoDevolucion from TipoDevolucion where EnRuta = 0)
		where SurtidosDetalle.IdCedis = @IdCedis and SurtidosDetalle.IdSurtido = @IdSurtidoA 
		group by SurtidosDetalle.IdCedis, SurtidosDetalle.IdSurtido, SurtidosDetalle.IdProducto
		having sum(DevBuena) - ISNULL(sum(Cantidad),0) > 0 
	end
	
	set @IdRutaS = isnull( (select IdRuta from StatusRutas where IdCedis = @IdCedis and Fecha = @Fecha and IdRuta = @IdRuta) , 0)
	
	if @IdRutaS = 0 
		insert into StatusRutas values (@IdCedis, @Fecha, @IdRuta, 'N', 'Sin Movimientos')
	else
		update StatusRutas set Status = 'N', StatusDesc = 'Sin Movimientos' where IdCedis = @IdCedis and Fecha = @Fecha and IdRuta = @IdRuta
end

if @Opc = 2  
begin
	update CargasSugeridas set IdSurtido = 0, IdCarga = 0, Status = 'A'
	where IdCedis = @IdCedis and IdSurtido = @IdSurtido 

	insert into VentasCanceladas 
	select IdCedis, IdSurtido, IdTipoVenta, Folio, Serie, Fecha, IdCliente, Subtotal, Iva, IdSucursal, DctoImp, DiasCredito 
	from Ventas 
	where IdCedis = @IdCedis and IdSurtido = @IdSurtido 

	delete from VentasAcredita where IdCedis = @IdCedis and IdSurtido = @IdSurtido 

	update Pedidos set IdSurtido = 0, Serie = '', Folio = 0
	where IdCedis = @IdCedis and IdSurtido = @IdSurtido 

	delete from SurtidosFoliosLiquidacion where IdCedis = @IdCedis and IdSurtido = @IdSurtido 
	delete from SurtidosCheque  where IdCedis = @IdCedis and IdSurtido = @IdSurtido 
	delete from SurtidosDenominacion where IdCedis = @IdCedis and IdSurtido = @IdSurtido 

	update CargasSugeridas set IdSurtido = 0, IdCarga = 0, Status = 'A'
	where IdCedis = @IdCedis and IdSurtido = @IdSurtido 
	
	delete from VendedoresSaldos where IdCedis = @IdCedis and IdSurtido = @IdSurtido 
	delete from VendedoresSaldosValida where IdCedis = @IdCedis and IdSurtido = @IdSurtido 
	
	delete from VentasDetalle where IdCedis = @IdCedis and IdSurtido = @IdSurtido
	delete from Ventas where IdCedis = @IdCedis and IdSurtido = @IdSurtido
	delete from VentasImpuestos where IdCedis = @IdCedis and IdSurtido = @IdSurtido

	delete from Cargas where IdCedis = @IdCedis and IdSurtido = @IdSurtido
	delete from SurtidosCargas where IdCedis = @IdCedis and IdSurtido = @IdSurtido

	delete from Rejas where IdCedis = @IdCedis and IdSurtido = @IdSurtido
	delete from SurtidosMerma where IdCedis = @IdCedis and IdSurtido = @IdSurtido
	delete from SurtidosDevolucion where IdCedis = @IdCedis and IdSurtido = @IdSurtido

	select top 1 @Fecha = Surtidos.Fecha, @IdVendedor = SurtidosVendedor.IdVendedor 
	from Surtidos 
	inner join SurtidosVendedor on Surtidos.IdCedis = SurtidosVendedor.IdCedis and Surtidos.IdSurtido = SurtidosVendedor.IdSurtido 
	where Surtidos.IdCedis = @IdCedis and Surtidos.IdSurtido = @IdSurtido 
	order by SurtidosVendedor.IdTipoVendedor 
	
	update VendedoresCargosAbonos set IdSurtido = 0 where IdCedis = @IdCedis and IdSurtido = @IdSurtido 
	update VendedoresSaldosFinancia set IdSurtido = 0 where IdCedis = @IdCedis and IdSurtido = @IdSurtido 
	update VendedoresSaldosFinanciaD set IdSurtido = 0 where IdCedis = @IdCedis and IdSurtido = @IdSurtido 

	delete from SurtidosVendedor where IdCedis = @IdCedis and IdSurtido = @IdSurtido
	
	exec up_VendedoresSaldos @IdCedis, 0, @IdVendedor, @Fecha, 1

	delete from SurtidosDetalle where IdCedis = @IdCedis and IdSurtido = @IdSurtido
	delete from Surtidos where IdCedis = @IdCedis and IdSurtido = @IdSurtido
		
end

if @Opc = 3
begin
	update Surtidos set Status = 'C' where IdCedis = @IdCedis and IdSurtido = @IdSurtido
	
	set @IdRuta = isnull( (select IdRuta from Surtidos where IdCedis = @IdCedis and IdSurtido = @IdSurtido), 0)
	update StatusRutas set Status = 'T', StatusDesc = 'Terminado' where IdCedis = @IdCedis and Fecha = @Fecha and IdRuta = @IdRuta
	
end



GO


