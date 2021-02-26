USE [RouteCPC]
GO

/****** Object:  StoredProcedure [dbo].[sel_ClientesFacturas]    Script Date: 04/01/2011 18:32:56 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sel_ClientesFacturas]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sel_ClientesFacturas]
GO

USE [RouteCPC]
GO

/****** Object:  StoredProcedure [dbo].[sel_ClientesFacturas]    Script Date: 04/01/2011 18:32:56 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sel_ClientesFacturas] 
@IdCedis as bigint,
@IdCliente as varchar(100),
@RFC as varchar(100),
@RazonSocial as varchar(100),
@Opc as int
AS

if @Opc = 1
begin
	if @IdCliente = 0
		select Clientes.IdCedis, Clientes.IdCliente, RFC, RazonSocial, Telefono, Domicilio
		from Clientes
		where Clientes.IdCedis = @IdCedis -- and cast(Clientes.IdCliente as varchar(20)) like '%' + cast(@IdCliente as varchar(20)) + '%'
		and RFC like '%' + @RFC + '%'
		and RazonSocial like '%' + @RazonSocial + '%'
	else
		select Clientes.IdCedis, Clientes.IdCliente, RFC, RazonSocial, Telefono, Domicilio
		from Clientes
		where Clientes.IdCedis = @IdCedis and Clientes.IdCliente = @IdCliente --cast(IdCliente as varchar(20)) like '%' + cast(@IdCliente as varchar(20)) + '%'
		-- and RFC like '%' + @RFC + '%'
		-- and RazonSocial like '%' + @RazonSocial + '%'
end

if @Opc = 2
begin
	if @IdCliente = 0
		select Clientes.IdCedis, Clientes.IdCliente, case ClientesTipo.Tipo when 'L' then 'LOCAL' when 'A' then 'AUTOSERVICIO' else 'No Definido' end as Tipo, RFC, RazonSocial, Telefono, Domicilio
		from Clientes
		left outer join ClientesTipo on  ClientesTipo.IdCedis = Clientes.IdCedis and ClientesTipo.IdCliente = Clientes.IdCliente
		where Clientes.IdCedis = @IdCedis -- and cast(Clientes.IdCliente as varchar(20)) like '%' + cast(@IdCliente as varchar(20)) + '%'
		and RFC like '%' + @RFC + '%'
		and RazonSocial like '%' + @RazonSocial + '%'
	else
		select Clientes.IdCedis, Clientes.IdCliente, case ClientesTipo.Tipo when 'L' then 'LOCAL' when 'A' then 'AUTOSERVICIO' else 'No Definido' end as Tipo, RFC, RazonSocial, Telefono, Domicilio
		from Clientes
		left outer join ClientesTipo on  ClientesTipo.IdCedis = Clientes.IdCedis and ClientesTipo.IdCliente = Clientes.IdCliente
		where Clientes.IdCedis = @IdCedis and Clientes.IdCliente = @IdCliente --cast(IdCliente as varchar(20)) like '%' + cast(@IdCliente as varchar(20)) + '%'
		-- and RFC like '%' + @RFC + '%'
		-- and RazonSocial like '%' + @RazonSocial + '%'
end

if @Opc = 3
begin
	SELECT * FROM  FN_ClienteSucursal (@IdCliente, @RazonSocial, @RFC)
end

if @Opc = 4
begin 
	SELECT FN_Clientes.*
	FROM  FN_Clientes (@IdCliente, @RazonSocial, @RFC)
	inner join ClientesFacturacion CteFact on CteFact.IdCedis = FN_Clientes.IdCedis and CteFact.IdCliente = FN_Clientes.IdCliente
	order by  FN_Clientes.IdCedis, FN_Clientes.RazonSocial
end

if @Opc = 5
begin
	SELECT FN_ClienteSucursal.* 
	FROM FN_ClienteSucursal (@IdCliente, @RazonSocial, @RFC)
	inner join ClientesFacturacion CteFact on CteFact.IdCedis = FN_ClienteSucursal.IdCedis and CteFact.IdCliente = FN_ClienteSucursal.IdCliente
	order by  FN_ClienteSucursal.IdCedis, FN_ClienteSucursal.RazonSocial, FN_ClienteSucursal.IdSucursal 
end

if @Opc = 6
begin
	SELECT * FROM  FN_ClienteSucursal (@IdCliente, @RazonSocial, @RFC)
	where IdCedis = @IdCedis 
end


GO


