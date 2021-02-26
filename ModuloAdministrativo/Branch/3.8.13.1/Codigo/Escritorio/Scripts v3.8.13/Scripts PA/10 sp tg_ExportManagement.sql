
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[recuperaImpuesto]') and xtype in (N'FN', N'IF', N'TF'))
drop function [dbo].[recuperaImpuesto]
/*go*/go

SET QUOTED_IDENTIFIER OFF 
/*go*/go
SET ANSI_NULLS ON 
/*go*/go



CREATE function [dbo].[recuperaImpuesto](@ProductoClave as varchar(16))
returns float
as
BEGIN
declare @Impuesto as float

set @Impuesto= (select round(isnull(sum(im.valor/100),0),2) from 
ProductoImpuesto as pim,
ImpuestoVig as im 
where pim.ProductoClave=@ProductoClave and
pim.ImpuestoClave=im.ImpuestoClave)

Return @Impuesto

END 



/*go*/go
SET QUOTED_IDENTIFIER OFF 
/*go*/go
SET ANSI_NULLS ON 
/*go*/go


if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[recuperaPrecio]') and xtype in (N'FN', N'IF', N'TF'))
drop function [dbo].[recuperaPrecio]
/*go*/go

SET QUOTED_IDENTIFIER OFF 
/*go*/go
SET ANSI_NULLS ON 
/*go*/go

CREATE function [dbo].[recuperaPrecio](@General as int,@DiaClave  as varchar(16) ,@USUId  as varchar(16) ,@Cliente  as varchar(16), @Producto as varchar(16))
returns float
as
BEGIN
declare @Precio as float

if @General=1
set @Precio= isnull((select max(td.Precio) from 
transprod as t,
transproddetalle as td
where
t.DiaClave= @DiaClave and 
t.MUsuarioid=@USUId and
t.ClienteClave in (select idSucursal from [PDC San Marcos].dbo.ClienteSucursal where idCliente = @Cliente) and
td.transprodid=t.transprodid and td.Promocion=0 and
td.ProductoClave=@Producto),0)

else
set @Precio= isnull((select max(td.Precio) from 
transprod as t,
transproddetalle as td
where
t.DiaClave= @DiaClave and 
t.MUsuarioid=@USUId and
t.ClienteClave=@Cliente and 
td.transprodid=t.transprodid and td.Promocion=0 and
td.ProductoClave=@Producto
),0)

Return @Precio

END 





/*go*/go
SET QUOTED_IDENTIFIER OFF 
/*go*/go
SET ANSI_NULLS ON 
/*go*/go


if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_tg_exportManagement]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_tg_exportManagement]
/*go*/go

SET QUOTED_IDENTIFIER OFF 
/*go*/go
SET ANSI_NULLS ON 
/*go*/go

CREATE PROCEDURE [dbo].[sp_tg_exportManagement] 
	@FechaIn as datetime, @FechaFin as datetime, @vende as varchar(20)
AS
BEGIN
	SET DATEFORMAT DMY;
	SET XACT_ABORT OFF    
	SET NOCOUNT OFF  
	
	SET ROWCOUNT 0 
	
	declare @ClaveCEDI as varchar(20)
	declare @DiaClave as varchar(20)
	declare @RUTClave as varchar(20)
	declare @Surtido as varchar(20)
	declare @Dia as datetime


	Declare @FechaIniCompara datetime
		SET @FechaIniCompara = convert(datetime,'9999-12-31',102)

	Declare  @esta as int, @leng as varchar(10)  
	  
	set @leng = (select top 1 TipoLenguaje from Conhist where CONHistFechaInicio <= getdate() order by CONHistFechaInicio desc)  
	set @esta = (select top 1 intUnidadVta from ConHist where CONHistFechaInicio <= getdate() order by CONHistFechaInicio desc) 
-- select 'Vende = ' + @vende

	--Obtiene los dias a Exportar
	DECLARE @CursorVar1 CURSOR  
	SET @CursorVar1 = CURSOR SCROLL DYNAMIC FOR 
	SELECT DISTINCT D.DiaClave, D.FechaCaptura
	FROM TransProd TP
	INNER JOIN Dia D ON D.DiaClave = TP.DiaClave 
	INNER JOIN USUARIO U ON U.USUId = TP.MUsuarioID
	WHERE TP.Tipo = 2 AND TP.TipoFase <> 0 
	AND((TP.MFechaHora between @FechaIn and @FechaFin) OR (@FechaIn = @FechaIniCompara AND TP.TipoFaseIntSal IN (0,2)))
	AND  (U.clave = @vende) 


	OPEN @CursorVar1

	FETCH NEXT FROM @CursorVar1 INTO @DiaClave, @Dia

	WHILE @@FETCH_STATUS = 0      
	BEGIN 
	
-- select 'Dia clave= ' + @DiaClave + ', Dia = ' + @Dia

		IF((select COUNT(*) as Registros from (
			select VisitaClave from Visita VIS 
			inner join Vendedor VEN on VIS.VendedorID = VEN.VendedorID 
			inner join Usuario USU on VEN.USUId = USU.USUId 
			where USU.Clave = @Vende and VIS.DiaClave = @Diaclave
			union
			select TransProdID from TransProd TRP
			inner join Usuario USU on TRP.MUsuarioID = USU.USUId 
			where TRP.Tipo in (4,7) and TRP.TipoFase <> 0 
			and USU.Clave = @vende and TRP.DiaClave = @Diaclave
			) as t1	)>0)
		BEGIN
	
			--Recupera el CEDI y la Ruta
			select top 1 @ClaveCEDI = ALMClave, @RUTClave = RUTClave from(
			select distinct	ALM.Clave as ALMClave, VIS.RUTClave 
			from Visita VIS 
			inner join Vendedor VEN on VIS.VendedorID = VEN.VendedorID 
			inner join Usuario USU on VEN.USUId = USU.USUId and VEN.TipoEstado = 1
			inner join VENCentroDistHist VCH on VEN.VendedorID = VCH.VendedorId and VCHFechaInicial <= @Dia and FechaFinal >= @Dia
			inner join Almacen ALM on VCH.AlmacenId = ALM.AlmacenID 
			where USU.Clave = @Vende and VIS.DiaClave = @Diaclave
			union
			select distinct	ALM.Clave, VRT.RUTClave 
			from TransProd TRP
			inner join Usuario USU on TRP.MUsuarioID = USU.USUId 
			inner join Vendedor VEN on USU.USUId = VEN.USUId and VEN.TipoEstado = 1
			inner join VENCentroDistHist VCH on VEN.VendedorID = VCH.VendedorId and VCHFechaInicial <= @Dia and FechaFinal >= @Dia
			inner join Almacen ALM on VCH.AlmacenId = ALM.AlmacenID 
			inner join VenRut VRT on VEN.VendedorID = VRT.VendedorID and VRT.TipoEstado = 1
			where TRP.Tipo in (2,4,7) and TRP.TipoFase <> 0 
			and USU.Clave = @vende and TRP.DiaClave = @Diaclave
			) as t1
			
			
		
