USE [RouteCPC]
GO

/****** Object:  StoredProcedure [dbo].[up_CobranzaTerminal]    Script Date: 02/04/2011 12:09:40 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[up_CobranzaTerminal]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[up_CobranzaTerminal]
GO

USE [RouteCPC]
GO

/****** Object:  StoredProcedure [dbo].[up_CobranzaTerminal]    Script Date: 02/04/2011 12:09:40 ******/
SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER OFF
GO


CREATE PROCEDURE [dbo].[up_CobranzaTerminal]
@IdCedis as bigint,
@Fecha as datetime,
@Login as varchar(20),
@Opc as int
AS

declare @IdMovimiento as bigint, @IdMovD as bigint
declare @Serie as varchar(20), @Folio as varchar(30), @Monto as money -- , @TotalFactura as money, @FechaFactura as datetime
declare @FolioC as varchar(40), @Saldo as money, @TransProdId as varchar(50)
declare @IdCliente as bigint, @IdSucursal as varchar(30), @UsuClave as varchar(30)
declare @Abonos as money, @Devoluciones as money

if @Opc = 1 -- inserta movimiento
begin

set @IdMovimiento = ( select isnull( max(IdMovimiento)+ 1, 1) from RouteCPC.dbo.Movimientos where IdCedis = @IdCedis )
insert into RouteCPC.dbo.Movimientos values 
(@IdCedis, @IdMovimiento, @Fecha, 'CT', 'A', 0, '', '', 'COBRANZA (Día ' + CAST(@Fecha as varchar(15)) + ')', 'P', @Login, GETDATE())
set @IdMovD = 1

declare @CursorMOV CURSOR
SET @CursorMOV = CURSOR SCROLL DYNAMIC FOR 

		select right(USU.Clave, 3), replace(Route.dbo.FNObtenerSoloNumeros(TRP.Folio),'-','') as Folio, sum(ABN.Total) as Total, TRP.Folio, USU.Clave, TRP.TransProdId
		from Route.dbo.AbnTrp ABT
		inner join Route.dbo.TransProd TRP on ABT.TransProdID = TRP.TransProdID 
		inner join Route.dbo.Abono ABN on ABT.ABNId = ABN.ABNId 
		inner join Route.dbo.Dia Dia on ABN.DiaClave = Dia.DiaClave
		inner join Route.dbo.Visita VIS on ABN.VisitaClave = VIS.VisitaClave
		inner join Route.dbo.Vendedor VEN on VEN.VendedorID = VIS.VendedorID
		inner join Route.dbo.Usuario USU on USU.USUId = VEN.USUId
		where Dia.FechaCaptura= @Fecha and USU.Clave in ( 
			select 'USER' + CAST(IdRuta as varchar(2)) from RouteADM.dbo.Rutas where IdCedis = @IdCedis) 
		and TRP.TipoFase <> 0 and (TRP.CFVTipo = 2 or TRP.CFVTipo is null)
		group by TRP.Folio, TRP.FechaCaptura, TRP.Total, USU.Clave, TRP.TransProdId

