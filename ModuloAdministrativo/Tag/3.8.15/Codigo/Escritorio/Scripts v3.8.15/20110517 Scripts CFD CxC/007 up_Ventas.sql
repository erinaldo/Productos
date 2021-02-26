USE [RouteCPC]
GO

/****** Object:  StoredProcedure [dbo].[up_Ventas]    Script Date: 05/18/2011 03:48:43 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[up_Ventas]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[up_Ventas]
GO

USE [RouteCPC]
GO

/****** Object:  StoredProcedure [dbo].[up_Ventas]    Script Date: 05/18/2011 03:48:43 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[up_Ventas] 
@IdCedis as bigint,
@IdTipoVenta as int,
@Serie as varchar(5),
@Folio as bigint,
@Fecha as datetime,
@IdCliente as bigint,
@IdSucursal as varchar(16),
@Login as varchar(20),
@Opc as int

AS

declare 
@DiasCredito as int

if @Opc = 1 -- Inserta Factura Nueva
begin

	select @DiasCredito = ISNULL(DiasCredito,0) 
	from ClienteSucursal 
	where IdCedis = @IdCedis and IdCliente = @IdCliente and IdSucursal = @IdSucursal and @IdTipoVenta = 2
	
	insert into Ventas values (@IdCedis, @IdTipoVenta, @Folio, @Serie, @Fecha, @IdCliente, 0,0, 0,0, @DiasCredito, @IdSucursal, 0,'',0, 'P', @Login, GETDATE())	

	insert into VentasAcredita 
	select IdCedis, IdTipoVenta, Folio, Serie, Fecha, Fecha, Login, Fecha, '', '', '', Folio, Folio, 'A', 7
	from Ventas  
	where IdCedis = @IdCedis and IdTipoVenta = @IdTipoVenta and Serie = @Serie and Folio = @Folio 
end

if @Opc = 2 -- Aplica Factura
begin

	update Ventas set Status = 'A', Login = @Login, FechaEdicion = GETDATE() 
	where IdCedis = @IdCedis and IdTipoVenta = @IdTipoVenta and Serie = @Serie and Folio = @Folio 

end

if @Opc = 3 -- Elimina Factura
begin

	delete from VentasDetalle where IdCedis = @IdCedis and IdTipoVenta = @IdTipoVenta and Serie = @Serie and Folio = @Folio 
	delete from VentasImpuestos where IdCedis = @IdCedis and IdTipoVenta = @IdTipoVenta and Serie = @Serie and Folio = @Folio 
	delete from Ventas where IdCedis = @IdCedis and IdTipoVenta = @IdTipoVenta and Serie = @Serie and Folio = @Folio 
	delete from VentasAcredita where IdCedis = @IdCedis and IdTipoVenta = @IdTipoVenta and Serie = @Serie and Folio = @Folio 

end




GO