-- select 'Cedi= ' + @clavecedi
			Declare @idRuta as int			
			--set @idRuta = Cast (substring(@RUTClave, charindex('-',@RUTClave)+1,LEN(@RUTClave)-charindex('-',@RUTClave)) as int) -- Cast (right(@RUTClave, 4) as int) 
			set @idRuta = cast(right(@RUTClave,4) as int)
			SET @ClaveCEDI = cast(right(@ClaveCEDI,2) as int) 
			--Recupera Surtido
			select  @Surtido=IdSurtido 
			from [RouteADM].dbo.Cargas 
			where idCedis=cast(@ClaveCEDI as int) and idRuta= @idRuta and Fecha=@Dia 
			and idCarga in (select cast(right(t.Folio, 5) as int) as Folio 
							from transprod as t
							INNER JOIN Usuario U ON U.USUId = T.MusuarioId
							where t.tipo=2 AND T.TipoFase <> 0 and t.DiaClave= @DiaClave and U.Clave=@vende and t.TipoFaseIntSal  = 0 )
			-- Inicializa Status de Surtido}
			
			
			if @Surtido is not null
			BEGIN

				if not exists (select IdCedis from [RouteADM].dbo.StatusSurtido where IdCedis = @ClaveCEDI and IdSurtido = @Surtido ) 
					insert into [RouteADM].dbo.StatusSurtido values ( @ClaveCEDI, @Surtido, 'B' )

---------------------------ACTUALIZA LOS OBSEQUIOS POR PROMOCION---------------------------------------------------
				update [RouteADM].dbo.SurtidosDetalle set Obsequios=a.Cantidad
				from
				[RouteADM].dbo.SurtidosDetalle as b
				INNER JOIN (
					SELECT productoclave,sum(cantidad)as Cantidad
					FROM (
						SELECT td.productoclave,td.cantidad
						FROM Transprod as TP
						INNER JOIN Visita V ON V.VisitaClave = TP.VisitaClave1 AND V.DiaClave = TP.DiaClave1 
						INNER JOIN TransProdDetalle as TD ON TD.transprodid = TP.transprodid
						INNER JOIN Producto P on P.ProductoClave = TD.ProductoClave  
						INNER JOIN vendedor VE on VE.VendedorId = V.VendedorId
						INNER JOIN Usuario as Us on Us.USUId = VE.USUId
						where TP.tipo=1 and TP.TipoFase in (2,3) and td.Promocion=2
						AND((TP.MFechaHora between @FechaIn and @FechaFin) OR (@FechaIn = @FechaIniCompara AND TP.TipoFaseIntSal IN (0,2)))
						AND  (Us.Clave = @vende AND TP.DiaClave1 = @DiaClave) 
						union all
						SELECT td.productoclave,td.cantidad 
						FROM Transprod as TP
						INNER JOIN Visita V ON V.VisitaClave = TP.VisitaClave AND V.DiaClave = TP.DiaClave
						INNER JOIN TransProdDetalle as TD ON TD.transprodid = TP.transprodid
						INNER JOIN Producto P on P.ProductoClave = TD.ProductoClave  
						INNER JOIN vendedor VE on VE.VendedorId = V.VendedorId
						INNER JOIN Usuario as Us on Us.USUId = VE.USUId
						where TP.tipo=1 and TP.TipoFase in (2,3) and td.Promocion=2
						AND((TP.MFechaHora between @FechaIn and @FechaFin) OR (@FechaIn = @FechaIniCompara AND TP.TipoFaseIntSal IN (0,2)))
						AND  (Us.Clave = @vende AND TP.DiaClave = @DiaClave) 
					) as T
					group by productoclave
				) as a ON b.IdProducto = CAST(a.ProductoClave AS INT)
				WHERE b.IdSurtido=@Surtido and b.IdCedis=@ClaveCEDI
