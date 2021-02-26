USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[sel_Devolucion]    Script Date: 10/20/2010 09:28:40 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sel_Devolucion]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sel_Devolucion]
GO

/****** Object:  StoredProcedure [dbo].[sel_DevolucionDetalle]    Script Date: 10/20/2010 09:28:40 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sel_DevolucionDetalle]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sel_DevolucionDetalle]
GO

USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[sel_Devolucion]    Script Date: 10/20/2010 09:28:40 ******/
SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER OFF
GO






CREATE PROCEDURE [dbo].[sel_Devolucion] 
@IdCedis as bigint,
@IdSurtido as bigint,
@Opc as int

AS

if @Opc = 1
	select Devolucion.IdCedis, Devolucion.IdSurtido, Devolucion.IdDevolucion, case Devolucion.Status when 'A' then 'Aplicado' when 'B' then 'Baja' else 'En Proceso' end Status,
	Devolucion.IdCliente as 'No. Cliente', isnull(Clientes.RazonSocial, 'Cliente no encontrado')  as 'Cliente', 
	isnull( ClienteSucursal.CodigoBarras, ' - ') as 'Código de Barras', isnull(ClienteSucursal.NombreSucursal, 0) as NombreSucursal, isnull(ClienteSucursal.IdSucursal, 0) as IdSucursal,
	CalleF + ' ' + NumExteriorF + ' ' + NumInteriorF + '. ' + ColoniaF + ', ' + EntidadF + case CPF when '' then '' when '0' then '' else '. CP ' + CPF end as Domicilio,
	ClienteSucursal.RFC as RFC, Surtidos.Fecha 
	from Devolucion
	inner join Surtidos on Surtidos.IdCedis = Devolucion.IdCedis and Surtidos.IdSurtido = Devolucion.IdSurtido 
	left outer join Clientes on Devolucion.IdCliente = Clientes.IdCliente and Clientes.IdCedis = Devolucion.IdCedis
	left outer join ClienteSucursal on Devolucion.IdCliente = ClienteSucursal.IdCliente and ClienteSucursal.IdCedis = Devolucion.IdCedis and ClienteSucursal.IdSucursal = Devolucion.IdSucursal
	where Devolucion.IdCedis = @IdCedis and Devolucion.IdSurtido = @IdSurtido

if @Opc = 2
	select isnull(MAX(IdDevolucion) + 1, 1)  
	from Devolucion 
	where IdCedis = @IdCedis 

if @Opc = 3
	select IdCedis, IdSurtido, COUNT(IdDevolucion) as Numero
	from Devolucion 
	where IdCedis = @IdCedis and IdSurtido = @IdSurtido and Status <> 'A'
	group by IdCedis, IdSurtido


GO

/****** Object:  StoredProcedure [dbo].[sel_DevolucionDetalle]    Script Date: 10/20/2010 09:28:40 ******/
SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER OFF
GO






CREATE PROCEDURE [dbo].[sel_DevolucionDetalle]
@IdCedis as bigint,
@IdSurtido as bigint,
@IdDevolucion as bigint,
@IdProducto as bigint,
@Opc as int

AS

if @Opc = 1
	select DevolucionDetalle.IdCedis, DevolucionDetalle.IdSurtido, DevolucionDetalle.IdDevolucion, 
	DevolucionDetalle.IdProducto as 'Cve. Prod.', Productos.Producto as 'Producto', 
	DevolucionDetalle.Cantidad as 'Cantidad'
	from DevolucionDetalle
	inner join Productos on DevolucionDetalle.IdProducto = Productos.IdProducto
	where DevolucionDetalle.IdCedis = @IdCedis and DevolucionDetalle.IdSurtido = @IdSurtido
	and DevolucionDetalle.IdDevolucion = @IdDevolucion
	order by DevolucionDetalle.IdProducto

if @Opc = 2
	select Productos.IdProducto as 'Cve. Prod.', Productos.Producto as 'Producto', 
	isnull(DevolucionDetalle.Cantidad,0) as 'Cantidad', Productos.Decimales, PRO.Contenido 
	from Productos 
	inner join Route.dbo.Producto PRO on cast(PRO.ProductoClave as int) = Productos.IdProducto 
	left outer join Route.dbo.ProductoDetalle PRD ON PRO.ProductoClave = PRD.ProductoClave AND PRD.ProductoClave = PRD.ProductoDetClave 
		AND PRD.Factor = 1 and PRO.Contenido = 1
	left outer join DevolucionDetalle on DevolucionDetalle.IdCedis = @IdCedis and DevolucionDetalle.IdSurtido = @IdSurtido
		and DevolucionDetalle.IdDevolucion = @IdDevolucion and DevolucionDetalle.IdProducto = Productos.IdProducto
	where Productos.IdProducto = @IdProducto
	order by Productos.IdProducto


GO


