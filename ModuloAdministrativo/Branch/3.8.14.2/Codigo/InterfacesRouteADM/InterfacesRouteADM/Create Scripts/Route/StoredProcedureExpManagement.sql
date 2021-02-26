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


Create PROCEDURE [dbo].[sp_tg_exportManagement] 
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
--select 'Vende = ' + @vende

      --Obtiene los dias a Exportar
      DECLARE @CursorVar1 CURSOR  
      SET @CursorVar1 = CURSOR SCROLL DYNAMIC FOR 
      SELECT DISTINCT D.DiaClave, D.FechaCaptura
      FROM TransProd TP
      INNER JOIN Dia D ON D.DiaClave = TP.DiaClave 
      INNER JOIN USUARIO U ON U.USUId = TP.MUsuarioID
      WHERE TP.Tipo in(2,23) AND TP.TipoFase <> 0 
      AND((TP.MFechaHora between @FechaIn and @FechaFin) OR (@FechaIn = @FechaIniCompara AND TP.TipoFaseIntSal IN (0,2)))
      AND  (U.clave = @vende) 


      OPEN @CursorVar1

      FETCH NEXT FROM @CursorVar1 INTO @DiaClave, @Dia

      WHILE @@FETCH_STATUS = 0      
      BEGIN 

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
                  ) as t1     )>0)
            BEGIN
                       
      
                  --Recupera el CEDI y la Ruta
                  select top 1 @ClaveCEDI = ALMClave, @RUTClave = RUTClave from(
					select ALM.Clave as ALMClave, VIS.RUTClave 
					from Visita VIS 
					inner join Vendedor VEN on VIS.VendedorID = VEN.VendedorID 
					inner join Usuario USU on VEN.USUId = USU.USUId and VEN.TipoEstado = 1
					inner join VENCentroDistHist VCH on VEN.VendedorID = VCH.VendedorId and VCHFechaInicial <= @Dia and FechaFinal >= @Dia
					inner join Almacen ALM on VCH.AlmacenId = ALM.AlmacenID 
					where USU.Clave = @Vende and VIS.DiaClave = @Diaclave and VIS.RUTClave = @vende 
					union
					select ALM.Clave, VRT.RUTClave 
					from TransProd TRP
					inner join Usuario USU on TRP.MUsuarioID = USU.USUId 
					inner join Vendedor VEN on USU.USUId = VEN.USUId and VEN.TipoEstado = 1
					inner join VENCentroDistHist VCH on VEN.VendedorID = VCH.VendedorId and VCHFechaInicial <= @Dia and FechaFinal >= @Dia
					inner join Almacen ALM on VCH.AlmacenId = ALM.AlmacenID 
					inner join VenRut VRT on VEN.VendedorID = VRT.VendedorID and VRT.TipoEstado = 1
					where TRP.Tipo in (2,4,7) and TRP.TipoFase <> 0 
					and USU.Clave = @vende and TRP.DiaClave = @Diaclave and VRT.RUTClave = @vende 
                  ) as t1
                  
                  
--select 'Cedi= ' + @clavecedi, dbo.FNObtenerRutaADMInter(@RUTClave), dbo.FNObtenerCediADMInter(@ClaveCEDI)
                  Declare @idRuta as int             
                  --set @idRuta = Cast (substring(@RUTClave, charindex('-',@RUTClave)+1,LEN(@RUTClave)-charindex('-',@RUTClave)) as int) -- Cast (right(@RUTClave, 4) as int) 
                  set @idRuta = CAST(right(@RUTClave,4) as int)
                  SET @ClaveCEDI = CAST(right(@ClaveCEDI,2) as int)

                  --set @idRuta = dbo.FNObtenerRutaADMInter(@RUTClave)
                  --SET @ClaveCEDI = dbo.FNObtenerCediADMInter(@ClaveCEDI)
                  DECLARE @IdCarga AS INT
                  --Recupera Surtido y carga
                  select TOP 1 @Surtido=IdSurtido, @IdCarga = IdCarga
                  from [RouteADM].dbo.Cargas 
                  where idCedis=cast(@ClaveCEDI as int) and idRuta= @idRuta and Fecha=@Dia
