USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[up_VentasContado]    Script Date: 05/15/2011 18:55:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[up_VentasContado]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[up_VentasContado]
GO

USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[up_VentasContado]    Script Date: 05/15/2011 18:55:28 ******/
SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER OFF
GO



CREATE PROCEDURE [dbo].[up_VentasContado]
@IdCedis as bigint,
@Fecha as datetime,
@Folio as bigint,
@Serie as varchar(5),
@Status as varchar(5),
@IdMarca as bigint,
@Opc as int

AS

if @Opc = 1 -- Inserta Factura Nueva
begin
	--if not exists( select Folio from VentasContado where IdCedis = @IdCedis and Fecha = @Fecha and Serie = @Serie and IdMarca = @IdMarca)
	--begin
	--	select @Folio = isnull(FS.Usados + 1, 1)
	--	from Route.dbo.FolioSolicitado FS
	--	where Serie = @Serie 
	
	--	insert into VentasContado values (@IdCedis, @Fecha, @Folio, @Serie, @Status, @IdMarca)	
		
	--	update Route.dbo.FolioSolicitado set Usados = @Folio where Serie = @Serie 
	--end
	--else

begin tran 

	declare @TransprodId as varchar(20), @TransprodIdFactura as varchar(20)
	
	update Route.dbo.FolioSolicitado set MUsuarioID = 'CFDCed' + CAST(@IdCedis as varchar(10)), MFechaHora = GETDATE()
	from Route.dbo.SubEmpresa SubE 
	inner join Route.dbo.Folio Folio on SubE.SubEmpresaId = Folio.SubEmpresaId 
	inner join Route.dbo.FolioSolicitado FolS on Folio.FolioID = FolS.FolioID 
	inner join Route.dbo.FOSHist FosH on FosH.FolioID = FolS.FolioID and FosH.FOSId = FolS.FOSId 
	where SubE.TipoEstado = 1 and FosH.VendedorID = 'CFDCed' + CAST(@IdCedis as varchar(10))

	select @TransprodId = RIGHT(REPLACE(CONVERT(VARCHAR(36),NEWID()),'-',''),16)
	select @TransprodIdFactura = RIGHT(REPLACE(CONVERT(VARCHAR(36),NEWID()),'-',''),16)

	select @Serie = FolS.Serie, @Folio = isnull((FolS.Usados) + 1,1) 
	from Route.dbo.SubEmpresa SubE 
	inner join Route.dbo.Folio Folio on SubE.SubEmpresaId = Folio.SubEmpresaId 
	inner join Route.dbo.FolioSolicitado FolS on Folio.FolioID = FolS.FolioID 
	inner join Route.dbo.FOSHist FosH on FosH.FolioID = FolS.FolioID and FosH.FOSId = FolS.FOSId 
	where SubE.TipoEstado = 1 and FosH.VendedorID = 'CFDCed' + CAST(@IdCedis as varchar(10))

	update Route.dbo.FolioSolicitado set Usados = @Folio 
	from Route.dbo.SubEmpresa SubE 
	inner join Route.dbo.Folio Folio on SubE.SubEmpresaId = Folio.SubEmpresaId 
	inner join Route.dbo.FolioSolicitado FolS on Folio.FolioID = FolS.FolioID 
	inner join Route.dbo.FOSHist FosH on FosH.FolioID = FolS.FolioID and FosH.FOSId = FolS.FOSId 
	where SubE.TipoEstado = 1 and FosH.VendedorID = 'CFDCed' + CAST(@IdCedis as varchar(10))

	declare @VendedorId as varchar(20)
	select @VendedorId = 'CFDCed' + CAST(@IdCedis as varchar(10))
	
	insert into VentasContado values (@IdCedis, @Fecha, @Folio, @Serie, 'A', 1 )

	insert into VentasFacturaCFD 
	values (@IdCedis, 0, 1, @Folio, 0, @Fecha, @Serie, @Folio, @TransprodId, @TransprodIdFactura, GETDATE())

	exec Route.dbo.sp_importVentaCPGADM @IdCedis, @Fecha, 1, @Folio, @Serie, @TransprodId, @TransprodIdFactura, @VendedorId, 0 

commit tran	
end

GO


