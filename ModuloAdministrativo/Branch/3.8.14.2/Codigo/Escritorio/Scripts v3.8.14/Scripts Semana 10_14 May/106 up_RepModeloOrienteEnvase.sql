USE [RouteADM]
GO
/****** Object:  StoredProcedure [dbo].[up_ModeloOrienteEnvase]    Script Date: 05/11/2010 15:50:00 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO



ALTER PROCEDURE [dbo].[up_ModeloOrienteEnvase]
@IdCedis as bigint,
@Fecha as datetime

AS

declare @IdProducto as varchar(2), @Producto as varchar(200), @Columnas as varchar(8000), @FilaProductos as varchar(8000), @FilaIdProductos as varchar(8000)
declare @Almacen2 as varchar(8000), @Almacen3 as varchar(8000)
declare @Total2 as varchar(8000), @Total3 as varchar(8000)
declare @Lleno2 as varchar(8000), @Lleno3 as varchar(8000)
declare @TotalCedis2 as varchar(8000), @TotalCedis3 as varchar(8000)
declare @Valor as money, @IdProducto2 as varchar(2), @IdRuta2 as varchar(2)


set @FilaProductos = ''
set @FilaIdProductos = ''
set @Almacen2 = ''
set @Almacen3 = ''
set @Total2 = ''
set @Total3 = ''
set @Lleno2 = ''
set @Lleno3 = ''
set @TotalCedis2 = ''
set @TotalCedis3 = ''

Delete from RepModeloOrienteEnvase -- where IdCedis = @IdCedis and Fecha = @Fecha 

DECLARE @CursorMOV CURSOR
SET @CursorMOV = CURSOR SCROLL DYNAMIC FOR 
	
	select IdProducto, Producto
	from Productos
	where IdFamilia in (2)
	order by IdProducto
	
OPEN @CursorMOV
FETCH NEXT FROM @CursorMOV INTO @IdProducto, @Producto
WHILE @@FETCH_STATUS = 0      
BEGIN  
	set @Columnas = @Columnas + ' IdProd' + @IdProducto + ' varchar(15), '
	set @FilaProductos = @FilaProductos + ' ''' + @Producto + ''', '
	set @FilaIdProductos = @FilaIdProductos + @IdProducto + ', '

-- Almacén 
	set @Valor = isnull((select Teorico  
		from InventarioKardex 
		where IdCedis = 3 and Fecha = @Fecha and IdProducto = cast(@IdProducto as bigint) ), 0)
	set @Almacen3 = @Almacen3 + ' ''' + cast(@Valor as varchar(15)) + ''', '                                                          

	set @Valor = isnull((select Teorico  
		from InventarioKardex 
		where IdCedis = 3 and Fecha = @Fecha and IdProducto = cast(@IdProducto as bigint) ), 0)
	set @Almacen2 = @Almacen2 + ' ''' + cast(@Valor as varchar(15)) + ''', '                                                          

-- Almacén + Rutas
	set @Valor = isnull((select Teorico  
		from InventarioKardex 
		where IdCedis = 3 and Fecha = @Fecha and IdProducto = cast(@IdProducto as bigint) ), 0) + 
		ISNULL((SELECT SUM(PPC.Saldo)
			FROM Route.dbo.ProductoPrestamoCli PPC 
			inner join (select distinct RutClave, ClienteClave from Route.dbo.Secuencia) SEC on PPC.ClienteClave = SEC.ClienteClave 
			inner join Route.dbo.VenRut VRT on SEC.RUTClave = VRT.RUTClave and VRT.TipoEstado = 1 
			where PPC.Saldo <> 0 and cast(ppc.ProductoClave as int) = @IdProducto 
			and Route.dbo.FNObtenerRutaADMInter(SEC.RUTClave) in (select IdRuta from Rutas where IdCedis = 3)), 0)
	set @Total3 = @Total3 + ' ''' + cast(@Valor as varchar(15)) + ''', '                                                          

	set @Valor = isnull((select Teorico  
		from InventarioKardex 
		where IdCedis = 2 and Fecha = @Fecha and IdProducto = cast(@IdProducto as bigint) ), 0) + 
		ISNULL((SELECT SUM(PPC.Saldo)
			FROM Route.dbo.ProductoPrestamoCli PPC 
			inner join (select distinct RutClave, ClienteClave from Route.dbo.Secuencia) SEC on PPC.ClienteClave = SEC.ClienteClave 
			inner join Route.dbo.VenRut VRT on SEC.RUTClave = VRT.RUTClave and VRT.TipoEstado = 1 
			where PPC.Saldo <> 0 and cast(ppc.ProductoClave as int) = @IdProducto 
			and Route.dbo.FNObtenerRutaADMInter(SEC.RUTClave) in (select IdRuta from Rutas where IdCedis = 2)), 0)
	set @Total2 = @Total2 + ' ''' + cast(@Valor as varchar(15)) + ''', '                                                          

-- Lleno
	set @Valor = isnull((select sum(Teorico * PRD.Factor) 
		from InventarioKardex 
		inner join Route.dbo.ProductoDetalle PRD on IdProducto = cast(PRD.ProductoClave as int) and IdProducto <> PRD.ProductoDetClave and cast(PRD.ProductoDetClave as int) = cast(@IdProducto as int)
		where IdCedis = 3 and Fecha = @Fecha 
		group by PRD.ProductoDetClave ), 0)
	set @Lleno3 = @Lleno3 + ' ''' + cast(@Valor as varchar(15)) + ''', '                                                          

	set @Valor = isnull((select sum(Teorico * PRD.Factor) 
		from InventarioKardex 
		inner join Route.dbo.ProductoDetalle PRD on IdProducto = cast(PRD.ProductoClave as int) and IdProducto <> PRD.ProductoDetClave and cast(PRD.ProductoDetClave as int) = cast(@IdProducto as int)
		where IdCedis = 2 and Fecha = @Fecha 
		group by PRD.ProductoDetClave ), 0)
	set @Lleno2 = @Lleno2 + ' ''' + cast(@Valor as varchar(15)) + ''', '                                                          

-- Total
	set @Valor = isnull((select Teorico  
		from InventarioKardex 
		where IdCedis = 3 and Fecha = @Fecha and IdProducto = cast(@IdProducto as bigint) ), 0) + 
		ISNULL((SELECT SUM(PPC.Saldo)
			FROM Route.dbo.ProductoPrestamoCli PPC 
			inner join (select distinct RutClave, ClienteClave from Route.dbo.Secuencia) SEC on PPC.ClienteClave = SEC.ClienteClave 
			inner join Route.dbo.VenRut VRT on SEC.RUTClave = VRT.RUTClave and VRT.TipoEstado = 1 
			where PPC.Saldo <> 0 and cast(ppc.ProductoClave as int) = @IdProducto 
			and Route.dbo.FNObtenerRutaADMInter(SEC.RUTClave) in (select IdRuta from Rutas where IdCedis = 3)), 0) + 
		isnull((select sum(Teorico * PRD.Factor) 
		from InventarioKardex 
		inner join Route.dbo.ProductoDetalle PRD on IdProducto = cast(PRD.ProductoClave as int) and IdProducto <> PRD.ProductoDetClave and cast(PRD.ProductoDetClave as int) = cast(@IdProducto as int)
		where IdCedis = 3 and Fecha = @Fecha 
		group by PRD.ProductoDetClave ), 0)
	set @TotalCedis3 = @TotalCedis3 + ' ''' + cast(@Valor as varchar(15)) + ''', '                                                          

	set @Valor = isnull((select Teorico  
		from InventarioKardex 
		where IdCedis = 2 and Fecha = @Fecha and IdProducto = cast(@IdProducto as bigint) ), 0) + 
		ISNULL((SELECT SUM(PPC.Saldo)
			FROM Route.dbo.ProductoPrestamoCli PPC 
			inner join (select distinct RutClave, ClienteClave from Route.dbo.Secuencia) SEC on PPC.ClienteClave = SEC.ClienteClave 
			inner join Route.dbo.VenRut VRT on SEC.RUTClave = VRT.RUTClave and VRT.TipoEstado = 1 
			where PPC.Saldo <> 0 and cast(ppc.ProductoClave as int) = @IdProducto 
			and Route.dbo.FNObtenerRutaADMInter(SEC.RUTClave) in (select IdRuta from Rutas where IdCedis = 2)), 0) + 
		isnull((select sum(Teorico * PRD.Factor) 
		from InventarioKardex 
		inner join Route.dbo.ProductoDetalle PRD on IdProducto = cast(PRD.ProductoClave as int) and IdProducto <> PRD.ProductoDetClave and cast(PRD.ProductoDetClave as int) = cast(@IdProducto as int)
		where IdCedis = 2 and Fecha = @Fecha 
		group by PRD.ProductoDetClave ), 0)
	set @TotalCedis2 = @TotalCedis2 + ' ''' + cast(@Valor as varchar(15)) + ''', '                                                          

	
	FETCH NEXT FROM @CursorMOV INTO @IdProducto, @Producto
END                                                                
CLOSE @CursorMOV  
DEALLOCATE @CursorMOV

set @Columnas = LEFT(@Columnas, len(@Columnas)- 1)
set @FilaProductos = LEFT(@FilaProductos, len(@FilaProductos)- 1)
set @FilaIdProductos = LEFT(@FilaIdProductos, len(@FilaIdProductos)- 1)

set @Almacen3 = LEFT(@Almacen3, len(@Almacen3)- 1)
set @Almacen2 = LEFT(@Almacen2, len(@Almacen2)- 1)

set @Total3 = LEFT(@Total3, len(@Total3)- 1)
set @Total2 = LEFT(@Total2, len(@Total2)- 1)

set @Lleno3 = LEFT(@Lleno3, len(@Lleno3)- 1)
set @Lleno2 = LEFT(@Lleno2, len(@Lleno2)- 1)

set @TotalCedis2 = LEFT(@TotalCedis2, len(@TotalCedis2)- 1)
set @TotalCedis3 = LEFT(@TotalCedis3, len(@TotalCedis3)- 1)

exec (  '

---- ******* Huamantla
	insert into RepModeloOrienteEnvase values (3, ''' + @Fecha + ''', 1, 0, '''', ''Productos'', ' + @FilaProductos + '  ) 
	insert into RepModeloOrienteEnvase values (3, ''' + @Fecha + ''', 2, 0, ''Almacén'', ''Huamantla'', ' + @Almacen3 + '  ) 

	insert into RepModeloOrienteEnvase (IdCedis, Fecha, IdAgrupador, IdRuta, Titulo, Concepto)
	select 3, ''' + @Fecha + ''', 3, IdRuta, ''Clientes'', ''Ruta '' + cast(IdRuta as varchar(2)) 
	from Rutas 
	where IdCedis = 3
	order by IdRuta  

	insert into RepModeloOrienteEnvase values (3, ''' + @Fecha + ''', 4, 0, ''Vacío'', ''Huamantla'', ' + @Total3 + '  ) 	
	insert into RepModeloOrienteEnvase values (3, ''' + @Fecha + ''', 5, 0, ''Lleno'', ''Huamantla'', ' + @Lleno3 + '  ) 
	insert into RepModeloOrienteEnvase values (3, ''' + @Fecha + ''', 6, 0, ''TOTAL'', ''Huamantla'', ' + @TotalCedis3 + '  ) 

---- ******* Libres
	insert into RepModeloOrienteEnvase values (2, ''' + @Fecha + ''', 101, 0, '''', ''Productos'', ' + @FilaProductos + '  ) 
	insert into RepModeloOrienteEnvase values (2, ''' + @Fecha + ''', 102, 0, ''Almacén'', ''Libres'', ' + @Almacen2 + '  ) 
	
	insert into RepModeloOrienteEnvase (IdCedis, Fecha, IdAgrupador, IdRuta, Titulo, Concepto)
	select 2, ''' + @Fecha + ''', 103, IdRuta, ''Clientes'', ''Ruta '' + cast(IdRuta as varchar(2)) 
	from Rutas 
	where IdCedis = 2
	order by IdRuta  

	insert into RepModeloOrienteEnvase values (2, ''' + @Fecha + ''', 104, 0, ''Vacío'', ''Libres'', ' + @Total2 + '  ) 
	insert into RepModeloOrienteEnvase values (2, ''' + @Fecha + ''', 105, 0, ''Lleno'', ''Libres'', ' + @Lleno2 + '  ) 
	insert into RepModeloOrienteEnvase values (2, ''' + @Fecha + ''', 106, 0, ''TOTAL'', ''Libres'', ' + @TotalCedis2 + '  ) 

	')

DECLARE @CursorRutas CURSOR
SET @CursorRutas = CURSOR SCROLL DYNAMIC FOR 

	select IdCedis, IdRuta 
	from Rutas 
	-- where IdCedis = @IdCedis 
	order by IdCedis, IdRuta 
	
OPEN @CursorRutas
FETCH NEXT FROM @CursorRutas INTO @IdCedis, @IdRuta2
WHILE @@FETCH_STATUS = 0      
BEGIN  

	
	DECLARE @CursorProductos CURSOR
	SET @CursorProductos = CURSOR SCROLL DYNAMIC FOR 

		select  IdProducto 
		from Productos 
		where IdFamilia in (2)
		order by IdProducto 

	OPEN @CursorProductos
	FETCH NEXT FROM @CursorProductos INTO @IdProducto2
	WHILE @@FETCH_STATUS = 0      
	BEGIN  
	
		set @Valor = ISNULL((SELECT SUM(PPC.Saldo)
			FROM Route.dbo.ProductoPrestamoCli PPC 
			inner join (select distinct RutClave, ClienteClave from Route.dbo.Secuencia) SEC on PPC.ClienteClave = SEC.ClienteClave 
			inner join Route.dbo.VenRut VRT on SEC.RUTClave = VRT.RUTClave and VRT.TipoEstado = 1 
			where PPC.Saldo <> 0 and SEC.RUTClave = 'R' + replicate('0', 2 - len(@IdRuta2)) + cast(@IdRuta2 as varchar(10)) 
			and cast(ppc.ProductoClave as int) = @IdProducto2 
			), 0)
		exec ( 'update RepModeloOrienteEnvase set IdProd' + @IdProducto2 + ' = ' + @Valor + ' where IdCedis = ' + @IdCedis + ' and Fecha = ''' + @Fecha + ''' and IdAgrupador in (3, 103) and IdRuta = ' + @IdRuta2 + ' ' )
		
		FETCH NEXT FROM @CursorProductos INTO @IdProducto2
	END                                                                
	CLOSE @CursorProductos  
	DEALLOCATE @CursorProductos

	FETCH NEXT FROM @CursorRutas INTO @IdCedis, @IdRuta2
END                                                                
CLOSE @CursorRutas  
DEALLOCATE @CursorRutas
