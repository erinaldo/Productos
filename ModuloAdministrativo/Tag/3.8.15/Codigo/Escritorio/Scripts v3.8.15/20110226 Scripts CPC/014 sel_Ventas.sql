USE [RouteCPC]
GO

/****** Object:  StoredProcedure [dbo].[sel_Ventas]    Script Date: 03/02/2011 11:02:01 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sel_Ventas]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sel_Ventas]
GO

USE [RouteCPC]
GO

/****** Object:  StoredProcedure [dbo].[sel_Ventas]    Script Date: 03/02/2011 11:02:01 ******/
SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER OFF
GO

CREATE PROCEDURE [dbo].[sel_Ventas] 
@IdCedis as bigint,
@IdTipoVenta as bigint,
@Serie as varchar(5),
@Folio as varchar(15),
@Login as varchar(20),
@Opc as int
AS

if @Opc = 1
begin
	select Ventas.IdCedis, isnull(Cedis,'-Cedis No Encontrado-') as Cedis, Ventas.IdTipoVenta, Ventas.Fecha, Ventas.Serie, Ventas.Folio, 
	VentasAcredita.FolioEntrega, VentasAcredita.FolioCliente, VentasAcredita.Factura, VentasAcredita.Remision, 	
	Ventas.Total, Ventas.Cargos, Ventas.Abonos, Ventas.Saldo, Ventas.IdCliente, isnull(Clientes.RazonSocial,'-Cliente No Econtrado-') as RazonSocial,
	Ventas.IdSucursal, isnull(ClienteSucursal.NombreSucursal,'-Sucursal No Econtrada-') as NombreSucursal, 
	isnull(FacturasOxxo.SerieOX,'') as SerieOX, isnull(FacturasOxxo.FolioOX,0) as FolioOX, Ventas.Status
	from Ventas 	
	left outer join Cedis on Cedis.IdCedis = Ventas.IdCedis 
	left outer join VentasAcredita on VentasAcredita.IdCedis = Ventas.IdCedis and VentasAcredita.IdTipoVenta = Ventas.IdTipoVenta
		and VentasAcredita.Serie = Ventas.Serie collate SQL_Latin1_General_CP1_CI_AS and VentasAcredita.Folio = Ventas.Folio 
	left outer join FacturasOxxo on FacturasOxxo.IdCedis = Ventas.IdCedis and FacturasOxxo.IdTipoVenta = Ventas.IdTipoVenta
		and FacturasOxxo.Serie = Ventas.Serie collate SQL_Latin1_General_CP1_CI_AS and FacturasOxxo.Folio = Ventas.Folio 
	left outer join Clientes on Clientes.IdCedis = Ventas.IdCedis and Clientes.IDCliente = Ventas.IdCliente 	
	left outer join ClienteSucursal on Ventas.IdCedis = ClienteSucursal.IdCedis and Ventas.IdSucursal = ClienteSucursal.IdSucursal	
	where (Ventas.Serie like '%' + @Serie + '%' and Ventas.Folio like '%' + @Folio + '%') or 
		(VentasAcredita.FolioEntrega like '%' + @Folio + '%' or VentasAcredita.FolioCliente like '%' + @Folio + '%' or VentasAcredita.Remision like '%' + @Folio + '%' or VentasAcredita.Factura like '%' + @Folio + '%' )
		and Ventas.IdCedis in (select IdCedis from UsuariosCedis where Login = @Login) 
	order by Ventas.Fecha desc, Ventas.IdCedis, Ventas.Serie, Ventas.Folio 
end

if @Opc = 2
begin
	select FacturasOxxo.IdCedis, FacturasOxxo.Serie, FacturasOxxo.IdTipoVenta, FacturasOxxo.Folio
	from FacturasOxxo 
	inner join Ventas on Ventas.IdCedis = FacturasOxxo.IdCedisOX and Ventas.IdTipoVenta = FacturasOxxo.IdTipoVentaOX 
		and Ventas.Serie = FacturasOxxo.SerieOX and Ventas.Folio = FacturasOxxo.FolioOX and Status <> 'A'
	where FacturasOxxo.IdCedis = @IdCedis and FacturasOxxo.IdTipoVenta = @IdTipoVenta and FacturasOxxo.Serie = @Serie and FacturasOxxo.Folio = @Folio
end

if @Opc = 3
begin
	select Ventas.IdCedis, Ventas.IdTipoVenta, Ventas.Fecha, Ventas.Serie, Ventas.Folio, 	
	Ventas.Total, Ventas.Cargos, Ventas.Abonos, Ventas.Saldo, Ventas.IdCliente, isnull(Clientes.RazonSocial,'-Cliente No Econtrado-') as RazonSocial,
	Ventas.IdSucursal, isnull(ClienteSucursal.NombreSucursal,'-Sucursal No Econtrada-') as NombreSucursal
	from Ventas 	
	left outer join Clientes on Clientes.IdCedis = Ventas.IdCedis and Clientes.IDCliente = Ventas.IdCliente 	
	left outer join ClienteSucursal on Ventas.IdCedis = ClienteSucursal.IdCedis and Ventas.IdSucursal = ClienteSucursal.IdSucursal	
	where Ventas.IdTipoVenta = @IdTipoVenta and Ventas.IdCedis = @IdCedis and Ventas.Serie = @Serie and Ventas.Folio = @Folio 
end

GO