---------------------------------------------------------------------------------------------------------
------------------------CAMBIOS DE PRODUCTO -------------------------------------------------------------
				declare @Cantidad as FLOAT
				declare @ProductoClave as int
				DECLARE @IdCarga AS INT

				SELECT TOP 1 @IdCarga = IdCarga FROM RouteADM.dbo.Cargas WHERE IdCedis = @ClaveCEDI AND IdSurtido = @Surtido AND IdRuta = @idRuta

				update [RouteADM].dbo.SurtidosDetalle set Obsequios=Obsequios+a.Cantidad
				from
				[RouteADM].dbo.SurtidosDetalle as b
				INNER JOIN (
					SELECT TD.ProductoClave, SUM(TD.Cantidad *PD.Factor) AS Cantidad
					FROM TransProd TP
					INNER JOIN Dia D ON D.DiaClave = TP.DiaClave 
					INNER JOIN Visita VIS ON VIS.VisitaClave = TP.VisitaClave AND VIS.DiaClave = TP.DiaClave 
					INNER JOIN Vendedor VEN ON VEN.VendedorID = VIS.VendedorID 
					INNER JOIN Usuario U ON U.USUId = VEN.USUId 
					INNER JOIN TransProdDetalle TD ON TD.TransProdID = TP.TransProdID 
					INNER JOIN ProductoDetalle PD ON PD.ProductoClave = TD.ProductoClave AND PD.ProductoDetClave = TD.ProductoClave 
					WHERE TP.Tipo = 9 AND TP.TipoFase <> 0 AND TP.TipoMovimiento = 2
							AND((TP.MFechaHora between @FechaIn and @FechaFin) OR (@FechaIn = @FechaIniCompara AND TP.TipoFaseIntSal IN (0,2)))
							AND  (U.Clave = @vende AND TP.DiaClave = @DiaClave) 
					GROUP BY TD.ProductoClave 
				) as a ON b.IdProducto = CAST(a.ProductoClave AS INT)
				WHERE b.IdSurtido=@Surtido and b.IdCedis=@ClaveCEDI
				
								update [RouteADM].dbo.SurtidosCambios set Entrada=Entrada+a.Cantidad
				from
				[RouteADM].dbo.SurtidosDetalle as b
				INNER JOIN (
					SELECT TD.ProductoClave, SUM(TD.Cantidad *PD.Factor) AS Cantidad
					FROM TransProd TP
					INNER JOIN Dia D ON D.DiaClave = TP.DiaClave 
					INNER JOIN Visita VIS ON VIS.VisitaClave = TP.VisitaClave AND VIS.DiaClave = TP.DiaClave 
					INNER JOIN Vendedor VEN ON VEN.VendedorID = VIS.VendedorID 
					INNER JOIN Usuario U ON U.USUId = VEN.USUId 
					INNER JOIN TransProdDetalle TD ON TD.TransProdID = TP.TransProdID 
					INNER JOIN ProductoDetalle PD ON PD.ProductoClave = TD.ProductoClave AND PD.ProductoDetClave = TD.ProductoClave 
					WHERE TP.Tipo = 9 AND TP.TipoFase <> 0 AND TP.TipoMovimiento = 1
							AND((TP.MFechaHora between @FechaIn and @FechaFin) OR (@FechaIn = @FechaIniCompara AND TP.TipoFaseIntSal IN (0,2)))
							AND  (U.Clave = @vende AND TP.DiaClave = @DiaClave) 
					GROUP BY TD.ProductoClave 
				) as a ON b.IdProducto = CAST(a.ProductoClave AS INT)
				WHERE b.IdSurtido=@Surtido and b.IdCedis=@ClaveCEDI
				
												update [RouteADM].dbo.SurtidosCambios set Salida=Salida+a.Cantidad
				from
				[RouteADM].dbo.SurtidosDetalle as b
				INNER JOIN (
					SELECT TD.ProductoClave, SUM(TD.Cantidad *PD.Factor) AS Cantidad
					FROM TransProd TP
					INNER JOIN Dia D ON D.DiaClave = TP.DiaClave 
					INNER JOIN Visita VIS ON VIS.VisitaClave = TP.VisitaClave AND VIS.DiaClave = TP.DiaClave 
					INNER JOIN Vendedor VEN ON VEN.VendedorID = VIS.VendedorID 
					INNER JOIN Usuario U ON U.USUId = VEN.USUId 
					INNER JOIN TransProdDetalle TD ON TD.TransProdID = TP.TransProdID 
					INNER JOIN ProductoDetalle PD ON PD.ProductoClave = TD.ProductoClave AND PD.ProductoDetClave = TD.ProductoClave 
					WHERE TP.Tipo = 9 AND TP.TipoFase <> 0 AND TP.TipoMovimiento = 2
							AND((TP.MFechaHora between @FechaIn and @FechaFin) OR (@FechaIn = @FechaIniCompara AND TP.TipoFaseIntSal IN (0,2)))
							AND  (U.Clave = @vende AND TP.DiaClave = @DiaClave) 
					GROUP BY TD.ProductoClave 
				) as a ON b.IdProducto = CAST(a.ProductoClave AS INT)
				WHERE b.IdSurtido=@Surtido and b.IdCedis=@ClaveCEDI
				


				
---------------------------------------------------------------------------------------------------------
----------------------------------- DESCARGA ------------------------------------------------------------

				update [RouteADM].dbo.SurtidosDetalle set DevBuena = a.Cantidad
				from
				[RouteADM].dbo.SurtidosDetalle as b
				INNER JOIN (
							SELECT TD.ProductoClave, SUM(TD.Cantidad *PD.Factor) AS Cantidad
							FROM TransProd TP
							INNER JOIN Dia D ON D.DiaClave = TP.DiaClave 
							INNER JOIN TransProdDetalle TD ON TD.TransProdID = TP.TransProdID 
							INNER JOIN ProductoDetalle PD ON PD.ProductoClave = TD.ProductoClave AND PD.ProductoDetClave = TD.ProductoClave 
							INNER JOIN Usuario U ON U.USUId = TP.MUsuarioID
							WHERE TP.Tipo = 7 AND TP.TipoFase <> 0
							AND((TP.MFechaHora between @FechaIn and @FechaFin) OR (@FechaIn = @FechaIniCompara AND TP.TipoFaseIntSal IN (0,2)))
							AND  (U.Clave = @vende AND TP.DiaClave = @DiaClave) 
					GROUP BY TD.ProductoClave 
				) as a ON b.IdProducto = CAST(a.ProductoClave AS INT)
				WHERE b.IdSurtido=@Surtido and b.IdCedis=@ClaveCEDI
				
				UPDATE TransProd SET TipoFaseIntSal = 1 
				FROM TransProd TP
				INNER JOIN Dia D ON D.DiaClave = TP.DiaClave 
				INNER JOIN TransProdDetalle TD ON TD.TransProdID = TP.TransProdID 
				INNER JOIN ProductoDetalle PD ON PD.ProductoClave = TD.ProductoClave AND PD.ProductoDetClave = TD.ProductoClave 
				INNER JOIN Usuario U ON U.USUId = TP.MUsuarioID 
				WHERE TP.Tipo = 7 AND TP.TipoFase <> 0
					AND((TP.MFechaHora between @FechaIn and @FechaFin) OR (@FechaIn = @FechaIniCompara AND TP.TipoFaseIntSal IN (0,2)))
					AND  (U.Clave = @vende AND TP.DiaClave = @DiaClave) 
				
