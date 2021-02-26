
declare @ClaveCedi as bigint
declare @Dia as datetime
declare @RutClave as bigint
declare @IdMovimiento as bigint
declare @Surtido as bigint
declare @productoclave as bigint
declare @cantidad as bigint

set @ClaveCedi = 3
set @Surtido = 10
set @RutClave = 36
set @Dia = '20100409'

	if not exists(Select * from RouteADM.dbo.Movimientos where IdCedis = @ClaveCEDI and Fecha = @Dia and IdTipoMovimiento in (select IdMovimientoConsignas from RouteADM.dbo.Configuracion where RouteADM.dbo.Configuracion.IdCedis =@ClaveCEDI ))
	begin
		set @IdMovimiento = (select Max(idMovimiento) from RouteADM.dbo.Movimientos where IdCedis = @ClaveCEDI ) + 1
		IF @IdMovimiento is null
			SET @IdMovimiento = 1
			insert into RouteADM.dbo.Movimientos values(@ClaveCEDI, @IdMovimiento, @Dia, (select IdMovimientoConsignas from RouteADM.dbo.Configuracion where RouteADM.dbo.Configuracion.IdCedis =@ClaveCEDI ) ,'','RUTA ' + cast(@RutClave as varchar(10)),'A')
	end
	else
	begin
		set @IdMovimiento = (select IdMovimiento from RouteADM.dbo.Movimientos where IdCedis = @ClaveCEDI and Fecha = @Dia and IdTipoMovimiento in (select IdMovimientoConsignas from RouteADM.dbo.Configuracion where RouteADM.dbo.Configuracion.IdCedis =@ClaveCEDI ))
		IF @IdMovimiento is null
			SET @IdMovimiento = 1
	end

insert into RouteADM.dbo.MovimientosDetalle 
select @ClaveCedi, @IdMovimiento, cast(tc.ProductoClave as Int), 
sum(tc.Cantidad) as Consignacion, ''
from TrpTpd tt 
inner join TransProd tr on tt.TransProdID1 = tr.TransProdID
inner join Dia diaC on tr.DiaClave = diaC.DiaClave 
inner join TransProd trD on tt.TransProdID = trD.TransProdID
inner join TransProdDetalle tC on tr.TransProdID = tC.TransProdID and tt.TransProdDetalleID = tC.TransProdDetalleID 
inner join Usuario on Usuario.USUId = tt.MUsuarioID  
where diaC.FechaCaptura = @Dia and dbo.FNObtenerRutaADMInter (Usuario.Clave) =  @RutClave 
and tr.tipo = 24
group by  tc.ProductoClave

DECLARE @CursorMOV CURSOR
				
SET @CursorMOV = CURSOR SCROLL DYNAMIC FOR 
	select cast(tc.ProductoClave as Int), sum(tc.Cantidad) as Consignacion
	from TrpTpd tt 
	inner join TransProd tr on tt.TransProdID1 = tr.TransProdID
	inner join Dia diaC on tr.DiaClave = diaC.DiaClave 
	inner join TransProd trD on tt.TransProdID = trD.TransProdID
	inner join TransProdDetalle tC on tr.TransProdID = tC.TransProdID and tt.TransProdDetalleID = tC.TransProdDetalleID 
	inner join Usuario on Usuario.USUId = tt.MUsuarioID  
	where diaC.FechaCaptura = @Dia and dbo.FNObtenerRutaADMInter (Usuario.Clave) =  @RutClave 
	and tr.tipo = 24
	group by  tc.ProductoClave

OPEN @CursorMOV
FETCH NEXT FROM @CursorMOV INTO @ProductoClave, @Cantidad
WHILE @@FETCH_STATUS = 0      
BEGIN 	

	update RouteADM.dbo.SurtidosDetalle set DevBuena = DevBuena + @cantidad 
	where IdCedis = @ClaveCedi and IdSurtido = @Surtido and IdProducto = @productoclave 
											
	FETCH NEXT FROM @CursorMOV INTO @ProductoClave, @Cantidad
END
CLOSE @CursorMOV  
DEALLOCATE @CursorMOV



