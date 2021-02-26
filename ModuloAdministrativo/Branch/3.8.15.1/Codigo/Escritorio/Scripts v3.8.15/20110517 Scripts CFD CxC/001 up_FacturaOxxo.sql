USE [RouteCPC]
GO

/****** Object:  StoredProcedure [dbo].[up_FacturaOxxo]    Script Date: 05/18/2011 01:05:17 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[up_FacturaOxxo]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[up_FacturaOxxo]
GO

USE [RouteCPC]
GO

/****** Object:  StoredProcedure [dbo].[up_FacturaOxxo]    Script Date: 05/18/2011 01:05:17 ******/
SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER OFF
GO



CREATE PROCEDURE [dbo].[up_FacturaOxxo] 
@IdCedis as bigint,
@IdTipoVenta as int,
@Serie as varchar(5),
@Folio as bigint,
@Fecha as datetime,
@IdCliente as bigint,
@DiasCredito as int,
@Login as varchar(20),
@Opc as int
AS

declare @IdSucursal as varchar(20)

if @Opc = 1 --  inserta factura
begin		
	--set @Folio = ( select  isnull ( max ( Folio )+1, 1)  from Ventas where IdCedis = @IdCedis and IdTipoVenta = 2 and Serie = @Serie )
	select top 1 @IdSucursal = IdSucursal from ClienteSucursal where IdCedis = @IdCedis and IdCliente = @IdCliente 

	insert into Ventas values (@IdCedis, @IdTipoVenta, @Folio, @Serie, @Fecha, @IdCliente, 0, 0, 0, 0, @DiasCredito, @IdSucursal, 1, '', 0, 'P', @Login, getdate())
end

if @Opc = 2
begin
begin tran 

	update Route.dbo.FolioSolicitado set MUsuarioID = 'CFDCed' + CAST(@IdCedis as varchar(10)), MFechaHora = GETDATE()
	from Route.dbo.SubEmpresa SubE 
	inner join Route.dbo.Folio Folio on SubE.SubEmpresaId = Folio.SubEmpresaId 
	inner join Route.dbo.FolioSolicitado FolS on Folio.FolioID = FolS.FolioID 
	inner join Route.dbo.FOSHist FosH on FosH.FolioID = FolS.FolioID and FosH.FOSId = FolS.FOSId 
	where SubE.TipoEstado = 1 and FosH.VendedorID = 'CFDCed' + CAST(@IdCedis as varchar(10))

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

	select top 1 @IdSucursal = IdSucursal from ClienteSucursal where IdCedis = @IdCedis and IdCliente = @IdCliente 
	insert into Ventas values (@IdCedis, @IdTipoVenta, @Folio, @Serie, @Fecha, @IdCliente, 0, 0, 0, 0, @DiasCredito, @IdSucursal, 1, '', 0, 'P', @Login, getdate())

commit tran	
end

if @Opc = 3 --elimina factutras
begin
	-- update MovimientosFacturas set Status = 'B', FechaEdicion = getdate(), Login = @Login where Folio in ( select Folio from FacturasOxxo where IdCedisOX = @IdCedis and IdTipoVentaOX = @IdTipoVenta and FolioOX  = @Folio and SerieOX = @Serie )	
	delete from FacturasOxxo where IdCedisOX = @IdCedis and IdTipoVentaOX = @IdTipoVenta and FolioOX  = @Folio and SerieOX = @Serie
	delete from Ventas where IdCedis = @IdCedis and IdTipoVenta = @IdTipoVenta and Folio  = @Folio and Serie = @Serie
	delete from VentasDetalle where IdCedis = @IdCedis and IdTipoVenta = @IdTipoVenta and Folio  = @Folio and Serie = @Serie
	delete from VentasImpuestos where IdCedis = @IdCedis and IdTipoVenta = @IdTipoVenta and Folio  = @Folio and Serie = @Serie
end

if @Opc = 4 -- marca con Status G
begin	
	delete from VentasDetalle where IdCedis = @IdCedis and IdTipoVenta = @IdTipoVenta and Folio  = @Folio and Serie = @Serie
	delete from VentasImpuestos where IdCedis = @IdCedis and IdTipoVenta = @IdTipoVenta and Folio  = @Folio and Serie = @Serie
	
	insert into VentasDetalle
	select * from FN_VentasOxxo (@IdCedis, @IdTipoVenta, @Serie, @Folio)

	insert into VentasImpuestos
	select * from FN_VentasOxxoImp (@IdCedis, @IdTipoVenta, @Serie, @Folio)
	
	update Ventas set Status = 'G', Login = @Login, FechaEdicion = getdate() where IdCedis = @IdCedis and IdTipoVenta = @IdTipoVenta and Folio  = @Folio and Serie = @Serie

	update Ventas set 
	Cargos =  ( select isnull( sum(Total), 0)   from MovimientosFacturas
			where MovimientosFacturas.IdCedis = Ventas.IdCedis and MovimientosFacturas.IdTipoVenta = Ventas.IdTipoVenta
			and MovimientosFacturas.Serie = Ventas.Serie and MovimientosFacturas.Folio = Ventas.Folio and Status <> 'B' and CargoAbono = 'C') , 
	Abonos =  ( select isnull( sum(Total), 0)   from MovimientosFacturas
			where MovimientosFacturas.IdCedis = Ventas.IdCedis and MovimientosFacturas.IdTipoVenta = Ventas.IdTipoVenta
			and MovimientosFacturas.Serie = Ventas.Serie and MovimientosFacturas.Folio = Ventas.Folio and Status <> 'B' and CargoAbono = 'A') 
	where Ventas.Folio in ( select Folio from FacturasOxxo
			where FacturasOxxo.IdCedis = Ventas.IDCedis and FacturasOxxo.IdTipoVenta = Ventas.IdTipoVenta
			and FacturasOxxo.Serie = Ventas.Serie and FacturasOxxo.Folio = Ventas.Folio
			and FacturasOxxo.IdCedisOX = @IdCedis and FacturasOxxo.IdTipoVentaOX = @IdTipoVenta
			and FacturasOxxo.SerieOX = @Serie and FacturasOxxo.FolioOX = @Folio)

	exec up_actualizasaldo @IdCedis, 2
	
