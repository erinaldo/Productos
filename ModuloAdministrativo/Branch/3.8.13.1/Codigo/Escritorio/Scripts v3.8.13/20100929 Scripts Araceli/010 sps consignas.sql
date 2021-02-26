USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[sel_Consignas]    Script Date: 09/23/2010 16:08:32 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sel_Consignas]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sel_Consignas]
GO

/****** Object:  StoredProcedure [dbo].[sel_ConsignasDetalle]    Script Date: 09/23/2010 16:08:32 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sel_ConsignasDetalle]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sel_ConsignasDetalle]
GO

/****** Object:  StoredProcedure [dbo].[up_Consignas]    Script Date: 09/23/2010 16:08:33 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[up_Consignas]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[up_Consignas]
GO

/****** Object:  StoredProcedure [dbo].[up_ConsignasDetalle]    Script Date: 09/23/2010 16:08:33 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[up_ConsignasDetalle]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[up_ConsignasDetalle]
GO

USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[sel_Consignas]    Script Date: 09/23/2010 16:08:33 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO








CREATE PROCEDURE [dbo].[sel_Consignas]
@IdCedis as bigint,
@IdConsigna as bigint,
@IdSurtido as bigint,
@CadenaStatus as varchar(50),
@Opc as int

AS
Declare @IdCliente as bigint
Declare @IdRuta as bigint
declare @IdLista as bigint

-- Busca a nivel Cliente

if @Opc = 0		-- Obtiene el folio de la consigna
begin
	Select isnull(max(IdConsigna),0)+1 as IdConsigna from Consignas where  IdCedis = @IdCedis
end

if @Opc = 1		-- Busqueda de una consigna en especifico
Begin
	SELECT  CON.IdCedis, CON.IdConsigna, CON.IdCliente, CON.IdSucursal, CON.IdRutaEntrega, CON.IdSurtidoEntrega, 
			CON.FechaEntrega, ISNULL(CON.IdMovimientoEntrega, 0) AS IdMovimientoEntrega, 
			ISNULL(CON.IdRutaDevolucion, 0) AS IdRutaDevolucion, ISNULL(CON.IdSurtidoDevolucion, 0) AS IdSurtidoDevolucion, 
			CON.FechaDevolucion, ISNULL(CON.IdMovimientoDevolucion, 0) AS IdMovimientoDevolucion, 
			ISNULL(CON.Observaciones, '') AS Observaciones, CON.Status AS StatusConsigna, 
			CAST(CASE CON.Status 
				WHEN 'P' THEN 'En Proceso de Registro'				-- Tiene encabezado pero no productos registrados
				WHEN 'R' THEN 'Registrada'							-- Esta registrada, aun en dia abierto
				WHEN 'E' THEN 'En Consigna, Pendiente por Devolver' -- Esta registrada, en dia cerrado y queda pendiente por devolver
				WHEN 'D' THEN 'Devolución y Venta Registradas'		-- Tiene Devoluciones y Ventas registradas, aun en dia abierto
				WHEN 'V' THEN 'Consigna Cerrada'					-- Tiene Devoluciones y Ventas registradas, ya en dia cerrado y no se permiten cambios
				WHEN 'C' THEN 'Consigna Cancelada'					-- Consigna Cancelada
			END AS char(50)) AS DescripcionStatus, 
			CLI.RazonSocial as NombreCliente, CLISUC.NombreSucursal, -- @IdLista, AS IdListaCliente
			isnull(CON.Serie,'') as Serie, isnull(CON.Folio,0) as Folio
	FROM	Consignas AS CON LEFT OUTER JOIN
		  Clientes AS CLI ON CON.IdCedis = CLI.IdCedis AND CON.IdCliente = CLI.IdCliente LEFT OUTER JOIN
		  ClienteSucursal AS CLISUC ON CON.IdCedis = CLISUC.IdCedis AND CON.IdSucursal = CLISUC.IdSucursal AND 
		  CON.IdCliente = CLISUC.IdCliente	
	where	CON.IdCedis = @IdCedis and CON.IdConsigna = @IdConsigna

end

if @Opc = 2		-- Busqueda de una consignas de una ruta y surtido en especifico
Begin
	SELECT	CON.IdConsigna as [Num. Consigna],
			CAST(CASE CON.Status 
				WHEN 'P' THEN 'En Proceso de Registro' 
				WHEN 'R' THEN 'Consigna Registrada' 
				WHEN 'E' THEN 'En Consigna, Pendiente por Devolver'
				WHEN 'D' THEN 'Devolución y Venta Registradas' 
				WHEN 'V' THEN 'Consigna Cerrada' 
				WHEN 'C' THEN 'Consigna Cancelada' 
			END AS char(50)) AS Estatus, 
			cast (CON.IdCliente as varchar(10)) + ' - ' + CLI.RazonSocial AS Cliente, CON.IdSucursal + ' - ' + CLISUC.NombreSucursal as Sucursal, 
			isnull(CON.Serie + '-' + cast(CON.Folio as varchar(10)),'') as Factura, CON.IdCedis, CON.IdRutaEntrega, CON.IdSurtidoEntrega, ISNULL(CON.IdMovimientoEntrega, 0) AS IdMovimientoEntrega,
			ISNULL(CON.IdRutaDevolucion, 0) AS IdRutaDevolucion, ISNULL(CON.IdSurtidoDevolucion, 0) AS IdSurtidoDevolucion,
			ISNULL(CON.IdMovimientoDevolucion, 0) AS IdMovimientoDevolucion, ISNULL(CON.Observaciones, '') AS Observaciones,
			CON.Status AS StatusConsigna, CON.FechaEntrega, CON.FechaDevolucion
	FROM    Consignas AS CON LEFT OUTER JOIN
			Clientes AS CLI ON CON.IdCedis = CLI.IdCedis AND CON.IdCliente = CLI.IdCliente LEFT OUTER JOIN
			ClienteSucursal AS CLISUC ON CON.IdCedis = CLISUC.IdCedis AND CON.IdSucursal = CLISUC.IdSucursal AND 
			CON.IdCliente = CLISUC.IdCliente
	WHERE	(((CON.IdCedis = @IdCedis) AND (CON.IdSurtidoEntrega = @IdSurtido)) OR ((CON.IdCedis = @IdCedis) AND (CON.IdSurtidoDevolucion = @IdSurtido)))
			and (CON.Status in ('P','R','E','D','V'))
end

if @Opc = 3		-- Busqueda de una consignas por Devolver
Begin
	SELECT	CON.IdConsigna as [Num. Consigna],
			CAST(CASE CON.Status 
				WHEN 'P' THEN 'En Proceso de Registro' 
				WHEN 'R' THEN 'Consigna Registrada' 
				WHEN 'E' THEN 'En Consigna, Pendiente por Devolver'
				WHEN 'D' THEN 'Devolución y Venta Registradas' 
				WHEN 'V' THEN 'Consigna Cerrada' 
				WHEN 'C' THEN 'Consigna Cancelada' 
			END AS char(50)) AS Estatus, 
			cast (CON.IdCliente as varchar(10)) + ' - ' + CLI.RazonSocial AS Cliente, CON.IdSucursal + ' - ' + CLISUC.NombreSucursal as Sucursal, 
			cast (CON.IdRutaEntrega as varchar(10)) + cast(CON.IdSurtidoEntrega as varchar(10)) as [Ruta y Surtido de Entrega], 
			CON.FechaEntrega as [Fecha de Entrega], CON.IdCedis, ISNULL(CON.IdMovimientoEntrega, 0) AS IdMovimientoEntrega,
			ISNULL(CON.IdRutaDevolucion, 0) AS IdRutaDevolucion, ISNULL(CON.IdSurtidoDevolucion, 0) AS IdSurtidoDevolucion,
			ISNULL(CON.IdMovimientoDevolucion, 0) AS IdMovimientoDevolucion, ISNULL(CON.Observaciones, '') AS Observaciones,
			CON.Status AS StatusConsigna, CON.FechaDevolucion, isnull(CON.Serie + '-' + cast(CON.Folio as varchar(10)),'') as Factura
	FROM    Consignas AS CON LEFT OUTER JOIN
			Clientes AS CLI ON CON.IdCedis = CLI.IdCedis AND CON.IdCliente = CLI.IdCliente LEFT OUTER JOIN
			ClienteSucursal AS CLISUC ON CON.IdCedis = CLISUC.IdCedis AND CON.IdSucursal = CLISUC.IdSucursal AND 
			CON.IdCliente = CLISUC.IdCliente
	WHERE	(CON.IdCedis = @IdCedis) AND CON.Status = 'E'
end


if @Opc = 4		-- Busqueda de una consignas de una ruta y surtido en especifico, y por status
Begin
	execute ('SELECT	CON.IdConsigna as [Num. Consigna],
			CAST(CASE CON.Status 
				WHEN ''P'' THEN ''En Proceso de Registro'' 
				WHEN ''R'' THEN ''Consigna Registrada'' 
				WHEN ''E'' THEN ''En Consigna, Pendiente por Devolver''
				WHEN ''D'' THEN ''Devolución y Venta Registradas'' 
				WHEN ''V'' THEN ''Consigna Cerrada'' 
				WHEN ''C'' THEN ''Consigna Cancelada'' 
			END AS char(50)) AS Estatus, 
			cast (CON.IdCliente as varchar(10)) + '' - '' + CLI.RazonSocial AS Cliente, CON.IdSucursal + '' - '' + CLISUC.NombreSucursal as Sucursal, 
			cast (CON.IdRutaEntrega as varchar(10)) + '' - '' + cast(CON.IdSurtidoEntrega as varchar(10)) as [Ruta y Surtido de Entrega], 
			CON.FechaEntrega as [Fecha de Entrega], CON.IdCedis, ISNULL(CON.IdMovimientoEntrega, 0) AS IdMovimientoEntrega,
			ISNULL(CON.IdRutaDevolucion, 0) AS IdRutaDevolucion, ISNULL(CON.IdSurtidoDevolucion, 0) AS IdSurtidoDevolucion,
			ISNULL(CON.IdMovimientoDevolucion, 0) AS IdMovimientoDevolucion, ISNULL(CON.Observaciones, '''') AS Observaciones,
			CON.Status AS StatusConsigna, CON.FechaDevolucion, isnull(CON.Serie + '' - '' + cast(CON.Folio as varchar(10)),'''') as Factura
	FROM    Consignas AS CON LEFT OUTER JOIN
			Clientes AS CLI ON CON.IdCedis = CLI.IdCedis AND CON.IdCliente = CLI.IdCliente LEFT OUTER JOIN
			ClienteSucursal AS CLISUC ON CON.IdCedis = CLISUC.IdCedis AND CON.IdSucursal = CLISUC.IdSucursal AND 
			CON.IdCliente = CLISUC.IdCliente
	WHERE	(((CON.IdCedis = ' + @IdCedis + ') AND (CON.IdSurtidoEntrega = ' + @IdSurtido + ')) OR 
			((CON.IdCedis = ' + @IdCedis + ') AND (CON.IdSurtidoDevolucion = ' + @IdSurtido + ')))
			and (CON.Status in (' + @CadenaStatus + '))')
end

if @Opc = 5		-- Busqueda de una consignas de una ruta y surtido en especifico, y por status
Begin
	execute ('SELECT	CON.IdConsigna,
			CAST(CASE CON.Status 
				WHEN ''P'' THEN ''En Proceso de Registro'' 
				WHEN ''R'' THEN ''Consigna Registrada'' 
				WHEN ''E'' THEN ''En Consigna, Pendiente por Devolver''
				WHEN ''D'' THEN ''Devolución y Venta Registradas'' 
				WHEN ''V'' THEN ''Consigna Cerrada'' 
				WHEN ''C'' THEN ''Consigna Cancelada'' 
			END AS char(50)) AS Estatus, 
			cast (CON.IdCliente as varchar(10)) + '' - '' + CLI.RazonSocial AS Cliente, CON.IdSucursal + '' - '' + CLISUC.NombreSucursal as Sucursal, 
			CON.IdRutaEntrega, CON.IdSurtidoEntrega, CON.FechaEntrega, CON.IdCedis, ISNULL(CON.IdMovimientoEntrega, 0) AS IdMovimientoEntrega,
			ISNULL(CON.IdRutaDevolucion, 0) AS IdRutaDevolucion, ISNULL(CON.IdSurtidoDevolucion, 0) AS IdSurtidoDevolucion,
			ISNULL(CON.IdMovimientoDevolucion, 0) AS IdMovimientoDevolucion, ISNULL(CON.Observaciones, '''') AS Observaciones,
			CON.Status AS StatusConsigna, CON.FechaDevolucion, isnull(CON.Serie + ''-'' + cast(CON.Folio as varchar(10)),'''') as Factura
	FROM    Consignas AS CON LEFT OUTER JOIN
			Clientes AS CLI ON CON.IdCedis = CLI.IdCedis AND CON.IdCliente = CLI.IdCliente LEFT OUTER JOIN
			ClienteSucursal AS CLISUC ON CON.IdCedis = CLISUC.IdCedis AND CON.IdSucursal = CLISUC.IdSucursal AND 
			CON.IdCliente = CLISUC.IdCliente
	WHERE	(((CON.IdCedis = ' + @IdCedis + ') AND (CON.IdSurtidoEntrega = ' + @IdSurtido + ')) OR 
			((CON.IdCedis = ' + @IdCedis + ') AND (CON.IdSurtidoDevolucion = ' + @IdSurtido + ')))
			and (CON.Status in (' + @CadenaStatus + '))')
end




GO

/****** Object:  StoredProcedure [dbo].[sel_ConsignasDetalle]    Script Date: 09/23/2010 16:08:34 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[sel_ConsignasDetalle]
@IdCedis as bigint,
@IdConsigna as bigint,
@IdProducto as bigint,
@Opc as int
AS
declare @IdFamiliaRejas as bigint


if @Opc = 2		-- checa existencia de producto para el caso de devolucion de consigna
begin		
		/*
        set @IdFamiliaRejas = ( select isnull(idfamiliarejas,0) as Reja from productos left outer join configuracion on idfamilia = idfamiliarejas where idproducto = @IdProducto )

        if @IdFamiliaRejas <> 0  -- producto reja
		begin
                --checar como se usara el concepto de REJAS
				select * from consignas
		end
        else -- producto no reja
		*/

		begin
			SELECT  CON.IdCedis, CON.IdProducto, PROD.Producto, CON.Surtido, 
					CON.Devolucion, CON.Surtido - CON.Devolucion as Existencias, CON.Venta, CON.Precio, CON.SubTotal AS 'Subtotal',
					CON.Surtido * CON.Precio * CON.Iva AS 'Iva', CON.Total, PROD.Decimales
			FROM    ConsignasDetalle AS CON INNER JOIN
					Productos AS PROD ON CON.IdProducto = PROD.IdProducto
			WHERE   (CON.IdCedis = @IdCedis) AND (CON.IdConsigna = @IdConsigna) AND (CON.IdProducto = @IdProducto)
			ORDER BY CAST(CON.IdProducto AS bigint)
		end
