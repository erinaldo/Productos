USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[sel_Consignas]    Script Date: 12/10/2010 09:39:39 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sel_Consignas]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sel_Consignas]
GO

USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[sel_Consignas]    Script Date: 12/10/2010 09:39:39 ******/
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
		  ClienteSucursal AS CLISUC ON CON.IdCedis = CLISUC.IdCedis AND CON.IdSucursal = CLISUC.IdSucursal --AND CON.IdCliente = CLISUC.IdCliente	
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
			ClienteSucursal AS CLISUC ON CON.IdCedis = CLISUC.IdCedis AND CON.IdSucursal = CLISUC.IdSucursal --AND CON.IdCliente = CLISUC.IdCliente
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
			ClienteSucursal AS CLISUC ON CON.IdCedis = CLISUC.IdCedis AND CON.IdSucursal = CLISUC.IdSucursal --AND CON.IdCliente = CLISUC.IdCliente
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
			ClienteSucursal AS CLISUC ON CON.IdCedis = CLISUC.IdCedis AND CON.IdSucursal = CLISUC.IdSucursal --AND CON.IdCliente = CLISUC.IdCliente
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
			ClienteSucursal AS CLISUC ON CON.IdCedis = CLISUC.IdCedis AND CON.IdSucursal = CLISUC.IdSucursal --AND CON.IdCliente = CLISUC.IdCliente
	WHERE	(((CON.IdCedis = ' + @IdCedis + ') AND (CON.IdSurtidoEntrega = ' + @IdSurtido + ')) OR 
			((CON.IdCedis = ' + @IdCedis + ') AND (CON.IdSurtidoDevolucion = ' + @IdSurtido + ')))
			and (CON.Status in (' + @CadenaStatus + '))')
end

if @Opc = 6
begin
	select IdCedis, IdConsigna, IdProducto, Surtido - (Devolucion + Venta)
	from ConsignasDetalle 
	where IdCedis = @IdCedis and IdConsigna = @IdConsigna and (Surtido - (Devolucion + Venta)) <> 0
end





GO


