USE [RouteCPC]
GO

/****** Object:  StoredProcedure [dbo].[up_VentasFactura]    Script Date: 07/19/2011 16:50:36 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[up_VentasFactura]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[up_VentasFactura]
GO

USE [RouteCPC]
GO

/****** Object:  StoredProcedure [dbo].[up_VentasFactura]    Script Date: 07/19/2011 16:50:36 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO









CREATE PROCEDURE [dbo].[up_VentasFactura] 
@IdCedis as bigint,
@IdTipoVenta as int,
@Folio as bigint,
@Serie as varchar(5),
@FolioN as bigint,
@SerieN as varchar(5),
@Actividad as int,
@Opc as int

AS

--set @IdCedis = 1
--set @IdTipoVenta = 2
--set @Folio = 32109
--set @Serie = 'REM01'
--set @FolioN = 0
--set @SerieN = ''
--set @Actividad = 1
--set @Opc = 1

declare @TransprodId as varchar(20), @TransprodIdFactura as varchar(20)
declare @IdCedisCFD as int 
declare @VendedorId as varchar(20)
DECLARE @Lenguaje AS VARCHAR(20), @TipoVersion as varchar(20)
declare @UUID as varchar(100)
SET @Lenguaje = Route.dbo.FNObtenerLenguaje()

set @IdCedisCFD = 1

select @TipoVersion = Route.dbo.FNObtenerDescVR('VERFACTE',@Lenguaje, SemHist.VersionCFD)
from Route.dbo.SEMHist SemHist
inner join Route.dbo.SubEmpresa SubE on SubE.SubEmpresaId = SemHist.SubEmpresaId 
inner join Route.dbo.Folio Folio on SubE.SubEmpresaId = Folio.SubEmpresaId
inner join Route.dbo.FolioSolicitado FolS on Folio.FolioID = FolS.FolioID 
inner join Route.dbo.FOSHist FosH on FosH.FolioID = FolS.FolioID and FosH.FOSId = FolS.FOSId 
where SubE.TipoEstado = 1 and FosH.VendedorID = 'CFDCed' + CAST(@IdCedisCFD as varchar(10))

if @TipoVersion = '2.0'
	set @UUID = ''
else
	set @UUID = null
	
if @Opc = 1
begin
begin tran 

	set @IdCedisCFD = 1
	--execute up_VentasFactura 1, 2, 32109, 'REM01', 0, '', 1, 1
	
	--select * from RouteCPC.dbo.VentasFacturaCFD where Serie = 'REM01' and Folio = '32109' order by Fecha desc
	declare @FolioNtemp as bigint
	declare @SerieNtemp as varchar(5)
	
	select @TransprodId  = TransprodId , @TransprodIdFactura = TransprodIdFactura, @FolioNtemp= FolioFactura, @SerieNtemp = SerieFactura
	from VentasFacturaCFD 
	where IdCedis = @IdCedis and IdTipoVenta = @IdTipoVenta and Serie = @Serie and Folio = @Folio 

	--declare @VendedorId as varchar(20)
	select @VendedorId = 'CFDCed' + CAST(@IdCedis as varchar(10))

	if ((@TransprodId is not null) AND (@TransprodIdFactura is not null))
	begin
		set @FolioN = @FolioNtemp
		set @SerieN = @SerieNtemp
		
		if @Actividad = 1 			
			exec Route.dbo.sp_importVentasCPC @IdCedis, @IdTipoVenta, @Folio, @Serie, @TransprodId, @TransprodIdFactura, @VendedorId, 0 
	end
	else
	begin

		if not exists(
			select *
			from Route.dbo.SubEmpresa SubE 
			inner join Route.dbo.Folio Folio on SubE.SubEmpresaId = Folio.SubEmpresaId 
			inner join Route.dbo.FolioSolicitado FolS on Folio.FolioID = FolS.FolioID 
			inner join Route.dbo.FOSHist FosH on FosH.FolioID = FolS.FolioID and FosH.FOSId = FolS.FOSId 
			where SubE.TipoEstado = 1 and FosH.VendedorID = 'CFDCed' + CAST(@IdCedisCFD as varchar(10)) 
				and FolS.Serie = @SerieN and FolS.Usados >= @FolioN )
				
		begin
		
			update Route.dbo.FolioSolicitado set MUsuarioID = 'CFDCed' + CAST(@IdCedisCFD as varchar(10)), MFechaHora = GETDATE()
			from Route.dbo.SubEmpresa SubE 
			inner join Route.dbo.Folio Folio on SubE.SubEmpresaId = Folio.SubEmpresaId 
			inner join Route.dbo.FolioSolicitado FolS on Folio.FolioID = FolS.FolioID 
			inner join Route.dbo.FOSHist FosH on FosH.FolioID = FolS.FolioID and FosH.FOSId = FolS.FOSId 
			where SubE.TipoEstado = 1 and FosH.VendedorID = 'CFDCed' + CAST(@IdCedisCFD as varchar(10))

			select @SerieN = FolS.Serie, @FolioN = isnull((FolS.Usados) + 1,1) 
			from Route.dbo.SubEmpresa SubE 
			inner join Route.dbo.Folio Folio on SubE.SubEmpresaId = Folio.SubEmpresaId 
			inner join Route.dbo.FolioSolicitado FolS on Folio.FolioID = FolS.FolioID 
			inner join Route.dbo.FOSHist FosH on FosH.FolioID = FolS.FolioID and FosH.FOSId = FolS.FOSId 
			where SubE.TipoEstado = 1 and FosH.VendedorID = 'CFDCed' + CAST(@IdCedisCFD as varchar(10))

			update Route.dbo.FolioSolicitado set Usados = @FolioN 
			from Route.dbo.SubEmpresa SubE 
			inner join Route.dbo.Folio Folio on SubE.SubEmpresaId = Folio.SubEmpresaId 
			inner join Route.dbo.FolioSolicitado FolS on Folio.FolioID = FolS.FolioID 
			inner join Route.dbo.FOSHist FosH on FosH.FolioID = FolS.FolioID and FosH.FOSId = FolS.FOSId 
			where SubE.TipoEstado = 1 and FosH.VendedorID = 'CFDCed' + CAST(@IdCedisCFD as varchar(10))

		end
		
		select @TransprodId = RIGHT(REPLACE(CONVERT(VARCHAR(36),NEWID()),'-',''),16)
		select @TransprodIdFactura = RIGHT(REPLACE(CONVERT(VARCHAR(36),NEWID()),'-',''),16)
		
		if @Actividad = 1 
		begin
			
			declare @FormatoFolio as varchar(16)
			select top 1 @FormatoFolio = fd.Formato 
			from Route.dbo.FolioSolicitado fs
			inner join Route.dbo.Foliodetalle fd on fd.FolioID = fs.FolioID
			where Usados < CantSolicitada and Serie = @SerieN 
			order by Usados desc
			
			update VentasAcredita set Factura = @SerieN + right(@FormatoFolio + CAST(@FolioN as varchar(20)), LEN(@FormatoFolio))
			where IdCedis = @IdCedis and Serie = @Serie and IdTipoVenta = @IdTipoVenta and Folio = @Folio 
			
			if not exists(select * from VentasFacturaCFD where IdCedis = @IdCedis and SerieFactura = @SerieN and IdTipoVenta = @IdTipoVenta and FolioFactura = @FolioN )
				insert into VentasFacturaCFD 
				values (@IdCedis, 0, @IdTipoVenta, @Serie, @Folio, @SerieN, @FolioN, @TransprodId, @TransprodIdFactura, GETDATE(), @UUID)
			
			exec Route.dbo.sp_importVentasCPC @IdCedis, @IdTipoVenta, @Folio, @Serie, @TransprodId, @TransprodIdFactura, @VendedorId, 0 
				
			--update Route.dbo.TransProd set Folio = @SerieN + right(@FormatoFolio + CAST(@FolioN as varchar(20)), LEN(@FormatoFolio))
			--where TransProdID in (@TransprodId, @TransprodIdFactura) 

			--update Route.dbo.TransProd set FechaFacturacion = GETDATE()
			--where TransProdID in (@TransprodIdFactura) 
			
		end
	end	

	

commit tran
end

if @Opc = 3
begin
begin tran 

	set @IdCedisCFD = 1
	
	if not exists(
		select *
		from Route.dbo.SubEmpresa SubE 
		inner join Route.dbo.Folio Folio on SubE.SubEmpresaId = Folio.SubEmpresaId 
		inner join Route.dbo.FolioSolicitado FolS on Folio.FolioID = FolS.FolioID 
		inner join Route.dbo.FOSHist FosH on FosH.FolioID = FolS.FolioID and FosH.FOSId = FolS.FOSId 
		where SubE.TipoEstado = 1 and FosH.VendedorID = 'CFDCed' + CAST(@IdCedisCFD as varchar(10)) 
			and FolS.Serie = @SerieN and FolS.Usados >= @FolioN )
	begin

		update Route.dbo.FolioSolicitado set MUsuarioID = 'CFDCed' + CAST(@IdCedisCFD as varchar(10)), MFechaHora = GETDATE()
		from Route.dbo.SubEmpresa SubE 
		inner join Route.dbo.Folio Folio on SubE.SubEmpresaId = Folio.SubEmpresaId 
		inner join Route.dbo.FolioSolicitado FolS on Folio.FolioID = FolS.FolioID 
		inner join Route.dbo.FOSHist FosH on FosH.FolioID = FolS.FolioID and FosH.FOSId = FolS.FOSId 
		where SubE.TipoEstado = 1 and FosH.VendedorID = 'CFDCed' + CAST(@IdCedisCFD as varchar(10))

		select @SerieN = FolS.Serie, @FolioN = isnull((FolS.Usados) + 1,1) 
		from Route.dbo.SubEmpresa SubE 
		inner join Route.dbo.Folio Folio on SubE.SubEmpresaId = Folio.SubEmpresaId 
		inner join Route.dbo.FolioSolicitado FolS on Folio.FolioID = FolS.FolioID 
		inner join Route.dbo.FOSHist FosH on FosH.FolioID = FolS.FolioID and FosH.FOSId = FolS.FOSId 
		where SubE.TipoEstado = 1 and FosH.VendedorID = 'CFDCed' + CAST(@IdCedisCFD as varchar(10))

		update Route.dbo.FolioSolicitado set Usados = @FolioN 
		from Route.dbo.SubEmpresa SubE 
		inner join Route.dbo.Folio Folio on SubE.SubEmpresaId = Folio.SubEmpresaId 
		inner join Route.dbo.FolioSolicitado FolS on Folio.FolioID = FolS.FolioID 
		inner join Route.dbo.FOSHist FosH on FosH.FolioID = FolS.FolioID and FosH.FOSId = FolS.FOSId 
		where SubE.TipoEstado = 1 and FosH.VendedorID = 'CFDCed' + CAST(@IdCedisCFD as varchar(10))
	end
	
	select @TransprodId = RIGHT(REPLACE(CONVERT(VARCHAR(36),NEWID()),'-',''),16)
	select @TransprodIdFactura = RIGHT(REPLACE(CONVERT(VARCHAR(36),NEWID()),'-',''),16)

	select @VendedorId = 'CFDCed' + CAST(@IdCedisCFD as varchar(10))
	
	if @Actividad = 1 
	begin
		update VentasDetalle set Serie = @SerieN, Folio = @FolioN 
		where IdCedis = @IdCedis and Serie = @Serie and IdTipoVenta = @IdTipoVenta and Folio = @Folio and Serie = @Serie

		update Ventas set Serie = @SerieN, Folio = @FolioN 
		where IdCedis = @IdCedis and Serie = @Serie and IdTipoVenta = @IdTipoVenta and Folio = @Folio and Serie = @Serie
		
		update VentasImpuestos set Serie = @SerieN, Folio = @FolioN 
		where IdCedis = @IdCedis and Serie = @Serie and IdTipoVenta = @IdTipoVenta and Folio = @Folio 
		
		update VentasAcredita set Serie = @SerieN, Folio = @FolioN, Factura = @FolioN  
		where IdCedis = @IdCedis and Serie = @Serie and IdTipoVenta = @IdTipoVenta and Folio = @Folio 

		if not exists(select * from VentasFacturaCFD where IdCedis = @IdCedis and SerieFactura = @SerieN and IdTipoVenta = @IdTipoVenta and FolioFactura = @FolioN )
			insert into VentasFacturaCFD 
			values (@IdCedis, 0, @IdTipoVenta, @Serie, @Folio, @SerieN, @FolioN, @TransprodId, @TransprodIdFactura, GETDATE(), @UUID)

		exec Route.dbo.sp_importVentasCPC @IdCedis, @IdTipoVenta, @FolioN, @SerieN, @TransprodId, @TransprodIdFactura, @VendedorId, 0 
	end

commit tran
end

if @Opc = 4
begin

	declare @Fecha as datetime

	set @IdCedisCFD = 1
	
	select @TransprodId = TransprodId, @TransprodIdFactura = TransprodIdFactura, @SerieN = SerieFactura, @FolioN = FolioFactura
	from VentasFacturaCFD 
	where IdCedis = @IdCedis and Serie = @Serie and IdTipoVenta = @IdTipoVenta and Folio = @Folio 

	select @Fecha = FechaCaptura
	from Route.dbo.TransProd 
	where TransProdID = @TransprodIdFactura 

	exec Route.dbo.SP_CancelarVenta @FolioN, @SerieN, @Fecha, 'CFDCed1', 0 
	
	update VentasAcredita set Factura = ''
	where IdCedis = @IdCedis and Serie = @Serie and IdTipoVenta = @IdTipoVenta and Folio = @Folio 
		
	delete from VentasFacturaCFD 
	where IdCedis = @IdCedis and Serie = @Serie and IdTipoVenta = @IdTipoVenta and Folio = @Folio 
	
end

if @Opc = 5
begin

	select @UUID = Trp.UUID 
	from VentasFacturaCFD VtasF, Route.dbo.TRPDatoFiscal Trp
	where VtasF.TransprodIdFactura = Trp.TransProdID and VtasF.IdCedis = @IdCedis and VtasF.IdTipoVenta = @IdTipoVenta and 
		VtasF.SerieFactura = @SerieN and VtasF.FolioFactura = @FolioN 

	if @UUID is null and @TipoVersion = '2.0' set @UUID = ''

	update VentasFacturaCFD set UUID = @UUID 
	where IdCedis = @IdCedis and IdTipoVenta = @IdTipoVenta and 
		SerieFactura = @SerieN and FolioFactura = @FolioN 

end

if @Opc = 6
begin

	select @UUID = Trp.UUID 
	from VentasFacturaCFD VtasF, Route.dbo.TRPDatoFiscal Trp
	where VtasF.TransprodIdFactura = Trp.TransProdID and VtasF.IdCedis = @IdCedis and VtasF.IdTipoVenta = @IdTipoVenta and 
		VtasF.Serie = @Serie and VtasF.Folio = @Folio

	if @UUID is null and @TipoVersion = '2.0' set @UUID = ''

	update VentasFacturaCFD set UUID = @UUID 
	where IdCedis = @IdCedis and IdTipoVenta = @IdTipoVenta and 
		Serie = @Serie and Folio = @Folio

end

GO