end

If @Opc = 3	
Begin
	
	SELECT  CON.IdCedis, CON.IdProducto AS 'Cve. Producto', PROD.Producto, CON.Surtido, 
			CON.Devolucion as Devolución, CON.Venta, CON.Precio, CON.IVA, CON.Venta * (CON.Precio * (1 + CON.Iva)) as 'Venta Total', 
			CON.Surtido - CON.Devolucion as Existencias, CON.Venta * CON.Precio as Subtotal, CON.Venta * (CON.Precio * (CON.Iva)) as IvaCobrado
	FROM    ConsignasDetalle AS CON INNER JOIN
			Productos AS PROD ON CON.IdProducto = PROD.IdProducto
	WHERE   (CON.IdCedis = @IdCedis) AND (CON.IdConsigna = @IdConsigna) AND (CON.Surtido > 0)
	ORDER BY CAST(CON.IdProducto AS bigint)

End

If @Opc = 4	--trae la informacion de los productos relacionados con una consigna (caso de devoluciones)
Begin

	SELECT  CON.IdCedis, CON.IdProducto AS 'Cve. Producto', PROD.Producto, CON.Surtido, 
			CON.Surtido - CON.Venta as 'Por Devolver', CON.Venta, CON.Precio, 
			CON.IVA, CON.Venta * (CON.Precio * (1 + CON.Iva)) as 'Venta Total', CON.Devolucion as Devolución,
			CON.Venta * CON.Precio as Subtotal, CON.Venta * (CON.Precio * (CON.Iva)) as IvaCobrado
	FROM    ConsignasDetalle AS CON INNER JOIN
			Productos AS PROD ON CON.IdProducto = PROD.IdProducto
	WHERE   (CON.IdCedis = @IdCedis) AND (CON.IdConsigna = @IdConsigna) AND (CON.Surtido > 0)
	ORDER BY CAST(CON.IdProducto AS bigint)

