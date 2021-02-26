USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[del_EliminaDatosTransferidos]    Script Date: 05/25/2011 07:48:29 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[del_EliminaDatosTransferidos]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[del_EliminaDatosTransferidos]
GO

USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[del_EliminaDatosTransferidos]    Script Date: 05/25/2011 07:48:29 ******/
SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER OFF
GO


CREATE PROCEDURE [dbo].[del_EliminaDatosTransferidos]

@IdCedis as bigint,
@FechaInicial as datetime,
@FechaFinal as datetime

 AS

Begin

	-- Eliminacion por IdSurtido
	delete from SurtidosMerma 
		Where idcedis = @idcedis and IdSurtido in
		(Select IdSurtido 
		from Surtidos 
		where idcedis = @IdCedis 
		and Fecha between @FechaInicial and @FechaFinal)

	delete from SurtidosDevolucion 
		Where idcedis = @idcedis and IdSurtido in
		(Select IdSurtido 
		from Surtidos 
		where idcedis = @IdCedis 
		and Fecha between @FechaInicial and @FechaFinal)
	
	delete from SurtidosVendedor
		Where idcedis = @idcedis and IdSurtido in
		(Select IdSurtido 
		from Surtidos 
		where idcedis = @IdCedis 
		and Fecha between @FechaInicial and @FechaFinal)

	delete from SurtidosCargas 
		Where idcedis = @idcedis and IdSurtido in
		(Select IdSurtido 
		from Surtidos 
		where idcedis = @IdCedis 
		and Fecha between @FechaInicial and @FechaFinal)
	
	delete from SurtidosDetalle
		Where idcedis = @idcedis and IdSurtido in
		(Select IdSurtido 
		from Surtidos 
		where idcedis = @IdCedis 
		and Fecha between @FechaInicial and @FechaFinal)
	
	delete from SurtidosImpuestos 
		Where idcedis = @idcedis and IdSurtido in
		(Select IdSurtido 
		from Surtidos 
		where idcedis = @IdCedis 
		and Fecha between @FechaInicial and @FechaFinal)

	delete from Rejas 
		Where idcedis = @idcedis and IdSurtido in
		(Select IdSurtido 
		from Surtidos 
		where idcedis = @IdCedis 
		and Fecha between @FechaInicial and @FechaFinal)
	
	delete from Ventas
		Where idcedis = @idcedis and IdSurtido in
		(Select IdSurtido 
		from Surtidos 
		where idcedis = @IdCedis 
		and Fecha between @FechaInicial and @FechaFinal)
	
	delete from VentasImpuestos 
		Where idcedis = @idcedis and IdSurtido in
		(Select IdSurtido 
		from Surtidos 
		where idcedis = @IdCedis 
		and Fecha between @FechaInicial and @FechaFinal)

	delete from VentasPromociones 
		Where idcedis = @idcedis and IdSurtido in
		(Select IdSurtido 
		from Surtidos 
		where idcedis = @IdCedis 
		and Fecha between @FechaInicial and @FechaFinal)

	delete from VentasDetalle
		Where idcedis = @idcedis and IdSurtido in
		(Select IdSurtido 
		from Surtidos 
		where idcedis = @IdCedis 
		and Fecha between @FechaInicial and @FechaFinal)

	delete from Cargas 
		Where idcedis = @idcedis and IdSurtido in
		(Select IdSurtido 
		from Surtidos 
		where idcedis = @IdCedis 
		and Fecha between @FechaInicial and @FechaFinal)
	
	delete from RepCreditosCobranza 
		Where idcedis = @idcedis and IdSurtido in
		(Select IdSurtido 
		from Surtidos 
		where idcedis = @IdCedis 
		and Fecha between @FechaInicial and @FechaFinal)
	
	delete from SurtidosCambios 
		Where idcedis = @idcedis and IdSurtido in
		(Select IdSurtido 
		from Surtidos 
		where idcedis = @IdCedis 
		and Fecha between @FechaInicial and @FechaFinal)
	
	delete from SurtidosCheque 
		Where idcedis = @idcedis and IdSurtido in
		(Select IdSurtido 
		from Surtidos 
		where idcedis = @IdCedis 
		and Fecha between @FechaInicial and @FechaFinal)
	
	delete from SurtidosDenominacion
		Where idcedis = @idcedis and IdSurtido in
		(Select IdSurtido 
		from Surtidos 
		where idcedis = @IdCedis 
		and Fecha between @FechaInicial and @FechaFinal)
	
	delete from SurtidosFoliosLiquidacion
		Where idcedis = @idcedis and IdSurtido in
		(Select IdSurtido 
		from Surtidos 
		where idcedis = @IdCedis 
		and Fecha between @FechaInicial and @FechaFinal)
	
	delete from VendedoresSaldos
		Where idcedis = @idcedis and IdSurtido in
		(Select IdSurtido 
		from Surtidos 
		where idcedis = @IdCedis 
		and Fecha between @FechaInicial and @FechaFinal)

	delete from VendedoresSaldosValida 
		Where idcedis = @idcedis and IdSurtido in
		(Select IdSurtido 
		from Surtidos 
		where idcedis = @IdCedis 
		and Fecha between @FechaInicial and @FechaFinal)
	
	delete from VentasAcredita
		Where idcedis = @idcedis and IdSurtido in
		(Select IdSurtido 
		from Surtidos 
		where idcedis = @IdCedis 
		and Fecha between @FechaInicial and @FechaFinal)
	
	delete from VentasCanceladas
		Where idcedis = @idcedis and IdSurtido in
		(Select IdSurtido 
		from Surtidos 
		where idcedis = @IdCedis 
		and Fecha between @FechaInicial and @FechaFinal)
	
	delete from VentasFacturadas
		Where idcedis = @idcedis and IdSurtido in
		(Select IdSurtido 
		from Surtidos 
		where idcedis = @IdCedis 
		and Fecha between @FechaInicial and @FechaFinal)

	delete from VentasDevolucion 
		Where IdCedisD = @idcedis and IdSurtido in
		(Select IdSurtido 
		from Surtidos 
		where idcedis = @IdCedis 
		and Fecha between @FechaInicial and @FechaFinal)
	
	--Eliminacion por Fecha	
	delete from VentasContado
		Where idcedis = @idcedis 
		and Fecha between @FechaInicial and @FechaFinal
	
	delete from StatusRutas
		Where idcedis = @idcedis 
		and Fecha between @FechaInicial and @FechaFinal
	
	delete from StatusDia
		Where idcedis = @idcedis 
		and Fecha between @FechaInicial and @FechaFinal
	
	delete from InventarioKardex 
		Where idcedis = @idcedis 
		and Fecha between @FechaInicial and @FechaFinal
	
	delete from MovimientosDetalle
		Where idcedis = @idcedis and IdMovimiento in
		(Select IdMovimiento 
		from Movimientos 
		where idcedis = @IdCedis 
		and Fecha between @FechaInicial and @FechaFinal)
	
	delete from Movimientos
		Where idcedis = @idcedis 
		and Fecha between @FechaInicial and @FechaFinal

	delete from RepModeloOrienteEnvase
		Where idcedis = @idcedis 
		and Fecha between @FechaInicial and @FechaFinal

	delete from RepModeloOrienteES
		Where idcedis = @idcedis 
		and Fecha between @FechaInicial and @FechaFinal

	delete from VendedoresCargosAbonos
		Where idcedis = @idcedis 
		and Fecha between @FechaInicial and @FechaFinal

	delete from CargasSugeridas
		Where idcedis = @idcedis 
		and FechaCarga between @FechaInicial and @FechaFinal

	delete from CargasSugeridasDetalle
		Where idcedis = @idcedis 
		and FechaCarga between @FechaInicial and @FechaFinal

	delete from CargasSugeridasFamilia
		Where idcedis = @idcedis 
		and FechaCarga between @FechaInicial and @FechaFinal

	delete from CargasSugeridasProducto
		Where idcedis = @idcedis 
		and FechaCarga between @FechaInicial and @FechaFinal

	delete from CargasSugeridasRuta
		Where idcedis = @idcedis 
		and FechaCarga between @FechaInicial and @FechaFinal

	delete from VendedoresSaldosFinanciaD
		Where IdCedis = @IdCedis and IdCorto in 
			(Select IdCorto from VendedoresSaldosFinancia Where IdCedis = @IdCedis and Fecha between @FechaInicial and @FechaFinal ) 

	delete from VendedoresSaldosFinancia
		Where IdCedis = @IdCedis and Fecha between @FechaInicial and @FechaFinal

	--Eliminacion en Tablas de Control o Principales
	delete from Surtidos
		Where idcedis = @idcedis 
		and Fecha between @FechaInicial and @FechaFinal
	
	delete from InventarioFisico
		Where idcedis = @idcedis 
		and Fecha between @FechaInicial and @FechaFinal

End

GO


