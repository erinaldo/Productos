USE [RouteADM]
GO
/****** Objeto:  StoredProcedure [dbo].[sel_ComEsquema]    Fecha de la secuencia de comandos: 03/20/2010 14:37:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



ALTER PROCEDURE [dbo].[sel_ComEsquema]
@IdComEsquema as bigint,
@Opc as int

AS

if @Opc = 1
	select IdComEsquema, Nombre as 'Esquema', 
	case Status 
		when 'A' then 'Activo'
		when 'B' then 'Baja'
	end as 'Status', Fecha as 'Fecha de Modificación', Usuario
	from ComEsquema
	order by IdComEsquema





GO
/****** Objeto:  StoredProcedure [dbo].[sel_ComEsquemaCedis]    Fecha de la secuencia de comandos: 03/20/2010 14:37:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



ALTER PROCEDURE [dbo].[sel_ComEsquemaCedis]
@IdComEsquema as bigint,
@Opc as int

AS

if @Opc = 1


	select Cedis.IdCedis, Cedis.Cedis as 'Cedis', 
	case ComEsquemaCedis.Status 
		when 'A' then 'Activo'
		when 'B' then 'Baja'
	end as 'Status', ComEsquemaCedis.Fecha as 'Fecha de Modificación', ComEsquemaCedis.Usuario
	from ComEsquemaCedis
	inner join Cedis on Cedis.IdCedis = ComEsquemaCedis.IdCedis
	where ComEsquemaCedis.IdComEsquema = @IdComEsquema
	order by IdComEsquema

if @Opc = 2
	select Cedis.IdCedis, Cedis.Cedis as 'Cedis'
	from Cedis 
	where IdCedis not in ( select ComEsquemaCedis.IdCedis 
		from ComEsquemaCedis where ComEsquemaCedis.IdComEsquema = @IdComEsquema and ComEsquemaCedis.Status = 'A' )
	order by Cedis





GO
/****** Objeto:  StoredProcedure [dbo].[sel_ComEsquemaFamilia]    Fecha de la secuencia de comandos: 03/20/2010 14:37:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



ALTER PROCEDURE [dbo].[sel_ComEsquemaFamilia]
@IdCedis as bigint,
@IdComEsquema as bigint,
@IdFamilia as varchar(5000),
@IdTipoVendedor as varchar(5000),
@IdConceptoPago as varchar(5000),
@Opc as int

AS

if @Opc = 1
begin 

	if @IdFamilia <> '0' set @IdFamilia = ' and ComEsquemaFamilia.IdFamilia = ' + @IdFamilia 
	else set @IdFamilia = ''

	if @IdTipoVendedor <> '0' set @IdTipoVendedor = ' and TipoVendedor.IdTipoVendedor = ' + @IdTipoVendedor 
	else set @IdTipoVendedor = ''

	if @IdConceptoPago <> '0' set @IdConceptoPago = ' and ComEsquemaRangos.IdConceptoPago = ' + @IdConceptoPago 
	else set @IdConceptoPago = ''

		exec(  'select Familias.IdFamilia, Familias.Familia as ''Familia de Producto'', 
		case IdConceptoPago
			when ''1'' then ( select Etiqueta01 from Configuracion where IdCedis = ' + @IdCedis + ')
			when ''2'' then ( select Etiqueta02 from Configuracion where IdCedis = ' + @IdCedis + ')
			when ''3'' then ''Importe de Venta''
		end as ''Concepto Pago'', ComEsquemaRangos.Inicial, ComEsquemaRangos.Final,
		case ComEsquemaFamilia.Status 
			when ''A'' then ''Activo''
			when ''B'' then ''Baja''
		end as ''Status'', ComEsquemaFamilia.Fecha as ''Fecha de Modificación'', ComEsquemaFamilia.Usuario, ComEsquemaRangos.IdComEsquema, ComEsquemaRangos.IdConceptoPago
		from ComEsquemaFamilia
		inner join Familias on Familias.IdFamilia = ComEsquemaFamilia.IdFamilia
		inner join ComEsquemaRangos on ComEsquemaRangos.IdComEsquema = ComEsquemaFamilia.IdComEsquema and ComEsquemaRangos.IdFamilia = ComEsquemaFamilia.IdFamilia and ComEsquemaRangos.Status = ''A'' ' + @IdConceptoPago + ' 
		where ComEsquemaFamilia.IdComEsquema = ' + @IdComEsquema + ' ' + @IdFamilia + '   
		order by Familias.Familia, ComEsquemaRangos.Inicial')
end
-- TipoVendedor.TipoVendedor, ComEsquemaPagos.Inicial, ComEsquemaPagos.Final, Pago,
-- inner join TipoVendedor on ComEsquemaPagos.IdTipoVendedor = TipoVendedor.IdTipoVendedor ' + @IdTipoVendedor + '  


if @Opc = 2
	select Familias.IdFamilia, Familias.Familia 
	from Familias 
--	where IdFamilia not in ( select ComEsquemaFamilia.IdFamilia 
--		from ComEsquemaFamilia where ComEsquemaFamilia.IdComEsquema = @IdComEsquema and ComEsquemaFamilia.Status = 'A' )
	order by Familia.Familia

if @Opc = 3
	select top 1 IdConceptoPago
	from ComEsquemaRangos 
	where ComEsquemaRangos.IdComEsquema = @IdComEsquema and Status = 'A'
	order by IdConceptoPago

if @Opc = 4
	select top 1 IdCedis as 'IdCedis', '0' as 'IdTipoRuta'
	from ComEsquemaCedis 
	where ComEsquemaCedis.IdComEsquema = @IdComEsquema and Status = 'A'
		union
	select top 1 '0' as 'IdCedis', IdTipoRuta as 'IdTipoRuta'
	from ComEsquemaTipoRuta
	where ComEsquemaTipoRuta.IdComEsquema = @IdComEsquema and Status = 'A'




GO
/****** Objeto:  StoredProcedure [dbo].[sel_ComEsquemaPagos]    Fecha de la secuencia de comandos: 03/20/2010 14:37:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[sel_ComEsquemaPagos]
@IdComEsquema as bigint,
@IdFamilia as bigint,
@IdProducto as bigint,
@IdConceptoPago as bigint,
@Inicial as money,
@Final as money,
@Opc as int

AS

if @Opc = 1
begin
	if @IdFamilia <> '0'
		select TipoVendedor as 'Perfil', Inicial, Final, Pago, FechaAlta, 
		case ComEsquemaPagos.Status
			when 'A' then 'Activo'
			when 'B' then 'Baja' 
		end as 'Status', ComEsquemaPagos.Usuario
		from ComEsquemaPagos 
		inner join TipoVendedor on ComEsquemaPagos.IdTipoVendedor = TipoVendedor.IdTipoVendedor
		where IdComEsquema = @IdComEsquema and IdFamilia = @IdFamilia and IdConceptoPago = @IdConceptoPago and Inicial = @Inicial and Final = @Final and ComEsquemaPagos.Status = 'A'
	else
		select TipoVendedor as 'Perfil', Inicial, Final, Pago, FechaAlta, 
		case ComEsquemaPagos.Status
			when 'A' then 'Activo'
			when 'B' then 'Baja' 
		end as 'Status', ComEsquemaPagos.Usuario
		from ComEsquemaPagos 
		inner join TipoVendedor on ComEsquemaPagos.IdTipoVendedor = TipoVendedor.IdTipoVendedor
		where IdComEsquema = @IdComEsquema and IdProducto = @IdProducto and IdConceptoPago = @IdConceptoPago and Inicial = @Inicial and Final = @Final and ComEsquemaPagos.Status = 'A'
end


GO
/****** Objeto:  StoredProcedure [dbo].[sel_ComEsquemaProducto]    Fecha de la secuencia de comandos: 03/20/2010 14:37:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



ALTER PROCEDURE [dbo].[sel_ComEsquemaProducto]
@IdCedis as bigint,
@IdComEsquema as bigint,
@IdProducto as varchar(5000),
@IdTipoVendedor as varchar(5000),
@IdConceptoPago as varchar(5000),
@Opc as int

AS

if @Opc = 1
begin 

	if @IdProducto <> '0' set @IdProducto = ' and ComEsquemaProducto.IdProducto = ' + @IdProducto 
	else set @IdProducto = ''

	if @IdTipoVendedor <> '0' set @IdTipoVendedor = ' and TipoVendedor.IdTipoVendedor = ' + @IdTipoVendedor 
	else set @IdTipoVendedor = ''

	if @IdConceptoPago <> '0' set @IdConceptoPago = ' and ComEsquemaRangos.IdConceptoPago = ' + @IdConceptoPago 
	else set @IdConceptoPago = ''

		exec( 'select Productos.IdProducto, Productos.Producto as ''Producto'', 
		case IdConceptoPago
			when ''1'' then ( select Etiqueta01 from Configuracion where IdCedis = ' + @IdCedis + ')
			when ''2'' then ( select Etiqueta02 from Configuracion where IdCedis = ' + @IdCedis + ')
			when ''3'' then ''Importe de Venta''
		end as ''Concepto Pago'',  ComEsquemaRangos.Inicial, ComEsquemaRangos.Final, 
		case ComEsquemaProducto.Status 
			when ''A'' then ''Activo''
			when ''B'' then ''Baja''
		end as ''Status'', ComEsquemaProducto.Fecha as ''Fecha de Modificación'', ComEsquemaProducto.Usuario, ComEsquemaRangos.IdComEsquema, ComEsquemaRangos.IdConceptoPago
		from ComEsquemaProducto
		inner join Productos on Productos.IdProducto = ComEsquemaProducto.IdProducto
		inner join ComEsquemaRangos on ComEsquemaRangos.IdComEsquema = ComEsquemaProducto.IdComEsquema and ComEsquemaRangos.IdProducto = ComEsquemaProducto.IdProducto and ComEsquemaRangos.Status = ''A'' ' + @IdConceptoPago + '   
		where ComEsquemaProducto.IdComEsquema = ' + @IdComEsquema + ' ' + @IdProducto + ' 
		order by Productos.IdProducto, ComEsquemaRangos.Inicial')
end

if @Opc = 2
begin

	select Productos.IdProducto, Productos.Producto
	from Productos 
	where Productos.IdProducto = @IdProducto 
	order by Producto.IdProducto

--	if @IdTipoVendedor <> '0' set @IdTipoVendedor = ' and ComEsquemaPago.IdTipoVendedor = ' + @IdTipoVendedor 
--	else set @IdTipoVendedor = ''
--	
--	exec('select Productos.IdProducto, Productos.Producto, isnull(Inicial, 0), isnull(Final, 0), isnull(Pago, 0), 
--		isnull(IdConceptoPago, 0), isnull(IdTipoVendedor)
--	from Productos 
--	left outer join ComEsquemaPago on ComEsquemaPago.IdProducto = Productos.IdProducto 
--		and ComEsquemaPago.IdComEsquema = ' + @IdComEsquema + '  ' + @IdTipoVendedor + ' 
--		and ComEsquemaPago.Status = ''A''
--	where Productos.IdProducto = ' + @IdProducto + '  
--	order by Producto.IdProducto')
end




GO
/****** Objeto:  StoredProcedure [dbo].[sel_ComEsquemaTipoRuta]    Fecha de la secuencia de comandos: 03/20/2010 14:37:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



ALTER PROCEDURE [dbo].[sel_ComEsquemaTipoRuta]
@IdComEsquema as bigint,
@Opc as int

AS

if @Opc = 1


	select TipoRuta.IdTipoRuta, TipoRuta.TipoRuta as 'Especialización de la Ruta', 
	case ComEsquemaTipoRuta.Status 
		when 'A' then 'Activo'
		when 'B' then 'Baja'
	end as 'Status', ComEsquemaTipoRuta.Fecha as 'Fecha de Modificación', ComEsquemaTipoRuta.Usuario
	from ComEsquemaTipoRuta
	inner join TipoRuta on TipoRuta.IdTipoRuta = ComEsquemaTipoRuta.IdTipoRuta
	where ComEsquemaTipoRuta.IdComEsquema = @IdComEsquema
	order by ComEsquemaTipoRuta.IdComEsquema

if @Opc = 2
	select TipoRuta.IdTipoRuta, TipoRuta.TipoRuta 
	from TipoRuta 
	where IdTipoRuta not in ( select ComEsquemaTipoRuta.IdTipoRuta 
		from ComEsquemaTipoRuta where ComEsquemaTipoRuta.IdComEsquema = @IdComEsquema and ComEsquemaTipoRuta.Status = 'A' )
	order by TipoRuta.TipoRuta




USE [RouteADM]
GO
/****** Objeto:  StoredProcedure [dbo].[up_ComEsquema]    Fecha de la secuencia de comandos: 03/20/2010 14:38:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



ALTER PROCEDURE [dbo].[up_ComEsquema]
@IdComEsquema as bigint,
@ComEsquema as varchar(5000),
@Status as char(1),
@Usuario as varchar(5000),
@Opc as int

AS

if @Opc = 1
begin 

	set @IdComEsquema = isnull((select max(IdComEsquema) + 1 from ComEsquema ),1)
	insert into ComEsquema values (@IdComEsquema, @ComEsquema, 'A', getdate(), @Usuario)

end

if @Opc = 2
	update ComEsquema set Nombre = @ComEsquema, Status = @Status, Fecha = getdate(), Usuario = @Usuario
	where IdComEsquema = @IdComEsquema






GO
/****** Objeto:  StoredProcedure [dbo].[up_ComEsquemaCedis]    Fecha de la secuencia de comandos: 03/20/2010 14:38:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[up_ComEsquemaCedis]
@IdComEsquema as bigint,
@IdCedis as bigint,
@Status as char(1),
@Usuario as varchar(50),
@Opc as int

AS

if @Opc = 1
begin 

	if exists(select IdComEsquema from ComEsquemaCedis where IdComEsquema = @IdComEsquema and IdCedis = @IdCedis) 
		update ComEsquemaCedis set Status = @Status, Fecha = getdate(), Usuario = @Usuario
		where IdComEsquema = @IdComEsquema and IdCedis = @IdCedis
	else
		insert into ComEsquemaCedis values (@IdComEsquema, @IdCedis, @Status, getdate(), @Usuario)
end






GO
/****** Objeto:  StoredProcedure [dbo].[up_ComEsquemaPagos]    Fecha de la secuencia de comandos: 03/20/2010 14:38:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[up_ComEsquemaPagos]
@IdComEsquema as bigint,
@IdFamilia as bigint,
@IdProducto as bigint,
@IdConceptoPago as bigint,
@Inicial as money,
@Final as money,
@IdTipoVendedor as bigint,
@Pago as money,
@Status as char(1),
@Usuario as varchar(50),
@Opc as int

AS

if @Opc = 1
begin
	delete from ComEsquemaPagos 
	where IdComEsquema = @IdComEsquema and IdFamilia = @IdFamilia and IdProducto = @IdProducto
		and IdConceptoPago = @IdConceptoPago and Inicial = @Inicial and Final = @Final and IdTipoVendedor = @IdTipoVendedor

	if @Pago > 0 insert into ComEsquemaPagos values (@IdComEsquema, @IdFamilia, @IdProducto, @IdConceptoPago, @Inicial, @Final, @IdTipoVendedor, @Pago, @Status, getdate(), @Usuario)
end


GO
/****** Objeto:  StoredProcedure [dbo].[up_ComEsquemaRangos]    Fecha de la secuencia de comandos: 03/20/2010 14:38:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[up_ComEsquemaRangos]
@IdComEsquema as bigint,
@IdFamilia as bigint,
@IdProducto as bigint,
@IdConceptoPago as bigint,
@Inicial as money,
@Final as money,
@Status as char(1),
@Usuario as varchar(50),
@Opc as int

AS

if @Opc = 1
begin
	delete from ComEsquemaRangos 
	where IdComEsquema = @IdComEsquema and IdFamilia = @IdFamilia and IdProducto = @IdProducto
		and IdConceptoPago = @IdConceptoPago and Inicial = @Inicial and Final = @Final

	if @IdFamilia <> 0 and not exists(select IdComEsquema from ComEsquemaFamilia where IdComEsquema = @IdComEsquema and IdFamilia = @IdFamilia )
		insert into ComEsquemaFamilia values (@IdComEsquema, @IdFamilia, 'A', getdate(), @Usuario)

	if @IdProducto <> 0 and not exists(select IdComEsquema from ComEsquemaProducto where IdComEsquema = @IdComEsquema and IdProducto = @IdProducto )
		insert into ComEsquemaProducto values (@IdComEsquema, @IdProducto, 'A', getdate(), @Usuario)

	insert into ComEsquemaRangos values (@IdComEsquema, @IdFamilia, @IdProducto, @IdConceptoPago, @Inicial, @Final, @Status, getdate(), @Usuario)
end

if @Opc = 2
begin
	update ComEsquemaRangos set Status = 'B', Fecha = getdate(), Usuario = @Usuario
	where IdComEsquema = @IdComEsquema and IdFamilia = @IdFamilia and IdProducto = @IdProducto
		and IdConceptoPago = @IdConceptoPago and Inicial = @Inicial and Final = @Final

	update ComEsquemaPagos set Status = 'B', Fecha = getdate(), Usuario = @Usuario
	where IdComEsquema = @IdComEsquema and IdFamilia = @IdFamilia and IdProducto = @IdProducto
		and IdConceptoPago = @IdConceptoPago and Inicial = @Inicial and Final = @Final
end

if @Opc = 3
begin
	declare @Resultado as varchar(5000), 
		@InicialAnt as money,
		@FinalAnt as money

	set @Resultado = 'Rangos de Pago configurados correctamente.'
	set @InicialAnt = -1
	set @FinalAnt = -1

	declare  ValidaRangos cursor for
		select Inicial, Final
		from ComEsquemaRangos
		where IdComEsquema = @IdComEsquema and IdFamilia = @IdFamilia and IdProducto = @IdProducto
		and IdConceptoPago = @IdConceptoPago and Status = 'A'
	open ValidaRangos
	
	fetch next from ValidaRangos into @Inicial, @Final
	while (@@fetch_status = 0)
	begin
		if @FinalAnt > 0
		begin
			if @Inicial <> @FinalAnt
			set @Resultado = 'Error en los Rangos de Pago. Error entre el Rango Final: ' + cast(@FinalAnt as varchar(30)) + ' y el Inicial: ' + cast(@Inicial as varchar(30)) 
		end
		set @InicialAnt = @Inicial
		set @FinalAnt = @Final
	
		fetch next from ValidaRangos into @Inicial, @Final
	end
	close ValidaRangos
	deallocate ValidaRangos	

	select @Resultado
end





GO
/****** Objeto:  StoredProcedure [dbo].[up_ComEsquemaTipoRuta]    Fecha de la secuencia de comandos: 03/20/2010 14:38:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[up_ComEsquemaTipoRuta]
@IdComEsquema as bigint,
@IdTipoRuta as bigint,
@Status as char(1),
@Usuario as varchar(50),
@Opc as int

AS

if @Opc = 1
begin 

	if exists(select IdComEsquema from ComEsquemaTipoRuta where IdComEsquema = @IdComEsquema and IdTipoRuta = @IdTipoRuta) 
		update ComEsquemaTipoRuta set Status = @Status, Fecha = getdate(), Usuario = @Usuario
		where IdComEsquema = @IdComEsquema and IdTipoRuta = @IdTipoRuta
	else
		insert into ComEsquemaTipoRuta values (@IdComEsquema, @IdTipoRuta, @Status, getdate(), @Usuario)
end





