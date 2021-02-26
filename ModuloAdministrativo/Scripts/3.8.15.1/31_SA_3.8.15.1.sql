USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[sel_Sucursales]    Script Date: 07/09/2011 14:47:08 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sel_Sucursales]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sel_Sucursales]
GO

USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[sel_Sucursales]    Script Date: 07/09/2011 14:47:09 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[sel_Sucursales]

@IdCedis as bigint,
@IdCliente as bigint,
@IdSucursal as varchar(16),
@IdRuta as bigint,
@RFC as varchar(20),
@NombreSucursal as varchar(75),
@Calle as varchar(250),
@Opc as int

AS

if @Opc = 1 		-- sucursales para un solo cliente
Begin
	SELECT     SUC.IdCedis, CTE.RazonSocial AS cliente, SUC.IdCliente, SUC.IdSucursal, isnull(SUC.TDA_GLN,'') AS [TDA/GLN], 
		isnull(SUC.NombreSucursal,'') AS Sucursal, isnull(SUC.Status,'B') as Status,
--		case SUC.Status
--			when 'A' then 'Activo'
--			when 'B' then 'Baja'
--			when 'S' then 'Suspendido'
--			when null then 'Baja'
--		end as Status, 
		isnull(SUC.FormaVenta,'') as [Forma de Venta],
		isnull(SUC.CodigoBarras,'') as [Código de Barras], isnull(SUC.Calle,'') as Calle, isnull(SUC.NumExterior,'') AS [No. Ext],
            		isnull(SUC.NumInterior,'') AS [No. Int], isnull(SUC.Colonia,'') as Colonia, isnull(SUC.Localidad,'') as [Localidad], isnull(SUC.Poblacion,'') as Poblacion, 
		isnull(SUC.Entidad,'') as Entidad, isnull(SUC.Pais,'') as [País], isnull(SUC.Telefonos,'') AS Teléfonos, isnull(SUC.CP,'') AS 'C.P.', 
		isnull(SUC.RFC,'') AS [RFC], isnull(SUC.RazonSocial,'') AS [Razón Social],
		isnull(SUC.CalleF,'') as CalleF, isnull(SUC.NumExteriorF,'') AS [No. ExtF],
            		isnull(SUC.NumInteriorF,'') AS [No. IntF], isnull(SUC.ColoniaF,'') as ColoniaF, isnull(SUC.LocalidadF,'') as [LocalidadF], isnull(SUC.PoblacionF,'') as PoblacionF, 
		isnull(SUC.EntidadF,'') as EntidadF, isnull(SUC.PaisF,'') as [PaísF], isnull(SUC.TelefonosF,'') AS TeléfonosF, isnull(SUC.CPF,'') AS 'C.P.F', SUC.Contacto,
		ISNULL(SUC.DiasCredito, 0) as 'Dias Crédito', ISNULL(SUC.LimiteCredito, 0) as 'Crédito'
	FROM         Clientes CTE INNER JOIN
	                      ClienteSucursal SUC ON CTE.IdCedis = SUC.IdCedis AND CTE.IdCliente = SUC.IdCliente
	WHERE     (CTE.IdCliente = @IdCliente) AND CTE.IdCedis = @IdCedis
		and (@IdSucursal = '' or SUC.IdSucursal like '%' + @IdSucursal + '%')	
		and (@RFC = '' or SUC.RFC like '%' + @RFC + '%')
		and (@NombreSucursal = '' or SUC.NombreSucursal like '%' + @NombreSucursal + '%')
		and (@Calle = '' or SUC.Calle like '%' + @Calle + '%')
	ORDER BY SUC.NombreSucursal
End

if @Opc = 2 		-- sucursales para un solo cliente
Begin
	SELECT     SUC.IdCedis, CTE.RazonSocial AS cliente, SUC.IdCliente, SUC.IdSucursal, isnull(SUC.TDA_GLN,'') AS [TDA/GLN], 
		isnull(SUC.NombreSucursal,'') AS Sucursal,
		case SUC.Status
			when 'A' then 'Activo'
			when 'B' then 'Baja'
			when 'S' then 'Suspendido'
			when null then 'Baja'
		end as Status, 
		case SUC.FormaVenta
			when 1 then 'Contado'
			when 2 then 'Crédito' 
		end as [Forma de Venta],
		isnull(SUC.CodigoBarras,'') as [Código de Barras], isnull(SUC.Calle,'') as Calle, isnull(SUC.NumExterior,'') AS [No. Ext],
            		isnull(SUC.NumInterior,'') AS [No. Int], isnull(SUC.Colonia,'') as Colonia, isnull(SUC.Localidad,'') as [Localidad], isnull(SUC.Poblacion,'') as Poblacion, 
		isnull(SUC.Entidad,'') as Entidad, isnull(SUC.Pais,'') as [País], isnull(SUC.Telefonos,'') AS Teléfonos, isnull(SUC.CP,'') AS 'C.P.', 
		isnull(SUC.RFC,'') AS [RFC], isnull(SUC.RazonSocial,'') AS [Razón Social],
		isnull(SUC.CalleF,'') as CalleF, isnull(SUC.NumExteriorF,'') AS [No. ExtF],
            		isnull(SUC.NumInteriorF,'') AS [No. IntF], isnull(SUC.ColoniaF,'') as ColoniaF, isnull(SUC.LocalidadF,'') as [LocalidadF], isnull(SUC.PoblacionF,'') as PoblacionF, 
		isnull(SUC.EntidadF,'') as EntidadF, isnull(SUC.PaisF,'') as [PaísF], isnull(SUC.TelefonosF,'') AS TeléfonosF, isnull(SUC.CPF,'') AS 'C.P.F', SUC.Contacto,
		ISNULL(SUC.DiasCredito, 0) as 'Dias Crédito', ISNULL(SUC.LimiteCredito, 0) as 'Crédito'
	FROM         Clientes CTE INNER JOIN
	                      ClienteSucursal SUC ON CTE.IdCedis = SUC.IdCedis AND CTE.IdCliente = SUC.IdCliente
	WHERE     (CTE.IdCliente = @IdCliente) AND CTE.IdCedis = @IdCedis
	ORDER BY SUC.NombreSucursal
End

IF @Opc = 3
begin
	select replicate ('0', 2-len(@IdCedis)) + cast(@IdCedis as varchar(2)) 
		+ replicate ('0', 3-len(@IdRuta)) + cast(@IdRuta as varchar(3)) 
		+ replicate ('0', 4-len(isnull(max(cast(right(IdSucursal,4) as int)) + 1, 1) )) + cast( isnull(max(cast(right(IdSucursal,4) as int)) + 1, 1) as varchar(10))
	from ClienteSucursal
	where IdCedis = @IdCedis and cast( substring(IdSucursal,3,3) as int) = @IdRuta
end 



GO