---------------------------------------------------------------------------------------------------------
----------------AGREGA LOS PRODUCTOS DEVUELTOS POR EL CLIENTE--------------------------------------------
								
				DECLARE @CursorDev CURSOR  

				SET @CursorDev = CURSOR SCROLL DYNAMIC FOR 
					SELECT CAST(TD.ProductoClave AS INT), SUM(TD.Cantidad *PD.Factor) AS Cantidad
					FROM TransProd TP
					INNER JOIN Dia D ON D.DiaClave = TP.DiaClave 
					INNER JOIN Visita VIS ON VIS.VisitaClave = TP.VisitaClave AND VIS.DiaClave = TP.DiaClave 
					INNER JOIN Vendedor VEN ON VEN.VendedorID = VIS.VendedorID 
					INNER JOIN Usuario U ON U.USUId = VEN.USUId 
					INNER JOIN TransProdDetalle TD ON TD.TransProdID = TP.TransProdID 
					INNER JOIN ProductoDetalle PD ON PD.ProductoClave = TD.ProductoClave AND PD.ProductoDetClave = TD.ProductoClave 
					WHERE ((TP.Tipo = 3 AND TP.TipoFase <> 0) OR (TP.Tipo = 9 AND TP.TipoFase <> 0 AND TP.TipoMovimiento = 2)) 
							AND((TP.MFechaHora between @FechaIn and @FechaFin) OR (@FechaIn = @FechaIniCompara AND TP.TipoFaseIntSal IN (0,2)))
							AND  (U.Clave = @vende AND TP.DiaClave = @DiaClave) 
					GROUP BY TD.ProductoClave 

				OPEN  @CursorDev
				FETCH NEXT FROM @CursorDev INTO @ProductoClave, @Cantidad
				WHILE @@FETCH_STATUS = 0      
				BEGIN 
					IF(SELECT COUNT(*) FROM RouteADM.dbo.SurtidosCargas WHERE IdCedis = @ClaveCEDI AND IdSurtido = @Surtido AND  IdCarga = @IdCarga AND IdProducto = @ProductoClave )>0
					BEGIN
						UPDATE RouteADM.dbo.SurtidosCargas SET Cantidad = Cantidad + @Cantidad WHERE IdCedis = @ClaveCEDI AND IdSurtido = @Surtido AND  IdCarga = @IdCarga AND IdProducto = @ProductoClave
					END
					ELSE
					BEGIN
						INSERT INTO RouteADM.dbo.SurtidosCargas(IdCedis, IdSurtido , IdCarga , IdProducto ,Cantidad )
						VALUES(@ClaveCEDI,@Surtido,@IdCarga,@ProductoClave,@Cantidad)
					END
					FETCH NEXT FROM @CursorDev INTO @ProductoClave, @Cantidad
				END
				CLOSE @CursorDev  
				DEALLOCATE @CursorDev
				
				UPDATE TransProd SET TipoFaseIntSal = 1
				FROM TransProd TP
				INNER JOIN Dia D ON D.DiaClave = TP.DiaClave 
				INNER JOIN Visita VIS ON VIS.VisitaClave = TP.VisitaClave AND VIS.DiaClave = TP.DiaClave 
				INNER JOIN Vendedor VEN ON VEN.VendedorID = VIS.VendedorID 
				INNER JOIN Usuario U ON U.USUId = VEN.USUId 
				WHERE TP.Tipo = 3 AND TP.TipoFase <> 0 
						AND((TP.MFechaHora between @FechaIn and @FechaFin) OR (@FechaIn = @FechaIniCompara AND TP.TipoFaseIntSal IN (0,2)))
						AND  (U.Clave = @vende AND TP.DiaClave = @DiaClave) 



