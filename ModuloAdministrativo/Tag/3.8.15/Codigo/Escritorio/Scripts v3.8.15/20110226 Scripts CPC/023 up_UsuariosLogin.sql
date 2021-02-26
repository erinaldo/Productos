USE [RouteCPC]
GO

/****** Object:  StoredProcedure [dbo].[up_UsuariosLogin]    Script Date: 03/04/2011 11:43:11 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[up_UsuariosLogin]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[up_UsuariosLogin]
GO

USE [RouteCPC]
GO

/****** Object:  StoredProcedure [dbo].[up_UsuariosLogin]    Script Date: 03/04/2011 11:43:11 ******/
SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[up_UsuariosLogin]
@Login as varchar(20),
@LoginD as varchar(20),
@Opc as int
AS

if @Opc = 1 
begin
	delete from UsuariosLogin where Login = @Login and LoginD = @LoginD 
	insert into UsuariosLogin values (@Login, @LoginD)
end

if @Opc = 2
begin
	delete from UsuariosLogin where Login = @Login and LoginD = @LoginD 
end

GO


