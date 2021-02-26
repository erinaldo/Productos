USE [Route]
GO

/****** Object:  StoredProcedure [dbo].[SP_CancelarFactura]    Script Date: 07/01/2011 12:30:16 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_CancelarFactura]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[SP_CancelarFactura]
GO

USE [Route]
GO

/****** Object:  StoredProcedure [dbo].[SP_CancelarFactura]    Script Date: 07/01/2011 12:30:16 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE Procedure [dbo].[SP_CancelarFactura]
@IdFactura varchar(16),
@ClaveUsuario varchar(16)
as Begin
	declare @UsuID as varchar(16)
	declare @ClienteClave as varchar(16)
	declare @CFVTipo as smallint
	declare @CobrarVentas as bit
	declare @PagoAutomatico as bit
	declare @ClientePagoID as smallint
	declare @Total as float
	declare @Saldo as float
	declare @Puntos as float
	
	if(exists(Select * from Usuario where Clave=@ClaveUsuario))
		Select @UsuID=USUId from Usuario where Clave=@ClaveUsuario
	ELSE
		set @UsuID='Interfaz'
		

	select top 1 @CobrarVentas=CobrarVentas,@PagoAutomatico=PagoAutomatico from CONHist order by CONHist.CONHistFechaInicio desc
	
	select @CFVTipo = FAC.CFVTipo, @Total = FAC.Total, @ClienteClave = VIS.ClienteClave, @ClientePagoID = max(ven.ClientePagoID), @Saldo = FAC.Saldo  
	from TransProd FAC 
	inner join TransProd VEN on FAC.TransProdID = VEN.FacturaID 
	inner join Dia on Dia.DiaClave = FAC.DiaClave 
	inner join Visita VIS on VIS.VisitaClave = FAC.VisitaClave and VIS.DiaClave = FAC.DiaClave 
	where FAC.TransProdID = @IdFactura 
	group by FAC.CFVTipo, FAC.Total, VIS.ClienteClave, FAC.Saldo
	

	if(@CFVTipo=2 and @CobrarVentas=0)
	begin
		update Cliente set SaldoEfectivo=SaldoEfectivo-@Saldo,MFechaHora=GETDATE(),MUsuarioID=@UsuID where ClienteClave=@ClienteClave
	end

	if(@CFVTipo=1 and @ClientePagoID=1 and @CobrarVentas=0 and @PagoAutomatico=1)
	begin
		delete ABNDetalle from ABNDetalle inner join Abono on ABNDetalle.ABNId=Abono.ABNId inner join AbnTrp on AbnTrp.ABNId=Abono.ABNId where AbnTrp.TransProdID=@IdFactura
		delete Abono from Abono inner join AbnTrp on AbnTrp.ABNId=Abono.ABNId where AbnTrp.TransProdID=@IdFactura 
		delete AbnTrp where AbnTrp.TransProdID=@IdFactura 
		update TransProd Set Saldo =Total where TransProdID=@IdFactura 
	end
	
	if(@CFVTipo=1 and @ClientePagoID=1 and @CobrarVentas=1 and @PagoAutomatico=1)
	begin
		delete ABNDetalle from ABNDetalle inner join Abono on ABNDetalle.ABNId=Abono.ABNId inner join AbnTrp on AbnTrp.ABNId=Abono.ABNId  inner join TransProd on TransProd.TransProdID=AbnTrp.TransProdID where TransProd.FacturaID=@IdFactura 
		delete Abono from Abono inner join AbnTrp on AbnTrp.ABNId=Abono.ABNId inner join TransProd on TransProd.TransProdID=AbnTrp.TransProdID where TransProd.FacturaID=@IdFactura 
		delete AbnTrp From AbnTrp inner join TransProd on TransProd.TransProdID=AbnTrp.TransProdID where TransProd.FacturaID=@IdFactura 
		update TransProd Set Saldo =Total where TransProdID=@IdFactura 
	end
	
	delete ProductoNegado From ProductoNegado P inner join TransProd T on T.TransProdID=P.TransProdID where not PromocionClave is null and T.FacturaID =@IdFactura 
	delete TpdDesVendedor From TpdDesVendedor D inner join TransProd T on T.TransProdID=D.TransProdID where T.FacturaID =@IdFactura 
		
	select @Puntos=isnull(sum(isnull(Puntos,0)),0)  from TpdPun P inner join Transprod  t on T.TransProdId =P.TransprodID where T.FacturaID=@IdFactura 
	update Punto set Saldo=Saldo-@Puntos,MFechaHora=GETDATE(),MUsuarioID=@UsuID where ClienteClave=@ClienteClave
					
	
	--CancelaFactura
	Update TransProd Set TipoFase=0,MUsuarioID=@UsuID,MFechaHora=GETDATE(),FechaCancelacion=GETDATE() From TransProd where TransProdID=@IdFactura 
	--CancelaVentas
	Update TransProd Set TipoFase=0,MUsuarioID=@UsuID,MFechaHora=GETDATE(),FechaCancelacion=GETDATE(),FacturaID =null,FechaFacturacion=null From TransProd where FacturaID=@IdFactura 
		
end



GO


