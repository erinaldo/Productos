USE [RouteCPC]
GO

/****** Object:  UserDefinedFunction [dbo].[FN_SaldosPorFechaG]    Script Date: 04/06/2011 00:33:34 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FN_SaldosPorFechaG]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[FN_SaldosPorFechaG]
GO

USE [RouteCPC]
GO

/****** Object:  UserDefinedFunction [dbo].[FN_SaldosPorFechaG]    Script Date: 04/06/2011 00:33:34 ******/
SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER OFF
GO

CREATE FUNCTION [dbo].[FN_SaldosPorFechaG]
(
	@FechaInicial as Datetime, 
	@FechaFinal as Datetime
)  


RETURNS Table 

AS  

	Return
	(
			select Ventas.IdCedis, Ventas.IdTipoVenta, Ventas.Serie, Ventas.Folio, Ventas.Fecha, Ventas.Fecha + Ventas.DiasVencimiento as FechaVencimiento, Ventas.IdCliente, 
			
			isnull( (select sum(Vtas.Total) from Ventas as Vtas where Vtas.IdCedis = Ventas.IdCedis and Vtas.IdTipoVenta = Ventas.IdTipoVenta and 
			Vtas.Serie = Ventas.Serie and Vtas.Folio = Ventas.Folio and Vtas.Fecha < @FechaInicial ), 0)  +
			isnull(( select sum(MC.Total) from MovimientosFacturas as MC where MC.IdCedis = Ventas.IdCedis and MC.IdTipoVenta = Ventas.IdTipoVenta and 
			MC.Serie = Ventas.Serie and MC.Folio = Ventas.Folio and MC.Status <> 'B' and MC.CargoAbono = 'C' and MC.Fecha < @FechaInicial ), 0) -
			isnull(( select sum(MA.Total) from MovimientosFacturas as MA where MA.IdCedis = Ventas.IdCedis and MA.IdTipoVenta = Ventas.IdTipoVenta and 
			MA.Serie = Ventas.Serie and MA.Folio = Ventas.Folio and MA.Status <> 'B' and MA.CargoAbono = 'A' and MA.Fecha < @FechaInicial ), 0) as SaldoInicial, 
			
			isnull( (select sum(Vtas.Total) from Ventas as Vtas where Vtas.IdCedis = Ventas.IdCedis and Vtas.IdTipoVenta = Ventas.IdTipoVenta and 
			Vtas.Serie = Ventas.Serie and Vtas.Folio = Ventas.Folio and Vtas.Fecha between @FechaInicial and  @FechaFinal), 0) as Monto, 
			isnull(( select sum(MC.Total) from MovimientosFacturas as MC where MC.IdCedis = Ventas.IdCedis and MC.IdTipoVenta = Ventas.IdTipoVenta and 
			MC.Serie = Ventas.Serie and MC.Folio = Ventas.Folio and MC.Status <> 'B' and MC.CargoAbono = 'C' and MC.Fecha between @FechaInicial and  @FechaFinal ), 0) as Cargos, 
			isnull(( select sum(MA.Total) from MovimientosFacturas as MA where MA.IdCedis = Ventas.IdCedis and MA.IdTipoVenta = Ventas.IdTipoVenta and 
			MA.Serie = Ventas.Serie and MA.Folio = Ventas.Folio and MA.Status <> 'B' and MA.CargoAbono = 'A' and MA.Fecha between @FechaInicial and  @FechaFinal ), 0) as Abonos,
			
			( isnull( (select sum(Vtas.Total) from Ventas as Vtas where Vtas.IdCedis = Ventas.IdCedis and Vtas.IdTipoVenta = Ventas.IdTipoVenta and 
			Vtas.Serie = Ventas.Serie and Vtas.Folio = Ventas.Folio and Vtas.Fecha < @FechaInicial ), 0)  +
			isnull(( select sum(MC.Total) from MovimientosFacturas as MC where MC.IdCedis = Ventas.IdCedis and MC.IdTipoVenta = Ventas.IdTipoVenta and 
			MC.Serie = Ventas.Serie and MC.Folio = Ventas.Folio and MC.Status <> 'B' and MC.CargoAbono = 'C' and MC.Fecha < @FechaInicial ), 0) -
			isnull(( select sum(MA.Total) from MovimientosFacturas as MA where MA.IdCedis = Ventas.IdCedis and MA.IdTipoVenta = Ventas.IdTipoVenta and 
			MA.Serie = Ventas.Serie and MA.Folio = Ventas.Folio and MA.Status <> 'B' and MA.CargoAbono = 'A' and MA.Fecha < @FechaInicial ), 0) ) +
			
			( isnull( (select sum(Vtas.Total) from Ventas as Vtas where Vtas.IdCedis = Ventas.IdCedis and Vtas.IdTipoVenta = Ventas.IdTipoVenta and 
			Vtas.Serie = Ventas.Serie and Vtas.Folio = Ventas.Folio and Vtas.Fecha between @FechaInicial and  @FechaFinal), 0) +
			isnull(( select sum(MC.Total) from MovimientosFacturas as MC where MC.IdCedis = Ventas.IdCedis and MC.IdTipoVenta = Ventas.IdTipoVenta and 
			MC.Serie = Ventas.Serie and MC.Folio = Ventas.Folio and MC.Status <> 'B' and MC.CargoAbono = 'C' and MC.Fecha between @FechaInicial and  @FechaFinal ), 0) -
			isnull(( select sum(MA.Total) from MovimientosFacturas as MA where MA.IdCedis = Ventas.IdCedis and MA.IdTipoVenta = Ventas.IdTipoVenta and 
			MA.Serie = Ventas.Serie and MA.Folio = Ventas.Folio and MA.Status <> 'B' and MA.CargoAbono = 'A' and MA.Fecha between @FechaInicial and  @FechaFinal ), 0) ) as Saldo
			
			
			from Ventas 
			
			where Ventas.Fecha <= @FechaFinal -- and Ventas.IdCedis = @IdCedis -- and Ventas.Fecha < @FechaInicial	
			group by Ventas.IdCedis, Ventas.IdTipoVenta, Ventas.Serie, Ventas.Folio, Ventas.Fecha, Ventas.DiasVencimiento, Ventas.IdCliente

/*
		select Ventas.IdCedis, Ventas.IdTipoVenta, Ventas.Serie, Ventas.Folio, Ventas.Fecha, Ventas.Fecha + Ventas.DiasVencimiento as FechaVencimiento, Ventas.IdCliente, 
		
		isnull( (select sum(Vtas.Total) from Ventas as Vtas where Vtas.IdCedis = Ventas.IdCedis and Vtas.IdTipoVenta = Ventas.IdTipoVenta and 
		Vtas.Serie = Ventas.Serie and Vtas.Folio = Ventas.Folio and Vtas.Fecha between @FechaInicial and  @FechaFinal), 0) as Monto, 

		-- isnull(sum(MC1.Total), 0) as Cargos1, isnull(sum(MA1.Total), 0) as Abonos1, 
		
		isnull(sum(MC.Total), 0) as Cargos, isnull(sum(MA.Total), 0) as Abonos, 
		
		isnull( (select sum(Vtas.Total) from Ventas as Vtas where Vtas.IdCedis = Ventas.IdCedis and Vtas.IdTipoVenta = Ventas.IdTipoVenta and 
		Vtas.Serie = Ventas.Serie and Vtas.Folio = Ventas.Folio and Vtas.Fecha between @FechaInicial and  @FechaFinal), 0) + isnull(sum(MC.Total), 0) - isnull(sum(MA.Total), 0)  as Saldo
		
		from Ventas 	
	
		left outer join MovimientosFacturas as MC on MC.IdCedis = Ventas.IdCedis and MC.IdTipoVenta = Ventas.IdTipoVenta and 
		MC.Serie = Ventas.Serie and MC.Folio = Ventas.Folio and MC.Status <> 'B' and MC.CargoAbono = 'C' and MC.Fecha between @FechaInicial and  @FechaFinal		
		left outer join MovimientosFacturas as MA on MA.IdCedis = Ventas.IdCedis and MA.IdTipoVenta = Ventas.IdTipoVenta and 
		MA.Serie = Ventas.Serie and MA.Folio = Ventas.Folio and MA.Status <> 'B' and MA.CargoAbono = 'A' and MA.Fecha between @FechaInicial and  @FechaFinal

		where Ventas.Fecha <= @FechaFinal and Ventas.IdCedis = @IdCedis -- and Ventas.Fecha < @FechaInicial			
		group by Ventas.IdCedis, Ventas.IdTipoVenta, Ventas.Serie, Ventas.Folio, Ventas.Fecha, Ventas.DiasVencimiento, Ventas.IdCliente
		-- having isnull( sum(Ventas.Total),0) + isnull(sum(MC.Total), 0) - isnull(sum(MA.Total), 0) <> 0
*/
	)

GO


