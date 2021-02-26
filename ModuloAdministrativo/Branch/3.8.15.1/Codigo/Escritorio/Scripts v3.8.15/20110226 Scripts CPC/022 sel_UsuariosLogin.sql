USE [RouteCPC]
GO

/****** Object:  StoredProcedure [dbo].[sel_UsuariosLogin]    Script Date: 03/04/2011 12:23:03 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sel_UsuariosLogin]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sel_UsuariosLogin]
GO

USE [RouteCPC]
GO

/****** Object:  StoredProcedure [dbo].[sel_UsuariosLogin]    Script Date: 03/04/2011 12:23:03 ******/
SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sel_UsuariosLogin] 
@Login as varchar(20),
@Opc as int
AS

if @Opc = 1
begin
	select cast(LoginD as varchar(20)) as Login, ApPaterno + ' ' + ApMaterno + ' ' + Nombre as Nombre
	from UsuariosLogin 
	inner join Usuarios on Usuarios.Login = UsuariosLogin.LoginD 
	where UsuariosLogin.Login = @Login 
	order by Nombre 
end

if @Opc = 2
begin
	select cast(Login as varchar(20)) , ApPaterno + ' ' + ApMaterno + ' ' + Nombre as Nombre
	from Usuarios 
	where Login <> @Login and Login not in (
		select LoginD from UsuariosLogin where Login = @Login)
	order by Nombre 
end


GO


