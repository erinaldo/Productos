USE [RouteCPC]
GO

/****** Object:  StoredProcedure [dbo].[sel_Ventas2]    Script Date: 04/01/2011 09:10:37 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sel_Ventas2]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sel_Ventas2]
GO

USE [RouteCPC]
GO

/****** Object:  StoredProcedure [dbo].[sel_Ventas2]    Script Date: 04/01/2011 09:10:37 ******/
SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER OFF
GO


CREATE PROCEDURE [dbo].[sel_Ventas2] 
@IdCedis as bigint,
@FechaInicial as datetime,
@FechaFinal as datetime,
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
	isnull(FacturasOxxo.SerieOX,'') as SerieOX, isnull(FacturasOxxo.FolioOX,0) as FolioOX, Ventas.Status, Ventas.Login
	from Ventas 	
	left outer join Cedis on Cedis.IdCedis = Ventas.IdCedis 
	left outer join VentasAcredita on VentasAcredita.IdCedis = Ventas.IdCedis and VentasAcredita.IdTipoVenta = Ventas.IdTipoVenta
		and VentasAcredita.Serie = Ventas.Serie collate SQL_Latin1_General_CP1_CI_AS and VentasAcredita.Folio = Ventas.Folio 
	left outer join FacturasOxxo on FacturasOxxo.IdCedis = Ventas.IdCedis and FacturasOxxo.IdTipoVenta = Ventas.IdTipoVenta
		and FacturasOxxo.Serie = Ventas.Serie collate SQL_Latin1_General_CP1_CI_AS and FacturasOxxo.Folio = Ventas.Folio 
	left outer join Clientes on Clientes.IdCedis = Ventas.IdCedis and Clientes.IDCliente = Ventas.IdCliente 	
	left outer join ClienteSucursal on Ventas.IdCedis = ClienteSucursal.IdCedis and Ventas.IdSucursal = ClienteSucursal.IdSucursal	
	where Ventas.IdCedis = @IdCedis and Ventas.Serie like '%' + @Serie + '%' and Ventas.Folio like '%' + @Folio + '%' and Ventas.IdCedis in (select IdCedis from UsuariosCedis where Login = @Login) 
		and Ventas.Fecha between @FechaInicial and @FechaFinal -- and Ventas.Status <> ''
	order by Ventas.Fecha desc, Ventas.IdCedis, Ventas.Serie, Ventas.Folio 
end


if @Opc = 4
begin
	exec ( 'select Ventas.IdCedis, isnull(Cedis,''-Cedis No Encontrado-'') as Cedis, Ventas.IdTipoVenta, Ventas.Fecha, Ventas.Serie, Ventas.Folio, 
	VentasAcredita.FolioEntrega, VentasAcredita.FolioCliente, VentasAcredita.Factura, VentasAcredita.Remision, 	
	Ventas.Total, Ventas.Cargos, Ventas.Abonos, Ventas.Saldo, Ventas.IdCliente, isnull(Clientes.RazonSocial,''-Cliente No Econtrado-'') as RazonSocial,
	Ventas.IdSucursal, isnull(ClienteSucursal.NombreSucursal,''-Sucursal No Econtrada-'') as NombreSucursal, 
	isnull(FacturasOxxo.SerieOX,'''') as SerieOX, isnull(FacturasOxxo.FolioOX,0) as FolioOX, Ventas.Status, Ventas.Login
	from Ventas 	
	left outer join Cedis on Cedis.IdCedis = Ventas.IdCedis 
	left outer join VentasAcredita on VentasAcredita.IdCedis = Ventas.IdCedis and VentasAcredita.IdTipoVenta = Ventas.IdTipoVenta
		and VentasAcredita.Serie = Ventas.Serie collate SQL_Latin1_General_CP1_CI_AS and VentasAcredita.Folio = Ventas.Folio 
	left outer join FacturasOxxo on FacturasOxxo.IdCedis = Ventas.IdCedis and FacturasOxxo.IdTipoVenta = Ventas.IdTipoVenta
		and FacturasOxxo.Serie = Ventas.Serie collate SQL_Latin1_General_CP1_CI_AS and FacturasOxxo.Folio = Ventas.Folio 
	left outer join Clientes on Clientes.IdCedis = Ventas.IdCedis and Clientes.IDCliente = Ventas.IdCliente 	
	left outer join ClienteSucursal on Ventas.IdCedis = ClienteSucursal.IdCedis and Ventas.IdSucursal = ClienteSucursal.IdSucursal	
	where Ventas.IdCedis in (select IdCedis from UsuariosCedis where Login = ''' + @Login + ''') ' + @Serie + '  
	order by Ventas.Fecha desc, Ventas.IdCedis, Ventas.Serie, Ventas.Folio ')
end

GO


