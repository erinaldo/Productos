USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[up_TransferenciaContenedor]    Script Date: 05/11/2011 19:42:00 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[up_TransferenciaContenedor]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[up_TransferenciaContenedor]
GO

USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[up_TransferenciaContenedor]    Script Date: 05/11/2011 19:42:00 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO





CREATE PROCEDURE [dbo].[up_TransferenciaContenedor]
AS

	declare @IdCedis as int, @IdSurtido as bigint, @IdTipoVenta as int, @Folio as bigint
	declare @FechaInicial as datetime, @FechaFinal as datetime

	declare BORRATRANSFERENCIA cursor for
	-- BORRA DATOS
	select IdCedis, Fecha 
	from VWDetalleDiasATransferir2 
	Where Totalsurtidos = SurtidosTerminados and SurtidosNoTransferidos > 0
	open BORRATRANSFERENCIA
	fetch next from BORRATRANSFERENCIA
	into @IdCedis, @FechaInicial
	while @@fetch_status = 0
	begin
		exec [Contenedor].[RouteADM].DBO.del_EliminaDatosTransferidos @IdCedis, @FechaInicial, @FechaInicial
		
		Update Surtidos set StatusTransferido = 'N'
		where IdCedis = @IdCedis and Fecha = @FechaInicial 

		Update InventarioFisico set StatusTransferido = 'N'
		where IdCedis = @IdCedis and Fecha = @FechaInicial 

		fetch next from BORRATRANSFERENCIA into @IdCedis, @FechaInicial
	end
	close BORRATRANSFERENCIA
	deallocate BORRATRANSFERENCIA

	-- INVENTARIO INICIAL
	delete From [Contenedor].[RouteADM].DBO.InventarioInicial where CAST(IdCedis AS varchar(2)) + CAST(Agno AS varchar(4)) + REPLICATE('0', 2 - LEN(CAST(Mes AS varchar(2)))) + CAST(Mes AS varchar(2)) in 
	(SELECT CAST(IdCedis AS varchar(2)) + AgnoMes 
	FROM VWInventarioInicialATransferir Where TotalProductos = ProductosAplicados and TotalProductos = ProductosNotransferidos and ProductosNotransferidos>0 )

	Insert Into [Contenedor].[RouteADM].DBO.InventarioInicial
	Select [IDCedis],[Agno],[Mes],[IdProducto],[Cantidad],[Status],'T' as StatusTransferido 
	From InventarioInicial where CAST(Agno AS varchar(4)) + REPLICATE('0', 2 - LEN(CAST(Mes AS varchar(2)))) + CAST(Mes AS varchar(2)) in 
	(SELECT AgnoMes FROM VWInventarioInicialATransferir Where TotalProductos = ProductosAplicados and TotalProductos = ProductosNotransferidos and ProductosNotransferidos>0 )

	-- TABLAS DE OPERACIÓN
	set @IdCedis = (Select top 1 IdCedis from Cedis)
	declare TRANSFERENCIA cursor for
	SELECT @IdCedis, Fecha 
	FROM VWDetalleDiasATransferir2 Where Totalsurtidos = SurtidosTerminados and TotalSurtidos = SurtidosNoTransferidos and 
	TotalProductos = ProductosAplicados and TotalProductos = ProductosNotransferidos
	open TRANSFERENCIA
	fetch next from TRANSFERENCIA
	into @IdCedis, @FechaInicial
	while @@fetch_status = 0
	begin

		Insert Into [Contenedor].[RouteADM].DBO.Surtidos
		Select [IDCedis],[IdSurtido],[Fecha],[IdRuta],[Status],'T' as StatusTransferido 
		From surtidos where IdCedis = @IdCedis and Fecha = @FechaInicial 
		
		Insert Into [Contenedor].[RouteADM].DBO.InventarioFisico
		Select [IdCedis],[Fecha],[IdProducto],[Cantidad],[Status],'T' as StatusTransferido, [Captura],[DevBuena] 
		From InventarioFisico where IdCedis = @IdCedis and Fecha = @FechaInicial 

		Insert Into [Contenedor].[RouteADM].DBO.Cargas
		Select [IdCedis],[IdSurtido],[IdCarga],[IdRuta],[Fecha],[Status]
		From Cargas where IdCedis = @IdCedis and IdSurtido in (SELECT SUR.IdSurtido FROM Surtidos SUR WHERE SUR.IdCedis = @IdCedis and SUR.Fecha = @FechaInicial ) 

		Insert Into [Contenedor].[RouteADM].DBO.SurtidosMerma
		Select [IdCedis],[IdSurtido],[IdTipoMerma],[IdProducto],[Cantidad]
		From SurtidosMerma where IdCedis = @IdCedis and IdSurtido in (SELECT SUR.IdSurtido FROM Surtidos SUR WHERE SUR.IdCedis = @IdCedis and SUR.Fecha = @FechaInicial )

		Insert Into [Contenedor].[RouteADM].DBO.SurtidosDevolucion
		Select [IdCedis],[IdSurtido],[IdTipoDevolucion],[IdProducto],[Cantidad]
		From SurtidosDevolucion where IdCedis = @IdCedis and IdSurtido in (SELECT SUR.IdSurtido FROM Surtidos SUR WHERE SUR.IdCedis = @IdCedis and SUR.Fecha = @FechaInicial )

		Insert Into [Contenedor].[RouteADM].DBO.VendedoresSaldosValida
		Select [IdCedis],[IdSurtido],[IdTipoSaldo],[IdVendedor],[Fecha],[Saldo],[Financiado],[SaldoVencido],[Creditos],[Bolsa],[Ajuste],[Resultado],[Observaciones],[Login]
		From VendedoresSaldosValida where IdCedis = @IdCedis and IdSurtido in ( select IdSurtido from Surtidos where IdCedis = @IdCedis and Fecha = @FechaInicial)

		Insert Into [Contenedor].[RouteADM].DBO.VentasDevolucion
		Select [IdCedisD],[IdSurtidoD],[IdTipoVentaD],[FolioD],[SerieD],[IdSurtido],[IdTipoVenta],[Folio],[Serie],[IdCliente],[IdSucursal],[Tipo]
		From VentasDevolucion where IdCedisD = @IdCedis and IdSurtido in (SELECT SUR.IdSurtido FROM Surtidos SUR WHERE SUR.IdCedis = @IdCedis and SUR.Fecha = @FechaInicial )
		
		Insert Into [Contenedor].[RouteADM].DBO.SurtidosVendedor
		Select [IdCedis],[IdSurtido],[Fecha],[IdVendedor],[IdTipoVendedor]
		From SurtidosVendedor where IdCedis = @IdCedis and IdSurtido in (SELECT SUR.IdSurtido FROM Surtidos SUR WHERE SUR.IdCedis = @IdCedis and SUR.Fecha = @FechaInicial )

		Insert Into [Contenedor].[RouteADM].DBO.SurtidosDetalle
		([IdCedis],[IdSurtido],[IdProducto],[Fecha],[Surtido],[DevBuena],[DevMala],[Obsequios],[VentaContado],[VentaCredito],[Precio],[Iva])
		Select [IdCedis],[IdSurtido],[IdProducto],[Fecha],[Surtido],[DevBuena],[DevMala],[Obsequios],[VentaContado],[VentaCredito],[Precio],[Iva]
		From SurtidosDetalle where IdCedis = @IdCedis and IdSurtido in (SELECT SUR.IdSurtido FROM Surtidos SUR WHERE SUR.IdCedis = @IdCedis and SUR.Fecha = @FechaInicial )

		Insert Into [Contenedor].[RouteADM].DBO.SurtidosCargas
		Select [IdCedis],[IdSurtido],[IdCarga],[IdProducto],[Cantidad]
		From SurtidosCargas where IdCedis = @IdCedis and IdSurtido in (SELECT SUR.IdSurtido FROM Surtidos SUR WHERE SUR.IdCedis = @IdCedis and SUR.Fecha = @FechaInicial )

		Insert Into [Contenedor].[RouteADM].DBO.Rejas
		Select [IdCedis],[IdSurtido],[IdCarga],[IdProducto],[Fecha],[IdRuta],[Surtido],[Devolucion]
		From Rejas where IdCedis = @IdCedis and IdSurtido in (SELECT SUR.IdSurtido FROM Surtidos SUR WHERE SUR.IdCedis = @IdCedis and SUR.Fecha = @FechaInicial )

		Insert Into [Contenedor].[RouteADM].DBO.Ventas
		([IdCedis],[IdSurtido],[IdTipoVenta],[Folio],[Serie],[Fecha],[IdCliente],[Subtotal],[Iva],[IdSucursal],[DctoImp],[DiasCredito])
		Select [IdCedis],[IdSurtido],[IdTipoVenta],[Folio],[Serie],[Fecha],[IdCliente],[Subtotal],[Iva],[IdSucursal],[DctoImp],[DiasCredito]
		From Ventas where IdCedis = @IdCedis and IdSurtido in (SELECT SUR.IdSurtido FROM Surtidos SUR WHERE SUR.IdCedis = @IdCedis and SUR.Fecha = @FechaInicial )

		Insert Into [Contenedor].[RouteADM].DBO.VentasDetalle
		([IdCedis],[IdSurtido],[IdTipoVenta],[Folio],[IdProducto],[Serie],[Cantidad],[Precio],[Iva],[DctoPorc],[DctoImp],[Entregado])
		Select [IdCedis],[IdSurtido],[IdTipoVenta],[Folio],[IdProducto],[Serie],[Cantidad],[Precio],[Iva],[DctoPorc],[DctoImp],[Entregado]
		From VentasDetalle where IdCedis = @IdCedis and IdSurtido in (SELECT SUR.IdSurtido FROM Surtidos SUR WHERE SUR.IdCedis = @IdCedis and SUR.Fecha = @FechaInicial )

		Insert Into [Contenedor].[RouteADM].dbo.RepCreditosCobranza ([IdCedis],[IdSurtido],[Orden],[Concepto],[IdMarca],[Marca],[NombreSucursal],[Folio],[Total])
		Select [IdCedis],[IdSurtido],[Orden],[Concepto],[IdMarca],[Marca],[NombreSucursal],[Folio],[Total]
		From RepCreditosCobranza
		where IdCedis = @IdCedis and IdSurtido in (SELECT SUR.IdSurtido FROM Surtidos SUR WHERE SUR.IdCedis = @IdCedis and SUR.Fecha = @FechaInicial )

		Insert Into [Contenedor].[RouteADM].dbo.SurtidosCambios
		Select [IdCedis],[IdSurtido],[IdFecha],[IdProducto],[Entrada],[Salida]
		From SurtidosCambios where IdCedis = @IdCedis and IdSurtido in (SELECT SUR.IdSurtido FROM Surtidos SUR WHERE SUR.IdCedis = @IdCedis and SUR.Fecha = @FechaInicial )

		Insert Into [Contenedor].[RouteADM].dbo.SurtidosCheque
		Select [IdCedis],[IdSurtido],[Folio],[IdCheque],[IdCajero],[IdMoneda],[IdBanco],[Referencia],[Importe]
		From SurtidosCheque where IdCedis = @IdCedis and IdSurtido in (SELECT SUR.IdSurtido FROM Surtidos SUR WHERE SUR.IdCedis = @IdCedis and SUR.Fecha = @FechaInicial )

		Insert Into [Contenedor].[RouteADM].dbo.SurtidosDenominacion
		Select [IdCedis],[IdSurtido],[Folio],[IdCajero],[IdMoneda],[IdDenominacion],[TipoDenominacion],[Cantidad]
		From SurtidosDenominacion where IdCedis = @IdCedis and IdSurtido in (SELECT SUR.IdSurtido FROM Surtidos SUR WHERE SUR.IdCedis = @IdCedis and SUR.Fecha = @FechaInicial )

		Insert Into [Contenedor].[RouteADM].dbo.SurtidosFoliosLiquidacion
		Select [IdCedis],[IdSurtido],[Folio],[IdCajero],[Status]
		From SurtidosFoliosLiquidacion where IdCedis = @IdCedis and IdSurtido in (SELECT SUR.IdSurtido FROM Surtidos SUR WHERE SUR.IdCedis = @IdCedis and SUR.Fecha = @FechaInicial )

		Insert Into [Contenedor].[RouteADM].dbo.VendedoresSaldos
		Select [IdCedis],[IdSurtido],[IdRuta],[IdTipoSaldo],[IdVendedor],[Fecha],[SaldoAnterior],[Saldo],[Otros],[SaldoActual]
		From VendedoresSaldos where IdCedis = @IdCedis and IdSurtido in (SELECT SUR.IdSurtido FROM Surtidos SUR WHERE SUR.IdCedis = @IdCedis and SUR.Fecha = @FechaInicial )

		Insert Into [Contenedor].[RouteADM].dbo.VentasAcredita
		Select [IdCedis],[IdSurtido],[IdTipoVenta],[Folio],[Serie],[Fecha],[FechaAcredita],[Login],[FechaEntrega],[FolioEntrega],[Observaciones],[FolioCliente],[Remision],[Factura],[Status],[Vencimiento]
		From VentasAcredita where IdCedis = @IdCedis and IdSurtido in (SELECT SUR.IdSurtido FROM Surtidos SUR WHERE SUR.IdCedis = @IdCedis and SUR.Fecha = @FechaInicial )

		Insert Into [Contenedor].[RouteADM].dbo.VentasCanceladas
		([IdCedis],[IdSurtido],[IdTipoVenta],[Folio],[Serie],[Fecha],[IdCliente],[Subtotal],[Iva],[IdSucursal],[DctoImp],[DiasCredito])
		Select [IdCedis],[IdSurtido],[IdTipoVenta],[Folio],[Serie],[Fecha],[IdCliente],[Subtotal],[Iva],[IdSucursal],[DctoImp],[DiasCredito]
		From VentasCanceladas where IdCedis = @IdCedis and IdSurtido in (SELECT SUR.IdSurtido FROM Surtidos SUR WHERE SUR.IdCedis = @IdCedis and SUR.Fecha = @FechaInicial )

		Insert Into [Contenedor].[RouteADM].dbo.VentasFacturadas
		Select [IdCedis],[IdSurtido],[IdTipoVenta],[Folio],[Serie],[Facturada],[Fecha],[FolioImpresion]
		From VentasFacturadas where IdCedis = @IdCedis and IdSurtido in (SELECT SUR.IdSurtido FROM Surtidos SUR WHERE SUR.IdCedis = @IdCedis and SUR.Fecha = @FechaInicial )

		Insert Into [Contenedor].[RouteADM].DBO.VentasContado
		Select [IdCedis],[Fecha],[Folio],[Serie],[Status],[IdMarca]
		From VentasContado where IdCedis = @IdCedis and Fecha = @FechaInicial 

		Insert Into [Contenedor].[RouteADM].DBO.StatusRutas
		Select [IdCedis],[Fecha],[IdRuta],[Status],[StatusDesc]
		From StatusRutas where IdCedis = @IdCedis and Fecha = @FechaInicial 

		Insert Into [Contenedor].[RouteADM].DBO.StatusDia
		Select [IdCedis],[Fecha],[Status],[StatusDesc]
		From StatusDia where IdCedis = @IdCedis and Fecha = @FechaInicial 

		Insert Into [Contenedor].[RouteADM].DBO.InventarioKardex
		([IdCedis],[Fecha],[IdProducto],[Inicial],[Entradas],[Salidas],[Surtido],[DevBuena],[DevMala],[Obsequios],[VentaContado],[VentaCredito],[Fisico])
		Select [IdCedis],[Fecha],[IdProducto],[Inicial],[Entradas],[Salidas],[Surtido],[DevBuena],[DevMala],[Obsequios],[VentaContado],[VentaCredito],[Fisico]
		From InventarioKardex where IdCedis = @IdCedis and Fecha = @FechaInicial 

		Insert Into [Contenedor].[RouteADM].DBO.Movimientos
		Select [IdCedis],[IdMovimiento],[Fecha],[IdTipoMovimiento],[Observaciones],[Folio],[Status]
		From Movimientos where IdCedis = @IdCedis and Fecha = @FechaInicial 

		Insert Into [Contenedor].[RouteADM].DBO.MovimientosDetalle
		Select [IdCedis],[IdMovimiento],[IdProducto],[Cantidad],[Observaciones]
		From MovimientosDetalle where IdCedis = @IdCedis and IdMovimiento in (SELECT MOV.IdMovimiento FROM Movimientos MOV 
		WHERE MOV.IdCedis = @IdCedis and MOV.Fecha = @FechaInicial)

		Insert Into [Contenedor].[RouteADM].DBO.RepModeloOrienteEnvase
		Select [Id],[IdCedis],[Fecha],[IdAgrupador],[IdRuta],[Titulo],[Concepto],[IdProd30],[IdProd31],[IdProd32],[IdProd33],[IdProd34],[IdProd35],[IdProd36]
		From RepModeloOrienteEnvase where IdCedis = @IdCedis and Fecha = @FechaInicial 

		Insert Into [Contenedor].[RouteADM].DBO.RepModeloOrienteES
		Select [Id],[IdCedis],[Fecha],[IdAgrupador],[IdRuta],[Titulo],[Concepto],[IdProd1],[IdProd2],[IdProd3],[IdProd4],[IdProd5],[IdProd6],[IdProd7],[IdProd8],[IdProd9],[IdProd10],[IdProd11],[IdProd12],[IdProd13],[IdProd14],[IdProd15]
		,[IdProd16],[IdProd17],[IdProd18],[IdProd19],[IdProd20],[IdProd21],[IdProd22],[IdProd23],[IdProd24],[IdProd25],[IdProd26],[IdProd27],[IdProd28],[IdProd30],[IdProd31],[IdProd32],[IdProd33],[IdProd34],[IdProd35],[IdProd36]
		From RepModeloOrienteES where IdCedis = @IdCedis and Fecha = @FechaInicial 

		Insert Into [Contenedor].[RouteADM].DBO.VendedoresCargosAbonos
		Select [IdCedis],[IdCargoAbono],[IdTipoSaldo],[IdVendedor],[Fecha],[Importe],[Observaciones],[IdSurtido] 
		From VendedoresCargosAbonos where IdCedis = @IdCedis and Fecha = @FechaInicial 

		Insert Into [Contenedor].[RouteADM].dbo.CargasSugeridas
		Select [IdCedis],[IdRuta],[FechaCarga],[Tipo],[Folio],[IdSurtido],[IdCarga],[Status]
		From CargasSugeridas where IdCedis = @IdCedis and FechaCarga = @FechaInicial 

		Insert Into [Contenedor].[RouteADM].DBO.CargasSugeridasDetalle
		Select [IdCedis],[IdRuta],[FechaCarga],[IdProducto],[Tipo],[Folio],[Venta],[Cantidad],[Cambios]
		From CargasSugeridasDetalle where IdCedis = @IdCedis and FechaCarga = @FechaInicial 

		Insert Into [Contenedor].[RouteADM].DBO.CargasSugeridasFamilia
		Select [IdCedis],[IdRuta],[FechaCarga],[Folio],[IdFamilia],[Semanas],[Porcentaje]
		From CargasSugeridasFamilia where IdCedis = @IdCedis and FechaCarga = @FechaInicial 

		Insert Into [Contenedor].[RouteADM].DBO.CargasSugeridasProducto
		Select [IdCedis],[IdRuta],[FechaCarga],[Folio],[IdProducto],[Semanas],[Porcentaje]
		From CargasSugeridasProducto where IdCedis = @IdCedis and FechaCarga = @FechaInicial 

		Insert Into [Contenedor].[RouteADM].DBO.CargasSugeridasRuta
		Select [IdCedis],[IdRuta],[FechaCarga],[Folio],[IdRutaPedido],[FechaInicial],[FechaFinal]
		From CargasSugeridasRuta where IdCedis = @IdCedis and FechaCarga = @FechaInicial 

		fetch next from TRANSFERENCIA into @IdCedis, @FechaInicial
	end
	close TRANSFERENCIA
	deallocate TRANSFERENCIA

	-- CATÁLOGOS
	Delete from [Contenedor].[RouteADM].DBO.Rutas Where IdCedis = @IdCedis
	Insert Into [Contenedor].[RouteADM].DBO.Rutas
	Select [IdCedis],[IdRuta],[Ruta],[TipoRuta],[TipoVenta],[FechaAlta],[Status],[CFD] from Rutas Where IdCedis = @IdCedis

	Delete from [Contenedor].[RouteADM].DBO.Vendedores Where IdCedis = @IdCedis
	Insert Into [Contenedor].[RouteADM].DBO.Vendedores
	Select [IdCedis],[IdVendedor],[Nombre],[ApPaterno],[ApMaterno],[Nomina],[IdTipoVendedor],[FechaAlta],[Status],[Usuario] 
	from Vendedores Where IdCedis = @IdCedis

	Delete from [Contenedor].[RouteADM].DBO.VendedoresRutas Where IdCedis = @IdCedis
	Insert Into [Contenedor].[RouteADM].DBO.VendedoresRutas
	Select [IdCedis],[IdRuta],[IdVendedor],[IdTipoVendedor]
	from VendedoresRutas Where IdCedis = @IdCedis

	Insert into [Contenedor].[RouteADM].DBO.Productos 
	Select [IdProducto],[CodBarras],[Producto],[Iva],[Conversion],[IdMarca],[IdGrupo],[IdFamilia],[IdSubFamilia],[IdPresentacion],[FechaAlta],[Status],[Decimales]
	from productos where IdProducto not in ( Select IdProducto 
	from [Contenedor].[RouteADM].DBO.Productos)

	Insert into [Contenedor].[RouteADM].DBO.Bancos 
	Select [IdBanco],[Nombre]
	from Bancos where IdBanco not in (Select IdBanco from [Contenedor].[RouteADM].DBO.Bancos)

	Insert Into [Contenedor].[RouteADM].DBO.Clientes
	SELECT [IdCedis],[IdCliente],[RFC],[RazonSocial],[Domicilio],[Telefono],[Contacto],[email],[SitioWeb],[IdCanal],[IdCadena],[IdGrupoCadena],[DomicilioEntrega],[FechaAlta],[Status] 
	FROM Clientes Where IdCedis = @IdCedis and IdCliente not in (Select IdCliente from [Contenedor].[RouteADM].DBO.Clientes where IdCedis = @IdCedis )

	Insert Into [Contenedor].[RouteADM].DBO.ClienteSucursal
	SELECT [IdCedis],[IdCliente],[IdSucursal],[TDA_GLN],[NombreSucursal],[Calle],[NumExterior]
	,[NumInterior],[Colonia],[Localidad],[Poblacion],[Entidad],[Pais],[Telefonos]
	,[CP],[RFC],[RazonSocial],[CalleF],[NumExteriorF],[NumInteriorF],[ColoniaF]
	,[LocalidadF],[PoblacionF],[EntidadF],[PaisF],[TelefonosF],[CPF],[CodigoBarras]
	,[FormaVenta],[Status],[Contacto],[DiasCredito],[LimiteCredito]
	FROM ClienteSucursal Where IdCedis = @IdCedis and IdSucursal not in (Select IdSucursal from [Contenedor].[RouteADM].DBO.ClienteSucursal where IdCedis = @IdCedis)

	Insert Into [Contenedor].[RouteADM].DBO.ComEsquema
	SELECT [IdComEsquema],[Nombre],[Status],[Fecha],[Usuario]
	FROM ComEsquema Where IdComEsquema not in ( Select IdComEsquema from [Contenedor].[RouteADM].DBO.ComEsquema )

	Insert Into [Contenedor].[RouteADM].DBO.ComEsquemaCedis
	SELECT [IdComEsquema],[IdCedis],[Status],[Fecha],[Usuario]
	FROM ComEsquemaCedis Where IdCedis = @IdCedis and IdComEsquema not in ( Select IdComEsquema from [Contenedor].[RouteADM].DBO.ComEsquemaCedis where IdCedis = @IdCedis )

	Insert Into [Contenedor].[RouteADM].DBO.ComEsquemaFamilia
	SELECT [IdComEsquema],[IdFamilia],[Status],[Fecha],[Usuario]
	FROM ComEsquemaFamilia Where cast(IdComEsquema as varchar(10))+'-'+cast(IdFamilia as varchar(10)) not in 
	(Select cast(IdComEsquema as varchar(10))+'-'+cast(IdFamilia as varchar(10)) from [Contenedor].[RouteADM].DBO.ComEsquemaFamilia)

	Insert Into [Contenedor].[RouteADM].DBO.ComEsquemaPagos
	SELECT [IdComEsquema],[IdFamilia],[IdProducto],[IdConceptoPago],[Inicial],[Final],[IdTipoVendedor],[Pago],[Status],[Fecha],[Usuario]
	FROM ComEsquemaPagos
	Where cast(IdComEsquema as varchar(10))+'-'+cast(IdFamilia as varchar(10))+'-'+
	cast(IdProducto as varchar(10))+'-'+cast(IdConceptoPago as varchar(10))+'-'+
	cast(Inicial as varchar(30))+'-'+cast(Final as varchar(30))+'-'+
	cast(IdTipoVendedor as varchar(10)) not in 
	(Select cast(IdComEsquema as varchar(10))+'-'+cast(IdFamilia as varchar(10))+'-'+
	cast(IdProducto as varchar(10))+'-'+cast(IdConceptoPago as varchar(10))+'-'+
	cast(Inicial as varchar(30))+'-'+cast(Final as varchar(30))+'-'+
	cast(IdTipoVendedor as varchar(10))
	from [Contenedor].[RouteADM].DBO.ComEsquemaPagos)

	Insert Into [Contenedor].[RouteADM].DBO.ComEsquemaProducto
	SELECT [IdComEsquema],[IdProducto],[Status],[Fecha],[Usuario]
	FROM ComEsquemaProducto Where cast(IdComEsquema as varchar(10))+'-'+cast(IdProducto as varchar(10)) not in 
	(Select cast(IdComEsquema as varchar(10))+'-'+cast(IdProducto as varchar(10)) from [Contenedor].[RouteADM].DBO.ComEsquemaProducto)

	Insert Into [Contenedor].[RouteADM].DBO.ComEsquemaRangos
	SELECT [IdComEsquema],[IdFamilia],[IdProducto],[IdConceptoPago],[Inicial],[Final],[Status],[Fecha],[Usuario]
	FROM ComEsquemaRangos Where cast(IdComEsquema as varchar(10))+'-'+cast(IdFamilia as varchar(10))+'-'+
	cast(IdProducto as varchar(10))+'-'+cast(IdConceptoPago as varchar(10))+'-'+
	cast(Inicial as varchar(30))+'-'+cast(Final as varchar(30)) not in 
	(Select cast(IdComEsquema as varchar(10))+'-'+cast(IdFamilia as varchar(10))+'-'+
	cast(IdProducto as varchar(10))+'-'+cast(IdConceptoPago as varchar(10))+'-'+
	cast(Inicial as varchar(30))+'-'+cast(Final as varchar(30))
	from [Contenedor].[RouteADM].DBO.ComEsquemaRangos)

	Insert Into [Contenedor].[RouteADM].DBO.ComEsquemaTipoRuta
	SELECT [IdComEsquema],[IdTipoRuta],[Status],[Fecha],[Usuario]
	FROM ComEsquemaTipoRuta Where cast(IdComEsquema as varchar(10))+'-'+cast(IdTipoRuta as varchar(10)) not in 
	( Select cast(IdComEsquema as varchar(10))+'-'+cast(IdTipoRuta as varchar(10)) from [Contenedor].[RouteADM].DBO.ComEsquemaTipoRuta)

	Insert Into [Contenedor].[RouteADM].DBO.Monedas
	SELECT [IdMoneda],[Moneda],[Status],[Base]
	FROM Monedas Where IdMoneda not in (Select IdMoneda from [Contenedor].[RouteADM].DBO.Monedas)

	Insert Into [Contenedor].[RouteADM].DBO.MonedasMarcas
	SELECT [IdMoneda],[IdMarca]
	FROM MonedasMarcas Where ltrim(rtrim(IdMoneda))+'-'+cast(IdMarca as varchar(10)) not in (Select ltrim(rtrim(IdMoneda))+'-'+cast(IdMarca as varchar(10))
	from [Contenedor].[RouteADM].DBO.MonedasMarcas)

	Insert Into [Contenedor].[RouteADM].DBO.TipoDenominacion
	SELECT [IdTipoDenominacion],[TipoDenominacion],[Status]
	FROM TipoDenominacion Where IdTipoDenominacion not in (Select IdTipoDenominacion from [Contenedor].[RouteADM].DBO.TipoDenominacion)

	Insert Into [Contenedor].[RouteADM].DBO.Denominaciones
	SELECT [IdMoneda],[IdDenominacion],[TipoDenominacion],[Denominacion],[Status]
	FROM Denominaciones Where ltrim(rtrim(IdMoneda))+'-'+cast(IdDenominacion as varchar(10))+'-'+ltrim(rtrim(TipoDenominacion)) not in 
	(Select ltrim(rtrim(IdMoneda))+'-'+cast(IdDenominacion as varchar(10))+'-'+ltrim(rtrim(TipoDenominacion)) from [Contenedor].[RouteADM].DBO.Denominaciones)

	Insert Into [Contenedor].[RouteADM].DBO.TipoPago
	SELECT [IdTipoPago],[TipoPago]
	FROM TipoPago Where IdTipoPago not in (Select IdTipoPago from [Contenedor].[RouteADM].DBO.TipoPago) 

	Insert into [Contenedor].[RouteADM].DBO.PreciosLista 
	select [IdLista],[Descripcion],[TipoLista],[FechaAlta],[Status]
	from PreciosLista where Idlista not in (select IdLista from [Contenedor].[RouteADM].DBO.PreciosLista)

	Insert into [Contenedor].[RouteADM].DBO.PreciosDetalle 
	select [IdLista],[IdProducto],[Precio]
	from  PreciosDetalle where cast(Idlista as varchar(10))+'/'+cast(IdProducto as varchar(10)) not in 
	(select cast(Idlista as varchar(10))+'/'+cast(IdProducto as varchar(10)) from [Contenedor].[RouteADM].DBO.PreciosDetalle)

	Insert into [Contenedor].[RouteADM].DBO.PreciosListaCedis
	select [IdLista],[IdCedis]
	from PreciosListaCedis where IdCedis = @IdCedis and IdLista not in (Select IdLista from [Contenedor].[RouteADM].DBO.PreciosListaCedis where IdCedis = @IdCedis)

	Insert into [Contenedor].[RouteADM].DBO.PreciosListaCliente 
	Select  [IdCedis],[IdCliente],[IdLista]
	from  PreciosListaCliente where IdCedis = @IdCedis and cast(IdCliente as varchar(20))+'/'+cast(Idlista as varchar(10)) not in 
	(Select cast(IdCliente as varchar(20))+'/'+cast(Idlista as varchar(10)) from [Contenedor].[RouteADM].DBO.PreciosListaCliente where IdCedis = @IdCedis)

	Insert into [Contenedor].[RouteADM].DBO.PreciosListaRuta
	Select  [IdCedis],[IdRuta],[IdLista]
	from  PreciosListaRuta where IdCedis = @IdCedis and cast(IdRuta as varchar(10))+'/'+cast(Idlista as varchar(10)) not in 
	(Select cast(IdRuta as varchar(20))+'/'+cast(Idlista as varchar(10)) from [Contenedor].[RouteADM].DBO.PreciosListaRuta where IdCedis = @IdCedis)

	Insert Into [Contenedor].[RouteADM].DBO.ProductosUnidad
	SELECT [IdProducto],[IdUnidad],[Factor],[Divide],[CodigoBarras],[Orden]
	FROM ProductosUnidad Where cast(IdProducto as varchar(10))+'-'+ltrim(rtrim(IdUnidad)) not in 
	(Select cast(IdProducto as varchar(10))+'-'+ltrim(rtrim(IdUnidad)) from [Contenedor].[RouteADM].DBO.ProductosUnidad)

	-- TRANSACCIONES POR FOLIO
	Insert Into [Contenedor].[RouteADM].DBO.TipoDeCambio
	Select [Fecha],[IdMonedaBase],[IdMoneda],[TipoCambio]
	FROM TipoDeCambio Where cast(Fecha as varchar(10))+'-'+IdMonedaBase+'-'+IdMoneda not in 
	(Select cast(Fecha as varchar(10))+'-'+IdMonedaBase+'-'+IdMoneda from [Contenedor].[RouteADM].DBO.TipoDeCambio)

	Delete from [Contenedor].[RouteADM].DBO.PedidosDetalle 
	Where IdCedis = @IdCedis and IdPedido in 
	(Select IdPedido from [Contenedor].[RouteADM].DBO.Pedidos Where IdCedis = @IdCedis and FechaPedido Between (getdate()-45) and (getdate()+45)) 
	Delete from [Contenedor].[RouteADM].DBO.Pedidos 
	Where IdCedis = @IdCedis and FechaPedido Between (getdate()-45) and (getdate()+45) 

	Insert into [Contenedor].[RouteADM].DBO.Pedidos 
	([IdCedis],[IdPedido],[IdTipoVenta],[FechaPedido],[IdRutaPedido],[FechaEntrega],[IdRutaEntrega],[IdCliente],[IdSucursal],[DctoImp],[SubTotal],[Iva],[IdSurtido],[Serie],[Folio],[DiasCredito])
	Select [IdCedis],[IdPedido],[IdTipoVenta],[FechaPedido],[IdRutaPedido],[FechaEntrega],[IdRutaEntrega],[IdCliente],[IdSucursal],[DctoImp],[SubTotal],[Iva],[IdSurtido],[Serie],[Folio],[DiasCredito]
	from Pedidos where IdCedis = @IdCedis and IdPedido not in (Select IdPedido from  [Contenedor].[RouteADM].DBO.Pedidos where IdCedis = @IdCedis)
	Insert into [Contenedor].[RouteADM].DBO.PedidosDetalle 
	([IdCedis],[IdPedido],[IdTipoVenta],[IdProducto],[Cantidad],[Precio],[Iva],[DctoPorc],[DctoImp],[Entregado])
	Select [IdCedis],[IdPedido],[IdTipoVenta],[IdProducto],[Cantidad],[Precio],[Iva],[DctoPorc],[DctoImp],[Entregado]
	from  PedidosDetalle where IdCedis = @IdCedis and cast(IdPedido as varchar(10))+'-'+cast(IdTipoVenta as varchar(10))+'-'+
	cast(IdProducto as varchar(10)) not in (Select cast(IdPedido as varchar(10))+'-'+cast(IdTipoVenta as varchar(10))+'-'+
	cast(IdProducto as varchar(10)) from [Contenedor].[RouteADM].DBO.PedidosDetalle where IdCedis = @IdCedis)

	Delete from [Contenedor].[RouteADM].DBO.VendedoresSaldosFinanciaD
	Where IdCedis = @IdCedis and IdCorto in 
	(Select IdCorto from [Contenedor].[RouteADM].DBO.VendedoresSaldosFinancia Where IdCedis = @IdCedis and Fecha Between (getdate()-45) and (getdate()+45)) 
	Delete from [Contenedor].[RouteADM].DBO.VendedoresSaldosFinancia
	Where IdCedis = @IdCedis and Fecha Between (getdate()-45) and (getdate()+45) 

	Insert into [Contenedor].[RouteADM].DBO.VendedoresSaldosFinancia 
	([IdCedis],[IdCorto],[IdSurtido],[IdVendedor],[MontoFinanciar],[Pagos],[Frecuencia],[FechaInicio],[Autoriza],[Concepto],[Status],[FechaElaboracion],[Fecha])
	Select [IdCedis],[IdCorto],[IdSurtido],[IdVendedor],[MontoFinanciar],[Pagos],[Frecuencia],[FechaInicio],[Autoriza],[Concepto],[Status],[FechaElaboracion],[Fecha]
	from VendedoresSaldosFinancia Where IdCedis = @IdCedis and Fecha Between (getdate()-45) and (getdate()+45) 
	Insert into [Contenedor].[RouteADM].DBO.VendedoresSaldosFinanciaD 
	([IdCedis],[IdCorto],[IdSurtido],[IdVendedor],[IdPago],[Monto],[Fecha],[Status])
	Select [IdCedis],[IdCorto],[IdSurtido],[IdVendedor],[IdPago],[Monto],[Fecha],[Status]
	from  VendedoresSaldosFinanciaD Where IdCedis = @IdCedis and IdCorto in 
	(Select IdCorto from [Contenedor].[RouteADM].DBO.VendedoresSaldosFinancia Where IdCedis = @IdCedis and Fecha Between (getdate()-45) and (getdate()+45)) 

	-- ACTUALIZA VENTASACREDITA
	update [Contenedor].[RouteADM].dbo.VentasAcredita set Fecha=VACL.Fecha, FechaAcredita=VACL.FechaAcredita,Login=VACL.Login,FechaEntrega=VACL.FechaEntrega,FolioEntrega=VACL.FolioEntrega,
	Observaciones=VACL.Observaciones,FolioCliente=VACL.FolioCliente,Remision=VACL.Remision,Factura=VACL.Factura,Status=VACL.Status,Vencimiento=VACL.Vencimiento
	From VentasAcredita VACL,  [Contenedor].[RouteADM].dbo.VentasAcredita VACC
	where VACL.IdCedis = @IdCedis and VACL.IdSurtido in (SELECT SUR.IdSurtido FROM Surtidos SUR WHERE SUR.IdCedis = @IdCedis and SUR.Fecha between @FechaInicial - 7 and @FechaInicial)
	and VACL.IdCedis = VACC.IdCedis and VACL.IdSurtido = VACC.IdSurtido and VACL.IdTipoVenta = VACC.IdTipoVenta and VACL.Folio = VACC.Folio 

	-- ACTUALIZA STATUS EN TABLAS
	Update Surtidos set StatusTransferido = 'T'
	where Fecha in (SELECT Fecha FROM VWDetalleDiasATransferir
	Where Totalsurtidos = SurtidosTerminados and TotalSurtidos = SurtidosNoTransferidos and 
	TotalProductos = ProductosAplicados and TotalProductos = ProductosNotransferidos )

	Update InventarioFisico set StatusTransferido = 'T'
	where Fecha in (SELECT Fecha FROM VWDetalleDiasATransferir
	Where TotalProductos = ProductosAplicados and TotalProductos = ProductosNotransferidos and ProductosNotransferidos>0 )

	Update InventarioInicial set StatusTransferido = 'T'
	where CAST(Agno AS varchar(4)) + REPLICATE('0', 2 - LEN(CAST(Mes AS varchar(2)))) + CAST(Mes AS varchar(2)) in (SELECT AgnoMes FROM VWInventarioInicialATransferir
	Where TotalProductos = ProductosAplicados and TotalProductos = ProductosNotransferidos and ProductosNotransferidos>0 )

	-- VALIDA ACREDITACIONES
	select top 1 @FechaFinal = Fecha from StatusDia where Status = 'C' order by Fecha desc	
	
	declare InsertaVentasAcreditadasPendientes cursor for
		Select VAC.IdCedis, VAC.IdSurtido, VAC.IdTipoVenta, VAC.Folio
		--, vac.fechaacredita, vacc.fechaacredita, vac.status, vacc.status, VAC.FolioEntrega, VACC.FolioEntrega, VAC.FolioCliente, VACC.FolioCliente, VAC.Remision, VACC.Remision, VAC.Factura, VACC.Factura
		From VentasAcredita VAC
		left outer join [Contenedor].[RouteADM].DBO.VentasAcredita VACC on VACC.IdCedis = VAC.IdCedis and VACC.IdSurtido = VAC.IdSurtido 
			and VACC.IdTipoVenta = VAC.IdTipoVenta and VACC.Folio = VAC.Folio 
		where VAC.FechaAcredita between (@FechaFinal-45) and @FechaFinal and (VACC.IdCedis is null or VAC.status <> VACC.status
			or VAC.FolioEntrega <> VACC.FolioEntrega or VAC.FolioCliente <> VACC.FolioCliente 
			or VAC.Remision <> VACC.Remision or VAC.Factura <> VACC.Factura)
	open InsertaVentasAcreditadasPendientes
	fetch next from InsertaVentasAcreditadasPendientes into @IdCedis, @IdSurtido, @IdTipoVenta, @Folio 
	while @@fetch_status = 0
	begin
		
		delete from [Contenedor].[RouteADM].dbo.VentasAcredita where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdTipoVenta = @IdTipoVenta and Folio = @Folio 
		
		Insert Into [Contenedor].[RouteADM].dbo.VentasAcredita
		Select [IdCedis],[IdSurtido],[IdTipoVenta],[Folio],[Serie],[Fecha],[FechaAcredita],[Login],[FechaEntrega],[FolioEntrega],[Observaciones],[FolioCliente],[Remision],[Factura],[Status],[Vencimiento]
		From VentasAcredita where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdTipoVenta = @IdTipoVenta and Folio = @Folio 
		
		fetch next from InsertaVentasAcreditadasPendientes into @IdCedis, @IdSurtido, @IdTipoVenta, @Folio 
	end
	close InsertaVentasAcreditadasPendientes
	deallocate InsertaVentasAcreditadasPendientes


GO


