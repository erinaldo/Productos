USE [RouteADM]
GO

/****** Object:  UserDefinedFunction [dbo].[FN_ComisionesDetalleFecha]    Script Date: 12/20/2010 11:09:51 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FN_ComisionesDetalleFecha]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[FN_ComisionesDetalleFecha]
GO

USE [RouteADM]
GO

/****** Object:  UserDefinedFunction [dbo].[FN_ComisionesDetalleFecha]    Script Date: 12/20/2010 11:09:51 ******/
SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE FUNCTION [dbo].[FN_ComisionesDetalleFecha]
(
	@IdCedis as bigint,
	@FechaInicial as datetime,
	@FechaFinal as datetime
)  
RETURNS Table 

AS  
		
	Return
	(
		select Vendedores.IdVendedor, Vendedores.Nomina, ApPaterno + ' ' + ApMaterno + ' ' + Nombre as Vendedor,
		FN_ComisionesEsquemaFecha.IdSurtido, FN_ComisionesEsquemaFecha.IdTipoVendedor, 
		FN_ComisionesEsquemaFecha.TipoVendedor, SUM(FN_ComisionesEsquemaFecha.Pago) as Pago, FN_ComisionesEsquemaFecha.Fecha,
		SUM(FN_ComisionesEsquemaFecha.AbonoMerma) as AbonoMerma, SUM(FN_ComisionesEsquemaFecha.AbonoVolumen) as AbonoVolumen,
		ISNULL((select sum(Cantidad * Precio) 
			from SurtidosMerma 
			inner join SurtidosDetalle on SurtidosMerma.IdCedis = SurtidosDetalle.IdCedis and SurtidosMerma.IdSurtido = SurtidosDetalle.IdSurtido 
				and SurtidosMerma.IdProducto = SurtidosDetalle.IdProducto 
			inner join TipoMerma on SurtidosMerma.IdTipoMerma = TipoMerma.IdTipoMerma and Imputable = 'V'
			where SurtidosMerma.IdCedis = FN_ComisionesEsquemaFecha.IdCedis and SurtidosMerma.IdSurtido = FN_ComisionesEsquemaFecha.IdSurtido),0) as CargoMerma,
		sum(FN_ComisionesEsquemaFecha.VentaTotal) as VentaTotal			
		from FN_ComisionesEsquemaFecha(@IdCedis, @FechaInicial, @FechaFinal) 
		inner join FN_ComisionesEsquema(@IdCedis) on FN_ComisionesEsquema.IdComEsquema = FN_ComisionesEsquemaFecha.IdComEsquema and FN_ComisionesEsquema.IdConceptoPago = FN_ComisionesEsquemaFecha.IdConceptoPago
			and FN_ComisionesEsquema.IdTipoRuta = FN_ComisionesEsquemaFecha.TipoRuta and FN_ComisionesEsquema.IdTipoVendedor = FN_ComisionesEsquemaFecha.IdTipoVendedor
			and FN_ComisionesEsquema.IdProducto = FN_ComisionesEsquemaFecha.IdProducto 
		inner join SurtidosVendedor on FN_ComisionesEsquemaFecha.IdCedis = SurtidosVendedor.IdCedis and FN_ComisionesEsquemaFecha.IdSurtido = SurtidosVendedor.IdSurtido 
			and FN_ComisionesEsquemaFecha.IdTipoVendedor = SurtidosVendedor.IdTipoVendedor
		inner join Vendedores on Vendedores.IdCedis = SurtidosVendedor.IdCedis and Vendedores.IdVendedor = SurtidosVendedor.IdVendedor 
		group by FN_ComisionesEsquemaFecha.IdCedis, Vendedores.IdVendedor, Vendedores.Nomina, ApPaterno, ApMaterno, Nombre,
		FN_ComisionesEsquemaFecha.TipoVendedor, FN_ComisionesEsquemaFecha.IdSurtido, FN_ComisionesEsquemaFecha.IdTipoVendedor, FN_ComisionesEsquemaFecha.Fecha
		
	)


GO


