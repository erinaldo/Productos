/****** Object:  StoredProcedure [dbo].[sp_tg_exportCargaSugerida]    Script Date: 04/11/2010 22:03:10 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_tg_exportCargaSugerida]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_tg_exportCargaSugerida]
/*go*/go

/****** Object:  StoredProcedure [dbo].[sp_tg_exportCargaSugerida]    Script Date: 04/11/2010 22:03:10 ******/
SET ANSI_NULLS ON
/*go*/go
SET QUOTED_IDENTIFIER OFF
/*go*/go




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
/*go*/go