End





GO

/****** Object:  StoredProcedure [dbo].[up_ConsignasDetalle]    Script Date: 09/23/2010 16:08:34 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO








GO

/****** Object:  StoredProcedure [dbo].[up_ConsignasDetalle]    Script Date: 09/23/2010 16:08:34 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[up_ConsignasDetalle] 
@IdCedis as bigint,
@IdCliente as bigint,
@IdRutaOrigen as bigint,
@IdSurtidoOrigen as bigint,
@IdConsigna as bigint,
@IdProducto as bigint,
@Surtido as float,
@Venta as float,
@Opc as int

AS

declare 
@SurtidoAnterior as float,
@Precio as money,
@IVA as money,
@IdLista as bigint

--obtener el precio de venta del producto para varios casos, agregar nuevo producto a la consigna o actualizar precio
-- Busca a nivel Cliente
set @IdLista = isnull((Select IdLista from PreciosListaCliente where IdCedis = @IdCedis and IdCliente = @IdCliente),0)
set @Precio =  isnull((Select Precio from PreciosDetalle where IdLista = @IdLista and IdProducto = @IdProducto),0)

if @Precio=0
begin
	-- Busca a nivel ruta
	set @IdLista = isnull((Select IdLista from PreciosListaRuta where IdCedis = @IdCedis and IdRuta = @IdRutaOrigen),0)
	set @Precio =  isnull((Select Precio from PreciosDetalle where IdLista = @IdLista and IdProducto = @IdProducto),0)	
	if @Precio=0
	begin
		-- contado
		set @IdLista = isnull((select PreciosListaCedis.IdLista from PreciosListaCedis 
			inner join PreciosLista on PreciosListaCedis.IdLista = PreciosLista.IdLista and TipoLista='BA'
			where PreciosListaCedis.idcedis = @IdCedis),0)
		set @Precio =  isnull((Select Precio from PreciosDetalle where IdLista = @IdLista and IdProducto = @IdProducto),0)	
	end
end

set @Iva = isnull( (select Iva from Productos where IdProducto = @IdProducto), 0)

if @Opc = 1			-- Registro de Consigna
begin
	set @SurtidoAnterior = isnull( (select Surtido from ConsignasDetalle where IdCedis = @IdCedis and IdConsigna = @IdConsigna and IdProducto = @IdProducto ), 0)
			
	if @SurtidoAnterior = 0 and @Surtido <> 0 
		begin
			delete from ConsignasDetalle where IdCedis = @IdCedis and IdConsigna= @IdConsigna and IdProducto = @IdProducto
			
			insert into ConsignasDetalle (IdCedis, IdConsigna, IdProducto, Surtido, Devolucion, Venta, Precio, Iva)
			values (@IdCedis, @IdConsigna, @IdProducto, @Surtido, 0, 0, @Precio, @Iva)
		end
	else
		begin
			update ConsignasDetalle set Surtido = @Surtido, Precio = @Precio, Iva = @Iva where IdCedis = @IdCedis and IdConsigna = @IdConsigna and IdProducto = @IdProducto
			if @Surtido = 0 delete from ConsignasDetalle where IdCedis = @IdCedis and Idconsigna = @IdConsigna and IdProducto = @IdProducto
		end
end

if @Opc = 2			-- Registro de Devolucion de Consigna
begin
	update ConsignasDetalle set Venta = @Venta, Devolucion = Surtido - @Venta
	where IdCedis = @IdCedis and IdConsigna = @IdConsigna and IdProducto = @IdProducto
end

if @Opc = 3			-- Actualiza el precio de venta del producto cuando se cambia de cliente en el registro de consigna
begin
	update ConsignasDetalle set Precio = @Precio, Iva = @Iva
	where IdCedis = @IdCedis and IdConsigna = @IdConsigna and IdProducto = @IdProducto
end



GO



GO

/****** Object:  StoredProcedure [dbo].[up_Consignas]    Script Date: 09/23/2010 16:08:34 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[up_Consignas]
@IdCedis as bigint,
@IdConsigna as bigint,
@IdCliente as bigint,
@IdSucursal as varchar(16),
@IdRutaEntrega as bigint,
@IdSurtidoEntrega as bigint,
@FechaEntrega as datetime,
@IdMovimientoEntrega as bigint,
@IdRutaDevolucion as bigint,
@IdSurtidoDevolucion as bigint,
@FechaDevolucion as datetime,
@IdMovimientoDevolucion as bigint,
@Folio as bigint,
@Serie as varchar(5),
@Observaciones as varchar(5000),
@Status as char(1),
@Opc as int

AS

declare @IdProducto as bigint,
@Surtido as float,
@Devolucion as float,
@Venta as float,
@Precio as money,
@Iva as money,
@SurtidoExiste as float,
@FolioInicial as bigint,
@IdTipoVenta as int,
@TVenta as int,
@IdMovimiento as bigint,
@IdCarga as bigint

if @Opc = 1
begin

	--declare @FilaInsertada table (IdCedis bigint, IdConsigna bigint);

	-- Generar el registro de la consigna
	--set @IdConsigna = isnull((Select max(IdConsigna) from Consignas where  IdCedis = @IdCedis) + 1, 1)	
	
	insert into Consignas (IdCedis, IdConsigna, IdCliente, IdSucursal, IdRutaEntrega, IdSurtidoEntrega, 
				FechaEntrega, FechaDevolucion, Observaciones, Status)
	--Output INSERTED.IdCedis, INSERTED.IdConsigna into @FilaInsertada
	values (@IdCedis, @IdConsigna, @IdCliente, @IdSucursal, @IdRutaEntrega, @IdSurtidoEntrega, 
			@FechaEntrega, @FechaDevolucion ,@Observaciones, @Status)

	--select IdCedis, IdConsigna from @FilaInsertada

end

if @Opc = 2		--cambios en la asignacion del cliente para la consigna
Begin

	update Consignas set IdCliente = @IdCliente, IdSucursal = @IdSucursal, 
						FechaDevolucion = @FechaDevolucion, Observaciones = @Observaciones
	where IdCedis = @IdCedis and IdConsigna = @IdConsigna

	--actualizar los nuevos precios de la consigna al cambio de cliente
	DECLARE Consignas_Cursor CURSOR FOR
	select IdProducto, surtido, Devolucion, Venta, Precio, Iva from ConsignasDetalle where idCedis = @IdCedis and Idconsigna = @IdConsigna

	OPEN Consignas_Cursor;

	FETCH NEXT FROM Consignas_Cursor
	into @IdProducto, @Surtido, @Devolucion, @Venta, @Precio, @Iva
	WHILE @@FETCH_STATUS = 0
	BEGIN
		-- Actualizacion de precio
		execute up_ConsignasDetalle @IdCedis,@IdCliente,@IdRutaEntrega,@IdSurtidoEntrega,@IdConsigna,@IdProducto,0,0,3

		FETCH NEXT FROM Consignas_Cursor
		into @IdProducto, @Surtido, @Devolucion, @Venta, @Precio, @Iva
	END

	CLOSE Consignas_Cursor
	DEALLOCATE Consignas_Cursor

End

if @Opc = 3		-- Cambia el Status de la consigna
begin
	-- 'P' a 'R' una vez que se guarda una consigna, para generar los movimientos de surtidos, kardex y almacen
	-- 'R' a 'E' una vez que se cierra la ruta
	-- 'E' a 'D' una vez que se comienza a registrar la devolución de la consinga
	-- 'D' a 'V' una vez que se aplica la liquidacion de un surtido donde se devolvio la consigna
	-- 'P','R' a 'C' al cancelar un registro de Consigna
	-- 'D' a 'S' al cancelar una devolucion de Consigna

	If @Status = 'R'
	Begin
		-- Generar registro de movimientos en surtidos, kardex y almacen
        -- incrementar la devolucion buena del producto en la ruta que liquida la consigna
        -- incrementar la columna de devolucion buena del producto en el kardex de inventario
		DECLARE Consignas_Cursor CURSOR FOR
		select IdProducto, surtido, Devolucion, Venta, Precio, Iva from ConsignasDetalle where idCedis = @IdCedis and Idconsigna = @IdConsigna

		OPEN Consignas_Cursor;

		FETCH NEXT FROM Consignas_Cursor
		into @IdProducto, @Surtido, @Devolucion, @Venta, @Precio, @Iva
		WHILE @@FETCH_STATUS = 0
		BEGIN
			-- incrementar la devolucion buena del producto en la ruta que liquida la consigna
			set @SurtidoExiste = isnull((select Surtido from SurtidosDetalle 
								where IdCedis = @IdCedis and IdSurtido = @IdSurtidoEntrega and IdProducto = @IdProducto ),0)
			if @SurtidoExiste = 0
				Begin
					delete from SurtidosDetalle where IdCedis = @IdCedis and IdSurtido = @IdSurtidoEntrega and IdProducto = @IdProducto 
					insert into SurtidosDetalle values (@IdCedis, @IdSurtidoEntrega, @IdProducto, @FechaEntrega, @Surtido, 0, 0, 0, 0, 0, @Precio, @Iva)
				End
			Else
				Begin
					update surtidosdetalle set DevBuena = DevBuena + @Surtido
					where IdCedis = @IdCedis and IdSurtido = @IdSurtidoEntrega and IdProducto = @IdProducto
				End

			FETCH NEXT FROM Consignas_Cursor
			into @IdProducto, @Surtido, @Devolucion, @Venta, @Precio, @Iva
		END

		CLOSE Consignas_Cursor
		DEALLOCATE Consignas_Cursor

		-- incrementar la columna de devolucion buena del producto en el kardex de inventario
		exec up_ActualizaKardex @IdCedis , @FechaDevolucion, @IdSurtidoEntrega, 4
		
		update Consignas set Status = @Status
		where IdCedis = @IdCedis and IdConsigna = @IdConsigna	

	End
	
	If @Status = 'E'
	Begin
		-- Generar registro del movimiento de Salida de productos del Almacen
        -- generar el movimiento de salida en el Inventario
		set @IdMovimiento = isnull((Select max(IdMovimiento) from Movimientos where  IdCedis = @IdCedis)+1,1)	
		-- insert into Movimientos values (
		select @IdCedis, @IdMovimiento, @FechaEntrega, 12, 'Salida de Producto por Entrega de Consigna', 'RUTA R' + CAST(@IdRutaEntrega AS varchar(10)), 'A'-- )

		update Consignas set IdMovimientoEntrega = @IdMovimiento
		where IdCedis = @IdCedis and IdConsigna = @IdConsigna	

        -- registrar los detalles del movimiento de salida generado
		insert into MovimientosDetalle (IdCedis, IdMovimiento, IdProducto, Cantidad, Observaciones) 
		Select @IdCedis, @IdMovimiento, IdProducto, Surtido, '' from ConsignasDetalle where IdCedis = @IdCedis and IdConsigna = @IdConsigna

		exec up_ActualizaKardex @IdCedis , @FechaEntrega, 0, 3

		update Consignas set Status = @Status
		where IdCedis = @IdCedis and IdConsigna = @IdConsigna	

	End

	If @Status = 'D'
	Begin
		-- Guarda los datos de Fecha, ruta y Surtido para comenzar el registro de las devoluciones
		update Consignas set IdRutaDevolucion = @IdRutaDevolucion, 
							IdSurtidoDevolucion = @IdSurtidoDevolucion,
							FechaDevolucion = @FechaDevolucion
		where IdCedis = @IdCedis and IdConsigna = @IdConsigna	
        
		-- Genera la factura de contado de cliente (IdTipoVenta 3)
		set @IdTipoVenta = 1
		set @FolioInicial = isnull((select FolioInicialContadoRutas from Configuracion where IdCedis = @IdCedis ), 0)
		set @Serie = isnull((select SerieFacturasCredito from Configuracion where IdCedis = @IdCedis ), '')
		set @Folio = (	select isnull( max(Ventas.Folio)+1, 1) 
						from	Ventas 
						where	Ventas.IdCedis = @IdCedis and Ventas.Serie = @Serie )
		if @Folio < @FolioInicial
		Begin
			set @Folio = @FolioInicial
		End
		
		--guarda la factura de contado de cliente
		execute up_Ventas @IdCedis, @IdSurtidoDevolucion, @IdTipoVenta, @Folio, @Serie, @FechaDevolucion, @IdCliente, @IdSucursal, 1

		--Guarda la relacion de la factura de contado con la consigna
		update Consignas set Folio = @Folio, Serie = @Serie
		where IdCedis = @IdCedis and IdConsigna = @IdConsigna
		
		-- Genera Recarga para Venta
		set @IdCarga = isnull( (select max( IdCarga ) from Cargas where IdCedis = @IdCedis and Fecha = @FechaDevolucion and IdRuta = @IdRutaDevolucion) + 1 , 1)	
		insert into Cargas values (@IdCedis, @IdSurtidoDevolucion, @IdCarga, @IdRutaDevolucion, @FechaDevolucion, 'A')
		
		DECLARE Consignas_Cursor CURSOR FOR
		select IdProducto, surtido, Devolucion, Venta, Precio, Iva from ConsignasDetalle where idCedis = @IdCedis and Idconsigna = @IdConsigna

		OPEN Consignas_Cursor;

		FETCH NEXT FROM Consignas_Cursor
		into @IdProducto, @Surtido, @Devolucion, @Venta, @Precio, @Iva
		WHILE @@FETCH_STATUS = 0
		BEGIN

			-- guardar el detalle de la venta de contado del producto en la ruta que liquida la consigna
			delete from VentasDetalle where IdCedis = @IdCedis and IdSurtido = @IdSurtidoDevolucion and IdTipoVenta = @IdTipoVenta and Folio = @Folio and IdProducto = @IdProducto	
			If @Venta <> 0
			Begin
				insert into VentasDetalle values (@IdCedis, @IdSurtidoDevolucion, @IdTipoVenta, @Folio, @IdProducto, @Serie, @Venta, @Precio, @Iva)
			End
			
			-- incrementar el surtido del producto y venta de contado en la ruta que liquida la consigna
			set @SurtidoExiste = isnull((select Surtido from SurtidosDetalle 
								where IdCedis = @IdCedis and IdSurtido = @IdSurtidoDevolucion and IdProducto = @IdProducto ),0)
			if @SurtidoExiste = 0
				Begin
					delete from SurtidosDetalle where IdCedis = @IdCedis and IdSurtido = @IdSurtidoDevolucion and IdProducto = @IdProducto 
					insert into SurtidosDetalle values (@IdCedis, @IdSurtidoDevolucion, @IdProducto, @FechaDevolucion, @Surtido, 0, 0, 0, @Venta, 0, @Precio, @Iva)
				End
			Else
				Begin
					insert into SurtidosCargas 
					select IdCedis, @IdSurtidoDevolucion, @IdCarga, IdProducto, Venta 
					from ConsignasDetalle 
					where IdCedis = @IdCedis and IdConsigna = @IdConsigna and Venta > 0
				End

			FETCH NEXT FROM Consignas_Cursor
			into @IdProducto, @Surtido, @Devolucion, @Venta, @Precio, @Iva
		END

		CLOSE Consignas_Cursor
		DEALLOCATE Consignas_Cursor

		-- incrementar la columna de surtido y VentasContado del producto en el kardex de inventario
		exec up_ActualizaKardex @IdCedis , @FechaDevolucion, @IdSurtidoDevolucion, 4

		--Actualiza la informacion de Ventas
		update Ventas set Subtotal = isnull((select sum(Cantidad * Precio) from VentasDetalle where IdCedis = @IdCedis and IdSurtido = @IdSurtidoDevolucion and IdTipoVenta = @IdTipoVenta and Folio = @Folio ), 0), 
		Iva = isnull( (select sum(Cantidad * Precio * Iva) from VentasDetalle where IdCedis = @IdCedis and IdSurtido = @IdSurtidoDevolucion and IdTipoVenta = @IdTipoVenta and Folio = @Folio ), 0)
		where IdCedis = @IdCedis and IdSurtido = @IdSurtidoDevolucion and IdTipoVenta = @IdTipoVenta and Folio = @Folio 

		--Estatus de la ruta
		if exists( select IdCedis from StatusLiquidacion where IdCedis = @IdCedis and IdSurtido = @IdSurtidoDevolucion and IdRuta = @IdRutaDevolucion and Fecha = @FechaDevolucion and Status = 'HH' )
		begin
			delete from StatusLiquidacion where IdCedis = @IdCedis and IdSurtido = @IdSurtidoDevolucion and IdRuta = @IdRutaDevolucion and Fecha = @FechaDevolucion and Status = 'VEN'
			insert into StatusLiquidacion values ( @IdCedis, @IdSurtidoDevolucion, @IdRutaDevolucion, @FechaDevolucion, 'VEN', 'Actualización de Ventas', getdate() )
		end

		update Consignas set Status = @Status
		where IdCedis = @IdCedis and IdConsigna = @IdConsigna	

	End

	If @Status = 'V'
	Begin
		-- generar el movimiento de entrada en el Inventario
		-- registrar los detalles del movimiento de entrada generado

		set @IdMovimiento = isnull((Select max(IdMovimiento) from Movimientos where  IdCedis = @IdCedis)+1,1)	
		insert into Movimientos values (@IdCedis, @IdMovimiento, @FechaDevolucion, 18, 'Entrada de Producto por Devolución de Consigna', 'RUTA R' + CAST(@IdRutaDevolucion AS varchar(10)), 'A')

		update Consignas set IdMovimientoDevolucion = @IdMovimiento
		where IdCedis = @IdCedis and IdConsigna = @IdConsigna	

        -- registrar los detalles del movimiento de salida generado
		insert into MovimientosDetalle (IdCedis, IdMovimiento, IdProducto, Cantidad, Observaciones) 
		Select @IdCedis, @IdMovimiento, IdProducto, Venta, '' from ConsignasDetalle where IdCedis = @IdCedis and IdConsigna = @IdConsigna

		exec up_ActualizaKardex @IdCedis , @FechaDevolucion, 0, 3

		update Consignas set Status = @Status
		where IdCedis = @IdCedis and IdConsigna = @IdConsigna	

	End

	If @Status = 'C'	-- cuando se cancele una consigna que se esta registrando como entrega
	Begin
        -- decrementar la devolucion buena del producto en la ruta que liquida la consigna
        -- decrementar la columna de devolucion buena del producto en el kardex de inventario
		DECLARE Consignas_Cursor CURSOR FOR
		select IdProducto, surtido, Devolucion, Venta, Precio, Iva from ConsignasDetalle where idCedis = @IdCedis and Idconsigna = @IdConsigna

		OPEN Consignas_Cursor;

		FETCH NEXT FROM Consignas_Cursor
		into @IdProducto, @Surtido, @Devolucion, @Venta, @Precio, @Iva
		WHILE @@FETCH_STATUS = 0
		BEGIN
			-- decrementar la devolucion buena del producto en la ruta que liquida la consigna

			update surtidosdetalle set DevBuena = DevBuena - @Surtido
			where IdCedis = @IdCedis and IdSurtido = @IdSurtidoEntrega and IdProducto = @IdProducto

			-- decrementar la columna de devolucion buena del producto en el kardex de inventario
			update InventarioKardex set DevBuena = DevBuena - @Surtido
			where IdCedis = @IdCedis and Fecha = @FechaEntrega and IdProducto = @IdProducto	

			FETCH NEXT FROM Consignas_Cursor
			into @IdProducto, @Surtido, @Devolucion, @Venta, @Precio, @Iva
		END

		CLOSE Consignas_Cursor
		DEALLOCATE Consignas_Cursor

		update Consignas set Status = @Status
		where IdCedis = @IdCedis and IdConsigna = @IdConsigna	

	End

	If @Status = 'S'	-- cuando se cancele la devolucion de una consigna
	Begin
		-- Elimina la factura de contado de cliente (IdTipoVenta 3)
		set @IdTipoVenta = 3

		-- Elimina los detalles de la factura
		delete 
		from	VentasDetalle 
		where	IdCedis = @IdCedis and IdSurtido = @IdSurtidoDevolucion and IdTipoVenta = @IdTipoVenta 
				and Folio = @Folio and Serie = @Serie

		-- Elimina la factura
		delete 
		from	Ventas 
		where	IdCedis = @IdCedis and IdSurtido = @IdSurtidoDevolucion and IdTipoVenta = @IdTipoVenta 
				and Folio = @Folio and Serie = @Serie

		-- Decrementa los movimientos del producto marcado como vendido
		DECLARE Consignas_Cursor CURSOR FOR
		select IdProducto, surtido, Devolucion, Venta, Precio, Iva from ConsignasDetalle where idCedis = @IdCedis and Idconsigna = @IdConsigna

		OPEN Consignas_Cursor;

		FETCH NEXT FROM Consignas_Cursor
		into @IdProducto, @Surtido, @Devolucion, @Venta, @Precio, @Iva
		WHILE @@FETCH_STATUS = 0
		BEGIN
			-- decrementar el surtido del producto y venta de contado en la ruta que liquida la consigna
			update surtidosdetalle set Surtido = Surtido - @Surtido, VentaContado = VentaContado - @Venta
			where IdCedis = @IdCedis and IdSurtido = @IdSurtidoDevolucion and IdProducto = @IdProducto

			-- decrementar la columna de surtido y VentasContado del producto en el kardex de inventario
			update InventarioKardex set Surtido = Surtido - @Surtido, VentaContado = VentaContado - @Venta
			where IdCedis = @IdCedis and Fecha = @FechaDevolucion and IdProducto = @IdProducto	

			FETCH NEXT FROM Consignas_Cursor
			into @IdProducto, @Surtido, @Devolucion, @Venta, @Precio, @Iva
		END

		CLOSE Consignas_Cursor
		DEALLOCATE Consignas_Cursor

		--Actualiza la informacion de Ventas
		update Ventas set Subtotal = isnull((select sum(Cantidad * Precio) from VentasDetalle where IdCedis = @IdCedis and IdSurtido = @IdSurtidoDevolucion and IdTipoVenta = @IdTipoVenta and Folio = @Folio ), 0), 
		Iva = isnull( (select sum(Cantidad * Precio * Iva) from VentasDetalle where IdCedis = @IdCedis and IdSurtido = @IdSurtidoDevolucion and IdTipoVenta = @IdTipoVenta and Folio = @Folio ), 0)
		where IdCedis = @IdCedis and IdSurtido = @IdSurtidoDevolucion and IdTipoVenta = @IdTipoVenta and Folio = @Folio 

		--Estatus de la ruta
		if exists( select IdCedis from StatusLiquidacion where IdCedis = @IdCedis and IdSurtido = @IdSurtidoDevolucion and IdRuta = @IdRutaDevolucion and Fecha = @FechaDevolucion and Status = 'HH' )
		begin
			delete from StatusLiquidacion where IdCedis = @IdCedis and IdSurtido = @IdSurtidoDevolucion and IdRuta = @IdRutaDevolucion and Fecha = @FechaDevolucion and Status = 'VEN'
			insert into StatusLiquidacion values ( @IdCedis, @IdSurtidoDevolucion, @IdRutaDevolucion, @FechaDevolucion, 'VEN', 'Actualización de Ventas', getdate() )
		end

		-- Actualiza los valores de Venta y Devoluciones de los detalles de la consigna
		update ConsignasDetalle set Devolucion = 0, 
							Venta = 0
		where IdCedis = @IdCedis and IdConsigna = @IdConsigna	  

		-- Elimina los datos de Fecha, ruta y Surtido para comenzar el registro de las devoluciones y Actualiza el estatus de la consigna a "E Pendiente por Devolver"
		update Consignas set IdRutaDevolucion = null, 
							IdSurtidoDevolucion = null,
							Folio = null,
							serie = null,
							Status = 'E'
		where IdCedis = @IdCedis and IdConsigna = @IdConsigna	        
	End

end




