USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[up_SurtidosVendedores]    Script Date: 01/17/2011 16:11:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[up_SurtidosVendedores]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[up_SurtidosVendedores]
GO

USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[up_SurtidosVendedores]    Script Date: 01/17/2011 16:11:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO





CREATE PROCEDURE [dbo].[up_SurtidosVendedores] 
@IdCedis as bigint,
@IdSurtido as bigint,
@Fecha as datetime,
@IdVendedor as bigint,
@IdTipoVendedor as bigint,
@Opc as int
AS

declare @IdRuta as bigint

if @Opc = 1
begin
	-- set @IdSurtido = isnull ( (select max(IdSurtido) from Surtidos  ), 1)
	insert into SurtidosVendedor values (@IdCedis, @IdSurtido, @Fecha, @IdVendedor, @IdTipoVendedor)

	select @Fecha = Fecha  
	from Surtidos
	where IdCedis = @IdCedis and IdSurtido = @IdSurtido 

	exec up_VendedoresSaldos @IdCedis, @IdSurtido, @IdVendedor, @Fecha, 1
end

if @Opc = 2
begin
	delete from SurtidosVendedor 
	where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdVendedor = @IdVendedor
	
	select @Fecha = Fecha  
	from Surtidos
	where IdCedis = @IdCedis and IdSurtido = @IdSurtido 
	
	update VendedoresCargosAbonos set IdSurtido = 0 where IdCedis = @IdCedis and IdSurtido = @IdSurtido 
	update VendedoresSaldosFinancia set IdSurtido = 0 where IdCedis = @IdCedis and IdSurtido = @IdSurtido 
	update VendedoresSaldosFinanciaD set IdSurtido = 0 where IdCedis = @IdCedis and IdSurtido = @IdSurtido 

	exec up_VendedoresSaldos @IdCedis, 0, @IdVendedor, @Fecha, 1
end
			


set @IdRuta = isnull ( (select idruta from Surtidos where IdCedis = @IdCedis and IdSurtido = @IdSurtido ) , 0 )
delete from VendedoresRutas where IdCedis = @IdCedis and IdRuta = @IdRuta
if @IdRuta<>0
begin
	insert into VendedoresRutas
	select IdCedis, @IdRuta, IdVendedor, IdTipoVendedor 
	from SurtidosVendedor 
	where IdCedis = @IdCedis and IdSurtido = @IdSurtido 	
end


GO


