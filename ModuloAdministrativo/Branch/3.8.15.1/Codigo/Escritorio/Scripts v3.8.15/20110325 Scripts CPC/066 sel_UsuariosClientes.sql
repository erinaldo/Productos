USE [RouteCPC]
GO

/****** Object:  StoredProcedure [dbo].[sel_UsuariosClientes]    Script Date: 03/28/2011 08:59:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sel_UsuariosClientes]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sel_UsuariosClientes]
GO

USE [RouteCPC]
GO

/****** Object:  StoredProcedure [dbo].[sel_UsuariosClientes]    Script Date: 03/28/2011 08:59:49 ******/
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
	select '', Clientes.IdCedis, Cedis, UsuariosClientes.IdCliente, RazonSocial as Cliente, Clientes.IdCedis  
	from UsuariosClientes 
	inner join Clientes on Clientes.IdCedis = UsuariosClientes.IdCedis and Clientes.IdCliente = UsuariosClientes.IdCliente
	inner join Cedis on Cedis.IdCedis = Clientes.IdCedis 
	where UsuariosClientes.Login = @Login 
	order by Clientes.RazonSocial, Clientes.IdCedis 

if @Opc = 2
	select Clientes.IdCedis, Cedis, UsuariosClientes.IdCliente, RazonSocial as Cliente, Clientes.IdCedis 
	from UsuariosClientes 
	inner join Clientes on Clientes.IdCedis = UsuariosClientes.IdCedis and Clientes.IdCliente = UsuariosClientes.IdCliente
	inner join Cedis on Cedis.IdCedis = Clientes.IdCedis 
	where UsuariosClientes.Login = @Login
	order by Clientes.RazonSocial, Clientes.IdCedis 
	
if @Opc = 3   -- Clientes no Asignados
	select '', Clientes.IdCedis, Cedis, IdCliente, RazonSocial as Cliente, Clientes.IdCedis 
	from Clientes 
	inner join Cedis on Cedis.IdCedis = Clientes.IdCedis 
	where IdCliente not in (
	select IdCliente from UsuariosClientes where Login = @Login and UsuariosClientes.IdCedis = Clientes.IdCedis )
	order by Clientes.RazonSocial, Clientes.IdCedis 
	
if @Opc = 4   -- TODOS LOS Clientes
	select '', Clientes.IdCedis, Cedis, IdCliente, RazonSocial as Cliente
	from Clientes 
	inner join Cedis on Cedis.IdCedis = Clientes.IdCedis 
	order by Clientes.RazonSocial, Clientes.IdCedis 

GO