--select @idruta, @dia, @surtido, @idcarga                    
                  --and idCarga in (select dbo.FNObtenerSoloNumeros(t.Folio) as Folio 
                  --                      from transprod as t
                  --                      INNER JOIN Usuario U ON U.USUId = T.MusuarioId
                  --                      where t.tipo=2 AND T.TipoFase <> 0 and t.DiaClave= @DiaClave and U.Clave=@vende and t.TipoFaseIntSal  = 0 )
                  -- Inicializa Status de Surtido}
                  
                  
                  if @Surtido is not null
                  BEGIN

                        if not exists (select IdCedis from [RouteADM].dbo.StatusSurtido where IdCedis = @ClaveCEDI and IdSurtido = @Surtido ) 
                             insert into [RouteADM].dbo.StatusSurtido values ( @ClaveCEDI, @Surtido, 'B' )

---------------------------ACTUALIZA LOS OBSEQUIOS POR PROMOCION---------------------------------------------------
                        update [RouteADM].dbo.SurtidosDetalle set Obsequios=Obsequios+a.Cantidad
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
------------------------CAMBIOS DE PRODUCTO (Obsequios)--------------------------------------------------
                        declare @Cantidad as FLOAT
                        declare @ProductoClave as int
                        
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
                             WHERE ((TP.Tipo = 3 AND TP.TipoFase <> 0) OR (TP.Tipo = 9 AND TP.TipoFase <> 0 AND TP.TipoMovimiento = 1)) 
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
                        
                        
-----------------------------> ## DEVOLUCIONES Y CAMBIOS FISICOS ## <-----------------------------------------------------
                        declare @IdMovimiento as int
                        DECLARE @CursorMOV CURSOR
                        DECLARE @IdTipoMovimiento as int
                        SET @IdTipoMovimiento = (select TOP 1 IdMovimientoDevoluciones from RouteADM.dbo.Configuracion where RouteADM.dbo.Configuracion.IdCedis =@ClaveCEDI )
                                               
                        SET @CursorMOV = CURSOR SCROLL DYNAMIC FOR 
                             SELECT CAST(TD.ProductoClave AS INT), SUM(TD.Cantidad *PD.Factor) AS Cantidad
                             FROM TransProd TP
                             INNER JOIN Dia D ON D.DiaClave = TP.DiaClave 
                             INNER JOIN Visita VIS ON VIS.VisitaClave = TP.VisitaClave AND VIS.DiaClave = TP.DiaClave 
                             INNER JOIN Vendedor VEN ON VEN.VendedorID = VIS.VendedorID 
                             INNER JOIN Usuario U ON U.USUId = VEN.USUId 
                             INNER JOIN TransProdDetalle TD ON TD.TransProdID = TP.TransProdID 
                             INNER JOIN ProductoDetalle PD ON PD.ProductoClave = TD.ProductoClave AND PD.ProductoDetClave = TD.ProductoClave 
                             WHERE ((TP.Tipo = 3 AND TP.TipoFase <> 0) OR (TP.Tipo = 9 AND TP.TipoFase <> 0 AND TP.TipoMovimiento = 1)) 
                                         AND((TP.MFechaHora between @FechaIn and @FechaFin) OR (@FechaIn = @FechaIniCompara AND TP.TipoFaseIntSal IN (0,2)))
                                         AND  (U.Clave = @vende AND TP.DiaClave = @DiaClave) 
                             GROUP BY TD.ProductoClave 
                             
                        if not exists(Select * from RouteADM.dbo.Movimientos where IdCedis = @ClaveCEDI and Fecha = @Dia and IdTipoMovimiento = @IdTipoMovimiento)
                        begin
                             set @IdMovimiento = (select Max(idMovimiento) from RouteADM.dbo.Movimientos where IdCedis = @ClaveCEDI ) + 1
                             IF @IdMovimiento is null
                                   SET @IdMovimiento = 1
                             insert into RouteADM.dbo.Movimientos values(@ClaveCEDI, @IdMovimiento, @Dia, @IdTipoMovimiento  ,'','','A')
                        end
                        else
                        begin
                             set @IdMovimiento = (select IdMovimiento from RouteADM.dbo.Movimientos where IdCedis = @ClaveCEDI and Fecha = @Dia and IdTipoMovimiento = @IdTipoMovimiento)
                             IF @IdMovimiento is null
                                   SET @IdMovimiento = 1
                        end


                        OPEN @CursorMOV
                        FETCH NEXT FROM @CursorMOV INTO @ProductoClave, @Cantidad
                        WHILE @@FETCH_STATUS = 0      
                        BEGIN                                                            
                                                                                        
                             if (select COUNT(*) from RouteADM.dbo.MovimientosDetalle where IdCedis = @ClaveCEDI and IdMovimiento = @IdMovimiento and IdProducto = @ProductoClave ) > 0
                             begin
                                   update RouteADM.dbo.MovimientosDetalle set Cantidad = cast(Cantidad as decimal(19,4)) + cast(@Cantidad as decimal(19,4)) where IdCedis = @ClaveCEDI and IdMovimiento = @IdMovimiento and IdProducto = @ProductoClave 
                              end
                             else
                             begin
                                   insert into RouteADM.dbo.MovimientosDetalle values(@ClaveCEDI, @IdMovimiento, @ProductoClave, cast(@Cantidad as decimal(19,4)), '')
                             end
                                                           
                             FETCH NEXT FROM @CursorMOV INTO @ProductoClave, @Cantidad
                        END
                        CLOSE @CursorMOV  
                        DEALLOCATE @CursorMOV
                        
                        
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
------------------------------------ CONSIGNA -----------------------------------------------------------

						SET @IdTipoMovimiento = (select TOP 1 IdMovimientoConsignas from RouteADM.dbo.Configuracion where RouteADM.dbo.Configuracion.IdCedis =@ClaveCEDI)
						
						IF (select COUNT(*)
                             FROM TransProd TP
                             INNER JOIN Dia D ON D.DiaClave = TP.DiaClave 
                             INNER JOIN Visita VIS ON VIS.VisitaClave = TP.VisitaClave AND VIS.DiaClave = TP.DiaClave 
                             INNER JOIN Vendedor VEN ON VEN.VendedorID = VIS.VendedorID 
                             INNER JOIN Usuario U ON U.USUId = VEN.USUId 
                             WHERE ( (TP.Tipo = 24 AND TP.TipoFase <> 0)) 
                                         AND((TP.MFechaHora between @FechaIn and @FechaFin) OR (@FechaIn = @FechaIniCompara AND TP.TipoFaseIntSal IN (0,2)))
                                         AND  (U.Clave = @vende AND TP.DiaClave = @DiaClave))> 0
						BEGIN
	                                         
							if not exists(Select * from RouteADM.dbo.Movimientos where IdCedis = @ClaveCEDI and Fecha = @Dia and IdTipoMovimiento = @IdTipoMovimiento AND Folio = 'RUTA ' + cast(@RutClave as varchar(10)))
							begin
								 set @IdMovimiento = (select Max(idMovimiento) from RouteADM.dbo.Movimientos where IdCedis = @ClaveCEDI ) + 1
								 IF @IdMovimiento is null
								   SET @IdMovimiento = 1
								 insert into RouteADM.dbo.Movimientos values(@ClaveCEDI, @IdMovimiento, @Dia, @IdTipoMovimiento ,'','RUTA ' + cast(@RutClave as varchar(10)),'A')
							end
							else
							begin
								 set @IdMovimiento = (select IdMovimiento from RouteADM.dbo.Movimientos where IdCedis = @ClaveCEDI and Fecha = @Dia and IdTipoMovimiento  = @IdTipoMovimiento)
								 IF @IdMovimiento is null
								   SET @IdMovimiento = 1
							end
	                                             
							SET @CursorMOV = CURSOR SCROLL DYNAMIC FOR 
								 select cast(TD.ProductoClave as Int), sum(TD.Cantidad *PD.Factor) as Consignacion
								 FROM TransProd TP
								 INNER JOIN Dia D ON D.DiaClave = TP.DiaClave 
								 INNER JOIN Visita VIS ON VIS.VisitaClave = TP.VisitaClave AND VIS.DiaClave = TP.DiaClave 
								 INNER JOIN Vendedor VEN ON VEN.VendedorID = VIS.VendedorID 
								 INNER JOIN Usuario U ON U.USUId = VEN.USUId 
								 INNER JOIN TransProdDetalle TD ON TD.TransProdID = TP.TransProdID 
								 INNER JOIN ProductoDetalle PD ON PD.ProductoClave = TD.ProductoClave AND PD.ProductoDetClave = TD.ProductoClave 
								 WHERE ( (TP.Tipo = 24 AND TP.TipoFase <> 0)) 
											 AND((TP.MFechaHora between @FechaIn and @FechaFin) OR (@FechaIn = @FechaIniCompara AND TP.TipoFaseIntSal IN (0,2)))
											 AND  (U.Clave = @vende AND TP.DiaClave = @DiaClave) 
								 GROUP BY TD.ProductoClave 

							OPEN @CursorMOV
							FETCH NEXT FROM @CursorMOV INTO @ProductoClave, @Cantidad
							WHILE @@FETCH_STATUS = 0      
							BEGIN
								 if (select COUNT(*) from [RouteADM].[dbo].[MovimientosDetalle] where IdCedis = @ClaveCedi and IdMovimiento = @IdMovimiento and IdProducto= @ProductoClave )= 0
								 begin
									   INSERT INTO [RouteADM].[dbo].[MovimientosDetalle]([IdCedis],[IdMovimiento],[IdProducto],[Cantidad],[Observaciones])
									   VALUES(@ClaveCedi,@IdMovimiento,@ProductoClave,@Cantidad,'')
								 end
								 else
								 begin
									   UPDATE [RouteADM].[dbo].[MovimientosDetalle] SET Cantidad = Cantidad + @Cantidad where IdCedis = @ClaveCedi and IdMovimiento = @IdMovimiento and IdProducto= @ProductoClave
								 end
	                                   
	                             
								  update RouteADM.dbo.SurtidosDetalle set DevBuena = DevBuena + @cantidad 
								 where IdCedis = @ClaveCedi and IdSurtido = @Surtido and IdProducto = @productoclave 
	                                                                                         
								 FETCH NEXT FROM @CursorMOV INTO @ProductoClave, @Cantidad
							END
							CLOSE @CursorMOV  
							DEALLOCATE @CursorMOV
	                        
							UPDATE TransProd SET TipoFaseIntSal = 1 
							FROM TransProd TP
							INNER JOIN Dia D ON D.DiaClave = TP.DiaClave 
							INNER JOIN TransProdDetalle TD ON TD.TransProdID = TP.TransProdID 
							INNER JOIN ProductoDetalle PD ON PD.ProductoClave = TD.ProductoClave AND PD.ProductoDetClave = TD.ProductoClave 
							INNER JOIN Usuario U ON U.USUId = TP.MUsuarioID 
							WHERE TP.Tipo = 24 AND TP.TipoFase <> 0
								 AND((TP.MFechaHora between @FechaIn and @FechaFin) OR (@FechaIn = @FechaIniCompara AND TP.TipoFaseIntSal IN (0,2)))
								 AND  (U.Clave = @vende AND TP.DiaClave = @DiaClave) 
                      END   
                        