end

if @Opc = 5 -- actualiza detalle de Factura Oxxo
begin	
	delete from VentasDetalle where IdCedis = @IdCedis and IdTipoVenta = @IdTipoVenta and Folio  = @Folio and Serie = @Serie
	delete from VentasImpuestos where IdCedis = @IdCedis and IdTipoVenta = @IdTipoVenta and Folio  = @Folio and Serie = @Serie
	
	insert into VentasDetalle
	select * from FN_VentasOxxo (@IdCedis, @IdTipoVenta, @Serie, @Folio) 	

	insert into VentasImpuestos
	select * from FN_VentasOxxoImp (@IdCedis, @IdTipoVenta, @Serie, @Folio)
	
	update Ventas set Login = @Login, FechaEdicion = GETDATE() 
	where IdCedis = @IdCedis and IdTipoVenta = @IdTipoVenta and Folio  = @Folio and Serie = @Serie
end

if @Opc = 6
begin

begin tran 

	declare @TransprodId as varchar(20), @TransprodIdFactura as varchar(20)

	delete from VentasDetalle where IdCedis = @IdCedis and IdTipoVenta = @IdTipoVenta and Folio  = @Folio and Serie = @Serie
	delete from VentasImpuestos where IdCedis = @IdCedis and IdTipoVenta = @IdTipoVenta and Folio  = @Folio and Serie = @Serie
	
	insert into VentasDetalle
	select * from FN_VentasOxxo (@IdCedis, @IdTipoVenta, @Serie, @Folio)

	insert into VentasImpuestos
	select * from FN_VentasOxxoImp (@IdCedis, @IdTipoVenta, @Serie, @Folio)

	update Ventas set Status = 'G', Login = @Login, FechaEdicion = getdate() where IdCedis = @IdCedis and IdTipoVenta = @IdTipoVenta and Folio  = @Folio and Serie = @Serie

	update Ventas set 
	Cargos =  ( select isnull( sum(Total), 0)   from MovimientosFacturas
			where MovimientosFacturas.IdCedis = Ventas.IdCedis and MovimientosFacturas.IdTipoVenta = Ventas.IdTipoVenta
			and MovimientosFacturas.Serie = Ventas.Serie and MovimientosFacturas.Folio = Ventas.Folio and Status <> 'B' and CargoAbono = 'C') , 
	Abonos =  ( select isnull( sum(Total), 0)   from MovimientosFacturas
			where MovimientosFacturas.IdCedis = Ventas.IdCedis and MovimientosFacturas.IdTipoVenta = Ventas.IdTipoVenta
			and MovimientosFacturas.Serie = Ventas.Serie and MovimientosFacturas.Folio = Ventas.Folio and Status <> 'B' and CargoAbono = 'A') 
	where Ventas.Folio in ( select Folio from FacturasOxxo
			where FacturasOxxo.IdCedis = Ventas.IDCedis and FacturasOxxo.IdTipoVenta = Ventas.IdTipoVenta
			and FacturasOxxo.Serie = Ventas.Serie and FacturasOxxo.Folio = Ventas.Folio
			and FacturasOxxo.IdCedisOX = @IdCedis and FacturasOxxo.IdTipoVentaOX = @IdTipoVenta
			and FacturasOxxo.SerieOX = @Serie and FacturasOxxo.FolioOX = @Folio)

	exec up_actualizasaldo @IdCedis, 2
	
	declare @VendedorId as varchar(20)
	select @VendedorId = 'CFDCed' + CAST(@IdCedis as varchar(10))
	
	select @TransprodId = RIGHT(REPLACE(CONVERT(VARCHAR(36),NEWID()),'-',''),16)
	select @TransprodIdFactura = RIGHT(REPLACE(CONVERT(VARCHAR(36),NEWID()),'-',''),16)

	insert into VentasFacturaCFD 
	values (@IdCedis, 0, @IdTipoVenta, @Serie, @Folio, @Serie, @Folio, @TransprodId, @TransprodIdFactura, GETDATE())

	exec Route.dbo.sp_importVentasCPC @IdCedis, @IdTipoVenta, @Folio, @Serie, @TransprodId, @TransprodIdFactura, @VendedorId, 0 

commit tran	


end

GO


