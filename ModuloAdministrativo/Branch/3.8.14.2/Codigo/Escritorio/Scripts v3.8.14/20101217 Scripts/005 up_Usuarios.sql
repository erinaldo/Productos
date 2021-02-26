USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[up_Usuarios]    Script Date: 12/17/2010 09:46:27 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[up_Usuarios]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[up_Usuarios]
GO

USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[up_Usuarios]    Script Date: 12/17/2010 09:46:27 ******/
SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER OFF
GO




CREATE PROCEDURE [dbo].[up_Usuarios] 
@IdCedis as bigint,
@Login as varchar(20),
@Password as varchar(10),
@Nombre as varchar(200),
@ApPaterno as varchar(200),
@ApMaterno as varchar(200),
@Status as char(1),
@Opc as int
AS

if @Opc = 1
begin
	insert into Usuarios values (@IdCedis, @Login, pwdEncrypt(@Password), @Nombre, @ApPaterno, @ApMaterno, 1, 'A')

	if not exists(select Login from RouteCPC.dbo.Usuarios where Login = @Login)
		insert into RouteCPC.dbo.Usuarios values (@Login, @IdCedis, pwdEncrypt(@Password), @Nombre, @ApPaterno, @ApMaterno, 1, 'A')
	else
		update RouteCPC.dbo.Usuarios set
			password = pwdEncrypt(@Password),
			Nombre = @Nombre,
			ApPaterno = @ApPaterno,
			ApMaterno = @ApMaterno,
			Status = @Status
		where Login = @Login
end
if @Opc = 2
begin
	if @Password<>''
	begin
		update Usuarios set
			password = pwdEncrypt(@Password),
			Nombre = @Nombre,
			ApPaterno = @ApPaterno,
			ApMaterno = @ApMaterno,
			Status = @Status
		where IdCedis = @IdCedis and Login = @Login
		
		if exists(select Login from RouteCPC.dbo.Usuarios where Login = @Login)
		begin
			update RouteCPC.dbo.Usuarios set
				password = pwdEncrypt(@Password),
				Nombre = @Nombre,
				ApPaterno = @ApPaterno,
				ApMaterno = @ApMaterno,
				Status = @Status
			where Login = @Login
		end
	end
	else
	begin
		update Usuarios set
			Nombre = @Nombre,
			ApPaterno = @ApPaterno,
			ApMaterno = @ApMaterno,
			Status = @Status
		where IdCedis = @IdCedis and Login = @Login
		
		if exists(select Login from RouteCPC.dbo.Usuarios where Login = @Login)
		begin
			update RouteCPC.dbo.Usuarios set
				Nombre = @Nombre,
				ApPaterno = @ApPaterno,
				ApMaterno = @ApMaterno,
				Status = @Status
			where Login = @Login
		end
	end
end

if @Opc = 3
begin
	update Usuarios set Status = 'B' where IdCedis = @IdCedis and Login = @Login

	if exists(select Login from RouteCPC.dbo.Usuarios where Login = @Login)
	begin
		update RouteCPC.dbo.Usuarios set Status = 'B' where IdCedis = @IdCedis and Login = @Login
	end
end
if @Opc = 4
	select pwdCompare(@Password,Password) from Usuarios where IdCedis = @IdCedis and Login = @Login




GO


