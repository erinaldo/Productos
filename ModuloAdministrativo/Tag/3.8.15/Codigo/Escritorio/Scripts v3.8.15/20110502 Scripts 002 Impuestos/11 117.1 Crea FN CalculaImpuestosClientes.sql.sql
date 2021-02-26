USE [RouteADM]
GO

/****** Object:  UserDefinedFunction [dbo].[FN_ImpuestosClientes]    Script Date: 05/04/2011 09:36:09 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FN_ImpuestosClientes]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[FN_ImpuestosClientes]
GO

USE [RouteADM]
GO

/****** Object:  UserDefinedFunction [dbo].[FN_ImpuestosClientes]    Script Date: 05/04/2011 09:36:09 ******/
SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER OFF
GO



CREATE FUNCTION [dbo].[FN_ImpuestosClientes]
(
@IdCedis as bigint,
@IdCliente as bigint,
@IdSucursal as varchar(30),
@IdProducto as bigint
)  
RETURNS Table AS  
return
(
		select Productos.IdProducto, TipoImpuesto.IdTipoImpuesto, TipoAplicacion, Jerarquia, TipoImpuesto.Tasa as Impuestos
		from Productos 
		left outer join ProductosImpuestos on ProductosImpuestos.IdProducto = Productos.IdProducto 
		left outer join TipoImpuesto on TipoImpuesto.IdTipoImpuesto = ProductosImpuestos.IdTipoImpuesto
		where Productos.IdProducto = @IdProducto
		
		union 
		
		select ClientesImpuestos.IdProducto, TipoImpuesto.IdTipoImpuesto, TipoAplicacion, Jerarquia, TipoImpuesto.Tasa as Impuestos
		from ClientesImpuestos 
		inner join TipoImpuesto on TipoImpuesto.IdTipoImpuesto = ClientesImpuestos.IdTipoImpuesto
		where ClientesImpuestos.IdCedis = @IdCedis and ClientesImpuestos.IdCliente = @IdCliente and ClientesImpuestos.IdSucursal = @IdSucursal 
			and  ClientesImpuestos.IdProducto = @IdProducto 

)

GO


