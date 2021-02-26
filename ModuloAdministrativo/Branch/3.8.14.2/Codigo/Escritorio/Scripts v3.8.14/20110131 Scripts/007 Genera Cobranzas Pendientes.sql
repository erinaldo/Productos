
use RouteCPC 

declare @FolioRoute as varchar(20), @Folio as bigint, @Serie as varchar(10), @AbonosTerminal as money, @AbonosCPC as money, @SaldoVenta as money
declare @IdMov as bigint, @IdMovDet as bigint, @ImporteAbono as money

select @IdMov = ISNULL(IdMovimiento+1,1) 
from Movimientos

insert into Movimientos 
select 1, @IdMov, '20110130', 'CT', 'A', 0, '', '', 'COBRANZA LÁCTEOS (PENDIENTES DE APLICAR DESDE ENERO DE 2010 HASTA ENERO DE 2011)', 'A', 'SUPER', GETDATE()

declare AplicaAbonosEnero cursor for
		select distinct FAC.Folio as FolioRoute, Route.dbo.FNObtenerSoloNumeros(FAC.Folio) as Folio, replace(FAC.Folio, Route.dbo.FNObtenerSoloNumeros(FAC.Folio),'') as Serie, sum(ABT.Importe) TotalAbonos, 
		Ventas.Abonos as AbonosCPC, ventas.Abonos - SUM(ABT.Importe) as Diferencia--Ventas.Saldo as SaldoCPC
		from Route.dbo.AbnTrp ABT
		inner join Route.dbo.TransProd FAC on ABT.TransProdID = FAC.TransProdID 
		inner join Route.dbo.Abono ABN on ABT.ABNId = ABN.ABNId 
		inner join Route.dbo.Dia Dia on ABN.DiaClave = Dia.DiaClave
		inner join Route.dbo.Visita VIS on ABN.VisitaClave = VIS.VisitaClave
		inner join Route.dbo.Vendedor VEN on VEN.VendedorID = VIS.VendedorID
		inner join Route.dbo.Usuario USU on USU.USUId = VEN.USUId
		inner join Route.dbo.Cliente CS on CS.ClienteClave = VIS.ClienteClave 
		left outer join RouteCPC.dbo.Ventas on Ventas.Serie = replace(FAC.Folio, Route.dbo.FNObtenerSoloNumeros(FAC.Folio),'')
			and Ventas.Folio = CAST(Route.dbo.FNObtenerSoloNumeros(FAC.Folio) as bigint)
		where Dia.FechaCaptura between '20100101' and '20110131' --and FAC.FOLIO LIKE '%EBE%1083'
		and FAC.Tipo = 8 and FAC.TipoFase <> 0 and (FAC.CFVTipo = 2 or FAC.CFVTipo is null) and FAC.SubEmpresaId = 1
		group by FAC.Folio, Ventas.Abonos, Ventas.Saldo, Ventas.Total
		having  SUM(ABT.Importe) <> Ventas.Abonos and SUM(ABT.Importe) > ventas.Abonos and SUM(ABT.Importe) - ventas.Abonos not between -1 and 1
		order by FAC.Folio

	open AplicaAbonosEnero

	fetch next from AplicaAbonosEnero into @FolioRoute, @Folio, @Serie, @AbonosTerminal, @AbonosCPC, @SaldoVenta
		while @@fetch_status = 0
		begin
	
			set @ImporteAbono = @AbonosTerminal - @AbonosCPC 
			exec up_MovimientosFacturas 1, 2, @Serie, @Folio, @IdMov, '20110130', 0, 'CT', '1', 'A', '', '', @ImporteAbono, 0, 'A', 'SUPER', 1
			
			fetch next from AplicaAbonosEnero into @FolioRoute, @Folio, @Serie, @AbonosTerminal, @AbonosCPC, @SaldoVenta
		end
	close AplicaAbonosEnero

deallocate AplicaAbonosEnero
	
select @IdMov = ISNULL(IdMovimiento+1,1) 
from Movimientos

insert into Movimientos 
select 1, @IdMov, '20110130', 'CT', 'A', 0, '', '', 'COBRANZA COBASUR (PENDIENTES DE APLICAR DESDE ENERO DE 2010 HASTA ENERO DE 2011)', 'A', 'SUPER', GETDATE()

declare AplicaAbonosEnero cursor for
		select distinct FAC.Folio as FolioRoute, Route.dbo.FNObtenerSoloNumeros(FAC.Folio) as Folio, replace(FAC.Folio, Route.dbo.FNObtenerSoloNumeros(FAC.Folio),'') as Serie, sum(ABT.Importe) TotalAbonos, 
		Ventas.Abonos as AbonosCPC, ventas.Abonos - SUM(ABT.Importe) as Diferencia--Ventas.Saldo as SaldoCPC
		from Route.dbo.AbnTrp ABT
		inner join Route.dbo.TransProd FAC on ABT.TransProdID = FAC.TransProdID 
		inner join Route.dbo.Abono ABN on ABT.ABNId = ABN.ABNId 
		inner join Route.dbo.Dia Dia on ABN.DiaClave = Dia.DiaClave
		inner join Route.dbo.Visita VIS on ABN.VisitaClave = VIS.VisitaClave
		inner join Route.dbo.Vendedor VEN on VEN.VendedorID = VIS.VendedorID
		inner join Route.dbo.Usuario USU on USU.USUId = VEN.USUId
		inner join Route.dbo.Cliente CS on CS.ClienteClave = VIS.ClienteClave 
		left outer join RouteCPC.dbo.Ventas on Ventas.Serie = replace(FAC.Folio, Route.dbo.FNObtenerSoloNumeros(FAC.Folio),'')
			and Ventas.Folio = CAST(Route.dbo.FNObtenerSoloNumeros(FAC.Folio) as bigint)
		where Dia.FechaCaptura between '20100101' and '20110131' --and FAC.FOLIO LIKE '%EBE%1083'
		and FAC.Tipo = 8 and FAC.TipoFase <> 0 and (FAC.CFVTipo = 2 or FAC.CFVTipo is null) and FAC.SubEmpresaId = 2
		group by FAC.Folio, Ventas.Abonos, Ventas.Saldo, Ventas.Total
		having  SUM(ABT.Importe) <> Ventas.Abonos and SUM(ABT.Importe) > ventas.Abonos and SUM(ABT.Importe) - ventas.Abonos not between -1 and 1
		order by FAC.Folio

	open AplicaAbonosEnero

	fetch next from AplicaAbonosEnero into @FolioRoute, @Folio, @Serie, @AbonosTerminal, @AbonosCPC, @SaldoVenta
		while @@fetch_status = 0
		begin
	
			set @ImporteAbono = @AbonosTerminal - @AbonosCPC 
			exec up_MovimientosFacturas 1, 2, @Serie, @Folio, @IdMov, '20110130', 0, 'CT', '1', 'A', '', '', @ImporteAbono, 0, 'A', 'SUPER', 1
			
			fetch next from AplicaAbonosEnero into @FolioRoute, @Folio, @Serie, @AbonosTerminal, @AbonosCPC, @SaldoVenta
		end
	close AplicaAbonosEnero

deallocate AplicaAbonosEnero
	
		