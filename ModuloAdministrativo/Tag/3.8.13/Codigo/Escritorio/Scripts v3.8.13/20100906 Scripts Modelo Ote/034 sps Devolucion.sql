USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[sel_Ventas]    Script Date: 09/30/2010 15:47:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sel_Devolucion]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sel_Devolucion]
GO

/****** Object:  StoredProcedure [dbo].[sel_VentasDetalle]    Script Date: 09/30/2010 15:47:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sel_DevolucionDetalle]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sel_DevolucionDetalle]
GO

USE [RouteADM]
GO


/****** Object:  StoredProcedure [dbo].[sel_Devolucion]    Script Date: 09/30/2010 15:47:06 ******/
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
	isnull( ClienteSucursal.CodigoBarras, ' - ') as 'Código de Barras', isnull(ClienteSucursal.NombreSucursal, 0) as NombreSucursal, isnull(ClienteSucursal.IdSucursal, 0) as IdSucursal
	from Devolucion
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

/****** Object:  StoredProcedure [dbo].[sel_DevolucionDetalle]    Script Date: 09/30/2010 15:47:07 ******/
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

Go

USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[up_Devolucion]    Script Date: 09/30/2010 20:07:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[up_Devolucion]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[up_Devolucion]
GO

/****** Object:  StoredProcedure [dbo].[up_DevolucionDetalle]    Script Date: 09/30/2010 20:07:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[up_DevolucionDetalle]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[up_DevolucionDetalle]
GO

USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[up_Devolucion]    Script Date: 09/30/2010 20:07:49 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO





CREATE PROCEDURE [dbo].[up_Devolucion] 
@IdCedis as bigint,
@IdSurtido as bigint,
@IdDevolucion as bigint,
@IdCliente as bigint,
@IdSucursal as varchar(16),
@Status as char(1),
@Opc as int

AS

declare @IdTipoMovimiento as bigint, @IdMovimiento as bigint, @Dia as datetime
declare @IdCarga as bigint, @IdRuta as bigint, @Cantidad as money, @IdProducto as bigint

if @Opc = 1 
begin
	
	select @IdDevolucion = isnull(MAX(IdDevolucion) + 1, 1)  
	from Devolucion 
	where IdCedis = @IdCedis 

	insert into Devolucion values (@IdCedis, @IdSurtido, @IdDevolucion, @IdCliente, @IdSucursal, 'P')	

end

if @Opc = 2 
begin
	
	select @Dia = Fecha, @IdRuta = IdRuta from Surtidos where IdCedis = @IdCedis and IdSurtido = @IdSurtido 
	SET @IdTipoMovimiento = (select TOP 1 IdMovimientoDevoluciones from Configuracion where RouteADM.dbo.Configuracion.IdCedis = @IdCedis )

	if not exists(Select * from RouteADM.dbo.Movimientos where IdCedis = @IdCedis and Fecha = @Dia and IdTipoMovimiento = @IdTipoMovimiento)
	begin
		 set @IdMovimiento = isnull((select Max(IdMovimiento) + 1 from Movimientos where IdCedis = @IdCedis ),1)
		 insert into RouteADM.dbo.Movimientos values(@IdCedis, @IdMovimiento, @Dia, @IdTipoMovimiento  ,'','','A')
	end
	else
		 set @IdMovimiento = (select IdMovimiento from RouteADM.dbo.Movimientos where IdCedis = @IdCedis and Fecha = @Dia and IdTipoMovimiento = @IdTipoMovimiento)

	set @IdCarga = isnull( (select max( IdCarga ) from Cargas where IdCedis = @IdCedis and IdSurtido = @IdSurtido and Status = 'A'), 1)	
	if exists ( select IdProducto from SurtidosCargas where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdCarga = @IdCarga ) 
	begin
		set @IdCarga = isnull( (select max( IdCarga ) from Cargas where IdCedis = @IdCedis and IdSurtido = @IdSurtido and Status = 'A') + 1 , 1)	
		insert into Cargas values (@IdCedis, @IdSurtido, @IdCarga, @IdRuta, @Dia, 'A')
	end 	

	DECLARE Devolucion_Cursor CURSOR FOR
	select IdProducto, Cantidad from DevolucionDetalle where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdDevolucion = @IdDevolucion

	OPEN Devolucion_Cursor;

	FETCH NEXT FROM Devolucion_Cursor
	into @IdProducto, @Cantidad
	WHILE @@FETCH_STATUS = 0
	BEGIN

		exec up_SurtidosCargas @IdCedis, @IdSurtido, @IdCarga, @IdProducto, @Dia, @Cantidad, 1 

		 if exists (select IdProducto from MovimientosDetalle where IdCedis = @IdCedis and IdMovimiento = @IdMovimiento and IdProducto = @IdProducto ) 
			   update RouteADM.dbo.MovimientosDetalle set Cantidad = cast(Cantidad as decimal(19,4)) + cast(@Cantidad as decimal(19,4)) where IdCedis = @IdCedis and IdMovimiento = @IdMovimiento and IdProducto = @IdProducto 
		 else
			   insert into RouteADM.dbo.MovimientosDetalle values(@IdCedis, @IdMovimiento, @IdProducto, cast(@Cantidad as decimal(19,4)), '')

		FETCH NEXT FROM Devolucion_Cursor
		into @IdProducto, @Cantidad
	END

	CLOSE Devolucion_Cursor
	DEALLOCATE Devolucion_Cursor
	
	update Devolucion set Status = @Status 
	where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdDevolucion = @IdDevolucion
end

if @Opc = 3 
begin

	delete from DevolucionDetalle where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdDevolucion = @IdDevolucion
	delete from Devolucion where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdDevolucion = @IdDevolucion

end

if @Opc = 4
begin

	DECLARE Devolucion_Cursor CURSOR FOR
		select Devolucion.IdSucursal, IdProducto, sum(DevolucionDetalle.Cantidad)
		from Devolucion 
		inner join ClienteSucursal on ClienteSucursal.IdCedis = Devolucion.IdCedis and ClienteSucursal.IdSucursal = Devolucion.IdSucursal 
		inner join DevolucionDetalle on Devolucion.IdCedis = DevolucionDetalle.IdCedis and Devolucion.IdSurtido = DevolucionDetalle.IdSurtido
			and Devolucion.IdDevolucion = DevolucionDetalle.IdDevolucion  
		where Devolucion.IdCedis = @IdCedis and Devolucion.IdSurtido = @IdSurtido and Devolucion.Status = 'A'
		group by Devolucion.IdSucursal, IdProducto
		order by IdProducto

	OPEN Devolucion_Cursor;

	FETCH NEXT FROM Devolucion_Cursor
	into @IdSucursal, @IdProducto, @Cantidad
	WHILE @@FETCH_STATUS = 0
	BEGIN

		if not exists(select * from Route.dbo.ProductoPrestamoCli where ClienteClave = @IdSucursal and cast(ProductoClave as bigint) = @IdProducto )
			insert into	Route.dbo.ProductoPrestamoCli values (@IdSucursal, REPLICATE('0',2-len(@IdProducto)) + CAST(@IdProducto as varchar(10)), @Cantidad * -1, GETDATE(), 'Interfaz' )
		else		
			update Route.dbo.ProductoPrestamoCli 
				set Saldo = Saldo - @Cantidad, MFechaHora = GETDATE(), MUsuarioID = 'Interfaz'
			where ClienteClave = @IdSucursal and cast(ProductoClave as bigint) = @IdProducto 

		FETCH NEXT FROM Devolucion_Cursor
		into @IdSucursal, @IdProducto, @Cantidad
	END

	CLOSE Devolucion_Cursor
	DEALLOCATE Devolucion_Cursor

end



GO

/****** Object:  StoredProcedure [dbo].[up_DevolucionDetalle]    Script Date: 09/30/2010 20:07:49 ******/
SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[up_DevolucionDetalle]
@IdCedis as bigint,
@IdSurtido as bigint,
@IdDevolucion as bigint,
@IdProducto as bigint,
@Cantidad as float,
@Opc as int

AS

if @Opc = 1 -- Actualiza Partida de Factura
begin

	delete from DevolucionDetalle where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdDevolucion = @IdDevolucion and IdProducto = @IdProducto
	if @Cantidad <> 0 
		insert into DevolucionDetalle values (@IdCedis, @IdSurtido, @IdDevolucion, @IdProducto, @Cantidad)

end

GO


