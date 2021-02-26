 
 -------------------------------------------------------------
--------------- Precedure Para Carga Sugerida -----------
-------------------------------------------------------------


if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_tg_PreliquidacionManagement]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_tg_PreliquidacionManagement]
/*go*/go


--------****************************---------------
-- Directo a  SurtidosDenominacion
---------------


CREATE Procedure [dbo].sp_tg_PreliquidacionManagement
@FechaIn as datetime, @FechaFin as datetime, @vende as varchar(20)
AS    
SET XACT_ABORT OFF    
SET NOCOUNT OFF  


Declare  @IdCedis  as varchar(255) , @IdSurtido  as varchar(255) ,@IdDenominacion as varchar(255),@TipoDenominacion as varchar(255),@Cantidad  as varchar(255)
  
declare @curTmp  cursor  

set @curTmp = Cursor scroll dynamic FOR
select cast(right(A.Clave,2) as int),S.IdSurtido,Vd.Descripcion,VAV.Grupo,Cantidad from Preliquidacion P
inner join PLIEfectivo PE on  PE.PLIId=P.PLIId
inner join VARValor VAV on  VAV.VAVClave=PE.TipoEfectivo and VAV.VARCodigo='DENOMINA'
inner join vavdescripcion vd on vd.varcodigo = vav.varcodigo and vd.vavclave = vav.vavclave 
inner join Vendedor V on P.VendedorId = V.VendedorID
inner join Usuario as Us on Us.USUId = V.USUId
inner join VenRut VR on VR.VendedorID=V.VendedorID
inner join VENCentroDistHist VC on VC.VendedorId=V.VendedorID and getdate() between VC.VCHFechaInicial and VC.FechaFinal
inner join almacen A on A.Almacenid=VC.Almacenid
inner join RouteADM.dbo.Surtidos S on cast(right(A.Clave,2) as int)=cast(S.IdCedis AS VARCHAR(255)) and Fecha=CONvERT(DATETIME,CONvERT(VARCHAR(20),FechaPreLiquidacion,111),111) and idruta=cast(right(VR.RutClave,4) as int) and S.Status='P'
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