---------------------------------------------------------------------------------------------------------
----------------AGREGA LOS PRODUCTOS CAMBIOS--------------------------------------------
					
				DECLARE @CursorCambioEntrada CURSOR  

				SET @CursorCambioEntrada = CURSOR SCROLL DYNAMIC FOR 
					SELECT CAST(TD.ProductoClave AS INT), SUM(TD.Cantidad *PD.Factor) AS Cantidad
					FROM TransProd TP
					INNER JOIN Dia D ON D.DiaClave = TP.DiaClave 
					INNER JOIN Visita VIS ON VIS.VisitaClave = TP.VisitaClave AND VIS.DiaClave = TP.DiaClave 
					INNER JOIN Vendedor VEN ON VEN.VendedorID = VIS.VendedorID 
					INNER JOIN Usuario U ON U.USUId = VEN.USUId 
					INNER JOIN TransProdDetalle TD ON TD.TransProdID = TP.TransProdID 
					INNER JOIN ProductoDetalle PD ON PD.ProductoClave = TD.ProductoClave AND PD.ProductoDetClave = TD.ProductoClave 
					WHERE ((TP.Tipo = 9 AND TP.TipoFase <> 0 AND TP.TipoMovimiento = 1)) 
							AND((TP.MFechaHora between @FechaIn and @FechaFin) OR (@FechaIn = @FechaIniCompara AND TP.TipoFaseIntSal IN (0,2)))
							AND  (U.Clave = @vende AND TP.DiaClave = @DiaClave) 
					GROUP BY TD.ProductoClave 

				OPEN  @CursorCambioEntrada
				FETCH NEXT FROM @CursorCambioEntrada INTO @ProductoClave, @Cantidad
				WHILE @@FETCH_STATUS = 0      
				BEGIN 

					IF(SELECT COUNT(*) FROM RouteADM.dbo.SurtidosCambios WHERE IdCedis = @ClaveCEDI AND IdSurtido = @Surtido AND   IdProducto = @ProductoClave and idFecha=@Dia)>0
					BEGIN

						UPDATE RouteADM.dbo.SurtidosCambios SET Entrada = Entrada + @Cantidad WHERE IdCedis = @ClaveCEDI AND IdSurtido = @Surtido AND  IdProducto = @ProductoClave and idFecha=@Dia
					END
					ELSE
					BEGIN

						INSERT INTO RouteADM.dbo.SurtidosCambios(IdCedis, IdSurtido ,IdFecha , IdProducto ,Entrada,Salida )
						VALUES(@ClaveCEDI,@Surtido,@Dia,@ProductoClave,@Cantidad,0)
					END
					FETCH NEXT FROM @CursorCambioEntrada INTO @ProductoClave, @Cantidad
				END
				CLOSE @CursorCambioEntrada  
				DEALLOCATE @CursorCambioEntrada
				

				DECLARE @CursorCambioSalida CURSOR  

				SET @CursorCambioSalida = CURSOR SCROLL DYNAMIC FOR 
					SELECT CAST(TD.ProductoClave AS INT), SUM(TD.Cantidad *PD.Factor) AS Cantidad
					FROM TransProd TP
					INNER JOIN Dia D ON D.DiaClave = TP.DiaClave 
					INNER JOIN Visita VIS ON VIS.VisitaClave = TP.VisitaClave AND VIS.DiaClave = TP.DiaClave 
					INNER JOIN Vendedor VEN ON VEN.VendedorID = VIS.VendedorID 
					INNER JOIN Usuario U ON U.USUId = VEN.USUId 
					INNER JOIN TransProdDetalle TD ON TD.TransProdID = TP.TransProdID 
					INNER JOIN ProductoDetalle PD ON PD.ProductoClave = TD.ProductoClave AND PD.ProductoDetClave = TD.ProductoClave 
					WHERE ( (TP.Tipo = 9 AND TP.TipoFase <> 0 AND TP.TipoMovimiento = 2)) 
							AND((TP.MFechaHora between @FechaIn and @FechaFin) OR (@FechaIn = @FechaIniCompara AND TP.TipoFaseIntSal IN (0,2)))
							AND  (U.Clave = @vende AND TP.DiaClave = @DiaClave) 
					GROUP BY TD.ProductoClave 

				OPEN  @CursorCambioSalida
				FETCH NEXT FROM @CursorCambioSalida INTO @ProductoClave, @Cantidad
				WHILE @@FETCH_STATUS = 0      
				BEGIN 
					IF(SELECT COUNT(*) FROM RouteADM.dbo.SurtidosCambios WHERE IdCedis = @ClaveCEDI AND IdSurtido = @Surtido AND IdProducto = @ProductoClave and idFecha=@Dia)>0
					BEGIN
						UPDATE RouteADM.dbo.SurtidosCambios SET Salida = Salida + @Cantidad WHERE IdCedis = @ClaveCEDI AND IdSurtido = @Surtido  AND IdProducto = @ProductoClave and idFecha=@Dia
					END
					ELSE
					BEGIN
						INSERT INTO RouteADM.dbo.SurtidosCambios(IdCedis, IdSurtido ,idFecha,IdProducto ,Entrada,Salida )
						VALUES(@ClaveCEDI,@Surtido,@Dia,@ProductoClave,0,@Cantidad)
					END
					FETCH NEXT FROM @CursorCambioSalida INTO @ProductoClave, @Cantidad
				END
				CLOSE @CursorCambioSalida
				DEALLOCATE @CursorCambioSalida

				UPDATE TransProd SET TipoFaseIntSal = 1 
				FROM TransProd TP
				INNER JOIN Dia D ON D.DiaClave = TP.DiaClave 
				INNER JOIN Visita VIS ON VIS.VisitaClave = TP.VisitaClave AND VIS.DiaClave = TP.DiaClave 
				INNER JOIN Vendedor VEN ON VEN.VendedorID = VIS.VendedorID 
				INNER JOIN Usuario U ON U.USUId = VEN.USUId 	
				WHERE TP.Tipo = 9 AND TP.TipoFase <> 0 
				AND((TP.MFechaHora between @FechaIn and @FechaFin) OR (@FechaIn = @FechaIniCompara AND TP.TipoFaseIntSal IN (0,2)))
				AND  (U.Clave = @vende AND TP.DiaClave = @DiaClave) 


---------------------------------------------------------------------------------------------------------
------------------------ DEVOLUCIONES DE ALMACEN---------------------------------------------------------

				DECLARE @CursorDevA CURSOR  

				SET @CursorDevA = CURSOR SCROLL DYNAMIC FOR 
					SELECT CAST(TD.ProductoClave AS INT), SUM(TD.Cantidad *PD.Factor) AS Cantidad
					FROM TransProd TP
					INNER JOIN Dia D ON D.DiaClave = TP.DiaClave 
					INNER JOIN TransProdDetalle TD ON TD.TransProdID = TP.TransProdID 
					INNER JOIN ProductoDetalle PD ON PD.ProductoClave = TD.ProductoClave AND PD.ProductoDetClave = TD.ProductoClave 
					INNER JOIN Usuario U ON U.USUId = TP.MUsuarioID 
					WHERE TP.Tipo = 4 AND TP.TipoFase <> 0
					AND((TP.MFechaHora between @FechaIn and @FechaFin) OR (@FechaIn = @FechaIniCompara AND TP.TipoFaseIntSal IN (0,2)))
					AND  (U.Clave = @vende AND TP.DiaClave = @DiaClave) 
					GROUP BY TD.ProductoClave 
				
				OPEN  @CursorDevA
				FETCH NEXT FROM @CursorDevA INTO @ProductoClave, @Cantidad
				WHILE @@FETCH_STATUS = 0      
				BEGIN 
					IF(SELECT COUNT(*) FROM RouteADM.dbo.SurtidosMerma  WHERE IdCedis = @ClaveCEDI AND IdSurtido = @Surtido AND IdTipoMerma = 1 AND IdProducto = @ProductoClave )>0
					BEGIN
						UPDATE RouteADM.dbo.SurtidosMerma SET Cantidad = Cantidad + @Cantidad WHERE IdCedis = @ClaveCEDI AND IdSurtido = @Surtido AND  IdTipoMerma = 1  AND IdProducto = @ProductoClave
					END
					ELSE
					BEGIN
						INSERT INTO RouteADM.dbo.SurtidosMerma(IdCedis, IdSurtido , IdTipoMerma , IdProducto ,Cantidad )
						VALUES(@ClaveCEDI,@Surtido,1,@ProductoClave,@Cantidad)
					END
					update [RouteADM].dbo.SurtidosDetalle set DevMala = DevMala+ @Cantidad 
					WHERE IdCedis = @ClaveCEDI AND IdSurtido = @Surtido AND IdProducto = @ProductoClave
					
					FETCH NEXT FROM @CursorDevA INTO @ProductoClave, @Cantidad
				END
				CLOSE @CursorDevA  
				DEALLOCATE @CursorDevA
				
				UPDATE TransProd SET TipoFaseIntSal = 1
					FROM TransProd TP
					INNER JOIN Dia D ON D.DiaClave = TP.DiaClave 
					INNER JOIN TransProdDetalle TD ON TD.TransProdID = TP.TransProdID 
					INNER JOIN ProductoDetalle PD ON PD.ProductoClave = TD.ProductoClave AND PD.ProductoDetClave = TD.ProductoClave 
					INNER JOIN Usuario U ON U.USUId = TP.MUsuarioID 
					WHERE TP.Tipo = 4 AND TP.TipoFase <> 0
					AND((TP.MFechaHora between @FechaIn and @FechaFin) OR (@FechaIn = @FechaIniCompara AND TP.TipoFaseIntSal IN (0,2)))
					AND  (U.Clave = @vende AND TP.DiaClave = @DiaClave) 
				
