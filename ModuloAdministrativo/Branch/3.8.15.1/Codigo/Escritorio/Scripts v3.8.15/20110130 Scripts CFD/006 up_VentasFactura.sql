USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[up_VentasFactura]    Script Date: 01/31/2011 00:52:57 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[up_VentasFactura]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[up_VentasFactura]
GO

USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[up_VentasFactura]    Script Date: 01/31/2011 00:52:57 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO





CREATE PROCEDURE [dbo].[up_VentasFactura] 
@IdCedis as bigint,
@IdSurtido as bigint,
@IdTipoVenta as int,
@Folio as bigint,
@Serie as varchar(5),
@FolioN as bigint,
@SerieN as varchar(5),
@Opc as int

AS

declare 
@TVenta as bigint,
@IdRuta as bigint,
@IdLista as bigint

if @Opc = 1 -- Inserta Factura Nueva
begin

	--select @IdRuta = isnull(Surtidos.IdRuta,0) 
	--from Surtidos 
	--inner join Rutas on Rutas.IdCedis = Surtidos.IdCedis and Rutas.IdRuta = Surtidos.IdRuta and CFD = 1
	--where Surtidos.IdCedis = @IdCedis and Surtidos.IdSurtido = @IdSurtido 

	--if @IdRuta <> 0 and @IdRuta is not null
	--begin
	--	if exists( select Usados from Route.dbo.FolioSolicitado FolS, Route.dbo.FOSHist FosH 
	--		where FosH.FolioID = FolS.FolioID and FosH.FOSId = FosH.FOSId 
	--		and FosH.VendedorID = CAST(@IdCedis as varchar(10)) + REPLICATE('0', 4-len(@IdRuta)) + CAST(@IdRuta as varchar(4)) 
	--		and FolS.Serie = @SerieN and FolS.Usados >= @FolioN )
	--	begin
	--		select @FolioN = ISNULL(Usados+1,1) 
	--		from Route.dbo.FolioSolicitado FolS, Route.dbo.FOSHist FosH 
	--		where FosH.FolioID = FolS.FolioID and FosH.FOSId = FosH.FOSId 
	--		and FosH.VendedorID = CAST(@IdCedis as varchar(10)) + REPLICATE('0', 4-len(@IdRuta)) + CAST(@IdRuta as varchar(4)) 
	--		and FolS.Serie = @SerieN 
			
	--		select @FolioN			
	--	end
		
	--	update Route.dbo.FolioSolicitado set Usados = @FolioN 
	--	from Route.dbo.FolioSolicitado FolS, Route.dbo.FOSHist FosH 
	--	where FosH.FolioID = FolS.FolioID and FosH.FOSId = FosH.FOSId 
	--	and FosH.VendedorID = CAST(@IdCedis as varchar(10)) + REPLICATE('0', 4-len(@IdRuta)) + CAST(@IdRuta as varchar(4)) 
	--	and FolS.Serie = @SerieN 
	--end

	update VentasDetalle set Serie = @SerieN, Folio = @FolioN 
	where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdTipoVenta = @IdTipoVenta and Folio = @Folio and Serie = @Serie

	update Ventas set Serie = @SerieN, Folio = @FolioN 
	where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdTipoVenta = @IdTipoVenta and Folio = @Folio and Serie = @Serie
	
	update Pedidos set Serie = @SerieN, Folio = @FolioN 
	where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdTipoVenta = @IdTipoVenta and Folio = @Folio 
	
	update VentasAcredita set Serie = @SerieN, Folio = @FolioN 
	where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdTipoVenta = @IdTipoVenta and Folio = @Folio 
	
	update VentasDevolucion set Serie = @SerieN, Folio = @FolioN 
	where IdCedisD = @IdCedis and IdSurtido = @IdSurtido and IdTipoVenta = @IdTipoVenta and Folio = @Folio 
	
end

if @Opc = 2 -- Valida Marca
begin
	select @IdRuta = isnull(Surtidos.IdRuta,0) 
	from Surtidos 
	inner join Rutas on Rutas.IdCedis = Surtidos.IdCedis and Rutas.IdRuta = Surtidos.IdRuta and CFD = 1
	where Surtidos.IdCedis = @IdCedis and Surtidos.IdSurtido = @IdSurtido 
	
	if @IdRuta <> 0
		select (select SubE.SubEmpresaId
			from Route.dbo.SubEmpresa SubE 
			inner join Route.dbo.Folio Folio on SubE.SubEmpresaId = Folio.SubEmpresaId 
			inner join Route.dbo.FolioSolicitado FolS on Folio.FolioID = FolS.FolioID 
			inner join Route.dbo.FOSHist FosH on FosH.FolioID = FolS.FolioID and FosH.FOSId = FosH.FOSId 
			where SubE.TipoEstado = 1 and FosH.VendedorID = CAST(@IdCedis as varchar(10)) + REPLICATE('0', 4-len(@IdRuta)) + CAST(@IdRuta as varchar(4))) , 
		(select distinct top 1 IdMarca 
			from VentasDetalle 
			inner join Productos on Productos.IdProducto = VentasDetalle.IdProducto 
			where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdTipoVenta = @IdTipoVenta and Folio = @Folio and Serie = @Serie) as Valida
	else
		select IdCedis, IdCedis as Valida
		from Configuracion 
		where IdCedis = @IdCedis

end

GO


