USE [RouteCPC]
GO

/****** Object:  UserDefinedFunction [dbo].[FN_VencimientoAlaFechaG]    Script Date: 04/06/2011 00:13:12 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FN_VencimientoAlaFechaG]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[FN_VencimientoAlaFechaG]
GO

USE [RouteCPC]
GO

/****** Object:  UserDefinedFunction [dbo].[FN_VencimientoAlaFechaG]    Script Date: 04/06/2011 00:13:12 ******/
SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER OFF
GO

CREATE FUNCTION [dbo].[FN_VencimientoAlaFechaG]
(
	@FechaFinal as Datetime
)  
RETURNS Table 

AS  

	Return
	(

		select Ventas.IdCedis, Ventas.IdTipoVenta, Ventas.Serie, Ventas.Folio, Ventas.Fecha, Ventas.Fecha + Ventas.DiasVencimiento as FechaVencimiento, Ventas.IdCliente,
		isnull( sum(Ventas.Total), 0) as Monto, 
		isnull( (select sum(MC.Total) from MovimientosFacturas as MC where MC.IdCedis = Ventas.IdCedis and MC.IdTipoVenta = Ventas.IdTipoVenta and 
		MC.Serie = Ventas.Serie and MC.Folio = Ventas.Folio and MC.Status <> 'B' and MC.CargoAbono = 'C' and MC.Fecha <= @FechaFinal ) , 0) as Cargos, 
		isnull( (select sum(MA.Total) from MovimientosFacturas as MA where MA.IdCedis = Ventas.IdCedis and MA.IdTipoVenta = Ventas.IdTipoVenta and 
		MA.Serie = Ventas.Serie and MA.Folio = Ventas.Folio and MA.Status <> 'B' and MA.CargoAbono = 'A' and MA.Fecha <= @FechaFinal ) , 0) as Abonos,
		isnull( sum(Ventas.Total), 0) + 
		isnull( (select sum(MC.Total) from MovimientosFacturas as MC where MC.IdCedis = Ventas.IdCedis and MC.IdTipoVenta = Ventas.IdTipoVenta and 
		MC.Serie = Ventas.Serie and MC.Folio = Ventas.Folio and MC.Status <> 'B' and MC.CargoAbono = 'C' and MC.Fecha <= @FechaFinal ) , 0) -
		isnull( (select sum(MA.Total) from MovimientosFacturas as MA where MA.IdCedis = Ventas.IdCedis and MA.IdTipoVenta = Ventas.IdTipoVenta and 
		MA.Serie = Ventas.Serie and MA.Folio = Ventas.Folio and MA.Status <> 'B' and MA.CargoAbono = 'A' and MA.Fecha <= @FechaFinal ) , 0) as Saldo,
		
		datediff(day, Ventas.Fecha + Ventas.DiasVencimiento, @FechaFinal ) as DiasVencidos
		
		from Ventas 
		where Ventas.Fecha <= @FechaFinal -- and Ventas.IdCedis = @IdCedis
		group by Ventas.IdCedis, Ventas.IdTipoVenta, Ventas.Serie, Ventas.Folio, Ventas.Fecha, Ventas.DiasVencimiento, Ventas.IdCliente
		having isnull( sum(Ventas.Total), 0) + 
			isnull( (select sum(MC.Total) from MovimientosFacturas as MC where MC.IdCedis = Ventas.IdCedis and MC.IdTipoVenta = Ventas.IdTipoVenta and 
			MC.Serie = Ventas.Serie and MC.Folio = Ventas.Folio and MC.Status <> 'B' and MC.CargoAbono = 'C' and MC.Fecha <= @FechaFinal ) , 0) -
			isnull( (select sum(MA.Total) from MovimientosFacturas as MA where MA.IdCedis = Ventas.IdCedis and MA.IdTipoVenta = Ventas.IdTipoVenta and 
			MA.Serie = Ventas.Serie and MA.Folio = Ventas.Folio and MA.Status <> 'B' and MA.CargoAbono = 'A' and MA.Fecha <= @FechaFinal ) , 0) <> 0
	)

GO


