USE [RouteCPC]
GO

/****** Object:  StoredProcedure [dbo].[up_CobranzaTerminal]    Script Date: 06/13/2011 18:13:44 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[up_CobranzaTerminal]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[up_CobranzaTerminal]
GO

USE [RouteCPC]
GO

/****** Object:  StoredProcedure [dbo].[up_CobranzaTerminal]    Script Date: 06/13/2011 18:13:44 ******/
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
declare @Serie as varchar(20), @Folio as varchar(20), @Monto as money-- , @TotalFactura as money, @FechaFactura as datetime
declare @FolioC as varchar(40) 

if @Opc = 1 -- inserta movimiento
begin

-- INSERTA LÁCTEOS

set @IdMovimiento = ( select isnull( max(IdMovimiento)+ 1, 1) from RouteCPC.dbo.Movimientos where IdCedis = @IdCedis )
insert into RouteCPC.dbo.Movimientos values (@IdCedis, @IdMovimiento, @Fecha, 'CT', 'A', 0, '', '', 'COBRANZA LÁCTEOS (Día ' + CAST(@Fecha as varchar(15)) + ')', 'P', @Login, GETDATE())
set @IdMovD = 1

declare @CursorMOV CURSOR
SET @CursorMOV = CURSOR SCROLL DYNAMIC FOR 
	select replace(FAC.Folio, Route.dbo.FNObtenerSoloNumeros(FAC.Folio),''), Route.dbo.FNObtenerSoloNumeros(FAC.Folio) as Folio, 
	sum(ABT.Importe) as Total, FAC.Folio
	from Route.dbo.AbnTrp ABT
	inner join Route.dbo.TransProd FAC on ABT.TransProdID = FAC.TransProdID 
	inner join Route.dbo.Abono ABN on ABT.ABNId = ABN.ABNId 
	inner join Route.dbo.Dia Dia on ABN.DiaClave = Dia.DiaClave
	inner join Route.dbo.Visita VIS on ABN.VisitaClave = VIS.VisitaClave
	inner join Route.dbo.Vendedor VEN on VEN.VendedorID = VIS.VendedorID
	inner join Route.dbo.Usuario USU on USU.USUId = VEN.USUId
	inner join RouteADM.dbo.Marcas M on M.IdMarca = FAC.SubEmpresaID 
	inner join Route.dbo.Cliente CS on CS.ClienteClave = VIS.ClienteClave 
	where Dia.FechaCaptura= @Fecha -- and USU.Clave = cast( @IdCedis as varchar(10) ) + replicate('0', 4 - len( @IdRuta ) ) + cast( @IdRuta as varchar(10) )
	and FAC.Tipo = 8 and FAC.TipoFase <> 0 and (FAC.CFVTipo = 2 or FAC.CFVTipo is null) and FAC.SubEmpresaId = 1
	and ABN.MUsuarioID <> '10000'
	group by M.IdMarca, M.Marca, CS.NombreCorto, FAC.Folio

OPEN @CursorMOV
FETCH NEXT FROM @CursorMOV INTO @Serie, @Folio, @Monto, @FolioC
WHILE @@FETCH_STATUS = 0      
BEGIN
	if exists(select Folio from Ventas where IdCedis = @IdCedis and Serie = @Serie and Folio = @Folio and IdTipoVenta = 2)                                                           
		insert into RouteCPC.dbo.MovimientosFacturas values 
		(@IdCedis, 2, @Serie, @Folio, @IdMovimiento, @Fecha, @IdMovD, 'CT', '1', 'A', '', '', @Monto, 0, 'A', 'Terminal', GETDATE())     
	else
	begin 
		select @Serie = Serie, @Folio = Folio 
		from Ventas 
		where IdCedis = @IdCedis and FolioC = @FolioC 

		insert into RouteCPC.dbo.MovimientosFacturas values 
		(@IdCedis, 2, @Serie, @Folio, @IdMovimiento, @Fecha, @IdMovD, 'CT', '1', 'A', '', '', @Monto, 0, 'A', 'Terminal', GETDATE())     
	end
	
	set @IdMovD = @IdMovD + 1
	FETCH NEXT FROM @CursorMOV INTO @Serie, @Folio, @Monto, @FolioC
