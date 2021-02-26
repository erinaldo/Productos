USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[sel_ValidaUsuarioCedisCFD]    Script Date: 05/04/2011 18:28:16 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sel_ValidaUsuarioCedisCFD]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sel_ValidaUsuarioCedisCFD]
GO

USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[sel_ValidaUsuarioCedisCFD]    Script Date: 05/04/2011 18:28:16 ******/
SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER OFF
GO





CREATE PROCEDURE [dbo].[sel_ValidaUsuarioCedisCFD]
@IdCedis as bigint,
@IdRuta as bigint,
@SubEmpresaId as varchar(20),
@CFDCedis as bit,
@Opc as int
AS

if @Opc = 1
begin

	if @CFDCedis = 1
	begin
	if not exists( select FosH.VendedorID from Route.dbo.FOSHist FosH where FosH.VendedorID = 'CFDCed' + CAST(@IdCedis as varchar(10)) )
	begin
		insert into ROUTE.dbo.Usuario 
		select 'CFDCed' + CAST(@IdCedis as varchar(10)), 'FacElec', 
		'CFDCed' + CAST(@IdCedis as varchar(10)),
		'Usuario Cedis ' + CAST(@IdCedis as varchar(10)) + ' CFD' , 
		Route.dbo.FNCrypt('CFD123'), 0, getdate(), 0, 1, getdate(), 'Interfaz'
		from Configuracion 
		where IdCedis = @IdCedis and 'CFDCed' + CAST(@IdCedis as varchar(10)) not in (select UsuId from ROUTE.dbo.Usuario)

		insert into ROUTE.dbo.Vendedor 
		select 'CFDCed' + CAST(@IdCedis as varchar(10)), null,
			'CFDCed' + CAST(@IdCedis as varchar(10)),'2', null, 
			(select top 1 AlmacenId
				from ROUTE.dbo.Almacen
				where Tipo = 1 and TipoEstado = 1), 			
			1,1,0,1,
			'CFDCed' + CAST(@IdCedis as varchar(10)), '', 
			0,0,0, '', 0,0,0, -- jornada de trabajo
			0,0,0, 0,0,0, getdate(), 'Interfaz'
		from Configuracion  
		where IdCedis = @IdCedis and 'CFDCed' + CAST(@IdCedis as varchar(10)) not in (select VendedorId from ROUTE.dbo.Vendedor)

		insert into ROUTE.dbo.VENCentroDistHist 
		select 'CFDCed' + CAST(@IdCedis as varchar(10)), 
			(select top 1 AlmacenId
				from ROUTE.dbo.Almacen
				where Tipo = 1 and TipoEstado = 1), 
			'20000101', '20991231', getdate(), 'Interfaz'

		insert into ROUTE.dbo.VendedorEsquema 
		select 'CFDCed' + CAST(@IdCedis as varchar(10)), 'CLI', 1, getdate(), 'Interfaz'
	end
	end
	
end

GO


