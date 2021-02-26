USE [RouteADM]
GO
/****** Objeto:  StoredProcedure [dbo].[sel_ComEsquemaProducto]    Fecha de la secuencia de comandos: 03/15/2010 11:04:34 ******/
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
		end as ''Status'', ComEsquemaProducto.Fecha as ''Fecha de Modificación'', ComEsquemaProducto.Usuario
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



USE [RouteADM]
GO
/****** Objeto:  StoredProcedure [dbo].[sel_ComEsquemaFamilia]    Fecha de la secuencia de comandos: 03/15/2010 11:04:54 ******/
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
		end as ''Status'', ComEsquemaFamilia.Fecha as ''Fecha de Modificación'', ComEsquemaFamilia.Usuario
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
	from ComEsquemaPagos 
	where ComEsquemaPagos.IdComEsquema = @IdComEsquema and Status = 'A'
	order by IdConceptoPago

if @Opc = 4
	select top 1 IdCedis as 'IdCedis', '0' as 'IdTipoRuta'
	from ComEsquemaCedis 
	where ComEsquemaCedis.IdComEsquema = @IdComEsquema and Status = 'A'
		union
	select top 1 '0' as 'IdCedis', IdTipoRuta as 'IdTipoRuta'
	from ComEsquemaTipoRuta
	where ComEsquemaTipoRuta.IdComEsquema = @IdComEsquema and Status = 'A'