END
CLOSE @CursorMOV  
DEALLOCATE @CursorMOV

-- INSERTA COBASUR

set @IdMovimiento = ( select isnull( max(IdMovimiento)+ 1, 1) from RouteCPC.dbo.Movimientos where IdCedis = @IdCedis )
insert into RouteCPC.dbo.Movimientos values (@IdCedis, @IdMovimiento, @Fecha, 'CT', 'A', 0, '', '', 'COBRANZA COBASUR (Día ' + CAST(@Fecha as varchar(15)) + ')', 'P', @Login, GETDATE())
set @IdMovD = 1

SET @CursorMOV = CURSOR SCROLL DYNAMIC FOR 
	select replace(FAC.Folio, Route.dbo.FNObtenerSoloNumeros(FAC.Folio),''), Route.dbo.FNObtenerSoloNumeros(FAC.Folio) as Folio, 
	sum(ABT.Importe) as Total, FAC.Folio
	from Route.dbo.AbnTrp ABT
	inner join Route.dbo.TransProd FAC on ABT.TransProdID = FAC.TransProdID 
	inner join Route.dbo.Abono ABN on ABT.ABNId = ABN.ABNId 
	inner join Route.dbo.Dia Dia on ABN.DiaClave = Dia.DiaClave
	inner join Route.dbo.Visita VIS on ABN.VisitaClave = VIS.VisitaClave
	inner join Route.dbo.Vendedor VEN on VEN.VendedorID = VIS.VendedorID
	inner join Route.dbo.Usuario USU on USU.USUId = VEN.USUId
	inner join RouteADM.dbo.Marcas M on M.IdMarca = FAC.SubEmpresaID 
	inner join Route.dbo.Cliente CS on CS.ClienteClave = VIS.ClienteClave 
	where Dia.FechaCaptura= @Fecha -- and USU.Clave = cast( @IdCedis as varchar(10) ) + replicate('0', 4 - len( @IdRuta ) ) + cast( @IdRuta as varchar(10) )
	and FAC.Tipo = 8 and FAC.TipoFase <> 0 and (FAC.CFVTipo = 2 or FAC.CFVTipo is null) and FAC.SubEmpresaId = 2
	and ABN.MUsuarioID <> '10000'
	group by M.IdMarca, M.Marca, CS.NombreCorto, FAC.Folio

OPEN @CursorMOV
FETCH NEXT FROM @CursorMOV INTO @Serie, @Folio, @Monto, @FolioC
WHILE @@FETCH_STATUS = 0      
BEGIN                                                            

	if exists(select Folio from Ventas where IdCedis = @IdCedis and Serie = @Serie and Folio = @Folio and IdTipoVenta = 2)   
	begin                                                        
		insert into RouteCPC.dbo.MovimientosFacturas values 
		(@IdCedis, 2, @Serie, @Folio, @IdMovimiento, @Fecha, @IdMovD, 'CT', '1', 'A', '', '', @Monto, 0, 'A', 'Terminal', GETDATE())     
	end
	else
	begin 
		select @Serie = Serie, @Folio = Folio 
		from Ventas 
		where IdCedis = @IdCedis and FolioC = @FolioC

		insert into RouteCPC.dbo.MovimientosFacturas values 
		(@IdCedis, 2, @Serie, @Folio, @IdMovimiento, @Fecha, @IdMovD, 'CT', '1', 'A', '', '', @Monto, 0, 'A', 'Terminal', GETDATE())     
	end
	
	set @IdMovD = @IdMovD + 1
	FETCH NEXT FROM @CursorMOV INTO @Serie, @Folio, @Monto, @FolioC
END
CLOSE @CursorMOV  
DEALLOCATE @CursorMOV

end


GO


