USE [RouteCPC]
GO

/****** Object:  StoredProcedure [dbo].[up_VentasFactura]    Script Date: 05/30/2011 13:13:42 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[up_VentasFactura]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[up_VentasFactura]
GO

USE [RouteCPC]
GO

/****** Object:  StoredProcedure [dbo].[up_VentasFactura]    Script Date: 05/30/2011 13:13:42 ******/
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

declare @TransprodId as varchar(20), @TransprodIdFactura as varchar(20)
declare @IdCedisCFD as int 
declare @VendedorId as varchar(20)

if @Opc = 1
begin
begin tran 

	set @IdCedisCFD = 1
	
	update Route.dbo.FolioSolicitado set MUsuarioID = 'CFDCed' + CAST(@IdCedisCFD as varchar(10)), MFechaHora = GETDATE()
	from Route.dbo.SubEmpresa SubE 
	inner join Route.dbo.Folio Folio on SubE.SubEmpresaId = Folio.SubEmpresaId 
	inner join Route.dbo.FolioSolicitado FolS on Folio.FolioID = FolS.FolioID 
	inner join Route.dbo.FOSHist FosH on FosH.FolioID = FolS.FolioID and FosH.FOSId = FolS.FOSId 
	where SubE.TipoEstado = 1 and FosH.VendedorID = 'CFDCed' + CAST(@IdCedisCFD as varchar(10))

	select @TransprodId = RIGHT(REPLACE(CONVERT(VARCHAR(36),NEWID()),'-',''),16)
	select @TransprodIdFactura = RIGHT(REPLACE(CONVERT(VARCHAR(36),NEWID()),'-',''),16)

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

	select @VendedorId = 'CFDCed' + CAST(@IdCedisCFD as varchar(10))
	
	if @Actividad = 1 
	begin
		
		declare @FormatoFolio as varchar(16)
		select top 1 @FormatoFolio = fd.Formato 
		from Route.dbo.FolioSolicitado fs
		inner join Route.dbo.Foliodetalle fd on fd.FolioID = fs.FolioID
		where Usados < CantSolicitada and Serie = @SerieN 
		order by Usados desc
		
		update VentasAcredita set Factura = @SerieN + right(@FormatoFolio + CAST(Folio as varchar(20)), LEN(@FormatoFolio))
		where IdCedis = @IdCedis and Serie = @Serie and IdTipoVenta = @IdTipoVenta and Folio = @Folio 

		insert into VentasFacturaCFD 
		values (@IdCedis, 0, @IdTipoVenta, @Serie, @Folio, @SerieN, @FolioN, @TransprodId, @TransprodIdFactura, GETDATE())
		
		exec Route.dbo.sp_importVentasCPC @IdCedis, @IdTipoVenta, @Folio, @Serie, @TransprodId, @TransprodIdFactura, @VendedorId, 0 
	
		update Route.dbo.TransProd set Folio = @SerieN + right(@FormatoFolio + CAST(@FolioN as varchar(20)), LEN(@FormatoFolio))
		where TransProdID in (@TransprodId, @TransprodIdFactura) 

		update Route.dbo.TransProd set FechaFacturacion = GETDATE()
		where TransProdID in (@TransprodIdFactura) 
		
	end

commit tran
end

if @Opc = 3
begin
begin tran 

	set @IdCedisCFD = 1
	
	update Route.dbo.FolioSolicitado set MUsuarioID = 'CFDCed' + CAST(@IdCedisCFD as varchar(10)), MFechaHora = GETDATE()
	from Route.dbo.SubEmpresa SubE 
	inner join Route.dbo.Folio Folio on SubE.SubEmpresaId = Folio.SubEmpresaId 
	inner join Route.dbo.FolioSolicitado FolS on Folio.FolioID = FolS.FolioID 
	inner join Route.dbo.FOSHist FosH on FosH.FolioID = FolS.FolioID and FosH.FOSId = FolS.FOSId 
	where SubE.TipoEstado = 1 and FosH.VendedorID = 'CFDCed' + CAST(@IdCedisCFD as varchar(10))

	select @TransprodId = RIGHT(REPLACE(CONVERT(VARCHAR(36),NEWID()),'-',''),16)
	select @TransprodIdFactura = RIGHT(REPLACE(CONVERT(VARCHAR(36),NEWID()),'-',''),16)

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

		insert into VentasFacturaCFD 
		values (@IdCedis, 0, @IdTipoVenta, @Serie, @Folio, @SerieN, @FolioN, @TransprodId, @TransprodIdFactura, GETDATE())

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

GO


