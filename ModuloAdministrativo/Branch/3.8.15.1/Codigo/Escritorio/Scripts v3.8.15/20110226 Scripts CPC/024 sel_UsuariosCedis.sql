USE [RouteCPC]
GO

/****** Object:  StoredProcedure [dbo].[sel_UsuariosCedis]    Script Date: 03/04/2011 11:30:32 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sel_UsuariosCedis]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sel_UsuariosCedis]	
GO

USE [RouteCPC]
GO

/****** Object:  StoredProcedure [dbo].[sel_UsuariosCedis]    Script Date: 03/04/2011 11:30:32 ******/
SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sel_UsuariosCedis] 
@Login as varchar(20),
@Opc as int
AS

if @Opc = 1
begin
	select 0, Cedis.IdCedis, Cedis 
	from UsuariosCedis 
	inner join Cedis on UsuariosCedis.IdCedis = Cedis.IdCedis 
	where UsuariosCedis.Login = @Login 
	order by Cedis.IdCedis
end

if @Opc = 2
begin
	select 0, Cedis.IdCedis, Cedis 
	from Cedis 
	where Cedis.IdCedis not in (select IdCedis from UsuariosCedis where Login = @Login)
	order by Cedis.IdCedis
end

GO