---------------------------------------------------------------------------------------------------------

				declare @IdClienteContado as bigint
				declare @SerieFactContado as varchar(10)

				select @IdClienteContado=IdClienteContado,@SerieFactContado='R'+@RUTClave
				from [RouteADM].dbo.Configuracion


				declare @Subtotal as float
				declare @Impuesto as float
				declare @ClienteClave as varchar(20)
				declare @TransProdId as varchar(20)
				declare @TipoVenta as smallint
				declare @Folio as varchar(20)
				declare @Serie as varchar(20)
				
				--OBTIENE LAS VENTAS REALIZADAS
				DECLARE @CursorVar2 CURSOR  

				SET @CursorVar2 = CURSOR SCROLL DYNAMIC FOR 
				SELECT TP.Subtotal ,TP.Impuesto, V.ClienteClave, TP.TransProdId, TP.CFVTipo,SUBSTRING(TP.Folio,3,LEN(TP.Folio)) as folio
				FROM TransProd as TP 
				INNER JOIN Visita V ON V.VisitaClave = TP.VisitaClave1 AND V.DiaClave = TP.DiaClave1 
				INNER JOIN vendedor VE on VE.VendedorId = V.VendedorId
				INNER JOIN Usuario as Us on Us.USUId = VE.USUId
				where TP.tipo=1 and TP.TipoFase=2 and  TP.DiaClave1= @DiaClave 
				AND((TP.MFechaHora between @FechaIn and @FechaFin) OR (@FechaIn = @FechaIniCompara AND TP.TipoFaseIntSal IN (0,2)))
				AND  (Us.Clave = @vende) and TP.Facturaid is null
				union
				SELECT TP.Subtotal ,TP.Impuesto, V.ClienteClave, TP.TransProdId, TP.CFVTipo,SUBSTRING(TP.Folio,3,LEN(TP.Folio)) as folio
				FROM TransProd as TP 
				INNER JOIN Visita V ON V.VisitaClave = TP.VisitaClave AND V.DiaClave = TP.DiaClave 
				INNER JOIN vendedor VE on VE.VendedorId = V.VendedorId
				INNER JOIN Usuario as Us on Us.USUId = VE.USUId
				where TP.tipo=1 and TP.TipoFase=2 and  TP.DiaClave= @DiaClave 
				AND((TP.MFechaHora between @FechaIn and @FechaFin) OR (@FechaIn = @FechaIniCompara AND TP.TipoFaseIntSal IN (0,2)))
				AND  (Us.Clave = @vende) and TP.Facturaid is null
				
				
				OPEN  @CursorVar2

				FETCH NEXT FROM @CursorVar2 INTO @Subtotal, @Impuesto,@ClienteClave, @TransProdId, @TipoVenta,@Folio

				WHILE @@FETCH_STATUS = 0      
				BEGIN 


					--set @Folio=(select isnull(max(folio)+1,1) from [RouteADM].dbo.Ventas where idCedis=@ClaveCEDI and Serie=@SerieFactContado)
		 
					insert into [RouteADM].dbo.Ventas (IdCedis,IdSurtido,IdTipoVenta,Folio,Serie,Fecha,IdCliente,Subtotal,Iva,IdSucursal)
					values(@ClaveCEDI,@Surtido,@TipoVenta,@Folio,@SerieFactContado,@Dia,@IdClienteContado,@Subtotal,@Impuesto,@ClienteClave)
					
					insert into [RouteADM].dbo.VentasDetalle (IdCedis,IdSurtido,IdTipoVenta,Folio,IdProducto,Serie,Cantidad,Precio,Iva)
					select @ClaveCEDI,@Surtido,@TipoVenta,@Folio, productoclave,@SerieFactContado,sum(Piezas),
					SUM(SubTotal - DescuentoCliente - ((SubTotal - DescuentoCliente) * (DescVendPor / 100)))/sum(Piezas) ,
					sum(Impuesto - DescClienteImpuesto - ((Impuesto - DescClienteImpuesto) * (DescVendPor / 100))) 
					FROM (	SELECT TD.ProductoClave, TD.SubTotal,
							(PRD.Factor * TD.Cantidad) as Piezas, 
							T.DescVendPor, TD.Impuesto,
							(select (case when sum(DesImporte) is null then 0 else sum(DesImporte) end) from TpdDes as TDD where TDD.TransProdId=TD.TransProdId and TDD.TransProdDetalleId=TD.TransProdDetalleId) as DescuentoCliente, 
							(select (case when sum(DesImpuesto) is null then 0 else sum(DesImpuesto) end) from TpdDes as TDD where TDD.TransProdId=TD.TransProdId and TDD.TransProdDetalleId=TD.TransProdDetalleId) as DescClienteImpuesto
							FROM TransProd T
							INNER JOIN Dia D ON D.DiaClave = T.DiaClave
							INNER JOIN Visita V ON V.DiaClave = T.DiaClave AND V.VisitaClave = T.VisitaClave 
							INNER JOIN TransProdDetalle TD ON T.TransProdId = TD.TransProdId
							inner join Producto PRO on PRO.ProductoClave = TD.ProductoClave 
							inner join ProductoDetalle PRD on TD.ProductoClave = PRD.ProductoClave and TD.TipoUnidad = PRD.PRUTipoUnidad and PRD.ProductoClave = PRD.ProductoDetClave 
							WHERE td.TransProdID = @TransProdId AND td.Promocion <> 2 ) AS T
					GROUP BY productoclave
					
					UPDATE TransProd SET TipoFaseIntSal = 1 WHERE TransProdID = @TransProdId
					UPDATE  TransProdDetalle SET TipoFaseIntSal = 1 WHERE TransProdID = @TransProdId
					
					
					FETCH NEXT FROM @CursorVar2 INTO @Subtotal, @Impuesto,@ClienteClave, @TransProdId, @TipoVenta,@Folio
				END
				CLOSE @CursorVar2  
								
								
								
								
								----------------------------------Facturas NO Electronicas***************
								
								
								
									select @IdClienteContado=IdClienteContado,@SerieFactContado=SerieFacturasContado
				from [RouteADM].dbo.Configuracion			
						
								SET @CursorVar2 = CURSOR SCROLL DYNAMIC FOR 
				SELECT TP.Subtotal ,TP.Impuesto, V.ClienteClave, TP.TransProdId, TP.CFVTipo,substring( TP.Folio,3,len(TP.Folio))
				FROM TransProd as TP 
				INNER JOIN Visita V ON V.VisitaClave = TP.VisitaClave AND V.DiaClave = TP.DiaClave 
				INNER JOIN vendedor VE on VE.VendedorId = V.VendedorId
				INNER JOIN Usuario as Us on Us.USUId = VE.USUId
				where TP.tipo=8   and  TP.DiaClave= @DiaClave 
				AND((TP.MFechaHora between @FechaIn and @FechaFin) OR (@FechaIn = @FechaIniCompara AND TP.TipoFaseIntSal IN (0,2)))
				AND  (Us.Clave = @vende)

				
				
				OPEN  @CursorVar2

				FETCH NEXT FROM @CursorVar2 INTO @Subtotal, @Impuesto,@ClienteClave, @TransProdId, @TipoVenta,@Folio

				WHILE @@FETCH_STATUS = 0      
				BEGIN 

					insert into [RouteADM].dbo.Ventas (IdCedis,IdSurtido,IdTipoVenta,Folio,Serie,Fecha,IdCliente,Subtotal,Iva,IdSucursal)
					values(@ClaveCEDI,@Surtido,@TipoVenta,@Folio,@SerieFactContado,@Dia,@IdClienteContado,@Subtotal,@Impuesto,@ClienteClave)
					
					insert into [RouteADM].dbo.VentasDetalle (IdCedis,IdSurtido,IdTipoVenta,Folio,IdProducto,Serie,Cantidad,Precio,Iva)
					select @ClaveCEDI,@Surtido,@TipoVenta,@Folio, productoclave,@SerieFactContado,sum(Piezas),
					SUM(SubTotal - DescuentoCliente - ((SubTotal - DescuentoCliente) * (DescVendPor / 100)))/sum(Piezas) ,
					sum(Impuesto - DescClienteImpuesto - ((Impuesto - DescClienteImpuesto) * (DescVendPor / 100))) 
					FROM (	SELECT TD.ProductoClave, TD.SubTotal,
							(PRD.Factor * TD.Cantidad) as Piezas, 
							Venta.DescVendPor, TD.Impuesto,
							(select (case when sum(DesImporte) is null then 0 else sum(DesImporte) end) from TpdDes as TDD where TDD.TransProdId=TD.TransProdId and TDD.TransProdDetalleId=TD.TransProdDetalleId) as DescuentoCliente, 
							(select (case when sum(DesImpuesto) is null then 0 else sum(DesImpuesto) end) from TpdDes as TDD where TDD.TransProdId=TD.TransProdId and TDD.TransProdDetalleId=TD.TransProdDetalleId) as DescClienteImpuesto
							FROM TransProd Venta
							inner join TransProd Factura on Factura.TransProdID= Venta.FacturaID
							INNER JOIN Dia D ON D.DiaClave = Factura.DiaClave
							INNER JOIN Visita V ON V.DiaClave = Factura.DiaClave AND V.VisitaClave = Factura.VisitaClave 
							INNER JOIN TransProdDetalle TD ON Venta.TransProdId = TD.TransProdId
							inner join Producto PRO on PRO.ProductoClave = TD.ProductoClave 
							inner join ProductoDetalle PRD on TD.ProductoClave = PRD.ProductoClave and TD.TipoUnidad = PRD.PRUTipoUnidad and PRD.ProductoClave = PRD.ProductoDetClave 
							WHERE Factura.TransProdID = @TransProdId AND td.Promocion <> 2 ) AS T
					GROUP BY productoclave
					
					UPDATE TransProd SET TipoFaseIntSal = 1 WHERE TransProdID = @TransProdId
					UPDATE  TransProdDetalle SET TipoFaseIntSal = 1 WHERE TransProdID = @TransProdId
					
					
					FETCH NEXT FROM @CursorVar2 INTO @Subtotal, @Impuesto,@ClienteClave, @TransProdId, @TipoVenta,@Folio
				END
				CLOSE @CursorVar2  
				
				
				
				
								----------------------------------Facturas Electronicas***************
								
								
								
								
								SET @CursorVar2 = CURSOR SCROLL DYNAMIC FOR 
				SELECT TP.Subtotal ,TP.Impuesto, V.ClienteClave, TP.TransProdId, TP.CFVTipo, replace(TP.Folio,TRD.Serie,'')as Folio,TRD.Serie
				FROM TransProd as TP 
				inner join trpdatofiscal TRD on TP.Transprodid=tp.transprodid
				INNER JOIN Visita V ON V.VisitaClave = TP.VisitaClave AND V.DiaClave = TP.DiaClave 
				INNER JOIN vendedor VE on VE.VendedorId = V.VendedorId
				INNER JOIN Usuario as Us on Us.USUId = VE.USUId
				where TP.tipo=8 and   TP.DiaClave= @DiaClave 
				AND((TP.MFechaHora between @FechaIn and @FechaFin) OR (@FechaIn = @FechaIniCompara AND TP.TipoFaseIntSal IN (0,2)))
				AND  (Us.Clave = @vende)

				
				
				OPEN  @CursorVar2

				FETCH NEXT FROM @CursorVar2 INTO @Subtotal, @Impuesto,@ClienteClave, @TransProdId, @TipoVenta,@Folio,@Serie

				WHILE @@FETCH_STATUS = 0      
				BEGIN 
			
					insert into [RouteADM].dbo.Ventas (IdCedis,IdSurtido,IdTipoVenta,Folio,Serie,Fecha,IdCliente,Subtotal,Iva,IdSucursal)
					values(@ClaveCEDI,@Surtido,@TipoVenta,@Folio,@SerieFactContado,@Dia,@IdClienteContado,@Subtotal,@Impuesto,@ClienteClave)
					
					insert into [RouteADM].dbo.VentasDetalle (IdCedis,IdSurtido,IdTipoVenta,Folio,IdProducto,Serie,Cantidad,Precio,Iva)
					select @ClaveCEDI,@Surtido,@TipoVenta,@Folio, productoclave,@SerieFactContado,sum(Piezas),
					SUM(SubTotal - DescuentoCliente - ((SubTotal - DescuentoCliente) * (DescVendPor / 100)))/sum(Piezas) ,
					sum(Impuesto - DescClienteImpuesto - ((Impuesto - DescClienteImpuesto) * (DescVendPor / 100))) 
					FROM (	SELECT TD.ProductoClave, TD.SubTotal,
							(PRD.Factor * TD.Cantidad) as Piezas, 
							T.DescVendPor, TD.Impuesto,
							(select (case when sum(DesImporte) is null then 0 else sum(DesImporte) end) from TpdDes as TDD where TDD.TransProdId=TD.TransProdId and TDD.TransProdDetalleId=TD.TransProdDetalleId) as DescuentoCliente, 
							(select (case when sum(DesImpuesto) is null then 0 else sum(DesImpuesto) end) from TpdDes as TDD where TDD.TransProdId=TD.TransProdId and TDD.TransProdDetalleId=TD.TransProdDetalleId) as DescClienteImpuesto
							FROM TransProd T
							INNER JOIN Dia D ON D.DiaClave = T.DiaClave
							INNER JOIN Visita V ON V.DiaClave = T.DiaClave AND V.VisitaClave = T.VisitaClave 
							INNER JOIN TransProdDetalle TD ON T.TransProdId = TD.TransProdId
							inner join Producto PRO on PRO.ProductoClave = TD.ProductoClave 
							inner join ProductoDetalle PRD on TD.ProductoClave = PRD.ProductoClave and TD.TipoUnidad = PRD.PRUTipoUnidad and PRD.ProductoClave = PRD.ProductoDetClave 
							WHERE td.TransProdID = @TransProdId AND td.Promocion <> 2 ) AS T
					GROUP BY productoclave
					
					UPDATE TransProd SET TipoFaseIntSal = 1 WHERE TransProdID = @TransProdId
					UPDATE  TransProdDetalle SET TipoFaseIntSal = 1 WHERE TransProdID = @TransProdId
					
					
					FETCH NEXT FROM @CursorVar2 INTO @Subtotal, @Impuesto,@ClienteClave, @TransProdId, @TipoVenta,@Folio,@Serie
				END
				CLOSE @CursorVar2  
				DEALLOCATE @CursorVar2
			end
		END

		FETCH NEXT FROM @CursorVar1 INTO @DiaClave, @Dia
	END 
	CLOSE @CursorVar1  
	
	--------------------------************
	
	DEALLOCATE @CursorVar1
	
	UPDATE TransProd SET TipoFaseIntSal = 1
	FROM TransProd TP
	INNER JOIN Dia D ON D.DiaClave = TP.DiaClave 
	INNER JOIN Usuario U ON U.USUId = TP.MUsuarioID 
	WHERE TP.Tipo = 2 AND TP.TipoFase <> 0 
	AND((TP.MFechaHora between @FechaIn and @FechaFin) OR (@FechaIn = @FechaIniCompara AND TP.TipoFaseIntSal IN (0,2)))
	AND  (U.Clave = @vende) 
	
	SET XACT_ABORT ON  
	SET NOCOUNT OFF

	exec [RouteADM].dbo.up_ActualizaKardex @ClaveCEDI, @DiaClave, @Surtido, 4
