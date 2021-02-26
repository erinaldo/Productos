USE [RouteCPC]
GO

/****** Object:  StoredProcedure [dbo].[sel_UsuariosClientes]    Script Date: 07/15/2010 15:03:55 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sel_UsuariosClientes]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sel_UsuariosClientes]
GO

USE [RouteCPC]
GO

/****** Object:  StoredProcedure [dbo].[sel_ClientesUsuarios]    Script Date: 07/15/2010 15:03:55 ******/
SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sel_UsuariosClientes] 
@IdCliente as bigint,
@Login as varchar(20),
@Opc as int
AS

if @Opc = 1 -- Clientes Asignados
	select '', UsuariosClientes.IdCliente, RazonSocial as Cliente, Clientes.IdCedis  
	from UsuariosClientes 
	inner join Clientes on Clientes.IdCedis = UsuariosClientes.IdCedis and Clientes.IdCliente = UsuariosClientes.IdCliente
	where UsuariosClientes.Login = @Login 
	order by Clientes.RazonSocial 

if @Opc = 2
	select UsuariosClientes.IdCliente, RazonSocial as Cliente, Clientes.IdCedis 
	from UsuariosClientes 
	inner join Clientes on Clientes.IdCedis = UsuariosClientes.IdCedis and Clientes.IdCliente = UsuariosClientes.IdCliente
	where UsuariosClientes.Login = @Login
	order by Clientes.RazonSocial 
	
if @Opc = 3   -- Clientes no Asignados
	select '', IdCliente, RazonSocial as Cliente, Clientes.IdCedis 
	from Clientes where IdCliente not in (
	select IdCliente from UsuariosClientes where Login = @Login and UsuariosClientes.IdCedis = Clientes.IdCedis )
	order by Clientes.RazonSocial 
	
if @Opc = 4   -- TODOS LOS Clientes
	select '', IdCliente, RazonSocial as Cliente
	from Clientes 
	order by Clientes.RazonSocial 
GO