OPEN @CursorMOV
FETCH NEXT FROM @CursorMOV INTO @Serie, @Folio, @Monto, @FolioC, @UsuClave, @TransProdId
WHILE @@FETCH_STATUS = 0      
BEGIN
	--select @IdCedis, @Serie, @Folio 

	if exists(select Folio from Ventas where IdCedis = @IdCedis and Serie = @Serie and Folio = @Folio and IdTipoVenta = 2)
	begin
		insert into RouteCPC.dbo.MovimientosFacturas values 
		(@IdCedis, 2, @Serie, @Folio, @IdMovimiento, @Fecha, @IdMovD, 'CT', '1', 'A', '', '', @Monto, 0, 'A', 'Terminal', GETDATE())
	end
	else
	begin 
		if exists ( select Folio from Ventas where IdCedis = @IdCedis and FolioC = @FolioC ) 
		begin
			select @Serie = Serie, @Folio = Folio from Ventas where IdCedis = @IdCedis and FolioC = @FolioC 
			insert into RouteCPC.dbo.MovimientosFacturas values 
			(@IdCedis, 2, @Serie, @Folio, @IdMovimiento, @Fecha, @IdMovD, 'CT', '1', 'A', '', '', @Monto, 0, 'A', 'Terminal', GETDATE())
		end
		--else
		--begin
		--	select @IdSucursal = VIS.ClienteClave, @IdCliente = CTES.IdCliente, @Saldo = TRP.Total 
		--	from ROUTE.dbo.TransProd TRP
		--	inner join Route.dbo.Dia Dia on TRP.DiaClave = Dia.DiaClave
		--	inner join Route.dbo.Visita VIS on TRP.VisitaClave = VIS.VisitaClave
		--	inner join Route.dbo.Vendedor VEN on VEN.VendedorID = VIS.VendedorID
		--	inner join Route.dbo.Usuario USU on USU.USUId = VEN.USUId 
		--	inner join RouteADM.dbo.ClienteSucursal CTES on CTES.IdCedis = @IdCedis and CTES.IdSucursal = VIS.ClienteClave 
		--	where TRP.TransProdID = @TransProdId 
		--	-- Folio = @FolioC and TRP.CFVTipo is null and TRP.TipoFase <> 0 and USU.Clave = @UsuClave 
			
		--	set @Abonos = 0
		--	set @Devoluciones = 0
			
		--	select @Abonos = isnull(sum(ABN.Total),0)
		--	from Route.dbo.AbnTrp ABT
		--	inner join Route.dbo.TransProd TRP on ABT.TransProdID = TRP.TransProdID 
		--	inner join Route.dbo.Abono ABN on ABT.ABNId = ABN.ABNId 
		--	inner join Route.dbo.Dia Dia on ABN.DiaClave = Dia.DiaClave
		--	inner join Route.dbo.Visita VIS on ABN.VisitaClave = VIS.VisitaClave
		--	where TRP.TransProdID = @TransProdId and Dia.FechaCaptura < @Fecha 

		--	if SUBSTRING(@FolioC,1,1) = 'C'
		--		select @Devoluciones = isnull(SUM(TPD.Total),0)
		--		from Route.dbo.TransProd TRPC
		--		inner join Route.dbo.TrpTpd TPD on TPD.TransProdID1 = TRPC.TransProdID 
		--		inner join Route.dbo.TransProd TRP on TPD.TransProdID = TRP.TransProdID 
		--		inner join Route.dbo.Dia Dia on TRP.DiaClave = Dia.DiaClave
		--		inner join Route.dbo.Visita VIS on TRP.VisitaClave = VIS.VisitaClave
		--		where TRPC.TransProdID = @TransProdId and Dia.FechaCaptura < @Fecha 
				
		--	select @Saldo = @Saldo - @Abonos - @Devoluciones 			
						
		--	select @Serie = case substring(@FolioC,1,1) when 'C' then 'C' + @Serie else @Serie end
		
		--	if not exists (select FolioC from Ventas where IdCedis = @IdCedis and FolioC = @FolioC and Serie = @Serie)
		--		insert into Ventas values (@IdCedis, 2, Route.dbo.FNObtenerSoloNumeros(@FolioC), @Serie, @Fecha, @IdCliente, @Saldo, 0, 0, 0, 0, @IdSucursal, 1, @FolioC, '', 'SNoReg', GETDATE())
		
		--	insert into RouteCPC.dbo.MovimientosFacturas values 
		--	(@IdCedis, 2, @Serie, Route.dbo.FNObtenerSoloNumeros(@FolioC), @IdMovimiento, @Fecha, @IdMovD, 'CT', '1', 'A', '', '', @Monto, 0, 'A', 'Terminal', GETDATE())
		--end
	end
	
	set @IdMovD = @IdMovD + 1
	FETCH NEXT FROM @CursorMOV INTO @Serie, @Folio, @Monto, @FolioC, @UsuClave, @TransProdId
END
CLOSE @CursorMOV  
DEALLOCATE @CursorMOV

end



GO


