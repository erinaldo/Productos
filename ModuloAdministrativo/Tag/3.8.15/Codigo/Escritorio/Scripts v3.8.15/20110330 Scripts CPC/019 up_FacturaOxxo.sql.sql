USE [RouteCPC]
GO

/****** Object:  StoredProcedure [dbo].[up_FacturaOxxo]    Script Date: 03/31/2011 17:51:21 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[up_FacturaOxxo]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[up_FacturaOxxo]
GO

USE [RouteCPC]
GO

/****** Object:  StoredProcedure [dbo].[up_FacturaOxxo]    Script Date: 03/31/2011 17:51:21 ******/
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

if @Opc = 1 --  inserta factutra
begin		
	--set @Folio = ( select  isnull ( max ( Folio )+1, 1)  from Ventas where IdCedis = @IdCedis and IdTipoVenta = 2 and Serie = @Serie )
	insert into Ventas values (@IdCedis, @IdTipoVenta, @Folio, @Serie, @Fecha, @IdCliente, 0, 0, 0, 0, @DiasCredito, '', 1, '', 0, 'P', @Login, getdate())
end

if @Opc = 3 --elimina factutras
begin
	-- update MovimientosFacturas set Status = 'B', FechaEdicion = getdate(), Login = @Login where Folio in ( select Folio from FacturasOxxo where IdCedisOX = @IdCedis and IdTipoVentaOX = @IdTipoVenta and FolioOX  = @Folio and SerieOX = @Serie )	
	delete from FacturasOxxo where IdCedisOX = @IdCedis and IdTipoVentaOX = @IdTipoVenta and FolioOX  = @Folio and SerieOX = @Serie
	delete from Ventas where IdCedis = @IdCedis and IdTipoVenta = @IdTipoVenta and Folio  = @Folio and Serie = @Serie
end

if @Opc = 4 -- marca con Status G
begin	
	delete from VentasDetalle where IdCedis = @IdCedis and IdTipoVenta = @IdTipoVenta and Folio  = @Folio and Serie = @Serie
	
	insert into VentasDetalle
	select * from FN_VentasOxxo (@IdCedis, @IdTipoVenta, @Serie, @Folio) 	

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
	
	insert into VentasDetalle
	select * from FN_VentasOxxo (@IdCedis, @IdTipoVenta, @Serie, @Folio) 	
	
	update Ventas set Login = @Login, FechaEdicion = GETDATE() 
	where IdCedis = @IdCedis and IdTipoVenta = @IdTipoVenta and Folio  = @Folio and Serie = @Serie
end


GO


