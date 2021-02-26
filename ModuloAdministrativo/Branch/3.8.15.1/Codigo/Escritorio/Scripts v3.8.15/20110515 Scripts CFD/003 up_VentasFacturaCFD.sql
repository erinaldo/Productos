USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[up_VentasFactura]    Script Date: 05/04/2011 20:09:17 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[up_VentasFactura]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[up_VentasFactura]
GO

USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[up_VentasFactura]    Script Date: 05/04/2011 20:09:17 ******/
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
@Actividad as int,
@Opc as int

AS

declare 
@TVenta as bigint,
@IdRuta as bigint,
@IdLista as bigint

if @Opc = 1 -- Inserta Factura Nueva
begin
	if @Actividad = 1 
	begin
		update VentasDetalle set Serie = @SerieN, Folio = @FolioN 
		where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdTipoVenta = @IdTipoVenta and Folio = @Folio and Serie = @Serie

		update Ventas set Serie = @SerieN, Folio = @FolioN 
		where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdTipoVenta = @IdTipoVenta and Folio = @Folio and Serie = @Serie
		
		update VentasImpuestos set Folio = @FolioN 
		where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdTipoVenta = @IdTipoVenta and Folio = @Folio 
		
		update Pedidos set Serie = @SerieN, Folio = @FolioN 
		where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdTipoVenta = @IdTipoVenta and Folio = @Folio 
		
		update VentasAcredita set Serie = @SerieN, Folio = @FolioN 
		where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdTipoVenta = @IdTipoVenta and Folio = @Folio 
		
		update VentasDevolucion set Serie = @SerieN, Folio = @FolioN 
		where IdCedisD = @IdCedis and IdSurtido = @IdSurtido and IdTipoVenta = @IdTipoVenta and Folio = @Folio 
	end	

	if @Actividad = 2
	begin
		update Pedidos set Serie = @SerieN, Folio = @FolioN, IdSurtido = 0 
		where IdCedis = @IdCedis and IdPedido = @IdSurtido
	end
end

if @Opc = 2 -- Valida Marca
begin
	if exists( select FS.Serie from Route.dbo.FolioSolicitado FS where Serie like '' + isnull((select SerieFacturasCredito from Configuracion where IdCedis = @IdCedis),'') + '%')
		select (select FH.CentroExpID  
			from Route.dbo.FolioSolicitado FS
			inner join Route.dbo.FOSHist FH on FH.FolioID = FS.FolioID and FS.FOSId = FH.FOSId 
			where Serie = @SerieN) , 
		(select distinct IdMarca 
			from VentasDetalle 
			inner join Productos on Productos.IdProducto = VentasDetalle.IdProducto 
			where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdTipoVenta = @IdTipoVenta and Folio = @Folio and Serie = @Serie) as Valida
	else
		select IdCedis, IdCedis as Valida
		from Configuracion 
		where IdCedis = @IdCedis

end

if @Opc = 3
begin
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

	select @SerieN = FolS.Serie, @FolioN = isnull((FolS.Usados) + 1,1) 
	from Route.dbo.SubEmpresa SubE 
	inner join Route.dbo.Folio Folio on SubE.SubEmpresaId = Folio.SubEmpresaId 
	inner join Route.dbo.FolioSolicitado FolS on Folio.FolioID = FolS.FolioID 
	inner join Route.dbo.FOSHist FosH on FosH.FolioID = FolS.FolioID and FosH.FOSId = FolS.FOSId 
	where SubE.TipoEstado = 1 and FosH.VendedorID = 'CFDCed' + CAST(@IdCedis as varchar(10))

	update Route.dbo.FolioSolicitado set Usados = @FolioN 
	from Route.dbo.SubEmpresa SubE 
	inner join Route.dbo.Folio Folio on SubE.SubEmpresaId = Folio.SubEmpresaId 
	inner join Route.dbo.FolioSolicitado FolS on Folio.FolioID = FolS.FolioID 
	inner join Route.dbo.FOSHist FosH on FosH.FolioID = FolS.FolioID and FosH.FOSId = FolS.FOSId 
	where SubE.TipoEstado = 1 and FosH.VendedorID = 'CFDCed' + CAST(@IdCedis as varchar(10))

	declare @VendedorId as varchar(20)
	select @VendedorId = 'CFDCed' + CAST(@IdCedis as varchar(10))
	
	if @Actividad = 1 
	begin
		update VentasDetalle set Serie = @SerieN, Folio = @FolioN 
		where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdTipoVenta = @IdTipoVenta and Folio = @Folio and Serie = @Serie

		update Ventas set Serie = @SerieN, Folio = @FolioN 
		where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdTipoVenta = @IdTipoVenta and Folio = @Folio and Serie = @Serie
		
		update VentasImpuestos set Folio = @FolioN 
		where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdTipoVenta = @IdTipoVenta and Folio = @Folio 
		
		update Pedidos set Serie = @SerieN, Folio = @FolioN 
		where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdTipoVenta = @IdTipoVenta and Folio = @Folio 
		
		update VentasAcredita set Serie = @SerieN, Folio = @FolioN 
		where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdTipoVenta = @IdTipoVenta and Folio = @Folio 
		
		update VentasDevolucion set Serie = @SerieN, Folio = @FolioN 
		where IdCedisD = @IdCedis and IdSurtido = @IdSurtido and IdTipoVenta = @IdTipoVenta and Folio = @Folio 

		insert into VentasFacturaCFD 
		values (@IdCedis, @IdSurtido, @IdTipoVenta, @Folio, 0, '19000101', @SerieN, @FolioN, @TransprodId, @TransprodIdFactura, GETDATE())

		exec Route.dbo.sp_importVentasADM @IdCedis, @IdSurtido, @IdTipoVenta, @FolioN, @SerieN, @TransprodId, @TransprodIdFactura, @VendedorId, 0 
	
	end

	if @Actividad = 2
	begin
		update Pedidos set Serie = @SerieN, Folio = @FolioN, IdSurtido = 0 
		where IdCedis = @IdCedis and IdPedido = @IdSurtido 

		insert into VentasFacturaCFD 
		values (@IdCedis, 0, @IdTipoVenta, 0, @IdSurtido, '19000101', @SerieN, @FolioN, @TransprodId, @TransprodIdFactura, GETDATE())

		exec Route.dbo.sp_importPedidosADM @IdCedis, @IdSurtido, @IdTipoVenta, @FolioN, @SerieN, @TransprodId, @TransprodIdFactura, @VendedorId, 0 
	
	end

commit tran
end

GO


