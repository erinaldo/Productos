USE [RouteCPC]
GO

/****** Object:  StoredProcedure [dbo].[sel_CedisUsuarios]    Script Date: 03/31/2011 16:28:43 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sel_CedisUsuarios]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sel_CedisUsuarios]
GO

USE [RouteCPC]
GO

/****** Object:  StoredProcedure [dbo].[sel_CedisUsuarios]    Script Date: 03/31/2011 16:28:43 ******/
SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sel_CedisUsuarios] 
@Login as varchar(20),
@Opc as int
AS

if @Opc = 1 -- cedis Asignados
	select '', UsuariosCedis.IdCedis, Cedis
	from UsuariosCedis 
	inner join Cedis on Cedis.IdCedis = UsuariosCedis.IdCedis
	where UsuariosCedis.Login = @Login
	order by Cedis.Cedis

if @Opc = 2
	select UsuariosCedis.IdCedis, Cedis
	from UsuariosCedis 
	inner join Cedis on Cedis.IdCedis = UsuariosCedis.IdCedis
	where UsuariosCedis.Login = @Login
	order by Cedis.Cedis

if @Opc = 3   -- Cedis no Asignados
	select '', IdCedis, Cedis
	from cedis where Idcedis not in (
	select IdCedis from UsuariosCedis where Login = @Login )
	order by Cedis.Cedis

if @Opc = 4   -- TODOS LOS CEDIS
	select '', IdCedis, Cedis
	from cedis 
	order by Cedis.Cedis

if @Opc = 5
	select IdCedis, Cedis
	from Cedis 
	where IdCedis = 1
	order by Cedis.Cedis

if @Opc = 6
	select '', IdCedis, Cedis
	from Cedis 
	where IdCedis = 1
	order by Cedis.Cedis
GO


