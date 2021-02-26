USE [RouteCPC]
GO

/****** Object:  StoredProcedure [dbo].[sel_Clientes]    Script Date: 05/19/2011 13:45:04 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sel_Clientes]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sel_Clientes]
GO

USE [RouteCPC]
GO

/****** Object:  StoredProcedure [dbo].[sel_Clientes]    Script Date: 05/19/2011 13:45:04 ******/
SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER OFF
GO

CREATE PROCEDURE [dbo].[sel_Clientes] 
@IdCedis as bigint,
@IdCliente as bigint,
@RazonSocial as varchar(15),
@IdCadenaOxxo as bigint, 
@SerieOxxo as varchar(5),
@Opc as int
AS

-- declare @IdCadenaOxxo as bigint, @SerieOxxo as varchar(5)
if @Opc = 1
begin
	-- set @IdCadenaOxxo = ( select isnull( IdCadenaOxxo, 0) from Configuracion )
	-- set @SerieOxxo = ( select isnull( SerieOxxo, 'OX') from Configuracion ) + cast ( @IdCedis as varchar(10))

	select top 1 1, IdCliente, RFC, RazonSocial, @SerieOxxo, ( select  isnull ( max ( folio )+1, 1)  from Ventas where IdCedis = @IdCedis and IdTipoVenta = 2 and Serie = @SerieOxxo )
	from Clientes 
	where IdCadena = @IdCadenaOxxo
end

GO


