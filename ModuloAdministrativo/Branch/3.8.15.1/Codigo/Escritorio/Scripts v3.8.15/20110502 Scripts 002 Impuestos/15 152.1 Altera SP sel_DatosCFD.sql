USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[sel_DatosCFD]    Script Date: 05/03/2011 16:33:58 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sel_DatosCFD]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sel_DatosCFD]
GO

USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[sel_DatosCFD]    Script Date: 05/03/2011 16:33:58 ******/
SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER OFF
GO





CREATE PROCEDURE [dbo].[sel_DatosCFD]
@IdCedis as bigint,
@IdSurtido as bigint,
@IdTipoVenta as int,
@Folio as bigint,
@Opc as int

AS

declare 
@IdRuta as bigint,
@IdSucursal as varchar(20)

if @Opc = 1
begin
	select top 1 Ventas.IdCedis, Ventas.IdSucursal, RFC, RazonSocial, CalleF, NumExteriorF, NumInteriorF, ColoniaF,
		LocalidadF, PoblacionF, EntidadF, PaisF, CPF 
	from Ventas
	inner join ClienteSucursal on Ventas.IdCedis = ClienteSucursal.IdCedis and Ventas.IdSucursal = ClienteSucursal.IdSucursal 
	where Ventas.IdCedis = @IdCedis and Ventas.IdSurtido = @IdSurtido and Ventas.IdTipoVenta = @IdTipoVenta and Ventas.Folio = @Folio 
end

if @Opc = 2
begin

	select @IdRuta = isnull(Surtidos.IdRuta,0) 
	from Surtidos 
	inner join Rutas on Rutas.IdCedis = Surtidos.IdCedis and Rutas.IdRuta = Surtidos.IdRuta and CFD = 1
	where Surtidos.IdCedis = @IdCedis and Surtidos.IdSurtido = @IdSurtido 

	select DirRepMensual, DirDocXML, DirArchivosFacElec, ContrasenaClave, FolS.Aprobacion, FolS.AnioAprobacion--, FolS.TipoComprobante  
	from Route.dbo.SEMHist SemHist
	inner join Route.dbo.SubEmpresa SubE on SubE.SubEmpresaId = SemHist.SubEmpresaId 
	inner join Route.dbo.Folio Folio on SubE.SubEmpresaId = Folio.SubEmpresaId
	inner join Route.dbo.FolioSolicitado FolS on Folio.FolioID = FolS.FolioID 
	inner join Route.dbo.FOSHist FosH on FosH.FolioID = FolS.FolioID and FosH.FOSId = FosH.FOSId 
	where SubE.TipoEstado = 1 and FosH.VendedorID = CAST(@IdCedis as varchar(10)) + REPLICATE('0', 4-len(@IdRuta)) + CAST(@IdRuta as varchar(4))
		and SemHist.DirArchivosFacElec <> ''
end

if @Opc = 3
begin
	select Matriz.NumCertificado, Matriz.RFC, Matriz.Calle, Matriz.NumExt, Matriz.NumInt, Matriz.Colonia, Matriz.CodigoPostal,
	Matriz.ReferenciaDom, Matriz.Localidad, Matriz.Municipio, Matriz.Entidad, Matriz.Pais,
	Sucursal.NumCertificado, Sucursal.RFC, Sucursal.Calle, Sucursal.NumExt, Sucursal.NumInt, Sucursal.Colonia, Sucursal.CodigoPostal,
	Sucursal.ReferenciaDom, Sucursal.Localidad, Sucursal.Municipio, Sucursal.Entidad, Sucursal.Pais, SubE.NombreEmpresa 
	from Route.dbo.CentroExpedicion as Matriz 
	inner join Route.dbo.SubEmpresa SubE on SubE.SubEmpresaId = Matriz.SubEmpresaId 
	inner join Route.dbo.CentroExpedicion as Sucursal on Sucursal.CentroExpPadreID = Matriz.CentroExpID and Sucursal.TipoEstado = 1
		and Sucursal.Tipo = 1 and Matriz.SubEmpresaId = Sucursal.SubEmpresaId 
	where Matriz.CentroExpPadreID is null and Matriz.TipoEstado = 1 and Matriz.Tipo = 0
end

if @Opc = 4
begin
	select
	VentasDetalle.IdProducto as 'Cve. Prod.', Productos.Producto as 'Producto', 
	VentasDetalle.Cantidad as 'Cantidad', VentasDetalle.Entregado as 'Entregado', VentasDetalle.Precio as 'Precio', 
	VentasDetalle.DctoPorc as 'Dcto.', VentasDetalle.DctoImp as 'Dcto. Imp.', VentasDetalle.Subtotal as 'Subtotal', 
	((VentasDetalle.Cantidad * VentasDetalle.Precio ) - VentasDetalle.DctoImp )* VentasDetalle.Iva as 'Impuestos', VentasDetalle.Total as 'Total', 
	VentasDetalle.DctoImp, VentasDetalle.Iva  
	from Ventas
	inner join VentasDetalle on Ventas.IdCedis = VentasDetalle.IdCedis and Ventas.IdTipoVenta = VentasDetalle.IdTipoVenta 
		and Ventas.IdSurtido = VentasDetalle.IdSurtido and Ventas.Folio = VentasDetalle.Folio 
	inner join Productos on VentasDetalle.IdProducto = Productos.IdProducto
	where Ventas.IdCedis = @IdCedis and Ventas.IdSurtido = @IdSurtido and Ventas.IdTipoVenta = @IdTipoVenta and Ventas.Folio = @Folio 
	order by VentasDetalle.IdProducto
end


GO


