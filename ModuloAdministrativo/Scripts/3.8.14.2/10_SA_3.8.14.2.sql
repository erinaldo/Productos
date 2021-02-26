USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[up_VentasFactura]    Script Date: 05/26/2011 13:15:36 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[up_VentasFactura]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[up_VentasFactura]
GO

USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[up_VentasFactura]    Script Date: 05/26/2011 13:15:36 ******/
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
	update VentasDetalle set Serie = @SerieN, Folio = @FolioN 
	where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdTipoVenta = @IdTipoVenta and Folio = @Folio and Serie = @Serie

	update Ventas set Serie = @SerieN, Folio = @FolioN 
	where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdTipoVenta = @IdTipoVenta and Folio = @Folio and Serie = @Serie
	
	update VentasRoute set Serie = @SerieN, Folio = @FolioN 
	where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdTipoVenta = @IdTipoVenta and Folio = @Folio and Serie = @Serie
	
	update Route.dbo.FolioSolicitado set Usados = @FolioN where Serie = @SerieN 
	
	insert into Route.dbo.tmp_Factura
	select RIGHT(newid(),16), 
	replicate('0', 2 - len( DAY(Ventas.Fecha) ) ) + cast( DAY(Ventas.Fecha) as varchar(2)) + '/' + 
		replicate('0', 2 - len( month(Ventas.Fecha) ) ) + cast( month(Ventas.Fecha) as varchar(2)) + '/' + cast( year(Ventas.Fecha) as varchar(4)), 
	IdSucursal, cast( Ventas.IdCedis as varchar(10) ) + replicate('0', 4 - len( IdRuta ) ) + cast( IdRuta as varchar(10)), 
	Serie + REPLICATE('0',7-len(Folio)) + CAST(folio as varchar(10)), 1, Ventas.Fecha, Ventas.Fecha, Ventas.Fecha, Ventas.Fecha, 2,
	Ventas.Subtotal, Iva, Ventas.Total, Ventas.Total, '', GETDATE(), cast( Ventas.IdCedis as varchar(10) ) + replicate('0', 4 - len( IdRuta ) ) + cast( IdRuta as varchar(10)) 
	from RouteADM.dbo.Ventas as Ventas 
	inner join RouteADM.dbo.Surtidos as Surtidos on Surtidos.IdSurtido = Ventas.IdSurtido and Ventas.IdCedis = Surtidos.IdCedis and Surtidos.IdRuta <> 17
	where Ventas.IdCedis = @IdCedis and Ventas.IdSurtido = @IdSurtido and Folio = @FolioN and Serie = @SerieN 
	and Serie + REPLICATE('0',7-len(Folio)) + CAST(folio as varchar(10)) not in (
		select Folio collate SQL_Latin1_General_CP1_CI_AS from Route.dbo.TransProd where Tipo = 8)
	
	update Route.dbo.TransProd set SubEmpresaID = 2 
	where Tipo = 8 and Folio like 'EBQX%' and SubEmpresaID is null and Folio in (
	select Serie + REPLICATE('0',7-len(Folio)) + CAST(folio as varchar(10)) collate SQL_Latin1_General_CP1_CI_AS 
		from RouteADM.dbo.Ventas as Ventas 
		where Ventas.IdCedis = @IdCedis and Ventas.IdSurtido = @IdSurtido and Folio = @FolioN and Serie = @SerieN )

	update Route.dbo.TransProd set SubEmpresaID = 1 
	where Tipo = 8 and Folio like 'EBQ%' and SubEmpresaID is null and Folio in (
	select Serie + REPLICATE('0',7-len(Folio)) + CAST(folio as varchar(10)) collate SQL_Latin1_General_CP1_CI_AS 
		from RouteADM.dbo.Ventas as Ventas 
		where Ventas.IdCedis = @IdCedis and Ventas.IdSurtido = @IdSurtido and Folio = @FolioN and Serie = @SerieN )
end

if @Opc = 2 -- Valida Marca
begin

	select (select FH.CentroExpID  
		from Route.dbo.FolioSolicitado FS
		inner join Route.dbo.FOSHist FH on FH.FolioID = FS.FolioID and FS.FOSId = FH.FOSId 
		where Serie = @SerieN) , 
	(select distinct IdMarca 
		from VentasDetalle 
		inner join Productos on Productos.IdProducto = VentasDetalle.IdProducto 
		where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdTipoVenta = @IdTipoVenta and Folio = @Folio and Serie = @Serie) as Valida

end
GO


