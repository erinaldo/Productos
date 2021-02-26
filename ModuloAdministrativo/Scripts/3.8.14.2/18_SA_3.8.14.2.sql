USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[sel_ClientesFacturas]    Script Date: 06/03/2011 13:08:53 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sel_ClientesFacturas]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sel_ClientesFacturas]
GO

USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[sel_ClientesFacturas]    Script Date: 06/03/2011 13:08:53 ******/
SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER OFF
GO




CREATE PROCEDURE [dbo].[sel_ClientesFacturas] 
@IdCedis as bigint,
@IdCliente as bigint,
@RFC as varchar(100),
@RazonSocial as varchar(100),
@FormaVenta as char(1),
@Opc as int
AS

if @Opc = 1
begin
	if @IdCliente = 0
		select Clientes.IdCedis, Clientes.IdCliente, Clientes.RazonSocial, 
		isnull( CodigoBarras, '-') as 'Código de Barras', NombreSucursal, ClienteSucursal.Calle + ' ' + ClienteSucursal.NumExterior + ' ' + ClienteSucursal.NumInterior as Calle, ClienteSucursal.Colonia, ClienteSucursal.Entidad, 
		isnull(PreciosLista.IdLista,0), isnull(PreciosLista.Descripcion, 'El Cliente no tiene Lista de Precios asignada'), IdSucursal, isnull(ClienteSucursal.RFC, '-') as 'RFC'
		from Clientes
		left outer join ClienteSucursal on Clientes.IdCedis = ClienteSucursal.IdCedis and Clientes.IdCliente = ClienteSucursal.IdCliente and ClienteSucursal.NombreSucursal like '%' + @RFC + '%' 
		left outer join PreciosListaCliente on PreciosListaCliente.IdCliente = Clientes.IdCliente and Clientes.IdCedis = PreciosListaCliente.IdCedis
		left outer join PreciosLista on PreciosLista.IdLista = PreciosListaCliente.IdLista
		where Clientes.IdCedis = @IdCedis and Clientes.RazonSocial like '%' + @RazonSocial + '%' and Clientes.Status = 'A'
		and (ClienteSucursal.FormaVenta = @FormaVenta or @FormaVenta = 0)

	else
		select Clientes.IdCedis, Clientes.IdCliente, Clientes.RazonSocial, 
		isnull( CodigoBarras, '-') as 'Código de Barras', NombreSucursal, ClienteSucursal.Calle + ' ' + ClienteSucursal.NumExterior + ' ' + ClienteSucursal.NumInterior as Calle, ClienteSucursal.Colonia, ClienteSucursal.Entidad, 
		isnull(PreciosLista.IdLista,0), isnull(PreciosLista.Descripcion, 'El Cliente no tiene Lista de Precios asignada'), IdSucursal, isnull(ClienteSucursal.RFC, '-') as 'RFC'
		from Clientes
		left outer join ClienteSucursal on Clientes.IdCedis = ClienteSucursal.IdCedis and Clientes.IdCliente = ClienteSucursal.IdCliente and ClienteSucursal.NombreSucursal like '%' + @RFC + '%' 
		left outer join PreciosListaCliente on PreciosListaCliente.IdCliente = Clientes.IdCliente and Clientes.IdCedis = PreciosListaCliente.IdCedis
		left outer join PreciosLista on PreciosLista.IdLista = PreciosListaCliente.IdLista
		where Clientes.IdCedis = @IdCedis and Clientes.IdCliente = @IdCliente and Clientes.Status = 'A'
		and (ClienteSucursal.FormaVenta = @FormaVenta or @FormaVenta = 0)
end

if @Opc = 2
begin

	select IdClienteContado, isnull(Clientes.IdCliente, -1)
	from Configuracion
	inner join Clientes on Clientes.IdCliente = IdClienteContado and Clientes.IdCedis = Configuracion.IdCedis 
	inner join ClienteSucursal on Clientes.IdCliente = ClienteSucursal.IdCliente and ClienteSucursal.FormaVenta = 1
	where Configuracion.IdCedis = @IdCedis 

end

if @Opc = 3
begin
		select Clientes.IdCedis, Clientes.IdCliente, Clientes.RazonSocial, 
		isnull( CodigoBarras, '-') as 'Código de Barras', NombreSucursal, ClienteSucursal.Calle + ' ' + ClienteSucursal.NumExterior + ' ' + ClienteSucursal.NumInterior as Calle, ClienteSucursal.Colonia, ClienteSucursal.Entidad, 
		isnull(PreciosLista.IdLista,0), isnull(PreciosLista.Descripcion, 'El Cliente no tiene Lista de Precios asignada'), IdSucursal, isnull(ClienteSucursal.RFC, '-') as 'RFC'
		from Clientes
		left outer join ClienteSucursal on Clientes.IdCedis = ClienteSucursal.IdCedis and Clientes.IdCliente = ClienteSucursal.IdCliente and ClienteSucursal.IdSucursal = @RazonSocial  
		left outer join PreciosListaCliente on PreciosListaCliente.IdCliente = Clientes.IdCliente and Clientes.IdCedis = PreciosListaCliente.IdCedis
		left outer join PreciosLista on PreciosLista.IdLista = PreciosListaCliente.IdLista
		where Clientes.IdCedis = @IdCedis and Clientes.IdCliente = @IdCliente and Clientes.Status = 'A'
		and (ClienteSucursal.FormaVenta = @FormaVenta or @FormaVenta = 0) 
end

GO


