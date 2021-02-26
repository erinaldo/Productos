USE [RouteADM]
GO
/****** Object:  StoredProcedure [dbo].[sel_SurtidosNotInVendedores]    Script Date: 06/18/2010 12:51:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




ALTER PROCEDURE [dbo].[sel_SurtidosNotInVendedores] 
@IdCedis as bigint,
@Fecha as datetime,
@IdVendedor as varchar(20),
@Nombre as varchar(20),
@Nomina as varchar(20),
@Opc as int 

AS

if @Opc = 1
	Select Vendedores.IdVendedor as 'Id Vend.', 
	Vendedores.ApPaterno + ' ' + Vendedores.ApMaterno + ' ' + Vendedores.Nombre as 'Nombre del Vendedor',
	Vendedores.Nomina as 'Nómina'
	from Vendedores 
	where Vendedores.IdCedis = @IdCedis and cast(Vendedores.IdVendedor as varchar(20)) like '%' + @IdVendedor  + '%' and ( 
	Vendedores.ApPaterno like '%' + @Nombre + '%' or 
	Vendedores.ApMaterno like '%' + @Nombre + '%' or 
	Vendedores.Nombre like '%' + @Nombre + '%' ) and
	Vendedores.Nomina like '%' + @Nomina + '%' 
	and Vendedores.IdVendedor not in (
		select SurtidosVendedor.IdVendedor 
		from  Surtidos
		inner join SurtidosVendedor on SurtidosVendedor.IdSurtido = Surtidos.IdSurtido
		where Surtidos.IdCedis = @IdCedis and Surtidos.Fecha = @Fecha and Surtidos.Status = 'P'
	) and Vendedores.Status = 'A'
	order by Vendedores.ApPaterno, Vendedores.ApMaterno, Vendedores.Nombre

if @Opc = 2
	Select Vendedores.IdVendedor as 'Id Vend.', 
	Vendedores.ApPaterno + ' ' + Vendedores.ApMaterno + ' ' + Vendedores.Nombre as 'Nombre del Vendedor',
	Vendedores.Nomina as 'Nómina'
	from Vendedores 
	where Vendedores.IdCedis = @IdCedis and cast(Vendedores.IdVendedor as varchar(20)) like '%' + @IdVendedor  + '%' and ( 
	Vendedores.ApPaterno like '%' + @Nombre + '%' or 
	Vendedores.ApMaterno like '%' + @Nombre + '%' or 
	Vendedores.Nombre like '%' + @Nombre + '%' ) and
	Vendedores.Nomina like '%' + @Nomina + '%' and Vendedores.Status = 'A'
	order by Vendedores.ApPaterno, Vendedores.ApMaterno, Vendedores.Nombre