---------------------------------------------------------------------------------------------------------
----------------------------------- DESCARGA ------------------------------------------------------------

                        SET @CursorMOV = CURSOR SCROLL DYNAMIC FOR 
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
                        
                        OPEN @CursorMOV
                        FETCH NEXT FROM @CursorMOV INTO @ProductoClave, @Cantidad
                        WHILE @@FETCH_STATUS = 0      
                        BEGIN
                             IF(SELECT COUNT(*) FROM [RouteADM].dbo.SurtidosDetalle WHERE IdSurtido= @Surtido and IdCedis=@ClaveCEDI and IdProducto = CAST(@ProductoClave AS INT))=0
                             begin
                                   INSERT INTO [RouteADM].[dbo].[SurtidosDetalle]([IdCedis],[IdSurtido],[IdProducto],[Fecha],[Surtido],[DevBuena],[DevMala],[Obsequios],[VentaContado],[VentaCredito],[Precio],[Iva])
                                   VALUES(@ClaveCEDI,@Surtido,CAST(@ProductoClave AS INT),@Dia,@Cantidad,@Cantidad,0,0,0,0,0,0)
                             end
                             else
                             begin
                                   update [RouteADM].dbo.SurtidosDetalle set DevBuena = DevBuena + @Cantidad
                                   WHERE IdSurtido= @Surtido and IdCedis=@ClaveCEDI and IdProducto = CAST(@ProductoClave AS INT)
                             end                          
                             
                             FETCH NEXT FROM @CursorMOV INTO @ProductoClave, @Cantidad
                        END
                        CLOSE @CursorMOV  
                        DEALLOCATE @CursorMOV
                        
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
------------------------ DEVOLUCIONES DE ALMACEN---------------------------------------------------------

						declare @TipoMotivo as varchar(10)
                        
                        DECLARE @CursorDevD CURSOR  

                        SET @CursorDevD = CURSOR SCROLL DYNAMIC FOR 
                             SELECT CAST(TD.ProductoClave AS INT), TP.TipoMotivo, SUM(TD.Cantidad *PD.Factor) AS Cantidad
                             FROM TransProd TP
                             INNER JOIN Dia D ON D.DiaClave = TP.DiaClave 
                             INNER JOIN TransProdDetalle TD ON TD.TransProdID = TP.TransProdID 
                             INNER JOIN ProductoDetalle PD ON PD.ProductoClave = TD.ProductoClave AND PD.ProductoDetClave = TD.ProductoClave 
                             INNER JOIN Usuario U ON U.USUId = TP.MUsuarioID 
                             WHERE TP.Tipo = 4 AND TP.TipoFase <> 0
                             AND((TP.MFechaHora between @FechaIn and @FechaFin) OR (@FechaIn = @FechaIniCompara AND TP.TipoFaseIntSal IN (0,2)))
                             AND  (U.Clave = @vende AND TP.DiaClave = @DiaClave) 
                             GROUP BY TD.ProductoClave, TP.TipoMotivo 
                        
                        OPEN  @CursorDevD
                        FETCH NEXT FROM @CursorDevD INTO @ProductoClave, @TipoMotivo, @Cantidad
                        WHILE @@FETCH_STATUS = 0      
                        BEGIN 

                             IF(SELECT COUNT(*) FROM [RouteADM].dbo.SurtidosDetalle WHERE IdCedis = @ClaveCEDI AND IdSurtido = @Surtido AND IdProducto = @ProductoClave)=0
                             begin
                                   INSERT INTO [RouteADM].[dbo].[SurtidosDetalle]([IdCedis],[IdSurtido],[IdProducto],[Fecha],[Surtido],[DevBuena],[DevMala],[Obsequios],[VentaContado],[VentaCredito],[Precio],[Iva])
                                   VALUES(@ClaveCEDI,@Surtido,CAST(@ProductoClave AS INT),@Dia,@Cantidad,0,@Cantidad,0,0,0,0,0)
                             end
                             else
                             begin
                                   update [RouteADM].dbo.SurtidosDetalle set DevMala = DevMala+ @Cantidad 
                                   WHERE IdCedis = @ClaveCEDI AND IdSurtido = @Surtido AND IdProducto = @ProductoClave
                             end

                             IF(SELECT COUNT(*) FROM RouteADM.dbo.SurtidosMerma  WHERE IdCedis = @ClaveCEDI AND IdSurtido = @Surtido AND IdTipoMerma = @TipoMotivo AND IdProducto = @ProductoClave )>0
                              BEGIN
                                   UPDATE RouteADM.dbo.SurtidosMerma SET Cantidad = Cantidad + @Cantidad WHERE IdCedis = @ClaveCEDI AND IdSurtido = @Surtido AND  IdTipoMerma = @TipoMotivo  AND IdProducto = @ProductoClave
                             END
                             ELSE
                             BEGIN
                                   INSERT INTO RouteADM.dbo.SurtidosMerma(IdCedis, IdSurtido , IdTipoMerma , IdProducto ,Cantidad )
                                   VALUES(@ClaveCEDI,@Surtido,@TipoMotivo,@ProductoClave,@Cantidad)
                             END
                             
                             FETCH NEXT FROM @CursorDevD INTO @ProductoClave, @TipoMotivo, @Cantidad
                        END
                        CLOSE @CursorDevD  
                        DEALLOCATE @CursorDevD
                        
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
                        declare @IdClienteContadoTmp as bigint
                        declare @SerieFactContado as varchar(10)

                        select @IdClienteContado=IdClienteContado,@SerieFactContado='R'+ltrim(str(@idRuta))
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
                        SELECT TP.Subtotal ,TP.Impuesto, V.ClienteClave, TP.TransProdId, TP.CFVTipo,dbo.FNObtenerSoloNumeros(right(TP.Folio,5)) as folio
                        FROM TransProd as TP 
                        INNER JOIN Visita V ON V.VisitaClave = TP.VisitaClave1 AND V.DiaClave = TP.DiaClave1 
                        INNER JOIN vendedor VE on VE.VendedorId = V.VendedorId
                        INNER JOIN Usuario as Us on Us.USUId = VE.USUId
                        where TP.tipo=1 and TP.TipoFase=2 and  TP.DiaClave1= @DiaClave 
                        AND((TP.MFechaHora between @FechaIn and @FechaFin) OR (@FechaIn = @FechaIniCompara AND TP.TipoFaseIntSal IN (0,2)))
                        AND  (Us.Clave = @vende) and TP.Facturaid is null
                        union
                        SELECT TP.Subtotal ,TP.Impuesto, V.ClienteClave, TP.TransProdId, TP.CFVTipo,dbo.FNObtenerSoloNumeros(right(TP.Folio,5)) as folio
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
							set @IdClienteContadoTmp = (select IdCliente from [RouteADM].dbo.ClienteSucursal where IdSucursal = @ClienteClave and IdCedis = @ClaveCEDI)
							if(@IdClienteContadoTmp is not null)
								SET @IdClienteContado = @IdClienteContadoTmp
             
                             insert into [RouteADM].dbo.Ventas (IdCedis,IdSurtido,IdTipoVenta,Folio,Serie,Fecha,IdCliente,Subtotal,Iva,IdSucursal)
                              values(@ClaveCEDI,@Surtido,@TipoVenta,@Folio,@SerieFactContado,@Dia,@IdClienteContado,@Subtotal,@Impuesto,@ClienteClave)
                                                                                     
                             insert into [RouteADM].dbo.VentasDetalle (IdCedis,IdSurtido,IdTipoVenta,Folio,IdProducto,Serie,Cantidad,Precio,Iva)
                             select @ClaveCEDI,@Surtido,@TipoVenta,@Folio, productoclave,@SerieFactContado,sum(Piezas),
                             SUM(SubTotal - DescuentoCliente - ((SubTotal - DescuentoCliente) * (DescVendPor / 100)))/sum(Piezas),
                             Impuesto/100 as Impuesto                                                         
                             FROM (      SELECT TD.ProductoClave, TD.SubTotal,
                                         (PRD.Factor * TD.Cantidad) as Piezas, 
                                         T.DescVendPor, 
                                         (select top 1 ImpuestoPor from TPDImpuesto where TransProdID = TD.TransProdID and TransProdDetalleID = TD.TransProdDetalleID) as Impuesto,
                                         (select (case when sum(DesImporte) is null then 0 else sum(DesImporte) end) from TpdDes as TDD where TDD.TransProdId=TD.TransProdId and TDD.TransProdDetalleId=TD.TransProdDetalleId) as DescuentoCliente 
                                         FROM TransProd T
                                         INNER JOIN Dia D ON D.DiaClave = T.DiaClave
                                         INNER JOIN Visita V ON V.DiaClave = T.DiaClave AND V.VisitaClave = T.VisitaClave 
                                         INNER JOIN TransProdDetalle TD ON T.TransProdId = TD.TransProdId
                                         inner join Producto PRO on PRO.ProductoClave = TD.ProductoClave 
                                         inner join ProductoDetalle PRD on TD.ProductoClave = PRD.ProductoClave and TD.TipoUnidad = PRD.PRUTipoUnidad and PRD.ProductoClave = PRD.ProductoDetClave 
                                         WHERE td.TransProdID = @TransProdId AND td.Promocion <> 2 ) AS T
                                         
                             GROUP BY productoclave, Impuesto
                             
                             UPDATE TransProd SET TipoFaseIntSal = 1 WHERE TransProdID = @TransProdId
                             UPDATE  TransProdDetalle SET TipoFaseIntSal = 1 WHERE TransProdID = @TransProdId
                             
                             
                             FETCH NEXT FROM @CursorVar2 INTO @Subtotal, @Impuesto,@ClienteClave, @TransProdId, @TipoVenta,@Folio
                        END
                        CLOSE @CursorVar2      
                                               
                                               
                                               ----------------------------------Facturas NO Electronicas***************
                                               
                                               
                                                     select @IdClienteContado=IdClienteContado,@SerieFactContado=SerieFacturasCredito
                        from [RouteADM].dbo.Configuracion              
                                   
                                               SET @CursorVar2 = CURSOR SCROLL DYNAMIC FOR 
                        SELECT TP.Subtotal ,TP.Impuesto, V.ClienteClave, TP.TransProdId, TP.CFVTipo,dbo.FNObtenerSoloNumeros(TP.Folio)
                        FROM TransProd as TP 
                        LEFT JOIN TRPDatoFiscal TF on TP.TransProdID = TF.TransProdID 
                        INNER JOIN Visita V ON V.VisitaClave = TP.VisitaClave AND V.DiaClave = TP.DiaClave 
                        INNER JOIN vendedor VE on VE.VendedorId = V.VendedorId
                        INNER JOIN Usuario as Us on Us.USUId = VE.USUId
                        where TP.tipo=8   and  TP.DiaClave= @DiaClave and TF.TransProdId is null
                        AND((TP.MFechaHora between @FechaIn and @FechaFin) OR (@FechaIn = @FechaIniCompara AND TP.TipoFaseIntSal IN (0,2)))
                        AND  (Us.Clave = @vende)

                        
                        
                        OPEN  @CursorVar2

                        FETCH NEXT FROM @CursorVar2 INTO @Subtotal, @Impuesto,@ClienteClave, @TransProdId, @TipoVenta,@Folio

                        WHILE @@FETCH_STATUS = 0      
                        BEGIN 
                        
							set @IdClienteContadoTmp = (select IdCliente from [RouteADM].dbo.ClienteSucursal where IdSucursal = @ClienteClave and IdCedis = @ClaveCEDI)
							if(@IdClienteContadoTmp is not null)
								SET @IdClienteContado = @IdClienteContadoTmp
								
                             insert into [RouteADM].dbo.Ventas (IdCedis,IdSurtido,IdTipoVenta,Folio,Serie,Fecha,IdCliente,Subtotal,Iva,IdSucursal)
                              values(@ClaveCEDI,@Surtido,@TipoVenta,@Folio,@SerieFactContado,@Dia,@IdClienteContado,@Subtotal,@Impuesto,@ClienteClave)
                                                                                     
                             insert into [RouteADM].dbo.VentasDetalle (IdCedis,IdSurtido,IdTipoVenta,Folio,IdProducto,Serie,Cantidad,Precio,Iva)
                             select @ClaveCEDI,@Surtido,@TipoVenta,@Folio, productoclave,@SerieFactContado,sum(Piezas),
                             SUM(SubTotal - DescuentoCliente - ((SubTotal - DescuentoCliente) * (DescVendPor / 100)))/sum(Piezas) ,
                             Impuesto/100 as Impuesto
                             FROM (      SELECT TD.ProductoClave, TD.SubTotal,
                                         (PRD.Factor * TD.Cantidad) as Piezas, 
                                         Venta.DescVendPor, 
                                         (select top 1 ImpuestoPor from TPDImpuesto where TransProdID = TD.TransProdID and TransProdDetalleID = TD.TransProdDetalleID) as Impuesto,
                                         (select (case when sum(DesImporte) is null then 0 else sum(DesImporte) end) from TpdDes as TDD where TDD.TransProdId=TD.TransProdId and TDD.TransProdDetalleId=TD.TransProdDetalleId) as DescuentoCliente 
                                         FROM TransProd Venta
                                         inner join TransProd Factura on Factura.TransProdID= Venta.FacturaID
                                         INNER JOIN Dia D ON D.DiaClave = Factura.DiaClave
                                         INNER JOIN Visita V ON V.DiaClave = Factura.DiaClave AND V.VisitaClave = Factura.VisitaClave 
                                         INNER JOIN TransProdDetalle TD ON Venta.TransProdId = TD.TransProdId
                                         inner join Producto PRO on PRO.ProductoClave = TD.ProductoClave 
                                         inner join ProductoDetalle PRD on TD.ProductoClave = PRD.ProductoClave and TD.TipoUnidad = PRD.PRUTipoUnidad and PRD.ProductoClave = PRD.ProductoDetClave 
                                         WHERE Factura.TransProdID = @TransProdId AND td.Promocion <> 2 ) AS T
                             GROUP BY productoclave, Impuesto 
                             
                             UPDATE TransProd SET TipoFaseIntSal = 1 WHERE TransProdID = @TransProdId
                             UPDATE  TransProdDetalle SET TipoFaseIntSal = 1 WHERE TransProdID = @TransProdId
                             
                             
                             FETCH NEXT FROM @CursorVar2 INTO @Subtotal, @Impuesto,@ClienteClave, @TransProdId, @TipoVenta,@Folio
                        END
                        CLOSE @CursorVar2
                        
                        
                                               ----------------------------------Facturas Electronicas***************
                                               
                                               
                        SET @CursorVar2 = CURSOR SCROLL DYNAMIC FOR 
                        SELECT TP.Subtotal ,TP.Impuesto, V.ClienteClave, TP.TransProdId, TP.CFVTipo, replace(TP.Folio,TRD.Serie,'')as Folio, TRD.Serie as Serie -- replace(TRD.Serie, 'X', '') as Serie
                        FROM TransProd as TP 
                        inner join trpdatofiscal TRD on TP.Transprodid=TRD.TransProdId
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
                        
							set @IdClienteContadoTmp = (select IdCliente from [RouteADM].dbo.ClienteSucursal where IdSucursal = @ClienteClave and IdCedis = @ClaveCEDI)
							if(@IdClienteContadoTmp is not null)
								SET @IdClienteContado = @IdClienteContadoTmp
								
							 insert into [RouteADM].dbo.Ventas (IdCedis,IdSurtido,IdTipoVenta,Folio,Serie,Fecha,IdCliente,Subtotal,Iva,IdSucursal)
                             values(@ClaveCEDI,@Surtido,@TipoVenta,@Folio,@Serie,@Dia,@IdClienteContado,@Subtotal,@Impuesto,@ClienteClave)
								                                                          
                             insert into [RouteADM].dbo.VentasDetalle (IdCedis,IdSurtido,IdTipoVenta,Folio,IdProducto,Serie,Cantidad,Precio,Iva)
                             select @ClaveCEDI,@Surtido,@TipoVenta,@Folio, productoclave,@Serie,sum(Piezas),
                             SUM(SubTotal - DescuentoCliente - ((SubTotal - DescuentoCliente) * (DescVendPor / 100)))/sum(Piezas) ,
                             Impuesto/100 as Impuesto                       
                             FROM (		 SELECT TD.ProductoClave, TD.SubTotal,
                                         (PRD.Factor * TD.Cantidad) as Piezas, 
                                         Venta.DescVendPor, 
                                         (select top 1 ImpuestoPor from TPDImpuesto where TransProdID = TD.TransProdID and TransProdDetalleID = TD.TransProdDetalleID) as Impuesto,
                                         (select (case when sum(DesImporte) is null then 0 else sum(DesImporte) end) from TpdDes as TDD where TDD.TransProdId=TD.TransProdId and TDD.TransProdDetalleId=TD.TransProdDetalleId) as DescuentoCliente 
                                         FROM TransProd Venta
                                         inner join TransProd Factura on Factura.TransProdID= Venta.FacturaID
                                         INNER JOIN Dia D ON D.DiaClave = Factura.DiaClave
                                         INNER JOIN Visita V ON V.DiaClave = Factura.DiaClave AND V.VisitaClave = Factura.VisitaClave 
                                         INNER JOIN TransProdDetalle TD ON Venta.TransProdId = TD.TransProdId
                                         inner join Producto PRO on PRO.ProductoClave = TD.ProductoClave 
                                         inner join ProductoDetalle PRD on TD.ProductoClave = PRD.ProductoClave and TD.TipoUnidad = PRD.PRUTipoUnidad and PRD.ProductoClave = PRD.ProductoDetClave 
                                         WHERE Factura.TransProdID = @TransProdId AND td.Promocion <> 2) AS T
                             GROUP BY productoclave, Impuesto 
                             
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
      WHERE TP.Tipo in(2,23) AND TP.TipoFase <> 0 
      AND((TP.MFechaHora between @FechaIn and @FechaFin) OR (@FechaIn = @FechaIniCompara AND TP.TipoFaseIntSal IN (0,2)))
      AND  (U.Clave = @vende) 
      
     
      exec [RouteADM].dbo.up_ActualizaKardex @ClaveCEDI, @DiaClave, @Surtido, 1

      declare @IdVendedor as bigint
      
      select top 1 @IdVendedor = SurtidosVendedor.IdVendedor, @DiaClave = Surtidos.Fecha
      from [RouteADM].dbo.Surtidos Surtidos
      inner join [RouteADM].dbo.SurtidosVendedor SurtidosVendedor on Surtidos.IdCedis = SurtidosVendedor.IdCedis and Surtidos.IdSurtido = SurtidosVendedor.IdSurtido 
      where Surtidos.IdCedis = @ClaveCEDI and Surtidos.IdSurtido = @Surtido 
      order by SurtidosVendedor.IdTipoVendedor

      exec [RouteADM].dbo.up_vendedoressaldos @ClaveCEDI, @Surtido, @IdVendedor, @DiaClave, 1

	SET XACT_ABORT ON  
      SET NOCOUNT OFF

END

/*go*/