END

/*

if not exists (select IdCedis from [PDC San Marcos].dbo.StatusLiquidacion where IdCedis = @ClaveCEDI and IdSurtido = @Surtido ) insert into [PDC San Marcos].dbo.StatusLiquidacion values ( @ClaveCEDI, @Surtido, @Ruta, @Dia, 'HH', 'Liquidación a través de HandHeld', getdate() )

delete from [PDC San Marcos].dbo.StatusSurtido where IdCedis = @ClaveCEDI and IdSurtido = @Surtido 

update Cliente set SaldoEfectivo=0 from Cliente where ClienteClave in (select distinct ClienteClave from Secuencia where RUTClave=@RUTClave )

update transprod set saldo=0 where tipo=1 and saldo <> 0 and MUsuarioID=@USUId

--Marcar los registros de carga como exportados
Update Transprod set TipoFaseIntSal  = 1
from transprod as t
where t.tipo=2 and t.DiaClave= @DiaClave and t.MUsuarioid=@USUId and t.tipofase=1
and t.TipoFaseIntSal  = 0

--Marcar los cambios de producto exportados
Update  transprod set TipoFaseIntSal = 1
from transprod as t where t.tipo=9 and t.DiaClave= @DiaClave and t.MUsuarioid=@USUId and t.TipoFaseIntSal  = 0 

--Marcar los ajustes de producto exportados
update transprod set TipoFaseIntSal = 1
from transprod as t
where t.tipo=6 and t.DiaClave= @DiaClave and t.MUsuarioid=@USUId  and t.TipoFaseIntSal  = 0 

--Marcar las Descargas (Devolucion Buen Estado)
Update transprod set TipoFaseIntSal = 1
from transprod as t
where t.tipo=7 and t.DiaClave= @DiaClave and t.MUsuarioid=@USUId and t.TipoFaseIntSal  = 0 

--Marcar facturas exportadas
Update TransProd set TipoFaseIntSal = 1 
from transprod as t
where
t.tipo=8 and t.TipoFase=1 and t.DiaClave= @DiaClave and t.MUsuarioid=@USUId and t.TipoFaseIntSal  = 0


--Marcar pedidos exportados
Update TransProd set TipoFaseIntSal = 1 
from transprod as t
where t.tipo=1 and t.TipoFase in(2,3) and t.DiaClave= @DiaClave and t.MUsuarioid=@USUId and t.TipoFaseIntSal  = 0

*/


/*go*/

