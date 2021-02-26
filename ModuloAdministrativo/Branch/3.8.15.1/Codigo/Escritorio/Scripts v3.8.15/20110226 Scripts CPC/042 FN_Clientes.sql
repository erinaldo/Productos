USE [RouteCPC]
GO

/****** Object:  UserDefinedFunction [dbo].[FN_Clientes]    Script Date: 03/21/2011 12:13:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FN_Clientes]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[FN_Clientes]
GO

USE [RouteCPC]
GO

/****** Object:  UserDefinedFunction [dbo].[FN_Clientes]    Script Date: 03/21/2011 12:13:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE FUNCTION [dbo].[FN_Clientes]
(
@IdSucursal as varchar(1000),	
@NombreSucursal as varchar(1000),
@Cliente as varchar(1000)
)  
RETURNS Table AS  
return
(
	select distinct isnull(Clientes.IdCedis, '') as IdCedis, isnull(Cedis, '-Cedis no encontrado-') as Cedis, Clientes.IdCliente, Clientes.RazonSocial
	from RouteADM.dbo.Clientes as Clientes
	left outer join RouteADM.dbo.Cedis as Cedis on Cedis.IdCedis = Clientes.IdCedis
	--inner join RouteADM.dbo.ClienteSucursal as ClienteSucursal on Clientes.IdCedis = ClienteSucursal.IdCedis and Clientes.IdCliente = ClienteSucursal.IdCliente
	where IdCliente like '%' + @Cliente + '%' or Clientes.RazonSocial like '%' + @Cliente + '%'  
)

GO


