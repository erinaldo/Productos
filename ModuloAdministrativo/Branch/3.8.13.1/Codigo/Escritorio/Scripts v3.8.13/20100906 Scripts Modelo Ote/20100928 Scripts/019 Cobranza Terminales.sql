USE [RouteCPC]
GO

/****** Object:  StoredProcedure [dbo].[sel_DiasCerrados]    Script Date: 09/22/2010 13:55:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sel_DiasCerrados]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sel_DiasCerrados]
GO

/****** Object:  StoredProcedure [dbo].[up_CobranzaTerminal]    Script Date: 09/22/2010 13:55:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[up_CobranzaTerminal]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[up_CobranzaTerminal]
GO

USE [RouteCPC]
GO

/****** Object:  StoredProcedure [dbo].[sel_DiasCerrados]    Script Date: 09/22/2010 13:55:06 ******/
SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER OFF
GO

CREATE PROCEDURE [dbo].[sel_DiasCerrados] 
@IdCedis as bigint,
@Opc as int
AS

if @Opc = 1 -- Por Cedis y Fechas
	select distinct SD.StatusDesc, SD.Fecha
	from RouteADM.dbo.StatusDia SD 
	where SD.IdCedis = @IdCedis and SD.Fecha not in ( select Fecha from Movimientos 
	where IdDocumento = 'CT' and Status = 'A' and Fecha = SD.Fecha )
		and Status = 'C'
	order by SD.Fecha desc

GO

/****** Object:  StoredProcedure [dbo].[up_CobranzaTerminal]    Script Date: 09/22/2010 13:55:07 ******/
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

set @IdMovimiento = ( select isnull( max(IdMovimiento)+ 1, 1) from RouteCPC.dbo.Movimientos where IdCedis = @IdCedis )
insert into RouteCPC.dbo.Movimientos values (@IdCedis, @IdMovimiento, @Fecha, 'CT', 'A', 0, '', '', 'COBRANZA LÁCTEOS (Día ' + CAST(@Fecha as varchar(15)) + ')', 'P', @Login, GETDATE())
set @IdMovD = 1

declare @CursorMOV CURSOR
SET @CursorMOV = CURSOR SCROLL DYNAMIC FOR 

	select right(USU.Clave, 3), Route.dbo.FNObtenerSoloNumeros(FAC.Folio) as Folio, 
	sum(ABN.Total) as Total, FAC.Folio
	from Route.dbo.AbnTrp ABT
	inner join Route.dbo.TransProd FAC on ABT.TransProdID = FAC.TransProdID 
	left join Route.dbo.TransProd TRP on FAC.TransProdID = TRP.FacturaID 
	inner join Route.dbo.Abono ABN on ABT.ABNId = ABN.ABNId 
	inner join Route.dbo.Dia Dia on ABN.DiaClave = Dia.DiaClave
	inner join Route.dbo.Visita VIS on ABN.VisitaClave = VIS.VisitaClave
	inner join Route.dbo.Vendedor VEN on VEN.VendedorID = VIS.VendedorID
	inner join Route.dbo.Usuario USU on USU.USUId = VEN.USUId
	inner join Route.dbo.Cliente CS on CS.ClienteClave = VIS.ClienteClave 
	where Dia.FechaCaptura= @Fecha 
	and FAC.TipoFase <> 0 and (TRP.CFVTipo = 2 or TRP.CFVTipo is null) 
	group by CS.NombreCorto, FAC.Folio, TRP.FechaCaptura, TRP.Total, USU.Clave

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

end


GO

