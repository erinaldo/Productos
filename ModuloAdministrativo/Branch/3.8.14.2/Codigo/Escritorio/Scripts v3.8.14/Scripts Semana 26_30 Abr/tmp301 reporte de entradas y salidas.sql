declare @Fecha as datetime, @IdCedis as bigint

declare @IdProducto as varchar(2), @Producto as varchar(200), @Columnas as varchar(8000), @FilaProductos as varchar(8000), @FilaIdProductos as varchar(8000)
declare @InvInicial as varchar(8000), @Entradas as varchar(8000), @Salidas as varchar(8000)
declare @VentaAnterior as varchar(8000), @Venta as varchar(8000), @VentaTotal as varchar(8000)
declare @Valor as money, @IdRuta2 as bigint, @IdProducto2 as varchar(2)

set @Fecha = '20100424'
set @IdCedis = 3

set @FilaProductos = ''
set @FilaIdProductos = ''
set @InvInicial = ''
set @Entradas = ''
set @Salidas = ''
set @Venta = ''
set @VentaAnterior = ''
set @VentaTotal = ''


Delete from RepModeloOrienteES where IdCedis = @IdCedis and Fecha = @Fecha 

DECLARE @CursorMOV CURSOR
SET @CursorMOV = CURSOR SCROLL DYNAMIC FOR 
	
	select IdProducto, Producto
	from Productos
	where IdFamilia in (1,2)
	order by IdProducto
	
