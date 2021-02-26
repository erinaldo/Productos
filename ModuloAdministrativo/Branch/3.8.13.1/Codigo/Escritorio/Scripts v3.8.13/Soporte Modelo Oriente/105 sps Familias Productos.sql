USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[sel_Familias]    Script Date: 08/13/2010 11:23:05 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sel_Familias]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sel_Familias]
GO

/****** Object:  StoredProcedure [dbo].[sel_Grupos]    Script Date: 08/13/2010 11:23:05 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sel_Grupos]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sel_Grupos]
GO

/****** Object:  StoredProcedure [dbo].[sel_Marcas]    Script Date: 08/13/2010 11:23:05 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sel_Marcas]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sel_Marcas]
GO

/****** Object:  StoredProcedure [dbo].[up_Familias]    Script Date: 08/13/2010 11:23:05 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[up_Familias]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[up_Familias]
GO

/****** Object:  StoredProcedure [dbo].[up_Grupos]    Script Date: 08/13/2010 11:23:05 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[up_Grupos]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[up_Grupos]
GO

/****** Object:  StoredProcedure [dbo].[up_Marcas]    Script Date: 08/13/2010 11:23:05 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[up_Marcas]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[up_Marcas]
GO

USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[sel_Familias]    Script Date: 08/13/2010 11:23:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




CREATE PROCEDURE [dbo].[sel_Familias]
@IdGrupo as bigint,
@Opc as int
AS

if @Opc = 1
	select F.IdFamilia as 'Clave', F.Familia as 'Familia', G.Grupo as 'Grupo', F.FechaAlta,
	case F.Status 
		when 'A' then 'Activo'
		else 'Baja'
		end as 'Estatus'
	from Familias F, Grupos G
	WHERE F.IdGrupo = G.IdGrupo
	order by Familia

if @Opc = 2
	select F.IdFamilia as 'Clave', F.Familia as 'Familia', G.Grupo as 'Grupo', F.FechaAlta,
	case F.Status 
		when 'A' then 'Activo'
		else 'Baja'
		end as 'Estatus'
	from Familias F, Grupos G
	WHERE F.IdGrupo = G.IdGrupo and f.IdGrupo = @IdGrupo 
	order by Familia




GO

/****** Object:  StoredProcedure [dbo].[sel_Grupos]    Script Date: 08/13/2010 11:23:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




CREATE PROCEDURE [dbo].[sel_Grupos]
@IdMarca as bigint,
@Opc as int
AS

if @Opc = 1
	select IdGrupo as 'Clave', Grupo as 'Grupo', Marcas.Marca, Grupos.FechaAlta,
	case Grupos.Status 
		when 'A' then 'Activo'
		else 'Baja'
	end as 'Estatus'
	from Grupos
	inner join Marcas on Marcas.IdMarca = Grupos.IdMarca 
	order by Grupo

if @Opc = 2
	select IdGrupo as 'Clave', Grupo as 'Grupo', Marcas.Marca, Grupos.FechaAlta,
	case Grupos.Status 
		when 'A' then 'Activo'
		else 'Baja'
	end as 'Estatus'
	from Grupos
	inner join Marcas on Marcas.IdMarca = Grupos.IdMarca 
	where Grupos.IdMarca = @IdMarca
	order by Grupo




GO

/****** Object:  StoredProcedure [dbo].[sel_Marcas]    Script Date: 08/13/2010 11:23:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




CREATE PROCEDURE [dbo].[sel_Marcas]
@Opc as int
AS

if @Opc = 1
	select IdMarca as 'Clave', Marca as 'Marca', FechaAlta,
	case Status 
		when 'A' then 'Activo'
		else 'Baja'
	end as 'Estatus'
	from Marcas
	order by Marca

if @Opc = 2
	select Marca as 'Marca', IdMarca as 'Clave'
	from Marcas
	order by Marca




GO

/****** Object:  StoredProcedure [dbo].[up_Familias]    Script Date: 08/13/2010 11:23:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




CREATE PROCEDURE [dbo].[up_Familias]
@IdFamilia as bigint,
@Familia as varchar(200),
@Grupo as bigint,
@Fecha   as datetime,
@Opc as int
AS

if @Opc = 1
begin
	set @IdFamilia = isnull((Select max(IdFamilia) from Familias)+1,1)	
	insert into Familias (idfamilia, familia, idgrupo, fechaalta, status) values (@IdFamilia, @Familia, @Grupo, @Fecha,  'A')
end

if @Opc = 2
	update Familias set Familia = @Familia, IdGrupo = @Grupo, Status = 'A' where IdFamilia = @IdFamilia


if @Opc = 3
	update Familias set Status = 'B' where IdFamilia = @IdFamilia




GO

/****** Object:  StoredProcedure [dbo].[up_Grupos]    Script Date: 08/13/2010 11:23:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




CREATE PROCEDURE [dbo].[up_Grupos]
@IdGrupo as bigint,
@Grupo as varchar(200),
@Fecha as varchar(200),
@IdMarca as bigint,
@Opc as int
AS


if @Opc = 1
begin
	set @IdGrupo = isnull((Select max(IdGrupo) from Grupos)+1,1)	
	insert into Grupos (idgrupo, grupo, fechaalta, status, IdMarca) values (@IdGrupo, @Grupo, @Fecha,  'A', @IdMarca)
end

if @Opc = 2
	update Grupos set Grupo = @Grupo, Status = 'A' where IdGrupo = @IdGrupo


if @Opc = 3
	update Grupos set Status = 'B' where IdGrupo = @IdGrupo




GO

/****** Object:  StoredProcedure [dbo].[up_Marcas]    Script Date: 08/13/2010 11:23:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




CREATE PROCEDURE [dbo].[up_Marcas]
@IdMarca as bigint,
@Marca as varchar(200),
@Fecha as varchar(200),
@Opc as int
AS

if @Opc = 1
begin
	set @IdMarca = isnull((Select max(IdMarca) from Marcas)+1,1)	
	insert into Marcas (idmarca, marca, fechaalta, status) values (@IdMarca, @Marca, @Fecha,  'A')
end

if @Opc = 2
	update Marcas set Marca = @Marca, Status = 'A' where IdMarca = @IdMarca


if @Opc = 3
	update Marcas set Status = 'B' where IdMarca = @IdMarca




GO


