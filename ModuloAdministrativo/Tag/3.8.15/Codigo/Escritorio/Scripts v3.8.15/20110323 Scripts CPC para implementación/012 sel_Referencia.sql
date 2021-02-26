USE [RouteCPC]
GO

/****** Object:  StoredProcedure [dbo].[sel_Referencia]    Script Date: 03/01/2011 12:21:21 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sel_Referencia]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sel_Referencia]
GO

USE [RouteCPC]
GO

/****** Object:  StoredProcedure [dbo].[sel_Referencia]    Script Date: 03/01/2011 12:21:21 ******/
SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER OFF
GO

CREATE PROCEDURE [dbo].[sel_Referencia] 
@IdCedis as bigint,
@Referencia as varchar(20),
@Opc as int
AS

if @Opc = 1
begin	
	select *
	from MovimientosFacturas 
	where Referencia = @Referencia 
end

if @Opc = 2
begin	
	select *
	from MovimientosFacturas 
	where ReferenciaBancos = @Referencia 
end

GO