OPEN @CursorMOV
FETCH NEXT FROM @CursorMOV INTO @IdProducto, @Producto
WHILE @@FETCH_STATUS = 0      
BEGIN  
	set @Columnas = @Columnas + ' IdProd' + @IdProducto + ' varchar(15), '
	set @FilaProductos = @FilaProductos + ' ''' + @Producto + ''', '
	set @FilaIdProductos = @FilaIdProductos + @IdProducto + ', '

	set @Valor = isnull((select Inicial 
		from InventarioKardex 
		where IdCedis = @IdCedis and Fecha = @Fecha and IdProducto = cast(@IdProducto as bigint) ), 0)
	set @InvInicial = @InvInicial + ' ''' + cast(@Valor as varchar(15)) + ''', '                                                          

	set @Valor = isnull((select SUM(Cantidad)
		from Movimientos 
		inner join MovimientosDetalle on Movimientos.IdCedis = MovimientosDetalle.IdCedis and Movimientos.IdMovimiento = MovimientosDetalle.IdMovimiento 
			and IdProducto = cast(@IdProducto as bigint)
		where Movimientos.IdCedis = @IdCedis and Movimientos.Fecha = @Fecha 
			and Movimientos.IdTipoMovimiento in (select TipoMovimiento.IdTipoMovimiento from TipoMovimiento where EntradaSalida = 'E')
		), 0)
	set @Entradas = @Entradas + ' ''' + cast(@Valor as varchar(15)) + ''', '  

	set @Valor = isnull((select SUM(Cantidad)
		from Movimientos 
		inner join MovimientosDetalle on Movimientos.IdCedis = MovimientosDetalle.IdCedis and Movimientos.IdMovimiento = MovimientosDetalle.IdMovimiento 
			and IdProducto = cast(@IdProducto as bigint)
		where Movimientos.IdCedis = @IdCedis and Movimientos.Fecha = @Fecha 
			and Movimientos.IdTipoMovimiento in (select TipoMovimiento.IdTipoMovimiento from TipoMovimiento where EntradaSalida = 'S')
		), 0)
	set @Salidas = @Salidas + ' ''' + cast(@Valor as varchar(15)) + ''', ' 

	
	set @Valor = ISNULL((select SUM(cantidad) 
		from Surtidos  
		inner join VentasDetalle on VentasDetalle.IdCedis = Surtidos.IdCedis and VentasDetalle.IdSurtido = Surtidos.IdSurtido and IdProducto = @IdProducto2 
		where Surtidos.IdCedis = @IdCedis and Fecha between year(@Fecha)+month(@Fecha)+'01' and  @Fecha - 1
		), 0)
	set @VentaAnterior = @VentaAnterior + ' ''' + cast(@Valor as varchar(15)) + ''', ' 
	
	set @Valor = ISNULL((select SUM(cantidad) 
		from Surtidos  
		inner join VentasDetalle on VentasDetalle.IdCedis = Surtidos.IdCedis and VentasDetalle.IdSurtido = Surtidos.IdSurtido and IdProducto = @IdProducto2 
		where Surtidos.IdCedis = @IdCedis and Fecha = @Fecha 
		), 0)
	set @Venta = @Venta + ' ''' + cast(@Valor as varchar(15)) + ''', ' 

	set @Valor = ISNULL((select SUM(cantidad) 
		from Surtidos  
		inner join VentasDetalle on VentasDetalle.IdCedis = Surtidos.IdCedis and VentasDetalle.IdSurtido = Surtidos.IdSurtido and IdProducto = @IdProducto2 
		where Surtidos.IdCedis = @IdCedis and Fecha between year(@Fecha)+month(@Fecha)+'01' and  @Fecha  
		), 0)
	set @VentaTotal = @VentaTotal + ' ''' + cast(@Valor as varchar(15)) + ''', ' 
	
	
	FETCH NEXT FROM @CursorMOV INTO @IdProducto, @Producto
END                                                                
CLOSE @CursorMOV  
DEALLOCATE @CursorMOV

set @Columnas = LEFT(@Columnas, len(@Columnas)- 1)
set @FilaProductos = LEFT(@FilaProductos, len(@FilaProductos)- 1)
set @FilaIdProductos = LEFT(@FilaIdProductos, len(@FilaIdProductos)- 1)

set @InvInicial = LEFT(@InvInicial, len(@InvInicial)- 1)
set @Entradas = LEFT(@Entradas, len(@Entradas)- 1)
set @Salidas = LEFT(@Salidas, len(@Salidas)- 1)

 set @Venta = LEFT(@Venta, len(@Venta)- 1)
 set @VentaTotal = LEFT(@VentaTotal, len(@VentaTotal)- 1)
 set @VentaAnterior = LEFT(@VentaAnterior, len(@VentaAnterior)- 1)

exec (  '
	
	insert into RepModeloOrienteES values (' + @IdCedis + ', ''' + @Fecha + ''', 1, 0, '''', ''Productos'', ' + @FilaProductos + '  ) 
	insert into RepModeloOrienteES values (' + @IdCedis + ', ''' + @Fecha + ''', 10, 0, ''Inicial'', ''Inventario Inicial'', ' + @InvInicial + '  ) 
	insert into RepModeloOrienteES values (' + @IdCedis + ', ''' + @Fecha + ''', 10, 0, ''Entradas'', ''Entradas'', ' + @Entradas + '  ) 

	insert into RepModeloOrienteES (IdCedis, Fecha, IdAgrupador, IdRuta, Titulo, Concepto)
	select ' + @IdCedis + ', ''' + @Fecha + ''', 11, 0, ''TOTAL'', ''(Inicial + Entradas)'' 

	insert into RepModeloOrienteES (IdCedis, Fecha, IdAgrupador, IdRuta, Titulo, Concepto)
	select ' + @IdCedis + ', ''' + @Fecha + ''', 20, IdRuta, ''Salida por Venta'', ''Ruta '' + cast(IdRuta as varchar(2)) 
	from Rutas 
	where IdCedis = ' + @IdCedis + '
	order by IdRuta 

	insert into RepModeloOrienteES values (' + @IdCedis + ', ''' + @Fecha + ''', 20, 0, ''Salidas'', ''Salidas'', ' + @Salidas + '  ) 

	insert into RepModeloOrienteES (IdCedis, Fecha, IdAgrupador, IdRuta, Titulo, Concepto)
	select ' + @IdCedis + ', ''' + @Fecha + ''', 21, 0, ''TOTAL'', ''Salidas''

	insert into RepModeloOrienteES (IdCedis, Fecha, IdAgrupador, IdRuta, Titulo, Concepto)
	select ' + @IdCedis + ', ''' + @Fecha + ''', 22, 0, ''TOTAL'', ''Existencia para Mañana'' 
 
	insert into RepModeloOrienteES (IdCedis, Fecha, IdAgrupador, IdRuta, Titulo, Concepto)
	select ' + @IdCedis + ', ''' + @Fecha + ''', 30, IdRuta, ''Cargas'', ''Ruta '' + cast(IdRuta as varchar(2)) 
	from Rutas 
	where IdCedis = ' + @IdCedis + '
	order by IdRuta  

	insert into RepModeloOrienteES (IdCedis, Fecha, IdAgrupador, IdRuta, Titulo, Concepto)
	select ' + @IdCedis + ', ''' + @Fecha + ''', 31, 0, ''TOTAL'', ''Cargas'' 

	insert into RepModeloOrienteES (IdCedis, Fecha, IdAgrupador, IdRuta, Titulo, Concepto)
	select ' + @IdCedis + ', ''' + @Fecha + ''', 40, IdRuta, ''Consignas'', ''Ruta '' + cast(IdRuta as varchar(2)) 
	from Rutas 
	where IdCedis = ' + @IdCedis + '
	order by IdRuta  

	insert into RepModeloOrienteES (IdCedis, Fecha, IdAgrupador, IdRuta, Titulo, Concepto)
	select ' + @IdCedis + ', ''' + @Fecha + ''', 41, 0, ''TOTAL'', ''Consignas'' 

	insert into RepModeloOrienteES (IdCedis, Fecha, IdAgrupador, IdRuta, Titulo, Concepto)
	select ' + @IdCedis + ', ''' + @Fecha + ''', 42, 0, ''TOTAL'', ''Existencia en Piso'' 
	
	insert into RepModeloOrienteES values (' + @IdCedis + ', ''' + @Fecha + ''', 50, 0, ''Venta'', ''Anterior'', ' + @VentaAnterior + '  ) 
	insert into RepModeloOrienteES values (' + @IdCedis + ', ''' + @Fecha + ''', 51, 0, ''Venta'', ''Hoy'', ' + @Venta + '  ) 
	insert into RepModeloOrienteES values (' + @IdCedis + ', ''' + @Fecha + ''', 52, 0, ''Venta TOTAL'', ''Acumulada'', ' + @VentaTotal + '  ) 

	insert into RepModeloOrienteES (IdCedis, Fecha, IdAgrupador, IdRuta, Titulo, Concepto)
	select ' + @IdCedis + ', ''' + @Fecha + ''', 60, IdRuta, ''Venta Acumulada'', ''Ruta '' + cast(IdRuta as varchar(2)) 
	from Rutas 
	where IdCedis = ' + @IdCedis + '
	order by IdRuta  


	')

