USE [Route]
GO

/****** Object:  StoredProcedure [dbo].[sp_tg_exportCargaSugerida]    Script Date: 10/20/2010 10:38:22 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_tg_exportCargaSugerida]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_tg_exportCargaSugerida]
GO

/****** Object:  StoredProcedure [dbo].[sp_tg_exportManagement]    Script Date: 10/20/2010 10:38:22 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_tg_exportManagement]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_tg_exportManagement]
GO

/****** Object:  StoredProcedure [dbo].[sp_tg_PreliquidacionManagement]    Script Date: 10/20/2010 10:38:22 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_tg_PreliquidacionManagement]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_tg_PreliquidacionManagement]
GO

USE [Route]
GO

/****** Object:  StoredProcedure [dbo].[sp_tg_exportCargaSugerida]    Script Date: 10/20/2010 10:38:22 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER OFF
GO






--------****************************---------------
-- Directo a  RouteADM.dbo.CargasSugeridasDetalle
---------------


CREATE Procedure [dbo].[sp_tg_exportCargaSugerida]
@FechaIn as datetime, @FechaFin as datetime, @vende as varchar(20)
AS    
SET XACT_ABORT OFF    
SET NOCOUNT OFF  


Declare  @TransProdID as varchar(255) , @TipoFaseIntSal as varchar(255) ,@AlmacenId as varchar(255),@RUTClave as varchar(255),@ProductoClave as varchar(255),@cantidad as varchar(255)
  
declare @curTmp  cursor  

set @curTmp = Cursor scroll dynamic FOR
select T.transprodid, T.TipoFaseIntSal, dbo.FNObtenerCEDIADMInter(A.Clave) as AlmacenId,dbo.FNObtenerRutaADMInter(VR.RutClave),TD.ProductoClave,PD.Factor*TD.Cantidad as cantidad from TransProd  T 
inner join TransProdDetalle TD on TD.TransProdID=T.TransProdID
inner join ProductoDetalle  PD on TD.ProductoClave=PD.ProductoClave and TD.TipoUnidad =PD.PRUTipoUnidad
inner join Vendedor V on T.MUsuarioID = V.USUId
inner join Usuario as Us on Us.USUId = T.MUsuarioID  
inner join VenRut VR on VR.VendedorID=V.VendedorID
inner join VENCentroDistHist VC on VC.VendedorId=V.VendedorID and getdate() between VC.VCHFechaInicial and VC.FechaFinal
inner join almacen A on A.Almacenid=VC.Almacenid
where T.Tipo=19 and VR.RUTClave<>'RUT001' and  ((T.FechahoraAlta between @FechaIn and @FechaFin) OR (@FechaIn = convert(Datetime,'9999-12-31',102) AND T.TipoFaseIntSal IN (0,2)))
AND (Us.Clave = @vende)  

 
open @curTmp  
  

Fetch next from @curTmp  
Into @TransProdID,@TipoFaseIntSal,@AlmacenId ,@RUTClave ,@ProductoClave,@cantidad 
  
while @@FETCH_STATUS = 0  
BEGIN  

 if((SELECT Count(*) FROM  RouteADM.dbo.CargasSugeridasDetalle C WHERE C.Tipo=2 and C.IdProducto=@ProductoClave and C.IdRuta=@RUTClave and C.IdCedis = @AlmacenId and C.FechaCarga ='1900-01-01T00:00:00')=0) 
 BEGIN  
  INSERT INTO  RouteADM.dbo.CargasSugeridasDetalle  VALUES(@AlmacenId ,@RUTClave,'1900-01-01T00:00:00' ,@ProductoClave,2,0,@cantidad,0 )  
 END  
 ELSE
 BEGIN
  Update    RouteADM.dbo.CargasSugeridasDetalle   set Cantidad=@cantidad where  Tipo=0 and IdProducto=@ProductoClave and IdRuta=@RUTClave and IdCedis = @AlmacenId and FechaCarga is null
 END
 
 --UPDATE dbo.TransProd
 --  SET
 --   TipoFaseIntSal = CASE 
 --        WHEN @TipoFaseIntSal IS NULL OR @TipoFaseIntSal = 0 THEN 1
 --        WHEN @TipoFaseIntSal = 1 OR @TipoFaseIntSal = 2 THEN 3
 --        END
 -- WHERE TransProdID = @TransProdID
 
 Fetch next from @curTmp  
 Into  @TransProdID,@TipoFaseIntSal,@AlmacenId ,@RUTClave ,@ProductoClave,@cantidad 
END  

close @curTmp  

 update TransProd set @TipoFaseIntSal=3 where TransProdID in (
 select T.transprodid from TransProd  T 
 inner join TransProdDetalle TD on TD.TransProdID=T.TransProdID
 inner join ProductoDetalle  PD on TD.ProductoClave=PD.ProductoClave and TD.TipoUnidad =PD.PRUTipoUnidad
 inner join Vendedor V on T.MUsuarioID = V.USUId
 inner join Usuario as Us on Us.USUId = T.MUsuarioID  
 inner join VenRut VR on VR.VendedorID=V.VendedorID
 inner join VENCentroDistHist VC on VC.VendedorId=V.VendedorID and getdate() between VC.VCHFechaInicial and VC.FechaFinal
 where T.Tipo=19 and VR.RUTClave<>'RUT001' and  ((T.FechahoraAlta between @FechaIn and @FechaFin) OR (@FechaIn = convert(Datetime,'9999-12-31',102) AND T.TipoFaseIntSal IN (0,2)))
 AND (Us.Clave = @vende)  and (T.TipoFaseIntSal in (1,2,3))
)

update TransProd set TipoFaseIntSal=1 where TransProdID in (
 select T.transprodid from TransProd  T 
 inner join TransProdDetalle TD on TD.TransProdID=T.TransProdID
 inner join ProductoDetalle  PD on TD.ProductoClave=PD.ProductoClave and TD.TipoUnidad =PD.PRUTipoUnidad
 inner join Vendedor V on T.MUsuarioID = V.USUId
 inner join Usuario as Us on Us.USUId = T.MUsuarioID  
 inner join VenRut VR on VR.VendedorID=V.VendedorID
 inner join VENCentroDistHist VC on VC.VendedorId=V.VendedorID and getdate() between VC.VCHFechaInicial and VC.FechaFinal
 where T.Tipo=19 and VR.RUTClave<>'RUT001' and  ((T.FechahoraAlta between @FechaIn and @FechaFin) OR (@FechaIn = convert(Datetime,'9999-12-31',102) AND T.TipoFaseIntSal IN (0,2)))
 AND (Us.Clave = @vende)  and (T.TipoFaseIntSal is null or T.TipoFaseIntSal=0))
 

SET XACT_ABORT ON  
SET NOCOUNT OFF

GO

/****** Object:  StoredProcedure [dbo].[sp_tg_exportManagement]    Script Date: 10/20/2010 10:38:22 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




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
                  select distinct   ALM.Clave as ALMClave, VIS.RUTClave 
                  from Visita VIS 
                  inner join Vendedor VEN on VIS.VendedorID = VEN.VendedorID 
                  inner join Usuario USU on VEN.USUId = USU.USUId and VEN.TipoEstado = 1
                  inner join VENCentroDistHist VCH on VEN.VendedorID = VCH.VendedorId and VCHFechaInicial <= @Dia and FechaFinal >= @Dia
                  inner join Almacen ALM on VCH.AlmacenId = ALM.AlmacenID 
                  where USU.Clave = @Vende and VIS.DiaClave = @Diaclave
                  union
                  select distinct   ALM.Clave, VRT.RUTClave 
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
                  set @idRuta = dbo.FNObtenerRutaADMInter(@RUTClave)
                  SET @ClaveCEDI = dbo.FNObtenerCediADMInter(@ClaveCEDI)
                  DECLARE @IdCarga AS INT
                  --Recupera Surtido y carga
                  select TOP 1 @Surtido=IdSurtido, @IdCarga = IdCarga
                  from [RouteADM].dbo.Cargas 
                  where idCedis=cast(@ClaveCEDI as int) and idRuta= @idRuta and Fecha=@Dia 
                  --and idCarga in (select dbo.FNObtenerSoloNumeros(t.Folio) as Folio 
                  --                      from transprod as t
                  --                      INNER JOIN Usuario U ON U.USUId = T.MusuarioId
                  --                      where t.tipo=2 AND T.TipoFase <> 0 and t.DiaClave= @DiaClave and U.Clave=@vende and t.TipoFaseIntSal  = 0 )
                  -- Inicializa Status de Surtido}
                  
                  print '1'
                  if @Surtido is not null
                  BEGIN
                  print '2'

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
                        
                        --- Se quito porque ya se esta obteniendo de mas arriba
                        --DECLARE @IdCarga AS INT
                        --SELECT TOP 1 @IdCarga = IdCarga FROM RouteADM.dbo.Cargas WHERE IdCedis = @ClaveCEDI AND IdSurtido = @Surtido AND IdRuta = @idRuta

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
                             set @IdMovimiento = (select Max(idMovimiento) from RouteADM.dbo.Movimientos where IdCedis = @ClaveCEDI  ) + 1
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
                        if not exists(Select * from RouteADM.dbo.Movimientos where IdCedis = @ClaveCEDI and Fecha = @Dia and IdTipoMovimiento = @IdTipoMovimiento)
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

                        --insert into RouteADM.dbo.MovimientosDetalle 
                        --select @ClaveCedi, @IdMovimiento, cast(tc.ProductoClave as Int), 
                        --sum(tc.Cantidad) as Consignacion, ''
                        --from TrpTpd tt 
                        --inner join TransProd tr on tt.TransProdID1 = tr.TransProdID
                        --inner join Dia diaC on tr.DiaClave = diaC.DiaClave 
                        --inner join TransProd trD on tt.TransProdID = trD.TransProdID
                        --inner join TransProdDetalle tC on tr.TransProdID = tC.TransProdID and tt.TransProdDetalleID = tC.TransProdDetalleID 
                        --inner join Usuario on Usuario.USUId = tt.MUsuarioID  
                        --where diaC.FechaCaptura = @Dia and dbo.FNObtenerRutaADMInter (Usuario.Clave) =  @RutClave 
                        --and tr.tipo = 24
                        --group by  tc.ProductoClave

                        --DECLARE @CursorMOV CURSOR
                                                
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
                             
                               --select cast(tc.ProductoClave as Int), sum(tc.Cantidad) as Consignacion
                               --from TrpTpd tt 
                                --inner join TransProd tr on tt.TransProdID1 = tr.TransProdID
                               --inner join Dia diaC on tr.DiaClave = diaC.DiaClave 
                               --inner join TransProd trD on tt.TransProdID = trD.TransProdID
                               --inner join TransProdDetalle tC on tr.TransProdID = tC.TransProdID and tt.TransProdDetalleID = tC.TransProdDetalleID 
                               --inner join Usuario on Usuario.USUId = tt.MUsuarioID  
                               --where diaC.FechaCaptura = @Dia and dbo.FNObtenerRutaADMInter (Usuario.Clave) =  @RutClave 
                               --and tr.tipo = 24
                               --group by  tc.ProductoClave

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
                        declare @DiasCredito as int
                        
                        --OBTIENE LAS VENTAS REALIZADAS
                        DECLARE @CursorVar2 CURSOR  

                        SET @CursorVar2 = CURSOR SCROLL DYNAMIC FOR 
                        SELECT TP.Subtotal ,TP.Impuesto, V.ClienteClave, TP.TransProdId, TP.CFVTipo,dbo.FNObtenerSoloNumeros(TP.Folio) as folio, TP.DiasCredito
                        FROM TransProd as TP 
                        INNER JOIN Visita V ON V.VisitaClave = TP.VisitaClave1 AND V.DiaClave = TP.DiaClave1 
                        INNER JOIN vendedor VE on VE.VendedorId = V.VendedorId
                        INNER JOIN Usuario as Us on Us.USUId = VE.USUId
                        where TP.tipo=1 and TP.TipoFase=2 and  TP.DiaClave1= @DiaClave 
                        AND((TP.MFechaHora between @FechaIn and @FechaFin) OR (@FechaIn = @FechaIniCompara AND TP.TipoFaseIntSal IN (0,2)))
                        AND  (Us.Clave = @vende) and TP.Facturaid is null
                        union
                        SELECT TP.Subtotal ,TP.Impuesto, V.ClienteClave, TP.TransProdId, TP.CFVTipo,dbo.FNObtenerSoloNumeros(TP.Folio) as folio, TP.DiasCredito
                        FROM TransProd as TP 
                        INNER JOIN Visita V ON V.VisitaClave = TP.VisitaClave AND V.DiaClave = TP.DiaClave 
                        INNER JOIN vendedor VE on VE.VendedorId = V.VendedorId
                        INNER JOIN Usuario as Us on Us.USUId = VE.USUId
                        where TP.tipo=1 and TP.TipoFase=2 and  TP.DiaClave= @DiaClave 
                        AND((TP.MFechaHora between @FechaIn and @FechaFin) OR (@FechaIn = @FechaIniCompara AND TP.TipoFaseIntSal IN (0,2)))
                        AND  (Us.Clave = @vende) and TP.Facturaid is null
                        
                        
                        OPEN  @CursorVar2

                        FETCH NEXT FROM @CursorVar2 INTO @Subtotal, @Impuesto,@ClienteClave, @TransProdId, @TipoVenta,@Folio, @DiasCredito

                        WHILE @@FETCH_STATUS = 0      
                        BEGIN 


                             --set @Folio=(select isnull(max(folio)+1,1) from [RouteADM].dbo.Ventas where idCedis=@ClaveCEDI and Serie=@SerieFactContado)
							set @IdClienteContadoTmp = (select IdCliente from [RouteADM].dbo.ClienteSucursal where IdSucursal = @ClienteClave and IdCedis = @ClaveCEDI)
							if(@IdClienteContadoTmp is not null)
								SET @IdClienteContado = @IdClienteContadoTmp
             
                             insert into [RouteADM].dbo.Ventas (IdCedis,IdSurtido,IdTipoVenta,Folio,Serie,Fecha,IdCliente,Subtotal,Iva,IdSucursal,DiasCredito)
                              values(@ClaveCEDI,@Surtido,@TipoVenta,@Folio,@SerieFactContado,@Dia,@IdClienteContado,@Subtotal,@Impuesto,@ClienteClave, @DiasCredito)
                             
                             insert into [RouteADM].dbo.VentasDetalle (IdCedis,IdSurtido,IdTipoVenta,Folio,IdProducto,Serie,Cantidad,Precio,Iva)
                             select @ClaveCEDI,@Surtido,@TipoVenta,@Folio, productoclave,@SerieFactContado,sum(Piezas),
                             SUM(SubTotal - DescuentoCliente - ((SubTotal - DescuentoCliente) * (DescVendPor / 100)))/sum(Piezas) ,
                             sum(Impuesto - DescClienteImpuesto - ((Impuesto - DescClienteImpuesto) * (DescVendPor / 100))) 
                             FROM (      SELECT TD.ProductoClave, TD.SubTotal,
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
                             
                             
                             FETCH NEXT FROM @CursorVar2 INTO @Subtotal, @Impuesto,@ClienteClave, @TransProdId, @TipoVenta,@Folio, @DiasCredito
                        END
                        CLOSE @CursorVar2  
                                               
                                               
                                               
                                               
                                               ----------------------------------Facturas NO Electronicas***************
                                               
                                               
                                               
                                                     select @IdClienteContado=IdClienteContado,@SerieFactContado=SerieFacturasCredito
                        from [RouteADM].dbo.Configuracion              
                                   
                                               SET @CursorVar2 = CURSOR SCROLL DYNAMIC FOR 
                        SELECT TP.Subtotal ,TP.Impuesto, V.ClienteClave, TP.TransProdId, TP.CFVTipo,dbo.FNObtenerSoloNumeros(TP.Folio), TP.DiasCredito
                        FROM TransProd as TP 
                        INNER JOIN Visita V ON V.VisitaClave = TP.VisitaClave AND V.DiaClave = TP.DiaClave 
                        INNER JOIN vendedor VE on VE.VendedorId = V.VendedorId
                        INNER JOIN Usuario as Us on Us.USUId = VE.USUId
                        where TP.tipo=8   and  TP.DiaClave= @DiaClave 
                        AND((TP.MFechaHora between @FechaIn and @FechaFin) OR (@FechaIn = @FechaIniCompara AND TP.TipoFaseIntSal IN (0,2)))
                        AND  (Us.Clave = @vende)

                        
                        
                        OPEN  @CursorVar2

                        FETCH NEXT FROM @CursorVar2 INTO @Subtotal, @Impuesto,@ClienteClave, @TransProdId, @TipoVenta,@Folio, @DiasCredito

                        WHILE @@FETCH_STATUS = 0      
                        BEGIN 
                        
							set @IdClienteContadoTmp = (select IdCliente from [RouteADM].dbo.ClienteSucursal where IdSucursal = @ClienteClave and IdCedis = @ClaveCEDI)
							if(@IdClienteContadoTmp is not null)
								SET @IdClienteContado = @IdClienteContadoTmp
								
                             insert into [RouteADM].dbo.Ventas (IdCedis,IdSurtido,IdTipoVenta,Folio,Serie,Fecha,IdCliente,Subtotal,Iva,IdSucursal,DiasCredito)
                              values(@ClaveCEDI,@Surtido,@TipoVenta,@Folio,@SerieFactContado,@Dia,@IdClienteContado,@Subtotal,@Impuesto,@ClienteClave, @DiasCredito)
                             
                             insert into [RouteADM].dbo.VentasDetalle (IdCedis,IdSurtido,IdTipoVenta,Folio,IdProducto,Serie,Cantidad,Precio,Iva)
                             select @ClaveCEDI,@Surtido,@TipoVenta,@Folio, productoclave,@SerieFactContado,sum(Piezas),
                             SUM(SubTotal - DescuentoCliente - ((SubTotal - DescuentoCliente) * (DescVendPor / 100)))/sum(Piezas) ,
                             sum(Impuesto - DescClienteImpuesto - ((Impuesto - DescClienteImpuesto) * (DescVendPor / 100))) 
                              FROM (      SELECT TD.ProductoClave, TD.SubTotal,
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
                             
                             
                             FETCH NEXT FROM @CursorVar2 INTO @Subtotal, @Impuesto,@ClienteClave, @TransProdId, @TipoVenta,@Folio, @DiasCredito
                        END
                        CLOSE @CursorVar2  
                        
                        
                        
                        
                                               ----------------------------------Facturas Electronicas***************
                                               
                                               
                                               
                                               
                                               SET @CursorVar2 = CURSOR SCROLL DYNAMIC FOR 
                        SELECT TP.Subtotal ,TP.Impuesto, V.ClienteClave, TP.TransProdId, TP.CFVTipo, replace(TP.Folio,TRD.Serie,'')as Folio,TRD.Serie, TP.DiasCredito
                        FROM TransProd as TP 
                        inner join trpdatofiscal TRD on TP.Transprodid=tp.transprodid
                        INNER JOIN Visita V ON V.VisitaClave = TP.VisitaClave AND V.DiaClave = TP.DiaClave 
                        INNER JOIN vendedor VE on VE.VendedorId = V.VendedorId
                        INNER JOIN Usuario as Us on Us.USUId = VE.USUId
                        where TP.tipo=8 and   TP.DiaClave= @DiaClave 
                        AND((TP.MFechaHora between @FechaIn and @FechaFin) OR (@FechaIn = @FechaIniCompara AND TP.TipoFaseIntSal IN (0,2)))
                        AND  (Us.Clave = @vende)

                        
                        
                        OPEN  @CursorVar2

                        FETCH NEXT FROM @CursorVar2 INTO @Subtotal, @Impuesto,@ClienteClave, @TransProdId, @TipoVenta,@Folio,@Serie, @DiasCredito

                        WHILE @@FETCH_STATUS = 0      
                        BEGIN 
                        
							set @IdClienteContadoTmp = (select IdCliente from [RouteADM].dbo.ClienteSucursal where IdSucursal = @ClienteClave and IdCedis = @ClaveCEDI)
							if(@IdClienteContadoTmp is not null)
								SET @IdClienteContado = @IdClienteContadoTmp
								
                             insert into [RouteADM].dbo.Ventas (IdCedis,IdSurtido,IdTipoVenta,Folio,Serie,Fecha,IdCliente,Subtotal,Iva,IdSucursal, DiasCredito)
                              values(@ClaveCEDI,@Surtido,@TipoVenta,@Folio,@Serie,@Dia,@IdClienteContado,@Subtotal,@Impuesto,@ClienteClave, @DiasCredito)
                             
                             insert into [RouteADM].dbo.VentasDetalle (IdCedis,IdSurtido,IdTipoVenta,Folio,IdProducto,Serie,Cantidad,Precio,Iva)
                             select @ClaveCEDI,@Surtido,@TipoVenta,@Folio, productoclave,@Serie,sum(Piezas),
                             SUM(SubTotal - DescuentoCliente - ((SubTotal - DescuentoCliente) * (DescVendPor / 100)))/sum(Piezas) ,
                             sum(Impuesto - DescClienteImpuesto - ((Impuesto - DescClienteImpuesto) * (DescVendPor / 100))) 
                             FROM (      SELECT TD.ProductoClave, TD.SubTotal,
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
                             
                             
                             FETCH NEXT FROM @CursorVar2 INTO @Subtotal, @Impuesto,@ClienteClave, @TransProdId, @TipoVenta,@Folio,@Serie, @DiasCredito
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
      
      SET XACT_ABORT ON  
      SET NOCOUNT OFF

      exec [RouteADM].dbo.up_ActualizaKardex @ClaveCEDI, @DiaClave, @Surtido, 4

END



GO

/****** Object:  StoredProcedure [dbo].[sp_tg_PreliquidacionManagement]    Script Date: 10/20/2010 10:38:22 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER OFF
GO



--------****************************---------------
-- Directo a  SurtidosDenominacion
---------------


CREATE Procedure [dbo].[sp_tg_PreliquidacionManagement]
@FechaIn as datetime, @FechaFin as datetime, @vende as varchar(20)
AS    
SET XACT_ABORT OFF    
SET NOCOUNT OFF  


Declare  @IdCedis  as varchar(255) , @IdSurtido  as varchar(255) ,@IdDenominacion as varchar(255),@TipoDenominacion as varchar(255),@Cantidad  as varchar(255)
  
declare @curTmp  cursor  

set @curTmp = Cursor scroll dynamic FOR
select dbo.FNObtenerCEDIADMInter(A.Clave),S.IdSurtido,Vd.Descripcion,VAV.Grupo,Cantidad from Preliquidacion P
inner join PLIEfectivo PE on  PE.PLIId=P.PLIId
inner join VARValor VAV on  VAV.VAVClave=PE.TipoEfectivo and VAV.VARCodigo='DENOMINA'
inner join vavdescripcion vd on vd.varcodigo = vav.varcodigo and vd.vavclave = vav.vavclave 
inner join Vendedor V on P.VendedorId = V.VendedorID
inner join Usuario as Us on Us.USUId = V.USUId
inner join VenRut VR on VR.VendedorID=V.VendedorID
inner join VENCentroDistHist VC on VC.VendedorId=V.VendedorID and getdate() between VC.VCHFechaInicial and VC.FechaFinal
inner join almacen A on A.Almacenid=VC.Almacenid
inner join RouteADM.dbo.Surtidos S on  dbo.FNObtenerCEDIADMInter(A.Clave)=cast(S.IdCedis AS VARCHAR(255)) and Fecha=CONvERT(DATETIME,CONvERT(VARCHAR(20),FechaPreLiquidacion,111),111) and idruta=dbo.FNObtenerRutaADMInter(VR.RutClave) and S.Status='P'
where P.FechaPreLiquidacion between @FechaIn and @FechaFin
AND (Us.Clave = @vende)  


 
open @curTmp  
  

Fetch next from @curTmp  
Into  @IdCedis  , @IdSurtido   ,@IdDenominacion ,@TipoDenominacion ,@Cantidad   
  
while @@FETCH_STATUS = 0  
BEGIN  

if((SELECT Count(*) FROM  RouteADM.dbo.SurtidosDenominacion S WHERE S.IdCedis=@IdCedis and S.IdSurtido=@IdSurtido and S.IdMoneda = 'MXP' and S.IdDenominacion=@IdDenominacion and S.TipoDenominacion=@TipoDenominacion)=0)  
      BEGIN  
      
            INSERT INTO  RouteADM.dbo.SurtidosDenominacion values(@IdCedis,@IdSurtido,'','MXP',@IdDenominacion,@TipoDenominacion,@Cantidad)
      END  
      ELSE
      BEGIN
            
            Update    RouteADM.dbo.SurtidosDenominacion  set Cantidad =@Cantidad WHERE IdCedis=@IdCedis and IdSurtido=@IdSurtido and IdMoneda = 'MXP' and IdDenominacion=@IdDenominacion and TipoDenominacion=@TipoDenominacion
      END
      
      Fetch next from @curTmp  
      Into @IdCedis  , @IdSurtido   ,@IdDenominacion ,@TipoDenominacion ,@Cantidad   
END

Close @curTmp


GO


