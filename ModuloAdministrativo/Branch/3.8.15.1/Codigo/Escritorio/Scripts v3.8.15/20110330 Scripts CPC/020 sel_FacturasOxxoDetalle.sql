USE [RouteCPC]
GO

/****** Object:  StoredProcedure [dbo].[sel_FacturasOxxoDetalle]    Script Date: 03/31/2011 18:07:17 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sel_FacturasOxxoDetalle]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sel_FacturasOxxoDetalle]
GO

USE [RouteCPC]
GO

/****** Object:  StoredProcedure [dbo].[sel_FacturasOxxoDetalle]    Script Date: 03/31/2011 18:07:17 ******/
SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER OFF
GO

CREATE PROCEDURE [dbo].[sel_FacturasOxxoDetalle]
@IdCedis as bigint,
@FechaInicial as datetime,
@FechaFinal as datetime,
@IdCedisOX as bigint,
@IdTipoVentaOX as bigint,
@SerieOX as varchar(5),
@FolioOX as bigint,
@IdCadenaOxxo as bigint,
@SerieOxxo as varchar(5),
@Opc as int
AS

declare @CedisOx as varchar(5)
if @Opc = 1
begin
--	set @CedisOx = substring( @SerieOxxo,3,len(@SerieOxxo))
--	if @CedisOx <> cast(@IdCedis as varchar(5)) set @SerieOxxo = 'OX' + ltrim(rtrim( cast(@IdCedis as varchar(5)) ))

	select Ventas.IdCedis, Ventas.Serie, Ventas.Folio, VentasAcredita.FolioEntrega, VentasAcredita.FolioCliente, VentasAcredita.Remision, VentasAcredita.Factura,
		Ventas.Fecha, SubTotal, Iva, Total, Cargos, Abonos, Saldo, Ventas.IdCliente, RazonSocial, Ventas.IdTipoVenta 
	from Ventas 
	inner join Clientes on Ventas.IdCedis = Clientes.IdCedis and Ventas.IdCliente = Clientes.IdCliente and IdCadena = @IdCadenaOxxo
	left outer join VentasAcredita on Ventas.IdCedis = VentasAcredita.IdCedis and Ventas.IdTipoVenta = VentasAcredita.IdTipoVenta 
		and Ventas.Serie = VentasAcredita.Serie and Ventas.Folio = VentasAcredita.Folio
	where ( Ventas.Fecha between @FechaInicial and @FechaFinal and Ventas.Serie <> @SerieOxxo -- and Total = Saldo 
	and Ventas.Folio not in ( select Folio from FacturasOxxo
		where FacturasOxxo.IdCedis = Ventas.IDCedis and FacturasOxxo.IdTipoVenta = Ventas.IdTipoVenta 
		and FacturasOxxo.Serie = Ventas.Serie and FacturasOxxo.Folio = Ventas.Folio 
		and FacturasOxxo.IdCedisOX = @IdCedisOX and FacturasOxxo.IdTipoVentaOX = @IdTipoVentaOX
		and FacturasOxxo.SerieOX = @SerieOX and FacturasOxxo.FolioOX <> @FolioOX)
and Ventas.Serie <> @SerieOxxo ) -- or ( Ventas.IDCedis = @IdCedis and Folio in ( select Folio from FacturasOxxo
--		where FacturasOxxo.IdCedisOX = @IdCedisOX and FacturasOxxo.IdTipoVentaOX = @IdTipoVentaOX
--		and FacturasOxxo.SerieOX = @SerieOX and FacturasOxxo.FolioOX = @FolioOX) )  

	order by Ventas.Fecha, Ventas.Folio
end

if @Opc = 2 
	select Ventas.IdCedis, Ventas.Serie, Ventas.Folio, VentasAcredita.FolioEntrega, VentasAcredita.FolioCliente, VentasAcredita.Remision, VentasAcredita.Factura,
	Ventas.Fecha, SubTotal, Iva, Total, Cargos, Abonos, Saldo, Ventas.IdCliente, RazonSocial, Ventas.IdTipoVenta 
	from FacturasOxxo 
	inner join Ventas on FacturasOxxo.IdCedis = Ventas.IDCedis and FacturasOxxo.IdTipoVenta = Ventas.IdTipoVenta
		and FacturasOxxo.Serie = Ventas.Serie and FacturasOxxo.Folio = Ventas.Folio
	left outer join VentasAcredita on Ventas.IdCedis = VentasAcredita.IdCedis and Ventas.IdTipoVenta = VentasAcredita.IdTipoVenta 
		and Ventas.Serie = VentasAcredita.Serie and Ventas.Folio = VentasAcredita.Folio
	inner join Clientes on Ventas.IdCedis = Clientes.IdCedis and Ventas.IdCliente = Clientes.IdCliente
	where FacturasOxxo.IdCedisOX = @IdCedisOX and FacturasOxxo.IdTipoVentaOX = @IdTipoVentaOX
		and FacturasOxxo.SerieOX = @SerieOX and FacturasOxxo.FolioOX = @FolioOX
	order by Ventas.Fecha, Ventas.Folio

GO


