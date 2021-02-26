USE [RouteCPC]
GO

/****** Object:  StoredProcedure [dbo].[sel_VentasAcreditaValida]    Script Date: 06/22/2011 09:10:01 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sel_VentasAcreditaValida]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sel_VentasAcreditaValida]
GO

USE [RouteCPC]
GO

/****** Object:  StoredProcedure [dbo].[sel_VentasAcreditaValida]    Script Date: 06/22/2011 09:10:01 ******/
SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER OFF
GO





CREATE PROCEDURE [dbo].[sel_VentasAcreditaValida] 
@IdCedis as bigint,
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
	from RouteCPC.dbo.Ventas
	left outer join Route.dbo.AddendaCliente AdCte on cast (case IdCedis when 1 then 'A' 
			when 2 then 'B' 
			when 3 then 'C' 
			when 4 then 'D' 
			when 5 then 'E'
			when 6 then 'F'
			when 7 then 'G'
			when 8 then 'H'
			when 9 then 'I'
			when 10 then 'J'
			else '' end as varchar(5))+Ventas.IdSucursal = AdCte.ClienteClave 
	left outer join Route.dbo.Addenda Addenda on AdCte.ADDId = Addenda.ADDID 
	where Ventas.IdCedis = @IdCedis and Ventas.IdTipoVenta = @IdTipoVenta 
		and Ventas.Serie = @Serie and Ventas.Folio = @Folio 

	if @AddID <> '' and @AddID is not null
	begin
		select *
		from RouteADM.dbo.VentasAcreditaValida  
		where ADDId = @AddID  
	end
	
	
end


GO