DECLARE @CursorRutas CURSOR
SET @CursorRutas = CURSOR SCROLL DYNAMIC FOR 

	select IdRuta 
	from Rutas 
	where IdCedis = @IdCedis 
	order by IdRuta 
	
OPEN @CursorRutas
FETCH NEXT FROM @CursorRutas INTO @IdRuta2
WHILE @@FETCH_STATUS = 0      
BEGIN  

	
	DECLARE @CursorProductos CURSOR
	SET @CursorProductos = CURSOR SCROLL DYNAMIC FOR 

		select  IdProducto 
		from Productos 
		where IdFamilia in (1,2)
		order by IdProducto 

	OPEN @CursorProductos
	FETCH NEXT FROM @CursorProductos INTO @IdProducto2
	WHILE @@FETCH_STATUS = 0      
	BEGIN  
	
		set @Valor = ISNULL((select SUM(cantidad) 
			from Surtidos  
			inner join VentasDetalle on VentasDetalle.IdCedis = Surtidos.IdCedis and VentasDetalle.IdSurtido = Surtidos.IdSurtido and IdProducto = @IdProducto2 
			where Surtidos.IdCedis = @IdCedis and Fecha = @Fecha and IdRuta = @IdRuta2 
			), 0)
		exec ( 'update RepModeloOrienteES set IdProd' + @IdProducto2 + ' = ' + @Valor + ' where IdCedis = ' + @IdCedis + ' and Fecha = ''' + @Fecha + ''' and IdAgrupador = 20 and IdRuta = ' + @IdRuta2 + ' ' )

		set @Valor = ISNULL((select SUM(Surtido) 
			from Surtidos  
			inner join SurtidosDetalle on SurtidosDetalle.IdCedis = Surtidos.IdCedis and SurtidosDetalle.IdSurtido = Surtidos.IdSurtido and IdProducto = @IdProducto2 
			where Surtidos.IdCedis = @IdCedis and Surtidos.Fecha = @Fecha and IdRuta = @IdRuta2 
			), 0)
		exec ( 'update RepModeloOrienteES set IdProd' + @IdProducto2 + ' = ' + @Valor + ' where IdCedis = ' + @IdCedis + ' and Fecha = ''' + @Fecha + ''' and IdAgrupador = 30 and IdRuta = ' + @IdRuta2 + ' ' )

		set @Valor = ISNULL((select SUM(cantidad) 
			from Surtidos  
			inner join VentasDetalle on VentasDetalle.IdCedis = Surtidos.IdCedis and VentasDetalle.IdSurtido = Surtidos.IdSurtido and IdProducto = @IdProducto2 
			where Surtidos.IdCedis = @IdCedis and Fecha between year(@Fecha)+month(@Fecha)+'01' and  @Fecha and IdRuta = @IdRuta2 
			), 0)
		exec ( 'update RepModeloOrienteES set IdProd' + @IdProducto2 + ' = ' + @Valor + ' where IdCedis = ' + @IdCedis + ' and Fecha = ''' + @Fecha + ''' and IdAgrupador = 60 and IdRuta = ' + @IdRuta2 + ' ' )
		
		set @Valor = ISNULL((select sum(TD.Cantidad *PD.Factor) as Consignacion
			 FROM Route.dbo.TransProd TP
			 INNER JOIN Route.dbo.Dia D ON D.DiaClave = TP.DiaClave 
			 INNER JOIN Route.dbo.Visita VIS ON VIS.VisitaClave = TP.VisitaClave AND VIS.DiaClave = TP.DiaClave 
			 INNER JOIN Route.dbo.Vendedor VEN ON VEN.VendedorID = VIS.VendedorID 
			 INNER JOIN Route.dbo.Usuario U ON U.USUId = VEN.USUId 
			 INNER JOIN Route.dbo.TransProdDetalle TD ON TD.TransProdID = TP.TransProdID 
			 INNER JOIN Route.dbo.ProductoDetalle PD ON PD.ProductoClave = TD.ProductoClave AND PD.ProductoDetClave = TD.ProductoClave 
			 WHERE TP.Tipo = 24 AND TP.TipoFase <> 0 and TP.FechaCaptura = @Fecha and Route.dbo.FNObtenerSoloNumeros(U.Clave) = @IdRuta2
			 and Route.dbo.FNObtenerSoloNumeros(TD.ProductoClave) = cast(@IdProducto2 as int)), 0)
		exec ( 'update RepModeloOrienteES set IdProd' + @IdProducto2 + ' = ' + @Valor + ' where IdCedis = ' + @IdCedis + ' and Fecha = ''' + @Fecha + ''' and IdAgrupador = 40 and IdRuta = ' + @IdRuta2 + ' ' )
		
		FETCH NEXT FROM @CursorProductos INTO @IdProducto2
	END                                                                
	CLOSE @CursorProductos  
	DEALLOCATE @CursorProductos

	

	FETCH NEXT FROM @CursorRutas INTO @IdRuta2
END                                                                
CLOSE @CursorRutas  
DEALLOCATE @CursorRutas


select * -- Route.dbo.FNObtenerSoloNumeros(Concepto)
from RepModeloOrienteES 


