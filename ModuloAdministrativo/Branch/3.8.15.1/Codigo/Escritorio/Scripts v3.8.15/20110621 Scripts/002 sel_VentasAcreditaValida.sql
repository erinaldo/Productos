USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[sel_VentasAcreditaValida]    Script Date: 06/22/2011 09:10:01 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sel_VentasAcreditaValida]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sel_VentasAcreditaValida]
GO

USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[sel_VentasAcreditaValida]    Script Date: 06/22/2011 09:10:01 ******/
SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER OFF
GO





CREATE PROCEDURE [dbo].[sel_VentasAcreditaValida] 
@IdCedis as bigint,
@IdSurtido as bigint,
@IdTipoVenta as bigint,
@Serie as varchar(5),
@Folio as bigint,
@Opc as int

AS

declare @IdSucursal as varchar(200), @AddID as varchar(20)

if @Opc = 1
begin

	select @AddID = ''
	
	select @IdSucursal = IdSucursal, @AddID = isnull(Addenda.ADDID, '')
	from Ventas
	left outer join Route.dbo.AddendaCliente AdCte on Ventas.IdSucursal = AdCte.ClienteClave 
	left outer join Route.dbo.Addenda Addenda on AdCte.ADDId = Addenda.ADDID 
	where Ventas.IdCedis = @IdCedis and Ventas.IdSurtido = @IdSurtido and Ventas.IdTipoVenta = @IdTipoVenta 
		and Ventas.Serie = @Serie and Ventas.Folio = @Folio 

	if @AddID <> '' and @AddID is not null
	begin
		select *
		from VentasAcreditaValida 
		where ADDId = @AddID  
	end
	
	
end


GO


